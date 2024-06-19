using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using System.Drawing.Text;

namespace Cod3rsGrowth.Forms
{
    public partial class ListaDeObras : Form
    {
        private readonly ServicoObra _servicoObra;
        public ListaDeObras(ServicoObra servicoObra)
        {
            _servicoObra = servicoObra;
            InitializeComponent();
            InicializarBancoDeDados();
        }

        private void InicializarBancoDeDados()
        {
            FiltroObra filtro = new();
            dataGridView1.DataSource = _servicoObra.ObterTodos(filtro);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ListaDeObras_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
