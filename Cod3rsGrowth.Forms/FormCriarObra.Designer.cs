namespace Cod3rsGrowth.Forms
{
    partial class FormCriarObra
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
            labelTitulo = new Label();
            labelAutor = new Label();
            labelSinopse = new Label();
            labelCapitulos = new Label();
            labelValor = new Label();
            labelInicioPublicacao = new Label();
            labelStatus = new Label();
            textBoxTitulo = new TextBox();
            textBoxAutor = new TextBox();
            dateTimePickerInicioPublicacao = new DateTimePicker();
            radioButtonFinalizada = new RadioButton();
            radioButtonEmLancamento = new RadioButton();
            richTextBoxSinopse = new RichTextBox();
            numericUpDownCapitulos = new NumericUpDown();
            textBoxValor = new TextBox();
            buttonSalvar = new Button();
            buttonCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapitulos).BeginInit();
            SuspendLayout();
            // 
            // labelTitulo
            // 
            labelTitulo.AutoSize = true;
            labelTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTitulo.Location = new Point(9, 10);
            labelTitulo.Name = "labelTitulo";
            labelTitulo.Size = new Size(43, 19);
            labelTitulo.TabIndex = 0;
            labelTitulo.Text = "Título";
            // 
            // labelAutor
            // 
            labelAutor.AutoSize = true;
            labelAutor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelAutor.Location = new Point(8, 68);
            labelAutor.Name = "labelAutor";
            labelAutor.Size = new Size(44, 19);
            labelAutor.TabIndex = 1;
            labelAutor.Text = "Autor";
            // 
            // labelSinopse
            // 
            labelSinopse.AutoSize = true;
            labelSinopse.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelSinopse.Location = new Point(8, 222);
            labelSinopse.Name = "labelSinopse";
            labelSinopse.Size = new Size(56, 19);
            labelSinopse.TabIndex = 2;
            labelSinopse.Text = "Sinopse";
            // 
            // labelCapitulos
            // 
            labelCapitulos.AutoSize = true;
            labelCapitulos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelCapitulos.Location = new Point(209, 10);
            labelCapitulos.Name = "labelCapitulos";
            labelCapitulos.Size = new Size(66, 19);
            labelCapitulos.TabIndex = 3;
            labelCapitulos.Text = "Capítulos";
            // 
            // labelValor
            // 
            labelValor.AutoSize = true;
            labelValor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelValor.Location = new Point(209, 68);
            labelValor.Name = "labelValor";
            labelValor.Size = new Size(40, 19);
            labelValor.TabIndex = 4;
            labelValor.Text = "Valor";
            // 
            // labelInicioPublicacao
            // 
            labelInicioPublicacao.AutoSize = true;
            labelInicioPublicacao.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelInicioPublicacao.Location = new Point(9, 138);
            labelInicioPublicacao.Name = "labelInicioPublicacao";
            labelInicioPublicacao.Size = new Size(128, 19);
            labelInicioPublicacao.TabIndex = 5;
            labelInicioPublicacao.Text = "Início da Publicação";
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelStatus.Location = new Point(209, 138);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(47, 19);
            labelStatus.TabIndex = 6;
            labelStatus.Text = "Status";
            // 
            // textBoxTitulo
            // 
            textBoxTitulo.BackColor = SystemColors.Control;
            textBoxTitulo.BorderStyle = BorderStyle.FixedSingle;
            textBoxTitulo.Location = new Point(12, 32);
            textBoxTitulo.Name = "textBoxTitulo";
            textBoxTitulo.Size = new Size(150, 23);
            textBoxTitulo.TabIndex = 7;
            // 
            // textBoxAutor
            // 
            textBoxAutor.BackColor = SystemColors.Control;
            textBoxAutor.BorderStyle = BorderStyle.FixedSingle;
            textBoxAutor.Location = new Point(12, 90);
            textBoxAutor.Name = "textBoxAutor";
            textBoxAutor.Size = new Size(150, 23);
            textBoxAutor.TabIndex = 8;
            // 
            // dateTimePickerInicioPublicacao
            // 
            dateTimePickerInicioPublicacao.CalendarMonthBackground = SystemColors.Control;
            dateTimePickerInicioPublicacao.Format = DateTimePickerFormat.Short;
            dateTimePickerInicioPublicacao.Location = new Point(12, 160);
            dateTimePickerInicioPublicacao.Name = "dateTimePickerInicioPublicacao";
            dateTimePickerInicioPublicacao.Size = new Size(150, 23);
            dateTimePickerInicioPublicacao.TabIndex = 9;
            // 
            // radioButtonFinalizada
            // 
            radioButtonFinalizada.AutoSize = true;
            radioButtonFinalizada.Location = new Point(212, 189);
            radioButtonFinalizada.Name = "radioButtonFinalizada";
            radioButtonFinalizada.Size = new Size(77, 19);
            radioButtonFinalizada.TabIndex = 10;
            radioButtonFinalizada.TabStop = true;
            radioButtonFinalizada.Text = "Finalizada";
            radioButtonFinalizada.UseVisualStyleBackColor = true;
            // 
            // radioButtonEmLancamento
            // 
            radioButtonEmLancamento.AutoSize = true;
            radioButtonEmLancamento.Location = new Point(212, 164);
            radioButtonEmLancamento.Name = "radioButtonEmLancamento";
            radioButtonEmLancamento.Size = new Size(111, 19);
            radioButtonEmLancamento.TabIndex = 11;
            radioButtonEmLancamento.TabStop = true;
            radioButtonEmLancamento.Text = "Em Lançamento";
            radioButtonEmLancamento.UseVisualStyleBackColor = true;
            // 
            // richTextBoxSinopse
            // 
            richTextBoxSinopse.BackColor = SystemColors.Control;
            richTextBoxSinopse.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxSinopse.Location = new Point(12, 244);
            richTextBoxSinopse.Name = "richTextBoxSinopse";
            richTextBoxSinopse.Size = new Size(311, 79);
            richTextBoxSinopse.TabIndex = 12;
            richTextBoxSinopse.Text = "";
            // 
            // numericUpDownCapitulos
            // 
            numericUpDownCapitulos.BackColor = SystemColors.Control;
            numericUpDownCapitulos.Location = new Point(212, 32);
            numericUpDownCapitulos.Name = "numericUpDownCapitulos";
            numericUpDownCapitulos.Size = new Size(111, 23);
            numericUpDownCapitulos.TabIndex = 13;
            // 
            // textBoxValor
            // 
            textBoxValor.BackColor = SystemColors.Control;
            textBoxValor.BorderStyle = BorderStyle.FixedSingle;
            textBoxValor.Location = new Point(212, 90);
            textBoxValor.Name = "textBoxValor";
            textBoxValor.Size = new Size(111, 23);
            textBoxValor.TabIndex = 14;
            textBoxValor.Text = "0,00";
            textBoxValor.TextAlign = HorizontalAlignment.Right;
            textBoxValor.TextChanged += AoAlterarTextoDoCampoValor;
            textBoxValor.KeyPress += AoPressionarTeclaNoCampoValor;
            // 
            // buttonSalvar
            // 
            buttonSalvar.BackColor = SystemColors.ButtonHighlight;
            buttonSalvar.Location = new Point(228, 356);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new Size(95, 28);
            buttonSalvar.TabIndex = 15;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.UseVisualStyleBackColor = false;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = SystemColors.ButtonHighlight;
            buttonCancelar.Location = new Point(12, 356);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(88, 28);
            buttonCancelar.TabIndex = 16;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // FormCriarObra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(342, 395);
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
            Name = "FormCriarObra";
            Text = "Cadastrar Obra";
            Load += FormCriarObra_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownCapitulos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTitulo;
        private Label labelAutor;
        private Label labelSinopse;
        private Label labelCapitulos;
        private Label labelValor;
        private Label labelInicioPublicacao;
        private Label labelStatus;
        private TextBox textBoxTitulo;
        private TextBox textBoxAutor;
        private DateTimePicker dateTimePickerInicioPublicacao;
        private RadioButton radioButtonFinalizada;
        private RadioButton radioButtonEmLancamento;
        private RichTextBox richTextBoxSinopse;
        private NumericUpDown numericUpDownCapitulos;
        private TextBox textBoxValor;
        private Button buttonSalvar;
        private Button buttonCancelar;
    }
}