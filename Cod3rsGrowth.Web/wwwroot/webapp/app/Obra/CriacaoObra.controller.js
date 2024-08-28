sap.ui.define([
    "ui5/coders/app/common/BaseController",
    'ui5/coders/model/formatter',
    "sap/ui/model/json/JSONModel",
 
], (BaseController, formatter, JSONModel) => {
    "use strict";
 
    return BaseController.extend("ui5.coders.app.Obra.CriacaoObra", {
        formatter: formatter,
 
        onInit() {
            this.inicializarComboBoxFormato();
        }
    });
});