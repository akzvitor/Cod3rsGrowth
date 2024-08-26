sap.ui.define([
    "ui5/coders/app/common/BaseController",
    'ui5/coders/model/formatter'
], (BaseController, formatter) => {
    "use strict";

    const ROTA_LISTAGEM_OBRAS = "listagemObra";
    const API_OBRAS_URL = "http://localhost:5070/api/Obras";
    const MODELO_OBRAS = "restObras";

    return BaseController.extend("ui5.coders.app.Obra.Listagem", {
        formatter: formatter,

        onInit() {
            this.aoCoincidirRota(ROTA_LISTAGEM_OBRAS, API_OBRAS_URL, MODELO_OBRAS);
        }
    });
});