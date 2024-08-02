sap.ui.define([
    "sap/ui/core/library"

], (coreLibrary) => {
    "use strict";

    const { ValueState } = coreLibrary;
    const MENSAGEM_ERRO_CAMPO_VAZIO = "Este campo é obrigatório.";

    return {
        validarNome(input) {
            const valor = input.getValue();
            const regexLetras = /^[a-zA-Zà-úÀ-Ú-' ]*$/;
            const mensagemErroRegexNome = "O nome deve conter apenas letras, espaços ou símbolos como - e '.";
            const mensagemErroNomeExcedeTamanhoMaximo = "O nome do cliente pode ter até 100 caracteres.";
            const eValido = (valor !== "" && regexLetras.test(valor) && valor.length <= 100)

            if (valor === "") {
                input.setValueState(ValueState.Error);
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
            }

            if (!regexLetras.test(valor)) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroRegexNome);
            }

            if (valor.length > 100) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroNomeExcedeTamanhoMaximo);
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }
        },

        validarEmail(input) {
            const valor = input.getValue();
            const regexEmail = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
            const mensagemErroRegexEmail = "O email deve ter formato válido e conter apenas letras sem acento, números, espaços ou alguns símbolos, como - e _.";
            const eValido = (valor !== "" && regexEmail.test(valor))

            if (valor === "") {
                input.setValueState(ValueState.Error);
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
            }

            if (!regexEmail.test(valor)) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroRegexEmail);
            }

            if (eValido) {
                input.setValueState(ValueState.None);
            }
        },

        validarTelefone(input) {
            const valor = input.getValue().replace(/[()_\-]/g, "");
            const mensagemErroTelefoneTamanhoInvalido = "O telefone deve conter 11 dígitos.";
            const tamanhoTelefone = 11;
            const eValido = (valor !== "" && valor.length === tamanhoTelefone);

            if (valor === "") {
                input.setValueState(ValueState.Error);
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
            }

            if (valor.length !== tamanhoTelefone) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroTelefoneTamanhoInvalido);
            }

            if (eValido) {
                input.setValueState(ValueState.None);
            }
        },

        validarCpf(input) {
            const valor = input.getValue().replace(/[._\-]/g, "");
            const mensagemErroCPFInvalido = "O CPF informado é inválido.";
            const eValido = (valor !== "" && this.eCpfValido(valor))


            console.log(valor)


            if (valor === "") {
                input.setValueState(ValueState.Error);
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
            }

            if (!this.eCpfValido(valor)) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroCPFInvalido);
            }

            if (eValido) {
                input.setValueState(ValueState.None);
            }
        },

        eCpfValido(cpf) {
            var Soma = 0
            var Resto

            var strCPF = String(cpf).replace(/[^\d]/g, '')

            if (strCPF.length !== 11)
                return false

            if ([
                '00000000000',
                '11111111111',
                '22222222222',
                '33333333333',
                '44444444444',
                '55555555555',
                '66666666666',
                '77777777777',
                '88888888888',
                '99999999999',
            ].indexOf(strCPF) !== -1)
                return false

            for (let i = 1; i <= 9; i++)
                Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (11 - i);

            Resto = (Soma * 10) % 11

            if ((Resto == 10) || (Resto == 11))
                Resto = 0

            if (Resto != parseInt(strCPF.substring(9, 10)))
                return false

            Soma = 0

            for (let i = 1; i <= 10; i++)
                Soma = Soma + parseInt(strCPF.substring(i - 1, i)) * (12 - i)

            Resto = (Soma * 10) % 11

            if ((Resto == 10) || (Resto == 11))
                Resto = 0

            if (Resto != parseInt(strCPF.substring(10, 11)))
                return false

            return true
        }
    };
});