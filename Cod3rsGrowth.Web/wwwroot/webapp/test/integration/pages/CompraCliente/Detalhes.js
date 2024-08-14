sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/Properties"  

], (Opa5, Properties) => {
    "use strict";

    const NOME_DA_VIEW = "CompraCliente.Detalhes";

    Opa5.createPageObjects({
        naPaginaDeDetalhes: {
            actions: {

            },

            asserts: {
                aPaginaDeveMudarParaDetalhes() {
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id:"paginaDetalhes",
                                viewName: NOME_DA_VIEW,
                                matchers: new Properties ({
                                    title: "Detalhes"
                                }),
                                success: function () {
                                    Opa5.assert.ok(true, "Está na página de Detalhes");
                                },
                                errorMessage: "Não está mostrando o título Detalhes"
                            });
                        }
                    });
                }
            }
        }
    });
});