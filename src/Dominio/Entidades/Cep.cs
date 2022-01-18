using System.Linq;

namespace Dominio.Entidades
{
    public class Cep : BaseEntidade
    {
        public string Valor { get; private set; }
        public string Nome { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }

        public Cep(string valor,
            string nome,
            string logradouro,        
            string bairro,
            string cidade,
            string uf
            )
        {
            ValidarValor(valor);
            ValidarString(nome, "Nome do CEP inválido.");
            ValidarString(logradouro, "Logradouro do CEP inválido.");
            ValidarString(bairro, "Bairro do CEP inválido.");
            ValidarString(cidade, "Cidade do CEP inválido.");
            ValidarString(uf, "Uf do CEP inválido.");

            Valor = valor;
            Nome = nome;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
        }

        private void ValidarValor(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) ||
                valor.Any(x => !char.IsDigit(x)) ||
                valor.Length != 9
                )
            {
                AdicionarMensagem("Valor do CEP inválido");
            }
        }      

        private void ValidarString(string valor, string mensagem)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                AdicionarMensagem(mensagem);
            }
        }  
    }
}
