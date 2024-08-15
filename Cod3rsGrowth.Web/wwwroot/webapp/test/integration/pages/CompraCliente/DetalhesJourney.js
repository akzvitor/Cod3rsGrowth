sap.ui.define([
    "sap/ui/test/opaQunit",
    "./Detalhes",
    "./Listagem"
], (opaTest) => {
    "use strict";
    
    QUnit.module("Detalhes");

    opaTest("Deveria mostrar detalhes da compra correta.", (Given, When, Then) => {
        Given.iStartMyApp();

        When.naPaginaDeListagem.euClicoEmUmItemDaTabela();

        Then.naPaginaDeDetalhes.deveExibirDetalhesDaCompraCorreta();
        Then.iTeardownMyApp();
    });
});