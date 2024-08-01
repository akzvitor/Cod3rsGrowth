sap.ui.define([
    "ui5/coders/controller/BaseController",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator"
], (BaseController, Filter, FilterOperator) => {
    "use strict";

    const API_OBRAS_URL = "http://localhost:5070/api/Obras";
    const MODELO_OBRAS = "restObras";
    const API_COMPRAS_URL = "http://localhost:5070/api/Compras";
    const ID_NOME_FORM_INPUT = "nomeFormInput";
    const ID_EMAIL_FORM_INPUT = "emailFormInput";
    const ID_CPF_FORM_INPUT = "cpfFormInput";
    const ID_TELEFONE_FORM_INPUT = "telefoneFormInput";

    return BaseController.extend("ui5.coders.controller.CriacaoCompra", {
        onInit() {
            this.inicializarDados(API_OBRAS_URL, MODELO_OBRAS);
        },

        aoProcurarObra(oEvent) {
            const aFilter = [];
            const sQuery = oEvent.getParameter("query");
            if (sQuery) {
                aFilter.push(new Filter("titulo", FilterOperator.Contains, sQuery));
            }

            const oList = this.byId("catalogoObras");
            const oBinding = oList.getBinding("items");
            oBinding.filter(aFilter);
        },

        aoClicarNoBotaoSalvar() {
            const inputNome = this.oView.byId(ID_NOME_FORM_INPUT).getValue();
            const inputEmail = this.oView.byId(ID_EMAIL_FORM_INPUT).getValue();
            const inputCpf = this.oView.byId(ID_CPF_FORM_INPUT).getValue();
            const inputTelefone = this.oView.byId(ID_TELEFONE_FORM_INPUT).getValue();
            const dataCompra = Date.now;
            const listaIdsSelecionados = this._obterObrasSelecionadas();

            console.log(listaIdsSelecionados)

            const data = {
                cpf: inputCpf, 
                nome: inputNome,
                telefone: inputTelefone,
                email: inputEmail,
                dataCompra: dataCompra,
                listaIdDosProdutos: listaIdsSelecionados
            }

            this._postData(data);
        },

        _obterObrasSelecionadas() {
            let oList = this.byId("catalogoObras"); 
            let itensSelecionados = oList.getSelectedItems();
            let listaIdsSelecionados = [];

            for (let i = 0; i < itensSelecionados.length; i++) {
                let itemSelecionado = itensSelecionados[i];
                let contexto = itemSelecionado.getBindingContext(MODELO_OBRAS);
                let obra = contexto.getProperty(null, contexto);

                listaIdsSelecionados[i] =  obra.id;
            };

            return listaIdsSelecionados;
        },

        _postData(data) {
            fetch(API_COMPRAS_URL, {
              method: 'POST', 
              body: JSON.stringify(data), 
              headers:{
                'Content-Type': 'application/json'
              }
            })
            .then(response => response.json())
            .then(data => console.log(data));
        }          
    });
});