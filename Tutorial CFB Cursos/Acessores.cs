using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_CFB_Cursos
{
    class Acessores
    {
        static void roda(string[] args)
        {
            A2 a2 = new A2();
            a2.p1 = 10;
            Console.WriteLine(a2.p1);
            a2.p1 = -5;
            Console.WriteLine(a2.p1);

            a2.p2 = -2;
            Console.WriteLine(a2.p2);
            a2.p3 = 9;
            Console.WriteLine(a2.p3);
        }
    }

    class A2
    {
        public A2()
        {
            velmax = 0;
        }
        int velmax;
        public int p1
        {
            get
            {
                return velmax;
            }
            set
            {
                if (value < 0) { Console.WriteLine("Foi setado um valor negativo. Logo ele será invertido");
                    velmax = -1 * value;
                } else
                {
                    Console.WriteLine("Foi setado um valor positivo");
                    velmax = value;
                }
            }
        }
        public int p2 { get; set; }
        public int p3;

    }
}
