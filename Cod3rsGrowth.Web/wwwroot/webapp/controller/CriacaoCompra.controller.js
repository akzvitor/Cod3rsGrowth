sap.ui.define([
    "ui5/coders/controller/BaseController",
    "sap/ui/model/Filter",
    "sap/ui/model/FilterOperator",
    "../model/formatter",
    "../model/validator"

], (BaseController, Filter, FilterOperator, formatter, validator) => {
    "use strict";

    const API_OBRAS_URL = "http://localhost:5070/api/Obras";
    const MODELO_OBRAS = "restObras";
    const API_COMPRAS_URL = "http://localhost:5070/api/Compras";
    const ID_NOME_FORM_INPUT = "nomeFormInput";
    const ID_EMAIL_FORM_INPUT = "emailFormInput";
    const ID_CPF_FORM_INPUT = "cpfFormInput";
    const ID_TELEFONE_FORM_INPUT = "telefoneFormInput";

    return BaseController.extend("ui5.coders.controller.CriacaoCompra", {
        formatter: formatter,
        validator: validator,

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
            const inputNome = this.oView.byId(ID_NOME_FORM_INPUT);
            const valorNome = inputNome.getValue();
            const inputEmail = this.oView.byId(ID_EMAIL_FORM_INPUT);
            const valorEmail = inputEmail.getValue()
            const inputCpf = this.oView.byId(ID_CPF_FORM_INPUT);
            const valorCpf = inputCpf.getValue()
            const inputTelefone = this.oView.byId(ID_TELEFONE_FORM_INPUT);
            const valorTelefone = inputTelefone.getValue()
            const dataDaCompra = new Date();
            const oObrasSelecionadas = this._obterObrasSelecionadas();
            const erroListaDeProdutosVazia = 0;
            const data = {
                cpf: valorCpf,
                nome: valorNome,
                telefone: valorTelefone,
                email: valorEmail,
                dataCompra: dataDaCompra,
                valorCompra: oObrasSelecionadas.valorTotalCompra,
                listaIdDosProdutos: oObrasSelecionadas.listaIdsSelecionados
            }

            const dadosSaoValidos = validator.validarDados(inputNome, inputEmail, inputTelefone, inputCpf);

            if (dadosSaoValidos && oObrasSelecionadas.listaIdsSelecionados.length !== erroListaDeProdutosVazia)
                this._postData(data);
        },

        _obterObrasSelecionadas() {
            let oList = this.byId("catalogoObras");
            let itensSelecionados = oList.getSelectedItems();
            let obj = { listaIdsSelecionados: [], valorTotalCompra: 0 };

            for (let i = 0; i < itensSelecionados.length; i++) {
                let itemSelecionado = itensSelecionados[i];
                let contexto = itemSelecionado.getBindingContext(MODELO_OBRAS);
                let obra = contexto.getProperty(null, contexto);

                obj.listaIdsSelecionados[i] = obra.id;
                obj.valorTotalCompra += obra.valorObra;
            };

            return obj;
        },

        _postData(data) {
            fetch(API_COMPRAS_URL, {
                method: 'POST',
                body: JSON.stringify(data),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(response => response.json())
                .then(data => console.log(data));
        },

        aoPreencherNome(oEvent) {
            const oInput = oEvent.getSource();

            validator.validarNome(oInput);
        },

        aoPreencherEmail(oEvent) {
            const oInput = oEvent.getSource();

            validator.validarEmail(oInput);
        },
        
        aoPreencherTelefone(oEvent) {
            const oInput = oEvent.getSource();

            validator.validarTelefone(oInput);
        },

        aoPreencherCpf(oEvent) {
            const oInput = oEvent.getSource();

            validator.validarCpf(oInput);
        }
    });
});