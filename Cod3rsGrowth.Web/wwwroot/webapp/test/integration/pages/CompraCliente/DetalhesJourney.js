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

        Then.naPaginaDeDetalhes.oObjectListItemComIntroNomeDevePossuirOValor("Vitor");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroEmailDevePossuirOValor("vitor@outlook.com");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroCpfDevePossuirOValor("763.139.720-15");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroTelefoneDevePossuirOValor("(46) 46464-6464");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroDataCompraDevePossuirOValor("12 de ago. de 2024");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroValorTotalDevePossuirOValor("R$ 674,80");
        Then.iTeardownMyApp();
    });
});