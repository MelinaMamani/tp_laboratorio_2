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

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
            this.txtNumero1.Multiline = true;
            this.txtNumero2.Multiline = true;

            this.cmbOperador.SelectedItem = "/";
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text == null)
            {
                this.lblResultado.Text = "Campo vacío.";
            }
            else
            {
                this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text == null)
            {
                this.lblResultado.Text = "Campo vacío.";
            }
            else
            {
                this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
            }
        }
        
        private void Limpiar()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox || item is Label)
                {
                    item.Text = "";
                }
            }
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double rdo = 0;

            Numero num = new Numero(numero1);
            Numero num2 = new Numero(numero2);

            rdo = Calculadora.Operar(num, num2, operador);

            return rdo;
        }
    }
}
