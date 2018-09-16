using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Numero
    {
        private double numero;

        private string strNum;
        private string SetNumero
        {
            set
            {
                this.numero = ValidarNumero(strNum);
                //numero = value;
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
            this.strNum = strNumero;
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

        public string BinarioDecimal(string binario)
        {
            string msj = "Valor inválido.";

            int num = Convert.ToInt32(binario, 2);

            if ( num >= 0)
            {
                msj = num.ToString();
            }

            return msj;
        }

        public string DecimalBinario(double numero)
        {
            string num = Convert.ToString(numero);
            return DecimalBinario(num);
        }

        public string DecimalBinario(string numero)
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
            return num1.numero / num2.numero;
        }
        
        #endregion
    }
}
