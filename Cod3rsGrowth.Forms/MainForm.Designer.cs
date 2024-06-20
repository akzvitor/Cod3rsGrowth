namespace Cod3rsGrowth.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            obraBindingSource = new BindingSource(components);
            dataGridObras = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tituloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            autorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            numeroCapitulosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorObraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            formatoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            foiFinalizadaDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            inicioPublicacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            tabPageObras = new TabPage();
            panelBottomObras = new Panel();
            panelObras = new Panel();
            buttonLimparObras = new Button();
            buttonFiltroObra = new Button();
            textBoxAnoObra = new TextBox();
            labelAnoObra = new Label();
            radioButtonStatusObraEmLancamento = new RadioButton();
            radioButtonStatusObraFinalizada = new RadioButton();
            labelStatus = new Label();
            labelFormatoObra = new Label();
            comboBoxFormatoObra = new ComboBox();
            textAutorObra = new TextBox();
            labelAutorObra = new Label();
            textBoxTituloObra = new TextBox();
            labelTituloObra = new Label();
            panelFiltroObras = new Panel();
            tabPageCompras = new TabPage();
            panelCompras = new Panel();
            dataGridCompras = new DataGridView();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            cpfDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorCompraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataCompraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            compraClienteBindingSource = new BindingSource(components);
            panel2BottomCompras = new Panel();
            panelFiltroCompras = new Panel();
            textBoxCpf = new TextBox();
            labelCpf = new Label();
            labelDataCompra = new Label();
            textBoxNomeCliente = new TextBox();
            buttonLimparCompras = new Button();
            buttonFiltrarCompras = new Button();
            labelNomeCliente = new Label();
            maskedTextBoxDataCompra = new MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)obraBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridObras).BeginInit();
            tabControl1.SuspendLayout();
            tabPageObras.SuspendLayout();
            panelObras.SuspendLayout();
            tabPageCompras.SuspendLayout();
            panelCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)compraClienteBindingSource).BeginInit();
            panelFiltroCompras.SuspendLayout();
            SuspendLayout();
            // 
            // obraBindingSource
            // 
            obraBindingSource.DataSource = typeof(Dominio.Entidades.Obra);
            // 
            // dataGridObras
            // 
            dataGridObras.AllowUserToAddRows = false;
            dataGridObras.AllowUserToDeleteRows = false;
            dataGridObras.AllowUserToResizeColumns = false;
            dataGridObras.AllowUserToResizeRows = false;
            dataGridObras.AutoGenerateColumns = false;
            dataGridObras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridObras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridObras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridObras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridObras.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tituloDataGridViewTextBoxColumn, autorDataGridViewTextBoxColumn, numeroCapitulosDataGridViewTextBoxColumn, valorObraDataGridViewTextBoxColumn, formatoDataGridViewTextBoxColumn, foiFinalizadaDataGridViewCheckBoxColumn, inicioPublicacaoDataGridViewTextBoxColumn });
            dataGridObras.DataSource = obraBindingSource;
            dataGridObras.Dock = DockStyle.Fill;
            dataGridObras.Location = new Point(3, 78);
            dataGridObras.Name = "dataGridObras";
            dataGridObras.ReadOnly = true;
            dataGridObras.RowTemplate.Height = 25;
            dataGridObras.Size = new Size(1027, 291);
            dataGridObras.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            idDataGridViewTextBoxColumn.FillWeight = 6.272095F;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            tituloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            tituloDataGridViewTextBoxColumn.FillWeight = 30.26575F;
            tituloDataGridViewTextBoxColumn.HeaderText = "Título";
            tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            tituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // autorDataGridViewTextBoxColumn
            // 
            autorDataGridViewTextBoxColumn.DataPropertyName = "Autor";
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            autorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            autorDataGridViewTextBoxColumn.FillWeight = 30.3542786F;
            autorDataGridViewTextBoxColumn.HeaderText = "Autor";
            autorDataGridViewTextBoxColumn.Name = "autorDataGridViewTextBoxColumn";
            autorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroCapitulosDataGridViewTextBoxColumn
            // 
            numeroCapitulosDataGridViewTextBoxColumn.DataPropertyName = "NumeroCapitulos";
            numeroCapitulosDataGridViewTextBoxColumn.FillWeight = 13.3542786F;
            numeroCapitulosDataGridViewTextBoxColumn.HeaderText = "Capítulos";
            numeroCapitulosDataGridViewTextBoxColumn.Name = "numeroCapitulosDataGridViewTextBoxColumn";
            numeroCapitulosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorObraDataGridViewTextBoxColumn
            // 
            valorObraDataGridViewTextBoxColumn.DataPropertyName = "ValorObra";
            dataGridViewCellStyle5.Padding = new Padding(10, 0, 0, 0);
            valorObraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            valorObraDataGridViewTextBoxColumn.FillWeight = 15.3542786F;
            valorObraDataGridViewTextBoxColumn.HeaderText = "Valor";
            valorObraDataGridViewTextBoxColumn.Name = "valorObraDataGridViewTextBoxColumn";
            valorObraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // formatoDataGridViewTextBoxColumn
            // 
            formatoDataGridViewTextBoxColumn.DataPropertyName = "Formato";
            formatoDataGridViewTextBoxColumn.FillWeight = 15.3542786F;
            formatoDataGridViewTextBoxColumn.HeaderText = "Formato";
            formatoDataGridViewTextBoxColumn.Name = "formatoDataGridViewTextBoxColumn";
            formatoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // foiFinalizadaDataGridViewCheckBoxColumn
            // 
            foiFinalizadaDataGridViewCheckBoxColumn.DataPropertyName = "FoiFinalizada";
            foiFinalizadaDataGridViewCheckBoxColumn.FillWeight = 15.3542786F;
            foiFinalizadaDataGridViewCheckBoxColumn.FlatStyle = FlatStyle.System;
            foiFinalizadaDataGridViewCheckBoxColumn.HeaderText = "Finalizada";
            foiFinalizadaDataGridViewCheckBoxColumn.Name = "foiFinalizadaDataGridViewCheckBoxColumn";
            foiFinalizadaDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // inicioPublicacaoDataGridViewTextBoxColumn
            // 
            inicioPublicacaoDataGridViewTextBoxColumn.DataPropertyName = "InicioPublicacao";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            inicioPublicacaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            inicioPublicacaoDataGridViewTextBoxColumn.FillWeight = 20.3542786F;
            inicioPublicacaoDataGridViewTextBoxColumn.HeaderText = "Início da Publicação";
            inicioPublicacaoDataGridViewTextBoxColumn.Name = "inicioPublicacaoDataGridViewTextBoxColumn";
            inicioPublicacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPageObras);
            tabControl1.Controls.Add(tabPageCompras);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1041, 456);
            tabControl1.TabIndex = 1;
            // 
            // tabPageObras
            // 
            tabPageObras.Controls.Add(dataGridObras);
            tabPageObras.Controls.Add(panelBottomObras);
            tabPageObras.Controls.Add(panelObras);
            tabPageObras.Controls.Add(panelFiltroObras);
            tabPageObras.Location = new Point(4, 24);
            tabPageObras.Name = "tabPageObras";
            tabPageObras.Padding = new Padding(3);
            tabPageObras.Size = new Size(1033, 428);
            tabPageObras.TabIndex = 0;
            tabPageObras.Text = "Obras";
            tabPageObras.UseVisualStyleBackColor = true;
            // 
            // panelBottomObras
            // 
            panelBottomObras.Dock = DockStyle.Bottom;
            panelBottomObras.Location = new Point(3, 369);
            panelBottomObras.Name = "panelBottomObras";
            panelBottomObras.Size = new Size(1027, 56);
            panelBottomObras.TabIndex = 0;
            // 
            // panelObras
            // 
            panelObras.Controls.Add(buttonLimparObras);
            panelObras.Controls.Add(buttonFiltroObra);
            panelObras.Controls.Add(textBoxAnoObra);
            panelObras.Controls.Add(labelAnoObra);
            panelObras.Controls.Add(radioButtonStatusObraEmLancamento);
            panelObras.Controls.Add(radioButtonStatusObraFinalizada);
            panelObras.Controls.Add(labelStatus);
            panelObras.Controls.Add(labelFormatoObra);
            panelObras.Controls.Add(comboBoxFormatoObra);
            panelObras.Controls.Add(textAutorObra);
            panelObras.Controls.Add(labelAutorObra);
            panelObras.Controls.Add(textBoxTituloObra);
            panelObras.Controls.Add(labelTituloObra);
            panelObras.Dock = DockStyle.Top;
            panelObras.Location = new Point(3, 3);
            panelObras.Name = "panelObras";
            panelObras.Size = new Size(1027, 75);
            panelObras.TabIndex = 2;
            // 
            // buttonLimparObras
            // 
            buttonLimparObras.Location = new Point(914, 35);
            buttonLimparObras.Name = "buttonLimparObras";
            buttonLimparObras.Size = new Size(75, 23);
            buttonLimparObras.TabIndex = 12;
            buttonLimparObras.Text = "Limpar";
            buttonLimparObras.UseVisualStyleBackColor = true;
            // 
            // buttonFiltroObra
            // 
            buttonFiltroObra.Location = new Point(833, 35);
            buttonFiltroObra.Name = "buttonFiltroObra";
            buttonFiltroObra.Size = new Size(75, 23);
            buttonFiltroObra.TabIndex = 11;
            buttonFiltroObra.Text = "Filtrar";
            buttonFiltroObra.UseVisualStyleBackColor = true;
            // 
            // textBoxAnoObra
            // 
            textBoxAnoObra.BackColor = SystemColors.Window;
            textBoxAnoObra.Cursor = Cursors.IBeam;
            textBoxAnoObra.Location = new Point(672, 35);
            textBoxAnoObra.Name = "textBoxAnoObra";
            textBoxAnoObra.PlaceholderText = "Pesquisar";
            textBoxAnoObra.Size = new Size(123, 23);
            textBoxAnoObra.TabIndex = 10;
            // 
            // labelAnoObra
            // 
            labelAnoObra.AutoSize = true;
            labelAnoObra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelAnoObra.Location = new Point(672, 11);
            labelAnoObra.Name = "labelAnoObra";
            labelAnoObra.Size = new Size(38, 21);
            labelAnoObra.TabIndex = 9;
            labelAnoObra.Text = "Ano";
            // 
            // radioButtonStatusObraEmLancamento
            // 
            radioButtonStatusObraEmLancamento.AutoSize = true;
            radioButtonStatusObraEmLancamento.Cursor = Cursors.Hand;
            radioButtonStatusObraEmLancamento.Location = new Point(451, 39);
            radioButtonStatusObraEmLancamento.Name = "radioButtonStatusObraEmLancamento";
            radioButtonStatusObraEmLancamento.Size = new Size(111, 19);
            radioButtonStatusObraEmLancamento.TabIndex = 8;
            radioButtonStatusObraEmLancamento.TabStop = true;
            radioButtonStatusObraEmLancamento.Text = "Em Lançamento";
            radioButtonStatusObraEmLancamento.UseVisualStyleBackColor = true;
            // 
            // radioButtonStatusObraFinalizada
            // 
            radioButtonStatusObraFinalizada.AutoSize = true;
            radioButtonStatusObraFinalizada.Cursor = Cursors.Hand;
            radioButtonStatusObraFinalizada.Location = new Point(568, 39);
            radioButtonStatusObraFinalizada.Name = "radioButtonStatusObraFinalizada";
            radioButtonStatusObraFinalizada.Size = new Size(77, 19);
            radioButtonStatusObraFinalizada.TabIndex = 7;
            radioButtonStatusObraFinalizada.TabStop = true;
            radioButtonStatusObraFinalizada.Text = "Finalizada";
            radioButtonStatusObraFinalizada.UseVisualStyleBackColor = true;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelStatus.Location = new Point(510, 11);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(52, 21);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Status";
            // 
            // labelFormatoObra
            // 
            labelFormatoObra.AutoSize = true;
            labelFormatoObra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelFormatoObra.Location = new Point(294, 11);
            labelFormatoObra.Name = "labelFormatoObra";
            labelFormatoObra.Size = new Size(69, 21);
            labelFormatoObra.TabIndex = 5;
            labelFormatoObra.Text = "Formato";
            // 
            // comboBoxFormatoObra
            // 
            comboBoxFormatoObra.FormattingEnabled = true;
            comboBoxFormatoObra.Items.AddRange(new object[] { "Manga", "Manhua", "Manhwa", "WebNovel" });
            comboBoxFormatoObra.Location = new Point(294, 35);
            comboBoxFormatoObra.Name = "comboBoxFormatoObra";
            comboBoxFormatoObra.Size = new Size(121, 23);
            comboBoxFormatoObra.TabIndex = 4;
            // 
            // textAutorObra
            // 
            textAutorObra.BackColor = SystemColors.Window;
            textAutorObra.Cursor = Cursors.IBeam;
            textAutorObra.Location = new Point(148, 35);
            textAutorObra.Name = "textAutorObra";
            textAutorObra.PlaceholderText = "Pesquisar";
            textAutorObra.Size = new Size(123, 23);
            textAutorObra.TabIndex = 3;
            // 
            // labelAutorObra
            // 
            labelAutorObra.AutoSize = true;
            labelAutorObra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelAutorObra.Location = new Point(148, 11);
            labelAutorObra.Name = "labelAutorObra";
            labelAutorObra.Size = new Size(49, 21);
            labelAutorObra.TabIndex = 2;
            labelAutorObra.Text = "Autor";
            // 
            // textBoxTituloObra
            // 
            textBoxTituloObra.BackColor = SystemColors.Window;
            textBoxTituloObra.Cursor = Cursors.IBeam;
            textBoxTituloObra.Location = new Point(5, 35);
            textBoxTituloObra.Name = "textBoxTituloObra";
            textBoxTituloObra.PlaceholderText = "Pesquisar";
            textBoxTituloObra.Size = new Size(123, 23);
            textBoxTituloObra.TabIndex = 1;
            // 
            // labelTituloObra
            // 
            labelTituloObra.AutoSize = true;
            labelTituloObra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTituloObra.Location = new Point(0, 11);
            labelTituloObra.Name = "labelTituloObra";
            labelTituloObra.Size = new Size(49, 21);
            labelTituloObra.TabIndex = 0;
            labelTituloObra.Text = "Título";
            // 
            // panelFiltroObras
            // 
            panelFiltroObras.Location = new Point(3, 3);
            panelFiltroObras.Name = "panelFiltroObras";
            panelFiltroObras.Size = new Size(1027, 87);
            panelFiltroObras.TabIndex = 1;
            // 
            // tabPageCompras
            // 
            tabPageCompras.Controls.Add(panelCompras);
            tabPageCompras.Controls.Add(panel2BottomCompras);
            tabPageCompras.Controls.Add(panelFiltroCompras);
            tabPageCompras.Location = new Point(4, 24);
            tabPageCompras.Name = "tabPageCompras";
            tabPageCompras.Padding = new Padding(3);
            tabPageCompras.Size = new Size(1033, 428);
            tabPageCompras.TabIndex = 1;
            tabPageCompras.Text = "Compras";
            tabPageCompras.UseVisualStyleBackColor = true;
            // 
            // panelCompras
            // 
            panelCompras.Controls.Add(dataGridCompras);
            panelCompras.Dock = DockStyle.Fill;
            panelCompras.Location = new Point(3, 81);
            panelCompras.Name = "panelCompras";
            panelCompras.Size = new Size(1027, 287);
            panelCompras.TabIndex = 2;
            // 
            // dataGridCompras
            // 
            dataGridCompras.AllowUserToAddRows = false;
            dataGridCompras.AllowUserToDeleteRows = false;
            dataGridCompras.AllowUserToResizeColumns = false;
            dataGridCompras.AllowUserToResizeRows = false;
            dataGridCompras.AutoGenerateColumns = false;
            dataGridCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridCompras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCompras.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, cpfDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, valorCompraDataGridViewTextBoxColumn, dataCompraDataGridViewTextBoxColumn });
            dataGridCompras.DataSource = compraClienteBindingSource;
            dataGridCompras.Dock = DockStyle.Fill;
            dataGridCompras.Location = new Point(0, 0);
            dataGridCompras.Name = "dataGridCompras";
            dataGridCompras.ReadOnly = true;
            dataGridCompras.RowTemplate.Height = 25;
            dataGridCompras.Size = new Size(1027, 287);
            dataGridCompras.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            idDataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle8;
            idDataGridViewTextBoxColumn1.FillWeight = 20F;
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cpfDataGridViewTextBoxColumn
            // 
            cpfDataGridViewTextBoxColumn.DataPropertyName = "Cpf";
            cpfDataGridViewTextBoxColumn.FillWeight = 60F;
            cpfDataGridViewTextBoxColumn.HeaderText = "CPF";
            cpfDataGridViewTextBoxColumn.Name = "cpfDataGridViewTextBoxColumn";
            cpfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            telefoneDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            telefoneDataGridViewTextBoxColumn.FillWeight = 60F;
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            telefoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "E-mail";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorCompraDataGridViewTextBoxColumn
            // 
            valorCompraDataGridViewTextBoxColumn.DataPropertyName = "ValorCompra";
            valorCompraDataGridViewTextBoxColumn.FillWeight = 40F;
            valorCompraDataGridViewTextBoxColumn.HeaderText = "Valor";
            valorCompraDataGridViewTextBoxColumn.Name = "valorCompraDataGridViewTextBoxColumn";
            valorCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataCompraDataGridViewTextBoxColumn
            // 
            dataCompraDataGridViewTextBoxColumn.DataPropertyName = "DataCompra";
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataCompraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            dataCompraDataGridViewTextBoxColumn.HeaderText = "Data da compra";
            dataCompraDataGridViewTextBoxColumn.Name = "dataCompraDataGridViewTextBoxColumn";
            dataCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // compraClienteBindingSource
            // 
            compraClienteBindingSource.DataSource = typeof(Dominio.Entidades.CompraCliente);
            // 
            // panel2BottomCompras
            // 
            panel2BottomCompras.Dock = DockStyle.Bottom;
            panel2BottomCompras.Location = new Point(3, 368);
            panel2BottomCompras.Name = "panel2BottomCompras";
            panel2BottomCompras.Size = new Size(1027, 57);
            panel2BottomCompras.TabIndex = 1;
            // 
            // panelFiltroCompras
            // 
            panelFiltroCompras.Controls.Add(maskedTextBoxDataCompra);
            panelFiltroCompras.Controls.Add(textBoxCpf);
            panelFiltroCompras.Controls.Add(labelCpf);
            panelFiltroCompras.Controls.Add(labelDataCompra);
            panelFiltroCompras.Controls.Add(textBoxNomeCliente);
            panelFiltroCompras.Controls.Add(buttonLimparCompras);
            panelFiltroCompras.Controls.Add(buttonFiltrarCompras);
            panelFiltroCompras.Controls.Add(labelNomeCliente);
            panelFiltroCompras.Dock = DockStyle.Top;
            panelFiltroCompras.Location = new Point(3, 3);
            panelFiltroCompras.Name = "panelFiltroCompras";
            panelFiltroCompras.Size = new Size(1027, 78);
            panelFiltroCompras.TabIndex = 0;
            // 
            // textBoxCpf
            // 
            textBoxCpf.Location = new Point(138, 38);
            textBoxCpf.Name = "textBoxCpf";
            textBoxCpf.PlaceholderText = "Pesquisar";
            textBoxCpf.Size = new Size(100, 23);
            textBoxCpf.TabIndex = 29;
            // 
            // labelCpf
            // 
            labelCpf.AutoSize = true;
            labelCpf.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCpf.Location = new Point(138, 13);
            labelCpf.Name = "labelCpf";
            labelCpf.Size = new Size(37, 21);
            labelCpf.TabIndex = 28;
            labelCpf.Text = "CPF";
            // 
            // labelDataCompra
            // 
            labelDataCompra.AutoSize = true;
            labelDataCompra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDataCompra.Location = new Point(275, 13);
            labelDataCompra.Name = "labelDataCompra";
            labelDataCompra.Size = new Size(42, 21);
            labelDataCompra.TabIndex = 27;
            labelDataCompra.Text = "Data";
            // 
            // textBoxNomeCliente
            // 
            textBoxNomeCliente.Location = new Point(3, 38);
            textBoxNomeCliente.Name = "textBoxNomeCliente";
            textBoxNomeCliente.PlaceholderText = "Pesquisar";
            textBoxNomeCliente.Size = new Size(100, 23);
            textBoxNomeCliente.TabIndex = 26;
            // 
            // buttonLimparCompras
            // 
            buttonLimparCompras.Location = new Point(914, 37);
            buttonLimparCompras.Name = "buttonLimparCompras";
            buttonLimparCompras.Size = new Size(75, 23);
            buttonLimparCompras.TabIndex = 25;
            buttonLimparCompras.Text = "Limpar";
            buttonLimparCompras.UseVisualStyleBackColor = true;
            // 
            // buttonFiltrarCompras
            // 
            buttonFiltrarCompras.Location = new Point(833, 37);
            buttonFiltrarCompras.Name = "buttonFiltrarCompras";
            buttonFiltrarCompras.Size = new Size(75, 23);
            buttonFiltrarCompras.TabIndex = 24;
            buttonFiltrarCompras.Text = "Filtrar";
            buttonFiltrarCompras.UseVisualStyleBackColor = true;
            // 
            // labelNomeCliente
            // 
            labelNomeCliente.AutoSize = true;
            labelNomeCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNomeCliente.Location = new Point(0, 13);
            labelNomeCliente.Name = "labelNomeCliente";
            labelNomeCliente.Size = new Size(53, 21);
            labelNomeCliente.TabIndex = 13;
            labelNomeCliente.Text = "Nome";
            // 
            // maskedTextBoxDataCompra
            // 
            maskedTextBoxDataCompra.Location = new Point(275, 38);
            maskedTextBoxDataCompra.Mask = "00/00/0000";
            maskedTextBoxDataCompra.Name = "maskedTextBoxDataCompra";
            maskedTextBoxDataCompra.Size = new Size(73, 23);
            maskedTextBoxDataCompra.TabIndex = 30;
            maskedTextBoxDataCompra.ValidatingType = typeof(DateTime);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 453);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Coders Growth";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)obraBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridObras).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageObras.ResumeLayout(false);
            panelObras.ResumeLayout(false);
            panelObras.PerformLayout();
            tabPageCompras.ResumeLayout(false);
            panelCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)compraClienteBindingSource).EndInit();
            panelFiltroCompras.ResumeLayout(false);
            panelFiltroCompras.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource obraBindingSource;
        private DataGridView dataGridObras;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn autorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numeroCapitulosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorObraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formatoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn foiFinalizadaDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn inicioPublicacaoDataGridViewTextBoxColumn;
        private TabControl tabControl1;
        private TabPage tabPageObras;
        private TabPage tabPageCompras;
        private Panel panelObras;
        private Panel panelBottomObras;
        private Panel panelFiltroObras;
        private DataGridView dataGridCompras;
        private BindingSource compraClienteBindingSource;
        private Panel panelCompras;
        private Panel panel2BottomCompras;
        private Panel panelFiltroCompras;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cpfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataCompraDataGridViewTextBoxColumn;
        private Label labelTituloObra;
        private TextBox textBoxTituloObra;
        private TextBox textAutorObra;
        private Label labelAutorObra;
        private ComboBox comboBoxFormatoObra;
        private Label labelFormatoObra;
        private RadioButton radioButtonStatusObraFinalizada;
        private Label labelStatus;
        private RadioButton radioButtonStatusObraEmLancamento;
        private TextBox textBoxAnoObra;
        private Label labelAnoObra;
        private Button buttonLimparObras;
        private Button buttonFiltroObra;
        private Button buttonLimparCompras;
        private Button buttonFiltrarCompras;
        private Label label1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label2;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
        private Label labelNomeCliente;
        private Label labelCpf;
        private Label labelDataCompra;
        private TextBox textBoxNomeCliente;
        private TextBox textBoxCpf;
        private MaskedTextBox maskedTextBoxDataCompra;
    }
}
