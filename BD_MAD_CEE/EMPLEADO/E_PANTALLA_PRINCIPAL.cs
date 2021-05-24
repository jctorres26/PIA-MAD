using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsvHelper;
using System.Globalization;

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
        private DataTable recibo;
        private int pBasico = 150;
        private int pIntermedio = 100;
       private DataTable reporteG;
        private DataTable reporteCH;
        private DataTable reporteT;
        private DataTable reporteC;



        private void E_PANTALLA_PRINCIPAL_Load(object sender, EventArgs e)
        {
            CMBE_TIPOS.Items.Add("Domestico");
            CMBE_TIPOS.Items.Add("Industrial");
            CMBE_GENERO.Items.Add("Masculino");
            CMBE_GENERO.Items.Add("Femenino");
            CMBE_TCSERVICIO.Items.Add("Domestico");
            CMBE_TCSERVICIO.Items.Add("Industrial");
            CMBE_RGTIPOS.Items.Add("Domestico");
            CMBE_RGTIPOS.Items.Add("Industrial");
            CMBE_RGTIPOS.Items.Add("Ambos");

            for (int i = 1; i < 13; i++)
            {
                CMBE_RGMES.Items.Add(i.ToString());
            }
            CMBE_RGMES.Items.Add("Todos los meses");
            CMBE_REPORTECHOPC.Items.Add("Numero de Servicio");
            CMBE_REPORTECHOPC.Items.Add("Numero de Medidor");
            CMBE_RCROPC.Items.Add("Numero de Servicio");
            CMBE_RCROPC.Items.Add("Numero de Medidor");
            CMBE_RCROPC.SelectedIndex = 0;
            CMBE_RTIPOS.Items.Add("Domestico");
            CMBE_RTIPOS.Items.Add("Industrial");
            CMBE_RTIPOS.SelectedIndex = 0;
            CMBE_RGMES.SelectedIndex = 0;
            CMBE_TCSERVICIO.SelectedIndex = 0;
            CMBE_RGTIPOS.SelectedIndex = 0;
            LoadCombo();
            loaded = true;
        }


        private void LoadCombo()
        {

            EnlaceDB con = EnlaceDB.getInstance();

            clientes = con.sp_GetDataTable("SelectClientes");
            CMBE_CLIENTES.DataSource = clientes;
            CMBE_CLIENTES.DisplayMember = "Nombre_Completo";
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

        private void BTNE_CTARIFA_Click(object sender, EventArgs e)
        {
           bool addTarifa = true;

            EnlaceDB con = EnlaceDB.getInstance();

           

           DataTable tarifas = con.sp_GetDataTable("SelectTarifas");
            foreach (DataRow row in tarifas.Rows)
            {
                if (row["Anio"].ToString() == NUDE_TCANIO.Value.ToString() && row["Mes"].ToString() == NUDE_TCMES.Value.ToString()
                    && row["Tipo_Servicio"].ToString() == CMBE_TCSERVICIO.Text)
                {
                    MessageBox.Show("Ya existe una tarifa para esa fecha y tipo de servicio", "Tarifas y Consumos", MessageBoxButtons.OK);
                     addTarifa = false;
                }
            }

            if(addTarifa == true)
            {
                con.sp_Tarifas("Insert", 0, (int)NUDE_TCANIO.Value, (int)NUDE_TCMES.Value, CMBE_TCSERVICIO.Text, (float)NUDE_TBASICA.Value,
              (float)NUDE_TINT.Value, (float)NUDE_TEXC.Value, idEmpleadoActual);
            }

        }

        private void BTNE_CCONSUMO_Click(object sender, EventArgs e)
        {
            int idClienteContrato=0;
            int idTarifa=0;
            int numServicio=0;
            bool medidorExist = false;
            bool tarifaExist = false;
            bool consumoExist = false;
            string tipoServicioContrato = "";
            EnlaceDB con = EnlaceDB.getInstance();

            DataTable contratos = con.sp_GetDataTable("SelectContrato");

            foreach (DataRow row in contratos.Rows)
            {
                int medidor = Int32.Parse(row["Numero_Medidor"].ToString());
               
                if (medidor==(int)NUDE_CMEDIDOR.Value)
                {
                    medidorExist = true;
                    idClienteContrato = Int32.Parse(row["id_Cliente"].ToString());
                    tipoServicioContrato = row["Tipo_Servicio"].ToString();
                    numServicio = Int32.Parse(row["Numero_Servicio"].ToString());
                }
            }

            if (medidorExist == false)
            {
                MessageBox.Show("El numero de medidor no existe", "Tarifas y Consumos", MessageBoxButtons.OK);
            }

            int anio = Int32.Parse(DTPE_FECHACONSUMO.Value.ToString("yyyy"));
            int mes = Int32.Parse(DTPE_FECHACONSUMO.Value.ToString("MM"));
            DataTable tarifas = con.sp_GetDataTable("SelectTarifas");
            foreach (DataRow row in tarifas.Rows)
            {
                if(row["Anio"].ToString() == anio.ToString() && row["Mes"].ToString()==mes.ToString()
                    && row["Tipo_Servicio"].ToString()==tipoServicioContrato)
                {
                    
                    tarifaExist = true;
                    idTarifa = Int32.Parse(row["id_Tarifa"].ToString());
                }

            }

            if(tarifaExist == false)
            {
                MessageBox.Show("No existe tarifa para esta fecha y tipo de servicio", "Tarifas y Consumos", MessageBoxButtons.OK);
            }

            
            DataTable consumos = con.sp_GetDataTable("SelectConsumos");
            foreach (DataRow row in consumos.Rows)
            {
                if(row["Anio"].ToString()==anio.ToString() && row["Mes"].ToString() == mes.ToString() 
                    && row["Numero_Medidor"].ToString() == NUDE_CMEDIDOR.Value.ToString())
                {
                    consumoExist = true;
                }

            }

            if (consumoExist == true)
            {
                MessageBox.Show("Ya existe un consumo para este numero de medidor y periodo", "Tarifas y Consumos", MessageBoxButtons.OK);
            }

                if (tarifaExist == true && medidorExist == true && consumoExist == false)
            {
                int consumoTotal = (int)NUDE_CONSUMOKWH.Value;
                int consumoBasico = 0;
                int consumoIntermedio = 0;
                int consumoExcedente = 0;

                if (consumoTotal >= (pBasico+pIntermedio))
                {
                    consumoBasico = pBasico;
                    consumoIntermedio = pIntermedio;
                    consumoExcedente = consumoTotal - (pBasico+pIntermedio);
                }
                else if (consumoTotal < (pBasico+pIntermedio) && consumoTotal >=pBasico)
                {
                    consumoBasico = pBasico;
                    consumoIntermedio = consumoTotal - pBasico;
                    consumoExcedente = 0;
                }
                else if (consumoTotal < pBasico)
                {
                    consumoBasico = consumoTotal;
                    consumoIntermedio = 0;
                    consumoExcedente = 0;
                }

                con.sp_Consumos("Insert",0,(int)NUDE_CMEDIDOR.Value,DTPE_FECHACONSUMO.Value.ToString("yyyyMMdd"),(int)NUDE_CONSUMOKWH.Value,
                    consumoBasico, consumoIntermedio, consumoExcedente, idEmpleadoActual);

                    if (tipoServicioContrato == "Domestico") {
                    con.sp_Recibos("Insert", 0, numServicio, (int)NUDE_CMEDIDOR.Value, DTPE_FECHACONSUMO.Value.ToString("yyyyMMdd"),
                        DTPE_FECHACONSUMO.Value.AddMonths(-2).ToString("yyyyMMdd"), "No Pagado", 0, idTarifa, 0, 0,0 , 0, 0, 0, 0, 0,0, idClienteContrato, 0);
                    con.sp_Recibos("CompletarRecibo", 0, numServicio, (int)NUDE_CMEDIDOR.Value, DTPE_FECHACONSUMO.Value.ToString("yyyyMMdd"),
                        DTPE_FECHACONSUMO.Value.AddMonths(-2).ToString("yyyyMMdd"), "No Pagado", 0, idTarifa,0, 0, 0, 0, 0, 0, 0, 0, 0, idClienteContrato, 0);

                }
                    else if (tipoServicioContrato == "Industrial")
                    {
                    con.sp_Recibos("Insert", 0, numServicio, (int)NUDE_CMEDIDOR.Value, DTPE_FECHACONSUMO.Value.ToString("yyyyMMdd"),
                       DTPE_FECHACONSUMO.Value.AddMonths(-1).ToString("yyyyMMdd"), "No Pagado", 0, idTarifa, 0, 0, 0, 0, 0, 0, 0, 0, 0, idClienteContrato, 0);
                    con.sp_Recibos("CompletarRecibo", 0, numServicio, (int)NUDE_CMEDIDOR.Value, DTPE_FECHACONSUMO.Value.ToString("yyyyMMdd"),
                       DTPE_FECHACONSUMO.Value.AddMonths(-1).ToString("yyyyMMdd"), "No Pagado", 0, idTarifa, 0, 0, 0, 0, 0, 0, 0, 0, 0, idClienteContrato, 0);
                }
            
            }


        }

        private void BTNE_RTCTVISUALIZAR_Click(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();
             reporteT = con.sp_ReportesTC("ReporteTarifas",(int)NUDE_RTCTANIO.Value);
            DGVE_REPORTET.DataSource = reporteT;
            DGVE_REPORTET.Columns["Basico"].DefaultCellStyle.Format = "N2";
            DGVE_REPORTET.Columns["Intermedio"].DefaultCellStyle.Format = "N2";
            DGVE_REPORTET.Columns["Excedente"].DefaultCellStyle.Format = "N2";

        }

        private void BTNE_RTCCVISUALIZAR_Click(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();
            reporteC = con.sp_ReportesTC("ReporteConsumos", (int)NUDE_RTCCANIO.Value);
            DGVE_REPORTEC.DataSource = reporteC;


        }

        private void BTNE_VISUALIZAR_Click(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();
            

            if (CMBE_RGMES.Text=="Todos los meses" && CMBE_RGTIPOS.Text == "Ambos")
            {
                 reporteG = con.sp_ReporteGeneral("AmbosTodos", (int)NUDE_RGANIO.Value, 0);
                DGVE_REPORTEG.DataSource = reporteG;
                DGVE_REPORTEG.Columns["Total Pendiente de Pago"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTEG.Columns["Total Pagado"].DefaultCellStyle.Format = "N2";

            }
            else if(CMBE_RGMES.Text != "Todos los meses" && CMBE_RGTIPOS.Text == "Ambos")
            {
                 reporteG = con.sp_ReporteGeneral("Ambos", (int)NUDE_RGANIO.Value, Int32.Parse(CMBE_RGMES.Text));
                DGVE_REPORTEG.DataSource = reporteG;
                DGVE_REPORTEG.Columns["Total Pendiente de Pago"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTEG.Columns["Total Pagado"].DefaultCellStyle.Format = "N2";
            }
            else if (CMBE_RGMES.Text == "Todos los meses" && CMBE_RGTIPOS.Text == "Industrial")
            {
                 reporteG = con.sp_ReporteGeneral("IndustrialTodos", (int)NUDE_RGANIO.Value, 0);
                DGVE_REPORTEG.DataSource = reporteG;
                DGVE_REPORTEG.Columns["Total Pendiente de Pago"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTEG.Columns["Total Pagado"].DefaultCellStyle.Format = "N2";

            }
            else if (CMBE_RGMES.Text != "Todos los meses" && CMBE_RGTIPOS.Text == "Industrial")
            {
                 reporteG = con.sp_ReporteGeneral("Industrial", (int)NUDE_RGANIO.Value, Int32.Parse(CMBE_RGMES.Text));
                DGVE_REPORTEG.DataSource = reporteG;
                DGVE_REPORTEG.Columns["Total Pendiente de Pago"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTEG.Columns["Total Pagado"].DefaultCellStyle.Format = "N2";
            }
            else if (CMBE_RGMES.Text == "Todos los meses" && CMBE_RGTIPOS.Text == "Domestico")
            {
                 reporteG = con.sp_ReporteGeneral("DomesticoTodos", (int)NUDE_RGANIO.Value, 0);
                DGVE_REPORTEG.DataSource = reporteG;
                DGVE_REPORTEG.Columns["Total Pendiente de Pago"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTEG.Columns["Total Pagado"].DefaultCellStyle.Format = "N2";

            }
            else if (CMBE_RGMES.Text != "Todos los meses" && CMBE_RGTIPOS.Text == "Domestico")
            {
                 reporteG = con.sp_ReporteGeneral("Domestico", (int)NUDE_RGANIO.Value, Int32.Parse(CMBE_RGMES.Text));
                DGVE_REPORTEG.DataSource = reporteG;
                DGVE_REPORTEG.Columns["Total Pendiente de Pago"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTEG.Columns["Total Pagado"].DefaultCellStyle.Format = "N2";
            }



        }

        private void CMBE_REPORTECHOPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();

            if (CMBE_REPORTECHOPC.Text == "Numero de Servicio")
            {
                DataTable numServ = con.sp_GetNumeros("NumeroServicio", 0);
                CMBE_REPORTECHNUM.DataSource = numServ;
                CMBE_REPORTECHNUM.DisplayMember = "Numero_Servicio";
                CMBE_REPORTECHNUM.SelectedIndex = 0;
            }
            else if (CMBE_REPORTECHOPC.Text == "Numero de Medidor")
            {
                DataTable numMed = con.sp_GetNumeros("NumeroMedidor", 0);
                CMBE_REPORTECHNUM.DataSource = numMed;
                CMBE_REPORTECHNUM.DisplayMember = "Numero_Medidor";
                CMBE_REPORTECHNUM.SelectedIndex = 0;
            }
        }

        private void BTNE_CHVISUALIZAR_Click(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();

            if (CMBE_REPORTECHOPC.Text == "Numero de Servicio")
            {
                 reporteCH = con.sp_ReporteConsumoHistorico("NumeroServicio", (int)NUDE_REPORTECHANIO.Value, 0,
                    Int32.Parse(CMBE_REPORTECHNUM.Text));
                DGVE_REPORTECH.DataSource = reporteCH;
               
                DGVE_REPORTECH.Columns["Importe"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTECH.Columns["Pagado"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTECH.Columns["Pendiente de Pago"].DefaultCellStyle.Format = "N2";


            }
            else if (CMBE_REPORTECHOPC.Text == "Numero de Medidor")
            {
                 reporteCH = con.sp_ReporteConsumoHistorico("NumeroMedidor", (int)NUDE_REPORTECHANIO.Value, 
                    Int32.Parse(CMBE_REPORTECHNUM.Text), 0);
                DGVE_REPORTECH.DataSource = reporteCH;
               
                DGVE_REPORTECH.Columns["Importe"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTECH.Columns["Pagado"].DefaultCellStyle.Format = "N2";
                DGVE_REPORTECH.Columns["Pendiente de Pago"].DefaultCellStyle.Format = "N2";


            }

        }

        private void CMBE_RCROPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();

            if (CMBE_RCROPC.Text == "Numero de Servicio")
            {
                DataTable numServ = con.sp_GetNumeros("NumeroServicio", 0);
                CMBE_RCRNUM.DataSource = numServ;
                CMBE_RCRNUM.DisplayMember = "Numero_Servicio";
                CMBE_RCRNUM.SelectedIndex = 0;
            }
            else if (CMBE_RCROPC.Text == "Numero de Medidor")
            {
                DataTable numMed = con.sp_GetNumeros("NumeroMedidor", 0);
                CMBE_RCRNUM.DataSource = numMed;
                CMBE_RCRNUM.DisplayMember = "Numero_Medidor";
                CMBE_RCRNUM.SelectedIndex = 0;
            }
        
        }

        private void BTNE_RCARGA_Click(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();

            con.sp_GenerarRecibos("Generar", (int)NUDE_RANIO.Value, (int)NUDE_RMES.Value, CMBE_RTIPOS.Text, idEmpleadoActual);

        }

        private void BTNE_GENERARPDF_Click(object sender, EventArgs e)
        {

            EnlaceDB con = EnlaceDB.getInstance();

            if (CMBE_RCROPC.Text == "Numero de Servicio")
            {
                 recibo = con.sp_SeleccionarRecibo("NumeroServicio", 0, Int32.Parse(CMBE_RCRNUM.Text), (int)NUDE_RCRANIO.Value,
                    (int)NUDE_RCRMES.Value);
                if (recibo.Rows.Count == 0)
                {
                    MessageBox.Show("No hay recibos para este periodo y numero de servicio", "Recibos", MessageBoxButtons.OK);

                }
                else
                {
                    generarPDF();
                }
                
            }
            else if (CMBE_RCROPC.Text == "Numero de Medidor")
            {
                 recibo = con.sp_SeleccionarRecibo("NumeroMedidor", Int32.Parse(CMBE_RCRNUM.Text), 0, (int)NUDE_RCRANIO.Value,
                     (int)NUDE_RCRMES.Value);
                if (recibo.Rows.Count == 0)
                {
                    MessageBox.Show("No hay recibos para este periodo y numero de medidor", "Recibos", MessageBoxButtons.OK);
                }
                else
                {
                    generarPDF();
                    
                }
            }

        }

        private void generarPDF()
        {
            DateTime fecha = Convert.ToDateTime(recibo.Rows[0]["Fecha"].ToString());
            DateTime fechaInicio = Convert.ToDateTime(recibo.Rows[0]["Fecha_Inicio"].ToString());
            string tituloArchivo = "Recibo del Numero de Servicio " + recibo.Rows[0]["Numero_Servicio"].ToString() + " En la fecha " + fecha.ToString("yyyy-MM-dd");
            string ruta = "Archivos//" + tituloArchivo + ".pdf";

            try
            {
                string sFechaLimite = fecha.AddDays(17).ToString("dd/MM/yy");
                string sFechaCorte = fecha.AddDays(18).ToString("dd/MM/yy");
                string sFecha = fecha.ToString("dd/MM/yy");
                string sFechaInicio = fechaInicio.ToString("dd/MM/yy");

                Document doc = new Document(PageSize.LETTER);
                PdfWriter.GetInstance(doc, new FileStream(ruta,FileMode.Create));
                moneda oMoneda = new moneda();

                string numLetra = oMoneda.Convertir(recibo.Rows[0]["Importe"].ToString().Substring(0, recibo.Rows[0]["Importe"].ToString().Length -5),true,"PESOS");


                doc.Open();

                iTextSharp.text.Font standard = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font boldStandard = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                iTextSharp.text.Font bigBold = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 15, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                doc.Add(new Paragraph("Recibo de consumo de energía eléctrica"));
                doc.Add(Chunk.NEWLINE);

                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;

                PdfPCell cl1t1 = new PdfPCell(new Phrase(recibo.Rows[0]["Nombre_Cliente"].ToString(), standard));
                cl1t1.BorderWidth = 0;
                cl1t1.BorderWidthBottom = 0;

                PdfPCell cl2t1 = new PdfPCell(new Phrase("TOTAL A PAGAR:", boldStandard));
                cl2t1.BorderWidth = 0;
                cl2t1.BorderWidthBottom = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);

                cl1t1 = new PdfPCell(new Phrase(recibo.Rows[0]["Calle"].ToString() + " " + recibo.Rows[0]["Numero_Exterior"].ToString(), standard));
                cl1t1.BorderWidth = 0;

                cl2t1 = new PdfPCell(new Phrase("$" + recibo.Rows[0]["Importe"].ToString().Substring(0, recibo.Rows[0]["Importe"].ToString().Length - 5), bigBold));
                cl2t1.BorderWidth = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);

                cl1t1 = new PdfPCell(new Phrase(recibo.Rows[0]["Colonia"].ToString() + " CP " + recibo.Rows[0]["CP"].ToString(), standard));
                cl1t1.BorderWidth = 0;

                cl2t1 = new PdfPCell(new Phrase("(" + numLetra + ")", standard));
                cl2t1.BorderWidth = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);

                cl1t1 = new PdfPCell(new Phrase(recibo.Rows[0]["Ciudad"].ToString() + ", " + recibo.Rows[0]["Estado"].ToString(), standard));
                cl1t1.BorderWidth = 0;

                cl2t1 = new PdfPCell(new Phrase("", standard));
                cl2t1.BorderWidth = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);

                cl1t1 = new PdfPCell(new Phrase("NO. DE SERVICIO: "+ recibo.Rows[0]["Numero_Servicio"].ToString(), standard));
                cl1t1.BorderWidth = 0;

                cl2t1 = new PdfPCell(new Phrase("", standard));
                cl2t1.BorderWidth = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);

                cl1t1 = new PdfPCell(new Phrase("LIMITE DE PAGO: " + sFechaLimite, standard));
                cl1t1.BorderWidth = 0;

                cl2t1 = new PdfPCell(new Phrase("", standard));
                cl2t1.BorderWidth = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);


                cl1t1 = new PdfPCell(new Phrase("CORTE A PARTIR: " + sFechaCorte, standard));
                cl1t1.BorderWidth = 0;

                cl2t1 = new PdfPCell(new Phrase("", standard));
                cl2t1.BorderWidth = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);


                cl1t1 = new PdfPCell(new Phrase("NO. MEDIDOR: " + recibo.Rows[0]["Numero_Medidor"].ToString(), standard));
                cl1t1.BorderWidth = 0;

                cl2t1 = new PdfPCell(new Phrase("", standard));
                cl2t1.BorderWidth = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);


                cl1t1 = new PdfPCell(new Phrase("PERIODO FACTURADO: " + sFechaInicio + " - " + sFecha, standard));
                cl1t1.BorderWidth = 0;

                cl2t1 = new PdfPCell(new Phrase("", standard));
                cl2t1.BorderWidth = 0;

                table.AddCell(cl1t1);
                table.AddCell(cl2t1);


                doc.Add(table);
                doc.Add(Chunk.NEWLINE);

                PdfPTable table2 = new PdfPTable(4);
                table2.WidthPercentage = 100;

                PdfPCell cl1t2 = new PdfPCell(new Phrase("Concepto", boldStandard));
                cl1t2.BorderWidth = 0;
                cl1t2.BorderWidthBottom = 0.75f;

                PdfPCell cl2t2 = new PdfPCell(new Phrase("Total Periodo", boldStandard));
                cl2t2.BorderWidth = 0;
                cl2t2.BorderWidthBottom = 0.75f;
                
                PdfPCell cl3t2 = new PdfPCell(new Phrase("Precio (MXN)", boldStandard));
                cl3t2.BorderWidth = 0;
                cl3t2.BorderWidthBottom = 0.75f;

                PdfPCell cl4t2 = new PdfPCell(new Phrase("Subtotal (MXN)", boldStandard));
                cl4t2.BorderWidth = 0;
                cl4t2.BorderWidthBottom = 0.75f;


                table2.AddCell(cl1t2);
                table2.AddCell(cl2t2);
                table2.AddCell(cl3t2);
                table2.AddCell(cl4t2);

                cl1t2 = new PdfPCell(new Phrase("Energia (kWh)", boldStandard));
                cl1t2.BorderWidth = 0;

                cl2t2 = new PdfPCell(new Phrase(recibo.Rows[0]["Consumo"].ToString(), standard));
                cl2t2.BorderWidth = 0;

                cl3t2 = new PdfPCell(new Phrase("", standard));
                cl3t2.BorderWidth = 0;

                cl4t2 = new PdfPCell(new Phrase("", standard));
                cl4t2.BorderWidth = 0;

                table2.AddCell(cl1t2);
                table2.AddCell(cl2t2);
                table2.AddCell(cl3t2);
                table2.AddCell(cl4t2);

                cl1t2 = new PdfPCell(new Phrase("Basico", standard));
                cl1t2.BorderWidth = 0;

                cl2t2 = new PdfPCell(new Phrase(recibo.Rows[0]["Consumo_Basico"].ToString(), standard));
                cl2t2.BorderWidth = 0;

                cl3t2 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Tarifa_Basico"].ToString()).ToString("n2"), standard));
                cl3t2.BorderWidth = 0;

                cl4t2 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Subtotal_Basico"].ToString()).ToString("n2"), standard));
                cl4t2.BorderWidth = 0;

                table2.AddCell(cl1t2);
                table2.AddCell(cl2t2);
                table2.AddCell(cl3t2);
                table2.AddCell(cl4t2);

                cl1t2 = new PdfPCell(new Phrase("Intermedio", standard));
                cl1t2.BorderWidth = 0;

                cl2t2 = new PdfPCell(new Phrase(recibo.Rows[0]["Consumo_Intermedio"].ToString(), standard));
                cl2t2.BorderWidth = 0;

                cl3t2 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Tarifa_Intermedio"].ToString()).ToString("n2"), standard));
                cl3t2.BorderWidth = 0;

                cl4t2 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Subtotal_Intermedio"].ToString()).ToString("n2"), standard));
                cl4t2.BorderWidth = 0;

                table2.AddCell(cl1t2);
                table2.AddCell(cl2t2);
                table2.AddCell(cl3t2);
                table2.AddCell(cl4t2);

                cl1t2 = new PdfPCell(new Phrase("Excedente", standard));
                cl1t2.BorderWidth = 0;

                cl2t2 = new PdfPCell(new Phrase(recibo.Rows[0]["Consumo_Excedente"].ToString(), standard));
                cl2t2.BorderWidth = 0;

                cl3t2 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Tarifa_Excedente"].ToString()).ToString("n2"), standard));
                cl3t2.BorderWidth = 0;

                cl4t2 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Subtotal_Excedente"].ToString()).ToString("n2"), standard));
                cl4t2.BorderWidth = 0;

                table2.AddCell(cl1t2);
                table2.AddCell(cl2t2);
                table2.AddCell(cl3t2);
                table2.AddCell(cl4t2);


                cl1t2 = new PdfPCell(new Phrase("Suma", standard));
                cl1t2.BorderWidth = 0;

                cl2t2 = new PdfPCell(new Phrase(recibo.Rows[0]["Consumo"].ToString(), standard));
                cl2t2.BorderWidth = 0;

                cl3t2 = new PdfPCell(new Phrase("", standard));
                cl3t2.BorderWidth = 0;

                cl4t2 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Total"].ToString()).ToString("n2"), standard));
                cl4t2.BorderWidth = 0;

                table2.AddCell(cl1t2);
                table2.AddCell(cl2t2);
                table2.AddCell(cl3t2);
                table2.AddCell(cl4t2);


                doc.Add(table2);

                doc.Add(Chunk.NEWLINE);

                PdfPTable table3 = new PdfPTable(2);
                table3.WidthPercentage = 50;
                table3.HorizontalAlignment = 2;

                PdfPCell cl1t3 = new PdfPCell(new Phrase("Concepto", boldStandard));
                cl1t3.BorderWidth = 0;
                cl1t3.BorderWidthBottom = 0.75f;

                PdfPCell cl2t3 = new PdfPCell(new Phrase("Importe (MXN)", boldStandard));
                cl2t3.BorderWidth = 0;
                cl2t3.BorderWidthBottom = 0.75f;

                table3.AddCell(cl1t3);
                table3.AddCell(cl2t3);

                cl1t3 = new PdfPCell(new Phrase("Energía", standard));
                cl1t3.BorderWidth = 0;

                cl2t3 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Total"].ToString()).ToString("n2"), standard));
                cl2t3.BorderWidth = 0;

                table3.AddCell(cl1t3);
                table3.AddCell(cl2t3);

                cl1t3 = new PdfPCell(new Phrase("IVA 16%", standard));
                cl1t3.BorderWidth = 0;

                cl2t3 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["IVA"].ToString()).ToString("n2"), standard));
                cl2t3.BorderWidth = 0;

                table3.AddCell(cl1t3);
                table3.AddCell(cl2t3);

                cl1t3 = new PdfPCell(new Phrase("Total", boldStandard));
                cl1t3.BorderWidth = 0;

                cl2t3 = new PdfPCell(new Phrase(float.Parse(recibo.Rows[0]["Importe"].ToString()).ToString("n2"), boldStandard));
                cl2t3.BorderWidth = 0;

                table3.AddCell(cl1t3);
                table3.AddCell(cl2t3);



                doc.Add(table3);


                doc.Close();
                MessageBox.Show("PDF creado con exito en la direccion: " +ruta, "Recibos", MessageBoxButtons.OK);

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al crear el archivo", "Recibos", MessageBoxButtons.OK);
            }
        }

        private void BTNE_ARCHIVOT_Click(object sender, EventArgs e)
        {
            bool addTarifa = true;
            int count = 0;
            EnlaceDB con = EnlaceDB.getInstance();
            var reader = File.OpenText("TarifasCM.csv");
            var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
            var tarifasCM = csvReader.GetRecords<TarifasCM>();

            DataTable tarifas = con.sp_GetDataTable("SelectTarifas");

           
            foreach (var tarifa in tarifasCM)
            {
                addTarifa = true;
                foreach (DataRow row in tarifas.Rows)
                {
                    if (row["Anio"].ToString() == tarifa.Anio.ToString() && row["Mes"].ToString() == tarifa.Mes.ToString()
                        && row["Tipo_Servicio"].ToString() == tarifa.Tipo_Servicio)
                    {
                        MessageBox.Show("La tarifa del año " + tarifa.Anio.ToString() + ", mes " + tarifa.Mes.ToString() 
                           + " y tipo de servicio "+ tarifa.Tipo_Servicio+ " ya estaba registrada" , "Tarifas y Consumos", MessageBoxButtons.OK);
                        addTarifa = false;
                        break;
                    }
                }

                if (addTarifa == true)
                {
                    con.sp_Tarifas("Insert", 0, tarifa.Anio, tarifa.Mes, tarifa.Tipo_Servicio, tarifa.Basico,
                  tarifa.Intermedio, tarifa.Excedente, idEmpleadoActual);
                    count++;
                }
            }


            MessageBox.Show("Se han agregado "+count.ToString() +" tarifas nuevas", "Tarifas y Consumos", MessageBoxButtons.OK);

        }

        private void BTNE_ARCHIVOC_Click(object sender, EventArgs e)
        {
            int count = 0;
            int idClienteContrato = 0;
            int idTarifa = 0;
            int numServicio = 0;
            bool medidorExist = false;
            bool tarifaExist = false;
            bool consumoExist = false;
            string tipoServicioContrato = "";

            EnlaceDB con = EnlaceDB.getInstance();
            var reader = File.OpenText("ConsumosCM.csv");
            var csvReader = new CsvReader(reader, CultureInfo.CurrentCulture);
            var consumosCM = csvReader.GetRecords<ConsumosCM>();

            foreach(var consumo in consumosCM)
            {
                DataTable contratos = con.sp_GetDataTable("SelectContrato");

                foreach (DataRow row in contratos.Rows)
                {
                    int medidor = Int32.Parse(row["Numero_Medidor"].ToString());

                    if (medidor == consumo.Numero_Medidor)
                    {
                        medidorExist = true;
                        idClienteContrato = Int32.Parse(row["id_Cliente"].ToString());
                        tipoServicioContrato = row["Tipo_Servicio"].ToString();
                        numServicio = Int32.Parse(row["Numero_Servicio"].ToString());
                    }
                }

                if (medidorExist == false)
                {
                    MessageBox.Show("El numero de medidor no existe", "Tarifas y Consumos", MessageBoxButtons.OK);
                }

                int anio = Int32.Parse(consumo.Fecha.Substring(6,4));
                int mes = Int32.Parse(consumo.Fecha.Substring(3,2));
                DataTable tarifas = con.sp_GetDataTable("SelectTarifas");
                foreach (DataRow row in tarifas.Rows)
                {
                    if (row["Anio"].ToString() == anio.ToString() && row["Mes"].ToString() == mes.ToString()
                        && row["Tipo_Servicio"].ToString() == tipoServicioContrato)
                    {

                        tarifaExist = true;
                        idTarifa = Int32.Parse(row["id_Tarifa"].ToString());
                    }

                }

                if (tarifaExist == false)
                {
                    MessageBox.Show("No existe tarifa para esta fecha y tipo de servicio", "Tarifas y Consumos", MessageBoxButtons.OK);
                }

                DataTable consumos = con.sp_GetDataTable("SelectConsumos");
                foreach (DataRow row in consumos.Rows)
                {
                    if (row["Anio"].ToString() == anio.ToString() && row["Mes"].ToString() == mes.ToString()
                        && row["Numero_Medidor"].ToString() == consumo.Numero_Medidor.ToString())
                    {
                        consumoExist = true;
                    }

                }

                if (consumoExist == true)
                {
                    MessageBox.Show("Ya existe un consumo para este numero de medidor y periodo", "Tarifas y Consumos", MessageBoxButtons.OK);
                }

                if (tarifaExist == true && medidorExist == true && consumoExist == false)
                {
                    count++;
                    int consumoTotal = consumo.Consumo;
                    int consumoBasico = 0;
                    int consumoIntermedio = 0;
                    int consumoExcedente = 0;

                    if (consumoTotal >= (pBasico + pIntermedio))
                    {
                        consumoBasico = pBasico;
                        consumoIntermedio = pIntermedio;
                        consumoExcedente = consumoTotal - (pBasico + pIntermedio);
                    }
                    else if (consumoTotal < (pBasico + pIntermedio) && consumoTotal >= pBasico)
                    {
                        consumoBasico = pBasico;
                        consumoIntermedio = consumoTotal - pBasico;
                        consumoExcedente = 0;
                    }
                    else if (consumoTotal < pBasico)
                    {
                        consumoBasico = consumoTotal;
                        consumoIntermedio = 0;
                        consumoExcedente = 0;
                    }

                    con.sp_Consumos("Insert", 0, consumo.Numero_Medidor, Convert.ToDateTime(consumo.Fecha).ToString("yyyyMMdd"), consumo.Consumo,
                        consumoBasico, consumoIntermedio, consumoExcedente, idEmpleadoActual);

                    if (tipoServicioContrato == "Domestico")
                    {
                        con.sp_Recibos("Insert", 0, numServicio, consumo.Numero_Medidor, Convert.ToDateTime(consumo.Fecha).ToString("yyyyMMdd"),
                            Convert.ToDateTime(consumo.Fecha).AddMonths(-2).ToString("yyyyMMdd"), "No Pagado", 0, idTarifa, 0, 0, 0, 0, 0, 0, 0, 0, 0, idClienteContrato, 0);
                        con.sp_Recibos("CompletarRecibo", 0, numServicio, (int)NUDE_CMEDIDOR.Value, DTPE_FECHACONSUMO.Value.ToString("yyyyMMdd"),
                            DTPE_FECHACONSUMO.Value.AddMonths(-2).ToString("yyyyMMdd"), "No Pagado", 0, idTarifa, 0, 0, 0, 0, 0, 0, 0, 0, 0, idClienteContrato, 0);

                    }
                    else if (tipoServicioContrato == "Industrial")
                    {
                        con.sp_Recibos("Insert", 0, numServicio, consumo.Numero_Medidor, Convert.ToDateTime(consumo.Fecha).ToString("yyyyMMdd"),
                           Convert.ToDateTime(consumo.Fecha).AddMonths(-1).ToString("yyyyMMdd"), "No Pagado", 0, idTarifa, 0, 0, 0, 0, 0, 0, 0, 0, 0, idClienteContrato, 0);
                        con.sp_Recibos("CompletarRecibo", 0, numServicio, (int)NUDE_CMEDIDOR.Value, DTPE_FECHACONSUMO.Value.ToString("yyyyMMdd"),
                           DTPE_FECHACONSUMO.Value.AddMonths(-1).ToString("yyyyMMdd"), "No Pagado", 0, idTarifa, 0, 0, 0, 0, 0, 0, 0, 0, 0, idClienteContrato, 0);
                    }

                }

            }

            MessageBox.Show("Se agregaron "+count.ToString() + " consumos nuevos", "Tarifas y Consumos", MessageBoxButtons.OK);


        }

        private void BTNE_RGPDF_Click(object sender, EventArgs e)
        {
            string tituloArchivo = "Reporte General " + NUDE_RGANIO.Value.ToString() + "-" + CMBE_RGMES.Text + "-" + CMBE_RGTIPOS.Text;
            string ruta = "Archivos//" + tituloArchivo + ".pdf";
            if (DGVE_REPORTEG.Rows.Count != 0)
            {
                try
                {

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                    iTextSharp.text.Font standard = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                    doc.Open();
                    doc.Add(new Paragraph(tituloArchivo));
                    doc.Add(Chunk.NEWLINE);

                    PdfPTable table = new PdfPTable(5);

                    table.AddCell(new Paragraph("Año", standard));
                    table.AddCell(new Paragraph("Mes", standard));
                    table.AddCell(new Paragraph("Tipo de Servicio", standard));
                    table.AddCell(new Paragraph("Total Pagado", standard));
                    table.AddCell(new Paragraph("Total Pendiente de Pago", standard));

                    foreach (DataRow reporte in reporteG.Rows)
                    {
                        table.AddCell(new Paragraph(reporte["Año"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Mes"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Tipo de Servicio"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Total Pagado"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Total Pendiente de Pago"].ToString(), standard));

                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF creado con exito en la direccion: " + ruta, "Reporte", MessageBoxButtons.OK);

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al crear el archivo", "Reporte", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No hay datos", "Reporte", MessageBoxButtons.OK);
            }
        }

        private void BTNE_CHPDF_Click(object sender, EventArgs e)
        {

            string tituloArchivo = "Reporte Consumo Historico " + NUDE_REPORTECHANIO.Value.ToString() + "-" + CMBE_REPORTECHOPC.Text + "-" + CMBE_REPORTECHNUM.Text;
            string ruta = "Archivos//" + tituloArchivo + ".pdf";
            if (DGVE_REPORTECH.Rows.Count != 0)
            {
                try
                {

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                    iTextSharp.text.Font standard = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                    doc.Open();
                    doc.Add(new Paragraph(tituloArchivo));
                    doc.Add(Chunk.NEWLINE);

                    PdfPTable table = new PdfPTable(5);

                    table.AddCell(new Paragraph("Mes", standard));
                    table.AddCell(new Paragraph("Consumo kWh", standard));
                    table.AddCell(new Paragraph("Importe", standard));
                    table.AddCell(new Paragraph("Pagado", standard));
                    table.AddCell(new Paragraph("Pendiente de Pago", standard));

                    foreach (DataRow reporte in reporteCH.Rows)
                    {
                        table.AddCell(new Paragraph(reporte["Mes"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Consumo kWh"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Importe"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Pagado"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Pendiente de Pago"].ToString(), standard));

                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF creado con exito en la direccion: " + ruta, "Reporte", MessageBoxButtons.OK);

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al crear el archivo", "Reporte", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No hay datos", "Reporte", MessageBoxButtons.OK);
            }

        }

        private void BTNE_TCPDFT_Click(object sender, EventArgs e)
        {

            string tituloArchivo = "Reporte Tarifas " + NUDE_RTCTANIO.Value.ToString();
            string ruta = "Archivos//" + tituloArchivo + ".pdf";
            if (DGVE_REPORTET.Rows.Count != 0)
            {
                try
                {

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                    iTextSharp.text.Font standard = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                    doc.Open();
                    doc.Add(new Paragraph(tituloArchivo));
                    doc.Add(Chunk.NEWLINE);

                    PdfPTable table = new PdfPTable(6);

                    table.AddCell(new Paragraph("Año", standard));
                    table.AddCell(new Paragraph("Mes", standard));
                    table.AddCell(new Paragraph("Tipo", standard));
                    table.AddCell(new Paragraph("Basico", standard));
                    table.AddCell(new Paragraph("Intermedio", standard));
                    table.AddCell(new Paragraph("Excedente", standard));

                    foreach (DataRow reporte in reporteT.Rows)
                    {
                        table.AddCell(new Paragraph(reporte["Año"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Mes"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Tipo"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Basico"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Intermedio"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Excedente"].ToString(), standard));

                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF creado con exito en la direccion: " + ruta, "Reporte", MessageBoxButtons.OK);

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al crear el archivo", "Reporte", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No hay datos", "Reporte", MessageBoxButtons.OK);
            }

        }

        private void BTNE_TCPDFC_Click(object sender, EventArgs e)
        {
            string tituloArchivo = "Reporte Consumos " + NUDE_RTCCANIO.Value.ToString();
            string ruta = "Archivos//" + tituloArchivo + ".pdf";
            if (DGVE_REPORTEC.Rows.Count != 0)
            {
                try
                {

                    Document doc = new Document();
                    PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                    iTextSharp.text.Font standard = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                    doc.Open();
                    doc.Add(new Paragraph(tituloArchivo));
                    doc.Add(Chunk.NEWLINE);

                    PdfPTable table = new PdfPTable(6);

                    table.AddCell(new Paragraph("Año", standard));
                    table.AddCell(new Paragraph("Mes", standard));
                    table.AddCell(new Paragraph("Numero de medidor", standard));
                    table.AddCell(new Paragraph("Kw Basico", standard));
                    table.AddCell(new Paragraph("Kw Intermedio", standard));
                    table.AddCell(new Paragraph("Kw Excedente", standard));
                   

                    foreach (DataRow reporte in reporteC.Rows)
                    {
                        table.AddCell(new Paragraph(reporte["Año"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Mes"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Numero de medidor"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["Kw Basico"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["kw Intermedio"].ToString(), standard));
                        table.AddCell(new Paragraph(reporte["kw Excedente"].ToString(), standard));
                      

                    }

                    doc.Add(table);
                    doc.Close();

                    MessageBox.Show("PDF creado con exito en la direccion: " + ruta, "Reporte", MessageBoxButtons.OK);

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrio un error al crear el archivo", "Reporte", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("No hay datos", "Reporte", MessageBoxButtons.OK);
            }
        }
    }
}
