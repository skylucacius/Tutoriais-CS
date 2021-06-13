using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_CFB_Cursos
{
    class Estrutura
    {
        static void roda(string[] args)
        {
            Carro c = new Carro("vermelho", "Chevrolet", "sedan");

        }

    }
    struct Carro
    {
        public string cor, marca, modelo;
        public Carro(string cor, string marca, string modelo)
        {
            this.cor = cor;
            this.marca = marca;
            this.modelo = modelo;
        }
    }
}
