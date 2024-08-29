sap.ui.define([
    "sap/ui/test/Opa5",
	'sap/ui/test/matchers/Properties',
    'sap/ui/test/actions/Press',
    'sap/ui/test/actions/EnterText',
    'sap/ui/test/matchers/AggregationLengthEquals',
    'sap/ui/test/matchers/AggregationFilled'

], (Opa5, Properties, Press, EnterText, AggregationLengthEquals, AggregationFilled) => {
    "use strict";

    const NOME_DA_VIEW = "Obra.CriacaoObra";

    Opa5.createPageObjects({
        naPaginaDeCriacaoObra: {
            actions: {
                
            },

            assertions: {
                
            }
        }
    });
});