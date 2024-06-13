namespace apBiblioteca.UI
{
    partial class FrmEstatisticas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEmprestimos = new System.Windows.Forms.TextBox();
            this.txtAtrasadas = new System.Windows.Forms.TextBox();
            this.txtPendentes = new System.Windows.Forms.TextBox();
            this.txtLivros = new System.Windows.Forms.TextBox();
            this.txtLeitores = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nº total de emprestimos:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nº total de entregas atrasadas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nº total de entregas pendentes:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nº total de livros:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(115, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Nº total de leitores:";
            // 
            // txtEmprestimos
            // 
            this.txtEmprestimos.Location = new System.Drawing.Point(278, 33);
            this.txtEmprestimos.Name = "txtEmprestimos";
            this.txtEmprestimos.Size = new System.Drawing.Size(100, 20);
            this.txtEmprestimos.TabIndex = 5;
            // 
            // txtAtrasadas
            // 
            this.txtAtrasadas.Location = new System.Drawing.Point(278, 79);
            this.txtAtrasadas.Name = "txtAtrasadas";
            this.txtAtrasadas.Size = new System.Drawing.Size(100, 20);
            this.txtAtrasadas.TabIndex = 6;
            // 
            // txtPendentes
            // 
            this.txtPendentes.Location = new System.Drawing.Point(278, 125);
            this.txtPendentes.Name = "txtPendentes";
            this.txtPendentes.Size = new System.Drawing.Size(100, 20);
            this.txtPendentes.TabIndex = 7;
            // 
            // txtLivros
            // 
            this.txtLivros.Location = new System.Drawing.Point(278, 171);
            this.txtLivros.Name = "txtLivros";
            this.txtLivros.Size = new System.Drawing.Size(100, 20);
            this.txtLivros.TabIndex = 8;
            // 
            // txtLeitores
            // 
            this.txtLeitores.Location = new System.Drawing.Point(278, 217);
            this.txtLeitores.Name = "txtLeitores";
            this.txtLeitores.Size = new System.Drawing.Size(100, 20);
            this.txtLeitores.TabIndex = 9;
            // 
            // FrmEstatisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 274);
            this.Controls.Add(this.txtLeitores);
            this.Controls.Add(this.txtLivros);
            this.Controls.Add(this.txtPendentes);
            this.Controls.Add(this.txtAtrasadas);
            this.Controls.Add(this.txtEmprestimos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmEstatisticas";
            this.Text = "FrmEstatisticas";
            this.Load += new System.EventHandler(this.FrmEstatisticas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmprestimos;
        private System.Windows.Forms.TextBox txtAtrasadas;
        private System.Windows.Forms.TextBox txtPendentes;
        private System.Windows.Forms.TextBox txtLivros;
        private System.Windows.Forms.TextBox txtLeitores;
    }
}