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

	opaTest("Deveria apresentar inputs preenchidos com os dados da obra escolhida para edição", (Given, When, Then) => {
		Given.iStartMyApp({
			hash: "edicaoObra/6"
		});

		Then.naPaginaDeCriacaoObra.oInputAutorDeveConterOValor("Takahiro");
        Then.naPaginaDeCriacaoObra.oInputTituloDeveConterOValor("Akame ga Kill!");
        Then.naPaginaDeCriacaoObra.aComboBoxFormatoDeveConterOValor("Mangá");
        Then.naPaginaDeCriacaoObra.oStepInputCapitulosDeveConterOValor(80);
        Then.naPaginaDeCriacaoObra.aComboBoxStatusDeveConterOValor("Finalizada");
        Then.naPaginaDeCriacaoObra.oDatePickerDeveConterOValor("22 de abr. de 2010");
        Then.naPaginaDeCriacaoObra.oStepInputValorDeveConterOValor(459.99);
        Then.naPaginaDeCriacaoObra.aMultiComboBoxGenerosDeveConterOValor('Ação,Aventura,Drama,Fantasia,Harém,Mistério,Psicológico,Sobrenatural');
        Then.naPaginaDeCriacaoObra.oTextAreaSinopseDeveConterOValor("Akame ga Kill! é um mangá shonen escrito por Takahiro e ilustrado por Tetsuya Tashiro que conta a história de Tatsumi, um jovem aldeão que se junta ao exército para lutar pelo império e ajudar a sua vila pobre. Depois de ver os seus amigos morrerem e descobrir a corrupção do governo, Tatsumi é recrutado pela assassina Leone e junta-se ao Night Raid, um grupo de guerreiros secretos que lutam contra a corrupção do império.");

		Then.iTeardownMyApp();
	});

	opaTest("Deveria apresentar erro ao tentar editar obra com dado inválido", (Given, When, Then) => {
		Given.iStartMyApp({
			hash: "edicaoObra/25"
		});

		When.naPaginaDeCriacaoObra.euPreenchoOInputAutorComOValor("******");		
		When.naPaginaDeCriacaoObra.euClicoNoBotaoSalvar();

		Then.naPaginaDeCriacaoObra.deveApresentarMensagemDeErroAoEditarObra();
		Then.iTeardownMyApp();
	});

	opaTest("Deveria editar a obra quando todos os dados forem validados", (Given, When, Then) => {
		Given.iStartMyApp({
			hash: "edicaoObra/25"
		});

		When.naPaginaDeCriacaoObra.euPreenchoOInputTituloComOValor("TesteOPA Edição");
		When.naPaginaDeCriacaoObra.euPreenchoOInputAutorComOValor("Sr Teste Opa Edição");
		When.naPaginaDeCriacaoObra.euPreenchoASinopseComOValor("Edição Edição Edição Edição Edição Edição");
		When.naPaginaDeCriacaoObra.euClicoNoBotaoSalvar();

		Then.naPaginaDeCriacaoObra.deveApresentarMensagemDeSucessoAoEditarObra();
		Then.iTeardownMyApp();
	});
});