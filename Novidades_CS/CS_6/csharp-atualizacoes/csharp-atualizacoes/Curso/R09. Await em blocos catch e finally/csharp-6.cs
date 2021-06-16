using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CSharp6.R09
{
    class Programa
    {
        public async void Main()
        {
            var logAplicacao = new StreamWriter("Aplicação.txt");
            try
            {
                WriteLine("9. Await em blocos catch e finally");
                await logAplicacao.WriteLineAsync("Iniciando log ...");

                Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12))
                //verificar sobre inicializador de objetos
                {
                    Endereco = "9303, Lyon Drive Hill Valley CA",
                    Fone = "555-4305"
                };
                await logAplicacao.WriteLineAsync("Criando aluno Marty Mcfly ...");
                //WriteLine(aluno.Nome);
                //WriteLine(aluno.Sobrenome);

                //WriteLine(aluno.NomeCompleto);
                //WriteLine("Idade: {0}", aluno.GetIdade());
                //WriteLine(aluno.DadosPessoais);
                aluno.AdicionarAvaliacao(new Avaliacao(1, "História", 9));
                aluno.AdicionarAvaliacao(new Avaliacao(1, "Matemática", 8));
                aluno.AdicionarAvaliacao(new Avaliacao(1, "Geografia", 7));
                //WriteLine(aluno.DadosPessoais);
                //ImprimirMelhorNota2(aluno);

                //Aluno aluno2 = null;
                Aluno aluno2 = new Aluno("Charlie", null); //queremos disparar um erro inserir o nome como null
                await logAplicacao.WriteLineAsync("Criando aluno Charlie Brown ...");
                Console.WriteLine(aluno2.DadosPessoais);
                //aluno2.AdicionarAvaliacao(new Avaliacao(1, "Matemática", 8));
                //ImprimirMelhorNota(aluno2);
                aluno.PropertyChanged += Aluno_PropertyChanged;

                //aluno.Endereco = "Rua Vergueio, 3185";
                //aluno.Fone = "555-1234"; // espera-se que seja emitido uma notificação de mudança dessas duas propriedades

            }
            catch (ArgumentException e) when (e.Message.Contains("não informado")) {
                string msg = $"Argumento {e.ParamName} não foi informado!";
                WriteLine(msg);
                await logAplicacao.WriteLineAsync(msg);
                
            }
            catch (ArgumentException exc) {
                var msg = "Erro de argumento!" + exc.Message;
                WriteLine(msg);
                await logAplicacao.WriteLineAsync(msg);
            }
            catch (Exception e) { 
                var msg = "Erro na aplicação: " + e.Message;
                WriteLine(msg);
                await logAplicacao.WriteLineAsync(msg);
            }
            finally
            {
                var mensagem = "Finalizando aplicação.";
                WriteLine(mensagem);
                await logAplicacao.WriteLineAsync(mensagem);
                logAplicacao.Dispose();
            }
        }
        private void Aluno_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WriteLine($"Propriedade {e.PropertyName} foi alterada!");
        }

        private static void ImprimirMelhorNota(Aluno al)
        {
            if (al?.MelhorAvaliacao != null)
                WriteLine("A melhor nota de {0} foi {1} em {2}.", al.Nome, al.MelhorAvaliacao.Nota, al.MelhorAvaliacao.Materia);
        }
    }
    class Aluno : INotifyPropertyChanged
    {
        private static void verificaParametro(string valorParametro, string nomeParametro)
        {
            if (string.IsNullOrEmpty(valorParametro))
            {
                throw new ArgumentException($"Parâmetro {nameof(nomeParametro)} não informado para o aluno!",nomeParametro);
            }
        }
        public string Nome { get; }
        public string Sobrenome { get; }
        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);
        private string _endereco;
        private string _telefone;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Endereco
        {
            get
            {
                return _endereco;
            }
            set
            {
                if (_endereco != value)
                {
                    _endereco = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DadosPessoais));
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName]string nomePropriedade = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nomePropriedade));
        }

        public string Fone
        {
            get
            {
                return _telefone;
            }
            set
            {
                if (_telefone != value)
                {
                    _telefone = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(DadosPessoais));
                }
            }

        }
        public string NomeCompleto  => Nome + " " + Sobrenome;
        public string DadosPessoais =>  $"Nome completo: {Nome} {Sobrenome}, endereço: {Endereco}, telefone: {Fone}, data de nascimento: {DataNascimento:dd/mm/yyyy}";


        public int GetIdade()
            => (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);

        public Aluno(string nome, string sobrenome)
        {
            verificaParametro(nome, nameof(nome));
            verificaParametro(sobrenome, nameof(sobrenome));
            Nome = nome;
            Sobrenome = sobrenome;
        }


        public Aluno(string nome, string sobrenome, DateTime dataNascimento) : this(nome, sobrenome) => 
            DataNascimento = dataNascimento;

        private IList<Avaliacao> avaliacoes = new List<Avaliacao>();
        public IReadOnlyCollection<Avaliacao> Avaliacoes => new ReadOnlyCollection<Avaliacao>(avaliacoes);
        public void AdicionarAvaliacao(Avaliacao avaliacao) => avaliacoes.Add(avaliacao);
        public Avaliacao MelhorAvaliacao => avaliacoes.OrderBy(a => a.Nota).LastOrDefault();
    }
    public class Avaliacao
    {
        public Avaliacao(int bimestre, string materia, double nota)
        {
            Bimestre = bimestre;
            Materia = materia;
            Nota = nota;
        }

        public int Bimestre { get; }
        public string Materia { get; }
        public Double Nota { get; }
    }
}
