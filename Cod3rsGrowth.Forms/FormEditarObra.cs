using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.ExtensaoDasStrings;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;
using System.Globalization;

namespace Cod3rsGrowth.Forms
{
    public partial class FormEditarObra : Form
    {
        private readonly ServicoObra _servicoObra;
        private readonly Obra _obraASerEditada = new();
        private const int ItemCheckListDesmarcado = -1;

        public FormEditarObra(ServicoObra servicoObra, Obra obraASerEditada)
        {
            _obraASerEditada = obraASerEditada;
            _servicoObra = servicoObra;
            InitializeComponent();
        }

        private void AoInicializarFormulario(object sender, EventArgs e)
        {
            try
            {
                InicializarValoresComboBox();
                InicializarValoresDosCamposDeDados();
                InicializarGenerosSelecionados();
            }
            catch (Exception ex)
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

        private void AoClicarNoBotaoSalvar(object sender, EventArgs e)
        {
            try
            {
                _obraASerEditada.Autor = textBoxAutor.Text;
                _obraASerEditada.Titulo = textBoxTitulo.Text;
                _obraASerEditada.ValorObra = decimal.Parse(textBoxValor.Text);
                _obraASerEditada.Sinopse = richTextBoxSinopse.Text;
                _obraASerEditada.NumeroCapitulos = Convert.ToInt32(numericUpDownCapitulos.Value);
                _obraASerEditada.Formato = (Formato)comboBoxFormato.SelectedIndex;
                _obraASerEditada.InicioPublicacao = dateTimePickerInicioPublicacao.Value;
                _obraASerEditada.FoiFinalizada = radioButtonFinalizada.Checked;
                _obraASerEditada.GenerosParaCriacao = ObterGenerosSelecionados();
                _obraASerEditada.Generos = ObterListaDeEnumsGenero(ObterGenerosSelecionados());

                DialogResult dialogResult = MessageBox.Show("Deseja salvar a obra com os dados informados?",
                                                            "Salvar Obra", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _servicoObra.Editar(_obraASerEditada);
                    Close();
                }
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

        private void InicializarValoresComboBox()
        {
            comboBoxFormato.DataSource = Enum.GetValues(typeof(Formato));
        }

        private void InicializarValoresDosCamposDeDados()
        {
            textBoxTitulo.Text = _obraASerEditada.Titulo;
            textBoxAutor.Text = _obraASerEditada.Autor;
            textBoxValor.Text = _obraASerEditada.ValorObra.ToString();
            dateTimePickerInicioPublicacao.Value = _obraASerEditada.InicioPublicacao;
            richTextBoxSinopse.Text = _obraASerEditada.Sinopse;
            numericUpDownCapitulos.Value = _obraASerEditada.NumeroCapitulos;
            comboBoxFormato.SelectedItem = _obraASerEditada.Formato;
            _ = _obraASerEditada.FoiFinalizada == true ?
                radioButtonFinalizada.Checked = true : radioButtonEmLancamento.Checked = true;
        }

        private void InicializarGenerosSelecionados()
        {
            var generosSelecionados = _servicoObra.ObterGenerosVinculados(_obraASerEditada.Id);

            foreach (var item in generosSelecionados)
            {
                var index = checkedListBoxGeneros.Items.IndexOf(item);

                if (index != ItemCheckListDesmarcado)
                {
                    checkedListBoxGeneros.SetItemChecked(index, true);
                }
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

        private static List<Genero> ObterListaDeEnumsGenero(List<string> generosSelecionados)
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
