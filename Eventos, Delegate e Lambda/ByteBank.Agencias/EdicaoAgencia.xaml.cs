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
using System.Windows.Shapes;


namespace ByteBank.Agencias
{
    /// <summary>
    /// Lógica interna para EdicaoAgencia.xaml
    /// </summary>
    public partial class EdicaoAgencia : Window
    {
        private readonly Agencia _agencia;
        public EdicaoAgencia(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia ?? throw new ArgumentNullException();
            PreencherCamposDeTexto();
            AtualizarControles();
        }
        private void PreencherCamposDeTexto()
        {
            txtNumero.Text = _agencia.Numero;
            txtNome.Text = _agencia.Nome;
            txtTelefone.Text = _agencia.Telefone;
            txtEndereco.Text = _agencia.Endereco;
            txtDescricao.Text = _agencia.Descricao;
        }
        private void AtualizarControles()
        {
            RoutedEventHandler dialogResultTrue = (sender,e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (sender,e) => DialogResult = false;
            RoutedEventHandler Fechar = (sender, e) => Close();

            btnOk.Click += dialogResultTrue + Fechar;
            btnCancelar.Click += dialogResultFalse + Fechar;

            //Eventos de mudança de texto da cor de fundo do TextBox
            //txtDescricao.TextChanged += ValidarCampoNulo; //equivalente a txtDescricao.TextChanged += new TextChangedEventHandler(ValidarCampoNulo);
            //txtEndereco.TextChanged += ValidarCampoNulo;
            //txtNome.TextChanged += ValidarCampoNulo;
            //txtNumero.TextChanged += ValidarCampoNulo;
            //txtTelefone.TextChanged += ValidarCampoNulo;
            //txtTelefone.TextChanged += ValidarSomenteDigito;

            txtDescricao.Validacao += ValidarCampoNulo;
            txtEndereco.Validacao += ValidarCampoNulo;
            txtNome.Validacao += ValidarCampoNulo;
            txtNumero.Validacao += ValidarCampoNulo;
            txtTelefone.Validacao += ValidarCampoNulo;
            txtTelefone.Validacao += ValidarSomenteDigito;

        }
        //private void ValidarCampoNulo(object sender, TextChangedEventArgs e)
        //{
        //    var txt = sender as TextBox;
        //    txt.Background = string.IsNullOrEmpty(txt.Text) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);
        //}
        //private void ValidarSomenteDigito(object sender, TextChangedEventArgs e)
        //{
        //var txt = sender as TextBox;

        //Func<char, bool> TodosSaoDigitos = c => char.IsDigit(c);
        //txt.Background = txt.Text.All(TodosSaoDigitos) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);

        //txt.Background = txt.Text.All(char.IsDigit) ? new SolidColorBrush(Colors.White) : new SolidColorBrush(Colors.OrangeRed); // cool =)
        //}
        private bool ValidarSomenteDigito(string texto) => texto.All(char.IsDigit);
        private bool ValidarCampoNulo(string texto) => !string.IsNullOrEmpty(texto);
    }
}
