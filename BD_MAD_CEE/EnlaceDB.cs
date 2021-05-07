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


        public void sp_Empleados(string opc, string id, string nombre, string apellidoP, string apellidoM, string nombreUsuario,
                      string contrasenia, string RFC, string CURP, string fechaNac, int activo, string usuarioAdministrador)
        {
            try
            {
                conectar();
                string qry = "sp_Empleados";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 10);
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
                var parametro12 = _comando.Parameters.Add("@Usuario_Administrador", SqlDbType.VarChar, 20);
                parametro12.Value = usuarioAdministrador;

                _adaptador.InsertCommand = _comando;
                _comando.ExecuteNonQuery();
            }
            catch (SqlException exc)
            {
                MessageBox.Show(exc.Message, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            finally
            {

                desconectar();
            }
        }

    }
}
