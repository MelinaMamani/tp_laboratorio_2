using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(value);
            }
        }

        #region Constructores
        public Numero ()
        {
        
        }

        public Numero (double numero)
        {
            this.numero = numero;
        }

        public Numero (string strNumero)
        {
            this.SetNumero = strNumero;
        }
        #endregion

        #region Métodos
        private double ValidarNumero(string strNumero)
        {
            double numero;

            if (!double.TryParse(strNumero, out numero))
            {
                numero = 0;
            }

            return numero;
        }

        public static string BinarioDecimal(string binario)
        {
            string msj = "Valor inválido.";

            int num = Convert.ToInt32(binario, 2);

            if ( num >= 0)
            {
                msj = num.ToString();
            }

            return msj;
        }

        public static string DecimalBinario(double numero)
        {
            string num = Convert.ToString(numero);
            return DecimalBinario(num);
        }

        public static string DecimalBinario(string numero)
        {
            int num = Convert.ToInt32(numero);
            string bin = Convert.ToString(num, 2);

            if ( bin != "")
            {
                return bin;
            }
            else
            {
                return "Valor inválido.";
            }
            
        }
        #endregion

        #region Sobrecargas
        public static double operator +(Numero num1, Numero num2)
        {
            return num1.numero + num2.numero;
        }

        public static double operator -(Numero num1, Numero num2)
        {
            return num1.numero - num2.numero;
        }

        public static double operator *(Numero num1, Numero num2)
        {
            return num1.numero * num2.numero;
        }

        public static double operator /(Numero num1, Numero num2)
        {
            double rdo;
            if (num2.numero == 0)
            {
                rdo = 0;
            }
            else
            {
                rdo = num1.numero / num2.numero;
            }
            return rdo;
        }
        
        #endregion
    }
}
