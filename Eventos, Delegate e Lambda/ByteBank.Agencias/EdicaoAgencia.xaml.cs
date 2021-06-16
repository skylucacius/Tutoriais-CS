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
            RoutedEventHandler dialogResultTrue = (sender, e) => DialogResult = true;
            RoutedEventHandler dialogResultFalse = (sender, e) => DialogResult = false;
            RoutedEventHandler Fechar = (sender, e) => Close();

            btnOk.Click += dialogResultTrue + Fechar;
            btnCancelar.Click += dialogResultFalse + Fechar;

            txtDescricao.Validacao += ValidarCampoNulo;
            txtEndereco.Validacao += ValidarCampoNulo;
            txtNome.Validacao += ValidarCampoNulo;
            txtNumero.Validacao += ValidarCampoNulo;
            txtTelefone.Validacao += ValidarCampoNulo;
            txtTelefone.Validacao += ValidarSomenteDigito;
        }

        private void ValidarSomenteDigito(object sender, ValidacaoEventArgs e) => e.EhValido = e.Text.All(char.IsDigit); 
        private void ValidarCampoNulo(object sender, ValidacaoEventArgs e) => e.EhValido = !string.IsNullOrEmpty(e.Text);
    }
}
