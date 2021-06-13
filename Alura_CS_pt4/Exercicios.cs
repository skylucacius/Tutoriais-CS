using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura_CS_pt4_alternativo
{
    public class Cliente
    {
        public string nome;
        public string cpf;
        public string profissao;
    }

    public class ContaCorrente
    {
        public double saldo;
        public int agencia;
        public int numero;
        public Cliente titular = new Cliente();
    }

    class Program
    {
        static void roda(string[] args)
        {
            ContaCorrente contaDaCamila = new ContaCorrente();
            contaDaCamila.agencia = 123;
            contaDaCamila.numero = 12345;
            contaDaCamila.saldo = 12;
            contaDaCamila.titular.cpf = "123456789";
            contaDaCamila.titular.nome = "Camila";
            contaDaCamila.titular.profissao = "programadora";

            Console.WriteLine("As informações da conta da " + contaDaCamila.titular.nome + " são:\n");
            Console.WriteLine("agência: " + contaDaCamila.agencia);
            Console.WriteLine("numero: " + contaDaCamila.numero);
            Console.WriteLine("saldo: " + contaDaCamila.saldo);
            Console.WriteLine("E as informações do titular são: ");
            Console.WriteLine("CPF: " + contaDaCamila.titular.cpf);
            Console.WriteLine("profissão: " + contaDaCamila.titular.profissao);
        }
    }
}
