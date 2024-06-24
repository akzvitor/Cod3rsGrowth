using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Dominio.Enums;


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

        //Adicionar try catch em todos os eventos
        //Renomear todos os eventos

        private void AoCarregarFormulario(object sender, EventArgs e)
        {
            try
            {
                ListarObras();
                ListarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoFiltrarDaAbaObras(object sender, EventArgs e)
        {
            try
            {
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

                _filtroObra.TituloObra = textBoxTituloObra.Text;
                _filtroObra.AutorObra = textBoxAutorObra.Text;
                _filtroObra.FormatoObra = (Formato?)comboBoxFormatoObra.SelectedItem;
                _filtroObra.AnoDaPublicacao = textBoxAnoObra.Text;

                ListarObras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoLimparDaAbaObras(object sender, EventArgs e)
        {
            try
            {
                _filtroObra.TituloObra = null;
                textBoxTituloObra.Text = null;
                _filtroObra.AutorObra = null;
                textBoxAutorObra.Text = null;
                _filtroObra.FormatoObra = null;
                comboBoxFormatoObra.SelectedItem = null;
                _filtroObra.ObraFoiFinalizada = null;
                radioButtonStatusObraEmLancamento.Checked = false;
                radioButtonStatusObraFinalizada.Checked = false;
                _filtroObra.AnoDaPublicacao = null;
                textBoxAnoObra.Text = null;

                ListarObras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoFiltrarDaAbaCompras(object sender, EventArgs e)
        {
            try
            {
                _filtroCompraCliente.NomeCliente = textBoxNomeCliente.Text;
                _filtroCompraCliente.Cpf = textBoxCpf.Text;
                if (dateTimePickerDataCompra.Value != DateTime.Parse("Jul 22, 2002"))
                {
                    _filtroCompraCliente.DataCompra = dateTimePickerDataCompra.Value;
                }

                ListarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoLimparDaAbaCompras(object sender, EventArgs e)
        {
            try
            { 
                _filtroCompraCliente.NomeCliente = null;
                textBoxNomeCliente.Text = null;
                _filtroCompraCliente.Cpf = null;
                textBoxCpf.Text = null;
                _filtroCompraCliente.DataCompra = DateTime.MinValue;
                dateTimePickerDataCompra.Value = DateTime.Parse("Jul 22, 2002");

                ListarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
