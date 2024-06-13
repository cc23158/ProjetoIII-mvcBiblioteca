using apBiblioteca.UI;
using System.Windows.Forms;

namespace apBiblioteca
{
    public partial class Form1 : Form
    {
        FrmLivro frmLivro = null;
        FrmLeitor frmLeitor = null;
        FrmEmprestimo frmEmprestimo = null;
        FrmDevolucao frmDevolucao = null;
        FrmConsultas frmConsultas = null;
        FrmEstatisticas frmEstatiticas = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void livrosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (txtServidor.Text == "" || txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");

            else
            {
                frmLivro = new UI.FrmLivro();
                frmLivro.servidor = txtServidor.Text;
                frmLivro.banco = txtBanco.Text;
                frmLivro.usuario = txtUsuario.Text;
                frmLivro.senha = txtSenha.Text;
                frmLivro.Show();
            }
        }

        private void leitoresToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (txtServidor.Text == "" || txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");

            else
            {
                frmLeitor = new UI.FrmLeitor();
                frmLeitor.servidor = txtServidor.Text;
                frmLeitor.banco = txtBanco.Text;
                frmLeitor.usuario = txtUsuario.Text;
                frmLeitor.senha = txtSenha.Text;
                frmLeitor.Show();
            }
        }

        private void emprestimoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (txtServidor.Text == "" || txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");

            else
            {
                frmEmprestimo = new UI.FrmEmprestimo();
                frmEmprestimo.servidor = txtServidor.Text;
                frmEmprestimo.banco = txtBanco.Text;
                frmEmprestimo.usuario = txtUsuario.Text;
                frmEmprestimo.senha = txtSenha.Text;
                frmEmprestimo.Show();
            }
        }

        private void devolucaoToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (txtServidor.Text == "" || txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");

            else
            {
                frmDevolucao = new UI.FrmDevolucao();
                frmDevolucao.servidor = txtServidor.Text;
                frmDevolucao.banco = txtBanco.Text;
                frmDevolucao.usuario = txtUsuario.Text;
                frmDevolucao.senha = txtSenha.Text;
                frmDevolucao.Show();
            }
        }

        // consultas de empréstimos
        private void emprestimosToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (txtServidor.Text == "" || txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");

            else
            {
                frmConsultas = new UI.FrmConsultas();
                frmConsultas.servidor = txtServidor.Text;
                frmConsultas.banco = txtBanco.Text;
                frmConsultas.usuario = txtUsuario.Text;
                frmConsultas.senha = txtSenha.Text;
                frmConsultas.Show();
            }
        }

        private void estatisticasToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            if (txtServidor.Text == "" || txtBanco.Text == "" || txtUsuario.Text == "" || txtSenha.Text == "")
                MessageBox.Show("Preencha os dados de conexão!");

            else
            {
                frmEstatiticas = new UI.FrmEstatisticas();
                frmEstatiticas.servidor = txtServidor.Text;
                frmEstatiticas.banco = txtBanco.Text;
                frmEstatiticas.usuario = txtUsuario.Text;
                frmEstatiticas.senha = txtSenha.Text;
                frmEstatiticas.Show();
            }
        }
    }
}
