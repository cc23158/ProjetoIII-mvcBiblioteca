// o campo desabilitado é um bit, de forma que 0 represente que o livro está ativo, enquanto 1 inativo

using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LivroDAL
    {
        string _cadeiaDeConexao = "";
        SqlConnection _conexao = null;

        // pode dar erro caso User Id seja na verdade User id
        public LivroDAL(string servidor, string banco, string usuario, string senha)
        {
            _cadeiaDeConexao = $"Data Source={servidor}; " +
                                $"Initial Catalog={banco}; " +
                                $"User Id={usuario}; " +
                                $"Password={senha};";

            _conexao = new SqlConnection(_cadeiaDeConexao);
        }

        public int SelectUltimoIdLivro()
        {
            try
            {
                int ultimoId = -1;
                var cmd = new SqlCommand("select MAX(idLivro) as UltimoId from mvc.Livro ", _conexao);
                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    ultimoId = Convert.ToInt32(dr["UltimoId"]);
                }

                _conexao.Close();
                return ultimoId;
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar livro " + ex.Message);
            }
        }

        public List<Livro> SelectListLivro()
        {
            try
            {
                var cmd = new SqlCommand("SELECT idLivro, codigoLivro, tituloLivro, autorLivro FROM mvc.Livro WHERE desabilitado = 0 ", _conexao);
                _conexao.Open();
                var listaLivros = new List<Livro>();
                SqlDataReader dr = cmd.ExecuteReader(); // executa o comando cmd e recebe uma estrutura de dados com os resultados do comando

                while (dr.Read()) // lê os dados enquanto há resultados para serem lidos
                {
                    // o "" é necessário para que o objeto seja reconhecido como string
                    var livro = new Livro((int)dr["idLivro"], dr["codigoLivro"] + "", dr["tituloLivro"].ToString(), Convert.ToString(dr["autorLivro"]));
                    listaLivros.Add(livro);
                }

                _conexao.Close();
                return listaLivros;
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar livro " + ex.Message);
            }
        }

        public DataTable SelectLivros()
        {
            try
            {
                string sql = "SELECT idLivro, codigoLivro, tituloLivro, autorLivro FROM mvc.Livro WHERE desabilitado = 0 ";

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

        public Livro SelectLivroById(int idDesejado)
        {
            try
            {
                // crtiação do comando + adição do parâmetro no comando
                string sql = "SELECT idLivro, codigoLivro, tituloLivro, autorLivro FROM mvc.Livro WHERE idLivro = @id AND desabilitado = 0 ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", idDesejado);

                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Livro livro = null;

                if (dr.Read()) // lê os dados enquanto há dados para ler
                {
                    livro = new Livro(Convert.ToInt32(dr["idLivro"]),
                                    dr["codigoLivro"].ToString(),
                                    dr["tituloLivro"].ToString(),
                                    dr["autorLIvro"].ToString());
                }

                //_conexao.Close();
                return livro;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Livro SelectLivroByCodigo(string codigoDesejado)
        {
            try
            {
                string sql = " SELECT idLivro, codigoLivro, tituloLivro, autorLivro FROM mvc.Livro WHERE codigoLivro = @codigo AND desabilitado = 0 ";
                var cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@codigo", codigoDesejado);

                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Livro livro = null;

                if (dr.Read())
                    livro = new Livro(Convert.ToInt32(dr["idLivro"]),
                                      dr["codigoLivro"].ToString(),
                                      dr["tituloLivro"].ToString(),
                                      dr["autorLivro"].ToString());

                //_conexao.Close();
                return livro;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertLivro(Livro qualLivro)
        {
            try
            {
                string sql = "INSERT INTO mvc.Livro (codigoLivro, tituloLivro, autorLivro, desabilitado) VALUES (@codigo, @titulo, @autor, 0) ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);

                cmd.Parameters.AddWithValue("@codigo", qualLivro.CodigoLivro);
                cmd.Parameters.AddWithValue("@titulo", qualLivro.TituloLivro);
                cmd.Parameters.AddWithValue("@autor", qualLivro.AutorLivro);

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

        public void DeleteLivro(Livro qualLivro)
        {
            try
            {
                // caso o livro seja inativado e tenha um empréstimo em andamento, devolve o livro
                String sql = "UPDATE mvc.Livro SET desabilitado = 1 WHERE idLIvro = @idLivro ";
                String sql2 = "UPDATE mvc.Emprestimo SET dataDevolucaoReal = GETDATE() WHERE idLivro = @idLivro ";

                SqlCommand cmd = new SqlCommand(sql, _conexao);
                SqlCommand cmd2 = new SqlCommand(sql2, _conexao);

                cmd.Parameters.AddWithValue("@idLivro", qualLivro.IdLivro);
                cmd2.Parameters.AddWithValue("@idLivro", qualLivro.IdLivro);

                _conexao.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
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

        public void UpdateLivro(Livro qualLivro)
        {
            try
            {
                string sql = "UPDATE mvc.Livro SET tituloLivro= @titulo, codigoLivro=@codigo, autorLivro=@autor WHERE idLivro = @idLivro ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@idLivro", qualLivro.IdLivro);
                cmd.Parameters.AddWithValue("@codigo", qualLivro.CodigoLivro);
                cmd.Parameters.AddWithValue("@titulo", qualLivro.TituloLivro);
                cmd.Parameters.AddWithValue("@autor", qualLivro.AutorLivro);

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
    }
}