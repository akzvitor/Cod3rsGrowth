namespace Cod3rsGrowth.Forms
{
    partial class FormCriarCompra
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
            labelCpf = new Label();
            labelNome = new Label();
            labelTelefone = new Label();
            labelEmail = new Label();
            labelDataCompra = new Label();
            labelValorCompra = new Label();
            maskedTextBoxCpf = new MaskedTextBox();
            maskedTextBox1 = new MaskedTextBox();
            dateTimePickerDataCompra = new DateTimePicker();
            textBoxEmail = new TextBox();
            textBoxNome = new TextBox();
            textBoxValorCompra = new TextBox();
            buttonSalvar = new Button();
            buttonCancelar = new Button();
            SuspendLayout();
            // 
            // labelCpf
            // 
            labelCpf.AutoSize = true;
            labelCpf.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelCpf.Location = new Point(9, 9);
            labelCpf.Name = "labelCpf";
            labelCpf.Size = new Size(33, 19);
            labelCpf.TabIndex = 0;
            labelCpf.Text = "CPF";
            // 
            // labelNome
            // 
            labelNome.AutoSize = true;
            labelNome.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelNome.Location = new Point(167, 9);
            labelNome.Name = "labelNome";
            labelNome.Size = new Size(46, 19);
            labelNome.TabIndex = 1;
            labelNome.Text = "Nome";
            // 
            // labelTelefone
            // 
            labelTelefone.AutoSize = true;
            labelTelefone.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelTelefone.Location = new Point(9, 101);
            labelTelefone.Name = "labelTelefone";
            labelTelefone.Size = new Size(59, 19);
            labelTelefone.TabIndex = 2;
            labelTelefone.Text = "Telefone";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelEmail.Location = new Point(9, 188);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(47, 19);
            labelEmail.TabIndex = 3;
            labelEmail.Text = "E-mail";
            // 
            // labelDataCompra
            // 
            labelDataCompra.AutoSize = true;
            labelDataCompra.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelDataCompra.Location = new Point(9, 260);
            labelDataCompra.Name = "labelDataCompra";
            labelDataCompra.Size = new Size(110, 19);
            labelDataCompra.TabIndex = 4;
            labelDataCompra.Text = "Data da Compra";
            // 
            // labelValorCompra
            // 
            labelValorCompra.AutoSize = true;
            labelValorCompra.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelValorCompra.Location = new Point(167, 101);
            labelValorCompra.Name = "labelValorCompra";
            labelValorCompra.Size = new Size(40, 19);
            labelValorCompra.TabIndex = 5;
            labelValorCompra.Text = "Valor";
            // 
            // maskedTextBoxCpf
            // 
            maskedTextBoxCpf.BackColor = SystemColors.Control;
            maskedTextBoxCpf.Culture = new System.Globalization.CultureInfo("");
            maskedTextBoxCpf.Location = new Point(12, 31);
            maskedTextBoxCpf.Mask = "000.000.000-00";
            maskedTextBoxCpf.Name = "maskedTextBoxCpf";
            maskedTextBoxCpf.Size = new Size(89, 23);
            maskedTextBoxCpf.TabIndex = 6;
            // 
            // maskedTextBox1
            // 
            maskedTextBox1.BackColor = SystemColors.Control;
            maskedTextBox1.Location = new Point(12, 123);
            maskedTextBox1.Mask = "(99) 00000-0000";
            maskedTextBox1.Name = "maskedTextBox1";
            maskedTextBox1.Size = new Size(89, 23);
            maskedTextBox1.TabIndex = 7;
            // 
            // dateTimePickerDataCompra
            // 
            dateTimePickerDataCompra.Format = DateTimePickerFormat.Short;
            dateTimePickerDataCompra.Location = new Point(12, 282);
            dateTimePickerDataCompra.Name = "dateTimePickerDataCompra";
            dateTimePickerDataCompra.Size = new Size(297, 23);
            dateTimePickerDataCompra.TabIndex = 8;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BackColor = SystemColors.Control;
            textBoxEmail.Location = new Point(12, 210);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(297, 23);
            textBoxEmail.TabIndex = 9;
            // 
            // textBoxNome
            // 
            textBoxNome.BackColor = SystemColors.Control;
            textBoxNome.Location = new Point(170, 31);
            textBoxNome.Name = "textBoxNome";
            textBoxNome.Size = new Size(139, 23);
            textBoxNome.TabIndex = 10;
            // 
            // textBoxValorCompra
            // 
            textBoxValorCompra.BackColor = SystemColors.Control;
            textBoxValorCompra.Location = new Point(170, 123);
            textBoxValorCompra.Name = "textBoxValorCompra";
            textBoxValorCompra.Size = new Size(139, 23);
            textBoxValorCompra.TabIndex = 11;
            textBoxValorCompra.Text = "0,00";
            textBoxValorCompra.TextChanged += AoAlterarTextoDoCampoValor;
            textBoxValorCompra.KeyPress += AoPressionarTeclaNoCampoValor;
            // 
            // buttonSalvar
            // 
            buttonSalvar.BackColor = SystemColors.ButtonHighlight;
            buttonSalvar.Location = new Point(214, 346);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new Size(95, 28);
            buttonSalvar.TabIndex = 12;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.UseVisualStyleBackColor = false;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = SystemColors.ButtonHighlight;
            buttonCancelar.Location = new Point(12, 346);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(95, 28);
            buttonCancelar.TabIndex = 13;
            buttonCancelar.Text = "Cancelar";
            buttonCancelar.UseVisualStyleBackColor = false;
            // 
            // FormCriarCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(326, 386);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonSalvar);
            Controls.Add(textBoxValorCompra);
            Controls.Add(textBoxNome);
            Controls.Add(textBoxEmail);
            Controls.Add(dateTimePickerDataCompra);
            Controls.Add(maskedTextBox1);
            Controls.Add(maskedTextBoxCpf);
            Controls.Add(labelValorCompra);
            Controls.Add(labelDataCompra);
            Controls.Add(labelEmail);
            Controls.Add(labelTelefone);
            Controls.Add(labelNome);
            Controls.Add(labelCpf);
            Name = "FormCriarCompra";
            Text = "FormCriarCompra";
            Load += AoInicializarFormulario;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCpf;
        private Label labelNome;
        private Label labelTelefone;
        private Label labelEmail;
        private Label labelDataCompra;
        private Label labelValorCompra;
        private MaskedTextBox maskedTextBoxCpf;
        private MaskedTextBox maskedTextBox1;
        private DateTimePicker dateTimePickerDataCompra;
        private TextBox textBoxEmail;
        private TextBox textBoxNome;
        private TextBox textBoxValorCompra;
        private Button buttonSalvar;
        private Button buttonCancelar;
    }
}