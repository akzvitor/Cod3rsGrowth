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
            let eValido = true;

            if (valor === "") {
                input.setValueState(ValueState.Error);
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
                eValido = false;
            }

            if (!regexLetras.test(valor)) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroRegexNome);
                eValido = false;
            }

            if (valor.length > 100) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroNomeExcedeTamanhoMaximo);
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarEmail(input) {
            const valor = input.getValue();
            const regexEmail = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
            const mensagemErroRegexEmail = "O email deve ter formato válido e conter apenas letras sem acento, números, espaços ou alguns símbolos, como - e _.";
            let eValido = true;

            if (valor === "") {
                input.setValueState(ValueState.Error);
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
                eValido = false;
            }

            else if (!regexEmail.test(valor)) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroRegexEmail);
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarTelefone(input) {
            const valor = input.getValue().replace(/[()_\-]/g, "");
            const mensagemErroTelefoneTamanhoInvalido = "O telefone deve conter 11 dígitos.";
            const tamanhoTelefone = 12;
            let eValido = true;

            if (valor === "") {
                input.setValueState(ValueState.Error);
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
                eValido = false;
            }

            else if (valor.length !== tamanhoTelefone) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroTelefoneTamanhoInvalido);
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarCpf(input) {
            const valor = input.getValue().replace(/[._\-]/g, "");
            const mensagemErroCPFInvalido = "O CPF informado é inválido.";
            let eValido = true;

            if (valor === "") {
                input.setValueState(ValueState.Error);
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
                eValido = false;
            }

            else if (!this.eCpfValido(valor)) {
                input.setValueState(ValueState.Error);
                input.setValueStateText(mensagemErroCPFInvalido);
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarDados(nome, email, telefone, cpf) {
            const nomeEValido = this.validarNome(nome);
            const emailValido = this.validarEmail(email);
            const telefoneEValido = this.validarTelefone(telefone);
            const cpfEValido = this.validarCpf(cpf);

            return nomeEValido && emailValido && telefoneEValido && cpfEValido;
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
        },

        validarTitulo(input) {
            const valor = input.getValue();
            const tamanhoLimiteTitulo = 2000;
            const mensagemErroTituloExcedeTamanhoMaximo = `O título pode ter no máximo ${tamanhoLimiteTitulo} caracteres.`;
            let eValido = true;

            input.setValueState(ValueState.Error);

            if (!valor) {
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
                eValido = false;
            }

            if (valor.length > tamanhoLimiteTitulo) {
                input.setValueStateText(mensagemErroTituloExcedeTamanhoMaximo);
                eValido = false
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarAutor(input) {
            const valor = input.getValue();
            const tamanhoLimiteAutor = 150;
            const regexAutor = /^[a-zA-Zà-úÀ-Ú0-9-_ ]*$/;
            const mensagemErroAutorExcedeTamanhoMaximo = `O nome do autor deve ter até ${tamanhoLimiteAutor} caracteres.`;
            const mensagemErroRegexAutor = "O nome do autor deve conter apenas letras, números, espaços ou símbolos como - ou _.";
            let eValido = true;

            input.setValueState(ValueState.Error);

            if (!valor) {
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
                eValido = false;
            }

            if (valor.length > tamanhoLimiteAutor) {
                input.setValueStateText(mensagemErroAutorExcedeTamanhoMaximo);
                eValido = false;
            }

            if (!regexAutor.test(valor)) {
                input.setValueStateText(mensagemErroRegexAutor);
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarSinopse(input) {
            const valor = input.getValue();
            const tamanhoLimiteSinopse = 2000;
            const mensagemErroSinopseExcedeTamanhoMaximo = `A sinopse deve ter no máximo ${tamanhoLimiteSinopse} caracteres.`;
            let eValido = true;

            input.setValueState(ValueState.Error);

            if (!valor) {
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
                eValido = false;
            }

            if (valor.length > tamanhoLimiteSinopse) {
                input.setValueStateText(mensagemErroSinopseExcedeTamanhoMaximo);
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarInicioDaPublicacao(input) {
            const valorString = input.getDateValue();
            const valorData = new Date(valorString);
            const mensagemErroDataPubliInvalida = "Data inválida. Não é possível colocar uma data futura."
            let eValido = true;

            input.setValueState(ValueState.Error);

            if (!valorString) { 
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO); 
                eValido = false;
            }

            else if (valorData >= Date.now()) { 
                input.setValueStateText(mensagemErroDataPubliInvalida); 
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarStatus(input) {
            const valor = input.getValue();
            const mensagemErroStatusInvalido = "Status inválido."
            const listaDeStatus = ["Finalizada", "Em lançamento"]
            let eValido = true;

            input.setValueState(ValueState.Error);

            if (!valor) { 
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO);
                eValido = false;
            }

            if (!listaDeStatus.includes(valor)) { 
                input.setValueStateText(mensagemErroStatusInvalido); 
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },


        validarFormato(input) {
            const valor = input.getValue();
            const mensagemErroFormatoInvalido = "Formato de obra inválido."
            const listaDeFormatos = ["Mangá", "Manhua", "Manhwa", "Web Novel"]
            let eValido = true;

            input.setValueState(ValueState.Error);

            if (!valor) { 
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO); 
                eValido = false;
            }

            if (!listaDeFormatos.includes(valor)) { 
                input.setValueStateText(mensagemErroFormatoInvalido); 
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }

            return false;
        },

        validarGeneros(input) {
            const valor = input.getSelectedKeys();
            let eValido = true;

            input.setValueState(ValueState.Error);

            if (!valor.length) { 
                input.setValueStateText(MENSAGEM_ERRO_CAMPO_VAZIO); 
                eValido = false;
            }

            if (eValido) {
                input.setValueState(ValueState.None);
                return true;
            }
            return false;
        },

        validarDadosObra(titulo, autor, sinopse, inicioDaPublicacao, formato, generos, status) {
            const tituloEValido = this.validarTitulo(titulo);
            const autorEValido = this.validarAutor(autor);
            const sinopseEValida = this.validarSinopse(sinopse);
            const inicioDaPublicacaoEValido = this.validarInicioDaPublicacao(inicioDaPublicacao);
            const formatoEValido = this.validarFormato(formato);
            const generosSaoValidos = this.validarGeneros(generos);
            const statusEValido = this.validarStatus(status);
            
            return tituloEValido && autorEValido && sinopseEValida && inicioDaPublicacaoEValido
                && formatoEValido && generosSaoValidos && statusEValido;
        }
    };
});