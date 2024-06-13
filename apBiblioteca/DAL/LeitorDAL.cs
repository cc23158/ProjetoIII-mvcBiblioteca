// o campo desabilitado é um bit, de forma que 0 represente que o leitor está ativo, enquanto 1 inativo

using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class LeitorDAL
    {
        string _cadeiaDeConexao = "";
        SqlConnection _conexao = null;

        // pode dar erro caso User Id seja na verdade User id
        public LeitorDAL(string servidor, string banco, string usuario, string senha)
        {
            _cadeiaDeConexao = $"Data Source={servidor}; " +
                                $"Initial Catalog={banco}; " +
                                $"User Id={usuario}; " +
                                $"Password={senha};";

            _conexao = new SqlConnection(_cadeiaDeConexao);
        }

        public List<Leitor> SelectListLeitor()
        {
            try
            {
                var cmd = new SqlCommand("SELECT idLeitor, nomeLeitor, telefoneLeitor, emailLeitor, enderecoLeitor FROM mvc.Leitor WHERE desabilitado = 0 ", _conexao);
                _conexao.Open();
                var listaLeitores = new List<Leitor>();
                SqlDataReader dr = cmd.ExecuteReader(); // executa o comando cmd e recebe uma estrutura de dados com os resultados do comando

                while (dr.Read()) // lê os dados enquanto há resultados para serem lidos
                {
                    // o "" é necessário para que o objeto seja reconhecido como string
                    var leitor = new Leitor((int)dr["idLeitor"], dr["nomeLeitor"].ToString(), dr["telefoneLeitor"].ToString(), dr["emailLeitor"].ToString(), dr["enderecoLeitor"].ToString());
                    listaLeitores.Add(leitor);
                }

                _conexao.Close();
                return listaLeitores;
            }

            catch (Exception ex)
            {
                throw new Exception("Erro ao acessar leitor " + ex.Message);
            }
        }

        public int SelectUltimoIdLeitor()
        {
            try
            {
                int ultimoId = -1;
                var cmd = new SqlCommand("select MAX(idLeitor) as UltimoId from mvc.Leitor ", _conexao);
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
                throw new Exception("Erro ao acessar leitor " + ex.Message);
            }
        }

        public DataTable SelectLeitores()
        {
            try
            {
                string sql = "SELECT idLeitor, nomeLeitor, telefoneLeitor, emailLeitor, enderecoLeitor FROM mvc.Leitor WHERE desabilitado = 0 ";

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

        public Leitor SelectLeitorById(int idDesejado)
        {
            try
            {
                // crtiação do comando + adição do parâmetro no comando
                string sql = "SELECT idLeitor, nomeLeitor, telefoneLeitor, emailLeitor, enderecoLeitor FROM mvc.Leitor WHERE idLeitor = @id AND desabilitado = 0 ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", idDesejado);

                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Leitor leitor = null;

                if (dr.Read()) // lê os dados enquanto há dados para ler
                {
                    leitor = new Leitor((int)dr["idLeitor"],
                        dr["nomeLeitor"].ToString(), dr["telefoneLeitor"].ToString(),
                        dr["emailLeitor"].ToString(), dr["enderecoLeitor"].ToString());
                }

                //_conexao.Close();
                return leitor;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Leitor SelectLeitorByNome(string nome)
        {
            try
            {
                // crtiação do comando + adição do parâmetro no comando
                string sql = "SELECT idLeitor, nomeLeitor, telefoneLeitor, emailLeitor, enderecoLeitor FROM mvc.Leitor WHERE nomeLeitor = @nome AND desabilitado = 0 ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@nome", nome);

                _conexao.Open();
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                Leitor leitor = null;

                if (dr.Read()) // lê os dados enquanto há dados para ler
                {
                    leitor = new Leitor((int)dr["idLeitor"],
                        dr["nomeLeitor"].ToString(), dr["telefoneLeitor"].ToString(),
                        dr["emailLeitor"].ToString(), dr["enderecoLeitor"].ToString());
                }

                //_conexao.Close();
                return leitor;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertLeitor(Leitor leitor)
        {
            try
            {
                string sql = "INSERT INTO mvc.Leitor (nomeLeitor, telefoneLeitor, emailLeitor, enderecoLeitor, desabilitado) VALUES (@nome, @telefone, @email, @endereco, 0) ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);

                cmd.Parameters.AddWithValue("@nome", leitor.NomeLeitor);
                cmd.Parameters.AddWithValue("@telefone", leitor.TelefoneLeitor);
                cmd.Parameters.AddWithValue("@email", leitor.EmailLeitor);
                cmd.Parameters.AddWithValue("@endereco", leitor.EnderecoLeitor);

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

        public void DeleteLeitor(Leitor leitor)
        {
            try
            {
                // caso o leitor seja inativado e tenha um empréstimo em andamento, devolve o livro
                String sql = "UPDATE mvc.Leitor SET desabilitado = 1 WHERE idLeitor = @idLeitor ";
                String sql2 = "UPDATE mvc.Emprestimo SET dataDevolucaoReal = GETDATE() WHERE idLeitor = @idLeitor ";

                SqlCommand cmd = new SqlCommand(sql, _conexao);
                SqlCommand cmd2 = new SqlCommand(sql2, _conexao);

                cmd.Parameters.AddWithValue("@idLeitor", leitor.IdLeitor);
                cmd2.Parameters.AddWithValue("@idLeitor", leitor.IdLeitor);

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

        public void UpdateLeitor(Leitor leitor)
        {
            try
            {
                string sql = "UPDATE mvc.Leitor SET nomeLeitor = @nomeLeitor, telefoneLeitor = @telefoneLeitor, emailLeitor = @emailLeitor, enderecoLeitor = @enderecoLeitor WHERE idLeitor = @id ";
                SqlCommand cmd = new SqlCommand(sql, _conexao);
                cmd.Parameters.AddWithValue("@id", leitor.IdLeitor);
                cmd.Parameters.AddWithValue("@nomeLeitor", leitor.NomeLeitor);
                cmd.Parameters.AddWithValue("@telefoneLeitor", leitor.TelefoneLeitor);
                cmd.Parameters.AddWithValue("@emailLeitor", leitor.EmailLeitor);
                cmd.Parameters.AddWithValue("@enderecoLeitor", leitor.EnderecoLeitor);

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