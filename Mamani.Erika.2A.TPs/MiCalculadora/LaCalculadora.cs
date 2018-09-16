using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void txtNumero2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

        }
    }
}
