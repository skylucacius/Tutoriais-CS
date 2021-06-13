using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_CFB_Cursos
{
    class Program
    {
        static void roda()
        {
            Base b = new Base(1);
            Derivada1 d1 = new Derivada1(1, 2);
            Derivada2 d2 = new Derivada2(1, 2, 3);

            b.getProp();
            d1.getProp();
            d2.getProp();

            Base Ref;
            Ref = d1;
        }
    }

    class Base
    {
        internal int prop1;
        internal Base(int prop1)
        {
            Console.WriteLine("\nInicializando classe base...");
            this.prop1 = prop1;     
        }

        internal virtual void getProp()
        {
            Console.WriteLine("Valor da propriedade 1: " + prop1);
        }
    }

    class Derivada1:Base
    {
        internal int prop2;
        internal Derivada1(int prop1, int prop2):base(prop1)
        {
            Console.WriteLine("Inicializando classe derivada 1...");
            this.prop2 = prop2;
        }

        internal override void getProp()
        {
            Console.WriteLine("Valor da propriedade 2: " + prop2);
        }
    }

    class Derivada2 : Derivada1
    {
        internal int prop3;
        internal Derivada2(int prop1, int prop2, int prop3):base(prop1,prop2)
        {
            Console.WriteLine("Inicializando classe derivada 2...");
            this.prop3 = prop3;
        }
        internal override void getProp()
        {
            Console.WriteLine("Valor da propriedade 3: " + prop3);
        }
    }
}
