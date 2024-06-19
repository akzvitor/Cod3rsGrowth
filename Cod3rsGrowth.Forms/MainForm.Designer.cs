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
            TabPage tabPageObras;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tituloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            autorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            numeroCapitulosDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorObraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            formatoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            foiFinalizadaDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            inicioPublicacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            obraBindingSource = new BindingSource(components);
            panelDataGrid = new Panel();
            panelFilter = new Panel();
            tabControl1 = new TabControl();
            tabPageVendas = new TabPage();
            panelBottom = new Panel();
            tabPageObras = new TabPage();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)obraBindingSource).BeginInit();
            panelDataGrid.SuspendLayout();
            panelFilter.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // tabPageObras
            // 
            tabPageObras.Location = new Point(4, 24);
            tabPageObras.Name = "tabPageObras";
            tabPageObras.Padding = new Padding(3);
            tabPageObras.Size = new Size(1030, 1);
            tabPageObras.TabIndex = 0;
            tabPageObras.Text = "Obras";
            tabPageObras.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, tituloDataGridViewTextBoxColumn, autorDataGridViewTextBoxColumn, numeroCapitulosDataGridViewTextBoxColumn, valorObraDataGridViewTextBoxColumn, formatoDataGridViewTextBoxColumn, foiFinalizadaDataGridViewCheckBoxColumn, inicioPublicacaoDataGridViewTextBoxColumn });
            dataGridView1.DataSource = obraBindingSource;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(1038, 361);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
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
            // obraBindingSource
            // 
            obraBindingSource.DataSource = typeof(Dominio.Entidades.Obra);
            // 
            // panelDataGrid
            // 
            panelDataGrid.Controls.Add(dataGridView1);
            panelDataGrid.Dock = DockStyle.Fill;
            panelDataGrid.Location = new Point(0, 92);
            panelDataGrid.Name = "panelDataGrid";
            panelDataGrid.Size = new Size(1038, 361);
            panelDataGrid.TabIndex = 1;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(tabControl1);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 0);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(1038, 92);
            panelFilter.TabIndex = 2;
            panelFilter.Paint += panel2_Paint;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageObras);
            tabControl1.Controls.Add(tabPageVendas);
            tabControl1.Dock = DockStyle.Top;
            tabControl1.HotTrack = true;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1038, 29);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 4;
            // 
            // tabPageVendas
            // 
            tabPageVendas.Location = new Point(4, 24);
            tabPageVendas.Name = "tabPageVendas";
            tabPageVendas.Padding = new Padding(3);
            tabPageVendas.Size = new Size(1030, 1);
            tabPageVendas.TabIndex = 1;
            tabPageVendas.Text = "Vendas";
            tabPageVendas.UseVisualStyleBackColor = true;
            // 
            // panelBottom
            // 
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 378);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1038, 75);
            panelBottom.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 453);
            Controls.Add(panelBottom);
            Controls.Add(panelDataGrid);
            Controls.Add(panelFilter);
            Name = "MainForm";
            Text = "Coders Growth";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)obraBindingSource).EndInit();
            panelDataGrid.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private BindingSource obraBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn tituloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn autorDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numeroCapitulosDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorObraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn formatoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn foiFinalizadaDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn inicioPublicacaoDataGridViewTextBoxColumn;
        private Panel panelDataGrid;
        private Panel panelFilter;
        private Panel panelBottom;
        private TabControl tabControl1;
        private TabPage tabPageVendas;
    }
}
