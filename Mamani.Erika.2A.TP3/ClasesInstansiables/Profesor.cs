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

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor()
        {
            
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Métodos

        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                switch (Profesor.random.Next(1, 5))
                {
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;
                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;
                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;
                    case 4:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                    default:
                        break;
                }
            }
        }

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

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion

        #region Sobrecargas

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

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
