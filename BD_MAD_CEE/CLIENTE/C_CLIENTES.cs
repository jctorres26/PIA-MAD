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

namespace BD_MAD_CEE.CLIENTE
{
    public partial class C_CLIENTES : Form
    {
        private int idClienteActual;
        public C_CLIENTES(int id)
        {
            InitializeComponent();
            idClienteActual = id;
        }

        private bool loaded = false;
        private DataTable recibo;
        private DataTable reporteCH;
        private void C_CLIENTES_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void C_CLIENTES_Load(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();

            CMBC_CHOPC.Items.Add("Numero de Servicio");
            CMBC_CHOPC.Items.Add("Numero de Medidor");

            CMBC_FORMA.Items.Add("Efectivo");
            CMBC_FORMA.Items.Add("Tarjeta de Credito");
            CMBC_FORMA.Items.Add("Tarjeta de Debito");
            CMBC_FORMA.Items.Add("Transferencia");
            CMBC_FORMA.SelectedIndex = 0;

            DataTable numeros = con.sp_RecibosClientes("SelectServicio",idClienteActual,0);

            CMBC_PSERVICIOS.DataSource = numeros;
            CMBC_PSERVICIOS.DisplayMember= "Numero_Servicio";
            CMBC_PSERVICIOS.SelectedIndex = -1;

            CMBC_CSERVICIOS.DataSource = numeros;
            CMBC_CSERVICIOS.DisplayMember = "Numero_Servicio";
            CMBC_CSERVICIOS.SelectedIndex = -1;
            loaded = true;

        }

        private void CMBC_CHOPC_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();

            if (CMBC_CHOPC.Text == "Numero de Servicio")
            {
                DataTable numServ = con.sp_GetNumeros("NumeroServicioCliente", idClienteActual);
                CMBC_CHNUM.DataSource = numServ;
                CMBC_CHNUM.DisplayMember = "Numero_Servicio";
                CMBC_CHNUM.SelectedIndex = 0;
            }
            else if (CMBC_CHOPC.Text == "Numero de Medidor")
            {
                DataTable numMed = con.sp_GetNumeros("NumeroMedidorCliente", idClienteActual);
                CMBC_CHNUM.DataSource = numMed;
                CMBC_CHNUM.DisplayMember = "Numero_Medidor";
                CMBC_CHNUM.SelectedIndex = 0;
            }
        }

        private void CMBC_CHVISUAL_Click(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();

            if (CMBC_CHOPC.Text == "Numero de Servicio")
            {
                 reporteCH = con.sp_ReporteConsumoHistorico("NumeroServicio", (int)NUDC_CHANIO.Value, 0,
                    Int32.Parse(CMBC_CHNUM.Text));
                DTG_CONSUMOH.DataSource = reporteCH;

                DTG_CONSUMOH.Columns["Importe"].DefaultCellStyle.Format = "N2";
                DTG_CONSUMOH.Columns["Pagado"].DefaultCellStyle.Format = "N2";
                DTG_CONSUMOH.Columns["Pendiente de Pago"].DefaultCellStyle.Format = "N2";


            }
            else if (CMBC_CHOPC.Text == "Numero de Medidor")
            {
                 reporteCH = con.sp_ReporteConsumoHistorico("NumeroMedidor", (int)NUDC_CHANIO.Value,
                    Int32.Parse(CMBC_CHNUM.Text), 0);
                DTG_CONSUMOH.DataSource = reporteCH;

                DTG_CONSUMOH.Columns["Importe"].DefaultCellStyle.Format = "N2";
                DTG_CONSUMOH.Columns["Pagado"].DefaultCellStyle.Format = "N2";
                DTG_CONSUMOH.Columns["Pendiente de Pago"].DefaultCellStyle.Format = "N2";


            }


        }

