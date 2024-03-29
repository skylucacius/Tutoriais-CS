﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp6.R01
{
    class Programa
    {
        public void Main()
        {
            Console.WriteLine("1. Propriedades Automáticas Somente-Leitura");

            Aluno aluno = new Aluno("Marty", "McFly", new DateTime(1968, 6, 12));
            Console.WriteLine(aluno.Nome);
            Console.WriteLine(aluno.SobreNome);

            //aluno.Nome = "Biff";
            //aluno.Sobrenome = "Tannen";
            //Console.WriteLine(aluno.Nome);
            //Console.WriteLine(aluno.Sobrenome);

            Console.WriteLine(aluno.ToString());
        }
    }

    class Aluno
    {
        public string Nome { get; }
        public string SobreNome { get; }
        public DateTime DataNascimento { get; }

        public Aluno(string nome, string sobreNome, DateTime dataNascimento)
        {
            Nome = nome;
            SobreNome = sobreNome;
            DataNascimento = dataNascimento;
        }

        //public override string ToString()
        //{
        //    this.Nome = "novo nome";
        //    this.Sobrenome = "novo sobrenome";
        //    return string.Format("{0} {1}", Nome, Sobrenome);
        //}
    }
}
