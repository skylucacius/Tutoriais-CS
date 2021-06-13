using System;

namespace Tutorial_CFB_Cursos
{
    class Jogador
    {
        internal string nome;
        internal int energia;
        internal Jogador(string nome, int energia)
        {
            this.nome = nome;
            this.energia = energia;
            //Console.WriteLine("O jogador {} tem energia {}", nome, energia);
        }

        public void rodar()
        {
            Jogador j1 = new Jogador("Godofredo", 90);
            Jogador j2 = new Jogador("Aldo", 100);

            Console.WriteLine("Agora a energia de {0} é {1}", j1.nome, j1.energia);
            Console.WriteLine("Agora a energia de {0} é {1}", j2.nome, j2.energia);
        }
    }
}
