﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
                using (TextWriter writer = new StreamWriter(archivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(writer, datos);
                    retorno = true;
                }
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
                using (TextReader reader = new StreamReader(archivo))
                {
                    XmlSerializer xml = new XmlSerializer(typeof(T));
                    datos = (T)xml.Deserialize(reader);
                    retorno = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return retorno;
        }
    }
}
