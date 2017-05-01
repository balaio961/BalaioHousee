using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for formCadastroDeUsuario.xaml
    /// </summary>
    public partial class formCadastroDeUsuario : Window
    {
        public formCadastroDeUsuario()
        {
            InitializeComponent();
            this.DataContext = new Usuario();
        }

        public formCadastroDeUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.DataContext = usuario;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            var usuario = (Usuario)this.DataContext;
            var repositorio = new RepositorioUsuario();
            if (usuario.Codigo == 0)
            {

                //adiciona novo usuario
                repositorio.Adicione(usuario);
            }
            else
            {
                //Editando
                
                repositorio.Atualize(usuario);
            }

            this.Close();
            //salvar no banco de dados
        }

      
    }


}

