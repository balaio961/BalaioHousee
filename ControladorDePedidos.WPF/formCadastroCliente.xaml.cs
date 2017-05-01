using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for formCadastroCliente.xaml
    /// </summary>
    public partial class formCadastroCliente : Window
    {
        public formCadastroCliente()
        {
            InitializeComponent();
            this.DataContext = new Cliente();
        }

        public formCadastroCliente(Cliente cliente)
        {
            InitializeComponent();
            this.DataContext = cliente;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var cliente = (Cliente)this.DataContext;
            var repositorio = new RepositorioCliente();
            if (cliente.Codigo == 0)
            {

                //adiciona novo cliente
                repositorio.Adicione(cliente);
            }
            else
            {
                //Editando

                repositorio.Atualize(cliente);
            }

            this.Close();
            //salvar no banco de dados
        }
    }
}
