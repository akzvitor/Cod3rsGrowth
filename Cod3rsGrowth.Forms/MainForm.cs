using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using System.ComponentModel;

namespace Cod3rsGrowth.Forms
{
    public partial class MainForm : Form
    {
        private readonly ServicoObra _servicoObra;
        private readonly ServicoCompraCliente _servicoCompraCliente;

        public MainForm(ServicoObra servicoObra, ServicoCompraCliente servicoCompraCliente)
        {
            _servicoObra = servicoObra;
            _servicoCompraCliente = servicoCompraCliente;
            InitializeComponent();
        }

        private void ListarObras()
        {
            FiltroObra filtro = new FiltroObra();
            dataGridObras.DataSource = _servicoObra.ObterTodos(filtro);
        }

        private void ListarCompras()
        {
            FiltroCompraCliente filtro = new();
            dataGridCompras.DataSource = _servicoCompraCliente.ObterTodos(filtro);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ListarObras();
            ListarCompras();
        }
    }
}
