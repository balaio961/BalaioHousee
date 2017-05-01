using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ControladorDePedidos.WPF
{
    /// <summary>
    /// Interaction logic for formCompras.xaml
    /// </summary>
    public partial class formCompras : Window
    {
        RepositorioCompra repositorio;

        public formCompras()
        {
            repositorio = new RepositorioCompra();
            InitializeComponent();
        }

        private void CarregarElementosDoBancoDeDados()
        {
            lstCompras.DataContext = repositorio.Liste();
        }

        private void btnMarcas_Click(object sender, RoutedEventArgs e)
        {
            var formMarca = new formMarcas();
            formMarca.Show();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroDeCompra = new formCadastroDeCompra();
            formCadastroDeCompra.ShowDialog();
            CarregarElementosDoBancoDeDados();

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return; //chama o return para comcluir o metodo.
            }
            var compra = (Compra)lstCompras.SelectedItem;
            var formCadastroDeCompra = new formCadastroDeCompra(compra);
            formCadastroDeCompra.ShowDialog();
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
            if (lstCompras.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item");
                return; //chama o return para comcluir o metodo.
            }
            var compra = (Compra)lstCompras.SelectedItem;
            repositorio.Excluir(compra);
            CarregarElementosDoBancoDeDados();
        }
    }
