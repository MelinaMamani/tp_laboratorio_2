using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        private const string mensajeBase = "Este DNI es inválido.";

        /// <summary>
        /// Genera la excepción con un mensaje por defecto.
        /// </summary>
        public DniInvalidoException() : base (mensajeBase)
        {

        }
        /// <summary>
        /// Genera la excepción con un mensaje por defecto y una excepción interna.
        /// </summary>
        public DniInvalidoException(Exception e) : this (mensajeBase,e)
        {

        }
        /// <summary>
        /// Genera la excepción con un mensaje personalizado.
        /// </summary>
        public DniInvalidoException(string message) : base (message)
        {

        }
        /// <summary>
        /// Genera la excepción con un mensaje personalizado y una inner excepction.
        /// </summary>
        public DniInvalidoException(string message, Exception e) : base (message, e)
        {

        }
    }
}
