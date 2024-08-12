sap.ui.define([
    "sap/ui/test/Opa5",
	'sap/ui/test/matchers/Properties',
    'sap/ui/test/actions/Press'

], (Opa5, Properties, Press) => {
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
                    })
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
                }
            }
        }
    });
});