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

        private int suspendidoEmp = 0;
        private int suspendidoCli = 0;
        private bool logged = false;
        private string usuarioAux = "";
        private int idEmpleadoActual;
        private int idClienteActual;

        
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


                EnlaceDB con = EnlaceDB.getInstance();

                DataTable admin = con.sp_Admin("Select");

                foreach (DataRow row in admin.Rows) {

                    if (TEXTL_USUARIO.Text == row["Nombre_Usuario"].ToString() && TEXTL_CLAVE.Text == row["Contrasenia"].ToString())
                    {
                        this.Hide();
                        Form form = new A_GESTION_EMPLEADOS(TEXTL_USUARIO.Text);
                        form.ShowDialog();
                        logged = true;

                    }
                }

                if (logged == false)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

                   
                
            }

            else if (CMBL_TIPO.Text == "Empleado")
            {
                            

                EnlaceDB con = EnlaceDB.getInstance();

                DataTable empleados = con.sp_GetDataTable("SelectUsuariosEmpleados");

                foreach (DataRow row in empleados.Rows)
                {
                    if (TEXTL_USUARIO.Text == row["Nombre_Usuario"].ToString() && TEXTL_CLAVE.Text == row["Contrasenia"].ToString())
                    {
                        idEmpleadoActual = Int32.Parse(row["id_Empleado"].ToString());
                        
                        this.Hide();
                        Form form = new E_PANTALLA_PRINCIPAL(idEmpleadoActual);
                        
                        form.ShowDialog();
                        logged = true;

                        


                    }
                    else if (CBL_RECORDAR.Checked == true && TEXTL_USUARIO.Text == row["Nombre_Usuario"].ToString())
                    {
                        idEmpleadoActual = Int32.Parse(row["id_Empleado"].ToString());
                        this.Hide();
                        Form form = new E_PANTALLA_PRINCIPAL(idEmpleadoActual);
                        form.ShowDialog();
                        logged = true;
                       


                    }

                }
                if (logged == false)
                {

                    if (usuarioAux == TEXTL_USUARIO.Text)
                    {

                        suspendidoEmp++;
                    }
                    else
                    {
                        suspendidoEmp = 0;
                    }

                    if (suspendidoEmp == 0)
                    {
                        usuarioAux = TEXTL_USUARIO.Text;
                        suspendidoEmp++;
                    }
                  

                    if (suspendidoEmp == 3)
                    {
                        con.sp_Empleados("Suspender", 0, null, null, null, TEXTL_USUARIO.Text, null,
                                   null, null, null, 1, 1, null);
                        MessageBox.Show("El usuario ha sido suspendido", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        suspendidoEmp = 0;

                    }
                    else
                    {

                        MessageBox.Show("Usuario o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

               
               
                
            }


            else if (CMBL_TIPO.Text == "Cliente")
            {

                
                EnlaceDB con = EnlaceDB.getInstance();

                DataTable clientes = con.sp_GetDataTable("SelectUsuariosClientes");



                foreach (DataRow row in clientes.Rows)
                {
                    if (TEXTL_USUARIO.Text == row["Nombre_Usuario"].ToString() && TEXTL_CLAVE.Text == row["Contrasenia"].ToString())
                    {
                        idClienteActual = Int32.Parse(row["id_Cliente"].ToString());
                        this.Hide();
                        Form form = new C_CLIENTES(idClienteActual);
                        form.ShowDialog();
                        logged = true;


                    }
                    else if (CBL_RECORDAR.Checked == true && TEXTL_USUARIO.Text == row["Nombre_Usuario"].ToString())
                    {
                        idClienteActual = Int32.Parse(row["id_Cliente"].ToString());
                        this.Hide();
                        Form form = new C_CLIENTES(idClienteActual);
                        form.ShowDialog();
                        logged = true;


                    }
                }
                    if (logged == false)
                    {

                        if (usuarioAux == TEXTL_USUARIO.Text)
                        {

                            suspendidoCli++;
                        }
                        else
                        {
                            suspendidoCli = 0;
                        }

                        if (suspendidoCli == 0)
                        {
                            usuarioAux = TEXTL_USUARIO.Text;
                            suspendidoCli++;
                        }


                        if (suspendidoCli == 3)
                        {
                            con.sp_Clientes("Suspender", 0, null, null, null, TEXTL_USUARIO.Text, null, null
                                     , null, null, null, 1, 0);
                            MessageBox.Show("El usuario ha sido suspendido", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            suspendidoCli = 0;

                        }
                        else
                        {

                            MessageBox.Show("Usuario o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }  
                


            }


        }

        private void CBL_RECORDAR_CheckedChanged(object sender, EventArgs e)
        {
            if (CBL_RECORDAR.Checked == true) {
                if (CMBL_TIPO.Text == "Empleado")
                {
                    EnlaceDB con = EnlaceDB.getInstance();

                    DataTable empleados = con.sp_GetDataTable("SelectUsuariosEmpleados");



                    foreach (DataRow row in empleados.Rows)
                    {
                        if (TEXTL_USUARIO.Text == row["Nombre_Usuario"].ToString())
                        {

                            TEXTL_CLAVE.Text = row["Contrasenia"].ToString();
                        }
                    }

                }
                else if (CMBL_TIPO.Text == "Cliente")
                {
                    EnlaceDB con = EnlaceDB.getInstance();

                    DataTable clientes = con.sp_GetDataTable("SelectUsuariosClientes");



                    foreach (DataRow row in clientes.Rows)
                    {
                        if (TEXTL_USUARIO.Text == row["Nombre_Usuario"].ToString())
                        {

                            TEXTL_CLAVE.Text = row["Contrasenia"].ToString();
                        }
                    }

                }
            }

        }
    }
}
