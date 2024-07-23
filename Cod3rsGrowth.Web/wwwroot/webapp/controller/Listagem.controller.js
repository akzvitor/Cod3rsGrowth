sap.ui.define([
    "ui5/coders/controller/BaseController",
    "sap/m/MessageToast"
], (BaseController, MessageToast) => {
    "use strict";

    return BaseController.extend("ui5.coders.controller.Listagem", {
        exibirOla() {
            const oBundle = this.getView().getModel("i18n").getResourceBundle();
            const sRecipient = this.getView().getModel().getProperty("/recipient/name");
            const sMsg = oBundle.getText("PaginaInicial.msg", [sRecipient]);

            MessageToast.show(sMsg);
        }
    });
});