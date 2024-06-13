using System;

namespace DTO
{
    public class Leitor
    {
        const int tamanhoNome = 50;
        const int tamanhoTelefone = 20;
        const int tamanhoEmail = 50;
        const int tamanhoEndereco = 100;

        int idLeitor;
        string nomeLeitor;
        string telefoneLeitor;
        string emailLeitor;
        string enderecoLeitor;

        public Leitor(int idLeitor, string nomeLeitor, string telefoneLeitor, string emailLeitor, string enderecoLeitor)
        {
            IdLeitor = idLeitor;
            NomeLeitor = nomeLeitor;
            TelefoneLeitor = telefoneLeitor;
            EmailLeitor = emailLeitor;
            EnderecoLeitor = enderecoLeitor;
        }

        public int IdLeitor
        {
            get => idLeitor;
            set
            {
                if (value < 0)
                    throw new Exception("ID negativo é inválido");

                idLeitor = value;
            }
        }

        public string NomeLeitor
        {
            get => nomeLeitor;
            set => nomeLeitor = value.PadRight(tamanhoNome, ' ').Substring(0, tamanhoNome);
        }

        public string TelefoneLeitor
        {
            get => telefoneLeitor;
            set => telefoneLeitor = value.PadRight(tamanhoTelefone, ' ').Substring(0, tamanhoTelefone);
        }

        public string EmailLeitor
        {
            get => emailLeitor;
            set => emailLeitor = value.PadRight(tamanhoEmail, ' ').Substring(0, tamanhoEmail);
        }

        public string EnderecoLeitor
        {
            get => enderecoLeitor;
            set => enderecoLeitor = value.PadRight(tamanhoEndereco, ' ').Substring(0, tamanhoEndereco);
        }
    }
}