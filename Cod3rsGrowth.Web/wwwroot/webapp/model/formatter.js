sap.ui.define([
    "sap/ui/core/format/NumberFormat",
    "sap/ui/core/format/DateFormat"
], (NumberFormat, DateFormat) => {
    "use strict";
 
    return {
        formatarValor(valor) {
            let oCurrencyFormat = NumberFormat.getCurrencyInstance({
                currencyCode: false
            });
 
            return oCurrencyFormat.format(valor, "BRL");
        },
 
        formatarData(data) {
            if (!data) { return data; }
 
            let oDateTimeFormat = DateFormat.getDateTimeInstance({
                format: "yMMMd"
            });
 
            return oDateTimeFormat.format(new Date(data));
        },
 
        formatarDataParaApi(data) {
            if (!data) { return data; }
 
            let oDate = new Date(data);
            return oDate.toISOString();
        },
 
        async formatarCpf(cpf) {
            if (!cpf) { return cpf; }
 
            return cpf.replace(/(\d{3})(\d{3})(\d{3})(\d{2})/, "$1.$2.$3-$4");
        },
 
        async formatarTelefone(telefone) {
            if (!telefone) { return telefone; }
 
            telefone = telefone.replace(/\D/g, '');
            telefone = telefone.replace(/(\d{2})(\d)/, "($1) $2");
            telefone = telefone.replace(/(\d)(\d{4})$/, "$1-$2");
            return telefone;
        },
 
        formatarFormatoParaTabela(formato) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
 
            switch (formato) {
                case 0:
                    return oResourceBundle.getText("Formato.manga");
                case 1:
                    return oResourceBundle.getText("Formato.manhwa");
                case 2:
                    return oResourceBundle.getText("Formato.manhua");
                case 3:
                    return oResourceBundle.getText("Formato.webnovel");
            }
        },
 
        formatarFormatoParaApi(formato) {
            switch (formato) {
                case "Manga" :
                    return 0;
                case "Manhua":
                    return 1;
                case "Manhwa":
                    return 2;
                case "WebNovel":
                    return 3;
                default:
                    return formato;
            }
        },

        formatarFormatoParaEdicao(formato) {
            switch (formato) {
                case 0:
                    return "Manga";
                case 1:
                    return "Manhua";
                case 2:
                    return "Manhwa";
                case 3:
                    return "WebNovel";
                default:
                    return formato;
            }
        },
 
        formatarFormatoParaFiltro(formato) {
            switch (formato) {
                case "Mangá":
                    return "Manga";
                case "Web Novel":
                    return "WebNovel";
                default:
                    return formato;
            }
        },
 
        formatarGenerosParaExibicao(listaDeEnum) {
            const generos = {
                0: "Ação",
                1: "Artes Marciais",
                2: "Aventura",
                3: "Comédia",
                4: "Drama",
                5: "Ecchi",
                6: "Espaço",
                7: "Esporte",
                8: "Fantasia",
                9: "Harém",
                10: "Histórico",
                11: "Horror",
                12: "Jogos",
                13: "Mahou Shoujo",
                14: "Mecha",
                15: "Militar",
                16: "Mistério",
                17: "Musical",
                18: "Psicológico",
                19: "Romance",
                20: "Samurai",
                21: "Sci-fi",
                22: "Seinen",
                23: "Shoujo",
                24: "Shounen",
                25: "Slice of Life",
                26: "Sobrenatural",
                27: "Vida Escolar",
                28: "Yaoi",
                29: "Yuri"
            }
            let listaDeDescricoes = [];
 
            listaDeEnum.forEach(codigoInt => {
                listaDeDescricoes.push(generos[codigoInt]);
            });
 
            return listaDeDescricoes;
        },
 
        formatarGenerosParaApi(listaDeDescricoes) {
            const generos = {
                "Ação": 0,
                "Artes Marciais": 1,
                "Aventura": 2,
                "Comédia": 3,
                "Drama": 4,
                "Ecchi": 5,
                "Espaço": 6,
                "Esporte": 7,
                "Fantasia": 8,
                "Harém": 9,
                "Histórico": 10,
                "Horror": 11,
                "Jogos": 12,
                "Mahou Shoujo": 13,
                "Mecha": 14,
                "Militar": 15,
                "Mistério": 16,
                "Musical": 17,
                "Psicológico": 18,
                "Romance": 19,
                "Samurai": 20,
                "Sci-fi": 21,
                "Seinen": 22,
                "Shoujo": 23,
                "Shounen": 24,
                "Slice of Life": 25,
                "Sobrenatural": 26,
                "Vida Escolar": 27,
                "Yaoi": 28,
                "Yuri": 29
            }
            let listaDeInteiros = [];
 
            listaDeDescricoes.forEach(descricao => {
                listaDeInteiros.push(generos[descricao]);
            });
 
            return listaDeInteiros;
        },
 
        formatarStatus(status) {
            const oResourceBundle = this.getOwnerComponent().getModel("i18n").getResourceBundle();
 
            switch (status) {
                case false:
                    return oResourceBundle.getText("Status.EmLancamento");
                case true:
                    return oResourceBundle.getText("Status.Finalizada");
            }
        },
 
        converterStringParaBoolean(string) {
            return string === "true"
        }
    };
});
 