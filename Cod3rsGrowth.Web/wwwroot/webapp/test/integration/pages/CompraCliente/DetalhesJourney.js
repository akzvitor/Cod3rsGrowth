sap.ui.define([
    "sap/ui/test/opaQunit",
    "./Detalhes",
    "./Listagem"
], (opaTest) => {
    "use strict";
    
    QUnit.module("Detalhes");

    opaTest("Deveria ver a página de edição ao clicar no botão Editar.", (Given, When, Then) => {
		Given.iStartMyApp({
            hash: "detalhes/3"
        });

		When.naPaginaDeDetalhes.euClicoNoBotaoEditar();

		Then.naPaginaDeCriacaoCompra.aPaginaDeveMudarParaEdicaoCompra();
	});

    opaTest("Deveria voltar para a página de Detalhes.", (Given, When, Then) => {
		When.naPaginaDeCriacaoCompra.euClicoNoBotaoNavBack();

		Then.naPaginaDeDetalhes.aPaginaDeveMudarParaDetalhes();
		Then.iTeardownMyApp();
	});

    opaTest("Deveria mostrar detalhes da compra correta partindo da tela de listagem.", (Given, When, Then) => {
        Given.iStartMyApp();

        When.naPaginaDeListagem.euClicoNoItemDaTabelaComNome("Bruno");

        Then.naPaginaDeDetalhes.oObjectListItemComIntroNomeDevePossuirOValor("Bruno");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroEmailDevePossuirOValor("bruno@uol.com");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroCpfDevePossuirOValor("602.582.600-50");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroTelefoneDevePossuirOValor("(33) 53523-4235");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroDataCompraDevePossuirOValor("19 de ago. de 2024");
        Then.naPaginaDeDetalhes.oObjectListItemComIntroValorTotalDevePossuirOValor("R$ 49,99");
        Then.iTeardownMyApp();
    });

    opaTest("Deveria mostrar detalhes da compra correta ao iniciar na página de detalhes.", (Given, When, Then) => {
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

    opaTest("Deveria deletar a compra corretamente.", (Given, When, Then) => {
        Given.iStartMyApp();

        When.naPaginaDeListagem.euClicoNoItemDaTabelaComNome("Paulo");
        When.naPaginaDeDetalhes.euClicoNoBotaoRemover();
        When.naPaginaDeDetalhes.euClicoNoBotaoSim();

        Then.naPaginaDeDetalhes.deveMostrarMensagemDeSucessoAoRemover();
    });

    opaTest("Deveria navegar de volta para a página de listagem ao clicar no botão voltar.", (Given, When, Then) => {
        When.naPaginaDeDetalhes.euClicoNoBotaoVoltarParaPaginaInicial();

		Then.naPaginaDeListagem.aPaginaDeveMudarParaListagem();
        Then.iTeardownMyApp();
    });
});