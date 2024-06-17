/*
Keven Richard da Rocha Barreiros - 23143
Victor Yuji Mimura               - 23158
*/

// https://learn.microsoft.com/pt-br/dotnet/api/system.windows.forms.combobox.selecteditem?view=windowsdesktop-8.0 -> Linha 54

using apBiblioteca.BLL;
using DTO;
using System;
using System.Data;
using System.Windows.Forms;

namespace apBiblioteca.UI
{
    public partial class FrmEmprestimo : Form
    {
        public string servidor, banco, usuario, senha;
        private DataTable livros, leitores;

        public FrmEmprestimo()
        {
            InitializeComponent();
        }

        private void FrmEmprestimo_Load(object sender, EventArgs e)
        {
            // preenchemos os comboBox de livro e leitor com os dados do BD
            try
            {
                var bllLivro = new LivroBLL(servidor, banco, usuario, senha);
                var bllLeitor = new LeitorBLL(servidor, banco, usuario, senha);

                livros = bllLivro.SelecionarLivros();
                leitores = bllLeitor.SelecionarLeitores();

                foreach (DataRow linha in livros.Rows)
                    cbxLivro.Items.Add(linha["tituloLivro"].ToString());

                foreach (DataRow linha in leitores.Rows)
                    cbxLeitor.Items.Add(linha["nomeLeitor"].ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnEmprestimo_Click(object sender, EventArgs e)
        {
            // verificamos se os campos estão preenchidos e caso positivo, identificamos os IDs
            // do livro e do leitor que irão compor o empréstimo
            if (cbxLivro.SelectedItem != null && cbxLeitor.SelectedItem != null)
            {
                int idLivro = -1;
                int idLeitor = -1;

                foreach (var linha in livros.Select())
                    if (linha["tituloLivro"].ToString() == cbxLivro.SelectedItem.ToString())
                    {
                        idLivro = Convert.ToInt32(linha["idLivro"]);
                        break;
                    }

                foreach (var linha in leitores.Select())
                    if (linha["nomeLeitor"].ToString() == cbxLeitor.SelectedItem.ToString())
                    {
                        idLeitor = Convert.ToInt32(linha["idLeitor"]);
                        break;
                    }

                // criamos um objeto emprestimo
                // inserimos o empréstimo e atualizamos o identificador
                var emp = new Emprestimo(0, idLivro, idLeitor, DateTime.Now, DateTime.Now.AddDays(14), default(DateTime));
                var bll = new EmprestimoBLL(servidor, banco, usuario, senha);
                bll.IncluirEmprestimo(emp);
                txtIdentificacao.Text = bll.SelecionarUltimoIdEmprestimo().ToString();

            }

            else
            {
                MessageBox.Show("Preencha os campos");
            }
        }
    }
}
