using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_MAD_CEE.ADMINISTRADOR
{
    public partial class A_GESTION_EMPLEADOS : Form
    {
        public A_GESTION_EMPLEADOS()
        {
            InitializeComponent();
            
            
        }

        private void BTNA_GUARDAR_Click(object sender, EventArgs e)
        {
            EnlaceDB con = new EnlaceDB();
            
            con.sp_Empleados("Insert", null, TEXTA_NOMBRES.Text, TEXTA_AP.Text, TEXTA_AM.Text, TEXTA_USUARIO.Text, TEXTA_CLAVE.Text,
                                TEXTA_RFC.Text, TEXTA_CURP.Text, DTP_FNAC.Value.ToString("yyyyMMdd"), 1, "admin");

        }
    }
}
