using System;
using System.Windows;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace ABCExhibicion
{ 
    public partial class FrmArticulos : Form
    {
        SqlConnection con = new SqlConnection("Data Source=10.28.146.71;Initial Catalog=ComprasMuebles;User ID=sysdesarrollo;Password=fl9s9FKLGJUT5YAoqtJFTn9MtQgVo9Zn");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        //Variables bool para Cambiar los atributos de los controls 
        public bool btn_AgregarClick = false;
        public bool btn_ModificarClick = false;
        public bool btn_EliminarClick = false;
        public bool btn_ConsultarClick = false;

        public void fMostrarArticulos()
        {
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("proc_abcarticulos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iArticuloid", 0);
            cmd.Parameters.AddWithValue("@cArticuloNom", "");
            cmd.Parameters.AddWithValue("@cArticuloModelo", "");
            cmd.Parameters.AddWithValue("@cArticuloMarca", "");
            cmd.Parameters.AddWithValue("@dArticuloPrecio", 0);
            cmd.Parameters.AddWithValue("@iArticuloExistencia", 0);
            cmd.Parameters.AddWithValue("@iOpcion", 5);
            cmd.ExecuteNonQuery();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            dgvArticulos.DataSource = dt;
            cmd.Parameters.Clear();
            con.Close();
        }

        public FrmArticulos()
        {
            InitializeComponent();
            fMostrarArticulos();
            fConfiguracionControles();          
        }

        private void FrmArticulos_Load(object sender, EventArgs e)
        { 

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {            
            if (txt_iduarticulo.Text != "" && txt_nombre.Text != ""  && txt_Modelo.Text != "" &&  txt_Marca.Text != "" && txt_Precio.Text != "" && txt_Stock.Text != "")
                {
                                                
                    con.Open();
                    cmd = new SqlCommand("proc_abcarticulos", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iArticuloid", txt_iduarticulo.Text);           
                    cmd.Parameters.AddWithValue("@cArticuloNom", txt_nombre.Text);
                    cmd.Parameters.AddWithValue("@cArticuloModelo", txt_Modelo.Text);
                    cmd.Parameters.AddWithValue("@cArticuloMarca", txt_Marca.Text);
                    cmd.Parameters.AddWithValue("@dArticuloPrecio", txt_Precio.Text);
                    cmd.Parameters.AddWithValue("@iArticuloExistencia", txt_Stock.Text);
                    cmd.Parameters.AddWithValue("@iOpcion", 1);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                        if(Convert.ToInt32(reader["Messagge"]) == 1){
                            MessageBox.Show("Codigo Articulo Existente");
                            con.Close();
                        }else{
                            cmd.Parameters.Clear();
                            con.Close();

                            btn_AgregarClick = true;
                
                            fLimpiarCamposArticulos();
                            fMostrarArticulos();  
                        }                            
                            
                }
                else {
                    MessageBox.Show("Ingrese todos los atributos");
                }

                       
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {            

            if (txt_iduarticulo.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_abcarticulos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iArticuloid", txt_iduarticulo.Text);
                cmd.Parameters.AddWithValue("@cArticuloNom", txt_nombre.Text);
                cmd.Parameters.AddWithValue("@cArticuloModelo", txt_Modelo.Text);
                cmd.Parameters.AddWithValue("@cArticuloMarca", txt_Marca.Text);
                cmd.Parameters.AddWithValue("@dArticuloPrecio", txt_Precio.Text);
                cmd.Parameters.AddWithValue("@iArticuloExistencia", txt_Stock.Text);
                cmd.Parameters.AddWithValue("@iOpcion", 2);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

                btn_ModificarClick = true;

                fLimpiarCamposArticulos();
                fMostrarArticulos();
                fAtributosModificarEliminar();
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Articulo");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (txt_iduarticulo.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_abcarticulos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iArticuloid", txt_iduarticulo.Text);
                cmd.Parameters.AddWithValue("@cArticuloNom", "");
                cmd.Parameters.AddWithValue("@cArticuloModelo", "");
                cmd.Parameters.AddWithValue("@cArticuloMarca", "");
                cmd.Parameters.AddWithValue("@dArticuloPrecio", 0);
                cmd.Parameters.AddWithValue("@iArticuloExistencia", 0);
                cmd.Parameters.AddWithValue("@iOpcion", 3);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

                btn_EliminarClick = true;

                fLimpiarCamposArticulos();
                fMostrarArticulos();
                fAtributosModificarEliminar();
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Articulo");
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {

            if (txt_iduarticulo.Text != "") {

                con.Open();
                cmd = new SqlCommand("proc_abcarticulos", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iArticuloid", txt_iduarticulo.Text);
                cmd.Parameters.AddWithValue("@cArticuloNom", "");
                cmd.Parameters.AddWithValue("@cArticuloModelo", "");
                cmd.Parameters.AddWithValue("@cArticuloMarca", "");
                cmd.Parameters.AddWithValue("@dArticuloPrecio", 0);
                cmd.Parameters.AddWithValue("@iArticuloExistencia", 0);
                cmd.Parameters.AddWithValue("@iOpcion", 4);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txt_nombre.Text = reader[1].ToString();
                        txt_Modelo.Text = reader[2].ToString();
                        txt_Marca.Text = reader[3].ToString();
                        txt_Precio.Text = reader[4].ToString();
                        txt_Stock.Text = reader[5].ToString();

                        cmd.Parameters.Clear();
                        con.Close();

                        btn_ConsultarClick = true;
 
                    }else {
                        MessageBox.Show("Codigo Articulo no Existe");
                        btn_ConsultarClick = false;
                        
                    }
                    con.Close();
                
                   
            }else{
                MessageBox.Show("Ingrese el Codigo del Articulo");
            }

            fAtributosConsultar();
        }

        #region Funciones Para Modificar Los Atributos de Los Controles

        public void fConfiguracionControles()
        {
            txt_iduarticulo.Enabled = false;
            txt_Marca.Enabled = false;
            txt_Modelo.Enabled = false;
            txt_nombre.Enabled = false;
            txt_Precio.Enabled = false;
            txt_Stock.Enabled = false;


            btn_Agregar.Visible = false;
            btn_Consultar.Visible = false;
            btn_Eliminar.Visible = false;
            btn_Modificar.Visible = false;
                      
        }

        public void fAtributosConsultar()
        {                       
            if (btn_ConsultarClick == true && rdb_Modificar.Checked == true)
            {
                txt_Marca.Enabled = true;
                txt_Modelo.Enabled = true;
                txt_nombre.Enabled = true;
                txt_Precio.Enabled = true;
                txt_Stock.Enabled = true;

                btn_Modificar.Visible = true;
            }
            if (btn_ConsultarClick == true && rdb_Eliminar.Checked == true)
            {
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
                txt_nombre.Enabled = false;
                txt_Precio.Enabled = false;
                txt_Stock.Enabled = false;

                btn_Eliminar.Visible = true;
            }
        }

        public void fAtributosModificarEliminar()
        {
            if (btn_ModificarClick == true)
            {

                txt_iduarticulo.Enabled = true;
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
                txt_nombre.Enabled = false;
                txt_Precio.Enabled = false;
                txt_Stock.Enabled = false;

                btn_Modificar.Visible = false;
                btn_Consultar.Visible = true;
            }

            if (btn_EliminarClick == true)
            {
                txt_iduarticulo.Enabled = true;
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
                txt_nombre.Enabled = false;
                txt_Precio.Enabled = false;
                txt_Stock.Enabled = false;

                btn_Consultar.Visible = true;
                btn_Eliminar.Visible = false;
            }        
        }

        public void fHabilitarAtributosRdb()
        {

            if (rdb_Agregar.Checked == true)
            {
                txt_iduarticulo.Enabled = true;
                txt_Marca.Enabled = true;
                txt_Modelo.Enabled = true;
                txt_nombre.Enabled = true;
                txt_Precio.Enabled = true;
                txt_Stock.Enabled = true;

                btn_Agregar.Visible = true;
                btn_Consultar.Visible = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;

                rdb_Eliminar.Checked = false;
                rdb_Modificar.Checked = false;

                fLimpiarCamposArticulos();

            }

            if (rdb_Modificar.Checked == true)
            {
                txt_iduarticulo.Enabled = true;
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
                txt_nombre.Enabled = false;
                txt_Precio.Enabled = false;
                txt_Stock.Enabled = false;

                btn_Consultar.Visible = true;
                btn_ConsultarClick = false;
                btn_Agregar.Visible = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;

                rdb_Agregar.Checked = false;
                rdb_Eliminar.Checked = false;

                fLimpiarCamposArticulos();
            }

            if (rdb_Eliminar.Checked == true) {

                txt_iduarticulo.Enabled = true;
                txt_Marca.Enabled = false;
                txt_Modelo.Enabled = false;
                txt_nombre.Enabled = false;
                txt_Precio.Enabled = false;
                txt_Stock.Enabled = false;

                btn_Consultar.Visible = true;
                btn_ConsultarClick = false;
                btn_Agregar.Visible = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;

                rdb_Agregar.Checked = false;
                rdb_Modificar.Checked = false;

                fLimpiarCamposArticulos();
            }
        }

        #endregion

        public void fLimpiarCamposArticulos()
        {
            txt_iduarticulo.Text = "";
            txt_Marca.Text = "";
            txt_Modelo.Text = "";
            txt_nombre.Text = "";
            txt_Precio.Text = "";
            txt_Stock.Text = "";
        }


        private void rdb_Agregar_CheckedChanged(object sender, EventArgs e)
        {
            fHabilitarAtributosRdb();
        }

        private void rdb_Modificar_CheckedChanged(object sender, EventArgs e)
        {
            fHabilitarAtributosRdb();
        }

        private void rdb_Eliminar_CheckedChanged(object sender, EventArgs e)
        {
            fHabilitarAtributosRdb();
        }

        private void txt_precio_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(txt_Precio.Text, @"^\d{1,14}(?:\.\d{0,2}){0,1}$"))
            {
                txt_Precio.Text = string.Empty;
            }
        }


        private void txt_iduarticulo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_iduarticulo.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo Numeros");
                txt_iduarticulo.Text = string.Empty;
            }
        }

        private void txt_Stock_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_Stock.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo Numeros");
                txt_Stock.Text = string.Empty;
            }
        }

        private void btn_ArticulosRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAbcExhibicion formexhibicion = new FrmAbcExhibicion();
            formexhibicion.StartPosition = FormStartPosition.CenterScreen;
            formexhibicion.ShowDialog(this);
            formexhibicion.Dispose();
            formexhibicion = null;
            this.Close();
        }
        

    }
}
