using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BD_MAD_CEE.EMPLEADO
{
    public partial class E_PANTALLA_PRINCIPAL : Form 
    {
        public E_PANTALLA_PRINCIPAL(int id)
        {
            InitializeComponent();
            idEmpleadoActual = id;
        }

        private void E_PANTALLA_PRINCIPAL_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private bool loaded = false;
        private int  idEmpleadoActual;
        private DataTable clientes;
       

        private void E_PANTALLA_PRINCIPAL_Load(object sender, EventArgs e)
        {
            CMBE_TIPOS.Items.Add("Domestico");
            CMBE_TIPOS.Items.Add("Industrial");
            CMBE_GENERO.Items.Add("Masculino");
            CMBE_GENERO.Items.Add("Femenino");
            LoadCombo();
            loaded = true;
        }


        private void LoadCombo()
        {

            EnlaceDB con = EnlaceDB.getInstance();

            clientes = con.sp_GetDataTable("SelectClientes");
            CMBE_CLIENTES.DataSource = clientes;
            CMBE_CLIENTES.DisplayMember = "Nombre";
            CMBE_CLIENTES.ValueMember = "id_Cliente";
            CMBE_CLIENTES.SelectedIndex = -1;

        }

        private void BTNE_CNUEVO_Click(object sender, EventArgs e)
        {
            if ((TXTE_NOMBRES.Text != "") && (TXTE_AP.Text != "") && (TXTE_AM.Text != "") && (TXTE_USUARIO.Text != "")
               && (TXTE_CURP.Text != "") && (TXTE_EMAIL.Text != "") && (TXTE_CLAVE.Text != "") && (CMBE_GENERO.Text != "")
               && (TXTE_ESTADO.Text != "") && (CMBE_TIPOS.Text != "") && (TXTE_CIUDAD.Text != "") && (TXTE_COLONIA.Text != "")
               && (TXTE_CALLE.Text != "") && (TXTE_NUMCASA.Text != "") && (TXTE_CP.Text != "") && (TXTE_MEDIDOR.Text != "")
               && CMBE_CLIENTES.SelectedIndex == -1)
            {
                EnlaceDB con = EnlaceDB.getInstance();

                int numServ = Int32.Parse(TXTE_MEDIDOR.Text);
                int cp = Int32.Parse(TXTE_CP.Text);
                int numExt = Int32.Parse(TXTE_NUMCASA.Text);
                


                bool bCliente = con.sp_Clientes("Insert", 0, TXTE_NOMBRES.Text, TXTE_AP.Text, TXTE_AM.Text, TXTE_USUARIO.Text, TXTE_CLAVE.Text,
                                    TXTE_EMAIL.Text, CMBE_GENERO.Text, TXTE_CURP.Text, DTPE_FNAC.Value.ToString("yyyyMMdd"), 1, 0);

                bool bContrato = con.sp_Contrato("Insert", 0, numServ, CMBE_TIPOS.Text, 0, idEmpleadoActual, cp, TXTE_ESTADO.Text, TXTE_CIUDAD.Text, TXTE_COLONIA.Text,
                                   TXTE_CALLE.Text, numExt);

                string usuarioCliente = TXTE_USUARIO.Text;

                loaded = false;
                LimpiarCampos();
                LoadCombo();
                loaded = true;

                if (bCliente == true && bContrato == true)
                {
                    foreach (DataRow row in clientes.Rows)
                    {
                        if (usuarioCliente == row["Nombre_Usuario"].ToString())
                        {
                            int idCliente = Int32.Parse(row["id_Cliente"].ToString());
                            con.sp_GestionClientes("Alta", idEmpleadoActual, idCliente);
                        }
                    }
                }
            }
            else if (((TXTE_NOMBRES.Text == "") || (TXTE_AP.Text != "") || (TXTE_AM.Text != "") || (TXTE_USUARIO.Text != "")
               || (TXTE_CURP.Text == "") || (TXTE_EMAIL.Text != "") && (TXTE_CLAVE.Text != "") || (CMBE_GENERO.Text != "")
               || (TXTE_ESTADO.Text == "") || (CMBE_TIPOS.Text != "") || (TXTE_CIUDAD.Text != "") || (TXTE_COLONIA.Text != "")
               || (TXTE_CALLE.Text != "") || (TXTE_NUMCASA.Text != "") || (TXTE_CP.Text != "") || (TXTE_MEDIDOR.Text != ""))
               && CMBE_CLIENTES.SelectedIndex == -1) {

                MessageBox.Show("Favor de llenar todos los campos.", "Gestion de Clientes", MessageBoxButtons.OK);
            }


            else if((TXTE_ESTADO.Text != "") && (CMBE_TIPOS.Text != "") && (TXTE_CIUDAD.Text != "") && (TXTE_COLONIA.Text != "")
               && (TXTE_CALLE.Text != "") && (TXTE_NUMCASA.Text != "") && (TXTE_CP.Text != "") && (TXTE_MEDIDOR.Text != "")
                && CMBE_CLIENTES.SelectedIndex != -1)
            {
                EnlaceDB con = EnlaceDB.getInstance();

                int numServ = Int32.Parse(TXTE_MEDIDOR.Text);
                int cp = Int32.Parse(TXTE_CP.Text);
                int numExt = Int32.Parse(TXTE_NUMCASA.Text);
                int idCliente = Int32.Parse(CMBE_CLIENTES.SelectedValue.ToString());

                con.sp_Contrato("InsertNuevo", 0, numServ, CMBE_TIPOS.Text, idCliente, idEmpleadoActual, cp, TXTE_ESTADO.Text, TXTE_CIUDAD.Text,
                    TXTE_COLONIA.Text, TXTE_CALLE.Text, numExt);

                loaded = false;
                LimpiarCampos();
                LoadCombo();
                loaded = true;

            }
            else
            {
                MessageBox.Show("Favor de llenar todos los campos del contrato.", "Gestion de Clientes", MessageBoxButtons.OK);
            }

               
           

        }

        private void CMBE_CLIENTES_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded == true)
            {

                EnlaceDB con = EnlaceDB.getInstance();

                clientes = con.sp_GetDataTable("SelectClientes");
                DataRow[] cliente = clientes.Select("id_Cliente = " + CMBE_CLIENTES.SelectedValue);
                TXTE_NOMBRES.Text = cliente[0]["Nombre"].ToString();
                TXTE_AP.Text = cliente[0]["Apellido_Paterno"].ToString();
                TXTE_AM.Text = cliente[0]["Apellido_Materno"].ToString();
                TXTE_CURP.Text = cliente[0]["CURP"].ToString();
                TXTE_EMAIL.Text = cliente[0]["Email"].ToString();
                TXTE_USUARIO.Text = cliente[0]["Nombre_Usuario"].ToString();
                TXTE_CLAVE.Text = cliente[0]["Contrasenia"].ToString();
                DTPE_FNAC.Text = cliente[0]["Fecha_Nacimiento"].ToString();
                if (cliente[0]["Genero"].ToString() == "Masculino")
                {
                    CMBE_GENERO.SelectedIndex = 0;
                }
                else
                {
                    CMBE_GENERO.SelectedIndex = 1;
                }


            }

        }

        private void LimpiarCampos()
        {
            CMBE_CLIENTES.SelectedIndex = -1;
            CMBE_TIPOS.SelectedIndex = -1;
            CMBE_GENERO.SelectedIndex = -1;
            TXTE_NOMBRES.Text = "";
            TXTE_AP.Text = "";
            TXTE_AM.Text = "";
            TXTE_CURP.Text = "";
            TXTE_EMAIL.Text = "";
            TXTE_USUARIO.Text = "";
            TXTE_CLAVE.Text = "";
            TXTE_ESTADO.Text = "";
            TXTE_CIUDAD.Text = "";
            TXTE_COLONIA.Text = "";
            TXTE_CALLE.Text = "";
            TXTE_NUMCASA.Text = "";
            TXTE_CP.Text = "";
            TXTE_MEDIDOR.Text = "";

        }

        private void BTNE_LIMPIAR_Click(object sender, EventArgs e)
        {
            loaded = false;
            LimpiarCampos();
            loaded = true;
        }

        private void BTNE_REESTABLCER_Click(object sender, EventArgs e)
        {

            if (CMBE_CLIENTES.SelectedIndex != -1)
            {
                EnlaceDB con = EnlaceDB.getInstance();
                int idCliente = Int32.Parse(CMBE_CLIENTES.SelectedValue.ToString());

                con.sp_Clientes("Restablecer", idCliente, TXTE_NOMBRES.Text, TXTE_AP.Text, TXTE_AM.Text, TXTE_USUARIO.Text, TXTE_CLAVE.Text,
                                        TXTE_EMAIL.Text, CMBE_GENERO.Text, TXTE_CURP.Text, DTPE_FNAC.Value.ToString("yyyyMMdd"), 1, 0);
            }
            
        }

        private void BTNE_BAJA_Click(object sender, EventArgs e)
        {
            if (CMBE_CLIENTES.SelectedIndex != -1)
            {
                EnlaceDB con = EnlaceDB.getInstance();
                int idCliente = Int32.Parse(CMBE_CLIENTES.SelectedValue.ToString());

                con.sp_Clientes("Delete", idCliente, TXTE_NOMBRES.Text, TXTE_AP.Text, TXTE_AM.Text, TXTE_USUARIO.Text, TXTE_CLAVE.Text,
                                        TXTE_EMAIL.Text, CMBE_GENERO.Text, TXTE_CURP.Text, DTPE_FNAC.Value.ToString("yyyyMMdd"), 1, 0);


                loaded = false;
                LimpiarCampos();
                LoadCombo();
                loaded = true;
            }

            
        }

        private void BTNE_ACTUALIZAR_Click(object sender, EventArgs e)
        {
            if (CMBE_CLIENTES.SelectedIndex != -1)
            {
                if ((TXTE_NOMBRES.Text != "") && (TXTE_AP.Text != "") && (TXTE_AM.Text != "") && (TXTE_USUARIO.Text != "")
               && (TXTE_CURP.Text != "") && (TXTE_EMAIL.Text != "") && (TXTE_CLAVE.Text != "") && (CMBE_GENERO.Text != ""))
                {
                    EnlaceDB con = EnlaceDB.getInstance();
                    int idCliente = Int32.Parse(CMBE_CLIENTES.SelectedValue.ToString());

                   bool bCliente= con.sp_Clientes("Update", idCliente, TXTE_NOMBRES.Text, TXTE_AP.Text, TXTE_AM.Text, TXTE_USUARIO.Text, TXTE_CLAVE.Text,
                                            TXTE_EMAIL.Text, CMBE_GENERO.Text, TXTE_CURP.Text, DTPE_FNAC.Value.ToString("yyyyMMdd"), 1, 0);

                    loaded = false;
                    LimpiarCampos();
                    LoadCombo();
                    loaded = true;

                    if (bCliente == true)
                    {
                        con.sp_GestionClientes("Cambio", idEmpleadoActual, idCliente);

                    }

                }
                else
                {
                    MessageBox.Show("Favor de llenar todos los campos del cliente", "Gestion de Clientes", MessageBoxButtons.OK);
                }


            }

        }

        
    }
}
