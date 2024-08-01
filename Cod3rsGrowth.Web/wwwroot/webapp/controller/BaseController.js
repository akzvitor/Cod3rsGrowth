sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/UIComponent",
	"../model/formatter"

], function(Controller, History, JSONModel, UIComponent, formatter) {
	"use strict";
	

	return Controller.extend("ui5.coders.controller.BaseController", {
		formatter: formatter,

		getRouter() {
			return UIComponent.getRouterFor(this);
		},

		onNavBack() {
			var history, previousHash;

			history = History.getInstance();
			previousHash = history.getPreviousHash();

			if (previousHash !== undefined) {
				window.history.go(-1);
			} else {
				this.getRouter().navTo("paginaInicial", {}, true);
			}
		},

		inicializarDados(urlDaApi, nomeDoModelo) {
            fetch(urlDaApi)
                .then((res) => res.json())
                .then((data) => this.getView().setModel(new JSONModel(data), nomeDoModelo))
                .catch((err) => console.error(err));
        }
	});
});
