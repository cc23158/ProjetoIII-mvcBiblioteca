/*
Keven Richard da Rocha Barreiros - 23143
Victor Yuji Mimura               - 23158
*/

// https://www.w3schools.com/sql/func_sqlserver_datediff.asp -> 93

using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class EmprestimoDAL
    {
        string _cadeiaDeConexao = "";
        SqlConnection _conexao = null;

        // pode dar erro caso User Id seja na verdade User id
        public EmprestimoDAL(string servidor, string banco, string usuario, string senha)
        {
            _cadeiaDeConexao = $"Data Source={servidor}; " +
                                $"Initial Catalog={banco}; " +
                                $"User Id={usuario}; " +
                                $"Password={senha};";

            _conexao = new SqlConnection(_cadeiaDeConexao);
        }

        public List<Emprestimo> SelectListEmprestimos()
        {
            try
            {
                var cmd = new SqlCommand("Select * from mvc.Emprestimo ", _conexao);
                _conexao.Open();
                var listaEmprestimos = new List<Emprestimo>();
                SqlDataReader dr = cmd.ExecuteReader(); // executa o comando cmd e recebe uma estrutura de dados com os resultados do comando

                while (dr.Read()) // lê os dados enquanto há resultados para serem lidos
                {
                    var emprestimo = new Emprestimo((int)dr["idEmprestimo"], (int)dr["idLivro"], (int)dr["idLeitor"],
                        Convert.ToDateTime(dr["dataEmprestimo"]), Convert.ToDateTime(dr["dataDevolucaoPrevista"]),
                        Convert.ToDateTime(dr["dataDevolucaoReal"]));
                    listaEmprestimos.Add(emprestimo);
                }

                _conexao.Close();
                return listaEmprestimos;
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar emprestimo: " + ex.Message);
            }
        }

        public DataTable SelectEmprestimos()
        {
            try
            {
                string sql = "SELECT * FROM mvc.Emprestimo ";

                // obj de comando baseado no comando TSQL bruto acima
                SqlCommand executorDeComandosSQL = new SqlCommand(sql, _conexao);

                _conexao.Open();

                // adapta os dados ao comando, no caso, o comando é adaptado ao tipo SELECT
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = executorDeComandosSQL;

                // pega os tipos de dados que serão retornados e preenche essa tabela (dt) com os dados obtidos pelo comando
                DataTable dt = new DataTable();
                da.Fill(dt);

                _conexao.Close();

                return dt; // retorna a tabela com todos os dados obtidos pelo comando
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectAtrasadas()
        {
            try
            {
                string sql = "SELECT * FROM mvc.Emprestimo where DATEDIFF(day, dataDevolucaoPrevista, dataDevolucaoReal) > 0 ";

                // obj de comando baseado no comando TSQL bruto acima
                SqlCommand executorDeComandosSQL = new SqlCommand(sql, _conexao);

                _conexao.Open();

                // adapta os dados ao comando, no caso, o comando é adaptado ao tipo SELECT
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = executorDeComandosSQL;

                // pega os tipos de dados que serão retornados e preenche essa tabela (dt) com os dados obtidos pelo comando
                DataTable dt = new DataTable();
                da.Fill(dt);

                _conexao.Close();

                return dt; // retorna a tabela com todos os dados obtidos pelo comando
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelecionarPendentes()
        {
            try
            {
                string sql = "SELECT * FROM mvc.Emprestimo where dataDevolucaoReal IS NULL ";

                // obj de comando baseado no comando TSQL bruto acima
                SqlCommand executorDeComandosSQL = new SqlCommand(sql, _conexao);

                _conexao.Open();

                // adapta os dados ao comando, no caso, o comando é adaptado ao tipo SELECT
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = executorDeComandosSQL;

                // pega os tipos de dados que serão retornados e preenche essa tabela (dt) com os dados obtidos pelo comando
                DataTable dt = new DataTable();
                da.Fill(dt);

                _conexao.Close();

                return dt; // retorna a tabela com todos os dados obtidos pelo comando
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Emprestimo> SelectListEmprestimosByLeitor(int idLeitor)
        {
            try
            {
                var cmd = new SqlCommand("Select * from mvc.Emprestimo where idLeitor = @idLeitor", _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", idLeitor);
                _conexao.Open();
                var listaEmprestimos = new List<Emprestimo>();
                SqlDataReader dr = cmd.ExecuteReader(); // executa o comando cmd e recebe uma estrutura de dados com os resultados do comando

                while (dr.Read()) // lê os dados enquanto há resultados para serem lidos
                {
                    var emprestimo = new Emprestimo((int)dr["idEmprestimo"], (int)dr["idLivro"], (int)dr["idLeitor"],
                        Convert.ToDateTime(dr["dataEmprestimo"]), Convert.ToDateTime(dr["dataDevolucaoPrevista"]),
                        Convert.ToDateTime(dr["dataDevolucaoReal"]));
                    listaEmprestimos.Add(emprestimo);
                }

                _conexao.Close();
                return listaEmprestimos;
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar emprestimo: " + ex.Message);
            }
        }

        public int SelectUltimoIdEmprestimo()
        {
            try
            {
                int ultimoId = -1;
                var cmd = new SqlCommand("select MAX(idEmprestimo) as UltimoId from mvc.Emprestimo ", _conexao);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    ultimoId = Convert.ToInt32(dr["UltimoId"]);

                _conexao.Close();
                return ultimoId;
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar leitor " + ex.Message);
            }
        }

        public List<Emprestimo> SelectListEmprestimosByLivro(int idLivro)
        {
            try
            {
                var cmd = new SqlCommand("Select * from mvc.Emprestimo where idLivro = @idLivro", _conexao);
                cmd.Parameters.AddWithValue("@idLivro", idLivro);
                _conexao.Open();
                var listaEmprestimos = new List<Emprestimo>();
                SqlDataReader dr = cmd.ExecuteReader(); // executa o comando cmd e recebe uma estrutura de dados com os resultados do comando

                while (dr.Read()) // lê os dados enquanto há resultados para serem lidos
                {
                    var emprestimo = new Emprestimo((int)dr["idEmprestimo"], (int)dr["idLivro"], (int)dr["idLeitor"],
                        Convert.ToDateTime(dr["dataEmprestimo"]), Convert.ToDateTime(dr["dataDevolucaoPrevista"]),
                        Convert.ToDateTime(dr["dataDevolucaoReal"]));
                    listaEmprestimos.Add(emprestimo);
                }

                _conexao.Close();
                return listaEmprestimos;
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar emprestimo: " + ex.Message);
            }
        }

        public Emprestimo SelectEmprestimoByIds(int idLivro, int idLeitor)
        {
            try
            {
                // crtiação do comando + adição do parâmetro no comando
                string sql = "SELECT * FROM mvc.Emprestimo WHERE idLivro = @idLivro AND  idLeitor = @idLeitor AND dataDevolucaoReal IS NULL ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", idLivro);
                cmd.Parameters.AddWithValue("@idLeitor", idLeitor);

                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Emprestimo emprestimo = null;

                if (dr.Read()) // lê os dados enquanto há dados para ler
                {
                    emprestimo = new Emprestimo(Convert.ToInt32(dr["idEmprestimo"]),
                                    idLivro,
                                    idLeitor,
                                    Convert.ToDateTime(dr["dataEmprestimo"]),
                                    Convert.ToDateTime(dr["dataDevolucaoPrevista"]),
                                    default(DateTime));
                }

                // se não foi encontrado nenhum empréstimo ativo entre o leitor e o livro
                else
                {
                    throw new Exception("Falha ao tentar acessar empréstimo inexistente");
                }

                //_conexao.Close();
                return emprestimo;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                if (NumeroDeLivrosDoLeitor(emprestimo.IdLeitor) == 5)
                    throw new Exception("Um leitor pode ter, no máximo, 5 livros em sua posse");

                if (EstaEmprestado(emprestimo.IdLivro))
                    throw new Exception("O livro já está emprestado, tente novamente mais tarde");


                string sql = "INSERT INTO mvc.Emprestimo (idLivro, idLeitor, dataEmprestimo, dataDevolucaoPrevista, dataDevolucaoReal) VALUES (@idLivro, @idLeitor, @dataEmprestimo, @dataDevolucaoPrevista, NULL)";
                SqlCommand cmd = new SqlCommand(sql, _conexao);

                cmd.Parameters.AddWithValue("@idLivro", emprestimo.IdLivro);
                cmd.Parameters.AddWithValue("@idLeitor", emprestimo.IdLeitor);
                cmd.Parameters.AddWithValue("@dataEmprestimo", emprestimo.DataEmprestimo);
                cmd.Parameters.AddWithValue("@dataDevolucaoPrevista", emprestimo.DataDevolucaoPrevista);

                _conexao.Open();
                cmd.ExecuteNonQuery(); // executa um comando que não é um SELECT
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _conexao.Close();
            }
        }

        public void DeleteEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                String sql = "DELETE FROM mvc.Emprestimo WHERE idEmprestimo = @idEmprestimo ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idEmprestimo", emprestimo.IdEmprestimo);

                _conexao.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _conexao.Close();
            }
        }

        public void UpdateEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                string sql = "UPDATE mvc.Emprestimo SET dataDevolucaoReal = GETDATE() WHERE idEmprestimo = @idEmprestimo";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idEmprestimo", emprestimo.IdEmprestimo);

                _conexao.Open();
                cmd.ExecuteNonQuery(); // executa um comando que não é um SELECT
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                _conexao.Close();
            }
        }

        public int NumeroDeLivrosDoLeitor(int idLeitor)
        {
            try
            {
                int qtsLivros = -1;
                string sql = "SELECT COUNT(*) as livros FROM mvc.Emprestimo where idLeitor = @idLeitor AND dataDevolucaoReal IS NULL ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLeitor", idLeitor);

                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    qtsLivros = Convert.ToInt32(dr["livros"]);

                _conexao.Close();
                return qtsLivros;
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar leitor " + ex.Message);
            }
        }

        public bool EstaEmprestado(int idLivro)
        {
            try
            {
                bool estaEmprestado = false;
                string sql = "SELECT COUNT(*) as emprestado FROM mvc.Emprestimo where idLivro = @idLivro AND dataDevolucaoReal IS NULL ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", idLivro);

                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                    // está emprestado no momento
                    if (Convert.ToInt32(dr["emprestado"]) == 1)
                        estaEmprestado = true;

                _conexao.Close();
                return estaEmprestado;
            }

            catch(Exception ex)
            {
                throw new Exception("Erro ao acessar leitor " + ex.Message);
            }
        }
    }
}