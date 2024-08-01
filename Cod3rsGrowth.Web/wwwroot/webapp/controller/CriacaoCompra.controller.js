sap.ui.define([
    "ui5/coders/controller/BaseController",
], (BaseController) => {
    "use strict";

    const API_URL = "http://localhost:5070/api/Obras";
    const NOME_DO_MODELO= "restObras";

    return BaseController.extend("ui5.coders.controller.CriacaoCompra", {
        onInit() {
            this.inicializarDados(API_URL, NOME_DO_MODELO);
        },
    });
});