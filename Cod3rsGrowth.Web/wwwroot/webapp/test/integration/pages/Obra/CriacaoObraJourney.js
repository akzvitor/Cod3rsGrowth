sap.ui.define([
	"sap/ui/test/opaQunit",
	"./CriacaoObra"
], (opaTest) => {
	"use strict";

	QUnit.module("CriacaoObra");

	opaTest("Deveria apresentar erro ao tentar salvar obra com dado inválido,", (Given, When, Then) => {
		Given.iStartMyApp({
			hash: "criacaoObra"
		});

		When.naPaginaDeCriacaoObra.euPreenchoOInputTituloComOValor("2314");
		When.naPaginaDeCriacaoObra.euClicoNoBotaoSalvar();

		Then.naPaginaDeCriacaoObra.deveApresentarMensagemDeErroAoSalvarObra();
		Then.iTeardownMyApp();
	});

    opaTest("Deveria salvar a obra quando todos os dados forem validados", (Given, When, Then) => {
		Given.iStartMyApp({
			hash: "criacaoObra"
		});

		When.naPaginaDeCriacaoObra.euPreenchoOInputTituloComOValor("TesteOPA");
		When.naPaginaDeCriacaoObra.euPreenchoOInputAutorComOValor("Sr Teste Opa");
		When.naPaginaDeCriacaoObra.euSelecionoOFormato("Mangá");
		When.naPaginaDeCriacaoObra.euSelecionoOStatus("Em lançamento");
		When.naPaginaDeCriacaoObra.euSelecionoADataDePublicacao("22/05/2005");
		When.naPaginaDeCriacaoObra.euAbroAComboBoxDeGeneros();
		When.naPaginaDeCriacaoObra.euSelecionoOGenero("Aventura");
		When.naPaginaDeCriacaoObra.euPreenchoASinopseComOValor("One Page Acceptance Tests!");
		When.naPaginaDeCriacaoObra.euClicoNoBotaoSalvar();

		Then.naPaginaDeCriacaoObra.deveApresentarMensagemDeSucessoAoSalvarObra();
		Then.iTeardownMyApp();
	});
});