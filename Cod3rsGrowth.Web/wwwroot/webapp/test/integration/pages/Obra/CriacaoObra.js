sap.ui.define([
    "sap/ui/test/Opa5",
    'sap/ui/test/matchers/Properties',
    'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/matchers/AggregationFilled',
    'sap/ui/test/matchers/Ancestor',

], (Opa5, Properties, Press, EnterText, AggregationLengthEquals, AggregationFilled, Ancestor) => {
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

                // TO DO - Verificar controltype (sap.ui.core.Item ?) e a key
                euSelecionoOGenero(genero) {
                    return this.waitFor({
                        id: "generosMultiComboBox",
                        actions: new Press(),
                        success: function (oMultiComboBox) {
                            this.waitFor({
                                controlType: "sap.m.StandardListItem",
                                matchers: [
                                    new Ancestor(oMultiComboBox),
                                    new Properties({ key: genero })
                                ],
                                actions: new Press(),
                                errorMessage: `Não foi possível selecionar a key ${genero} na MultiComboBox de generos.`
                            });
                        },
                        errorMessage: "Multi Combo Box de generos não foi encontrada."
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