using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializa un objeto en un archivo xml. 
        /// </summary>
        /// <param name="archivo">Ruta del archivo xml.</param>
        /// <param name="datos">Objeto a serializar.</param>
        /// <returns>Retorna <see cref="true"/> si el archivo se serializó, sino se lanza <see cref="ArchivosException"/>.</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
                writer.Close();
                retorno = true;
 
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }

        /// <summary>
        /// Deserializa un archivo xml y retorna el contenido como un objeto.
        /// </summary>
        /// <param name="archivo">Ruta del archivo xml.</param>
        /// <param name="datos">Salida de datos</param>
        /// <returns>Retorna <see cref="true"/> si se deserializo exitosamente, sino se lanza <see cref="ArchivosException"/></returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
            try
            {
                XmlTextReader reader = new XmlTextReader(archivo);
                XmlSerializer deserializer = new XmlSerializer(typeof(T));
                datos = (T)deserializer.Deserialize(reader);
                reader.Close();
                retorno = true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retorno;
        }
    }
}
