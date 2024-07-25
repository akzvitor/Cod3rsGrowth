sap.ui.define([
    "ui5/coders/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "../model/formatter"
], (BaseController, JSONModel, formatter) => {
    "use strict";

    const API_URL = "http://localhost:5070/api/Compras?";
    const NOMDE_DO_MODELO = "restCompras";

    return BaseController.extend("ui5.coders.controller.Listagem", {
        formatter: formatter,
        
        onInit() {
            fetch(API_URL)
                .then((res) => res.json())
                .then((data) => this.getView().setModel(new JSONModel(data), NOMDE_DO_MODELO))
                .catch((err) => console.error(err));
        }
    });
});