using ByteBank.Modelos.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    public class Estagiario : Funcionario
    {
        public override void AumentarSalario()
        {
            //Qualquer código
        }
        protected internal override double GetBonificacao()
        {
            throw new NotImplementedException();
        }

        public Estagiario(double salario, string cpf) : base(salario,cpf)
        {

        }
    }
}
