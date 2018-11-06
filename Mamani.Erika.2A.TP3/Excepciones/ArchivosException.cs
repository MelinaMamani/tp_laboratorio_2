using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        /// <summary>
        /// Generá la excepción con un mensaje por defecto y una excepción interna.
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException) : base ("Error en el archivo.",innerException)
        {

        }
    }
}
