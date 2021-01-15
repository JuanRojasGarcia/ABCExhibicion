namespace ABCExhibicion
{
    partial class FrmAbcExhibicion
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ventasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.locacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.rdb_Modificar = new System.Windows.Forms.RadioButton();
            this.rdb_Eliminar = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Codigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Cliente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_TotalVenta = new System.Windows.Forms.TextBox();
            this.txt_FechaVenta = new System.Windows.Forms.TextBox();
            this.btn_Consultar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_TAR = new System.Windows.Forms.Label();
            this.lbl_TCE = new System.Windows.Forms.Label();
            this.lbl_TCL = new System.Windows.Forms.Label();
            this.lbl_TVE = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(656, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            this.inicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventasToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.articulosToolStripMenuItem,
            this.locacionesToolStripMenuItem,
            this.configuracionToolStripMenuItem});
            this.inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            this.inicioToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.inicioToolStripMenuItem.Text = "Menu";
            // 
            // ventasToolStripMenuItem
            // 
            this.ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            this.ventasToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ventasToolStripMenuItem.Text = "Ventas";
            this.ventasToolStripMenuItem.Click += new System.EventHandler(this.ventasToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // articulosToolStripMenuItem
            // 
            this.articulosToolStripMenuItem.Name = "articulosToolStripMenuItem";
            this.articulosToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.articulosToolStripMenuItem.Text = "Articulos";
            this.articulosToolStripMenuItem.Click += new System.EventHandler(this.articulosToolStripMenuItem_Click);
            // 
            // locacionesToolStripMenuItem
            // 
            this.locacionesToolStripMenuItem.Name = "locacionesToolStripMenuItem";
            this.locacionesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.locacionesToolStripMenuItem.Text = "Locaciones";
            this.locacionesToolStripMenuItem.Click += new System.EventHandler(this.locacionesToolStripMenuItem_Click_1);
            // 
            // configuracionToolStripMenuItem
            // 
            this.configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            this.configuracionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.configuracionToolStripMenuItem.Text = "Configuracion";
            this.configuracionToolStripMenuItem.Click += new System.EventHandler(this.configuracionToolStripMenuItem_Click);
            // 
            // dgvVentas
            // 
            this.dgvVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVentas.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvVentas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Location = new System.Drawing.Point(71, 293);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.Size = new System.Drawing.Size(531, 179);
            this.dgvVentas.TabIndex = 1;
            // 
            // rdb_Modificar
            // 
            this.rdb_Modificar.AutoSize = true;
            this.rdb_Modificar.Location = new System.Drawing.Point(253, 270);
            this.rdb_Modificar.Name = "rdb_Modificar";
            this.rdb_Modificar.Size = new System.Drawing.Size(68, 17);
            this.rdb_Modificar.TabIndex = 2;
            this.rdb_Modificar.TabStop = true;
            this.rdb_Modificar.Text = "Modificar";
            this.rdb_Modificar.UseVisualStyleBackColor = true;
            this.rdb_Modificar.CheckedChanged += new System.EventHandler(this.rdb_Modificar_CheckedChanged);
            // 
            // rdb_Eliminar
            // 
            this.rdb_Eliminar.AutoSize = true;
            this.rdb_Eliminar.Location = new System.Drawing.Point(354, 270);
            this.rdb_Eliminar.Name = "rdb_Eliminar";
            this.rdb_Eliminar.Size = new System.Drawing.Size(61, 17);
            this.rdb_Eliminar.TabIndex = 3;
            this.rdb_Eliminar.TabStop = true;
            this.rdb_Eliminar.Text = "Eliminar";
            this.rdb_Eliminar.UseVisualStyleBackColor = true;
            this.rdb_Eliminar.CheckedChanged += new System.EventHandler(this.rdb_Eliminar_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Codigo";
            // 
            // txt_Codigo
            // 
            this.txt_Codigo.Location = new System.Drawing.Point(143, 158);
            this.txt_Codigo.Name = "txt_Codigo";
            this.txt_Codigo.Size = new System.Drawing.Size(100, 20);
            this.txt_Codigo.TabIndex = 5;
            this.txt_Codigo.TextChanged += new System.EventHandler(this.txt_Codigo_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cliente";
            // 
            // txt_Cliente
            // 
            this.txt_Cliente.Location = new System.Drawing.Point(143, 204);
            this.txt_Cliente.Name = "txt_Cliente";
            this.txt_Cliente.Size = new System.Drawing.Size(100, 20);
            this.txt_Cliente.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(268, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Total Venta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Fecha Venta";
            // 
            // txt_TotalVenta
            // 
            this.txt_TotalVenta.Location = new System.Drawing.Point(354, 158);
            this.txt_TotalVenta.Name = "txt_TotalVenta";
            this.txt_TotalVenta.Size = new System.Drawing.Size(100, 20);
            this.txt_TotalVenta.TabIndex = 10;
            // 
            // txt_FechaVenta
            // 
            this.txt_FechaVenta.Location = new System.Drawing.Point(354, 210);
            this.txt_FechaVenta.Name = "txt_FechaVenta";
            this.txt_FechaVenta.Size = new System.Drawing.Size(100, 20);
            this.txt_FechaVenta.TabIndex = 11;
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.Location = new System.Drawing.Point(500, 157);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_Consultar.TabIndex = 12;
            this.btn_Consultar.Text = "Consultar";
            this.btn_Consultar.UseVisualStyleBackColor = true;
            this.btn_Consultar.Click += new System.EventHandler(this.btn_Consultar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Location = new System.Drawing.Point(500, 212);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(75, 23);
            this.btn_Modificar.TabIndex = 13;
            this.btn_Modificar.Text = "Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(500, 241);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar.TabIndex = 14;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(97, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Articulos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(241, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Locaciones";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(403, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Clientes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(551, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ventas";
            // 
            // lbl_TAR
            // 
            this.lbl_TAR.AutoSize = true;
            this.lbl_TAR.Location = new System.Drawing.Point(112, 69);
            this.lbl_TAR.Name = "lbl_TAR";
            this.lbl_TAR.Size = new System.Drawing.Size(29, 13);
            this.lbl_TAR.TabIndex = 20;
            this.lbl_TAR.Text = "TAR";
            // 
            // lbl_TCE
            // 
            this.lbl_TCE.AutoSize = true;
            this.lbl_TCE.Location = new System.Drawing.Point(256, 69);
            this.lbl_TCE.Name = "lbl_TCE";
            this.lbl_TCE.Size = new System.Drawing.Size(28, 13);
            this.lbl_TCE.TabIndex = 21;
            this.lbl_TCE.Text = "TLO";
            // 
            // lbl_TCL
            // 
            this.lbl_TCL.AutoSize = true;
            this.lbl_TCL.Location = new System.Drawing.Point(420, 69);
            this.lbl_TCL.Name = "lbl_TCL";
            this.lbl_TCL.Size = new System.Drawing.Size(27, 13);
            this.lbl_TCL.TabIndex = 22;
            this.lbl_TCL.Text = "TCL";
            // 
            // lbl_TVE
            // 
            this.lbl_TVE.AutoSize = true;
            this.lbl_TVE.Location = new System.Drawing.Point(563, 69);
            this.lbl_TVE.Name = "lbl_TVE";
            this.lbl_TVE.Size = new System.Drawing.Size(28, 13);
            this.lbl_TVE.TabIndex = 23;
            this.lbl_TVE.Text = "TVE";
            // 
            // FrmAbcExhibicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 489);
            this.Controls.Add(this.lbl_TVE);
            this.Controls.Add(this.lbl_TCL);
            this.Controls.Add(this.lbl_TCE);
            this.Controls.Add(this.lbl_TAR);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Consultar);
            this.Controls.Add(this.txt_FechaVenta);
            this.Controls.Add(this.txt_TotalVenta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Cliente);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Codigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rdb_Eliminar);
            this.Controls.Add(this.rdb_Modificar);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmAbcExhibicion";
            this.Text = "ABCExhibicion";
            this.Load += new System.EventHandler(this.FrmAbcExhibicion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ventasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem locacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.RadioButton rdb_Modificar;
        private System.Windows.Forms.RadioButton rdb_Eliminar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Codigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Cliente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_TotalVenta;
        private System.Windows.Forms.TextBox txt_FechaVenta;
        private System.Windows.Forms.Button btn_Consultar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_TAR;
        private System.Windows.Forms.Label lbl_TCE;
        private System.Windows.Forms.Label lbl_TCL;
        private System.Windows.Forms.Label lbl_TVE;
    }
}

