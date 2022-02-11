namespace Api.Models
{
    public class RetornoListaModel
    {
        public int Tamanho { get; set; } = 0;

        protected void AdicionarTamanho()
        {
            Tamanho++;
        }
    }
}
