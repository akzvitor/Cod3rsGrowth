using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using FluentValidation;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarCompra : Form
    {
        private readonly ServicoCompraCliente _servicoCompraCliente;
        private readonly ServicoObra _servicoObra;
        private readonly FiltroObra _filtroObra = new();

        public FormCriarCompra(ServicoCompraCliente servicoCompraCliente, ServicoObra servicoObra)
        {
            _servicoCompraCliente = servicoCompraCliente;
            _servicoObra = servicoObra;
            InitializeComponent();
        }

        private void AoInicializarFormulario(object sender, EventArgs e)
        {
            try
            {
                CarregarDataSourceCatalogoObras();
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
                List<int> produtosSelecionados = ObterProdutosSelecionados();

                CompraCliente novaCompra = new()
                {
                    Cpf = maskedTextBoxCpf.Text.Trim().Replace(".", "").Replace("-", ""),
                    Nome = textBoxNome.Text,
                    Telefone = maskedTextBoxTelefone.Text.Trim().Replace("(", "").Replace(")", "").Replace("-", ""),
                    ValorCompra = decimal.Parse(textBoxValorCompra.Text),
                    Email = textBoxEmail.Text,
                    DataCompra = DateTime.Now,
                    listaIdDosProdutos = produtosSelecionados
                };

                DialogResult dialogResult = MessageBox.Show("Deseja salvar a compra com os dados informados?\n\n" +
                                                            $"Valor total: R${novaCompra.ValorCompra}",
                                                            "Salvar Compra", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    _servicoCompraCliente.Criar(novaCompra);
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

        private List<int> ObterProdutosSelecionados()
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

        private void CarregarDataSourceCatalogoObras()
        {
            dataGridViewCatalogoObras.DataSource = _servicoObra.ObterTodos(_filtroObra);
        }
    }
}
