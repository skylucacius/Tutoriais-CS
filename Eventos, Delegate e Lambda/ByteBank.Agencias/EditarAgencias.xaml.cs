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
            //var okEventHandler = (RoutedEventHandler) btnOk_Click + Fechar;
            //var cancelarEventHandler = (RoutedEventHandler)btnCancelar_Click + Fechar;

            btnOk.Click += (RoutedEventHandler)btnOk_Click + Fechar;
            btnCancelar.Click += (RoutedEventHandler)btnCancelar_Click + Fechar; //que massinha 

            //btnOk.Click += new RoutedEventHandler(btnOk_Click);
            //btnCancelar.Click += new RoutedEventHandler(btnCancelar_Click);

            //btnOk.Click += new RoutedEventHandler(Fechar);
            //btnCancelar.Click += new RoutedEventHandler(Fechar);
        }
        private void btnOk_Click(object sender, RoutedEventArgs e) => DialogResult = true;
        private void btnCancelar_Click(object sender, RoutedEventArgs e) => DialogResult = false;
        private void Fechar(object sender, EventArgs e)
        {
            Close();
        }
    }
}
