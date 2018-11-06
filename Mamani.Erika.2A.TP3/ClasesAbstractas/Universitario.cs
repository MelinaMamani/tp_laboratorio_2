using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributo
        private int legajo;
        #endregion

        #region Constructores

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Universitario"/>. 
        /// </summary>
        public Universitario() : base()
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de <see cref="Universitario"/>. 
        /// </summary>
        /// <param name="legajo">Legajo</param>
        /// <param name="nombre">Nombre</param>
        /// <param name="apellido">Apellido</param>
        /// <param name="dni">DNI</param>
        /// <param name="nacionalidad">Nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Métodos
        /// <summary> 
        /// Método abstracto de <see cref="Universitario"/>
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        
        /// <summary>
        /// Muestra los datos de <see cref="Universitario"/>
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("\nLEGAJO NUMERO: {0}\n", this.legajo);
            
            return sb.ToString();
        }

        #endregion

        #region Sobrecargas

        public override bool Equals(object obj)
        {
            if (obj is Universitario)
            {
                return (Universitario)obj == this;
            }

            return false;
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            return (pg1.legajo == pg2.legajo) || (pg1.DNI == pg2.DNI);
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion

    }
}
