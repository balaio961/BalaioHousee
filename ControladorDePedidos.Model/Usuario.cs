using System.ComponentModel.DataAnnotations;

namespace ControladorDePedidos.Model
{
    public class Usuario
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public bool Administrador { get; set; }
        public bool Clientes { get; set; }
        public bool Produtos { get; set; }
        public bool Vendas { get; set; }
        public bool Fornecedores { get; set; }
        public bool Compras { get; set; }
    }
}
