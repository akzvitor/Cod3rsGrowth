using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormEditarObra : Form
    {
        private readonly ServicoObra _servicoObra;
        private Obra _obraASerEditada = new();

        public FormEditarObra(ServicoObra servicoObra, Obra obraASerEditada)
        {
            _obraASerEditada = obraASerEditada;
            _servicoObra = servicoObra;
            InitializeComponent();
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

            //foreach (var item in _obraASerEditada.GenerosParaCriacao)
            //{
            //    var index = checkedListBoxGeneros.Items.IndexOf(item);

            //    if (index != -1)
            //    {
            //        checkedListBoxGeneros.SetItemChecked(index, true);
            //    }
            //}
        }

        private void AoInicializarFormulario(object sender, EventArgs e)
        {
            try
            {
                InicializarValoresComboBox();
                InicializarValoresDosCamposDeDados();
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
    }
}
