using DTO;
using apBiblioteca.BLL;
using System;
using System.Windows.Forms;

namespace apBiblioteca.UI
{
    public partial class FrmLivro : Form
    {
        public string servidor, banco, usuario, senha;

        public FrmLivro()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtCodigoDoLivro.Text != "" && txtTituloDoLivro.Text != "" && txtAutorDoLivro.Text != "")
            {
                var livro = new Livro(0, txtCodigoDoLivro.Text, txtTituloDoLivro.Text, txtAutorDoLivro.Text);

                try
                {
                    var bll = new LivroBLL(servidor, banco, usuario, senha);
                    bll.IncluirLivro(livro);
                    txtIdentificacao.Text = bll.SelecionarUltimoIdLivro().ToString();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(" Erro : " + ex.Message.ToString());
                }
            }

            else
                MessageBox.Show("Preencha os campos!");
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtCodigoDoLivro.Text != "" && txtTituloDoLivro.Text != "" && txtAutorDoLivro.Text != "")
            {
                var livro = new Livro(int.Parse(txtIdentificacao.Text), txtCodigoDoLivro.Text, txtTituloDoLivro.Text, txtAutorDoLivro.Text);

                try
                {
                    var bll = new LivroBLL(servidor, banco, usuario, senha);
                    bll.AlterarLivro(livro);
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
            if (txtCodigoDoLivro.Text != "" && txtTituloDoLivro.Text != "" && txtAutorDoLivro.Text != "")
            {
                var livro = new Livro(Convert.ToInt32(txtIdentificacao.Text), "", "", "");

                try
                {
                    var bll = new LivroBLL(servidor, banco, usuario, senha);
                    bll.ExcluirLivro(livro);

                    txtIdentificacao.Text = "";
                    txtCodigoDoLivro.Text = "";
                    txtTituloDoLivro.Text = "";
                    txtAutorDoLivro.Text = "";
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
            try
            {
                var bll = new LivroBLL(servidor, banco, usuario, senha);
                dgvLivros.DataSource = bll.SelecionarLivros(); // devolve a tabela dos dados

                dgvLivros.Columns[0].HeaderText = "Identificação";
                dgvLivros.Columns[1].HeaderText = "Código";
                dgvLivros.Columns[2].HeaderText = "Título";
                dgvLivros.Columns[3].HeaderText = "Autor(es)";
            }

            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (txtCodigoDoLivro.Text != "")
            {
                string codigo = txtCodigoDoLivro.Text;
                var livro = new Livro(0, codigo, "", "");

                try
                {
                    var bll = new LivroBLL(servidor, banco, usuario, senha);
                    livro = bll.ListarLivroPorCodigo(codigo);
                    txtIdentificacao.Text = livro.IdLivro.ToString();
                    txtCodigoDoLivro.Text = livro.CodigoLivro;
                    txtTituloDoLivro.Text = livro.TituloLivro;
                    txtAutorDoLivro.Text = livro.AutorLivro;
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
