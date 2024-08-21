sap.ui.define([
	"sap/ui/test/opaQunit",
	"./CriacaoCompra"
], (opaTest) => {
	"use strict";

	QUnit.module("CriacaoCompra");

	opaTest("Deveria filtrar o catálogo pelo nome da obra.", (Given, When, Then) => {
		Given.iStartMyApp({
			hash: "criacaoCompra"
		});

		When.naPaginaDeCriacaoCompra.euPreenchoOSearchField();

		Then.naPaginaDeCriacaoCompra.deveFiltrarOCatalogoPelaObraBuscada();
		Then.iTeardownMyApp();
	});

	opaTest("Deveria apresentar erro ao tentar salvar obra com dado inválido,", (Given, When, Then) => {
		Given.iStartMyApp({
			hash: "criacaoCompra"
		});

		When.naPaginaDeCriacaoCompra.euPreenchoOInputNomeComDadoInvalido("nomeFormInput", "2314");
		When.naPaginaDeCriacaoCompra.euClicoNoBotaoSalvar();

		Then.naPaginaDeCriacaoCompra.deveApresentarMensagemDeErroAoSalvarCompra();
		Then.iTeardownMyApp();
	});


	opaTest("Deveria salvar a obra quando todos os dados forem validados", (Given, When, Then) => {
		Given.iStartMyApp({
			hash: "criacaoCompra"
		});

		When.naPaginaDeCriacaoCompra.euPreenchoOInputNomeComDadoValido("nomeFormInput", "Paulo");
		When.naPaginaDeCriacaoCompra.euPreenchoOInputEmailComDadoValido("emailFormInput", "aasfae@km.com");
		When.naPaginaDeCriacaoCompra.euPreenchoOInputCpfComDadoValido("cpfFormInput", "69964405057");
		When.naPaginaDeCriacaoCompra.euPreenchoOInputTelefoneComDadoValido("telefoneFormInput", "65345445456");
		When.naPaginaDeCriacaoCompra.euSelecionoAoMenosUmaObraDoCatalogo();
		When.naPaginaDeCriacaoCompra.euClicoNoBotaoSalvar();

		Then.naPaginaDeCriacaoCompra.deveApresentarMensagemDeSucessoAoSalvarCompra();
		Then.iTeardownMyApp();
	});
});