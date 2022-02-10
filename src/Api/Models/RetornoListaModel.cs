namespace Api.Models
{
    public class RetornoListaModel
    {
        public object Valor { get; }
        public int Tamanho { get; set; }

        public RetornoListaModel(object valor,
            int tamanho
        )
        {
            Valor = valor;
            Tamanho = tamanho;
        }
    }
}
