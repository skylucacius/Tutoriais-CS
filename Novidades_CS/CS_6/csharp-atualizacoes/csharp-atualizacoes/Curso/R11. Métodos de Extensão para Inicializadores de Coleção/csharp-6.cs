using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CSharp6.R11
{
    class Programa
    {
        public void Main()
        {
            try
            {
                Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12))
                //verificar sobre inicializador de objetos
                {
                    Endereco = "9303, Lyon Drive Hill Valley CA",
                    Fone = "555-4305"
                };
                aluno.AdicionarAvaliacao(new Avaliacao(1, "HIS", 9));
                aluno.AdicionarAvaliacao(new Avaliacao(1, "MAT", 8));
                aluno.AdicionarAvaliacao(new Avaliacao(1, "GEO", 7));

                //foreach (var al in aluno.Avaliacoes)
                //{
                //    WriteLine(al);
                //}

                Aluno aluno2 = new Aluno("Bart", "Simpson"); //queremos disparar um erro inserir o nome como null
                //Console.WriteLine(aluno2.DadosPessoais);
                aluno.PropertyChanged += Aluno_PropertyChanged;

                Aluno aluno3 = new Aluno("Charlie", "Brown");
                var listaAlunos = new ListaDeMatricula()
                {
                    aluno, aluno2, aluno3
                };
                //listaAlunos.Matricular(aluno);
                //listaAlunos.Matricular(aluno2);
                //listaAlunos.Matricular(aluno3);


                foreach (Aluno al in listaAlunos)
                {
                    WriteLine(al.DadosPessoais);
                }


            }
            catch (ArgumentException e) when (e.Message.Contains("não informado")) {
                string msg = $"Argumento {e.ParamName} não foi informado!";
                WriteLine(msg);
                
            }
            catch (ArgumentException exc) {
                var msg = "Erro de argumento!" + exc.Message;
                WriteLine(msg);
            }
            catch (Exception e) { 
                var msg = "Erro na aplicação: " + e.Message;
                WriteLine(msg);
            }
            finally
            {
                var mensagem = "Finalizando aplicação.";
                WriteLine(mensagem);
            }
        }
        private void Aluno_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            WriteLine($"Propriedade {e.PropertyName} foi alterada!");
        }

        private static void ImprimirMelhorNota(Aluno al)
        {
            if (al?.MelhorAvaliacao != null)
                WriteLine("A melhor nota de {0} foi {1} em {2}.", al.Nome, al.MelhorAvaliacao.Nota, al.MelhorAvaliacao.CodigoMateria);
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
        Dictionary<string, string> materias = new Dictionary<string, string>()
        {
            ["MAT"] = "Matemática",
            ["LPL"] = "Língua Portuguesa",
            ["FIS"] = "Física",
            ["HIS"] = "História",
            ["GEO"] = "Geografia",
            ["QUI"] = "Química",
            ["BIO"] = "Biologia"
        };
        public Avaliacao(int bimestre, string codigoMateria, double nota)
        {
            Bimestre = bimestre;
            CodigoMateria = codigoMateria;
            Nota = nota;
        }
        public override string ToString()
        {
            return $"Bimestre: {Bimestre}, matéria {materias[CodigoMateria]}, nota {Nota}.";
        }

        public int Bimestre { get; }
        public string CodigoMateria { get; }
        public Double Nota { get; }
    }
    class ListaDeMatricula : IEnumerable<Aluno>
    {
        private List<Aluno> alunos = new List<Aluno>();

        public IEnumerator<Aluno> GetEnumerator()
        {
            return ((IEnumerable<Aluno>)alunos).GetEnumerator();
        }

        internal void Matricular(Aluno aluno)
        {
            alunos.Add(aluno);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)alunos).GetEnumerator();
        }
    }
    static class AlunoExtensions
    {
        public static void Add(this ListaDeMatricula lista, Aluno a) 
        {
            lista.Matricular(a);
        }
    }
}
