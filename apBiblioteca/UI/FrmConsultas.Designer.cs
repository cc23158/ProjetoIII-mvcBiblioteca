namespace apBiblioteca.UI
{
    partial class FrmConsultas
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
            this.rbPendentes = new System.Windows.Forms.RadioButton();
            this.rbEntregues = new System.Windows.Forms.RadioButton();
            this.rbAtrasados = new System.Windows.Forms.RadioButton();
            this.dgvEmprestimos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprestimos)).BeginInit();
            this.SuspendLayout();
            // 
            // rbPendentes
            // 
            this.rbPendentes.AutoSize = true;
            this.rbPendentes.Location = new System.Drawing.Point(16, 24);
            this.rbPendentes.Name = "rbPendentes";
            this.rbPendentes.Size = new System.Drawing.Size(79, 17);
            this.rbPendentes.TabIndex = 1;
            this.rbPendentes.TabStop = true;
            this.rbPendentes.Text = "Pendentes";
            this.rbPendentes.UseVisualStyleBackColor = true;
            this.rbPendentes.CheckedChanged += new System.EventHandler(this.rbPendentes_CheckedChanged);
            // 
            // rbEntregues
            // 
            this.rbEntregues.AutoSize = true;
            this.rbEntregues.Location = new System.Drawing.Point(180, 24);
            this.rbEntregues.Name = "rbEntregues";
            this.rbEntregues.Size = new System.Drawing.Size(79, 17);
            this.rbEntregues.TabIndex = 2;
            this.rbEntregues.TabStop = true;
            this.rbEntregues.Text = "Entregues";
            this.rbEntregues.UseVisualStyleBackColor = true;
            this.rbEntregues.CheckedChanged += new System.EventHandler(this.rbEntregues_CheckedChanged);
            // 
            // rbAtrasados
            // 
            this.rbAtrasados.AutoSize = true;
            this.rbAtrasados.Location = new System.Drawing.Point(344, 24);
            this.rbAtrasados.Name = "rbAtrasados";
            this.rbAtrasados.Size = new System.Drawing.Size(145, 17);
            this.rbAtrasados.TabIndex = 3;
            this.rbAtrasados.TabStop = true;
            this.rbAtrasados.Text = "Entregues com Atraso";
            this.rbAtrasados.UseVisualStyleBackColor = true;
            this.rbAtrasados.CheckedChanged += new System.EventHandler(this.rbAtrasados_CheckedChanged);
            // 
            // dgvEmprestimos
            // 
            this.dgvEmprestimos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmprestimos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmprestimos.Location = new System.Drawing.Point(16, 47);
            this.dgvEmprestimos.Name = "dgvEmprestimos";
            this.dgvEmprestimos.ReadOnly = true;
            this.dgvEmprestimos.Size = new System.Drawing.Size(473, 215);
            this.dgvEmprestimos.TabIndex = 0;
            // 
            // FrmConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 274);
            this.Controls.Add(this.rbAtrasados);
            this.Controls.Add(this.rbEntregues);
            this.Controls.Add(this.rbPendentes);
            this.Controls.Add(this.dgvEmprestimos);
            this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmConsultas";
            this.Text = "FrmConsultas";
            this.Load += new System.EventHandler(this.FrmConsultas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmprestimos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton rbPendentes;
        private System.Windows.Forms.RadioButton rbEntregues;
        private System.Windows.Forms.RadioButton rbAtrasados;
        private System.Windows.Forms.DataGridView dgvEmprestimos;
    }
}