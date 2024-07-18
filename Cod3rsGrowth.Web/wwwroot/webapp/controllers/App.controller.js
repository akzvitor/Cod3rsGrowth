sap.ui.define([
    "sap/ui/core/mvc/Controller",
    "sap/ui/model/resource/ResourceModel"
], (Controller, ResourceModel) => {
    "use strict";

    return Controller.extend("ui5.codersgrowth.controller.App", {

        exibirAlertaOla() {
            const oBundle = this.getView().getModel("i18n").getResourceBundle();
            const sRecipient = this.getView().getModel().getProperty("/recipient/name");
            const sMsg = oBundle.getText("olaMsg", [sRecipient]);

            alert(sMsg);
        }
    });
});