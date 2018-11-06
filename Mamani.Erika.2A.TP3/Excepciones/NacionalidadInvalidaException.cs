using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Genera la excepción con un mensaje por defecto.
        /// </summary>
        public NacionalidadInvalidaException() : base ("Nacionalidad incorrecta para este DNI.")
        {

        }
        /// <summary>
        /// Genera la excepción con un mensaje personalizado.
        /// </summary>
        public NacionalidadInvalidaException(string message) : base (message)
        {

        }
    }
}
