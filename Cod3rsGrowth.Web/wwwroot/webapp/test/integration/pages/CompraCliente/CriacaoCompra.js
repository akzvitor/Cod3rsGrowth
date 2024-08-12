sap.ui.define([
    "sap/ui/test/Opa5",
	'sap/ui/test/matchers/Properties',
    'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/AggregationLengthEquals',


], (Opa5, Properties, Press, EnterText, AggregationLengthEquals) => {
    "use strict";

    const NOME_DA_VIEW = "CompraCliente.CriacaoCompra";

    Opa5.createPageObjects({
        naPaginaDeCriacaoCompra: {
            actions: {
                euClicoNoBotaoNavBack() {
                    return this.waitFor({
                        id:"botaoNavBack",
                        viewName: NOME_DA_VIEW,
                        actions: new Press(),
                        errorMessage: "Botão de navback não encontrado"
                    });
                },

                euPreenchoOSearchField() {
                    return this.waitFor({
                        id:"searchFieldCatalogo",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: "Re: Zero kara Hajimeru Isekai Seikatsu"
                        }),
                        errorMessage: "SearchField não encontrado"
                    });
                }
            },

            assertions: {
                aPaginaDeveMudarParaCriacaoCompra() {
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id:"paginaCriacaoCompra",
                                viewName: NOME_DA_VIEW,
                                matchers: new Properties ({
                                    title: "Adicionar Nova Compra"
                                }),
                                success: function () {
                                    Opa5.assert.ok(true, "Está na página de Criação de Compra");
                                },
                                errorMessage: "Não está mostrando o título Adicionar Nova Compra"
                            });
                        }
                    });
                },

                DeveFiltrarOCatalogoPelaObraBuscada() {
                    return this.waitFor({
                        id:"catalogoObras",
                        viewName: NOME_DA_VIEW,
                        matchers: new AggregationLengthEquals({
                            name: "items",
                            length: 1
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "O catálogo contém apenas 1 obra, que foi buscada.");
                        },
                        errorMessage: "O catálogo não contém a obra buscada."
                    });
                }
            }
        }
    });
});