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
    }
}
