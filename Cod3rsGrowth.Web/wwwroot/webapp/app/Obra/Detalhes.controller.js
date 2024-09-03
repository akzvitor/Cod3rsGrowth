sap.ui.define([
    "ui5/coders/app/common/BaseController",
    "sap/ui/model/json/JSONModel",
    "sap/m/MessageBox"
 
], (BaseController, JSONModel, MessageBox) => {
    "use strict";
 
    const ROTA_DETALHES = "detalhesObra";
    const API_OBRAS_URL = "http://localhost:5070/api/Obras/";
    const MODELO_OBRAS = "restObras";
    const API_GENEROS_URL = "http://localhost:5070/api/Obras/generos";
    const MODELO_GENEROS = "restGeneros";
    var id_parametro;
 
 
    return BaseController.extend("ui5.coders.app.Obra.Detalhes", {
        onInit() {
            this._aoCoincidirRota(ROTA_DETALHES);
        },
 
        _aoCoincidirRota(rota) {
            this.processarAcao(() => {
                const oRouter = this.getOwnerComponent().getRouter();
                oRouter.getRoute(rota).attachPatternMatched((oEvent) => {
                    this.inicializarComboBox(API_GENEROS_URL, MODELO_GENEROS);
                    this._resgatarIdURL(oEvent);
                    this._inicializarDadosDaObraSelecionada(oEvent);
                }, this);
            });
        },
 
        _resgatarIdURL(oEvent) {
            this.processarAcao(() => {
                id_parametro = window.decodeURIComponent(oEvent.getParameter("arguments").idObra);
            });
        },
 
        _inicializarDadosDaObraSelecionada() {
            fetch(API_OBRAS_URL + id_parametro)
                .then((res) => {
                    return res.json();
                })
                .then((data) => {
                    !data.Detail ? this.getView().setModel(new JSONModel(data), MODELO_OBRAS)
                        : this.capturarErroApi(data);
                })
                .catch((err) => console.error(err));
        },

        aoClicarNoBotaoEditar() {
            this.processarAcao(() => {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("edicaoObra", {
					idObra: id_parametro
				});
			});
        }
    });
});