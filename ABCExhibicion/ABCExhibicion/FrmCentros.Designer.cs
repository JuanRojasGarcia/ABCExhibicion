namespace ABCExhibicion
{
    partial class FrmCentros
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
            this.lbl_Centros = new System.Windows.Forms.Label();
            this.lbl_CentroNom = new System.Windows.Forms.Label();
            this.txt_CentroNom = new System.Windows.Forms.TextBox();
            this.lbl_CentroNum = new System.Windows.Forms.Label();
            this.txt_CenNum = new System.Windows.Forms.TextBox();
            this.rdb_AgregarCentro = new System.Windows.Forms.RadioButton();
            this.rdb_ModificarCentro = new System.Windows.Forms.RadioButton();
            this.rdb_EliminarCentro = new System.Windows.Forms.RadioButton();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.btn_Modificar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Consultar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_CentrosRegresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Centros
            // 
            this.lbl_Centros.AutoSize = true;
            this.lbl_Centros.Location = new System.Drawing.Point(167, 9);
            this.lbl_Centros.Name = "lbl_Centros";
            this.lbl_Centros.Size = new System.Drawing.Size(43, 13);
            this.lbl_Centros.TabIndex = 0;
            this.lbl_Centros.Text = "Centros";
            // 
            // lbl_CentroNom
            // 
            this.lbl_CentroNom.AutoSize = true;
            this.lbl_CentroNom.Location = new System.Drawing.Point(58, 97);
            this.lbl_CentroNom.Name = "lbl_CentroNom";
            this.lbl_CentroNom.Size = new System.Drawing.Size(44, 13);
            this.lbl_CentroNom.TabIndex = 1;
            this.lbl_CentroNom.Text = "Nombre";
            // 
            // txt_CentroNom
            // 
            this.txt_CentroNom.Location = new System.Drawing.Point(127, 94);
            this.txt_CentroNom.Name = "txt_CentroNom";
            this.txt_CentroNom.Size = new System.Drawing.Size(100, 20);
            this.txt_CentroNom.TabIndex = 2;
            // 
            // lbl_CentroNum
            // 
            this.lbl_CentroNum.AutoSize = true;
            this.lbl_CentroNum.Location = new System.Drawing.Point(44, 55);
            this.lbl_CentroNum.Name = "lbl_CentroNum";
            this.lbl_CentroNum.Size = new System.Drawing.Size(78, 13);
            this.lbl_CentroNum.TabIndex = 3;
            this.lbl_CentroNum.Text = "Numero Centro";
            // 
            // txt_CenNum
            // 
            this.txt_CenNum.Location = new System.Drawing.Point(128, 52);
            this.txt_CenNum.Name = "txt_CenNum";
            this.txt_CenNum.Size = new System.Drawing.Size(100, 20);
            this.txt_CenNum.TabIndex = 4;
            this.txt_CenNum.TextChanged += new System.EventHandler(this.txt_CenNum_TextChanged);
            // 
            // rdb_AgregarCentro
            // 
            this.rdb_AgregarCentro.AutoSize = true;
            this.rdb_AgregarCentro.Location = new System.Drawing.Point(59, 144);
            this.rdb_AgregarCentro.Name = "rdb_AgregarCentro";
            this.rdb_AgregarCentro.Size = new System.Drawing.Size(62, 17);
            this.rdb_AgregarCentro.TabIndex = 5;
            this.rdb_AgregarCentro.Text = "Agregar";
            this.rdb_AgregarCentro.UseVisualStyleBackColor = true;
            this.rdb_AgregarCentro.CheckedChanged += new System.EventHandler(this.rdb_AgregarCentro_CheckedChanged);
            // 
            // rdb_ModificarCentro
            // 
            this.rdb_ModificarCentro.AutoSize = true;
            this.rdb_ModificarCentro.Location = new System.Drawing.Point(127, 144);
            this.rdb_ModificarCentro.Name = "rdb_ModificarCentro";
            this.rdb_ModificarCentro.Size = new System.Drawing.Size(68, 17);
            this.rdb_ModificarCentro.TabIndex = 6;
            this.rdb_ModificarCentro.Text = "Modificar";
            this.rdb_ModificarCentro.UseVisualStyleBackColor = true;
            this.rdb_ModificarCentro.CheckedChanged += new System.EventHandler(this.rdb_ModificarCentro_CheckedChanged);
            // 
            // rdb_EliminarCentro
            // 
            this.rdb_EliminarCentro.AutoSize = true;
            this.rdb_EliminarCentro.Location = new System.Drawing.Point(201, 144);
            this.rdb_EliminarCentro.Name = "rdb_EliminarCentro";
            this.rdb_EliminarCentro.Size = new System.Drawing.Size(61, 17);
            this.rdb_EliminarCentro.TabIndex = 7;
            this.rdb_EliminarCentro.Text = "Eliminar";
            this.rdb_EliminarCentro.UseVisualStyleBackColor = true;
            this.rdb_EliminarCentro.CheckedChanged += new System.EventHandler(this.rdb_EliminarCentro_CheckedChanged);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Location = new System.Drawing.Point(18, 209);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_Agregar.TabIndex = 8;
            this.btn_Agregar.Text = "Grabar";
            this.btn_Agregar.UseVisualStyleBackColor = true;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // btn_Modificar
            // 
            this.btn_Modificar.Location = new System.Drawing.Point(114, 209);
            this.btn_Modificar.Name = "btn_Modificar";
            this.btn_Modificar.Size = new System.Drawing.Size(75, 23);
            this.btn_Modificar.TabIndex = 9;
            this.btn_Modificar.Text = "Modificar";
            this.btn_Modificar.UseVisualStyleBackColor = true;
            this.btn_Modificar.Click += new System.EventHandler(this.btn_Modificar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(225, 209);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_Eliminar.TabIndex = 10;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Consultar
            // 
            this.btn_Consultar.Location = new System.Drawing.Point(258, 74);
            this.btn_Consultar.Name = "btn_Consultar";
            this.btn_Consultar.Size = new System.Drawing.Size(75, 23);
            this.btn_Consultar.TabIndex = 11;
            this.btn_Consultar.Text = "Consultar";
            this.btn_Consultar.UseVisualStyleBackColor = true;
            this.btn_Consultar.Click += new System.EventHandler(this.btn_Consultar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(352, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(244, 255);
            this.dataGridView1.TabIndex = 12;
            // 
            // btn_CentrosRegresar
            // 
            this.btn_CentrosRegresar.Location = new System.Drawing.Point(13, 295);
            this.btn_CentrosRegresar.Name = "btn_CentrosRegresar";
            this.btn_CentrosRegresar.Size = new System.Drawing.Size(75, 23);
            this.btn_CentrosRegresar.TabIndex = 13;
            this.btn_CentrosRegresar.Text = "Regresar";
            this.btn_CentrosRegresar.UseVisualStyleBackColor = true;
            this.btn_CentrosRegresar.Click += new System.EventHandler(this.btn_CentrosRegresar_Click);
            // 
            // FrmCentros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 330);
            this.Controls.Add(this.btn_CentrosRegresar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Consultar);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Modificar);
            this.Controls.Add(this.btn_Agregar);
            this.Controls.Add(this.rdb_EliminarCentro);
            this.Controls.Add(this.rdb_ModificarCentro);
            this.Controls.Add(this.rdb_AgregarCentro);
            this.Controls.Add(this.txt_CenNum);
            this.Controls.Add(this.lbl_CentroNum);
            this.Controls.Add(this.txt_CentroNom);
            this.Controls.Add(this.lbl_CentroNom);
            this.Controls.Add(this.lbl_Centros);
            this.Name = "FrmCentros";
            this.Text = "Centros";
            this.Load += new System.EventHandler(this.FrmCentros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Centros;
        private System.Windows.Forms.Label lbl_CentroNom;
        private System.Windows.Forms.TextBox txt_CentroNom;
        private System.Windows.Forms.Label lbl_CentroNum;
        private System.Windows.Forms.TextBox txt_CenNum;
        private System.Windows.Forms.RadioButton rdb_AgregarCentro;
        private System.Windows.Forms.RadioButton rdb_ModificarCentro;
        private System.Windows.Forms.RadioButton rdb_EliminarCentro;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_Modificar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Consultar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_CentrosRegresar;
    }
}