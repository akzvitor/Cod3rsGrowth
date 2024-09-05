sap.ui.define([
    "sap/ui/test/opaQunit",
    "./Detalhes",
    "./Listagem"
], (opaTest) => {
    "use strict";

    QUnit.module("Detalhes Obra");

    opaTest("Deveria ver a página de editar obra ao clicar no botão Editar.", (Given, When, Then) => {
		Given.iStartMyApp({
            hash: "detalhesObra/6"
        });

		When.naPaginaDeDetalhesDaObra.euClicoNoBotaoEditar();

		Then.naPaginaDeCriacaoObra.aPaginaDeveMudarParaEdicaoObra();
	});

    opaTest("Deveria voltar para a página de Detalhes da obra.", (Given, When, Then) => {
		When.naPaginaDeCriacaoObra.euClicoNoBotaoNavBack();

		Then.naPaginaDeDetalhesDaObra.aPaginaDeveMudarParaDetalhes();
		Then.iTeardownMyApp();
	});

    opaTest("Deveria mostrar detalhes da obra correta partindo da tela de listagem", (Given, When, Then) => {
        Given.iStartMyApp({
            hash: "listagemObra"
        });

        When.naPaginaDeListagemObras.euClicoNoItemDaTabelaComTitulo("Akame ga Kill!");

        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nAutorDevePossuirOValor("Takahiro");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nTituloDevePossuirOValor("Akame ga Kill! ");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nFormatoDevePossuirOValor("Mangá");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nCapitulosDevePossuirOValor("80");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nStatusDevePossuirOValor("Finalizada");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nInicioDaPublicacaoDevePossuirOValor("22 de abr. de 2010");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nValorDevePossuirOValor("R$ 459,99");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nGenerosDevePossuirOValor("Ação,Aventura,Drama,Fantasia,Harém,Mistério,Psicológico,Sobrenatural");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nSinopseDevePossuirOValor("Akame ga Kill! é um mangá shonen escrito por Takahiro e ilustrado por Tetsuya Tashiro que conta a história de Tatsumi, um jovem aldeão que se junta ao exército para lutar pelo império e ajudar a sua vila pobre. Depois de ver os seus amigos morrerem e descobrir a corrupção do governo, Tatsumi é recrutado pela assassina Leone e junta-se ao Night Raid, um grupo de guerreiros secretos que lutam contra a corrupção do império.");
        Then.iTeardownMyApp();
    });

    opaTest("Deveria mostrar detalhes da obra correta ao iniciar na tela de detalhes", (Given, When, Then) => {
        Given.iStartMyApp({
            hash: "detalhesObra/6"
        });

        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nAutorDevePossuirOValor("Takahiro");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nTituloDevePossuirOValor("Akame ga Kill! ");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nFormatoDevePossuirOValor("Mangá");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nCapitulosDevePossuirOValor("80");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nStatusDevePossuirOValor("Finalizada");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nInicioDaPublicacaoDevePossuirOValor("22 de abr. de 2010");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nValorDevePossuirOValor("R$ 459,99");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nGenerosDevePossuirOValor("Ação,Aventura,Drama,Fantasia,Harém,Mistério,Psicológico,Sobrenatural");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nSinopseDevePossuirOValor("Akame ga Kill! é um mangá shonen escrito por Takahiro e ilustrado por Tetsuya Tashiro que conta a história de Tatsumi, um jovem aldeão que se junta ao exército para lutar pelo império e ajudar a sua vila pobre. Depois de ver os seus amigos morrerem e descobrir a corrupção do governo, Tatsumi é recrutado pela assassina Leone e junta-se ao Night Raid, um grupo de guerreiros secretos que lutam contra a corrupção do império.");
        Then.iTeardownMyApp();
    });

    opaTest("Deveria deletar a obra corretamente.", (Given, When, Then) => {
        Given.iStartMyApp({
            hash: "listagemObra"
        });

        When.naPaginaDeListagemObras.euClicoNoItemDaTabelaComTitulo("TesteOPA");
        When.naPaginaDeDetalhesDaObra.euClicoNoBotaoRemover();
        When.naPaginaDeDetalhesDaObra.euClicoNoBotaoSim();

        Then.naPaginaDeDetalhesDaObra.deveMostrarMensagemDeSucessoAoRemover();
    });

    opaTest("Deveria navegar de volta para a página de listagem ao clicar no botão voltar.", (Given, When, Then) => {
        When.naPaginaDeDetalhesDaObra.euClicoNoBotaoVoltarParaListaDeObras();

		Then.naPaginaDeListagemObras.aPaginaDeveMudarParaListagem();
        Then.iTeardownMyApp();
    });
});