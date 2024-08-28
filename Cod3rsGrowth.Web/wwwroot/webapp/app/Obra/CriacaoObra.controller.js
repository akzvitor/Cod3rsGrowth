sap.ui.define([
    "ui5/coders/app/common/BaseController",
    'ui5/coders/model/formatter',
    "sap/ui/model/json/JSONModel",
 
], (BaseController, formatter, JSONModel) => {
    "use strict";
 
    const API_FORMATOS_URL="http://localhost:5070/api/Obras/formatos";
    const MODELO_FORMATOS="restFormatos";
    const API_GENEROS_URL="http://localhost:5070/api/Obras/generos";
    const MODELO_GENEROS="restGeneros";

    return BaseController.extend("ui5.coders.app.Obra.CriacaoObra", {
        formatter: formatter,
 
        onInit() {
            this.inicializarComboBox(API_FORMATOS_URL, MODELO_FORMATOS);
            this.inicializarComboBox(API_GENEROS_URL, MODELO_GENEROS);
        }
    });
});