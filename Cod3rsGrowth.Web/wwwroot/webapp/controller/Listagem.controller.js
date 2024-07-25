sap.ui.define([
    "ui5/coders/controller/BaseController",
    "sap/ui/model/json/JSONModel",
    "../model/formatter"
], (BaseController, JSONModel, formatter) => {
    "use strict";

    const API_URL = "http://localhost:5070/api/Compras?";
    const NOME_DO_MODELO = "restCompras";
    const ID_NOME_FILTRO_INPUT = "nomeFiltroInput";
    const ID_CPF_FILTRO_INPUT = "cpfFiltroInput";
    const ID_DATAINICIAL_FILTRO_INPUT= "dataInicialFiltroInput";
    const ID_DATAFINAL_FILTRO_INPUT= "dataFinalFiltroInput";

    return BaseController.extend("ui5.coders.controller.Listagem", {
        formatter: formatter,

        InicializarDados : function() {
            fetch(API_URL)
                .then((res) => res.json())
                .then((data) => this.getView().setModel(new JSONModel(data), NOME_DO_MODELO))
                .catch((err) => console.error(err));
        },

        onInit() {
            this.InicializarDados();
        },

        AoAlterarInputFiltro() {
            const inputNome = this.oView.byId(ID_NOME_FILTRO_INPUT).getValue();
            const inputCpf = this.oView.byId(ID_CPF_FILTRO_INPUT).getValue();
            const inputDataInicial = this.oView.byId(ID_DATAINICIAL_FILTRO_INPUT).getValue();
            const inputDataFinal = this.oView.byId(ID_DATAFINAL_FILTRO_INPUT).getValue();
            
            if (inputNome) {API_URL += "nomeCliente=" + inputNome + "&"}
            if (inputCpf) {API_URL += "cpf=" + inputCpf + "&"}
            if (inputDataInicial) {API_URL += "dataInicial=" + inputDataInicial + "&"}
            if (inputDataFinal) {API_URL += "dataFinal=" + inputDataFinal + "&"}

            this.InicializarDados();
        }
    });
});