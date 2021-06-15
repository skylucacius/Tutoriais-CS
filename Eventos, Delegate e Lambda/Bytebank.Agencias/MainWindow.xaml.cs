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

            lstAgencias.SelectionChanged += new SelectionChangedEventHandler(lstAgencias_SelectionChanged);

            container.Children.Add(lstAgencias);
            //Como adicionei o botão editar e seu evento de click pelo Drag-and-Drop do Visual Studio o evento de click já foi adicionado.
            //BtnEditar.Click += new RoutedEventHandler(BtnEditar_Click);
            PreencherAgencias();
        }
        private void lstAgencias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var agenciaSelecionada = (Agencia) lstAgencias.SelectedItem;

            txtNumero.Text = agenciaSelecionada.Numero.Trim();
            txtNome.Text = agenciaSelecionada.Nome.Trim();
            txtTelefone.Text = agenciaSelecionada.Telefone.Trim();
            txtEndereco.Text = agenciaSelecionada.Endereco.Trim();
            txtDescricao.Text = agenciaSelecionada.Descricao.Trim();

            
        }
        private void PreencherAgencias()
        {
            lstAgencias.Items.Clear();
            var agencias = _contextoBancoDeDados.Agencias.ToList();
            foreach (var agencia in agencias)
                lstAgencias.Items.Add(agencia);
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            var confirmacao = 
                MessageBox.Show(
                    "Você deseja realmente excluir este item?",
                    "Confirmação",
                    MessageBoxButton.YesNo);
            if (confirmacao == MessageBoxResult.Yes)
            {
                //Excluir
            }
            else
            {
                //Não faz nada
            }
        }

        private void BtnEditar_Click(object sender, RoutedEventArgs e)
        {
            //criar uma nova janela e abrí-la aqui.
            var agenciaSelecionada = (Agencia)lstAgencias.SelectedItem;

            if (agenciaSelecionada != null)
            {
                agenciaSelecionada.Descricao = agenciaSelecionada.Descricao.Trim();
                agenciaSelecionada.Endereco = agenciaSelecionada.Endereco.Trim();
                agenciaSelecionada.Nome = agenciaSelecionada.Nome.Trim();
                agenciaSelecionada.Numero = agenciaSelecionada.Numero.Trim();
                agenciaSelecionada.Telefone = agenciaSelecionada.Telefone.Trim();

                var janelaEdicao = new EditarAgencias(agenciaSelecionada);
                var resultado = janelaEdicao.ShowDialog().Value;

                //if (resultado)
                //{
                //    //lógica de edição
                //}
                //else
                //{
                //    //lógica de cancelar
                //}
            }
        }
    }
}
