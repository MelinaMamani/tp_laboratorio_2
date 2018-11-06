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

        public DniInvalidoException() : base (mensajeBase)
        {

        }

        public DniInvalidoException(Exception e) : this (mensajeBase,e)
        {

        }

        public DniInvalidoException(string message) : base (message)
        {

        }

        public DniInvalidoException(string message, Exception e) : base (message, e)
        {

        }
    }
}
