sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/Listagem"
], (opaTest) => {
	"use strict";

	QUnit.module("Posts");

	opaTest("Deveria filtrar os dados da tabela por nome do cliente e exibir a tabela com os dados filtrados.", (Given, When, Then) => {
		Given.iStartMyApp();

		When.onTheAppPage.euPreenchoOInputNome();

		Then.onTheAppPage.aTabelaDeveSerFiltradaDeAcordoComFiltroNome();

		Then.iTeardownMyApp();
	});

	opaTest("Deveria filtrar os dados da tabela por CPF e exibir a tabela com os dados filtrados.", (Given, When, Then) => {
		Given.iStartMyApp();

		When.onTheAppPage.euPreenchoOInputCPF();

		Then.onTheAppPage.aTabelaDeveSerFiltradaDeAcordoComFiltroCPF();

		Then.iTeardownMyApp();
	});

	opaTest("Deveria filtrar os dados da tabela por data inicial e exibir a tabela com os dados filtrados.", (Given, When, Then) => {
		Given.iStartMyApp();

		When.onTheAppPage.euPreenchoOInputDataInicial();

		Then.onTheAppPage.aTabelaDeveSerFiltradaDeAcordoComFiltroDataInicial();

		Then.iTeardownMyApp();
	});
	
	opaTest("Deveria filtrar os dados da tabela por data final e exibir a tabela com os dados filtrados.", (Given, When, Then) => {
		Given.iStartMyApp();

		When.onTheAppPage.euPreenchoOInputDataFinal();

		Then.onTheAppPage.aTabelaDeveSerFiltradaDeAcordoComFiltroDataFinal();
		
		Then.iTeardownMyApp();
	});
});