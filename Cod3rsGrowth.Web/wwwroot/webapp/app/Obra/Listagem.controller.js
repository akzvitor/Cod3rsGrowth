sap.ui.define([
    "ui5/coders/app/common/BaseController",
    'ui5/coders/model/formatter',
    "sap/ui/model/json/JSONModel",
 
], (BaseController, formatter, JSONModel) => {
    "use strict";
 
    const ROTA_LISTAGEM_OBRAS = "listagemObra";
    const API_OBRAS_URL = "http://localhost:5070/api/Obras";
    const API_FORMATOS_URL = "http://localhost:5070/api/Obras/formatos";
    const MODELO_OBRAS = "restObras";
    const MODELO_FORMATOS = "restFormatos";
    const ID_INPUT_TITULO = "tituloFiltroInput";
    const ID_INPUT_AUTOR = "autorFiltroInput";
    const ID_COMBOBOX_STATUS = "statusFiltroComboBox";
    const ID_COMBOBOX_FORMATO = "formatoFiltroComboBox";
 
    return BaseController.extend("ui5.coders.app.Obra.Listagem", {
        formatter: formatter,
 
        onInit() {
            this.aoCoincidirRota(ROTA_LISTAGEM_OBRAS, API_OBRAS_URL, MODELO_OBRAS);
            this.inicializarComboBox(API_FORMATOS_URL, MODELO_FORMATOS);
        },
 
        aoAlterarInputFiltro() {
            this.processarAcao(() => {
                let urlFiltro = "http://localhost:5070/api/Obras?";
                const inputTitulo = this.oView.byId(ID_INPUT_TITULO).getValue();
                const inputAutor = this.oView.byId(ID_INPUT_AUTOR).getValue();
                const comboBoxStatus = this.oView.byId(ID_COMBOBOX_STATUS).getSelectedKey();
                const comboBoxFormato = this.oView.byId(ID_COMBOBOX_FORMATO).getSelectedKey();
 
                if (inputTitulo) { urlFiltro += "Titulo=" + inputTitulo + "&"; }
 
                if (inputAutor) { urlFiltro += "Autor=" + inputAutor + "&"; }
 
                if (comboBoxStatus) { urlFiltro += "Finalizada=" + comboBoxStatus + "&"; }
 
                if (comboBoxFormato) { urlFiltro += "Formato=" + comboBoxFormato + "&"; }
 
                this.inicializarDados(urlFiltro, MODELO_OBRAS);
            });
        },
 
        aoClicarNoBotaoCompras() {
            this.processarAcao(() => {
                this.navegarPara("listagem")
            });
        },
 
        aoClicarNoBotaoAdicionarObra() {
            this.processarAcao(() => {
                this.navegarPara("criacaoObra")
            });
        },
 
        aoSelecionarObra(oEvent) {
            this.processarAcao(() => {
                const oItem = oEvent.getSource();
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.navTo("detalhesObra", {
                    idObra: window.encodeURIComponent(oItem.getBindingContext(MODELO_OBRAS).getProperty("id"))
                })
            });
        },
    });
});