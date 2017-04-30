namespace ControladorDePedidos.Model
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Marca Marca { get; set; } //produto tem uma marca composicao, produto possui uma marca
        public decimal ValorDeComra { get; set; }
        public decimal ValorDeVenda { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int QuantidadeMinimaEmEstoque { get; set; }
        public int QuantidadeDesejavelEmEstoque { get; set; }

    }
}
