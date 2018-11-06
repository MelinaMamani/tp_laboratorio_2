using Archivos;
using Excepciones;
using System.Collections.Generic;
using System.Text;

namespace ClasesInstansiables
{
    public class Universidad
    {
        #region Enumerado
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

        #region Atributos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region Propiedades

        /// <summary>
        /// Propiedad lista Alumnos
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
        /// Propiedad lista Instructores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad lista Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i < this.Jornadas.Count && i >= 0)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i < this.Jornadas.Count && i > 0)
                {
                    this.Jornadas[i] = value;
                }
            }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Genera un objeto universidad con todos sus campos inicializados.
        /// </summary>
        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Genera una cadena con los datos de un objeto universidad y la devuelve.
        /// </summary>
        /// <param name="g">Objeto universidad con datos a guardar en cadena.</param>
        /// <returns></returns>
        private static string MostrarDatos(Universidad g)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA: ");
            foreach (Jornada j in g.Jornadas)
            {
                sb.Append(j.ToString());
                sb.AppendLine("<-------------------------------------------------->");
            }

            return sb.ToString();
        }
        /// <summary>
        /// Devuelve una cadena que representa a la instancia universidad actual.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        /// <summary>
        /// Guarda los datos del objeto universidad en un archivo en "../Test/Universidad.xml". Puede lanza una excepción.
        /// </summary>
        /// <param name="g">Objeto universidad con datos a guardar.</param>
        /// <returns></returns>
        public static bool Guardar(Universidad g)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar("..\\..\\Universidad.xml", g);
            //return xml.Guardar("C:/Users/Usuario/Desktop/Universidad.xml", g);
        }
        /// <summary>
        /// Lee los datos de un archivo XML previamente generado con el método guardar. Lo deserializa y devuelve como un 
        /// objeto Universidad. Puede lanza una excepción.
        /// </summary>
        /// <returns></returns>
        public static Universidad Leer()
        {
            Universidad u = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer("..\\..\\Universidad.xml", out u);
            //xml.Leer("C:/Users/Usuario/Desktop/Universidad.xml", out u);
            return u;
        }

        #endregion

        #region Sobrecargas de operadores
        /// <summary>
        /// Un alumno será igual a una universidad si está registrado en la misma.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool ver = false;
            foreach (Alumno aux in g.Alumnos)
            {
                if (a == aux)
                {
                    ver = true;
                    break;
                }
            }
            return ver;
        }
        /// <summary>
        /// Un alumno será distinto a una universidad si no está registrado en la misma.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// /// Un profesor será igual a una universidad si dicta clases en ella.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="i">Profesor a comparar.</param>
        /// <returns></returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool ver = false;

            foreach (Profesor p in g.Instructores)
            {
                if (i == p)
                {
                    ver = true;
                    break;
                }
            }
            return ver;
        }
        /// <summary>
        /// Un profesor será distinto a una universidad si no dicta clases en ella.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="i">Profesor a comparar.</param>
        /// <returns></returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Una universidad será igual una clase si esta contiene un profesor capaz de dictarla. Devuelve el primer profesor coincidente.
        /// En caso de no haber ningún profesor lanza una excepción.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            Profesor p = null;

            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                {
                    p = profesor;
                    break;
                }
            }

            if (p is null)
            {
                throw new SinProfesorException();
            }

            return p;
        }

        /// <summary>
        /// Una universidad será distinta a una clase si no hay un profesor registrado capaz de dictarla. Devuelve el primer profesor 
        /// coincidente. En caso de no haber ningún profesor lanza una excepción.
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            Profesor pr = null;

            foreach (Profesor p in g.Instructores)
            {
                if (p != clase)
                {
                    pr = p;
                    break;
                }
            }

            return pr;
        }

        /// <summary>
        /// Agrega un alumno a la universidad si este ya no se encuentra en la misma.
        /// </summary>
        /// <param name="g">Universidad donde agregar alumno.</param>
        /// <param name="a">Alumno a agregar a la universidad.</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return g;
        }

        /// <summary>
        /// Agrega una jornada a la universidad con la clase pasada por parámetro y un profesor de la universidad capaz de dictarla. 
        /// Si no hay uno se genera una excepción.
        /// </summary>
        /// <param name="g">Universidad donde agergar Clase.</param>
        /// <param name="clase">Clase a agregar a la universidad.</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);

            foreach (Alumno a in g.Alumnos)
            {
                if (a == clase)
                {
                    jornada += a;
                }
            }

            g.Jornadas.Add(jornada);

            return g;
        }

        /// <summary>
        /// Agerga un profesor a una universidad si ya no se encuentra en la misma.
        /// </summary>
        /// <param name="g">Universidad donde agregar profesor.</param>
        /// <param name="i">Profesor a agregar a la universidad.</param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }
            return g;
        }

        #endregion
    }
}
