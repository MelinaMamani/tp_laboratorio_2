using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        public static double Operar (Numero num1, Numero num2, string operador)
        {
            double rdo = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    rdo = num1 + num2;
                    break;
                case "-":
                    rdo = num1 - num2;
                    break;
                case "*":
                    rdo = num1 * num2;
                    break;
                case "/":
                    rdo = num1 / num2;
                    break;
                default:
                    break;
            }

            return rdo;
        }

        private static string ValidarOperador (string operador)
        {
            if (operador == "+" || operador == "-" || operador == "*" || operador == "/")
            {
                return operador;
            }
            else
            {
                return "+";
            }

        }
    }
}
