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
    /// Lógica interna para EditarAgencias.xaml
    /// </summary>
    public partial class EditarAgencias : Window
    {
        private readonly Agencia _agencia;
        public EditarAgencias(Agencia agencia)
        {
            InitializeComponent();
            _agencia = agencia ?? throw new ArgumentNullException();
            EditarCamposDeTexto();
            AtualizarControles();
        }
        private void EditarCamposDeTexto()
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
            btnCancelar.Click += dialogResultFalse + Fechar; //que massinha 

            //Eventos de mudança de texto da cor de fundo do TextBox
            txtDescricao.TextChanged += ValidarCampoNulo; //equivalente a txtDescricao.TextChanged += new TextChangedEventHandler(ValidarCampoNulo);
            //txtDescricao.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtDescricao);
            //(sender, e) => 
            //txtDescricao.Background = string.IsNullOrEmpty(txtDescricao.Text) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);

            txtEndereco.TextChanged += ValidarCampoNulo;
            //txtEndereco.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtEndereco);
            //(sender, e) =>
            //txtEndereco.Background = string.IsNullOrEmpty(txtEndereco.Text) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);

            txtNome.TextChanged += ValidarCampoNulo;
            //txtNome.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtNome);
            //(sender, e) =>
            //txtNome.Background = string.IsNullOrEmpty(txtNome.Text) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);

            txtNumero.TextChanged += ValidarCampoNulo;
            //txtNumero.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtNumero);
            //(sender, e) =>
            //txtNumero.Background = string.IsNullOrEmpty(txtNumero.Text) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);

            txtTelefone.TextChanged += ValidarCampoNulo;
            //txtTelefone.TextChanged += ConstruirDelegateValidacaoCampoNulo(txtTelefone);
            //(sender, e) =>
            //txtTelefone.Background = string.IsNullOrEmpty(txtTelefone.Text) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);


        }
        private void ValidarCampoNulo(object sender, TextChangedEventArgs e)
        {
            var txt = sender as TextBox;
            txt.Background = string.IsNullOrEmpty(txt.Text) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);
        }

            

        //private TextChangedEventHandler ConstruirDelegateValidacaoCampoNulo(TextBox txt) =>
        //    (sender,e) => txt.Background = string.IsNullOrEmpty(txt.Text) ? new SolidColorBrush(Colors.OrangeRed) : new SolidColorBrush(Colors.White);

        //private void btnOk_Click(object sender, RoutedEventArgs e) => DialogResult = true;
        //private void btnCancelar_Click(object sender, RoutedEventArgs e) => DialogResult = false;
        //private void Fechar(object sender, EventArgs e)
        //{
        //    Close();
        //}
    }
}
