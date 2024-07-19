sap.ui.define([
	"sap/ui/test/opaQunit",
	"./pages/App"
], (opaTest) => {
	"use strict";

	QUnit.module("Navigation");

	opaTest("Ao clicar no botão Say Hello to the World!", (Given, When, Then) => {
		// Arrangements
		Given.iStartMyUIComponent({
			componentConfig: {
				name: "ui5.coders"
			}
		});

		//Actions
		When.onTheAppPage.euClicoNoBotaoSayHelloToTheWorld();

		// Assertions
		Then.onTheAppPage.deveSerExibidoUmMessageToast();

		// Cleanup
		Then.iTeardownMyApp();
	});
});