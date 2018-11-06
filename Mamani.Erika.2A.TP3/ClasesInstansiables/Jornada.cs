using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;
using EntidadesAbstractas;

namespace ClasesInstansiables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lista Alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad de lista Clases
        /// </summary>
        public Universidad.EClases Clases
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lista Instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }

        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa lista de alumnos.
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        /// <summary>
        /// Inicializa un objeto Jornada.
        /// </summary>
        /// <param name="clase"></param>
        /// <param name="instructor"></param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Instructor = instructor;
            this.Clases = clase;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Devuelve una cadena que representa al objeto actual.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CLASE DE {0} POR {1}", this.Clases, this.Instructor.ToString());
            sb.AppendLine("ALUMNOS:");

            foreach (Alumno alumno in this.Alumnos)
            {
                sb.Append(alumno.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Guarda los datos de la jornada enun archivo de texto en "../Test/Jornadas.txt" . Puede lanzar excepciones.
        /// </summary>
        /// <param name="jornada">Jornada con datos a almacenar en archivo.</param>
        /// <returns></returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTxt = new Texto(); 
            return archivoTxt.Guardar("..\\..\\Jornadas.txt", jornada.ToString());
        }
        /// <summary>
        /// Lee los datos de un archivo de texto previamente generado con el método Guardar y lo devuelve como una cadena de caracteres.
        /// Puede lanzar excepciones.
        /// </summary>
        /// <returns></returns>
        public static string Leer()
        {
            Texto archivoTxt = new Texto();
            string retorno;
            archivoTxt.Leer("..\\..\\Jornadas.txt", out retorno);
            return retorno;
        }

        #endregion

        #region Sobrecargas de operadores
        /// <summary>
        /// 
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool ver = false;
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    ver = true;
                    break;
                }
            }
            return ver;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return j;
        }

        #endregion
    }
}
