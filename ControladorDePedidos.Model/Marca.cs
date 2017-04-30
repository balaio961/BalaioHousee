using System.ComponentModel.DataAnnotations;

namespace ControladorDePedidos.Model
{
    public class Marca
    {
        [Key]
        public int  Codigo { get; set; }
        public string Nome { get; set; }
    }
}
