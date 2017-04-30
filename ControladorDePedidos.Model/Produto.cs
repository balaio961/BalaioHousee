using System.ComponentModel.DataAnnotations;

namespace ControladorDePedidos.Model
{
    public class Produto
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public virtual Marca Marca { get; set; } //produto tem uma marca composicao, produto possui uma marca, pode reescrever tambem 
        public decimal ValorDeCompra { get; set; }
        public decimal ValorDeVenda { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public int QuantidadeMinimaEmEstoque { get; set; }
        public int QuantidadeDesejavelEmEstoque { get; set; }

    }
}
