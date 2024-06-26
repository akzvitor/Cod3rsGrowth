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
            labelValorCompra = new Label();
            maskedTextBoxCpf = new MaskedTextBox();
            maskedTextBoxTelefone = new MaskedTextBox();
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
            // maskedTextBoxTelefone
            // 
            maskedTextBoxTelefone.BackColor = SystemColors.Control;
            maskedTextBoxTelefone.Location = new Point(12, 123);
            maskedTextBoxTelefone.Mask = "(00)00000-0000";
            maskedTextBoxTelefone.Name = "maskedTextBoxTelefone";
            maskedTextBoxTelefone.Size = new Size(89, 23);
            maskedTextBoxTelefone.TabIndex = 7;
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
            buttonSalvar.Location = new Point(214, 264);
            buttonSalvar.Name = "buttonSalvar";
            buttonSalvar.Size = new Size(95, 28);
            buttonSalvar.TabIndex = 12;
            buttonSalvar.Text = "Salvar";
            buttonSalvar.UseVisualStyleBackColor = false;
            buttonSalvar.Click += AoClicarNoBotaoSalvar;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = SystemColors.ButtonHighlight;
            buttonCancelar.Location = new Point(12, 264);
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
            ClientSize = new Size(326, 312);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonSalvar);
            Controls.Add(textBoxValorCompra);
            Controls.Add(textBoxNome);
            Controls.Add(textBoxEmail);
            Controls.Add(maskedTextBoxTelefone);
            Controls.Add(maskedTextBoxCpf);
            Controls.Add(labelValorCompra);
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
        private Label labelValorCompra;
        private MaskedTextBox maskedTextBoxCpf;
        private MaskedTextBox maskedTextBoxTelefone;
        private TextBox textBoxEmail;
        private TextBox textBoxNome;
        private TextBox textBoxValorCompra;
        private Button buttonSalvar;
        private Button buttonCancelar;
    }
}