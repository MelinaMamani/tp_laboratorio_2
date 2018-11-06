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

        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }

        public Universidad.EClases Clases { get { return this.clase; } set { this.clase = value; } }

        public Profesor Instructor { get { return this.instructor; } set { this.instructor = value; } }

        #endregion

        #region Constructores

        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Instructor = instructor;
            this.Clases = clase;
        }

        #endregion

        #region Métodos

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

        public static bool Guardar(Jornada jornada)
        {
            Texto archivoTxt = new Texto(); 
            return archivoTxt.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"../Test/Archivos/Jornadas.txt", jornada.ToString());
            //return archivoTxt.Guardar("C:/Users/Usuario/Desktop/Jornadas.txt", jornada.ToString());
        }

        public static string Leer()
        {
            Texto archivoTxt = new Texto();
            string retorno;
            archivoTxt.Leer(AppDomain.CurrentDomain.BaseDirectory + @"../Test/Archivos/Jornadas.txt", out retorno);
            //archivoTxt.Leer("C:/Users/Usuario/Desktop/Jornadas.txt", out retorno);
            return retorno;
        }

        #endregion

        #region Sobrecargas de operadores

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
