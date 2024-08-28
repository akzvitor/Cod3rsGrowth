sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/Press",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationContainsPropertyEqual"

], (Opa5, Press, EnterText, AggregationContainsPropertyEqual) => {
    "use strict";

    const NOME_DA_VIEW = "Obra.Listagem"

    Opa5.createPageObjects({
        naPaginaDeListagemObras: {
            actions: {
                euClicoNoBotaoCompras() {
                    return this.waitFor({
                        id: "botaoCompras",
                        viewName: NOME_DA_VIEW,
                        actions: new Press(),
                        success: function () {
                            Opa5.assert.ok(true, "Botão compras encontrado")
                        },
                        errorMessage: "Botão compras não encontrado."
                    });
                },

                euPreenchoOInputTituloComOValor(titulo) {
                    return this.waitFor({
                        id: "tituloFiltroInput",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: titulo
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "Input titulo encontrado.")
                        },
                        errorMessage: "Input titulo não encontrado."
                    });
                },

                euPreenchoOInputAutorComOValor(autor) {
                    return this.waitFor({
                        id: "autorFiltroInput",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: autor
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "Input autor encontrado.")
                        },
                        errorMessage: "Input autor não encontrado."
                    });
                },

                euPreenchoOComboBoxFormatoComOValor(formato) {
                    return this.waitFor({
                        id: "formatoFiltroComboBox",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: formato
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "ComboBox formato encontrado.")
                        },
                        errorMessage: "ComboBox formato não encontrado."
                    });
                },

                euPreenchoOComboBoxStatusComOValor(status) {
                    return this.waitFor({
                        id: "statusFiltroComboBox",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: status
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "ComboBox status encontrado.")
                        },
                        errorMessage: "ComboBox status não encontrado."
                    });
                }
            },

            assertions: {
                aPaginaDeveMudarParaListagem() {
                    this.waitFor({
                        id: "tabelaObras",
                        viewName: NOME_DA_VIEW,
                        success: function () {
                            Opa5.assert.ok(true, "A tabela de obras está sendo exibida.");
                        },
                        errorMessage: "Não é possível visualizar a tabela de obras."
                    });
                },

                deveExibirONumeroDeObrasQueSeAplicamAoFiltro(numero) {
                    this.waitFor({
                        id: "tabelaObras",
                        viewName: NOME_DA_VIEW,
                        matchers: {
                            aggregationLengthEquals: {
                                name: "items",
                                length: numero
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `A tabela de obras foi filtrada e apresentou ${numero} item(ns).`);

                        },
                        errorMessage: "Não é possível visualizar a tabela de obras."
                    })
                }
            }
        }
    });
});