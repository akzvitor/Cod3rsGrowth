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
    var rota;
    var id_parametro;
    var dataEdicao;

    return BaseController.extend("ui5.coders.app.CompraCliente.CriacaoCompra", {
        formatter: formatter,
        validator: validator,

        onInit() {
            this._aoCoincidirRota(API_OBRAS_URL, MODELO_OBRAS);
        },

        _aoCoincidirRota(urlDaApi, nomeDoModelo) {
            this.processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_CRIACAO).attachPatternMatched((oEvent) => {
                    const oRouter = this.getRouter();
                    rota = oRouter.getRoute(oEvent.getParameter('name'))._oConfig.name;
                    this.alterarTituloDaPagina(ID_PAGINA, "CriacaoCompra.titulo")
                    this.inicializarDados(urlDaApi, nomeDoModelo);
                    this._limparInputs();
                    this._esconderMensagensDeErro();
                    this._removerSelecoes();
                    this._removerValueStates();
                }, this);
                oRouter.getRoute(ROTA_EDICAO).attachPatternMatched((oEvent) => {
                    const oRouter = this.getRouter();
                    rota = oRouter.getRoute(oEvent.getParameter('name'))._oConfig.name;
                    this.resgatarIdURL(oEvent);
                    this.alterarTituloDaPagina(ID_PAGINA, "EdicaoCompra.titulo")
                    this._esconderMensagensDeErro();
                    this._removerValueStates();
                    this.inicializarDados(urlDaApi, nomeDoModelo);
                    this.preencherInputsComDadosDaCompra(oEvent);
                }, this);
            });
        },

        preencherInputsComDadosDaCompra(oEvent) {
            fetch(API_COMPRAS_URL + "/" + window.decodeURIComponent(oEvent.getParameter("arguments").idCompra))
                .then((res) => {
                    return res.json();
                })
                .then((data) => {
                    !data.Detail ? this.getView().setModel(new JSONModel(data), MODELO_COMPRAS) : this.capturarErroApi(data);

                    this._selecionarItensComprados(data.listaIdDosProdutos);
                    this.resgatarDataEdicao(data.dataCompra);
                })
                .catch((err) => console.error(err));
        },

        resgatarIdURL(oEvent) {
            id_parametro = window.decodeURIComponent(oEvent.getParameter("arguments").idCompra);
        },

        resgatarDataEdicao(data) {
            dataEdicao = data;
        },

        aoClicarNoBotaoSalvar() {
            this.processarAcao(() => {
                const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
                const [inputCpf, inputEmail, inputNome, inputTelefone] = this._obterInputs();
                const erroListaDeProdutosVazia = 0;
                let compra = this._criarCompra();
                const oObrasSelecionadas = this._obterObrasSelecionadas();

                const dadosSaoValidos = validator.validarDados(inputNome, inputEmail, inputTelefone, inputCpf);

                if (!dadosSaoValidos) {
                    if (rota === ROTA_CRIACAO)
                        this.oView.byId(ID_MESSAGESTRIP_ERRO).setText(oResourceBundle.getText("CriacaoCompra.messageStripErroCriar"));

                    if (rota === ROTA_EDICAO)
                        this.oView.byId(ID_MESSAGESTRIP_ERRO).setText(oResourceBundle.getText("CriacaoCompra.messageStripErroEditar"));

                    this.oView.byId(ID_MESSAGESTRIP_ERRO).setVisible(true);
                }

                if (oObrasSelecionadas.listaIdsSelecionados.length === erroListaDeProdutosVazia)
                    this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(true);

                if (dadosSaoValidos && oObrasSelecionadas.listaIdsSelecionados.length !== erroListaDeProdutosVazia)
                    this._salvarCompra(compra);
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

        _obterInputs() {
            return this.processarAcao(() => {
                const inputNome = this.oView.byId(ID_NOME_FORM_INPUT);
                const inputEmail = this.oView.byId(ID_EMAIL_FORM_INPUT);
                const inputCpf = this.oView.byId(ID_CPF_FORM_INPUT);
                const inputTelefone = this.oView.byId(ID_TELEFONE_FORM_INPUT);

                return [inputCpf, inputEmail, inputNome, inputTelefone];
            });
        },

        _criarCompra() {
            return this.processarAcao(() => {
                const [inputCpf, inputEmail, inputNome, inputTelefone] = this._obterInputs();
                const dataDaCompra = new Date();
                const oObrasSelecionadas = this._obterObrasSelecionadas();

                return {
                    cpf: inputCpf.getValue(),
                    nome: inputNome.getValue(),
                    telefone: inputTelefone.getValue(),
                    email: inputEmail.getValue(),
                    dataCompra: dataDaCompra,
                    valorCompra: oObrasSelecionadas.valorTotalCompra,
                    listaIdDosProdutos: oObrasSelecionadas.listaIdsSelecionados
                };
            });
        },

        _salvarCompra(compra) {
            this.processarAcao(() => {
                this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(false);
                const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();

                if (rota === ROTA_CRIACAO) {
                    this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setText(oResourceBundle.getText("CriacaoCompra.messageStripSucessoCriar"));
                    this.postData(API_COMPRAS_URL, compra);
                    this._limparInputs();
                    this._removerSelecoes();
                }

                if (rota === ROTA_EDICAO) {
                    this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setText(oResourceBundle.getText("CriacaoCompra.messageStripSucessoEditar"));
                    compra.id = id_parametro;
                    compra.dataCompra = dataEdicao;
                    this.putData(API_COMPRAS_URL, compra)
                }

                this._esconderMensagensDeErro();
                this._removerValueStates();
                this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setVisible(true);
            })
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

        _selecionarItensComprados(listaDeIds) {
            return this.processarAcao(() => {
                let oList = this.byId(ID_CATALOGO_OBRAS);
                let itensDoCatalogo = oList.getItems();

                for (let i = 0; i < itensDoCatalogo.length; i++) {
                    let itemSelecionado = itensDoCatalogo[i];
                    let contexto = itemSelecionado.getBindingContext(MODELO_OBRAS);
                    let obra = contexto.getProperty(null, contexto);

                    if (listaDeIds.includes(obra.id)) {
                        oList.setSelectedItem(itemSelecionado);
                    }
                };
            });
        },

        _limparInputs() {
            this.processarAcao(() => {
                const listaDeInputs = this._obterInputs();

                listaDeInputs.forEach(input => {
                    input.setValue(null);
                });
            });
        },

        _esconderMensagensDeErro() {
            this.oView.byId(ID_ERRO_VALIDACAO_PRODUTOS).setVisible(false);
            this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setVisible(false);
            this.oView.byId(ID_MESSAGESTRIP_ERRO).setVisible(false);
        },

        _removerValueStates() {
            this.processarAcao(() => {
                const listaDeInputs = this._obterInputs();

                listaDeInputs.forEach(input => {
                    input.setValueState(ValueState.None);
                });
            });
        },

        _removerSelecoes() {
            this.getView().byId(ID_CATALOGO_OBRAS).removeSelections(true);
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