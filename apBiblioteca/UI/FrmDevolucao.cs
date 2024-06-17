/*
Keven Richard da Rocha Barreiros - 23143
Victor Yuji Mimura               - 23158
*/

using apBiblioteca.BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace apBiblioteca.UI
{
    public partial class FrmDevolucao : Form
    {
        public string servidor, banco, usuario, senha;
        private DataTable livros, leitores;

        public FrmDevolucao()
        {
            InitializeComponent();
        }

        private void FrmDevolucao_Load(object sender, System.EventArgs e)
        {
            // inserimos os livros e leitores ativos em seus respectivos comboBoxes
            try
            {
                var bllLivro = new LivroBLL(servidor, banco, usuario, senha);
                var bllLeitor = new LeitorBLL(servidor, banco, usuario, senha);

                livros = bllLivro.SelecionarLivros();
                leitores = bllLeitor.SelecionarLeitores();

                foreach (DataRow linha in livros.Rows)
                    cbxLivros.Items.Add(linha["tituloLivro"].ToString());

                foreach (DataRow linha in leitores.Rows)
                    cbxLeitores.Items.Add(linha["nomeLeitor"].ToString());
            }

            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnDevolver_Click(object sender, EventArgs e)
        {
            // fazemos a devolução do livro <> leitor baseado no ID
            if(txtIdentificador.Text != "")
            {
                Emprestimo emp = new Emprestimo(Convert.ToInt32(txtIdentificador.Text), 0, 0, default(DateTime), default(DateTime), default(DateTime));

                try
                {
                    var bllEmprestimo = new EmprestimoBLL(servidor, banco, usuario, senha);
                    bllEmprestimo.AlterarEmprestimo(emp);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }

            else
            {
                MessageBox.Show("Preencha os campos");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // fazemos a busca pelo ID do empréstimo pelo nome do livro e do leitor
            if (cbxLivros.SelectedItem != null && cbxLeitores.SelectedItem != null)
            {
                try
                {
                    // buscamos o ID do livro e do leitor para fazer a busca do empréstimo pelos IDs
                    int idLivro = -1;
                    int idLeitor = -1;

                    foreach (var linha in livros.Select())
                        if (linha["tituloLivro"].ToString() == cbxLivros.SelectedItem.ToString())
                        {
                            idLivro = Convert.ToInt32(linha["idLivro"]);
                            break;
                        }

                    foreach (var linha in leitores.Select())
                        if (linha["nomeLeitor"].ToString() == cbxLeitores.SelectedItem.ToString())
                        {
                            idLeitor = Convert.ToInt32(linha["idLeitor"]);
                            break;
                        }

                    var bllEmprestimo = new EmprestimoBLL(servidor, banco, usuario, senha);
                    Emprestimo emp = bllEmprestimo.SelectEmprestimoByIds(idLivro, idLeitor);
                    txtIdentificador.Text = emp.IdEmprestimo.ToString();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }

            else
            {
                MessageBox.Show("Preencha os campos");
            }
        }
    }
}
