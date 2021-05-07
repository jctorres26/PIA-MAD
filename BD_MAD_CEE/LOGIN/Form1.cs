using BD_MAD_CEE.ADMINISTRADOR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_MAD_CEE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BTNL_INGRESAR_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form = new A_GESTION_EMPLEADOS();
            form.ShowDialog();
            this.Close();
            
        }
    }
}
