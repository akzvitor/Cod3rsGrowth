using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using System.ComponentModel;
using Cod3rsGrowth.Dominio.Enums;
using System.DirectoryServices.ActiveDirectory;


namespace Cod3rsGrowth.Forms
{
    public partial class MainForm : Form
    {
        private readonly ServicoObra _servicoObra;
        private readonly ServicoCompraCliente _servicoCompraCliente;
        private readonly FiltroObra _filtroObra = new();
        private readonly FiltroCompraCliente _filtroCompraCliente = new();

        public MainForm(ServicoObra servicoObra, ServicoCompraCliente servicoCompraCliente)
        {
            _servicoObra = servicoObra;
            _servicoCompraCliente = servicoCompraCliente;
            InitializeComponent();

            comboBoxFormatoObra.DataSource = Enum.GetValues(typeof(Formato));
            comboBoxFormatoObra.SelectedItem = null;
        }

        private void ListarObras()
        {
            dataGridObras.DataSource = _servicoObra.ObterTodos(_filtroObra);
        }

        private void ListarCompras()
        {
            dataGridCompras.DataSource = _servicoCompraCliente.ObterTodos(_filtroCompraCliente);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ListarObras();
            ListarCompras();
        }

        private void buttonFiltroObra_Click(object sender, EventArgs e)
        {
            _filtroObra.TituloObra = textBoxTituloObra.Text;
            _filtroObra.AutorObra = textBoxAutorObra.Text;
            _filtroObra.FormatoObra = (Formato?)comboBoxFormatoObra.SelectedItem;

            if (radioButtonStatusObraEmLancamento.Checked == false && 
                radioButtonStatusObraFinalizada.Checked == false)
            {
                _filtroObra.ObraFoiFinalizada = null;
            }
            else if (radioButtonStatusObraEmLancamento.Checked == true)
            {
                _filtroObra.ObraFoiFinalizada = false;
            }
            else if (radioButtonStatusObraFinalizada.Checked == true)
            {
                _filtroObra.ObraFoiFinalizada = true;
            }

            _filtroObra.AnoDaPublicacao = textBoxAnoObra.Text;
            ListarObras();
        }

        private void buttonLimparObras_Click(object sender, EventArgs e)
        {
            _filtroObra.TituloObra = null;
            _filtroObra.AutorObra = null;
            _filtroObra.FormatoObra = null;
            _filtroObra.ObraFoiFinalizada = null;
            textBoxTituloObra.Text = null;
            textBoxAutorObra.Text = null;
            comboBoxFormatoObra.SelectedItem = null;
            radioButtonStatusObraEmLancamento.Checked = false;
            radioButtonStatusObraFinalizada.Checked = false;
            _filtroObra.AnoDaPublicacao = null;
            textBoxAnoObra.Text = null;
            ListarObras();
        }
    }
}
