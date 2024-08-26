sap.ui.define([
    "ui5/coders/app/common/BaseController",
    'ui5/coders/model/formatter'
], (BaseController, formatter) => {
    "use strict";

    const ROTA_LISTAGEM_OBRAS = "listagemObra";
    const API_OBRAS_URL = "http://localhost:5070/api/Obras";
    const MODELO_OBRAS = "restObras";
    const ID_INPUT_TITULO = "tituloFiltroInput";
    const ID_INPUT_AUTOR = "autorFiltroInput";

    return BaseController.extend("ui5.coders.app.Obra.Listagem", {
        formatter: formatter,

        onInit() {
            this.aoCoincidirRota(ROTA_LISTAGEM_OBRAS, API_OBRAS_URL, MODELO_OBRAS);
        },

        aoAlterarInputFiltro(oEvent) {
            this.processarAcao(() => {
                let urlFiltro = "http://localhost:5070/api/Obras?";
                const inputTitulo = this.oView.byId(ID_INPUT_TITULO).getValue();
                const inputAutor = this.oView.byId(ID_INPUT_AUTOR).getValue();

                if (inputTitulo) { urlFiltro += "Titulo=" + inputTitulo + "&"; }

                if (inputAutor) { urlFiltro += "Autor=" + inputAutor + "&"; }

                this.inicializarDados(urlFiltro, MODELO_OBRAS);
            });
        }
    });
});