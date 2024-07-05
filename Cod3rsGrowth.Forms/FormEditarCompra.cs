using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormEditarCompra : Form
    {
        private readonly ServicoCompraCliente _servicoCompraCliente;
        private readonly ServicoObra _servicoObra;
        private readonly CompraCliente _compraASerEditada = new();
        private readonly FiltroObra _filtroObra = new();

        public FormEditarCompra(ServicoCompraCliente servicoCompraCliente, ServicoObra servicoObra, CompraCliente compraASerEditada)
        {
            _servicoCompraCliente = servicoCompraCliente;
            _servicoObra = servicoObra;
            _compraASerEditada = compraASerEditada;
            InitializeComponent();
        }

        private void AoInicializarFormulario(object sender, EventArgs e)
        {
            try
            {
                InicializarCatalogo();
                InicializarProdutosSelecionadosNoCatalogo();
                InicializarCamposDeDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InicializarCatalogo()
        {
            dataGridViewCatalogoObras.DataSource = _servicoObra.ObterTodos(_filtroObra);
        }

        private void InicializarProdutosSelecionadosNoCatalogo()
        {
            List<int> produtosSelecionados = _servicoCompraCliente.ObterProdutosVinculados(_compraASerEditada.Id);

            foreach (DataGridViewRow linha in dataGridViewCatalogoObras.Rows)
            {
                if (produtosSelecionados.Contains(Convert.ToInt32(linha.Cells["colunaId"].Value)))
                {
                    linha.Cells["colunaSelecao"].Value = true;
                }
            }
        }

        private void InicializarCamposDeDados()
        {
            textBoxNome.Text = _compraASerEditada.Nome;
            textBoxEmail.Text = _compraASerEditada.Email;
            maskedTextBoxCpf.Text = _compraASerEditada.Cpf;
            maskedTextBoxTelefone.Text = _compraASerEditada.Telefone;

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
                List<int> produtosSelecionados = ObterIdDosProdutosSelecionados();

                _compraASerEditada.Cpf = maskedTextBoxCpf.Text.Trim().Replace(".", "").Replace("-", "");
                _compraASerEditada.Nome = textBoxNome.Text;
                _compraASerEditada.Telefone = maskedTextBoxTelefone.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", "");
                _compraASerEditada.ValorCompra = decimal.Parse(textBoxValorCompra.Text);
                _compraASerEditada.Email = textBoxEmail.Text;
                _compraASerEditada.listaIdDosProdutos = produtosSelecionados;

                DialogResult dialogResult = MessageBox.Show("Deseja salvar a compra com os dados informados?",
                                                            "Salvar Compra", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _servicoCompraCliente.Editar(_compraASerEditada);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<int> ObterIdDosProdutosSelecionados()
        {
            List<int> produtosSelecionados = new();
            decimal valorDosProdutosSelecionados = 0;

            foreach (DataGridViewRow linha in dataGridViewCatalogoObras.Rows)
            {
                if (Convert.ToBoolean(linha.Cells["colunaSelecao"].Value))
                {
                    int produtoId = Convert.ToInt32(linha.Cells["colunaId"].Value);
                    produtosSelecionados.Add(produtoId);
                    valorDosProdutosSelecionados += Convert.ToDecimal(linha.Cells["ValorObra"].Value);
                }
            }

            textBoxValorCompra.Text = valorDosProdutosSelecionados.ToString();

            return produtosSelecionados;
        }
    }
}
