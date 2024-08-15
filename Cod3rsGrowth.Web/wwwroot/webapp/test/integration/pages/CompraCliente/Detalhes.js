sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/Properties",  
    "sap/ui/test/actions/Press"  

], (Opa5, Properties, Press) => {
    "use strict";

    const NOME_DA_VIEW = "CompraCliente.Detalhes";

    Opa5.createPageObjects({
        naPaginaDeDetalhes: {
            actions: {
                euClicoNoBotaoNavBack() {
                    return this.waitFor({
                        id:"paginaDetalhes",
                        viewName: NOME_DA_VIEW,
                        actions: new Press(),
                        errorMessage: "Botão de navback não encontrado"
                    });
                }
            },

            assertions: {
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
                },

                deveExibirDetalhesDaCompraCorreta() {
                    ret
                }
            }
        }
    });
});