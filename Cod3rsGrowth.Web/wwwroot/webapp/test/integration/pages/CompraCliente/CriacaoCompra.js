sap.ui.define([
    "sap/ui/test/Opa5",
	'sap/ui/test/matchers/Properties',
    'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/matchers/AggregationFilled'

], (Opa5, Properties, Press, EnterText, AggregationLengthEquals, AggregationFilled) => {
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
                },

                euPreenchoOInput(id, valor) {
                    return this.waitFor({
                        id: id,
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: valor
                        }),
                        errorMessage: "Input não encontrado"
                    });
                },

                euSelecionoAoMenosUmaObraDoCatalogo() {
                    return this.waitFor({
                        id: "catalogoObras",
                        viewName: NOME_DA_VIEW,
                        matchers: new AggregationFilled({
                            name: "items"
                        }),
                        actions: function(oList) {
                            const produtosDoCatalogo = oList.getItems();
                            var obra1 = produtosDoCatalogo[0];
                            obra1.setSelected(true);
                        },
                        errorMessage: "Item não encontrado"
                    })
                },

                euClicoNoBotaoSalvar() {
                    return this.waitFor({
                        id: "botaoSalvar",
                        viewName: NOME_DA_VIEW,
                        actions: new Press(),
                        errorMessage: "Botão salvar não encontrado"
                    })
                },

                euPreenchoOInputNomeComDadoInvalido(id, valor) {
                    this.euPreenchoOInput(id, valor)
                },

                euPreenchoOInputEmailComDadoValido(id, valor) {
                    this.euPreenchoOInput(id, valor)
                },

                euPreenchoOInputTelefoneComDadoValido(id, valor) {
                    this.euPreenchoOInput(id, valor)
                },

                euPreenchoOInputCpfComDadoValido(id, valor) {
                    this.euPreenchoOInput(id, valor)
                },

                euPreenchoOInputNomeComDadoValido(id, valor) {
                    this.euPreenchoOInput(id, valor)
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

                deveFiltrarOCatalogoPelaObraBuscada() {
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
                },

                deveApresentarMensagemDeErroAoSalvarCompra() {
                    return this.waitFor({
                        id: "messageStripErro",
                        viewName: NOME_DA_VIEW,
                        matchers: new Properties({
                            text: "Não foi possível salvar a compra, verifique os dados inseridos",
                            visible: true
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de erro foi apresentada.");
                        },
                        errorMessage: "Não apresentou mensagem de erro"
                    });
                },

                deveApresentarMensagemDeSucessoAoSalvarCompra() {
                    return this.waitFor({
                        id: "messageStripSucesso",
                        viewName: NOME_DA_VIEW,
                        matchers: new Properties({
                            text: "A compra foi salva com sucesso",
                            visible: true
                        }),
                        success: function () {
                            Opa5.assert.ok(true, "A mensagem de sucesso ao salvar compra foi apresentada.");
                        },
                        errorMessage: "Não apresentou nenhuma mensagem"
                    });
                }
            }
        }
    });
});