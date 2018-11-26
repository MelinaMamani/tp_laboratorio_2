using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda un string en un archivo de Texto.
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <returns>Retorna <see cref="true"/> si el archivo se guardó, sino lanza <see cref="ArchivosException"/>.</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool ver = false;
            try
            {
                using (StreamWriter stream = new StreamWriter(archivo))
                {
                    stream.WriteLine(datos);
                    stream.Close();
                    ver = true;
                }
            }
            catch (Exception e)
            {
                
                throw new ArchivosException(e);
            }
            return ver;
        }
        
        /// <summary>
        /// Lee un archivo de texto y retorna los datos.
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Cadena con salida de datos</param>
        /// <returns>Retorna <see cref="true"/> si logró leerse el archivo, sino se lanza <see cref="ArchivosException"/>.</returns>
        public bool Leer(string archivo, out string datos)
        {
            datos = "";
            bool ver = false;
            try
            {
                using (StreamReader stream = new StreamReader(archivo))
                {
                    datos = stream.ReadToEnd();
                    stream.Close();
                    ver = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return ver;
        }
    }
}
