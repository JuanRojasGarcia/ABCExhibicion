namespace ABCExhibicion
{
    partial class FrmVentas
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
            this.lbl_Ventas = new System.Windows.Forms.Label();
            this.lbl_VentaCliente = new System.Windows.Forms.Label();
            this.lbl_VentaArticulo = new System.Windows.Forms.Label();
            this.cmb_VentaCliente = new System.Windows.Forms.ComboBox();
            this.cmb_VentaArticulo = new System.Windows.Forms.ComboBox();
            this.btn_AgregarArticulo = new System.Windows.Forms.Button();
            this.dgvAddArticulos = new System.Windows.Forms.DataGridView();
            this.lbl_VentaEnganche = new System.Windows.Forms.Label();
            this.lbl_VentasBoniEng = new System.Windows.Forms.Label();
            this.lbl_VentaTotal = new System.Windows.Forms.Label();
            this.txt_VentasEnganche = new System.Windows.Forms.TextBox();
            this.txt_VentaBoniEng = new System.Windows.Forms.TextBox();
            this.txt_VentaTotal = new System.Windows.Forms.TextBox();
            this.lbl_VentasRFC = new System.Windows.Forms.Label();
            this.lbl_VentasRFCResult = new System.Windows.Forms.Label();
            this.btn_VentasGrabar = new System.Windows.Forms.Button();
            this.dgvAbonosMensuales = new System.Windows.Forms.DataGridView();
            this.btn_VentasCancelar = new System.Windows.Forms.Button();
            this.btn_VentasSiguente = new System.Windows.Forms.Button();
            this.lbl_VentasAbonosMensuales = new System.Windows.Forms.Label();
            this.btn_VentasREgresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbonosMensuales)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Ventas
            // 
            this.lbl_Ventas.AutoSize = true;
            this.lbl_Ventas.Location = new System.Drawing.Point(366, 9);
            this.lbl_Ventas.Name = "lbl_Ventas";
            this.lbl_Ventas.Size = new System.Drawing.Size(40, 13);
            this.lbl_Ventas.TabIndex = 0;
            this.lbl_Ventas.Text = "Ventas";
            // 
            // lbl_VentaCliente
            // 
            this.lbl_VentaCliente.AutoSize = true;
            this.lbl_VentaCliente.Location = new System.Drawing.Point(12, 52);
            this.lbl_VentaCliente.Name = "lbl_VentaCliente";
            this.lbl_VentaCliente.Size = new System.Drawing.Size(39, 13);
            this.lbl_VentaCliente.TabIndex = 1;
            this.lbl_VentaCliente.Text = "Cliente";
            // 
            // lbl_VentaArticulo
            // 
            this.lbl_VentaArticulo.AutoSize = true;
            this.lbl_VentaArticulo.Location = new System.Drawing.Point(12, 90);
            this.lbl_VentaArticulo.Name = "lbl_VentaArticulo";
            this.lbl_VentaArticulo.Size = new System.Drawing.Size(42, 13);
            this.lbl_VentaArticulo.TabIndex = 2;
            this.lbl_VentaArticulo.Text = "Articulo";
            // 
            // cmb_VentaCliente
            // 
            this.cmb_VentaCliente.FormattingEnabled = true;
            this.cmb_VentaCliente.Location = new System.Drawing.Point(59, 49);
            this.cmb_VentaCliente.Name = "cmb_VentaCliente";
            this.cmb_VentaCliente.Size = new System.Drawing.Size(171, 21);
            this.cmb_VentaCliente.TabIndex = 3;
            this.cmb_VentaCliente.SelectedIndexChanged += new System.EventHandler(this.cmb_VentaCliente_SelectedIndexChanged);
            // 
            // cmb_VentaArticulo
            // 
            this.cmb_VentaArticulo.FormattingEnabled = true;
            this.cmb_VentaArticulo.Location = new System.Drawing.Point(59, 87);
            this.cmb_VentaArticulo.Name = "cmb_VentaArticulo";
            this.cmb_VentaArticulo.Size = new System.Drawing.Size(121, 21);
            this.cmb_VentaArticulo.TabIndex = 4;
            // 
            // btn_AgregarArticulo
            // 
            this.btn_AgregarArticulo.Location = new System.Drawing.Point(191, 87);
            this.btn_AgregarArticulo.Name = "btn_AgregarArticulo";
            this.btn_AgregarArticulo.Size = new System.Drawing.Size(39, 21);
            this.btn_AgregarArticulo.TabIndex = 5;
            this.btn_AgregarArticulo.Text = "ADD";
            this.btn_AgregarArticulo.UseVisualStyleBackColor = true;
            this.btn_AgregarArticulo.Click += new System.EventHandler(this.btn_AgregarArticulo_Click);
            // 
            // dgvAddArticulos
            // 
            this.dgvAddArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAddArticulos.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvAddArticulos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAddArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddArticulos.Location = new System.Drawing.Point(12, 126);
            this.dgvAddArticulos.Name = "dgvAddArticulos";
            this.dgvAddArticulos.Size = new System.Drawing.Size(705, 188);
            this.dgvAddArticulos.TabIndex = 6;
            // 
            // lbl_VentaEnganche
            // 
            this.lbl_VentaEnganche.AutoSize = true;
            this.lbl_VentaEnganche.Location = new System.Drawing.Point(594, 331);
            this.lbl_VentaEnganche.Name = "lbl_VentaEnganche";
            this.lbl_VentaEnganche.Size = new System.Drawing.Size(56, 13);
            this.lbl_VentaEnganche.TabIndex = 7;
            this.lbl_VentaEnganche.Text = "Enganche";
            // 
            // lbl_VentasBoniEng
            // 
            this.lbl_VentasBoniEng.AutoSize = true;
            this.lbl_VentasBoniEng.Location = new System.Drawing.Point(533, 363);
            this.lbl_VentasBoniEng.Name = "lbl_VentasBoniEng";
            this.lbl_VentasBoniEng.Size = new System.Drawing.Size(117, 13);
            this.lbl_VentasBoniEng.TabIndex = 8;
            this.lbl_VentasBoniEng.Text = "Bonificacion Enganche";
            // 
            // lbl_VentaTotal
            // 
            this.lbl_VentaTotal.AutoSize = true;
            this.lbl_VentaTotal.Location = new System.Drawing.Point(619, 399);
            this.lbl_VentaTotal.Name = "lbl_VentaTotal";
            this.lbl_VentaTotal.Size = new System.Drawing.Size(31, 13);
            this.lbl_VentaTotal.TabIndex = 9;
            this.lbl_VentaTotal.Text = "Total";
            // 
            // txt_VentasEnganche
            // 
            this.txt_VentasEnganche.Location = new System.Drawing.Point(656, 328);
            this.txt_VentasEnganche.Name = "txt_VentasEnganche";
            this.txt_VentasEnganche.Size = new System.Drawing.Size(61, 20);
            this.txt_VentasEnganche.TabIndex = 10;
            // 
            // txt_VentaBoniEng
            // 
            this.txt_VentaBoniEng.Location = new System.Drawing.Point(656, 360);
            this.txt_VentaBoniEng.Name = "txt_VentaBoniEng";
            this.txt_VentaBoniEng.Size = new System.Drawing.Size(61, 20);
            this.txt_VentaBoniEng.TabIndex = 11;
            // 
            // txt_VentaTotal
            // 
            this.txt_VentaTotal.Location = new System.Drawing.Point(656, 396);
            this.txt_VentaTotal.Name = "txt_VentaTotal";
            this.txt_VentaTotal.Size = new System.Drawing.Size(61, 20);
            this.txt_VentaTotal.TabIndex = 12;
            // 
            // lbl_VentasRFC
            // 
            this.lbl_VentasRFC.AutoSize = true;
            this.lbl_VentasRFC.Location = new System.Drawing.Point(251, 52);
            this.lbl_VentasRFC.Name = "lbl_VentasRFC";
            this.lbl_VentasRFC.Size = new System.Drawing.Size(31, 13);
            this.lbl_VentasRFC.TabIndex = 13;
            this.lbl_VentasRFC.Text = "RFC:";
            // 
            // lbl_VentasRFCResult
            // 
            this.lbl_VentasRFCResult.AutoSize = true;
            this.lbl_VentasRFCResult.Location = new System.Drawing.Point(288, 52);
            this.lbl_VentasRFCResult.Name = "lbl_VentasRFCResult";
            this.lbl_VentasRFCResult.Size = new System.Drawing.Size(0, 13);
            this.lbl_VentasRFCResult.TabIndex = 14;
            // 
            // btn_VentasGrabar
            // 
            this.btn_VentasGrabar.Location = new System.Drawing.Point(513, 636);
            this.btn_VentasGrabar.Name = "btn_VentasGrabar";
            this.btn_VentasGrabar.Size = new System.Drawing.Size(64, 23);
            this.btn_VentasGrabar.TabIndex = 15;
            this.btn_VentasGrabar.Text = "Grabar";
            this.btn_VentasGrabar.UseVisualStyleBackColor = true;
            this.btn_VentasGrabar.Click += new System.EventHandler(this.btn_VentasGrabar_Click);
            // 
            // dgvAbonosMensuales
            // 
            this.dgvAbonosMensuales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAbonosMensuales.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvAbonosMensuales.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAbonosMensuales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAbonosMensuales.Location = new System.Drawing.Point(15, 457);
            this.dgvAbonosMensuales.Name = "dgvAbonosMensuales";
            this.dgvAbonosMensuales.Size = new System.Drawing.Size(702, 172);
            this.dgvAbonosMensuales.TabIndex = 16;
            // 
            // btn_VentasCancelar
            // 
            this.btn_VentasCancelar.Location = new System.Drawing.Point(583, 636);
            this.btn_VentasCancelar.Name = "btn_VentasCancelar";
            this.btn_VentasCancelar.Size = new System.Drawing.Size(64, 23);
            this.btn_VentasCancelar.TabIndex = 17;
            this.btn_VentasCancelar.Text = "Cancelar";
            this.btn_VentasCancelar.UseVisualStyleBackColor = true;
            this.btn_VentasCancelar.Click += new System.EventHandler(this.btn_VentasCancelar_Click);
            // 
            // btn_VentasSiguente
            // 
            this.btn_VentasSiguente.Location = new System.Drawing.Point(653, 636);
            this.btn_VentasSiguente.Name = "btn_VentasSiguente";
            this.btn_VentasSiguente.Size = new System.Drawing.Size(64, 23);
            this.btn_VentasSiguente.TabIndex = 18;
            this.btn_VentasSiguente.Text = "Siguiente";
            this.btn_VentasSiguente.UseVisualStyleBackColor = true;
            this.btn_VentasSiguente.Click += new System.EventHandler(this.btn_VentasSiguente_Click);
            // 
            // lbl_VentasAbonosMensuales
            // 
            this.lbl_VentasAbonosMensuales.AutoSize = true;
            this.lbl_VentasAbonosMensuales.Location = new System.Drawing.Point(308, 437);
            this.lbl_VentasAbonosMensuales.Name = "lbl_VentasAbonosMensuales";
            this.lbl_VentasAbonosMensuales.Size = new System.Drawing.Size(121, 13);
            this.lbl_VentasAbonosMensuales.TabIndex = 19;
            this.lbl_VentasAbonosMensuales.Text = "ABONOS MENSUALES";
            // 
            // btn_VentasREgresar
            // 
            this.btn_VentasREgresar.Location = new System.Drawing.Point(12, 636);
            this.btn_VentasREgresar.Name = "btn_VentasREgresar";
            this.btn_VentasREgresar.Size = new System.Drawing.Size(75, 23);
            this.btn_VentasREgresar.TabIndex = 20;
            this.btn_VentasREgresar.Text = "Regresar";
            this.btn_VentasREgresar.UseVisualStyleBackColor = true;
            this.btn_VentasREgresar.Click += new System.EventHandler(this.btn_VentasREgresar_Click);
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(732, 666);
            this.Controls.Add(this.btn_VentasREgresar);
            this.Controls.Add(this.lbl_VentasAbonosMensuales);
            this.Controls.Add(this.btn_VentasSiguente);
            this.Controls.Add(this.btn_VentasCancelar);
            this.Controls.Add(this.dgvAbonosMensuales);
            this.Controls.Add(this.btn_VentasGrabar);
            this.Controls.Add(this.lbl_VentasRFCResult);
            this.Controls.Add(this.lbl_VentasRFC);
            this.Controls.Add(this.txt_VentaTotal);
            this.Controls.Add(this.txt_VentaBoniEng);
            this.Controls.Add(this.txt_VentasEnganche);
            this.Controls.Add(this.lbl_VentaTotal);
            this.Controls.Add(this.lbl_VentasBoniEng);
            this.Controls.Add(this.lbl_VentaEnganche);
            this.Controls.Add(this.dgvAddArticulos);
            this.Controls.Add(this.btn_AgregarArticulo);
            this.Controls.Add(this.cmb_VentaArticulo);
            this.Controls.Add(this.cmb_VentaCliente);
            this.Controls.Add(this.lbl_VentaArticulo);
            this.Controls.Add(this.lbl_VentaCliente);
            this.Controls.Add(this.lbl_Ventas);
            this.Name = "FrmVentas";
            this.Text = "Ventas";
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAbonosMensuales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Ventas;
        private System.Windows.Forms.Label lbl_VentaCliente;
        private System.Windows.Forms.Label lbl_VentaArticulo;
        private System.Windows.Forms.ComboBox cmb_VentaCliente;
        private System.Windows.Forms.ComboBox cmb_VentaArticulo;
        private System.Windows.Forms.Button btn_AgregarArticulo;
        private System.Windows.Forms.DataGridView dgvAddArticulos;
        private System.Windows.Forms.Label lbl_VentaEnganche;
        private System.Windows.Forms.Label lbl_VentasBoniEng;
        private System.Windows.Forms.Label lbl_VentaTotal;
        private System.Windows.Forms.TextBox txt_VentasEnganche;
        private System.Windows.Forms.TextBox txt_VentaBoniEng;
        private System.Windows.Forms.TextBox txt_VentaTotal;
        private System.Windows.Forms.Label lbl_VentasRFC;
        private System.Windows.Forms.Label lbl_VentasRFCResult;
        private System.Windows.Forms.Button btn_VentasGrabar;
        private System.Windows.Forms.DataGridView dgvAbonosMensuales;
        private System.Windows.Forms.Button btn_VentasCancelar;
        private System.Windows.Forms.Button btn_VentasSiguente;
        private System.Windows.Forms.Label lbl_VentasAbonosMensuales;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.Button btn_VentasREgresar;
    }
}