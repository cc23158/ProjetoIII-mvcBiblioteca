/*
Keven Richard da Rocha Barreiros - 23143
Victor Yuji Mimura               - 23158
*/

using apBiblioteca.BLL;
using DTO;
using System;
using System.Windows.Forms;

namespace apBiblioteca.UI
{
    public partial class FrmLeitor : Form
    {
        public string servidor, banco, usuario, senha;

        public FrmLeitor()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            // inserimos o leitor de acordo com os campos digitados
            if (txtNomeDoLeitor.Text != "" && txtTelefoneDoLeitor.Text != "" && txtEnderecoDoLeitor.Text != "" && txtEmailDoLeitor.Text != "")
            {
                var leitor = new Leitor(0, txtNomeDoLeitor.Text, txtTelefoneDoLeitor.Text, txtEmailDoLeitor.Text, txtEnderecoDoLeitor.Text);

                try
                {
                    var bll = new LeitorBLL(servidor, banco, usuario, senha);
                    bll.IncluirLeitor(leitor);
                    txtIdentificacao.Text = bll.SelecionarUltimoIdLeitor().ToString();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message.ToString());
                }
            }

            else
                MessageBox.Show("Preencha os campos!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            // alteramos os dados do leitor que tem as credenciais correspondentes aos campos digitados
            if (txtIdentificacao.Text != "" && txtNomeDoLeitor.Text != "" && txtTelefoneDoLeitor.Text != "" && txtEnderecoDoLeitor.Text != "" && txtEmailDoLeitor.Text != "")
            {
                var leitor = new Leitor(int.Parse(txtIdentificacao.Text), txtNomeDoLeitor.Text, txtTelefoneDoLeitor.Text, txtEmailDoLeitor.Text, txtEnderecoDoLeitor.Text);

                try
                {
                    var bll = new LeitorBLL(servidor, banco, usuario, senha);
                    bll.AlterarLeitor(leitor);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }

            else
                MessageBox.Show("Preencha os campos!");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtIdentificacao.Text != "")
            {
                // excluimos o leitor baseado no ID em exibição
                var leitor = new Leitor(Convert.ToInt32(txtIdentificacao.Text), "", "", "", "");

                try
                {
                    var bll = new LeitorBLL(servidor, banco, usuario, senha);
                    bll.ExcluirLeitor(leitor);

                    txtIdentificacao.Text = "";
                    txtNomeDoLeitor.Text = "";
                    txtTelefoneDoLeitor.Text = "";
                    txtEmailDoLeitor.Text = "";
                    txtEnderecoDoLeitor.Text = "";
                }

                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }


            else
                MessageBox.Show("Preencha os campos!");
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            // exibimos os leitores ativos na segunda aba do tabPage
            try
            {
                var bll = new LeitorBLL(servidor, banco, usuario, senha);
                dgvLeitores.DataSource = bll.SelecionarLeitores(); // devolve a tabela dos dados

                dgvLeitores.Columns[0].HeaderText = "Identificação";
                dgvLeitores.Columns[1].HeaderText = "Nome";
                dgvLeitores.Columns[2].HeaderText = "Telefone";
                dgvLeitores.Columns[3].HeaderText = "Email";
                dgvLeitores.Columns[4].HeaderText = "Endereço";
            }

            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtNomeDoLeitor.Text != "")
            {
                // buscamos o leitor baseado no nome que está em exibição
                string nome = txtNomeDoLeitor.Text;
                var leitor = new Leitor(0, nome, "", "", "");

                try
                {
                    var bll = new LeitorBLL(servidor, banco, usuario, senha);
                    leitor = bll.ListarLeitorPorNome(leitor.NomeLeitor);
                    txtIdentificacao.Text = leitor.IdLeitor.ToString();
                    txtNomeDoLeitor.Text = leitor.NomeLeitor;
                    txtTelefoneDoLeitor.Text = leitor.TelefoneLeitor;
                    txtEmailDoLeitor.Text = leitor.EnderecoLeitor;
                    txtEnderecoDoLeitor.Text = leitor.EnderecoLeitor;
                }

                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }

            else
                MessageBox.Show("Preencha o campo de código!");
        }
    }
}
