using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for formCadastroDeProduto.xaml
    /// </summary>
    public partial class formCadastroDeProduto : Window
    {
        RepositorioMarca repositorioMarca;
        RepositorioProduto repositorioProduto;

        public formCadastroDeProduto()
        {
            repositorioMarca = new RepositorioMarca();
            repositorioProduto = new RepositorioProduto();
            InitializeComponent();
            this.DataContext = new Produto();
        }

        public formCadastroDeProduto(Produto produto)
        {
            repositorioMarca = new RepositorioMarca();
            repositorioProduto = new RepositorioProduto();
            InitializeComponent();
            this.DataContext = produto;
            cmbMarcas.SelectedValue = produto.Marca.Codigo;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var marcas = repositorioMarca.Liste();
            cmbMarcas.DataContext = marcas;
            
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            //faz cast dizendo que é um produto
            var produto = (Produto)this.DataContext;
            if(cmbMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione uma marca");
            }
            else
            {
                produto.Marca = (Marca)cmbMarcas.SelectedItem;
            }

            if(produto.Codigo == 0)
            {
                //cadastro
                repositorioProduto.Adicione(produto);
            }
            else
            {
                //atualizacao
                repositorioProduto.Atualize(produto);
            }
            this.Close();
        }
    }
}
