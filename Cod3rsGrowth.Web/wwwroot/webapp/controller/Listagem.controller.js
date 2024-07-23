sap.ui.define([
    "ui5/coders/controller/BaseController",
    "sap/ui/model/json/JSONModel"
], (BaseController, JSONModel) => {
    "use strict";

    return BaseController.extend("ui5.coders.controller.Listagem", {
        onInit() {
            var comprasClienteModel = new JSONModel();

            comprasClienteModel.loadData(
                "http://localhost:5070/api/Compras", null, true, 'GET'
            );

            this.getView().setModel(comprasClienteModel, "restCompras");
        }
    });
});