sap.ui.define([
    "sap/ui/test/opaQunit",
    "./Listagem",
    "../CompraCliente/Listagem"
], (opaTest) => {
    "use strict";

    QUnit.module("Listagem Obras");

    opaTest("Deveria ver a página de listagem de obras.", (Given, When, Then) => {
        Given.iStartMyApp({
            hash: "listagemObra"
        });

        Then.naPaginaDeListagemObras.aPaginaDeveMudarParaListagem();
    });

    opaTest("Deveria navegar para a página de listagem de compras.", (Given, When, Then) => {
        When.naPaginaDeListagemObras.euClicoNoBotaoCompras();

        Then.naPaginaDeListagemCompras.aPaginaDeveMudarParaListagem();
    });

    opaTest("Deveria voltar para página de listagem de obras.", (Given, When, Then) => {
        When.naPaginaDeListagemCompras.euClicoNoBotaoObras();

        Then.naPaginaDeListagemObras.aPaginaDeveMudarParaListagem();
    });

    opaTest("Deveria filtrar a tabela por título da obra.", (Given, When, Then) => {
        When.naPaginaDeListagemObras.euPreenchoOInputTituloComOValor("Akame");

        Then.naPaginaDeListagemObras.deveExibirONumeroDeObrasQueSeAplicamAoFiltro(1);
        Then.iTeardownMyApp();
    });

    opaTest("Deveria filtrar a tabela por autor.", (Given, When, Then) => {
        Given.iStartMyApp({
            hash: "listagemObra"
        });

        When.naPaginaDeListagemObras.euPreenchoOInputAutorComOValor("Tappei");

        Then.naPaginaDeListagemObras.deveExibirONumeroDeObrasQueSeAplicamAoFiltro(1);
        Then.iTeardownMyApp();
    });

    opaTest("Deveria filtrar a tabela por formato.", (Given, When, Then) => {
        Given.iStartMyApp({
            hash: "listagemObra"
        });

        When.naPaginaDeListagemObras.euPreenchoOComboBoxFormatoComOValor("Web Novel");

        Then.naPaginaDeListagemObras.deveExibirONumeroDeObrasQueSeAplicamAoFiltro(1);
        Then.iTeardownMyApp();
    });

    opaTest("Deveria filtrar a tabela por status.", (Given, When, Then) => {
        Given.iStartMyApp({
            hash: "listagemObra"
        });

        When.naPaginaDeListagemObras.euPreenchoOComboBoxStatusComOValor("Finalizadas");

        Then.naPaginaDeListagemObras.deveExibirONumeroDeObrasQueSeAplicamAoFiltro(1);
        Then.iTeardownMyApp();
    });
})