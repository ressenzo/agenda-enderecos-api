using System.Collections.Generic;

namespace Dominio.Entidades
{
    public abstract class BaseEntidade
    {
        public int Id { get; set; }

        private List<string> Mensagens { get; set; } = new List<string>();

        public bool Valida
        {
            get
            {
                return Mensagens.Count > 0;
            }
        }

        protected void AdicionarMensagem(string mensagem)
        {
            Mensagens.Add(mensagem);
        }
    }
}
