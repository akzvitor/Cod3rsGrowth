sap.ui.define([
	"sap/ui/test/Opa5",
	"./arrangements/Startup",
	"./pages/CompraCliente/ListagemJourney",
	"./pages/CompraCliente/CriacaoCompraJourney"
], function (Opa5, Startup) {
	"use strict";

	Opa5.extendConfig({
		arrangements: new Startup(),
		viewNamespace: "ui5.coders.CompraCliente",
		autoWait: true
	});
});