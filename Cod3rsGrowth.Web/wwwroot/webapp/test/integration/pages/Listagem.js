sap.ui.define([
    "sap/ui/test/Opa5",
    "sap/ui/test/actions/EnterText",
    "sap/ui/test/matchers/AggregationFilled"
], (Opa5, EnterText, AggregationFilled) => {
    "use strict";

    const NOME_DA_VIEW = ".Listagem";
    const NOME_DO_MODELO = "restCompras";
    const ID_INPUT_NOME = "nomeFiltroInput";
    const ID_INPUT_CPF = "cpfFiltroInput";
    const ID_DATERANGE = "dateRangeFiltroInput";
    const ID_TABELA = "tabelaCompras";
    const STRING_INSERIDO_INPUT_NOME = "Júlio";
    const STRING_INSERIDO_INPUT_CPF = "23985476047";
    const STRING_INSERIDO_INPUT_DATA_UNICA = "01/08/2024";
    const TAG_ITENS_TABELA = "items";
    const MENSAGEM_SUCESSO_BUSCAR_ITEM = "A tabela contém o item esperado.";
    const MENSAGEM_ERRO_CARREGAR_TABELA = "Ocorreu um erro ao carregar a tabela ou filtrar os dados.";

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

                euSelecionoAData() {
                    return this.waitFor({
                        id: ID_DATERANGE,
                        viewName: NOME_DA_VIEW,
                        actions: new EnterText({
                            text: STRING_INSERIDO_INPUT_DATA_UNICA
                        }),
                        errorMessage: "Input de filtro Data Única não encontrado."
                    })
                }
            },

            assertions: {
                aTabelaDeveSerFiltradaDeAcordoComFiltroNome() {
                    const propriedadeTestada = "nome";

                    return this.waitFor({
                        viewName: NOME_DA_VIEW,
                        id: ID_TABELA,
                        matchers: new AggregationFilled({
                            name: TAG_ITENS_TABELA
                        }),
                        success: function (oTable) {
                            const itensTabela = oTable.getItems();
                            let resultado = true;
                    
                            itensTabela.map((item) => {
                                let nomeBuscado = item.getBindingContext(NOME_DO_MODELO).getProperty(propriedadeTestada);

                                if (nomeBuscado !== STRING_INSERIDO_INPUT_NOME) 
                                    resultado = false;
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
                            name: TAG_ITENS_TABELA
                        }),
                        success: function (oTable) {
                            const itensTabela = oTable.getItems();
                            let resultado = true;

                            itensTabela.map((item) => {
                                let cpfBuscado = item.getBindingContext(NOME_DO_MODELO).getProperty(propriedadeTestada);

                                if (cpfBuscado !== STRING_INSERIDO_INPUT_CPF)
                                    resultado = false;
                            })

                            Opa5.assert.ok(resultado, MENSAGEM_SUCESSO_BUSCAR_ITEM);
                        },
                        errorMessage: MENSAGEM_ERRO_CARREGAR_TABELA
                    })
                },

                aTabelaDeveSerFiltradaDeAcordoComFiltroData() {
                    const propriedadeTestada = "dataCompra";

                    return this.waitFor({
                        id: ID_TABELA,
                        viewName: NOME_DA_VIEW,
                        matchers: new AggregationFilled({
                            name: TAG_ITENS_TABELA
                        }),
                        success: function (oTable) {
                            const itensTabela = oTable.getItems();
                            let resultado = true;

                            itensTabela.map((item) => {
                                let dataBuscada = new Date(item.getBindingContext(NOME_DO_MODELO).getProperty(propriedadeTestada));
                                let dataDaTabelaFormatada = new Date(STRING_INSERIDO_INPUT_DATA_UNICA);

                                console.log(dataBuscada + " não é igual a " + dataDaTabelaFormatada);

                                if (dataBuscada.toISOString() !== dataDaTabelaFormatada.toISOString())
                                    resultado = false;
                            })

                            Opa5.assert.ok(resultado, MENSAGEM_SUCESSO_BUSCAR_ITEM);
                        },
                        errorMessage: MENSAGEM_ERRO_CARREGAR_TABELA
                    })
                }
            }
        }
    });
});