/*
Keven Richard da Rocha Barreiros - 23143
Victor Yuji Mimura               - 23158
*/

using apBiblioteca.BLL;
using System;
using System.Data;
using System.Windows.Forms;

namespace apBiblioteca.UI
{
    public partial class FrmConsultas : Form
    {
        public string servidor, banco, usuario, senha;
        private DataTable emprestimos;

        public FrmConsultas()
        {
            InitializeComponent();
        }

        private void FrmConsultas_Load(object sender, System.EventArgs e)
        {
            // carregamos os emprestimos do BD no DataGridView
            try
            {
                var bll = new EmprestimoBLL(servidor, banco, usuario, senha);

                emprestimos = bll.SelecionarEmprestimos();

                dgvEmprestimos.DataSource = emprestimos;

                dgvEmprestimos.Columns[0].HeaderText = "Identificação";
                dgvEmprestimos.Columns[1].HeaderText = "Livro";
                dgvEmprestimos.Columns[2].HeaderText = "Leitor";
                dgvEmprestimos.Columns[3].HeaderText = "Data do Empréstimo";
                dgvEmprestimos.Columns[4].HeaderText = "Data Prevista";
                dgvEmprestimos.Columns[5].HeaderText = "Data de Devolução";
            }

            catch (Exception ex)
            {
                MessageBox.Show(" Erro : " + ex.Message.ToString());
            }
        }

        private void rbEntregues_CheckedChanged(object sender, System.EventArgs e)
        {
            // criamos um DataTable auxiliar que será um clone de emprestimos, visto que caso não seja,
            // aux.Rows.Add(linha.ItemArray) não funcionará por linha pertencer a outra tabela
            DataTable aux = emprestimos.Clone();

            dgvEmprestimos.DataSource = null;

            foreach (DataRow linha in emprestimos.Rows)
                if (linha[5].ToString() != "")
                    aux.Rows.Add(linha.ItemArray);

            dgvEmprestimos.DataSource = aux;
            dgvEmprestimos.Columns[0].HeaderText = "Identificação";
            dgvEmprestimos.Columns[1].HeaderText = "Livro";
            dgvEmprestimos.Columns[2].HeaderText = "Leitor";
            dgvEmprestimos.Columns[3].HeaderText = "Data do Empréstimo";
            dgvEmprestimos.Columns[4].HeaderText = "Data Prevista";
            dgvEmprestimos.Columns[5].HeaderText = "Data de Devolução";
        }

        private void rbAtrasados_CheckedChanged(object sender, System.EventArgs e)
        {
            // criamos um DataTable auxiliar que será um clone de emprestimos, visto que caso nã seja,
            // aux.Rows.Add(linha.ItemArray) não funcionará por linha pertencer a outra tabela
            DataTable aux = emprestimos.Clone();

            dgvEmprestimos.DataSource = null;

            foreach (DataRow linha in emprestimos.Rows)
            {
                if (linha[5].ToString() != "")
                {
                    var dataEmprestimoPrevisto = DateTime.Parse(linha[4].ToString());
                    var dataReal = DateTime.Parse(linha[5].ToString());

                    if (dataReal > dataEmprestimoPrevisto)
                        aux.Rows.Add(linha.ItemArray);
                }
            }

            dgvEmprestimos.DataSource = aux;
            dgvEmprestimos.Columns[0].HeaderText = "Identificação";
            dgvEmprestimos.Columns[1].HeaderText = "Livro";
            dgvEmprestimos.Columns[2].HeaderText = "Leitor";
            dgvEmprestimos.Columns[3].HeaderText = "Data do Empréstimo";
            dgvEmprestimos.Columns[4].HeaderText = "Data Prevista";
            dgvEmprestimos.Columns[5].HeaderText = "Data de Devolução";
        }

        private void rbPendentes_CheckedChanged(object sender, System.EventArgs e)
        {
            // criamos um DataTable auxiliar que será um clone de emprestimos, visto que caso nã seja,
            // aux.Rows.Add(linha.ItemArray) não funcionará por linha pertencer a outra tabela
            DataTable aux = emprestimos.Clone();

            dgvEmprestimos.DataSource = null;

            foreach (DataRow linha in emprestimos.Rows)
                if (linha[5].ToString() == "")
                    aux.Rows.Add(linha.ItemArray);

            dgvEmprestimos.DataSource = aux;
            dgvEmprestimos.Columns[0].HeaderText = "Identificação";
            dgvEmprestimos.Columns[1].HeaderText = "Livro";
            dgvEmprestimos.Columns[2].HeaderText = "Leitor";
            dgvEmprestimos.Columns[3].HeaderText = "Data do Empréstimo";
            dgvEmprestimos.Columns[4].HeaderText = "Data Prevista";
            dgvEmprestimos.Columns[5].HeaderText = "Data de Devolução";
        }
    }
}
