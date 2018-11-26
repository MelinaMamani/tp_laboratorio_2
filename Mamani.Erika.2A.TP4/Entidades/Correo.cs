using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos

        List<Thread> mockPaquetes;
        List<Paquete> paquetes;

        #endregion
        #region Propiedad

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion

        #region Constructor

        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();

        }
        #endregion

        #region Sobrecarga
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya esta en la lista.");
                }

            }
            c.paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            hilo.Start();
            c.mockPaquetes.Add(hilo);

            return c;
        }
        #endregion

        #region Metodos

        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> paquetes = (List<Paquete>)((Correo)elementos).Paquetes;
            StringBuilder sb = new StringBuilder();
            foreach (Paquete paquete in paquetes)
            {
                sb.AppendLine(string.Format("{0} ({1})", paquete.ToString(), paquete.Estado.ToString()));
            }
            return sb.ToString();
        }

        #endregion
    }
}
