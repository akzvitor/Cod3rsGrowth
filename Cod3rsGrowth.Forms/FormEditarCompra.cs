using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servico.Servicos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void InicializarCamposDeDados()
        {
            textBoxNome.Text = _compraASerEditada.Nome;
            textBoxEmail.Text = _compraASerEditada.Email;
            maskedTextBoxCpf.Text = _compraASerEditada.Cpf;
            maskedTextBoxTelefone.Text = _compraASerEditada.Telefone;
        }

        private void InicializarCatalogo()
        {
            dataGridViewCatalogoObras.DataSource = _servicoObra.ObterTodos(_filtroObra);
        }

        private void AoInicializarFormulario(object sender, EventArgs e)
        {
            try
            {
                InicializarCatalogo();
                InicializarCamposDeDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
