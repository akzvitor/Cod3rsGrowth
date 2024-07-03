using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using Cod3rsGrowth.Dominio.Enums;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagem : Form
    {
        private readonly ServicoObra _servicoObra;
        private readonly ServicoCompraCliente _servicoCompraCliente;
        private readonly FiltroObra _filtroObra = new();
        private readonly FiltroCompraCliente _filtroCompraCliente = new();
        const int dataGridVazio = -1;
        public FormListagem(ServicoObra servicoObra, ServicoCompraCliente servicoCompraCliente)
        {
            _servicoObra = servicoObra;
            _servicoCompraCliente = servicoCompraCliente;
            InitializeComponent();
        }

        private void ListarObras()
        {
            dataGridObras.DataSource = _servicoObra.ObterTodos(_filtroObra);
        }

        private void ListarCompras()
        {
            dataGridCompras.DataSource = _servicoCompraCliente.ObterTodos(_filtroCompraCliente);
        }

        private void InicializarValoresComboBox()
        {
            comboBoxFormatoObra.DataSource = Enum.GetValues(typeof(Formato));
        }

        private void LimparComboBox()
        {
            comboBoxFormatoObra.SelectedItem = null;
        }

        private void AoCarregarFormulario(object sender, EventArgs e)
        {
            try
            {
                ListarObras();
                ListarCompras();
                InicializarValoresComboBox();
                LimparComboBox();
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
                _filtroCompraCliente.Cpf = maskedTextBoxCpf.Text.Trim().Replace(".", "").Replace("-", "");
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
                maskedTextBoxCpf.Text = null;
                _filtroCompraCliente.DataCompra = DateTime.MinValue;
                dateTimePickerDataCompra.Value = DateTime.Parse("Jul 22, 2002");

                ListarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoAdicionarDaAbaObras(object sender, EventArgs e)
        {
            try
            {
                var formCriarObra = new FormCriarObra(_servicoObra);
                formCriarObra.ShowDialog();
                ListarObras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoAdicionarDaAbaCompras(object sender, EventArgs e)
        {
            try
            {
                var formCriarCompra = new FormCriarCompra(_servicoCompraCliente, _servicoObra);
                formCriarCompra.ShowDialog();
                ListarCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoRemoverDaAbaObras(object sender, EventArgs e)
        {
            try
            {
                const string colunaIdObra = "colunaIdObras";
                var idDaObraSelecionada = ObterIdDoObjetoSelecionado(colunaIdObra, dataGridObras);

                if (idDaObraSelecionada == dataGridVazio)
                {
                    MessageBox.Show("N�o foi poss�vel remover, n�o h� obras cadastradas.", "Lista de obras vazia");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Tem certeza que deseja remover" +
                                                            $" a obra de ID {idDaObraSelecionada}?",
                                                            "Remover Obra", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    _servicoObra.Remover(idDaObraSelecionada);
                    ListarObras();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoRemoverDaAbaCompras(object sender, EventArgs e)
        {
            try
            {
                const string nomeColunaIdCompras = "colunaIdCompras";
                var idDaCompraSelecionada = ObterIdDoObjetoSelecionado(nomeColunaIdCompras, dataGridCompras);

                if (idDaCompraSelecionada == dataGridVazio)
                {
                    MessageBox.Show("N�o foi poss�vel remover, n�o h� compras cadastradas.", "Lista de compras vazia.");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Tem certeza que deseja remover " +
                                                            $"a compra de ID {idDaCompraSelecionada}?",
                                                             "Remover Compra", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    _servicoCompraCliente.Remover(idDaCompraSelecionada);
                    ListarCompras();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoEditarDaAbaObras(object sender, EventArgs e)
        {
            try
            {
                const string colunaIdObra = "colunaIdObras";
                var idDaObraSelecionada = ObterIdDoObjetoSelecionado(colunaIdObra, dataGridObras);

                if (idDaObraSelecionada == dataGridVazio)
                {
                    MessageBox.Show("N�o foi poss�vel editar, n�o h� obras cadastradas.", "Lista de obras vazia");
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"Tem certeza que deseja editar os dados " +
                                                            $"da obra de ID {idDaObraSelecionada}?",
                                                            "Editar Obra", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var obraASerEditada = _servicoObra.ObterPorId(idDaObraSelecionada);
                    var formEditarObra = new FormEditarObra(_servicoObra, obraASerEditada);
                    formEditarObra.ShowDialog();
                    ListarObras();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AoClicarNoBotaoEditarDaAbaCompras(object sender, EventArgs e)
        {
            const string colunaIdCompra = "colunaIdCompras";
            var idDaCompraSelecionada = ObterIdDoObjetoSelecionado(colunaIdCompra, dataGridCompras);

            if (idDaCompraSelecionada == dataGridVazio)
            {
                MessageBox.Show("N�o foi poss�vel editar, n�o h� compras cadastradas.", "Lista de compras vazia");
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Tem certeza que deseja editar os dados " +
                                                        $"da compra de ID {idDaCompraSelecionada}?",
                                                        "Editar Compra", MessageBoxButtons.YesNo);

            if (dialogResult == DialogResult.Yes)
            {
                var compraASerEditada = _servicoCompraCliente.ObterPorId(idDaCompraSelecionada);
                var formEditarCompra = new FormEditarCompra(_servicoCompraCliente, _servicoObra, compraASerEditada);
                formEditarCompra.ShowDialog();
                ListarCompras();
            }
        }

        private static int ObterIdDoObjetoSelecionado(string nomeColuna, DataGridView dataGrid)
        {
            if (dataGrid.CurrentCell == null)
            {
                return dataGridVazio;
            }

            var linhaSelecionada = dataGrid.CurrentCell.RowIndex;
            var idDoObjetoSelecionado = Convert.ToInt32(dataGrid.Rows[linhaSelecionada].Cells[nomeColuna].Value);

            return idDoObjetoSelecionado;
        }
    }
}