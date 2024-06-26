﻿using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.ExtensaoDasStrings;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using System.Globalization;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarCompra : Form
    {
        private readonly ServicoCompraCliente _servicoCompraCliente;

        public FormCriarCompra(ServicoCompraCliente servicoCompraCliente)
        {
            _servicoCompraCliente = servicoCompraCliente;
            InitializeComponent();
        }

        private void AoInicializarFormulario(object sender, EventArgs e)
        {

        }

        private void AoClicarNoBotaoSalvar(object sender, EventArgs e)
        {
            try
            {
                CompraCliente novaCompra = new()
                {
                    Cpf = maskedTextBoxCpf.Text.Trim().Replace(".", "").Replace("-", ""),
                    Nome = textBoxNome.Text,
                    Telefone = maskedTextBoxTelefone.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", ""),
                    ValorCompra = decimal.Parse(textBoxValorCompra.Text),
                    Email = textBoxEmail.Text,
                    DataCompra = DateTime.Now
                };

                DialogResult dialogResult = MessageBox.Show("Deseja salvar a compra com os dados informados?",
                                                            "Salvar Compra", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    _servicoCompraCliente.Criar(novaCompra);
                    Close();
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoAlterarTextoDoCampoValor(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox
                    ?? throw new Exception("Texbox não foi encontrado");

                if (textBox.Text.NaoContemValor())
                    throw new ValidationException("Campo valor da compra está vazio.");

                int selectionStart = textBox.SelectionStart;
                int length = textBox.Text.Length;

                string text = textBox.Text.Replace(".", "").Replace(",", "");

                if (!int.TryParse(text, out int value))
                {
                    MessageBox.Show("Entrada inválida!");
                    textBox.Text = string.Empty;
                    return;
                }

                textBox.TextChanged -= AoAlterarTextoDoCampoValor;

                string formattedText = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N2}", value / 100.0);

                textBox.Text = formattedText;

                selectionStart = selectionStart + (textBox.Text.Length - length);

                const int valorPadraoTextBox = 0;
                selectionStart = selectionStart < textBox.Text.Length
                    ? valorPadraoTextBox
                    : textBox.Text.Length;

                textBox.SelectionStart = selectionStart;
                textBox.TextChanged += AoAlterarTextoDoCampoValor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao tentar executar evento");
            }
        }

        private void AoPressionarTeclaNoCampoValor(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == ',' || e.KeyChar == '.') && (sender as TextBox).Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
