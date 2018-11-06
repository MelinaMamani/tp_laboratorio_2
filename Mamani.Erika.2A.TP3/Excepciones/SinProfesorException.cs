using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Genera la excepción con un mensaje por defecto.
        /// </summary>
        public SinProfesorException() : base ("No hay profesor para la clase.")
        {

        }
    }
}
