using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Collections.Generic;
using System.Windows;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for formMarcas.xaml
    /// </summary>
    public partial class formMarcas : Window
    {
        RepositorioMarca repositorio;

        public formMarcas()
        {
            repositorio = new RepositorioMarca();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }
        private void CarregueElementosDoBancoDeDados()
        {
            lstMarcas.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroMarca = new formCadastroDeMarca();
            formCadastroMarca.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if(lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Marca)lstMarcas.SelectedItem;
                var formCadastroMarca = new formCadastroDeMarca(itemSelecionado);
                formCadastroMarca.ShowDialog();
                CarregueElementosDoBancoDeDados();
            }
            
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstMarcas.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Marca)lstMarcas.SelectedItem;
                repositorio.Excluir(itemSelecionado);
                CarregueElementosDoBancoDeDados();
            }            
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }
    }
}
