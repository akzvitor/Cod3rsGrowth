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

		Then.naPaginaDeCriacaoCompra.DeveFiltrarOCatalogoPelaObraBuscada();

		Then.iTeardownMyApp();
	});

});