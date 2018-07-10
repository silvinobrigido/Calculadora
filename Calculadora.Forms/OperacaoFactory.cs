using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculadora.Forms
{
    class OperacaoFactory
    {

        public  ICalculo GetCalculo(Operador operador)
        {
            switch (operador)
            {
                case Operador.Soma:
                    return new Soma();                    
                case Operador.Subtracao:
                    return new Subtracao();                    
                case Operador.Divisao:
                    return new Divisao();                    
                case Operador.Multiplicacao:
                    return new Multiplicacao();                    
                default:
                    throw new NotImplementedException();
            }
        }

    }
}
