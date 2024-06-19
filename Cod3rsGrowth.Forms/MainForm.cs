using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms
{
    public partial class MainForm : Form
    {
        private readonly ServicoObra _servicoObra;
        public MainForm(ServicoObra servicoObra)
        {
            _servicoObra = servicoObra;
            InitializeComponent();
        }

        private void InicializarBancoDeDados()
        {
            FiltroObra filtro = new();
            dataGridView1.DataSource = _servicoObra.ObterTodos(filtro);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            InicializarBancoDeDados();
        }
    }
}
