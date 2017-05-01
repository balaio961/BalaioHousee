using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class Contexto : DbContext
    {
        public Contexto():base("StringConexao")//chama a base na aplicação
        {
        }

        public DbSet<Marca> Marca { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Compra> Compra { get; set; }
    }
}
