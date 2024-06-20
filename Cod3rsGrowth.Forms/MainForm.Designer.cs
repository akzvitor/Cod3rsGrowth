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
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)obraBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridObras).BeginInit();
            tabControl1.SuspendLayout();
            tabPageObras.SuspendLayout();
            tabPageCompras.SuspendLayout();
            panelCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridCompras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)compraClienteBindingSource).BeginInit();
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
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridObras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridObras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridObras.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tituloDataGridViewTextBoxColumn, autorDataGridViewTextBoxColumn, numeroCapitulosDataGridViewTextBoxColumn, valorObraDataGridViewTextBoxColumn, formatoDataGridViewTextBoxColumn, foiFinalizadaDataGridViewCheckBoxColumn, inicioPublicacaoDataGridViewTextBoxColumn });
            dataGridObras.DataSource = obraBindingSource;
            dataGridObras.Dock = DockStyle.Fill;
            dataGridObras.Location = new Point(3, 90);
            dataGridObras.Name = "dataGridObras";
            dataGridObras.ReadOnly = true;
            dataGridObras.RowTemplate.Height = 25;
            dataGridObras.Size = new Size(1027, 254);
            dataGridObras.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            idDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            idDataGridViewTextBoxColumn.FillWeight = 6.272095F;
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tituloDataGridViewTextBoxColumn
            // 
            tituloDataGridViewTextBoxColumn.DataPropertyName = "Titulo";
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            tituloDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            tituloDataGridViewTextBoxColumn.FillWeight = 30.26575F;
            tituloDataGridViewTextBoxColumn.HeaderText = "Título";
            tituloDataGridViewTextBoxColumn.Name = "tituloDataGridViewTextBoxColumn";
            tituloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // autorDataGridViewTextBoxColumn
            // 
            autorDataGridViewTextBoxColumn.DataPropertyName = "Autor";
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            autorDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
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
            dataGridViewCellStyle12.Padding = new Padding(10, 0, 0, 0);
            valorObraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
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
            dataGridViewCellStyle13.Alignment = DataGridViewContentAlignment.MiddleCenter;
            inicioPublicacaoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
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
            panelBottomObras.Location = new Point(3, 344);
            panelBottomObras.Name = "panelBottomObras";
            panelBottomObras.Size = new Size(1027, 81);
            panelBottomObras.TabIndex = 0;
            // 
            // panelObras
            // 
            panelObras.Dock = DockStyle.Top;
            panelObras.Location = new Point(3, 3);
            panelObras.Name = "panelObras";
            panelObras.Size = new Size(1027, 87);
            panelObras.TabIndex = 2;
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
            panelCompras.Location = new Point(3, 41);
            panelCompras.Name = "panelCompras";
            panelCompras.Size = new Size(1027, 337);
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
            dataGridViewCellStyle14.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = SystemColors.Control;
            dataGridViewCellStyle14.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle14.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = DataGridViewTriState.True;
            dataGridCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridCompras.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, cpfDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, valorCompraDataGridViewTextBoxColumn, dataCompraDataGridViewTextBoxColumn });
            dataGridCompras.DataSource = compraClienteBindingSource;
            dataGridCompras.Dock = DockStyle.Fill;
            dataGridCompras.Location = new Point(0, 0);
            dataGridCompras.Name = "dataGridCompras";
            dataGridCompras.ReadOnly = true;
            dataGridCompras.RowTemplate.Height = 25;
            dataGridCompras.Size = new Size(1027, 337);
            dataGridCompras.TabIndex = 3;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "Id";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // cpfDataGridViewTextBoxColumn
            // 
            cpfDataGridViewTextBoxColumn.DataPropertyName = "Cpf";
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
            valorCompraDataGridViewTextBoxColumn.HeaderText = "Valor";
            valorCompraDataGridViewTextBoxColumn.Name = "valorCompraDataGridViewTextBoxColumn";
            valorCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataCompraDataGridViewTextBoxColumn
            // 
            dataCompraDataGridViewTextBoxColumn.DataPropertyName = "DataCompra";
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
            panel2BottomCompras.Location = new Point(3, 378);
            panel2BottomCompras.Name = "panel2BottomCompras";
            panel2BottomCompras.Size = new Size(1027, 47);
            panel2BottomCompras.TabIndex = 1;
            // 
            // panelFiltroCompras
            // 
            panelFiltroCompras.Dock = DockStyle.Top;
            panelFiltroCompras.Location = new Point(3, 3);
            panelFiltroCompras.Name = "panelFiltroCompras";
            panelFiltroCompras.Size = new Size(1027, 38);
            panelFiltroCompras.TabIndex = 0;
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
            tabPageCompras.ResumeLayout(false);
            panelCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridCompras).EndInit();
            ((System.ComponentModel.ISupportInitialize)compraClienteBindingSource).EndInit();
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
    }
}
