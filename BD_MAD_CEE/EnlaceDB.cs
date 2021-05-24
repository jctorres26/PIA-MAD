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


        public void sp_Tarifas(string opc, int idTarifa, int anio, int mes, string tipoServ, float basico, float intermedio,
            float excedente, int idEmpleado)
        {
            try
            {
                conectar();
                string qry = "sp_Tarifas";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@id_Tarifa", SqlDbType.Int);
                parametro2.Value = idTarifa;
                var parametro3 = _comando.Parameters.Add("@Anio", SqlDbType.Int);
                parametro3.Value = anio;
                var parametro4 = _comando.Parameters.Add("@Mes", SqlDbType.Int);
                parametro4.Value = mes;
                var parametro5 = _comando.Parameters.Add("@Tipo_Servicio", SqlDbType.VarChar, 10);
                parametro5.Value = tipoServ;
                var parametro6 = _comando.Parameters.Add("@Basico", SqlDbType.Money);
                parametro6.Value = basico;
                var parametro7 = _comando.Parameters.Add("@Intermedio", SqlDbType.Money);
                parametro7.Value = intermedio;
                var parametro8 = _comando.Parameters.Add("@Excedente", SqlDbType.Money);
                parametro8.Value = excedente;
                var parametro9 = _comando.Parameters.Add("@Id_Empleado", SqlDbType.Int);
                parametro9.Value = idEmpleado;
             


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


        public void sp_Consumos(string opc, int idConsumo, int numMed, string fecha, int consumo, int basico, int intermedio,
           int excedente, int idEmpleado)
        {
            try
            {
                conectar();
                string qry = "sp_Consumos";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@id_Consumo", SqlDbType.Int);
                parametro2.Value = idConsumo;
                var parametro3 = _comando.Parameters.Add("@Numero_Medidor", SqlDbType.Int);
                parametro3.Value = numMed;
                var parametro4 = _comando.Parameters.Add("@Fecha", SqlDbType.VarChar,10);
                parametro4.Value = fecha;
                var parametro5 = _comando.Parameters.Add("@Consumo", SqlDbType.Int);
                parametro5.Value = consumo;
                var parametro6 = _comando.Parameters.Add("@Basico", SqlDbType.Int);
                parametro6.Value = basico;
                var parametro7 = _comando.Parameters.Add("@Intermedio", SqlDbType.Int);
                parametro7.Value = intermedio;
                var parametro8 = _comando.Parameters.Add("@Excedente", SqlDbType.Int);
                parametro8.Value = excedente;
                var parametro9 = _comando.Parameters.Add("@id_Empleado", SqlDbType.Int);
                parametro9.Value = idEmpleado;



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

        public void sp_Recibos(string opc, int idRecibo, int numServ, int numMed, string fecha, string fechaInicio
            ,string estatus, int idConsumo, int idTarifa, float subBasico, float subIntermedio, float subExcedente, float total,
            float iva, float importe, float cantPagada, float pendiente, int idEmpleado, int idCliente, int generado)
        {
            try
            {
                conectar();
                string qry = "sp_Recibos";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@id_Recibo", SqlDbType.Int);
                parametro2.Value = idRecibo;
                var parametro3 = _comando.Parameters.Add("@Numero_Servicio", SqlDbType.Int);
                parametro3.Value = numServ;
                var parametro4 = _comando.Parameters.Add("@Numero_Medidor", SqlDbType.Int);
                parametro4.Value = numMed;
                var parametro5 = _comando.Parameters.Add("@Fecha", SqlDbType.VarChar, 10);
                parametro5.Value = fecha;
                var parametro6 = _comando.Parameters.Add("@Fecha_Inicio", SqlDbType.VarChar, 10);
                parametro6.Value = fechaInicio;
                var parametro7 = _comando.Parameters.Add("@Estatus", SqlDbType.VarChar, 20);
                parametro7.Value = estatus;
                var parametro8 = _comando.Parameters.Add("@id_Consumo", SqlDbType.Int);
                parametro8.Value = idConsumo;
                var parametro9 = _comando.Parameters.Add("@id_Tarifa", SqlDbType.Int);
                parametro9.Value = idTarifa;
                var parametro10 = _comando.Parameters.Add("@Subtotal_Basico", SqlDbType.Money);
                parametro10.Value = subBasico;
                var parametro11 = _comando.Parameters.Add("@Subtotal_Intermedio", SqlDbType.Money);
                parametro11.Value = subIntermedio;
                var parametro12 = _comando.Parameters.Add("@Subtotal_Excedente", SqlDbType.Money);
                parametro12.Value = subExcedente;
                var parametro13 = _comando.Parameters.Add("@Total", SqlDbType.Money);
                parametro13.Value = total;
                var parametro14 = _comando.Parameters.Add("@IVA", SqlDbType.Money);
                parametro14.Value = iva;
                var parametro15 = _comando.Parameters.Add("@Importe", SqlDbType.Money);
                parametro15.Value = importe;
                var parametro16 = _comando.Parameters.Add("@Cantidad_Pagada", SqlDbType.Money);
                parametro16.Value = cantPagada;
                var parametro17 = _comando.Parameters.Add("@Pendiente_Pago", SqlDbType.Money);
                parametro17.Value = pendiente;
                var parametro18 = _comando.Parameters.Add("@id_Empleado", SqlDbType.Int);
                parametro18.Value = idEmpleado;
                var parametro19 = _comando.Parameters.Add("@id_Cliente", SqlDbType.Int);
                parametro19.Value = idCliente;
                var parametro20 = _comando.Parameters.Add("@Generado", SqlDbType.Bit);
                parametro20.Value = generado;





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


        public DataTable sp_ReportesTC(string opc,int anio)
        {
            DataTable table = new DataTable();

            try
            {
                conectar();
                string qry = "sp_ReportesTC";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@Anio", SqlDbType.Int);
                parametro2.Value = anio;


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

        public DataTable sp_ReporteGeneral(string opc, int anio, int mes)
        {
            DataTable table = new DataTable();

            try
            {
                conectar();
                string qry = "sp_ReporteGeneral";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@Anio", SqlDbType.Int);
                parametro2.Value = anio;
                var parametro3 = _comando.Parameters.Add("@Mes", SqlDbType.Int);
                parametro3.Value = mes;

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

        public DataTable sp_ReporteConsumoHistorico(string opc, int anio, int numMed, int numServ)
        {
            DataTable table = new DataTable();

            try
            {
                conectar();
                string qry = "sp_ReporteConsumoHistorico";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@Anio", SqlDbType.Int);
                parametro2.Value = anio;
                var parametro3 = _comando.Parameters.Add("@Numero_Medidor", SqlDbType.Int);
                parametro3.Value = numMed;
                var parametro4 = _comando.Parameters.Add("@Numero_Servicio", SqlDbType.Int);
                parametro4.Value = numServ;

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

        public DataTable sp_GetNumeros(string opc, int idCliente)
        {
            DataTable table = new DataTable();

            try
            {
                conectar();
                string qry = "sp_GetNumeros";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@id_Cliente", SqlDbType.Int);
                parametro2.Value = idCliente;
             

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

        public void sp_GenerarRecibos(string opc, int anio, int mes, string tipoServicio, int idEmpleado)
        {
            try
            {
                conectar();
                string qry = "sp_GenerarRecibos";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@Anio", SqlDbType.Int);
                parametro2.Value = anio;
                var parametro3 = _comando.Parameters.Add("@Mes", SqlDbType.Int);
                parametro3.Value = mes;
                var parametro4 = _comando.Parameters.Add("@Tipo_Servicio", SqlDbType.VarChar, 10);
                parametro4.Value = tipoServicio;
                var parametro5 = _comando.Parameters.Add("@id_Empleado", SqlDbType.Int);
                parametro5.Value = idEmpleado;


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

        public DataTable sp_SeleccionarRecibo(string opc, int numMed, int numServ, int anio, int mes)
        {
            DataTable table = new DataTable();

            try
            {
                conectar();
                string qry = "sp_SeleccionarRecibo";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@Numero_Medidor", SqlDbType.Int);
                parametro2.Value = numMed;
                var parametro3 = _comando.Parameters.Add("@Numero_Servicio", SqlDbType.Int);
                parametro3.Value = numServ;
                var parametro4 = _comando.Parameters.Add("@Anio", SqlDbType.Int);
                parametro4.Value = anio;
                var parametro5 = _comando.Parameters.Add("@Mes", SqlDbType.Int);
                parametro5.Value = mes;


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


        public DataTable sp_RecibosClientes(string opc, int idCliente, int numServ)
        {
            DataTable table = new DataTable();

            try
            {
                conectar();
                string qry = "sp_RecibosClientes";
                _comando = new SqlCommand(qry, _conexion);
                _comando.CommandType = CommandType.StoredProcedure;
                _comando.CommandTimeout = 1200;

                var parametro1 = _comando.Parameters.Add("@Opc", SqlDbType.VarChar, 30);
                parametro1.Value = opc;
                var parametro2 = _comando.Parameters.Add("@id_Cliente", SqlDbType.Int);
                parametro2.Value = idCliente;
                var parametro3 = _comando.Parameters.Add("@Numero_Servicio", SqlDbType.Int);
                parametro3.Value = numServ;
                

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

    }
}
