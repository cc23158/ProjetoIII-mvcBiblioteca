/*
Keven Richard da Rocha Barreiros - 23143
Victor Yuji Mimura               - 23158
*/

using System;

namespace DTO
{
    public class Livro
    {
        const int tamanhoCodigo = 6;
        const int tamanhoTitulo = 50;
        const int tamanhoAutor = 50;

        int idLivro;
        string codigoLivro;
        string tituloLivro;
        string autorLivro;

        public Livro(int id, string codigo, string titulo, string autor)
        {
            IdLivro = id;
            CodigoLivro = codigo;
            TituloLivro = titulo;
            AutorLivro = autor;
        }

        public int IdLivro
        {
            get => idLivro;
            set
            {
                if (value < 0)
                    throw new Exception("ID negativo é inválido");

                idLivro = value;
            }
        }

        public string CodigoLivro
        {
            get => codigoLivro;
            set => codigoLivro = value.PadLeft(tamanhoCodigo, '0').Substring(0, tamanhoCodigo);
        }

        public string TituloLivro
        {
            get => tituloLivro;
            set => tituloLivro = value.PadRight(tamanhoTitulo, ' ').Substring(0, tamanhoTitulo);
        }

        public string AutorLivro
        {
            get => autorLivro;
            set => autorLivro = value.PadRight(tamanhoAutor, ' ').Substring(0, tamanhoAutor);
        }
    }
}
