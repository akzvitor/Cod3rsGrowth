sap.ui.define([
    "ui5/coders/app/common/BaseController",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "ui5/coders/model/formatter",
    "ui5/coders/model/validator",
    "sap/ui/core/library"


], (BaseController, Filter, FilterOperator, formatter, validator, coreLibrary) => {
    "use strict";

    const { ValueState } = coreLibrary;
    const ROTA_CRIACAO = "criacaoCompra"
    const API_OBRAS_URL = "http://localhost:5070/api/Obras";
    const MODELO_OBRAS = "restObras";
    const API_COMPRAS_URL = "http://localhost:5070/api/Compras";
    const ID_NOME_FORM_INPUT = "nomeFormInput";
    const ID_EMAIL_FORM_INPUT = "emailFormInput";
    const ID_CPF_FORM_INPUT = "cpfFormInput";
    const ID_TELEFONE_FORM_INPUT = "telefoneFormInput";
    const ID_ERRO_VALIDACAO_PRODUTOS = "mensagemErroProdutos";
    const ID_CATALOGO_OBRAS = "catalogoObras";
    const ID_MESSAGESTRIP_SUCESSO = "messageStripSucesso";

    return BaseController.extend("ui5.coders.app.CompraCliente.CriacaoCompra", {
        formatter: formatter,
        validator: validator,

        onInit() {
            this._aoCoincidirRota(ROTA_CRIACAO, API_OBRAS_URL, MODELO_OBRAS);
        },

         _aoCoincidirRota(rota, urlDaApi, nomeDoModelo) {
			this.processarAcao(() => {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.getRoute(rota).attachPatternMatched(() => {
					this.inicializarDados(urlDaApi, nomeDoModelo);
                    this._limparForm();
				}, this);
			});
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

                if (oObrasSelecionadas.listaIdsSelecionados.length === erroListaDeProdutosVazia)
                    this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(true);

                if (dadosSaoValidos && oObrasSelecionadas.listaIdsSelecionados.length !== erroListaDeProdutosVazia) {
                    this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(false);
                    this._postData(data);
                    this._limparForm();
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

        _limparForm() {
            this.processarAcao(() => {
                this.oView.byId(ID_NOME_FORM_INPUT).setValue(null);
                this.oView.byId(ID_EMAIL_FORM_INPUT).setValue(null);
                this.oView.byId(ID_CPF_FORM_INPUT).setValue(null);
                this.oView.byId(ID_TELEFONE_FORM_INPUT).setValue(null);
                this.oView.byId(ID_NOME_FORM_INPUT).setValueState(ValueState.None);
                this.oView.byId(ID_EMAIL_FORM_INPUT).setValueState(ValueState.None);
                this.oView.byId(ID_CPF_FORM_INPUT).setValueState(ValueState.None);
                this.oView.byId(ID_TELEFONE_FORM_INPUT).setValueState(ValueState.None);
                this.getView().byId(ID_CATALOGO_OBRAS).removeSelections(true);
                this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(false);
                this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setVisible(false);
            });
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