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
        }
    };
});