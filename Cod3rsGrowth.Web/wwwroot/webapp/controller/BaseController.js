sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/UIComponent",
	"../model/formatter",
	"sap/m/MessageBox",

], function (Controller, History, JSONModel, UIComponent, formatter, MessageBox) {
	"use strict";

	return Controller.extend("ui5.coders.controller.BaseController", {
		formatter: formatter,

		getRouter() {
			return UIComponent.getRouterFor(this);
		},

		processarAcao(action) {
			try {
				const resultado = action();
				return resultado;
			} catch (error) {
				MessageBox.error(error.message);
			}
		},

		aoCoincidirRota(rota, urlDaApi, nomeDoModelo) {
			this.processarAcao(() => {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.getRoute(rota).attachPatternMatched(() => {
					this.inicializarDados(urlDaApi, nomeDoModelo);
				}, this);
			});
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
		},

		formatarDataParaApi(data) {
			if (data === null || data === undefined) { return data; }

			let oDate = new Date(data);
			return oDate.toISOString();
		}
	});
});
