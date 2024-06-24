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
            groupBox1 = new GroupBox();
            panelBottomObras = new Panel();
            panelFiltroObras = new Panel();
            buttonLimparObras = new Button();
            textBoxAnoObra = new TextBox();
            buttonFiltroObra = new Button();
            labelAnoObra = new Label();
            radioButtonStatusObraEmLancamento = new RadioButton();
            radioButtonStatusObraFinalizada = new RadioButton();
            labelStatus = new Label();
            labelFormatoObra = new Label();
            comboBoxFormatoObra = new ComboBox();
            textBoxAutorObra = new TextBox();
            labelAutorObra = new Label();
            textBoxTituloObra = new TextBox();
            labelTituloObra = new Label();
            tabPageCompras = new TabPage();
            groupBoxCompras = new GroupBox();
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
            dateTimePickerDataCompra = new DateTimePicker();
            textBoxCpf = new TextBox();
            labelCpf = new Label();
            labelDataCompra = new Label();
            textBoxNomeCliente = new TextBox();
            buttonLimparCompras = new Button();
            buttonFiltrarCompras = new Button();
            labelNomeCliente = new Label();
            obraBindingSource1 = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)obraBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridObras).BeginInit();
            tabControl1.SuspendLayout();
            tabPageObras.SuspendLayout();
            groupBox1.SuspendLayout();
            panelFiltroObras.SuspendLayout();
            tabPageCompras.SuspendLayout();
            groupBoxCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)compraClienteBindingSource).BeginInit();
            panelFiltroCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)obraBindingSource1).BeginInit();
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
            dataGridObras.Location = new Point(3, 19);
            dataGridObras.Name = "dataGridObras";
            dataGridObras.ReadOnly = true;
            dataGridObras.RowTemplate.Height = 25;
            dataGridObras.Size = new Size(983, 255);
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
            tabControl1.Size = new Size(1016, 456);
            tabControl1.TabIndex = 1;
            // 
            // tabPageObras
            // 
            tabPageObras.Controls.Add(groupBox1);
            tabPageObras.Controls.Add(panelBottomObras);
            tabPageObras.Controls.Add(panelFiltroObras);
            tabPageObras.Location = new Point(4, 24);
            tabPageObras.Name = "tabPageObras";
            tabPageObras.Padding = new Padding(3);
            tabPageObras.Size = new Size(1008, 428);
            tabPageObras.TabIndex = 0;
            tabPageObras.Text = "Obras";
            tabPageObras.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(dataGridObras);
            groupBox1.Location = new Point(8, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(989, 277);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // panelBottomObras
            // 
            panelBottomObras.Dock = DockStyle.Bottom;
            panelBottomObras.Location = new Point(3, 389);
            panelBottomObras.Name = "panelBottomObras";
            panelBottomObras.Size = new Size(1002, 36);
            panelBottomObras.TabIndex = 0;
            // 
            // panelFiltroObras
            // 
            panelFiltroObras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFiltroObras.Controls.Add(buttonLimparObras);
            panelFiltroObras.Controls.Add(textBoxAnoObra);
            panelFiltroObras.Controls.Add(buttonFiltroObra);
            panelFiltroObras.Controls.Add(labelAnoObra);
            panelFiltroObras.Controls.Add(radioButtonStatusObraEmLancamento);
            panelFiltroObras.Controls.Add(radioButtonStatusObraFinalizada);
            panelFiltroObras.Controls.Add(labelStatus);
            panelFiltroObras.Controls.Add(labelFormatoObra);
            panelFiltroObras.Controls.Add(comboBoxFormatoObra);
            panelFiltroObras.Controls.Add(textBoxAutorObra);
            panelFiltroObras.Controls.Add(labelAutorObra);
            panelFiltroObras.Controls.Add(textBoxTituloObra);
            panelFiltroObras.Controls.Add(labelTituloObra);
            panelFiltroObras.Location = new Point(-18, 6);
            panelFiltroObras.Name = "panelFiltroObras";
            panelFiltroObras.Size = new Size(1041, 94);
            panelFiltroObras.TabIndex = 2;
            // 
            // buttonLimparObras
            // 
            buttonLimparObras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLimparObras.Location = new Point(937, 37);
            buttonLimparObras.Name = "buttonLimparObras";
            buttonLimparObras.Size = new Size(75, 23);
            buttonLimparObras.TabIndex = 12;
            buttonLimparObras.Text = "Limpar";
            buttonLimparObras.UseVisualStyleBackColor = true;
            buttonLimparObras.Click += AoClicarNoBotaoLimparDaAbaObras;
            // 
            // textBoxAnoObra
            // 
            textBoxAnoObra.BackColor = SystemColors.Window;
            textBoxAnoObra.Cursor = Cursors.IBeam;
            textBoxAnoObra.Location = new Point(689, 37);
            textBoxAnoObra.MaxLength = 4;
            textBoxAnoObra.Name = "textBoxAnoObra";
            textBoxAnoObra.PlaceholderText = "Pesquisar";
            textBoxAnoObra.Size = new Size(123, 23);
            textBoxAnoObra.TabIndex = 10;
            // 
            // buttonFiltroObra
            // 
            buttonFiltroObra.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonFiltroObra.Location = new Point(856, 37);
            buttonFiltroObra.Name = "buttonFiltroObra";
            buttonFiltroObra.Size = new Size(75, 23);
            buttonFiltroObra.TabIndex = 11;
            buttonFiltroObra.Text = "Filtrar";
            buttonFiltroObra.UseVisualStyleBackColor = true;
            buttonFiltroObra.Click += AoClicarNoBotaoFiltrarDaAbaObras;
            // 
            // labelAnoObra
            // 
            labelAnoObra.AutoSize = true;
            labelAnoObra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelAnoObra.Location = new Point(689, 13);
            labelAnoObra.Name = "labelAnoObra";
            labelAnoObra.Size = new Size(38, 21);
            labelAnoObra.TabIndex = 9;
            labelAnoObra.Text = "Ano";
            // 
            // radioButtonStatusObraEmLancamento
            // 
            radioButtonStatusObraEmLancamento.AutoSize = true;
            radioButtonStatusObraEmLancamento.Cursor = Cursors.Hand;
            radioButtonStatusObraEmLancamento.Location = new Point(472, 41);
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
            radioButtonStatusObraFinalizada.Location = new Point(589, 41);
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
            labelStatus.Location = new Point(531, 13);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(52, 21);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Status";
            // 
            // labelFormatoObra
            // 
            labelFormatoObra.AutoSize = true;
            labelFormatoObra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelFormatoObra.Location = new Point(322, 13);
            labelFormatoObra.Name = "labelFormatoObra";
            labelFormatoObra.Size = new Size(69, 21);
            labelFormatoObra.TabIndex = 5;
            labelFormatoObra.Text = "Formato";
            // 
            // comboBoxFormatoObra
            // 
            comboBoxFormatoObra.FormattingEnabled = true;
            comboBoxFormatoObra.Location = new Point(322, 37);
            comboBoxFormatoObra.Name = "comboBoxFormatoObra";
            comboBoxFormatoObra.Size = new Size(121, 23);
            comboBoxFormatoObra.TabIndex = 4;
            // 
            // textBoxAutorObra
            // 
            textBoxAutorObra.BackColor = SystemColors.Window;
            textBoxAutorObra.Cursor = Cursors.IBeam;
            textBoxAutorObra.Location = new Point(176, 37);
            textBoxAutorObra.Name = "textBoxAutorObra";
            textBoxAutorObra.PlaceholderText = "Pesquisar";
            textBoxAutorObra.Size = new Size(123, 23);
            textBoxAutorObra.TabIndex = 3;
            // 
            // labelAutorObra
            // 
            labelAutorObra.AutoSize = true;
            labelAutorObra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelAutorObra.Location = new Point(176, 13);
            labelAutorObra.Name = "labelAutorObra";
            labelAutorObra.Size = new Size(49, 21);
            labelAutorObra.TabIndex = 2;
            labelAutorObra.Text = "Autor";
            // 
            // textBoxTituloObra
            // 
            textBoxTituloObra.BackColor = SystemColors.Window;
            textBoxTituloObra.Cursor = Cursors.IBeam;
            textBoxTituloObra.Location = new Point(29, 37);
            textBoxTituloObra.Name = "textBoxTituloObra";
            textBoxTituloObra.PlaceholderText = "Pesquisar";
            textBoxTituloObra.Size = new Size(123, 23);
            textBoxTituloObra.TabIndex = 1;
            // 
            // labelTituloObra
            // 
            labelTituloObra.AutoSize = true;
            labelTituloObra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelTituloObra.Location = new Point(26, 13);
            labelTituloObra.Name = "labelTituloObra";
            labelTituloObra.Size = new Size(49, 21);
            labelTituloObra.TabIndex = 0;
            labelTituloObra.Text = "Título";
            // 
            // tabPageCompras
            // 
            tabPageCompras.Controls.Add(groupBoxCompras);
            tabPageCompras.Controls.Add(panel2BottomCompras);
            tabPageCompras.Controls.Add(panelFiltroCompras);
            tabPageCompras.Location = new Point(4, 24);
            tabPageCompras.Name = "tabPageCompras";
            tabPageCompras.Padding = new Padding(3);
            tabPageCompras.Size = new Size(1008, 428);
            tabPageCompras.TabIndex = 1;
            tabPageCompras.Text = "Compras";
            tabPageCompras.UseVisualStyleBackColor = true;
            // 
            // groupBoxCompras
            // 
            groupBoxCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBoxCompras.Controls.Add(dataGridCompras);
            groupBoxCompras.Location = new Point(8, 106);
            groupBoxCompras.Name = "groupBoxCompras";
            groupBoxCompras.Size = new Size(989, 276);
            groupBoxCompras.TabIndex = 4;
            groupBoxCompras.TabStop = false;
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
            dataGridCompras.Location = new Point(3, 19);
            dataGridCompras.Name = "dataGridCompras";
            dataGridCompras.ReadOnly = true;
            dataGridCompras.RowTemplate.Height = 25;
            dataGridCompras.Size = new Size(983, 254);
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
            panel2BottomCompras.Location = new Point(3, 388);
            panel2BottomCompras.Name = "panel2BottomCompras";
            panel2BottomCompras.Size = new Size(1002, 37);
            panel2BottomCompras.TabIndex = 1;
            // 
            // panelFiltroCompras
            // 
            panelFiltroCompras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelFiltroCompras.Controls.Add(dateTimePickerDataCompra);
            panelFiltroCompras.Controls.Add(textBoxCpf);
            panelFiltroCompras.Controls.Add(labelCpf);
            panelFiltroCompras.Controls.Add(labelDataCompra);
            panelFiltroCompras.Controls.Add(textBoxNomeCliente);
            panelFiltroCompras.Controls.Add(buttonLimparCompras);
            panelFiltroCompras.Controls.Add(buttonFiltrarCompras);
            panelFiltroCompras.Controls.Add(labelNomeCliente);
            panelFiltroCompras.Location = new Point(-4, 6);
            panelFiltroCompras.Name = "panelFiltroCompras";
            panelFiltroCompras.Size = new Size(1027, 94);
            panelFiltroCompras.TabIndex = 0;
            // 
            // dateTimePickerDataCompra
            // 
            dateTimePickerDataCompra.Format = DateTimePickerFormat.Short;
            dateTimePickerDataCompra.Location = new Point(287, 36);
            dateTimePickerDataCompra.Name = "dateTimePickerDataCompra";
            dateTimePickerDataCompra.Size = new Size(120, 23);
            dateTimePickerDataCompra.TabIndex = 30;
            dateTimePickerDataCompra.Value = new DateTime(2002, 7, 22, 0, 0, 0, 0);
            // 
            // textBoxCpf
            // 
            textBoxCpf.Location = new Point(150, 36);
            textBoxCpf.Name = "textBoxCpf";
            textBoxCpf.PlaceholderText = "Pesquisar";
            textBoxCpf.Size = new Size(100, 23);
            textBoxCpf.TabIndex = 29;
            // 
            // labelCpf
            // 
            labelCpf.AutoSize = true;
            labelCpf.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCpf.Location = new Point(150, 11);
            labelCpf.Name = "labelCpf";
            labelCpf.Size = new Size(37, 21);
            labelCpf.TabIndex = 28;
            labelCpf.Text = "CPF";
            // 
            // labelDataCompra
            // 
            labelDataCompra.AutoSize = true;
            labelDataCompra.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelDataCompra.Location = new Point(287, 11);
            labelDataCompra.Name = "labelDataCompra";
            labelDataCompra.Size = new Size(120, 21);
            labelDataCompra.TabIndex = 27;
            labelDataCompra.Text = "Data da compra";
            // 
            // textBoxNomeCliente
            // 
            textBoxNomeCliente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            textBoxNomeCliente.Location = new Point(15, 36);
            textBoxNomeCliente.Name = "textBoxNomeCliente";
            textBoxNomeCliente.PlaceholderText = "Pesquisar";
            textBoxNomeCliente.Size = new Size(100, 23);
            textBoxNomeCliente.TabIndex = 26;
            // 
            // buttonLimparCompras
            // 
            buttonLimparCompras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonLimparCompras.Location = new Point(926, 36);
            buttonLimparCompras.Name = "buttonLimparCompras";
            buttonLimparCompras.Size = new Size(75, 23);
            buttonLimparCompras.TabIndex = 25;
            buttonLimparCompras.Text = "Limpar";
            buttonLimparCompras.UseVisualStyleBackColor = true;
            buttonLimparCompras.Click += AoClicarNoBotaoLimparDaAbaCompras;
            // 
            // buttonFiltrarCompras
            // 
            buttonFiltrarCompras.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonFiltrarCompras.Location = new Point(845, 36);
            buttonFiltrarCompras.Name = "buttonFiltrarCompras";
            buttonFiltrarCompras.Size = new Size(75, 23);
            buttonFiltrarCompras.TabIndex = 24;
            buttonFiltrarCompras.Text = "Filtrar";
            buttonFiltrarCompras.UseVisualStyleBackColor = true;
            buttonFiltrarCompras.Click += AoClicarNoBotaoFiltrarDaAbaCompras;
            // 
            // labelNomeCliente
            // 
            labelNomeCliente.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            labelNomeCliente.AutoSize = true;
            labelNomeCliente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelNomeCliente.Location = new Point(12, 11);
            labelNomeCliente.Name = "labelNomeCliente";
            labelNomeCliente.Size = new Size(53, 21);
            labelNomeCliente.TabIndex = 13;
            labelNomeCliente.Text = "Nome";
            // 
            // obraBindingSource1
            // 
            obraBindingSource1.DataSource = typeof(Dominio.Entidades.Obra);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1013, 453);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Coders Growth";
            Load += AoCarregarFormulario;
            ((System.ComponentModel.ISupportInitialize)obraBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridObras).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageObras.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panelFiltroObras.ResumeLayout(false);
            panelFiltroObras.PerformLayout();
            tabPageCompras.ResumeLayout(false);
            groupBoxCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)compraClienteBindingSource).EndInit();
            panelFiltroCompras.ResumeLayout(false);
            panelFiltroCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)obraBindingSource1).EndInit();
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
        private Panel panelBottomObras;
        private Panel panelFiltroObras;
        private BindingSource compraClienteBindingSource;
        private Panel panel2BottomCompras;
        private Panel panelFiltroCompras;
        private Label labelTituloObra;
        private TextBox textBoxTituloObra;
        private TextBox textBoxAutorObra;
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
        private BindingSource obraBindingSource1;
        private GroupBox groupBox1;
        private DataGridView dataGridCompras;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn cpfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataCompraDataGridViewTextBoxColumn;
        private GroupBox groupBoxCompras;
        private DateTimePicker dateTimePickerDataCompra;
    }
}
