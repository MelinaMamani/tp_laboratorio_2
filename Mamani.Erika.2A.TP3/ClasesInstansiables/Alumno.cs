using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace ClasesInstansiables
{
    public sealed class Alumno : Universitario
    {
        #region Enumerado anidado

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        #endregion

        #region Atributos

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;

        #endregion

        #region Constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Métodos

        protected override string ParticiparEnClase()
        {
            return string.Format("\nTOMA CLASES DE {0}", this.claseQueToma);
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("\nESTADO DE CUENTA: ");
            switch (this.estadoCuenta)
            {
                case EEstadoCuenta.AlDia:
                    sb.AppendLine("Cuota al dia");
                    break;
                case EEstadoCuenta.Deudor:
                    sb.AppendLine("Deudor");
                    break;
                case EEstadoCuenta.Becado:
                    sb.AppendLine("Becado");
                    break;
                default:
                    break;
            }
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            return (a.claseQueToma == clase) && (a.estadoCuenta != EEstadoCuenta.Deudor);
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a.claseQueToma == clase);
        }

        #endregion
    }
}
