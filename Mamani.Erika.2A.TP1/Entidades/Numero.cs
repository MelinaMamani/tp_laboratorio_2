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
            int[] numeroCad = new int[binario.Length];
            string msj = "";
            double numero = 0;
            bool flag = true;
            int i;
            for (i = 0; i < binario.Length; i++)
            {
                numeroCad[i] = (int)char.GetNumericValue(binario[i]);
                if (numeroCad[i] != 0 && numeroCad[i] != 1)
                {
                    flag = false;
                    break;
                }
            }
            if (flag == true)
            {
                for (i = 0; i < binario.Length; i++)
                {
                    numero += (numeroCad[i] * Math.Pow(2, binario.Length - i - 1));
                }
                msj = numero.ToString();
            }
            else
            {
                msj = "Valor inválido";
            }

            return msj;
        }

        public static string DecimalBinario(string numero)
        {
            string msj;
            double numeroDouble;
            if (double.TryParse(numero, out numeroDouble))
            {
                msj = DecimalBinario(numeroDouble);
            }
            else
            {
                msj = "Valor inválido";
            }
            return msj;
        }

        public static string DecimalBinario(double entero)
        {
            int numero = (int)entero;
            string binario = "";
            while (numero > 0)
            {
                binario += (numero % 2).ToString();
                numero = numero / 2;
            }
            char[] charArray = binario.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
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
