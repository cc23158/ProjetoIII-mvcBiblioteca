namespace apBiblioteca.UI
{
    partial class FrmEmprestimo
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
            this.cbxLeitor = new System.Windows.Forms.ComboBox();
            this.cbxLivro = new System.Windows.Forms.ComboBox();
            this.txtIdentificacao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEmprestimo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxLeitor
            // 
            this.cbxLeitor.FormattingEnabled = true;
            this.cbxLeitor.Location = new System.Drawing.Point(128, 88);
            this.cbxLeitor.MaxLength = 50;
            this.cbxLeitor.Name = "cbxLeitor";
            this.cbxLeitor.Size = new System.Drawing.Size(321, 21);
            this.cbxLeitor.TabIndex = 4;
            // 
            // cbxLivro
            // 
            this.cbxLivro.FormattingEnabled = true;
            this.cbxLivro.Location = new System.Drawing.Point(128, 61);
            this.cbxLivro.MaxLength = 50;
            this.cbxLivro.Name = "cbxLivro";
            this.cbxLivro.Size = new System.Drawing.Size(321, 21);
            this.cbxLivro.TabIndex = 5;
            // 
            // txtIdentificacao
            // 
            this.txtIdentificacao.Location = new System.Drawing.Point(128, 35);
            this.txtIdentificacao.Name = "txtIdentificacao";
            this.txtIdentificacao.ReadOnly = true;
            this.txtIdentificacao.Size = new System.Drawing.Size(100, 20);
            this.txtIdentificacao.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Identificação:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Leitor:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Livro:";
            // 
            // btnEmprestimo
            // 
            this.btnEmprestimo.Location = new System.Drawing.Point(128, 174);
            this.btnEmprestimo.Name = "btnEmprestimo";
            this.btnEmprestimo.Size = new System.Drawing.Size(263, 23);
            this.btnEmprestimo.TabIndex = 14;
            this.btnEmprestimo.Text = "Fazer Emprestimo";
            this.btnEmprestimo.UseVisualStyleBackColor = true;
            this.btnEmprestimo.Click += new System.EventHandler(this.btnEmprestimo_Click);
            // 
            // FrmEmprestimo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 274);
            this.Controls.Add(this.btnEmprestimo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIdentificacao);
            this.Controls.Add(this.cbxLivro);
            this.Controls.Add(this.cbxLeitor);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmEmprestimo";
            this.Text = "FrmEmprestimo";
            this.Load += new System.EventHandler(this.FrmEmprestimo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbxLeitor;
        private System.Windows.Forms.ComboBox cbxLivro;
        private System.Windows.Forms.TextBox txtIdentificacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEmprestimo;
    }
}