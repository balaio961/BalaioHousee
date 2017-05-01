using System.ComponentModel.DataAnnotations;

namespace ControladorDePedidos.Model
{
    public class Cliente
    {
        [Key]
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
