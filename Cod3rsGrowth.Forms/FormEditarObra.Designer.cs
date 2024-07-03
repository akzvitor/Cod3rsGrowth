namespace Cod3rsGrowth.Forms
{
    partial class FormEditarObra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelGeneros = new Label();
            checkedListBoxGeneros = new CheckedListBox();
            comboBoxFormato = new ComboBox();
            labelFormato = new Label();
            buttonCancelar = new Button();
            buttonSalvar = new Button();
            textBoxValor = new TextBox();
            numericUpDownCapitulos = new NumericUpDown();
            richTextBoxSinopse = new RichTextBox();
            radioButtonEmLancamento = new RadioButton();
            radioButtonFinalizada = new RadioButton();
            dateTimePickerInicioPublicacao = new DateTimePicker();
            textBoxAutor = new TextBox();
            textBoxTitulo = new TextBox();
            labelStatus = new Label();
            labelInicioPublicacao = new Label();
            labelValor = new Label();
            labelCapitulos = new Label();
            labelSinopse = new Label();
            labelAutor = new Label();
            labelTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapitulos).BeginInit();
            SuspendLayout();
            // 
            // labelGeneros
            // 
            labelGeneros.AutoSize = true;
            labelGeneros.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelGeneros.Location = new Point(212, 222);
            labelGeneros.Name = "labelGeneros";
            labelGeneros.Size = new Size(60, 19);
            labelGeneros.TabIndex = 41;
            labelGeneros.Text = "Generos";
            // 
            // checkedListBoxGeneros
            // 
            checkedListBoxGeneros.BackColor = SystemColors.Control;
            checkedListBoxGeneros.BorderStyle = BorderStyle.FixedSingle;
            checkedListBoxGeneros.CheckOnClick = true;
            checkedListBoxGeneros.FormattingEnabled = true;
            checkedListBoxGeneros.Items.AddRange(new object[] { "Acao", "ArtesMarciais", "Aventura", "Comedia", "Drama", "Ecchi", "Espaco", "Esporte", "Fantasia", "Harem", "Historico", "Horror", "Jogos", "MahouShoujo", "Mecha", "Militar", "Misterio", "Musical", "Psicologico", "Romance", "Samurai", "SciFi", "Seinen", "Shoujo", "Shounen", "SliceOfLife", "Sobrenatural", "VidaEscolar", "Yaoi", "Yuri" });
            checkedListBoxGeneros.Location = new Point(215, 244);
            checkedListBoxGeneros.Name = "checkedListBoxGeneros";
            checkedListBoxGeneros.Size = new Size(124, 164);
            checkedListBoxGeneros.TabIndex = 37;
            // 
            // comboBoxFormato
            // 
            comboBoxFormato.BackColor = SystemColors.Control;
            comboBoxFormato.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFormato.FormattingEnabled = true;
            comboBoxFormato.Location = new Point(216, 91);
            comboBoxFormato.Name = "comboBoxFormato";
            comboBoxFormato.Size = new Size(124, 23);
            comboBoxFormato.TabIndex = 28;
            // 
            // labelFormato
            // 
            labelFormato.AutoSize = true;
            labelFormato.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelFormato.Location = new Point(212, 69);
            labelFormato.Name = "labelFormato";
            labelFormato.Size = new Size(61, 19);
            labelFormato.TabIndex = 40;
            labelFormato.Text = "Formato";
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = SystemColors.ButtonHighlight;
            buttonCancelar.Location = new Point(12, 435);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(88, 28);
            buttonCancelar.TabIndex = 39;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // buttonSalvar
            // 
            buttonSalvar.BackColor = SystemColors.ButtonHighlight;
            buttonSalvar.Location = new Point(245, 435);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new Size(95, 28);
            buttonSalvar.TabIndex = 38;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.UseVisualStyleBackColor = false;
            // 
            // textBoxValor
            // 
            textBoxValor.BackColor = SystemColors.Control;
            textBoxValor.BorderStyle = BorderStyle.FixedSingle;
            textBoxValor.Location = new Point(15, 152);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(150, 23);
            textBoxValor.TabIndex = 31;
            textBoxValor.Text = "0,00";
            textBoxValor.TextAlign = HorizontalAlignment.Right;
            // 
            // numericUpDownCapitulos
            // 
            numericUpDownCapitulos.BackColor = SystemColors.Control;
            numericUpDownCapitulos.Location = new Point(215, 33);
            numericUpDownCapitulos.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownCapitulos.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownCapitulos.Name = "numericUpDownCapitulos";
            numericUpDownCapitulos.Size = new Size(125, 23);
            numericUpDownCapitulos.TabIndex = 25;
            numericUpDownCapitulos.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // richTextBoxSinopse
            // 
            richTextBoxSinopse.BackColor = SystemColors.Control;
            richTextBoxSinopse.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxSinopse.Location = new Point(12, 300);
            richTextBoxSinopse.Name = "richTextBoxSinopse";
            richTextBoxSinopse.Size = new Size(153, 110);
            richTextBoxSinopse.TabIndex = 36;
            richTextBoxSinopse.Text = "";
            // 
            // radioButtonEmLancamento
            // 
            radioButtonEmLancamento.AutoSize = true;
            radioButtonEmLancamento.Location = new Point(215, 156);
            radioButtonEmLancamento.Name = "radioButtonEmLancamento";
            radioButtonEmLancamento.Size = new Size(111, 19);
            radioButtonEmLancamento.TabIndex = 33;
            radioButtonEmLancamento.TabStop = true;
            radioButtonEmLancamento.Text = "Em Lançamento";
            radioButtonEmLancamento.UseVisualStyleBackColor = true;
            // 
            // radioButtonFinalizada
            // 
            radioButtonFinalizada.AutoSize = true;
            radioButtonFinalizada.BackColor = SystemColors.Window;
            radioButtonFinalizada.Location = new Point(215, 181);
            radioButtonFinalizada.Name = "radioButtonFinalizada";
            radioButtonFinalizada.Size = new Size(77, 19);
            radioButtonFinalizada.TabIndex = 34;
            radioButtonFinalizada.TabStop = true;
            radioButtonFinalizada.Text = "Finalizada";
            radioButtonFinalizada.UseVisualStyleBackColor = false;
            // 
            // dateTimePickerInicioPublicacao
            // 
            dateTimePickerInicioPublicacao.CalendarMonthBackground = SystemColors.Control;
            dateTimePickerInicioPublicacao.Format = DateTimePickerFormat.Short;
            dateTimePickerInicioPublicacao.Location = new Point(12, 244);
            dateTimePickerInicioPublicacao.Name = "dateTimePickerInicioPublicacao";
            dateTimePickerInicioPublicacao.Size = new Size(151, 23);
            dateTimePickerInicioPublicacao.TabIndex = 35;
            // 
            // textBoxAutor
            // 
            textBoxAutor.BackColor = SystemColors.Control;
            textBoxAutor.BorderStyle = BorderStyle.FixedSingle;
            textBoxAutor.Location = new Point(15, 91);
            textBoxAutor.Name = "textBoxAutor";
            textBoxAutor.Size = new Size(150, 23);
            textBoxAutor.TabIndex = 27;
            // 
            // textBoxTitulo
            // 
            textBoxTitulo.BackColor = SystemColors.Control;
            textBoxTitulo.BorderStyle = BorderStyle.FixedSingle;
            textBoxTitulo.Location = new Point(15, 33);
            textBoxTitulo.Name = "textBoxTitulo";
            textBoxTitulo.Size = new Size(150, 23);
            textBoxTitulo.TabIndex = 23;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelStatus.Location = new Point(212, 130);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(47, 19);
            labelStatus.TabIndex = 32;
            labelStatus.Text = "Status";
            // 
            // labelInicioPublicacao
            // 
            labelInicioPublicacao.AutoSize = true;
            labelInicioPublicacao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelInicioPublicacao.Location = new Point(8, 222);
            labelInicioPublicacao.Name = "labelInicioPublicacao";
            labelInicioPublicacao.Size = new Size(128, 19);
            labelInicioPublicacao.TabIndex = 30;
            labelInicioPublicacao.Text = "Início da Publicação";
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelValor.Location = new Point(11, 130);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(40, 19);
            labelValor.TabIndex = 29;
            labelValor.Text = "Valor";
            // 
            // labelCapitulos
            // 
            labelCapitulos.AutoSize = true;
            labelCapitulos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelCapitulos.Location = new Point(212, 11);
            labelCapitulos.Name = "labelCapitulos";
            labelCapitulos.Size = new Size(66, 19);
            labelCapitulos.TabIndex = 26;
            labelCapitulos.Text = "Capítulos";
            // 
            // labelSinopse
            // 
            labelSinopse.AutoSize = true;
            labelSinopse.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelSinopse.Location = new Point(8, 278);
            labelSinopse.Name = "labelSinopse";
            labelSinopse.Size = new Size(56, 19);
            labelSinopse.TabIndex = 24;
            labelSinopse.Text = "Sinopse";
            // 
            // labelAutor
            // 
            labelAutor.AutoSize = true;
            labelAutor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelAutor.Location = new Point(11, 69);
            labelAutor.Name = "labelAutor";
            labelAutor.Size = new Size(44, 19);
            labelAutor.TabIndex = 22;
            labelAutor.Text = "Autor";
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.Location = new Point(8, 11);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(43, 19);
            labelTitulo.TabIndex = 21;
            labelTitulo.Text = "Título";
            // 
            // FormEditarObra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(365, 482);
            Controls.Add(labelGeneros);
            Controls.Add(checkedListBoxGeneros);
            Controls.Add(comboBoxFormato);
            Controls.Add(labelFormato);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonSalvar);
            Controls.Add(textBoxValor);
            Controls.Add(numericUpDownCapitulos);
            Controls.Add(richTextBoxSinopse);
            Controls.Add(radioButtonEmLancamento);
            Controls.Add(radioButtonFinalizada);
            Controls.Add(dateTimePickerInicioPublicacao);
            Controls.Add(textBoxAutor);
            Controls.Add(textBoxTitulo);
            Controls.Add(labelStatus);
            Controls.Add(labelInicioPublicacao);
            Controls.Add(labelValor);
            Controls.Add(labelCapitulos);
            Controls.Add(labelSinopse);
            Controls.Add(labelAutor);
            Controls.Add(labelTitulo);
            Name = "FormEditarObra";
            Text = "Editar Obra";
            Load += AoInicializarFormulario;
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapitulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelGeneros;
        private CheckedListBox checkedListBoxGeneros;
        private ComboBox comboBoxFormato;
        private Label labelFormato;
        private Button buttonCancelar;
        private Button buttonSalvar;
        private TextBox textBoxValor;
        private NumericUpDown numericUpDownCapitulos;
        private RichTextBox richTextBoxSinopse;
        private RadioButton radioButtonEmLancamento;
        private RadioButton radioButtonFinalizada;
        private DateTimePicker dateTimePickerInicioPublicacao;
        private TextBox textBoxAutor;
        private TextBox textBoxTitulo;
        private Label labelStatus;
        private Label labelInicioPublicacao;
        private Label labelValor;
        private Label labelCapitulos;
        private Label labelSinopse;
        private Label labelAutor;
        private Label labelTitulo;
    }
}