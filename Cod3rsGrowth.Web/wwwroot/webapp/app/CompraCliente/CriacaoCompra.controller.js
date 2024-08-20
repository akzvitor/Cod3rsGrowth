sap.ui.define([
    "ui5/coders/app/common/BaseController",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "ui5/coders/model/formatter",
    "ui5/coders/model/validator",
    "sap/ui/core/library",
    "sap/ui/model/json/JSONModel",

], (BaseController, Filter, FilterOperator, formatter, validator, coreLibrary, JSONModel) => {
    "use strict";

    const { ValueState } = coreLibrary;
    const ROTA_CRIACAO = "criacaoCompra";
    const ROTA_EDICAO = "edicaoCompra";
    const API_OBRAS_URL = "http://localhost:5070/api/Obras";
    const MODELO_OBRAS = "restObras";
    const MODELO_COMPRAS = "restCompras";
    const API_COMPRAS_URL = "http://localhost:5070/api/Compras";
    const ID_NOME_FORM_INPUT = "nomeFormInput";
    const ID_EMAIL_FORM_INPUT = "emailFormInput";
    const ID_CPF_FORM_INPUT = "cpfFormInput";
    const ID_TELEFONE_FORM_INPUT = "telefoneFormInput";
    const ID_ERRO_VALIDACAO_PRODUTOS = "mensagemErroProdutos";
    const ID_CATALOGO_OBRAS = "catalogoObras";
    const ID_MESSAGESTRIP_SUCESSO = "messageStripSucesso";
    const ID_MESSAGESTRIP_ERRO = "messageStripErro";
    const ID_PAGINA = "paginaCriacaoCompra";

    return BaseController.extend("ui5.coders.app.CompraCliente.CriacaoCompra", {
        formatter: formatter,
        validator: validator,

        onInit() {
            this._aoCoincidirRota(API_OBRAS_URL, MODELO_OBRAS);
        },

         _aoCoincidirRota(urlDaApi, nomeDoModelo) {
			this.processarAcao(() => {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.getRoute(ROTA_CRIACAO).attachPatternMatched(() => {
					this.inicializarDados(urlDaApi, nomeDoModelo);
                    this._limparInputs();
                    this._esconderMensagensDeErro();
                    this._removerSelecoes();
                    this._removerValueStates();
				}, this);
                oRouter.getRoute(ROTA_EDICAO).attachPatternMatched((oEvent) => {
                    this._alterarTituloParaEditar()
                    this._esconderMensagensDeErro();
                    this._removerValueStates();
                    this.inicializarDados(urlDaApi, nomeDoModelo);
                    this.preencherInputsComDadosDaCompra(oEvent);
                }, this);
			});
		},

        preencherInputsComDadosDaCompra(oEvent) {
            let sucesso = true;
		    fetch(API_COMPRAS_URL + "/" + window.decodeURIComponent(oEvent.getParameter("arguments").idCompra))
				.then((res) => {
					if (!res.ok)
						sucesso = false;
					return res.json();
				})
				.then((data) => {
					sucesso ? this.getView().setModel(new JSONModel(data), MODELO_COMPRAS) : this.capturarErroApi(data);

                    this.oView.byId(ID_NOME_FORM_INPUT).setValue(data.nome);
                    this.oView.byId(ID_EMAIL_FORM_INPUT).setValue(data.email);
                    this.oView.byId(ID_CPF_FORM_INPUT).setValue(formatter.formatarCpf(data.cpf));
                    this.oView.byId(ID_TELEFONE_FORM_INPUT).setValue(formatter.formatarTelefone(data.telefone));
                    this._selecionarItensComprados(data.listaIdDosProdutos);

				})
				.catch((err) => console.error(err));
        },

        aoClicarNoBotaoSalvar() {
            this.processarAcao(() => {
                const inputNome = this.oView.byId(ID_NOME_FORM_INPUT);
                const valorNome = inputNome.getValue();
                const inputEmail = this.oView.byId(ID_EMAIL_FORM_INPUT);
                const valorEmail = inputEmail.getValue()
                const inputCpf = this.oView.byId(ID_CPF_FORM_INPUT);
                const valorCpf = inputCpf.getValue()
                const inputTelefone = this.oView.byId(ID_TELEFONE_FORM_INPUT);
                const valorTelefone = inputTelefone.getValue()
                const dataDaCompra = new Date();
                const oObrasSelecionadas = this._obterObrasSelecionadas();
                const erroListaDeProdutosVazia = 0;
                const data = {
                    cpf: valorCpf,
                    nome: valorNome,
                    telefone: valorTelefone,
                    email: valorEmail,
                    dataCompra: dataDaCompra,
                    valorCompra: oObrasSelecionadas.valorTotalCompra,
                    listaIdDosProdutos: oObrasSelecionadas.listaIdsSelecionados
                }

                const dadosSaoValidos = validator.validarDados(inputNome, inputEmail, inputTelefone, inputCpf);

                if(!dadosSaoValidos)
                    this.oView.byId(ID_MESSAGESTRIP_ERRO).setVisible(true);

                if (oObrasSelecionadas.listaIdsSelecionados.length === erroListaDeProdutosVazia)
                    this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(true);

                if (dadosSaoValidos && oObrasSelecionadas.listaIdsSelecionados.length !== erroListaDeProdutosVazia) {
                    this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(false);
                    this._postData(data);
                    this._limparInputs();
                    this._esconderMensagensDeErro();
                    this._removerSelecoes();
                    this._removerValueStates();
                    this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setVisible(true);
                }
            });
        },

        aoProcurarObra(oEvent) {
            this.processarAcao(() => {
                const aFilter = [];
                const sQuery = oEvent.getParameter("query");
                if (sQuery) {
                    aFilter.push(new Filter("titulo", FilterOperator.Contains, sQuery));
                }

                const oList = this.byId(ID_CATALOGO_OBRAS);
                const oBinding = oList.getBinding("items");
                oBinding.filter(aFilter);
            });
        },

        _obterObrasSelecionadas() {
            return this.processarAcao(() => {
                let oList = this.byId(ID_CATALOGO_OBRAS);
                let itensSelecionados = oList.getSelectedItems();
                console.log(oList);
                let obj = { listaIdsSelecionados: [], valorTotalCompra: 0 };

                for (let i = 0; i < itensSelecionados.length; i++) {
                    let itemSelecionado = itensSelecionados[i];
                    let contexto = itemSelecionado.getBindingContext(MODELO_OBRAS);
                    let obra = contexto.getProperty(null, contexto);

                    obj.listaIdsSelecionados[i] = obra.id;
                    obj.valorTotalCompra += obra.valorObra;
                };

                return obj;
            });
        },

        _selecionarItensComprados(listaDeIds) {
            return this.processarAcao(() => {
                let oList = this.byId(ID_CATALOGO_OBRAS);
                let itensDoCatalogo = oList.getItems();

                for (let i = 0; i< itensDoCatalogo.length; i++) {
                    let itemSelecionado = itensDoCatalogo[i];
                    let contexto = itemSelecionado.getBindingContext(MODELO_OBRAS);
                    let obra = contexto.getProperty(null, contexto);

                    if(listaDeIds.includes(obra.id)) {
                        oList.setSelectedItem(itemSelecionado);
                    }
                };
            });
        },

        _postData(data) {
            fetch(API_COMPRAS_URL, {
                method: 'POST',
                body: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => response.json())
                .then(data => console.log(data));
        },

        _limparInputs() {
            this.processarAcao(() => {
                this.oView.byId(ID_NOME_FORM_INPUT).setValue(null);
                this.oView.byId(ID_EMAIL_FORM_INPUT).setValue(null);
                this.oView.byId(ID_CPF_FORM_INPUT).setValue(null);
                this.oView.byId(ID_TELEFONE_FORM_INPUT).setValue(null);
            });
        },

        _esconderMensagensDeErro() {
            this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(false);
            this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setVisible(false);
            this.oView.byId(ID_MESSAGESTRIP_ERRO).setVisible(false);
        },

        _removerValueStates() {
            this.oView.byId(ID_NOME_FORM_INPUT).setValueState(ValueState.None);
            this.oView.byId(ID_EMAIL_FORM_INPUT).setValueState(ValueState.None);
            this.oView.byId(ID_CPF_FORM_INPUT).setValueState(ValueState.None);
            this.oView.byId(ID_TELEFONE_FORM_INPUT).setValueState(ValueState.None);
        },

        _removerSelecoes() {
            this.getView().byId(ID_CATALOGO_OBRAS).removeSelections(true);
        },

        _alterarTituloParaEditar() {
            this.oView.byId(ID_PAGINA).setTitle("Editar Compra");
        },

        aoPreencherNome(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarNome(oInput);
            });
        },

        aoPreencherEmail(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarEmail(oInput);
            });
        },

        aoPreencherTelefone(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarTelefone(oInput);
            });
        },

        aoPreencherCpf(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarCpf(oInput);
            });
        },

        onSelectionChange() {
            this.processarAcao(() => {
                this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(false);
            });
        }
    });
});