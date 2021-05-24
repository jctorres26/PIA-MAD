namespace BD_MAD_CEE.CLIENTE
{
    partial class C_CLIENTES
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BTNC_PDF = new System.Windows.Forms.Button();
            this.CMBC_FECHA = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CMBC_CSERVICIOS = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.NUDC_TOTAL = new System.Windows.Forms.NumericUpDown();
            this.TEXTC_CANTP = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.BTNC_PAGAR = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CMBC_FORMA = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.CMBC_PFECHA = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.CMBC_PSERVICIOS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.NUDC_CHANIO = new System.Windows.Forms.NumericUpDown();
            this.CMBC_CHNUM = new System.Windows.Forms.ComboBox();
            this.CMBC_CHOPC = new System.Windows.Forms.ComboBox();
            this.BTNC_CHPDF = new System.Windows.Forms.Button();
            this.DTG_CONSUMOH = new System.Windows.Forms.DataGridView();
            this.CMBC_CHVISUAL = new System.Windows.Forms.Button();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDC_TOTAL)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDC_CHANIO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTG_CONSUMOH)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(967, 420);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.BTNC_PDF);
            this.tabPage1.Controls.Add(this.CMBC_FECHA);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CMBC_CSERVICIOS);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(959, 391);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Consultar recibo";
            // 
            // BTNC_PDF
            // 
            this.BTNC_PDF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNC_PDF.Location = new System.Drawing.Point(643, 197);
            this.BTNC_PDF.Margin = new System.Windows.Forms.Padding(4);
            this.BTNC_PDF.Name = "BTNC_PDF";
            this.BTNC_PDF.Size = new System.Drawing.Size(287, 161);
            this.BTNC_PDF.TabIndex = 9;
            this.BTNC_PDF.Text = "Generar recibo PDF";
            this.BTNC_PDF.UseVisualStyleBackColor = false;
            this.BTNC_PDF.Click += new System.EventHandler(this.BTNC_PDF_Click);
            // 
            // CMBC_FECHA
            // 
            this.CMBC_FECHA.FormattingEnabled = true;
            this.CMBC_FECHA.Location = new System.Drawing.Point(265, 41);
            this.CMBC_FECHA.Margin = new System.Windows.Forms.Padding(4);
            this.CMBC_FECHA.Name = "CMBC_FECHA";
            this.CMBC_FECHA.Size = new System.Drawing.Size(160, 24);
            this.CMBC_FECHA.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(261, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha";
            // 
            // CMBC_CSERVICIOS
            // 
            this.CMBC_CSERVICIOS.FormattingEnabled = true;
            this.CMBC_CSERVICIOS.Location = new System.Drawing.Point(28, 41);
            this.CMBC_CSERVICIOS.Margin = new System.Windows.Forms.Padding(4);
            this.CMBC_CSERVICIOS.Name = "CMBC_CSERVICIOS";
            this.CMBC_CSERVICIOS.Size = new System.Drawing.Size(165, 24);
            this.CMBC_CSERVICIOS.TabIndex = 1;
            this.CMBC_CSERVICIOS.SelectedIndexChanged += new System.EventHandler(this.CMBC_CSERVICIOS_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servicios contratados";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.NUDC_TOTAL);
            this.tabPage2.Controls.Add(this.TEXTC_CANTP);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.BTNC_PAGAR);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.CMBC_FORMA);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.CMBC_PFECHA);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.CMBC_PSERVICIOS);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(959, 391);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pagar recibo";
            // 
            // NUDC_TOTAL
            // 
            this.NUDC_TOTAL.DecimalPlaces = 2;
            this.NUDC_TOTAL.Location = new System.Drawing.Point(240, 160);
            this.NUDC_TOTAL.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NUDC_TOTAL.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NUDC_TOTAL.Name = "NUDC_TOTAL";
            this.NUDC_TOTAL.Size = new System.Drawing.Size(159, 22);
            this.NUDC_TOTAL.TabIndex = 22;
            this.NUDC_TOTAL.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // TEXTC_CANTP
            // 
            this.TEXTC_CANTP.Enabled = false;
            this.TEXTC_CANTP.Location = new System.Drawing.Point(431, 159);
            this.TEXTC_CANTP.Margin = new System.Windows.Forms.Padding(4);
            this.TEXTC_CANTP.Name = "TEXTC_CANTP";
            this.TEXTC_CANTP.Size = new System.Drawing.Size(192, 22);
            this.TEXTC_CANTP.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(237, 139);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "Total a pagar";
            // 
            // BTNC_PAGAR
            // 
            this.BTNC_PAGAR.Location = new System.Drawing.Point(700, 124);
            this.BTNC_PAGAR.Margin = new System.Windows.Forms.Padding(4);
            this.BTNC_PAGAR.Name = "BTNC_PAGAR";
            this.BTNC_PAGAR.Size = new System.Drawing.Size(171, 94);
            this.BTNC_PAGAR.TabIndex = 18;
            this.BTNC_PAGAR.Text = "Pagar";
            this.BTNC_PAGAR.UseVisualStyleBackColor = true;
            this.BTNC_PAGAR.Click += new System.EventHandler(this.BTNC_PAGAR_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(427, 139);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(189, 17);
            this.label10.TabIndex = 16;
            this.label10.Text = "Cantidad Pendiente de Pago";
            // 
            // CMBC_FORMA
            // 
            this.CMBC_FORMA.FormattingEnabled = true;
            this.CMBC_FORMA.Location = new System.Drawing.Point(25, 159);
            this.CMBC_FORMA.Margin = new System.Windows.Forms.Padding(4);
            this.CMBC_FORMA.Name = "CMBC_FORMA";
            this.CMBC_FORMA.Size = new System.Drawing.Size(165, 24);
            this.CMBC_FORMA.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 139);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Forma de pago";
            // 
            // CMBC_PFECHA
            // 
            this.CMBC_PFECHA.FormattingEnabled = true;
            this.CMBC_PFECHA.Location = new System.Drawing.Point(231, 42);
            this.CMBC_PFECHA.Margin = new System.Windows.Forms.Padding(4);
            this.CMBC_PFECHA.Name = "CMBC_PFECHA";
            this.CMBC_PFECHA.Size = new System.Drawing.Size(160, 24);
            this.CMBC_PFECHA.TabIndex = 8;
            this.CMBC_PFECHA.SelectedIndexChanged += new System.EventHandler(this.CMBC_PFECHA_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(227, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Fecha";
            // 
            // CMBC_PSERVICIOS
            // 
            this.CMBC_PSERVICIOS.FormattingEnabled = true;
            this.CMBC_PSERVICIOS.Location = new System.Drawing.Point(25, 42);
            this.CMBC_PSERVICIOS.Margin = new System.Windows.Forms.Padding(4);
            this.CMBC_PSERVICIOS.Name = "CMBC_PSERVICIOS";
            this.CMBC_PSERVICIOS.Size = new System.Drawing.Size(165, 24);
            this.CMBC_PSERVICIOS.TabIndex = 3;
            this.CMBC_PSERVICIOS.SelectedIndexChanged += new System.EventHandler(this.CMBC_PSERVICIOS_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Servicios contratados";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.NUDC_CHANIO);
            this.tabPage3.Controls.Add(this.CMBC_CHNUM);
            this.tabPage3.Controls.Add(this.CMBC_CHOPC);
            this.tabPage3.Controls.Add(this.BTNC_CHPDF);
            this.tabPage3.Controls.Add(this.DTG_CONSUMOH);
            this.tabPage3.Controls.Add(this.CMBC_CHVISUAL);
            this.tabPage3.Controls.Add(this.label36);
            this.tabPage3.Controls.Add(this.label35);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(959, 391);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Consumo historico";
            // 
            // NUDC_CHANIO
            // 
            this.NUDC_CHANIO.Location = new System.Drawing.Point(24, 41);
            this.NUDC_CHANIO.Maximum = new decimal(new int[] {
            2021,
            0,
            0,
            0});
            this.NUDC_CHANIO.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.NUDC_CHANIO.Name = "NUDC_CHANIO";
            this.NUDC_CHANIO.Size = new System.Drawing.Size(120, 22);
            this.NUDC_CHANIO.TabIndex = 22;
            this.NUDC_CHANIO.Value = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            // 
            // CMBC_CHNUM
            // 
            this.CMBC_CHNUM.FormattingEnabled = true;
            this.CMBC_CHNUM.Location = new System.Drawing.Point(404, 38);
            this.CMBC_CHNUM.Margin = new System.Windows.Forms.Padding(4);
            this.CMBC_CHNUM.Name = "CMBC_CHNUM";
            this.CMBC_CHNUM.Size = new System.Drawing.Size(160, 24);
            this.CMBC_CHNUM.TabIndex = 21;
            // 
            // CMBC_CHOPC
            // 
            this.CMBC_CHOPC.FormattingEnabled = true;
            this.CMBC_CHOPC.Location = new System.Drawing.Point(211, 39);
            this.CMBC_CHOPC.Margin = new System.Windows.Forms.Padding(4);
            this.CMBC_CHOPC.Name = "CMBC_CHOPC";
            this.CMBC_CHOPC.Size = new System.Drawing.Size(160, 24);
            this.CMBC_CHOPC.TabIndex = 20;
            this.CMBC_CHOPC.SelectedIndexChanged += new System.EventHandler(this.CMBC_CHOPC_SelectedIndexChanged);
            // 
            // BTNC_CHPDF
            // 
            this.BTNC_CHPDF.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BTNC_CHPDF.Location = new System.Drawing.Point(756, 117);
            this.BTNC_CHPDF.Margin = new System.Windows.Forms.Padding(4);
            this.BTNC_CHPDF.Name = "BTNC_CHPDF";
            this.BTNC_CHPDF.Size = new System.Drawing.Size(189, 82);
            this.BTNC_CHPDF.TabIndex = 16;
            this.BTNC_CHPDF.Text = "Generar PDF";
            this.BTNC_CHPDF.UseVisualStyleBackColor = false;
            this.BTNC_CHPDF.Click += new System.EventHandler(this.BTNC_CHPDF_Click);
            // 
            // DTG_CONSUMOH
            // 
            this.DTG_CONSUMOH.AllowUserToAddRows = false;
            this.DTG_CONSUMOH.AllowUserToDeleteRows = false;
            this.DTG_CONSUMOH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DTG_CONSUMOH.Location = new System.Drawing.Point(24, 98);
            this.DTG_CONSUMOH.Margin = new System.Windows.Forms.Padding(4);
            this.DTG_CONSUMOH.Name = "DTG_CONSUMOH";
            this.DTG_CONSUMOH.RowHeadersWidth = 51;
            this.DTG_CONSUMOH.Size = new System.Drawing.Size(721, 254);
            this.DTG_CONSUMOH.TabIndex = 15;
            // 
            // CMBC_CHVISUAL
            // 
            this.CMBC_CHVISUAL.Location = new System.Drawing.Point(593, 18);
            this.CMBC_CHVISUAL.Margin = new System.Windows.Forms.Padding(4);
            this.CMBC_CHVISUAL.Name = "CMBC_CHVISUAL";
            this.CMBC_CHVISUAL.Size = new System.Drawing.Size(152, 54);
            this.CMBC_CHVISUAL.TabIndex = 14;
            this.CMBC_CHVISUAL.Text = "Visualizar";
            this.CMBC_CHVISUAL.UseVisualStyleBackColor = true;
            this.CMBC_CHVISUAL.Click += new System.EventHandler(this.CMBC_CHVISUAL_Click);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(209, 18);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(81, 17);
            this.label36.TabIndex = 9;
            this.label36.Text = "Buscar por:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(20, 18);
            this.label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(33, 17);
            this.label35.TabIndex = 8;
            this.label35.Text = "Año";
            // 
            // C_CLIENTES
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 420);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "C_CLIENTES";
            this.Text = "CLIENTE";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.C_CLIENTES_FormClosed);
            this.Load += new System.EventHandler(this.C_CLIENTES_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDC_TOTAL)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUDC_CHANIO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTG_CONSUMOH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox CMBC_FECHA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CMBC_CSERVICIOS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BTNC_PDF;
        private System.Windows.Forms.Button BTNC_PAGAR;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox CMBC_FORMA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox CMBC_PFECHA;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox CMBC_PSERVICIOS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TEXTC_CANTP;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button CMBC_CHVISUAL;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.DataGridView DTG_CONSUMOH;
        private System.Windows.Forms.Button BTNC_CHPDF;
        private System.Windows.Forms.ComboBox CMBC_CHOPC;
        private System.Windows.Forms.ComboBox CMBC_CHNUM;
        private System.Windows.Forms.NumericUpDown NUDC_CHANIO;
        private System.Windows.Forms.NumericUpDown NUDC_TOTAL;
    }
}