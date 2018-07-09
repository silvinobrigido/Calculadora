using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora.Forms
{
    class Divisao : ICalculo
    {
        public decimal calcular(decimal valor1, decimal valor2)
        {
            return valor1 / valor2;
        }
    }
}
