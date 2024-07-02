using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.ExtensaoDasStrings;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using System.Globalization;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarObra : Form
    {
        private readonly ServicoObra _servicoObra;

        public FormCriarObra(ServicoObra servicoObra)
        {
            _servicoObra = servicoObra;
            InitializeComponent();
        }

        private void InicializarValoresComboBox()
        {
            comboBoxFormato.DataSource = Enum.GetValues(typeof(Formato));
        }

        private void LimparComboBox()
        {
            comboBoxFormato.SelectedItem = null;
        }

        private void AoInicializarFormulario(object sender, EventArgs e)
        {
            try
            {
                InicializarValoresComboBox();
                LimparComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoSalvar(object sender, EventArgs e)
        {
            try
            {
                List<string> generosSelecionados = ObterGenerosSelecionados();
                List<Genero> listaDeGeneros = ObterListaDeEnumsGenero(generosSelecionados);

                Obra novaObra = new()
                {
                    Autor = textBoxAutor.Text,
                    Titulo = textBoxTitulo.Text,
                    ValorObra = decimal.Parse(textBoxValor.Text),
                    Sinopse = richTextBoxSinopse.Text,
                    NumeroCapitulos = Convert.ToInt32(numericUpDownCapitulos.Value),
                    Formato = (Formato)comboBoxFormato.SelectedIndex,
                    InicioPublicacao = dateTimePickerInicioPublicacao.Value,
                    FoiFinalizada = radioButtonFinalizada.Checked,
                    Generos = listaDeGeneros
                };

                DialogResult dialogResult = MessageBox.Show("Deseja salvar a obra com os dados informados?",
                                                            "Salvar Obra", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _servicoObra.Criar(novaObra);
                    _servicoObra.SalvarGeneros(novaObra.Id, generosSelecionados);
                    Close();
                }
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoCancelar(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
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

                if (!textBox.Text.ContemValor())
                    throw new ValidationException("Campo valor da obra está vazio.");

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

        private List<string> ObterGenerosSelecionados()
        {
            List<string> generosSelecionados = new();

            foreach (var item in checkedListBoxGeneros.CheckedItems)
            {
                generosSelecionados.Add(item.ToString());
            }

            return generosSelecionados;
        }

        private List<Genero> ObterListaDeEnumsGenero(List<string> generosSelecionados)
        {
            List<Genero> generosDaObra = new();

            foreach (var item in generosSelecionados)
            {
                generosDaObra.Add((Genero)Enum.Parse(typeof(Genero), item.ToString()));
            }

            return generosDaObra;
        }
    }
}
