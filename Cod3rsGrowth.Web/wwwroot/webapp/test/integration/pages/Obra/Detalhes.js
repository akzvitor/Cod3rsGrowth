sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/matchers/Properties",
    "sap/ui/test/actions/Press"

], (Opa5, Properties, Press) => {
    "use strict";

    const NOME_DA_VIEW = "Obra.Detalhes";
    const ID_PAGINA_DETALHES = "paginaDetalhes";

    Opa5.createPageObjects({
        naPaginaDeDetalhesDaObra: {
            actions: {
                euClicoNoBotaoEditar() {
                    return this.waitFor({
                        id: "botaoEditar",
                        viewName: NOME_DA_VIEW,
                        actions: new Press(),
                        errorMessage: "Botão Editar não encontrado"
                    });
                }
            },

            assertions: {
                aPaginaDeveMudarParaDetalhes() {
                    return this.waitFor({
                        success: function () {
                            return this.waitFor({
                                id: "paginaDetalhesObra",
                                viewName: NOME_DA_VIEW,
                                matchers: new Properties({
                                    title: "Detalhes"
                                }),
                                success: function () {
                                    Opa5.assert.ok(true, "Está na página de Detalhes da obra");
                                },
                                errorMessage: "Não está mostrando o título Detalhes"
                            });
                        }
                    });
                },

                oTextComTooltipI18nAutorDevePossuirOValor(autor) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.Autor"
                            },
                            properties: {
                                text: autor
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Autor possui o valor ${autor}.`);
                        },
                        errorMessage: `O Text de tooltip Autor não possui o valor esperado (${autor}).`
                    });
                },

                oTextComTooltipI18nTituloDevePossuirOValor(titulo) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.Titulo"
                            },
                            properties: {
                                text: titulo
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Titulo possui o valor ${titulo}.`);
                        },
                        errorMessage: `O Text de tooltip Titulo não possui o valor esperado (${titulo}).`
                    });
                },

                oTextComTooltipI18nFormatoDevePossuirOValor(formato) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.Formato"
                            },
                            properties: {
                                text: formato
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Formato possui o valor ${formato}.`);
                        },
                        errorMessage: `O Text de tooltip Formato não possui o valor esperado (${formato}).`
                    });
                },

                oTextComTooltipI18nCapitulosDevePossuirOValor(capitulos) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.Capitulos"
                            },
                            properties: {
                                text: capitulos
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Capítulos possui o valor ${capitulos}.`);
                        },
                        errorMessage: `O Text de tooltip Capítulos não possui o valor esperado (${capitulos}).`
                    });
                },

                oTextComTooltipI18nStatusDevePossuirOValor(status) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.Status"
                            },
                            properties: {
                                text: status
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Status possui o valor ${status}.`);
                        },
                        errorMessage: `O Text de tooltip Status não possui o valor esperado (${status}).`
                    });
                },

                oTextComTooltipI18nInicioDaPublicacaoDevePossuirOValor(data) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.InicioPubli"
                            },
                            properties: {
                                text: data
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Início da Publicação possui o valor ${data}.`);
                        },
                        errorMessage: `O Text de tooltip Início da Publicação não possui o valor esperado (${data}).`
                    });
                },

                oTextComTooltipI18nValorDevePossuirOValor(valor) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.Valor"
                            },
                            properties: {
                                text: valor
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Valor possui o valor ${valor}.`);
                        },
                        errorMessage: `O Text de tooltip Valor não possui o valor esperado (${valor}).`
                    });
                },

                oTextComTooltipI18nGenerosDevePossuirOValor(generos) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.Generos"
                            },
                            properties: {
                                text: generos
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Generos possui o valor ${generos}.`);
                        },
                        errorMessage: `O Text de tooltip Generos não possui o valor esperado (${generos}).`
                    });
                },

                oTextComTooltipI18nSinopseDevePossuirOValor(sinopse) {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.m.Text",
                        matchers: {
                            i18NText: {
                                propertyName: "tooltip",
                                key: "Obra.Sinopse"
                            },
                            properties: {
                                text: sinopse
                            }
                        },
                        success: function () {
                            Opa5.assert.ok(true, `O Text de tooltip Sinopse possui o valor ${sinopse}.`);
                        },
                        errorMessage: `O Text de tooltip Sinopse não possui o valor esperado (${sinopse}).`
                    });
                }
            }
        }
    });
})
