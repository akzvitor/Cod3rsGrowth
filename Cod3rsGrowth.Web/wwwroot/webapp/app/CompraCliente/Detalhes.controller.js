sap.ui.define([
	"ui5/coders/app/common/BaseController",
	"sap/ui/model/json/JSONModel",
	"sap/m/MessageBox"

], (BaseController, JSONModel, MessageBox) => {
	"use strict";

	const ROTA_DETALHES = "detalhes";
	const API_COMPRAS_URL = "http://localhost:5070/api/Compras/";
	const MODELO_COMPRAS = "restCompras";
	const MODELO_OBRAS = "restObras";
	const API_OBRAS_URL = "http://localhost:5070/api/Obras/Compra";
	var id_parametro;


	return BaseController.extend("ui5.coders.app.CompraCliente.Detalhes", {
		onInit() {
			this._aoCoincidirRota(ROTA_DETALHES);
		},

		_aoCoincidirRota(rota) {
			this.processarAcao(() => {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.getRoute(rota).attachPatternMatched((oEvent) => {
					this._resgatarIdURL(oEvent);
					this._inicializarDadosDaCompraSelecionada(oEvent);
				}, this);
			});
		},

		_resgatarIdURL(oEvent) {
			id_parametro = window.decodeURIComponent(oEvent.getParameter("arguments").idCompra);
		},

		_inicializarDadosDaCompraSelecionada(oEvent) {
			fetch(API_COMPRAS_URL + id_parametro)
				.then((res) => {
					return res.json();
				})
				.then((data) => {
					!data.Detail ? this.getView().setModel(new JSONModel(data), MODELO_COMPRAS)
						: this.capturarErroApi(data);
				})
				.catch((err) => console.error(err));

			fetch(API_OBRAS_URL + "/" + window.decodeURIComponent(oEvent.getParameter("arguments").idCompra))
				.then((res) => {
					return res.json();
				})
				.then((data) => {
					!data.Detail ? this.getView().setModel(new JSONModel(data), MODELO_OBRAS)
						: this.capturarErroApi(data);
				})
				.catch((err) => console.error(err));
		},

		aoClicarNoBotaoEditar() {
			this.processarAcao(() => {
				const oRouter = this.getOwnerComponent().getRouter();
				oRouter.navTo("edicaoCompra", {
					idCompra: id_parametro
				});
			});
		},

		aoClicarNoBotaoRemover: function () {
			const thisFunction = this;
			MessageBox.confirm("Tem certeza que deseja excluir essa compra?", {
				title: "Excluir Compra",
				actions: [MessageBox.Action.YES, MessageBox.Action.NO],
				onClose: function (sAction) {
					if (sAction === MessageBox.Action.YES) {
						thisFunction._removerCompra(id_parametro);
						MessageBox.success(`A compra foi removida com sucesso.`, {
							actions: ["Voltar para a página inicial"],
							onClose: function () {
								thisFunction.getRouter().navTo("listagem", {}, true);
							}
						});
					}
				}
			});
		},

		_removerCompra(id) {
			fetch(API_COMPRAS_URL + id, {
				method: 'DELETE',
				headers: {
					'Content-Type': 'application/json',
				}
			})
				.then((res) => {
					return res.ok ? console.log(res) : res.json()
				})
				.then((data) => {
					!data.Detail ? console.log(data)
						: this.capturarErroApi(data);
				})
				.catch((err) => console.error(err));
		}
	});
});