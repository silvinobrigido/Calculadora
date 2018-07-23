using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Calculadora.Forms
{
    public partial class frmCalculadora : Form
    {
        Operador Operacao;
        readonly string logPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Calculadora.log";

        public frmCalculadora()
        {
            InitializeComponent();

            this.AcceptButton = btnCalcular;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            var valores = txtDisplay.Text.Split('+', '-', '/', '*');
            if (valores.Length >= 2)
            {
                var valor1 = Convert.ToDecimal(valores[0]);
                var valor2 = Convert.ToDecimal(valores[1]);
                decimal resultado = 0;

                OperacaoFactory of = new OperacaoFactory();
                resultado = of.GetCalculo(Operacao).calcular(valor1, valor2);

                /*switch (Operacao)
                {
                    case Operador.Soma:
                        resultado = valor1 + valor2;
                        break;
                    case Operador.Subtracao:
                        resultado = valor1 - valor2;
                        break;
                    case Operador.Divisao:
                        resultado = valor1 / valor2;
                        break;
                    case Operador.Multiplicacao:
                        resultado = valor1 * valor2;
                        break;
                    default:
                        throw new NotImplementedException();
                }*/

                using (var file = new StreamWriter(logPath, true))
                {
                    file.WriteLine($"[{DateTime.Now}] [Operação: {Operacao.ToString()}] [Primeiro Valor: {valor1.ToString()}] [Segundo Valor: { valor2.ToString()}] [Resultado: {resultado.ToString()}]");
                }

                txtDisplay.Text = resultado.ToString();
                txtDisplay.Focus();
                txtDisplay.SelectionStart = txtDisplay.Text.Length;
                txtDisplay.SelectionLength = 0;
            }
            else
            {
                MessageBox.Show("Digite mais de um valor");
            }
        }

        private void txtDisplay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '/')
            {
                Operacao = Operador.Divisao;
            }

            if (e.KeyChar == '*')
            {
                Operacao = Operador.Multiplicacao;
            }

            if (e.KeyChar == '-')
            {
                Operacao = Operador.Subtracao;
            }

            if (e.KeyChar == '+')
            {
                Operacao = Operador.Soma;
            }
        }
    }
}
