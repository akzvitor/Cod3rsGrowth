sap.ui.define([
	"sap/ui/core/mvc/Controller",
	"sap/ui/core/routing/History",
	"sap/ui/model/json/JSONModel",
	"sap/ui/core/UIComponent",
	"ui5/coders/model/formatter",
	"sap/m/MessageBox",

], function (Controller, History, JSONModel, UIComponent, formatter, MessageBox) {
	"use strict";

	return Controller.extend("ui5.coders.app.common.BaseController", {
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
				this.getRouter().navTo("listagem", {}, true);
			}
		},

		inicializarDados(urlDaApi, nomeDoModelo) {
			fetch(urlDaApi)
				.then((res) => {
					return res.json();
				})
				.then((data) => {
					!data.Detail ?  this.getView().setModel(new JSONModel(data), nomeDoModelo)
					: this.capturarErroApi(data);
				})
				.catch((err) => console.error(err));
		},

		capturarErroApi(erroRfc) {
			const mensagemErroPrincipal = erroRfc.Extensions.Erros.join(', ');
			const mensagemErroCompleta = `<p><strong>Status:</strong> ${erroRfc.Status}</p>` +
				`<p><strong>Detalhes:</strong><br /> ${erroRfc.Detail}</p>` +
				"<p>Para mais ajuda acesse <a href='//www.sap.com' target='_top'>aqui</a>.";

			MessageBox.error(mensagemErroPrincipal, {
				title: "Erro",
				details: mensagemErroCompleta,
				styleClass: "sapUiResponsivePadding--header sapUiResponsivePadding--content sapUiResponsivePadding--footer",
				dependentOn: this.getView()
			});
		},

		inicializarComboBox(urlApi, nomeDoModelo) {
            this.processarAcao(() => {
                fetch(urlApi)
                    .then((res) => {
                        return res.json();
                    })
                    .then((data) => {
                        if (!data.Detail) {
                            const opcoes = data.map((item) => ({opcao: item}));
                            this.getView().setModel(new JSONModel({opcoes: opcoes}), nomeDoModelo);
                        } 
                        else  
                            this.capturarErroApi(data);
                    })
                    .catch((err) => console.error(err));
            });
        },

		postData(urlApi, objeto) {
            fetch(urlApi, {
                method: 'POST',
                body: JSON.stringify(objeto),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => response.json())
                .then(data => console.log(data));
        },

		putData(urlApi, data) {
            fetch(urlApi, {
                method: 'PUT',
                body: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => response.json())
                .then(data => console.log(data));
        },

		deleteData(urlApi, id, mensagem, rotaParaVoltar) {
			fetch(urlApi + id, {
				method: 'DELETE',
				headers: {
					'Content-Type': 'application/json',
				}
			})
				.then((res) => {
					return res.ok ? 
					this.exibirMensagemDeSucessoAoRemover(mensagem, rotaParaVoltar) :
					res.json();
				})
				.then((data) => {
					if (data && data.Detail) 
						this.capturarErroApi(data) 
				})
				.catch((err) => console.error(err));
		},

		exibirMensagemDeSucessoAoRemover(mensagem, rotaParaVoltar) {
			MessageBox.success(mensagem, {
				actions: ["Voltar"],
				onClose: () => {
					this.getRouter().navTo(rotaParaVoltar, {}, true);
				}
			});
		},

		alterarTituloDaPagina(idPagina, chavei18n) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
            
            this.oView.byId(idPagina).setTitle(oResourceBundle.getText(chavei18n));
        },
	});
});
