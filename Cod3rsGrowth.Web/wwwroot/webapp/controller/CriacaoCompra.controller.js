sap.ui.define([
    "ui5/coders/controller/BaseController",
    "sap/ui/model/json/JSONModel"
], (BaseController, JSONModel) => {
    "use strict";

    const API_URL = "http://localhost:5070/api/Obras";
    const NOME_DO_MODELO= "restObras";

    return BaseController.extend("ui5.coders.controller.CriacaoVenda", {
        onInit() {
            this._inicializarDados(API_URL);
        },

        _inicializarDados(urlDaApi) {
            fetch(urlDaApi)
                .then((res) => res.json())
                .then((data) => this.getView().setModel(new JSONModel(data), NOME_DO_MODELO))
                .catch((err) => console.error(err));
        }
    });
});