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

        Then.naPaginaDeDetalhes.oObjectListItemComIntroNomeDevePossuirOValor("Bruno");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroEmailDevePossuirOValor("bruno@uol.com");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroCpfDevePossuirOValor("602.582.600-50");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroTelefoneDevePossuirOValor("(33) 53523-4235");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroDataCompraDevePossuirOValor("19 de ago. de 2024");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroValorTotalDevePossuirOValor("R$ 49,99");
        Then.iTeardownMyApp();
    });

    opaTest("Deveria mostrar detalhes da compra correta.", (Given, When, Then) => {
        Given.iStartMyApp({
			hash: "detalhes/4"
		});

        Then.naPaginaDeDetalhes.oObjectListItemComIntroNomeDevePossuirOValor("Higor");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroEmailDevePossuirOValor("higor@hotmail.com");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroCpfDevePossuirOValor("408.515.880-50");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroTelefoneDevePossuirOValor("(43) 62352-3634");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroDataCompraDevePossuirOValor("19 de ago. de 2024");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroValorTotalDevePossuirOValor("R$ 79,99");
        Then.iTeardownMyApp();
    });
});