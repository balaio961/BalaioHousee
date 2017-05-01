using ControladorDePedidos.Model;
using ControladorDePedidos.Repositorio;
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
    /// Interaction logic for formUsuario.xaml
    /// </summary>
    public partial class formUsuario : Window
    {
        RepositorioUsuario repositorio;

        public formUsuario()
        {
            repositorio = new RepositorioUsuario();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarregueElementosDoBancoDeDados();
        }
        private void CarregueElementosDoBancoDeDados()
        {
            lstUsuarios.DataContext = repositorio.Liste();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            var formCadastroUsuario = new formCadastroDeUsuario();
            formCadastroUsuario.ShowDialog();
            CarregueElementosDoBancoDeDados();
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            if (lstUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Usuario)lstUsuarios.SelectedItem;
                var formCadastroUsuario = new formCadastroDeUsuario(itemSelecionado);
                formCadastroUsuario.ShowDialog();
                CarregueElementosDoBancoDeDados();
            }

        }

        private void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (lstUsuarios.SelectedItem == null)
            {
                MessageBox.Show("Selecione um item na lista");
            }
            else
            {
                var itemSelecionado = (Usuario)lstUsuarios.SelectedItem;
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
