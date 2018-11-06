using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo <T>
    {
        /// <summary>
        /// Guarda datos en un archivo.
        /// </summary>
        /// <param name="archivo">Ruta al Archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Retorna <see cref="true"/> si el archivo se guardó,<see cref="false"/> si no pudo guardarse.</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Lee datos en un archivo.
        /// </summary>
        /// <param name="archivo">Ruta al Archivo</param>
        /// <param name="datos">Salida de datos</param>
        /// <returns>Retorna <see cref="true"/> si el archivo se leyó,<see cref="false"/> si no pudo leerse.</returns>
        bool Leer(string archivo, out T datos);
    }
}
