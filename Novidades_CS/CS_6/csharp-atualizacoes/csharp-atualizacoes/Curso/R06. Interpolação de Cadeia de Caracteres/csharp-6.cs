using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace CSharp6.R06
{
    class Programa
    {
        public void Main()
        {
            WriteLine("6. Interpolação de Cadeia de Caracteres");

            Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12))
            //verificar sobre inicializador de objetos
            {
                Endereco = "9303, Lyon Drive Hill Valley CA",
                Telefone = "555-4305"
            };
            //WriteLine(aluno.Nome);
            //WriteLine(aluno.Sobrenome);

            WriteLine(aluno.NomeCompleto);
            //WriteLine("Idade: {0}", aluno.GetIdade());
            //WriteLine(aluno.DadosPessoais);
            aluno.AdicionarAvaliacao(new Avaliacao(1, "História", 9));
            aluno.AdicionarAvaliacao(new Avaliacao(1, "Matemática", 8));
            aluno.AdicionarAvaliacao(new Avaliacao(1, "Geografia", 7));
            WriteLine(aluno.DadosPessoais);
            ImprimirMelhorNota2(aluno);

            //Aluno aluno2 = null;
            Aluno aluno2 = new Aluno("Bart", "Simpson");
            //aluno2.AdicionarAvaliacao(new Avaliacao(1, "Matemática", 8));
            ImprimirMelhorNota2(aluno2);

        }

        private static void ImprimirMelhorNota(Aluno aluno)
        {
            //Caso aluno seja nulo, irá imprimir: A melhor nota de  foi  em .
            WriteLine("A melhor nota de {0} foi {1} em {2}.", aluno?.Nome, aluno?.MelhorAvaliacao?.Nota, aluno?.MelhorAvaliacao?.Materia);
        }

        private static void ImprimirMelhorNota2(Aluno al)
        {
            if (al?.MelhorAvaliacao != null)
                WriteLine("A melhor nota de {0} foi {1} em {2}.", al.Nome, al.MelhorAvaliacao.Nota, al.MelhorAvaliacao.Materia);
        }
    }

    class Aluno
    {
        public string Nome { get; }
        public string Sobrenome { get; }
        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string NomeCompleto  => Nome + " " + Sobrenome;
        public string DadosPessoais =>  $"Nome completo: {Nome} {Sobrenome}, endereço: {Endereco}, telefone: {Telefone}, data de nascimento: {DataNascimento:dd/mm/yyyy}";


        public int GetIdade()
            => (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);

        public Aluno(string nome, string sobrenome)
        {
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
