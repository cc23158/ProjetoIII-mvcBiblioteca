// https://datatables.net/reference/api/count() -> Linha 36

using apBiblioteca.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apBiblioteca.UI
{
    public partial class FrmEstatisticas : Form
    {
        public string servidor, banco, usuario, senha;

        public FrmEstatisticas()
        {
            InitializeComponent();
        }

        private void FrmEstatisticas_Load(object sender, EventArgs e)
        {
            // pegamos os dados necessários através da BLL e mostramos na tela
            // o número de elementos existentes no BD de tal categoria

            var bllLivro = new LivroBLL(servidor, banco, usuario, senha);
            var bllLeitor = new LeitorBLL(servidor, banco, usuario, senha);
            var bllEmprestimo = new EmprestimoBLL(servidor, banco, usuario, senha);

            DataTable emprestimos = bllEmprestimo.SelecionarEmprestimos();
            DataTable atrasadas   = bllEmprestimo.SelecionarAtrasadas();
            DataTable pendentes   = bllEmprestimo.SelecionarPendentes();
            DataTable livros      = bllLivro.SelecionarLivros();
            DataTable leitores    = bllLeitor.SelecionarLeitores();

            txtEmprestimos.Text = emprestimos.Rows.Count.ToString();
            txtAtrasadas.Text   = atrasadas.Rows.Count.ToString();
            txtPendentes.Text   = pendentes.Rows.Count.ToString();
            txtLivros.Text      = livros.Rows.Count.ToString();
            txtLeitores.Text    = leitores.Rows.Count.ToString();
        }
    }
}
