sap.ui.define([
    "sap/ui/core/format/NumberFormat",
    "sap/ui/core/format/DateFormat"
], (NumberFormat, DateFormat) => {
    "use strict";

    return {
        formatarValor(valor) {
            var oCurrencyFormat = NumberFormat.getCurrencyInstance({
                currencyCode: false
            });

            return oCurrencyFormat.format(valor, "BRL");
        },

        formatarData(data) {
            var oDateTimeFormat = DateFormat.getDateTimeInstance({
                format: "yMMMd"
            });

            return oDateTimeFormat.format(new Date(data));
        },

        formatarCpf(cpf) {
            return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
        },

        formatarTelefone(telefone) {
            telefone = telefone.replace(/\D/g, '');
            telefone = telefone.replace(/(\d{2})(\d)/, "($1) $2");
            telefone = telefone.replace(/(\d)(\d{4})$/, "$1-$2");
            return telefone;
        },
    };
});