using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstansiables
{
    public class Profesor : Universitario
    {
        #region Atributos

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa el atributo estático random.
        /// </summary>
        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor()
        {
            
        }
        /// <summary>
        /// Inicializa un objeto profesor y todos sus campos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="dni"></param>
        /// <param name="nacionalidad"></param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Establece dos valores aleatorios para el atributo clasesDelDia.
        /// </summary>
        private void _randomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
        }
        /// <summary>
        /// Muestra las clases que dicta esta instancia y devuelve una cadena con las mismas.
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");

            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine(clase.ToString());
            }

            return sb.ToString();
        }
        /// <summary>
        /// Genera una cadena con los datos del objeto profesor y la devuelve.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            

            return sb.ToString();
        }
        /// <summary>
        /// Devuelve una cadena que representa al objeto actual.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas
        /// <summary>
        /// Un profesor será igual a una clase si dicta la misma.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool ver = false;

            foreach (Universidad.EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    ver = true;
                    break;
                }
            }
            return ver;
        }
        /// <summary>
        /// Un profesor será distinto a una clase si no dicta la misma.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion 
    }
}
