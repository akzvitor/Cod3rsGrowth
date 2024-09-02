sap.ui.define([
    "sap/ui/test/opaQunit",
    "./Detalhes",
    "./Listagem"
], (opaTest) => {
    "use strict";

    QUnit.module("Detalhes Obra");

    opaTest("Deveria mostrar etalhes da obra correta partindo da tela de listagem", (Given, When, Then) => {
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
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nGenerosDevePossuirOValor(" Ação, Aventura, Drama, Fantasia, Harém, Mistério, Psicológico, Sobrenatural");
        Then.naPaginaDeDetalhesDaObra.oTextComTooltipI18nSinopseDevePossuirOValor("Akame ga Kill! é um mangá shonen escrito por Takahiro e ilustrado por Tetsuya Tashiro que conta a história de Tatsumi, um jovem aldeão que se junta ao exército para lutar pelo império e ajudar a sua vila pobre. Depois de ver os seus amigos morrerem e descobrir a corrupção do governo, Tatsumi é recrutado pela assassina Leone e junta-se ao Night Raid, um grupo de guerreiros secretos que lutam contra a corrupção do império.");
        Then.iTeardownMyApp();
    });
});