/*
Keven Richard da Rocha Barreiros - 23143
Victor Yuji Mimura               - 23158
*/

using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;

namespace apBiblioteca.BLL
{
    public class LivroBLL
    {
        public string servidor, banco, usuario, senha;
        LivroDAL dal = null;

        public LivroBLL(string servidor, string banco, string usuario, string senha)
        {
            this.servidor = servidor;
            this.banco = banco;
            this.usuario = usuario;
            this.senha = senha;
        }

        public int SelecionarUltimoIdLivro()
        {
            int ultimoId = -1;

            try
            {
                dal = new LivroDAL(servidor, banco, usuario, senha);
                ultimoId = dal.SelectUltimoIdLivro();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return ultimoId;
        }

        public DataTable SelecionarLivros()
        {
            DataTable tb = new DataTable();

            try
            {
                dal = new LivroDAL(servidor, banco, usuario, senha);
                tb = dal.SelectLivros();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return tb;
        }

        public List<Livro> SelectListLivro()
        {
            List<Livro> livros = new List<Livro>();

            try
            {
                dal = new LivroDAL(servidor, banco, usuario, senha);
                livros = dal.SelectListLivro();
            }

            catch (Exception ex)
            {
                throw ex;
            }

            return livros;
        }

        public void IncluirLivro(Livro livro)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                dal.InsertLivro(livro);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AlterarLivro(Livro livro)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                dal.UpdateLivro(livro);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirLivro(Livro livro)
        {
            try
            {
                dal = new DAL.LivroDAL(servidor, banco, usuario, senha);
                dal.DeleteLivro(livro);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Livro ListarLivroPorId(int id)
        {
            try
            {
                dal = new LivroDAL(servidor, banco, usuario, senha);
                return dal.SelectLivroById(id);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Livro ListarLivroPorCodigo(string codigo)
        {
            try
            {
                dal = new LivroDAL(servidor, banco, usuario, senha);
                return dal.SelectLivroByCodigo(codigo);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
