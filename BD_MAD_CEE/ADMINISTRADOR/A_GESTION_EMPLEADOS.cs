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

        private void A_GESTION_EMPLEADOS_Load(object sender, EventArgs e)
        {
           
            EnlaceDB con = new EnlaceDB();

            var empleados = con.sp_GetDataTable("SelectEmpleados");
            CMBA_EMPLEADOS.DataSource = empleados;
            CMBA_EMPLEADOS.DisplayMember = "id_Empleado";
            DataRow[] emp = empleados.Select("id_Empleado = " + CMBA_EMPLEADOS.Text);
            foreach(DataRow row in emp)
            {
                TEXTA_NOMBRES.Text = row["Nombre"].ToString();
                DTP_FNAC.Text = row["Fecha_Nacimiento"].ToString();
            }

                        
        }

        private void BTNA_GUARDAR_Click(object sender, EventArgs e)
        {
            EnlaceDB con = new EnlaceDB();
            
            con.sp_Empleados("Insert", null, TEXTA_NOMBRES.Text, TEXTA_AP.Text, TEXTA_AM.Text, TEXTA_USUARIO.Text, TEXTA_CLAVE.Text,
                                TEXTA_RFC.Text, TEXTA_CURP.Text, DTP_FNAC.Value.ToString("yyyyMMdd"), 1, "admin");

        }

        
    }
}
