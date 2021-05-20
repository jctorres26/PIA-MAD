using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BD_MAD_CEE
{
    public class EnlaceDB
    {

        static private SqlConnection _conexion;
        static private SqlCommand _comando = new SqlCommand();
        static private SqlDataAdapter _adaptador = new SqlDataAdapter();
        static private EnlaceDB _instance = null;

        private static void conectar()
        {
            string conexion = ConfigurationManager.ConnectionStrings["SQLServer"].ToString();
            _conexion = new SqlConnection(conexion);
            _conexion.Open();

        }

        private static void desconectar()
        {
            _conexion.Close();
        }

        static public EnlaceDB getInstance()
        {
            if(_instance == null)
            {
                _instance = new EnlaceDB();
            }
            return _instance;
        }


        public void sp_Empleados(string opc, int id, string nombre, string apellidoP, string apellidoM, string nombreUsuario,
                      string contrasenia, string RFC, string CURP, string fechaNac, int activo, int eliminado, string usuarioAdministrador)
        {
            try
            {
                conectar();
                string qry = "sp_Empleados";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@id_Empleado", SqlDbType.Int);
                parametro2.Value = id;
                var parametro3 = _comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
                parametro3.Value = nombre;
                var parametro4 = _comando.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 25);
                parametro4.Value = apellidoP;
                var parametro5 = _comando.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 25);
                parametro5.Value = apellidoM;
                var parametro6 = _comando.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 20);
                parametro6.Value = nombreUsuario;
                var parametro7 = _comando.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 20);
                parametro7.Value = contrasenia;
                var parametro8 = _comando.Parameters.Add("@RFC", SqlDbType.VarChar, 13);
                parametro8.Value = RFC;
                var parametro9 = _comando.Parameters.Add("@CURP", SqlDbType.VarChar, 18);
                parametro9.Value = CURP;
                var parametro10 = _comando.Parameters.Add("@Fecha_Nacimiento", SqlDbType.VarChar,10);
                parametro10.Value = fechaNac;
                var parametro11 = _comando.Parameters.Add("@Activo", SqlDbType.Bit);
                parametro11.Value = activo;
                var parametro12 = _comando.Parameters.Add("@Eliminado", SqlDbType.Bit);
                parametro11.Value = eliminado;
                var parametro13 = _comando.Parameters.Add("@Usuario_Administrador", SqlDbType.VarChar, 20);
                parametro13.Value = usuarioAdministrador;

                _adaptador.InsertCommand = _comando;
                _comando.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                string warning = "Ha ocurrido una excepcion en la base de datos \n";
                warning += exc.Message;
                MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
        }

        public bool sp_Clientes(string opc, int id, string nombre, string apellidoP, string apellidoM, string nombreUsuario,
                      string contrasenia, string email, string genero, string CURP, string fechaNac, int activo, 
                      int eliminado)
        {
            bool agregado = true;
            try
            {
                conectar();
                string qry = "sp_Clientes";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@id_Cliente", SqlDbType.Int);
                parametro2.Value = id;
                var parametro3 = _comando.Parameters.Add("@Nombre", SqlDbType.VarChar, 50);
                parametro3.Value = nombre;
                var parametro4 = _comando.Parameters.Add("@Apellido_Paterno", SqlDbType.VarChar, 25);
                parametro4.Value = apellidoP;
                var parametro5 = _comando.Parameters.Add("@Apellido_Materno", SqlDbType.VarChar, 25);
                parametro5.Value = apellidoM;
                var parametro6 = _comando.Parameters.Add("@Nombre_Usuario", SqlDbType.VarChar, 20);
                parametro6.Value = nombreUsuario;
                var parametro7 = _comando.Parameters.Add("@Contrasenia", SqlDbType.VarChar, 20);
                parametro7.Value = contrasenia;
                var parametro8 = _comando.Parameters.Add("@Email", SqlDbType.VarChar, 50);
                parametro8.Value = email;
                var parametro9 = _comando.Parameters.Add("@Genero", SqlDbType.VarChar, 10);
                parametro9.Value = genero;
                var parametro10 = _comando.Parameters.Add("@CURP", SqlDbType.VarChar, 18);
                parametro10.Value = CURP;
                var parametro11 = _comando.Parameters.Add("@Fecha_Nacimiento", SqlDbType.VarChar, 10);
                parametro11.Value = fechaNac;
                var parametro12 = _comando.Parameters.Add("@Activo", SqlDbType.Bit);
                parametro12.Value = activo;
                var parametro13 = _comando.Parameters.Add("@Eliminado", SqlDbType.Bit);
                parametro13.Value = eliminado;

                _adaptador.InsertCommand = _comando;
                _comando.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                agregado = false;
                string warning = "Ha ocurrido una excepcion en la base de datos \n";
                warning += exc.Message;
                MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return agregado;
        }


        public bool sp_Contrato(string opc, int numServ, int numMed, string tipoServ, int idCliente, int idEmpleado, int CP,
                        string estado, string ciudad, string colonia, string calle, int numExt)
        {
            bool agregado = true;
            try
            {
                conectar();
                string qry = "sp_Contrato";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@Numero_Servicio", SqlDbType.Int);
                parametro2.Value = numServ;
                var parametro3 = _comando.Parameters.Add("@Numero_Medidor", SqlDbType.Int);
                parametro3.Value = numMed;
                var parametro4 = _comando.Parameters.Add("@Tipo_Servicio", SqlDbType.VarChar, 10);
                parametro4.Value = tipoServ;
                var parametro5 = _comando.Parameters.Add("@id_Cliente", SqlDbType.Int);
                parametro5.Value = idCliente;
                var parametro6 = _comando.Parameters.Add("@id_Empleado", SqlDbType.Int);
                parametro6.Value = idEmpleado;
                var parametro7 = _comando.Parameters.Add("@CP", SqlDbType.Int);
                parametro7.Value = CP;
                var parametro8 = _comando.Parameters.Add("@Estado", SqlDbType.VarChar, 30);
                parametro8.Value = estado;
                var parametro9 = _comando.Parameters.Add("@Ciudad", SqlDbType.VarChar, 50);
                parametro9.Value = ciudad;
                var parametro10 = _comando.Parameters.Add("@Colonia", SqlDbType.VarChar, 50);
                parametro10.Value = colonia;
                var parametro11 = _comando.Parameters.Add("@Calle", SqlDbType.VarChar, 40);
                parametro11.Value = calle;
                var parametro12 = _comando.Parameters.Add("@Numero_Exterior", SqlDbType.Int);
                parametro12.Value = numExt;
             

                _adaptador.InsertCommand = _comando;
                _comando.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                agregado = false;
                string warning = "Ha ocurrido una excepcion en la base de datos \n";
                warning += exc.Message;
                MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }
            return agregado;
        }


            public DataTable sp_GetDataTable(string opc)
        {
            DataTable table = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GetDataTable";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;

                _adaptador.SelectCommand = _comando;
                _adaptador.Fill(table);
                
            }
            catch(SqlException exc)
            {
                string warning = "Ha ocurrido una excepcion en la base de datos \n";
                warning += exc.Message;
                MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            finally
            {
                desconectar();
            }

            return table;
        }



        public DataTable sp_Admin(string opc)
        {
            DataTable table = new DataTable();

            try
            {
                conectar();
                string qry = "sp_Admin";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;

                _adaptador.SelectCommand = _comando;
                _adaptador.Fill(table);

            }
            catch (SqlException exc)
            {
                string warning = "Ha ocurrido una excepcion en la base de datos \n";
                warning += exc.Message;
                MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            finally
            {
                desconectar();
            }

            return table;
        }

        public void sp_GestionClientes(string opc, int idEmpleado, int idCliente)
        {
            try
            {
                conectar();
                string qry = "sp_GestionClientes";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@id_Empleado", SqlDbType.Int);
                parametro2.Value = idEmpleado;
                var parametro3 = _comando.Parameters.Add("@id_Cliente", SqlDbType.Int);
                parametro3.Value = idCliente;

                _adaptador.InsertCommand = _comando;
                _comando.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                string warning = "Ha ocurrido una excepcion en la base de datos \n";
                warning += exc.Message;
                MessageBox.Show(warning, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {
                desconectar();
            }

        }

    }
}
