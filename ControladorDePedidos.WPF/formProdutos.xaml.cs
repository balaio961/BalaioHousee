using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
using System.Windows;
using System.Windows.Data;
using System;
using System.Globalization;
using System.Windows.Media;

namespace ControladorDePedidos.WPF
{
    public class ConversorDeEstoque : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var produto = value as Produto;
            if (produto.QuantidadeEmEstoque < produto.QuantidadeMinimaEmEstoque)
            {
                return new SolidColorBrush(Colors.Red);
            }
            else
            {
                return new SolidColorBrush(Colors.Black);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public partial class formProdutos : Window
    {
        RepositorioProduto repositorio;

        public formProdutos()
        {
            repositorio = new RepositorioProduto();
            InitializeComponent();
        }

        private void CarregarElementosDoBancoDeDados()
        {
            lstProdutos.DataContext = repositorio.Liste();
        }

        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new formMarcas();
            formMarca.Show();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {   
                var formCadastroDeProduto = new formCadastroDeProduto();
                formCadastroDeProduto.ShowDialog();
                CarregarElementosDoBancoDeDados();           
            
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if(lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return; //chama o return para comcluir o metodo.
            }
            var produto = (Produto)lstProdutos.SelectedItem;
            var formCadastroDeProduto = new formCadastroDeProduto(produto);
            formCadastroDeProduto.ShowDialog();
            CarregarElementosDoBancoDeDados();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarElementosDoBancoDeDados();
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            CarregarElementosDoBancoDeDados();
        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstProdutos.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return; //chama o return para comcluir o metodo.
            }
            var produto = (Produto)lstProdutos.SelectedItem;
            repositorio.Excluir(produto);
            CarregarElementosDoBancoDeDados();
        }
    }
}
