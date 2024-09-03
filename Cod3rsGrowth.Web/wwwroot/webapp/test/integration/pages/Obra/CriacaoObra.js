sap.ui.define([
    "sap/ui/test/Opa5",
    'sap/ui/test/matchers/PropertyStrictEquals',
    'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/matchers/AggregationFilled',
    'sap/ui/test/matchers/Ancestor',
    'sap/ui/test/matchers/Properties',

], (Opa5, PropertyStrictEquals, Press, EnterText, AggregationLengthEquals, AggregationFilled, Ancestor, Properties) => {
    "use strict";

    const NOME_DA_VIEW = "Obra.CriacaoObra";

    Opa5.createPageObjects({
        naPaginaDeCriacaoObra: {
            actions: {
                euClicoNoBotaoNavBack() {
                    return this.waitFor({
                        id: "paginaCriacaoObra",
                        viewName: NOME_DA_VIEW,
                        actions: new Press(),
                        errorMessage: "Botão de navback não encontrado"
                    });
                },

                euPreenchoOInputTituloComOValor(titulo) {
                    return this.waitFor({
                        id: "tituloFormInput",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: titulo
                        }),
                        errorMessage: "Input de título não encontrado"
                    });
                },

                euPreenchoOInputAutorComOValor(autor) {
                    return this.waitFor({
                        id: "autorFormInput",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: autor
                        }),
                        errorMessage: "Input de autor não encontrado"
                    });
                },

                euSelecionoOFormato(formato) {
                    return this.waitFor({
                        id: "formatoComboBox",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: formato
                        }),
                        errorMessage: "ComboBox de formato não encontrado"
                    });
                },

                euSelecionoOStatus(status) {
                    return this.waitFor({
                        id: "statusComboBox",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: status
                        }),
                        errorMessage: "ComboBox de status não encontrado"
                    });
                },

                euSelecionoADataDePublicacao(dataDePublicacao) {
                    return this.waitFor({
                        id: "datePickerFormInput",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: dataDePublicacao
                        }),
                        errorMessage: "DatePicker de data de publicação não encontrado"
                    });
                },

                euAbroAComboBoxDeGeneros() {
                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        controlType: "sap.ui.core.Icon",
                        matchers: [
                            new Properties({ src: "sap-icon://slim-arrow-down" })
                        ],
                        actions: new Press(),
                        errorMessage: "Multi Combo Box de generos não foi encontrada."
                    });
                },

                euSelecionoOGenero(genero) {
                    return this.waitFor({
                        controlType: "sap.m.MultiComboBox",
                        actions: function (oMultiComboBox) {
                            oMultiComboBox.setSelectedKeys(genero)
                        },
                        errorMessage: `Não foi possível selecionar a key ${genero} na MultiComboBox de generos.`
                    });
                },

                euPreenchoASinopseComOValor(sinopse) {
                    return this.waitFor({
                        id: "sinopseTextArea",
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: sinopse
                        }),
                        errorMessage: "TextArea de sinopse não encontrado"
                    });
                },

                euClicoNoBotaoSalvar() {
                    return this.waitFor({
                        id: "botaoSalvar",
                        viewName: NOME_DA_VIEW,
                        actions: new Press(),
                        errorMessage: "Botão salvar não encontrado"
                    });
                }
            },

            assertions: {
                aPaginaDeveMudarParaEdicaoObra() {
                    return this.waitFor({
                        success: function() {
                            return this.waitFor({
                                id:"paginaCriacaoObra",
                                viewName: NOME_DA_VIEW,
                                matchers: new Properties ({
                                    title: "Editar Obra"
                                }),
                                success: function () {
                                    Opa5.assert.ok(true, "Está na página de Edição de Obra")
                                },
                                errorMessage: "Não está mostrando o título Editar Obra"
                            });
                        }
                    });
                },

                deveApresentarMensagemDeErroAoSalvarObra() {
                    return this.waitFor({
                        id: "messageStripErro",
                        viewName: NOME_DA_VIEW,
                        matchers: new Properties({
                            text: "Não foi possível salvar a obra, verifique os dados inseridos.",
                            visible: true
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro foi apresentada.");
                        },
                        errorMessage: "Não apresentou mensagem de erro."
                    });
                },

                deveApresentarMensagemDeSucessoAoSalvarObra() {
                    return this.waitFor({
                        id: "messageStripSucesso",
                        viewName: NOME_DA_VIEW,
                        matchers: new Properties({
                            text: "A obra foi salva com sucesso.",
                            visible: true
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de sucesso ao salvar obra foi apresentada.");
                        },
                        errorMessage: "Não apresentou mensagem de sucesso."
                    });
                }
            }
        }
    });
});