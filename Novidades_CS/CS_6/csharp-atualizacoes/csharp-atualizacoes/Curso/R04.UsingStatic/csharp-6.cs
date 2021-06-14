using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace CSharp6.R04
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("4. Using Static");

            Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12))
            // verificar sobre inicializador de objetos
            {
                Endereco = "9303, Lyon Drive Hill Valley CA",
                Telefone = "555-4305"
            };
            ////Equivalente a
            //; aluno.Endereco = "9303, Lyon Drive Hill Valley CA";
            //aluno.Telefone = "555-4305";
            WriteLine(aluno.Nome);
            WriteLine(aluno.Sobrenome);

            WriteLine(aluno.NomeCompleto);
            WriteLine("Idade: {0}", aluno.GetIdade());
            WriteLine(aluno.DadosPessoais);
        }
    }

    class Aluno
    {
        public string Nome { get; }
        public string Sobrenome { get; }
        public DateTime DataNascimento { get; } = new DateTime(1990, 1, 1);
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string DadosPessoais => string.Format("{0}, {1}, {2}", Nome, Endereco, Telefone);
        public string NomeCompleto => Nome + " " + Sobrenome; 
        
        public int GetIdade()
            => (int)(((DateTime.Now - DataNascimento).TotalDays) / 365.242199);

        public Aluno(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }
        public Aluno(string nome, string sobrenome, DateTime dataNascimento) :
            this(nome, sobrenome)
        {
            DataNascimento = dataNascimento;
        }

    }
}