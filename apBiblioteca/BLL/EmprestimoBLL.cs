using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace apBiblioteca.BLL
{
    public class EmprestimoBLL
    {
        public string servidor, banco, usuario, senha;
        EmprestimoDAL dal = null;

        public EmprestimoBLL(string servidor, string banco, string usuario, string senha)
        {
            this.servidor = servidor;
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public int SelecionarUltimoIdEmprestimo()
        {
            int ultimoId = -1;

            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                ultimoId = dal.SelectUltimoIdEmprestimo();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return ultimoId;
        }

        public DataTable SelecionarEmprestimos()
        {
            DataTable tb = new DataTable();

            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                tb = dal.SelectEmprestimos();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return tb;
        }

        public DataTable SelecionarAtrasadas()
        {
            DataTable tb = new DataTable();

            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                tb = dal.SelectAtrasadas();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return tb;
        }

        public DataTable SelecionarPendentes()
        {
            DataTable tb = new DataTable();

            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                tb = dal.SelecionarPendentes();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return tb;
        }

        public void IncluirEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                dal.InsertEmprestimo(emprestimo);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                dal.UpdateEmprestimo(emprestimo);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirEmprestimo(Emprestimo emprestimo)
        {
            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                dal.DeleteEmprestimo(emprestimo);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Emprestimo SelectEmprestimoByIds(int idLivro, int idLeitor)
        {
            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                return dal.SelectEmprestimoByIds(idLivro, idLeitor);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Emprestimo> ListarEmprestimoPorLeitor(Leitor leitor)
        {
            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                return dal.SelectListEmprestimosByLeitor(leitor.IdLeitor);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public System.Collections.Generic.List<Emprestimo> ListarEmprestimoPorLivro(Livro livro)
        {
            try
            {
                dal = new EmprestimoDAL(servidor, banco, usuario, senha);
                return dal.SelectListEmprestimosByLivro(livro.IdLivro);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
