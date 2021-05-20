using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_MAD_CEE.CLIENTE
{
    public partial class C_CLIENTES : Form
    {
        public C_CLIENTES(int id)
        {
            InitializeComponent();
            idClienteActual = id;
        }

        private int idClienteActual;
        private void C_CLIENTES_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
