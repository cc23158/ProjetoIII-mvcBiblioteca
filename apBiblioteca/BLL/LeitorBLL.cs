using DAL;
using DTO;
using System;
using System.Data;

namespace apBiblioteca.BLL
{
    public class LeitorBLL
    {
        public string servidor, banco, usuario, senha;
        LeitorDAL dal = null;

        public LeitorBLL(string servidor, string banco, string usuario, string senha)
        {
            this.servidor = servidor;
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public int SelecionarUltimoIdLeitor()
        {
            int ultimoId = -1;

            try
            {
                dal = new LeitorDAL(servidor, banco, usuario, senha);
                ultimoId = dal.SelectUltimoIdLeitor();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return ultimoId;
        }

        public DataTable SelecionarLeitores()
        {
            DataTable tb = new DataTable();

            try
            {
                dal = new LeitorDAL(servidor, banco, usuario, senha);
                tb = dal.SelectLeitores();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return tb;
        }

        public void IncluirLeitor(Leitor leitor)
        {
            try
            {
                dal = new LeitorDAL(servidor, banco, usuario, senha);
                dal.InsertLeitor(leitor);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarLeitor(Leitor leitor)
        {
            try
            {
                dal = new LeitorDAL(servidor, banco, usuario, senha);
                dal.UpdateLeitor(leitor);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLeitor(Leitor leitor)
        {
            try
            {
                dal = new LeitorDAL(servidor, banco, usuario, senha);
                dal.DeleteLeitor(leitor);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Leitor ListarLeitorPorId(int id)
        {
            try
            {
                dal = new LeitorDAL(servidor, banco, usuario, senha);
                return dal.SelectLeitorById(id);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Leitor ListarLeitorPorNome(string nome)
        {
            try
            {
                dal = new LeitorDAL(servidor, banco, usuario, senha);
                return dal.SelectLeitorByNome(nome);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
