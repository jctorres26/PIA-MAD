using BD_MAD_CEE.ADMINISTRADOR;
using BD_MAD_CEE.CLIENTE;
using BD_MAD_CEE.EMPLEADO;
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

        private void Form1_Load(object sender, EventArgs e)
        {

            CMBL_TIPO.Items.Add("Administrador");
            CMBL_TIPO.Items.Add("Empleado");
            CMBL_TIPO.Items.Add("Cliente");
            CMBL_TIPO.SelectedIndex = 0;

        }

        private void BTNL_INGRESAR_Click(object sender, EventArgs e)
        {
            if (CMBL_TIPO.Text == "Administrador")
            {
                this.Hide();
                Form form = new A_GESTION_EMPLEADOS();
                form.ShowDialog();
                this.Close();
            }
            else if (CMBL_TIPO.Text == "Empleado")
            {
                this.Hide();
                Form form = new E_PANTALLA_PRINCIPAL();
                form.ShowDialog();
                this.Close();
            }
            else if (CMBL_TIPO.Text == "Cliente")
            {
                this.Hide();
                Form form = new C_CLIENTES();
                form.ShowDialog();
                this.Close();
            }


        }

        
    }
}
