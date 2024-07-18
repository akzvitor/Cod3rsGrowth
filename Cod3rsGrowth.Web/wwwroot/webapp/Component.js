sap.ui.define([
    "sap/ui/core/UIComponent",
    "sap/ui/model/resource/ResourceModel"
], (UIComponent, JSONModel, ResourceModel) => {
    "use strict";

    return UIComponent.extend("ui5.codersgrowth.Component", {
        metadata: {
            "interfaces": ["sap.ui.core.IAsyncContentCreation"],
            "rootView": {
                "viewName": "ui5.codersgrowth.view.App",
                "type": "XML",
                "id": "app"
            }
        },

        init() {
            UIComponent.prototype.init.apply(this, arguments);

            const oData = {
                recipient: {
                    name: "World"
                }
            };

            const i18nModel = new ResourceModel({
                bundleName: "ui5.codersgrowth.i18n.i18n"
            });
            this.setModel(i18nModel, "i18n");
        }
    });
});
