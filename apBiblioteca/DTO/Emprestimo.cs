using System;

namespace DTO
{
    public class Emprestimo
    {
        int idEmprestimo;
        int idLivro;
        int idLeitor;
        DateTime dataEmprestimo;
        DateTime dataDevolucaoPrevista;
        DateTime dataDevolucaoReal;

        public Emprestimo(int idEmprestimo, int idLivro, int idLeitor, DateTime dataEmprestimo, DateTime dataDevolucaoPrevista, DateTime dataDevolucaoReal)
        {
            IdEmprestimo = idEmprestimo;
            IdLivro = idLivro;
            IdLeitor = idLeitor;
            DataEmprestimo = dataEmprestimo;
            DataDevolucaoPrevista = dataDevolucaoPrevista;
            DataDevolucaoReal = dataDevolucaoReal;
        }

        public int IdEmprestimo
        {
            get => idEmprestimo;
            set
            {
                if (value < 0)
                    throw new Exception("ID do emprestimo deve ser maior que 0");

                idEmprestimo = value;
            }
        }

        public int IdLivro
        {
            get => idLivro;
            set
            {
                if (value < 0)
                    throw new Exception("ID do livro deve ser maior que 0");

                idLivro = value;
            }
        }

        public int IdLeitor
        {
            get => idLeitor;
            set
            {
                if (value < 0)
                    throw new Exception("ID do leitor deve ser maior que 0");

                idLeitor = value;
            }
        }

        public DateTime DataEmprestimo
        {
            get => dataEmprestimo;
            set => dataEmprestimo = value;
        }

        public DateTime DataDevolucaoPrevista
        {
            get => dataDevolucaoPrevista;
            set => dataDevolucaoPrevista = value;
        }

        public DateTime DataDevolucaoReal
        {
            get => dataDevolucaoReal;
            set => dataDevolucaoReal = value;
        }
    }
}