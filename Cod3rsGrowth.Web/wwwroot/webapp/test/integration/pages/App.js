sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationFilled"
], (Opa5, EnterText, AggregationFilled) => {
    "use strict";

    const NOME_DA_VIEW = "ui5.coders.view.Listagem";
    const NOME_DO_MODELO = "restCompras";
    const ID_INPUT_NOME = "nomeFiltroInput";
    const ID_INPUT_CPF = "cpfFiltroInput";
    const ID_INPUT_DATAINICIAL = "dataInicialFiltroInput";
    const ID_INPUT_DATAFINAL = "dataFinalFiltroInput";
    const ID_TABELA = "tabelaCompras";
    const STRING_INSERIDO_INPUT_NOME = "Vitor";
    const STRING_INSERIDO_INPUT_CPF = "23985476047";
    const STRING_INSERIDO_INPUT_DATAINICIAL = "23985476047";
    const STRING_INSERIDO_INPUT_DATAFINAL = "23985476047";
    const ITENS_TABELA = "items";
    const MENSAGEM_SUCESSO_BUSCAR_ITEM = "A tabela contém o item esperado.";
    const MENSAGEM_ERRO_BUSCAR_ITEM = "A tabela não contém o item esperado.";
    const MENSAGEM_ERRO_CARREGAR_TABELA = "Ocorreu um erro ao carregar a tabela ou filtrar os dados.";
    const PROPRIEDADE_NOME = "nome";


    Opa5.createPageObjects({
        onTheAppPage: {
            actions: {
                euPreenchoOInputNome() {
                    return this.waitFor({
                        id: ID_INPUT_NOME,
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                             text: STRING_INSERIDO_INPUT_NOME 
                        }),
                        errorMessage: "Input de filtro Nome não encontrado."
                    });
                },

                euPreenchoOInputCPF() {
                    return this.waitFor({
                        id: ID_INPUT_CPF,
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: STRING_INSERIDO_INPUT_CPF
                        }),
                        errorMessage: "Input de filtro CPF não encontrado."
                    })
                },

                euPreenchoOInputDataFinal() {
                    return this.waitFor({
                        id: ID_INPUT_DATAINICIAL,
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: STRING_INSERIDO_INPUT_CPF
                        }),
                        errorMessage: "Input de filtro CPF não encontrado."
                    })
                },

                euPreenchoOInputCPF() {
                    return this.waitFor({
                        id: ID_INPUT_CPF,
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: STRING_INSERIDO_INPUT_CPF
                        }),
                        errorMessage: "Input de filtro CPF não encontrado."
                    })
                }
            },

            assertions: {
                aTabelaDeveSerFiltradaDeAcordoComFiltroNome() {
                    const stringEsperada = "Vitor";
                    const tagLinhas = "items";

                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_TABELA,
                        matchers: new AggregationFilled({
                            name: tagLinhas
                        }),
                        success: function (oTable) {
                            const itensTabela = oTable.getItems();

                            let resultado = true;
                            itensTabela.map((item) => {
                                let nomeBuscado = item.getBindingContext(NOME_DO_MODELO).getProperty(PROPRIEDADE_NOME);
                                console.log(item.getBindingContext(NOME_DO_MODELO));
                                if (nomeBuscado !== stringEsperada) {
                                    resultado = false;
                                }
                            });
                            Opa5.assert.ok(resultado, MENSAGEM_SUCESSO_BUSCAR_ITEM);
                        },
                        errorMessage: MENSAGEM_ERRO_CARREGAR_TABELA
                    });
                },

                aTabelaDeveSerFiltradaDeAcordoComFiltroCPF() {
                    const propriedadeTestada = "cpf";
                    return this.waitFor({
                        id: ID_TABELA,
                        viewName: NOME_DA_VIEW,
                        matchers: new AggregationFilled({
                            name: ITENS_TABELA
                        }),
                        success: function (oTable) {
                            const itensTabela = oTable.getItems();

                            var resultado = itensTabela.some(function (item) {
                                var cpfDesejado = item.getBindingContext(NOME_DO_MODELO).getProperty(propriedadeTestada);
                                return cpfDesejado === STRING_INSERIDO_INPUT_CPF;
                            });

                            if (resultado)
                                Opa5.assert.ok(resultado, MENSAGEM_SUCESSO_BUSCAR_ITEM);
                            else
                                Opa5.assert.ok(resultado, MENSAGEM_ERRO_BUSCAR_ITEM);

                        },
                        errorMessage: MENSAGEM_ERRO_CARREGAR_TABELA
                    })
                }
            }
        }
    });
});