        private void CMBC_CSERVICIOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded == true)
            {
                EnlaceDB con = EnlaceDB.getInstance();
                DataTable fechas = con.sp_RecibosClientes("SelectFecha", 0, Int32.Parse(CMBC_CSERVICIOS.Text));
                CMBC_FECHA.DataSource = fechas;
                CMBC_FECHA.DisplayMember = "Fecha";
                
            }
        }

        private void CMBC_PSERVICIOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded == true)
            {
                EnlaceDB con = EnlaceDB.getInstance();
                DataTable fechas = con.sp_RecibosClientes("SelectFecha", 0, Int32.Parse(CMBC_PSERVICIOS.Text));
                CMBC_PFECHA.DataSource = fechas;
                CMBC_PFECHA.DisplayMember = "Fecha";
            }
        }

        private void BTNC_PAGAR_Click(object sender, EventArgs e)
        {
            if (CMBC_PSERVICIOS.SelectedIndex != -1 && CMBC_PFECHA.SelectedIndex != -1) {
                EnlaceDB con = EnlaceDB.getInstance();

                con.sp_Recibos("Pagar", 0, Int32.Parse(CMBC_PSERVICIOS.Text), 0, Convert.ToDateTime(CMBC_PFECHA.Text).ToString("yyyyMMdd"),
                           "", "No Pagado", 0, 0, 0, 0, 0, 0, 0, 0,(float)NUDC_TOTAL.Value, 0, 0, 0, 0);

                DataTable fechas = con.sp_RecibosClientes("SelectFecha", 0, Int32.Parse(CMBC_PSERVICIOS.Text));
                foreach (DataRow row in fechas.Rows)
                {
                    string sFecha = row["Fecha"].ToString();
                    DateTime dtFecha = Convert.ToDateTime(sFecha);
                    sFecha = dtFecha.ToString("dd/MM/yyyy");
                    if (sFecha == CMBC_PFECHA.Text)
                    {
                        TEXTC_CANTP.Text = (Math.Round(Convert.ToDecimal(row["Pendiente_Pago"].ToString()), 2)).ToString();
                    }
                }
            }
        }

        private void CMBC_PFECHA_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnlaceDB con = EnlaceDB.getInstance();
            DataTable fechas = con.sp_RecibosClientes("SelectFecha", 0, Int32.Parse(CMBC_PSERVICIOS.Text));
            foreach(DataRow row in fechas.Rows)
            {
                string sFecha = row["Fecha"].ToString();
                DateTime dtFecha = Convert.ToDateTime(sFecha);
                sFecha = dtFecha.ToString("dd/MM/yyyy");
                if(sFecha == CMBC_PFECHA.Text)
                {
                    TEXTC_CANTP.Text = (Math.Round(Convert.ToDecimal(row["Pendiente_Pago"].ToString()), 2)).ToString();
                }
            }
        }

        private void BTNC_PDF_Click(object sender, EventArgs e)
        {
            if (CMBC_CSERVICIOS.SelectedIndex != -1 && CMBC_FECHA.SelectedIndex != -1) {
                DateTime fechaRecibo = Convert.ToDateTime(CMBC_FECHA.Text);
              EnlaceDB con = EnlaceDB.getInstance();
                 recibo = con.sp_SeleccionarRecibo("NumeroServicio", 0, Int32.Parse(CMBC_CSERVICIOS.Text),
                    fechaRecibo.Year, fechaRecibo.Month);

                generarPDF();
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
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                moneda oMoneda = new moneda();

                string numLetra = oMoneda.Convertir(recibo.Rows[0]["Importe"].ToString().Substring(0, recibo.Rows[0]["Importe"].ToString().Length - 5), true, "PESOS");


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

                cl1t1 = new PdfPCell(new Phrase("NO. DE SERVICIO: " + recibo.Rows[0]["Numero_Servicio"].ToString(), standard));
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
                MessageBox.Show("PDF creado con exito en la direccion: " + ruta, "Recibos", MessageBoxButtons.OK);

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al crear el archivo", "Recibos", MessageBoxButtons.OK);
            }
        }

        private void BTNC_CHPDF_Click(object sender, EventArgs e)
        {
            string tituloArchivo = "Reporte Consumo Historico " + NUDC_CHANIO.Value.ToString() + "-" + 
                CMBC_CHOPC.Text + "-" + CMBC_CHNUM.Text + "-Cliente " + idClienteActual.ToString();
            string ruta = "Archivos//" + tituloArchivo + ".pdf";
            if (DTG_CONSUMOH.Rows.Count != 0)
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
    }
}
