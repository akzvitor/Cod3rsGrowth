sap.ui.define([
    "ui5/coders/controller/BaseController",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator"
], (BaseController, Filter, FilterOperator) => {
    "use strict";

    const API_URL = "http://localhost:5070/api/Obras";
    const NOME_DO_MODELO = "restObras";

    return BaseController.extend("ui5.coders.controller.CriacaoCompra", {
        onInit() {
            this.inicializarDados(API_URL, NOME_DO_MODELO);
        },

        aoProcurarObra(oEvent) {
            const aFilter = [];
            const sQuery = oEvent.getParameter("query");
            if (sQuery) {
                aFilter.push(new Filter("titulo", FilterOperator.Contains, sQuery));
            }

            const oList = this.byId("catalogoObras");
            const oBinding = oList.getBinding("items");
            oBinding.filter(aFilter);
        }
    });
});