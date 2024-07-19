sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press"
], (Opa5, Press) => {
    "use strict";

    const NOME_DA_VIEW = "ui5.coders.view.App";

    Opa5.createPageObjects({
        onTheAppPage: {
            actions: {
                euClicoNoBotaoSayHelloToTheWorld() {
                    return this.waitFor({
                        id: "botaoSayHello",
                        viewName: NOME_DA_VIEW,
                        actions: new Press(),
                        errorMessage: "Não foi possivel encontrar o botão 'Say Hello to the World!' na App view."
                    });
                }
            },

            assertions: {
                deveSerExibidoUmMessageToast() {
                    return this.waitFor({
                        pollingInterval: 100,
                        viewName: NOME_DA_VIEW,
                        check: function () {
                            return !!sap.ui.test.Opa5.getJQuery()(".sapMMessageToast").length;
                        },
                        success: function () {
                            ok(true, "Message Toast encontrado!");
                        },
                        errorMessage: "Não foi detectado nenhum Message Toast!"
                    });
                }
            }
        }
    });
});