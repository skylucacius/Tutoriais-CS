using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Agencias
{
    public class ValidacaoEventArgs : EventArgs
    {
        public ValidacaoEventArgs(string text)
        {
            Text = text;
            EhValido = true;
        }
        public string Text { get; private set; }
        public bool EhValido { get; set; }

    }
}
