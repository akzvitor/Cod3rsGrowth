sap.ui.define([
    "ui5/coders/app/common/BaseController",
    'ui5/coders/model/formatter',
    'ui5/coders/model/validator',
    "sap/ui/core/library",
 
], (BaseController, formatter, validator, coreLibrary) => {
    "use strict";
 
    const { ValueState } = coreLibrary;
    const ROTA_CRIACAO_OBRA = "criacaoObra";
    const API_OBRAS_URL = "http://localhost:5070/api/Obras";
    const API_FORMATOS_URL ="http://localhost:5070/api/Obras/formatos";
    const MODELO_FORMATOS = "restFormatos";
    const API_GENEROS_URL = "http://localhost:5070/api/Obras/generos";
    const MODELO_GENEROS = "restGeneros";
    const ID_TITULO_INPUT = "tituloFormInput";
    const ID_AUTOR_INPUT = "autorFormInput";
    const ID_FORMATO_COMBOBOX = "formatoComboBox";
    const ID_CAPITULOS_STEPINPUT = "stepInputCapitulos";
    const ID_STATUS_COMBOBOX = "statusComboBox";
    const ID_DATAPUBLI_DATEPICKER = "datePickerFormInput";
    const ID_VALOR_STEPINPUT = "stepInputValor";
    const ID_SINOPSE_TEXTAREA = "sinopseTextArea";
    const ID_GENEROS_MULTICOMBOBOX = "generosMultiComboBox";
    const ID_MESSAGESTRIP_SUCESSO = "messageStripSucesso";
    const ID_MESSAGESTRIP_ERRO = "messageStripErro";

    return BaseController.extend("ui5.coders.app.Obra.CriacaoObra", {
        formatter: formatter,
        validator: validator,
 
        onInit() {
            this._aoCoincidirRota();
        },

        _aoCoincidirRota() {
            this.processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(ROTA_CRIACAO_OBRA).attachPatternMatched((oEvent) => {
                    this.inicializarComboBox(API_FORMATOS_URL, MODELO_FORMATOS);
                    this.inicializarComboBox(API_GENEROS_URL, MODELO_GENEROS);
                    this._limparInputs();
                    this._removerSelecoes();
                    this._esconderMensagensDeErro();
                    this._removerValueStates();
                }, this);
            });
        },

        aoClicarNoBotaoSalvar() {
            this.processarAcao(() => {
                const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
                const inputTitulo = this.oView.byId(ID_TITULO_INPUT);
                const inputAutor = this.oView.byId(ID_AUTOR_INPUT);
                const inputFormato = this.oView.byId(ID_FORMATO_COMBOBOX);
                const inputCapitulos = this.oView.byId(ID_CAPITULOS_STEPINPUT);
                const inputStatus = this.oView.byId(ID_STATUS_COMBOBOX);
                const inputDataPubli = this.oView.byId(ID_DATAPUBLI_DATEPICKER);
                const inputValor = this.oView.byId(ID_VALOR_STEPINPUT);
                const inputSinopse = this.oView.byId(ID_SINOPSE_TEXTAREA);
                const inputGeneros = this.oView.byId(ID_GENEROS_MULTICOMBOBOX);
                const dadosSaoValidos = validator.validarDadosObra(inputTitulo, inputAutor, inputSinopse, inputDataPubli,
                    inputFormato, inputGeneros, inputStatus);
                let data = {
                    titulo: inputTitulo.getValue(),
                    autor: inputAutor.getValue(),
                    numeroCapitulos: inputCapitulos.getValue(),
                    valorObra: inputValor.getValue(),
                    formato: formatter.formatarFormatoParaApi(inputFormato.getSelectedKey()),
                    foiFinalizada: formatter.converterStringParaBoolean(inputStatus.getSelectedKey()),
                    inicioPublicacao: formatter.formatarDataParaApi(inputDataPubli.getDateValue()),
                    sinopse: inputSinopse.getValue(),
                    generos: formatter.formatarGenerosParaApi(inputGeneros.getSelectedKeys()),
                    capaImagemBase64: null
                };

                console.log(typeof(formatter.formatarFormatoParaApi(inputFormato.getSelectedKey())));
                console.log(data.inicioPublicacao);
                console.log(inputDataPubli.getDateValue())

                if (!dadosSaoValidos) {
                    this.oView.byId(ID_MESSAGESTRIP_ERRO).setText(oResourceBundle.getText("CriacaoObra.messageStripErroCriar"));
                    this.oView.byId(ID_MESSAGESTRIP_ERRO).setVisible(true);
                }

                if (dadosSaoValidos) {
                    this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setText(oResourceBundle.getText("CriacaoObra.messageStripSucessoCriar"));
                    this.postData(API_OBRAS_URL, data);
                    this._limparInputs();
                    this._esconderMensagensDeErro();
                    this._removerValueStates();
                    this._removerSelecoes();
                    this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setVisible(true);
                    
                }
            });
        },

        _removerSelecoes() {
            this.getView().byId(ID_GENEROS_MULTICOMBOBOX).removeAllSelectedItems();
        },

        _limparInputs() {
            this.processarAcao(() => {
                this.oView.byId(ID_TITULO_INPUT).setValue(null);
                this.oView.byId(ID_AUTOR_INPUT).setValue(null);
                this.oView.byId(ID_FORMATO_COMBOBOX).setValue(null);
                this.oView.byId(ID_CAPITULOS_STEPINPUT).setValue(null);
                this.oView.byId(ID_STATUS_COMBOBOX).setValue(null);
                this.oView.byId(ID_DATAPUBLI_DATEPICKER).setValue(null);
                this.oView.byId(ID_VALOR_STEPINPUT).setValue(null);
                this.oView.byId(ID_GENEROS_MULTICOMBOBOX).setValue(null);
                this.oView.byId(ID_SINOPSE_TEXTAREA).setValue(null);
            });
        },

        _esconderMensagensDeErro() {
            this.processarAcao(() => {
                this.oView.byId(ID_MESSAGESTRIP_SUCESSO).setVisible(false);
                this.oView.byId(ID_MESSAGESTRIP_ERRO).setVisible(false);
            })
        },

        _removerValueStates() {
            this.processarAcao(() => {
                this.oView.byId(ID_TITULO_INPUT).setValueState(ValueState.None)
                this.oView.byId(ID_AUTOR_INPUT).setValueState(ValueState.None)
                this.oView.byId(ID_FORMATO_COMBOBOX).setValueState(ValueState.None)
                this.oView.byId(ID_CAPITULOS_STEPINPUT).setValueState(ValueState.None)
                this.oView.byId(ID_STATUS_COMBOBOX).setValueState(ValueState.None)
                this.oView.byId(ID_DATAPUBLI_DATEPICKER).setValueState(ValueState.None)
                this.oView.byId(ID_VALOR_STEPINPUT).setValueState(ValueState.None)
                this.oView.byId(ID_GENEROS_MULTICOMBOBOX).setValueState(ValueState.None)
                this.oView.byId(ID_SINOPSE_TEXTAREA).setValueState(ValueState.None)
            })
        },

        aoPreencherTitulo(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarTitulo(oInput);
            });
        },

        aoPreencherAutor(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarAutor(oInput);
            });
        },

        aoSelecionarFormato(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarFormato(oInput);
            });
        },

        aoSelecionarStatus(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarStatus(oInput);
            });
        },

        aoSelecionarData(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarInicioDaPublicacao(oInput);
            });
        },

        aoSelecionarGeneros(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarGeneros(oInput);
            });
        },

        aoPreencherSinopse(oEvent) {
            this.processarAcao(() => {
                const oInput = oEvent.getSource();

                validator.validarSinopse(oInput);
            });
        }
    });
});