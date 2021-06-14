using ByteBank.Agencias.DAL;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ByteBank.Agencias
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ByteBankEntities _contextoBancoDeDados = new ByteBankEntities();
        private readonly ListBox lstAgencias;

        public MainWindow()
        {
            InitializeComponent();
            lstAgencias = new ListBox();
            AtualizarControles();
        }

        private void AtualizarControles()
        {
            lstAgencias.Width = 270;
            lstAgencias.Height = 290;
            Canvas.SetTop(lstAgencias, 15);
            Canvas.SetLeft(lstAgencias, 15);

            lstAgencias.SelectionChanged += new SelectionChangedEventHandler(lstAgencia_SelectionChanged);
            btnEditar.Click += new RoutedEventHandler(btnEditar_Click);

            container.Children.Add(lstAgencias);
            AtualizarListaDeAgencias();
        }
        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            //criar uma nova janela e abrí-la aqui.
        }
        private void AtualizarListaDeAgencias()
        {
            lstAgencias.Items.Clear();
            var agencias = _contextoBancoDeDados.Agencias.ToList();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private void lstAgencia_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var agenciaSelecionada = (Agencia)lstAgencias.SelectedItem;
            txtDescricao.Text = agenciaSelecionada.Descricao;
            txtEndereco.Text = agenciaSelecionada.Endereco;
            txtNome.Text = agenciaSelecionada.Nome;
            txtNumero.Text = agenciaSelecionada.Numero;
            txtTelefone.Text = agenciaSelecionada.Telefone;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var resposta = MessageBox.Show ("Você deseja realmente excluir o registro ?", "Confirmar Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (resposta == MessageBoxResult.Yes)
            {
                //lógica para exclusão
            }
            else
            {
                //não faz nada ...
            }
        }
    }
}
