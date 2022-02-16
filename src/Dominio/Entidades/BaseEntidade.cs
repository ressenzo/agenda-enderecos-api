using System.Collections.Generic;

namespace Dominio.Entidades
{
    public abstract class BaseEntidade
    {
        public int Id { get; set; }

        public List<string> Mensagens { get; private set; } = new List<string>();

        public bool Valida
        {
            get
            {
                return Mensagens.Count == 0;
            }
        }

        protected void AdicionarMensagem(string mensagem)
        {
            Mensagens.Add(mensagem);
        }

        protected void ValidarString(string valor, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                AdicionarMensagem(mensagem);
            }
        }  
    }
}
