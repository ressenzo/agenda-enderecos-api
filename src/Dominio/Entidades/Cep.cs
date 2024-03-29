using System.Text.RegularExpressions;

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
        public string IdUsuario { get; private set; }

        public Cep(string valor,
            string nome,
            string logradouro,        
            string bairro,
            string cidade,
            string uf,
            string idUsuario
            )
        {
            ValidarValor(valor);
            ValidarString(nome, "Nome do CEP inválido.");
            ValidarString(logradouro, "Logradouro do CEP inválido.");
            ValidarString(bairro, "Bairro do CEP inválido.");
            ValidarString(cidade, "Cidade do CEP inválido.");
            ValidarString(uf, "UF do CEP inválido.");
            ValidarString(idUsuario, "Id do Usuário inválido");

            Valor = valor;
            Nome = nome;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Uf = uf;
            IdUsuario = idUsuario;
        }

        private void ValidarValor(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor) ||
                valor.Length != 9 ||
                !Regex.IsMatch(valor, ("[0-9]{5}-[0-9]{3}"))
                )
            {
                AdicionarMensagem("Valor do CEP inválido.");
            }
        }
    }
}
