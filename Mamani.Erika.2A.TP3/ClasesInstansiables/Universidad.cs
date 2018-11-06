using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using EntidadesAbstractas;
using Excepciones;

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

        public List<Alumno> Alumnos { get { return this.alumnos; } set { this.alumnos = value; } }

        public List<Profesor> Instructores { get { return this.profesores; } set { this.profesores = value; } }

        public List<Jornada> Jornadas { get { return this.jornada; } set { this.jornada = value; } }

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

        public Universidad()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

        #endregion

        #region Métodos

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

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool Guardar(Universidad g)
        {
            Xml<Universidad> xml = new Xml<Universidad>();
            return xml.Guardar(AppDomain.CurrentDomain.BaseDirectory + @"../Test/Archivos/Universidad.xml", g);
            //return xml.Guardar("C:/Users/Usuario/Desktop/Universidad.xml", g);
        }

        public static Universidad Leer()
        {
            Universidad u = new Universidad();
            Xml<Universidad> xml = new Xml<Universidad>();
            xml.Leer(AppDomain.CurrentDomain.BaseDirectory + @"../Test/Archivos/Universidad.xml", out u);
            //xml.Leer("C:/Users/Usuario/Desktop/Universidad.xml", out u);
            return u;
        }

        #endregion

        #region Sobrecargas de operadores

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

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
