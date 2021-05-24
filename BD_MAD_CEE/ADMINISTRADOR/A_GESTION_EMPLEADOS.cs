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
        private bool loaded = false;

        public A_GESTION_EMPLEADOS(string adm)
        {
            InitializeComponent();
            adminActual = adm;
        }

        string adminActual;
        private void A_GESTION_EMPLEADOS_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void A_GESTION_EMPLEADOS_Load(object sender, EventArgs e)
        {
                 LoadCombo();
                loaded = true;
        }

        private void LoadCombo()
        {
            EnlaceDB con = EnlaceDB.getInstance();

            DataTable empleados = con.sp_GetDataTable("SelectEmpleados");
            CMBA_EMPLEADOS.DataSource = empleados;
            CMBA_EMPLEADOS.DisplayMember = "Nombre_Completo";
            CMBA_EMPLEADOS.ValueMember = "id_Empleado";
            CMBA_EMPLEADOS.SelectedIndex = -1;

        }

        private void BTNA_GUARDAR_Click(object sender, EventArgs e)
        {
            if ((TEXTA_NOMBRES.Text !="") && (TEXTA_AP.Text != "") && (TEXTA_AM.Text != "") && (TEXTA_RFC.Text != "")
                && (TEXTA_CURP.Text != "") && (TEXTA_USUARIO.Text != "") && (TEXTA_CLAVE.Text != "")) {

                EnlaceDB con = EnlaceDB.getInstance();

                if (CMBA_EMPLEADOS.SelectedIndex == -1)
                {
                    con.sp_Empleados("Insert", 0, TEXTA_NOMBRES.Text, TEXTA_AP.Text, TEXTA_AM.Text, TEXTA_USUARIO.Text, TEXTA_CLAVE.Text,
                                        TEXTA_RFC.Text, TEXTA_CURP.Text, DTP_FNAC.Value.ToString("yyyyMMdd"), 1, 0, adminActual);
                }
                else
                {
                    int id = Int32.Parse(CMBA_EMPLEADOS.SelectedValue.ToString());
                    con.sp_Empleados("Update", id, TEXTA_NOMBRES.Text, TEXTA_AP.Text, TEXTA_AM.Text, TEXTA_USUARIO.Text, TEXTA_CLAVE.Text,
                                        TEXTA_RFC.Text, TEXTA_CURP.Text, DTP_FNAC.Value.ToString("yyyyMMdd"), 1, 0, adminActual);

                }


                loaded = false;
                LimpiarCampos();
                LoadCombo();
                loaded = true;
            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos.", "Gestion de Empleados", MessageBoxButtons.OK);
            }
        }

        private void BTNA_BORRAR_Click(object sender, EventArgs e)
        {
            if (CMBA_EMPLEADOS.SelectedIndex != -1)
            {
                EnlaceDB con = EnlaceDB.getInstance();
                int id = Int32.Parse(CMBA_EMPLEADOS.SelectedValue.ToString());
                con.sp_Empleados("Delete", id, TEXTA_NOMBRES.Text, TEXTA_AP.Text, TEXTA_AM.Text, TEXTA_USUARIO.Text, TEXTA_CLAVE.Text,
                                    TEXTA_RFC.Text, TEXTA_CURP.Text, DTP_FNAC.Value.ToString("yyyyMMdd"), 1, 1, adminActual);
                
            }
            loaded = false;
            LimpiarCampos();
            LoadCombo();
            loaded = true;



        }

        private void CMBA_EMPLEADOS_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (loaded == true)
            {
                EnlaceDB con = EnlaceDB.getInstance();

                var empleados = con.sp_GetDataTable("SelectEmpleados");
                DataRow[] emp = empleados.Select("id_Empleado = " + CMBA_EMPLEADOS.SelectedValue);
                TEXTA_NOMBRES.Text = emp[0]["Nombre"].ToString();
                DTP_FNAC.Text = emp[0]["Fecha_Nacimiento"].ToString();
                TEXTA_AP.Text = emp[0]["Apellido_Paterno"].ToString();
                TEXTA_AM.Text = emp[0]["Apellido_Materno"].ToString();
                TEXTA_CLAVE.Text = emp[0]["Contrasenia"].ToString();
                TEXTA_RFC.Text = emp[0]["RFC"].ToString();
                TEXTA_CURP.Text = emp[0]["CURP"].ToString();
                TEXTA_USUARIO.Text = emp[0]["Nombre_Usuario"].ToString();

            }
            

        }

        private void LimpiarCampos()
        {
            CMBA_EMPLEADOS.SelectedIndex = -1;
            TEXTA_NOMBRES.Text = "";
            TEXTA_AP.Text = "";
            TEXTA_AM.Text = "";
            TEXTA_CLAVE.Text = "";
            TEXTA_RFC.Text = "";
            TEXTA_CURP.Text = "";
            TEXTA_USUARIO.Text = "";
        }

        private void BTNA_LIMPIAR_Click(object sender, EventArgs e)
        {
            loaded = false;
            LimpiarCampos();
            loaded = true; 
        }

        private void BTNA_REESTABLECER_Click(object sender, EventArgs e)
        {
            if (CMBA_EMPLEADOS.SelectedIndex != -1)
            {
                EnlaceDB con = EnlaceDB.getInstance();
                int id = Int32.Parse(CMBA_EMPLEADOS.SelectedValue.ToString());
                con.sp_Empleados("Restablecer", id, TEXTA_NOMBRES.Text, TEXTA_AP.Text, TEXTA_AM.Text, TEXTA_USUARIO.Text, TEXTA_CLAVE.Text,
                                    TEXTA_RFC.Text, TEXTA_CURP.Text, DTP_FNAC.Value.ToString("yyyyMMdd"), 1, 1, adminActual);

            }

        }

        
    }
}
