using System;

namespace Alura_CS_pt4
{
    public class ContaCorrente
    {
        private int _agencia;
        public int Agencia { get { return _agencia; } 
            set { 
                if (value <= 0)
                {
                    return;
                } else
                {
                    _agencia = value;
                }
            } 
        }
        public int Numero { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        private double _saldo;
        public double Saldo { 
            get {
                return _saldo;
            } 
            set { 
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            } 
        }
        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
            TotalDeContasCriadas++;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Total de contas criadas: " + ContaCorrente.TotalDeContasCriadas);
            ContaCorrente conta = new ContaCorrente(867, 86712540);
            Console.WriteLine("Total de contas criadas: " + ContaCorrente.TotalDeContasCriadas);
        }

        //sacar, depositar, transferir
        public bool Sacar(double amount)
        {
            if (_saldo > amount) {
                Saldo -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Depositar(double amount)
        {
            if (amount > 0)
            {
                _saldo += amount;
            }
            else
            {
                Console.WriteLine("Por favor, entre com um valor positivo.");
            }
        }

        public bool Transferir(double amount, ContaCorrente conta)
        {
            if (amount > 0)
            {
                conta.Depositar(amount);
                _saldo -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }
}