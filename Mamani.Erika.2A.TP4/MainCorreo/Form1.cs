using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        private Correo correo;
        public Form1()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void ActualizarEstados()
        {

            foreach (Control item in this.groupBox1.Controls)
            {
                if (item is ListBox)
                {
                    ((ListBox)item).Items.Clear();
                }
            }

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnviaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paq = new Paquete(this.txtDireccion.Text,this.mTxtTrackingId.Text);
            paq.InformaEstado += this.paq_InformaEstado;
            paq.InformarException += this.paq_InformaExcepcion;

            try 
            {
                this.correo += paq;
                this.ActualizarEstados();
            }
            catch(TrackingIdRepetidoException ep)
            {
              MessageBox.Show(ep.Message,"Paquete repetido", MessageBoxButtons.OK);
            }
            
        }

        private void paq_InformaExcepcion(Exception e)
        {
            MessageBox.Show(e.Message, "Error al enviar el paquete.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
          if (this.InvokeRequired)
          {
              Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
              this.Invoke( d, new object[] {sender, e} ); 
          }
          else
          {
              this.ActualizarEstados();
          }
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {   
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }
       
         void MostrarInformacion<T>(IMostrar<T> elemento)
         {
            if (((object)elemento) != null)
            {
                this.rtbMostar.Text = elemento.MostrarDatos(elemento);
                (elemento.MostrarDatos(elemento)).Guardar("salida.txt");
            }
         }

         private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
         {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
         }
    }
}
