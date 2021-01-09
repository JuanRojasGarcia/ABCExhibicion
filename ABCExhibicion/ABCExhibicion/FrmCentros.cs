using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ABCExhibicion
{
    public partial class FrmCentros : Form
    {

        SqlConnection con = new SqlConnection("Data Source=10.28.146.71;Initial Catalog=ComprasMuebles;User ID=sysdesarrollo;Password=fl9s9FKLGJUT5YAoqtJFTn9MtQgVo9Zn");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        //Variables bool para Cambiar los atributos de los controls 
        public bool btn_AgregarClick = false;
        public bool btn_ModificarClick = false;
        public bool btn_EliminarClick = false;
        public bool btn_ConsultarClick = false;

        public void fMostrarCentros()
        {
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("proc_abcentros", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iCentroid", 0);
            cmd.Parameters.AddWithValue("@cCentroNom", "");
            cmd.Parameters.AddWithValue("@iOpcion", 5);
            cmd.ExecuteNonQuery();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.Parameters.Clear();
            con.Close();
        }

        public FrmCentros()
        {
            InitializeComponent();
            fMostrarCentros();
            fConfiguracionControles();          
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {            

            if (txt_CenNum.Text != "" && txt_CentroNom.Text != "" )
                {
                                                
                    con.Open();
                    cmd = new SqlCommand("proc_abcentros", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iCentroid", txt_CenNum.Text);
                    cmd.Parameters.AddWithValue("@cCentroNom", txt_CentroNom.Text);
                    cmd.Parameters.AddWithValue("@iOpcion", 1);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                        if(Convert.ToInt32(reader["Error"]) == 1){
                            MessageBox.Show("Codigo Centro Existente");
                            con.Close();
                        }else{
                            cmd.Parameters.Clear();
                            con.Close();

                            btn_AgregarClick = true;
                
                            fLimpiarCamposCentros();
                            fMostrarCentros();  
                        }                              
                            
                }
                else {
                    MessageBox.Show("Ingrese todos los atributos");
                }
                       
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {            

            if (txt_CenNum.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_abcentros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iCentroid", txt_CenNum.Text);
                cmd.Parameters.AddWithValue("@cCentroNom", txt_CentroNom.Text);
                cmd.Parameters.AddWithValue("@iOpcion", 2);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

                btn_ModificarClick = true;

                fLimpiarCamposCentros();
                fMostrarCentros();
                fAtributosModificarEliminar();
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Centro");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (txt_CenNum.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_abcentros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iCentroid", txt_CenNum.Text);
                cmd.Parameters.AddWithValue("@cCentroNom", "");
                cmd.Parameters.AddWithValue("@iOpcion", 3);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

                btn_EliminarClick = true;

                fLimpiarCamposCentros();
                fMostrarCentros();
                fAtributosModificarEliminar();
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Centro");
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {

            if (txt_CenNum.Text != "") {

                con.Open();
                cmd = new SqlCommand("proc_abcentros", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iCentroid", txt_CenNum.Text);
                cmd.Parameters.AddWithValue("@cCentroNom", "");
                cmd.Parameters.AddWithValue("@iOpcion", 4);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txt_CentroNom.Text = reader[1].ToString();


                        cmd.Parameters.Clear();
                        con.Close();

                        btn_ConsultarClick = true;
 
                    }else {
                        MessageBox.Show("Codigo Centro no Existe");
                        btn_ConsultarClick = false;
                        
                    }
                    con.Close();
                
                   
            }else{
                MessageBox.Show("Ingrese el Codigo del Centro");
            }

            fAtributosConsultar();
        }

        #region Funciones Para Modificar Los Atributos de Los Controles

        public void fConfiguracionControles()
        {
            txt_CentroNom.Enabled = false;
            txt_CenNum.Enabled = false;

            btn_Agregar.Visible = false;
            btn_Consultar.Visible = false;
            btn_Eliminar.Visible = false;
            btn_Modificar.Visible = false;
      
        }

        public void fAtributosConsultar()
        {                       
            if (btn_ConsultarClick == true && rdb_ModificarCentro.Checked == true)
            {
                txt_CenNum.Enabled = true;
                txt_CentroNom.Enabled = true;


                btn_Modificar.Visible = true;
            }
            if (btn_ConsultarClick == true && rdb_EliminarCentro.Checked == true)
            {
                txt_CentroNom.Enabled = false;

                btn_Eliminar.Visible = true;
            }
        }

        public void fAtributosModificarEliminar()
        {
            if (btn_ModificarClick == true)
            {

                txt_CenNum.Enabled = true;
                txt_CentroNom.Enabled = false;

                btn_Modificar.Visible = false;
                btn_Consultar.Visible = true;
            }

            if (btn_EliminarClick == true)
            {
                txt_CenNum.Enabled = true;
                txt_CentroNom.Enabled = false;

                btn_Consultar.Visible = true;
                btn_Eliminar.Visible = false;
            }        
        }

        public void fHabilitarAtributosRdb()
        {

            if (rdb_AgregarCentro.Checked == true)
            {
                txt_CenNum.Enabled = true;
                txt_CentroNom.Enabled = true;


                btn_Agregar.Visible = true;
                btn_Consultar.Visible = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;

                rdb_EliminarCentro.Checked = false;
                rdb_ModificarCentro.Checked = false;

                fLimpiarCamposCentros();

            }

            if (rdb_ModificarCentro.Checked == true)
            {
                txt_CenNum.Enabled = true;
                txt_CentroNom.Enabled = false;

                btn_Consultar.Visible = true;
                btn_ConsultarClick = false;
                btn_Agregar.Visible = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;

                rdb_AgregarCentro.Checked = false;
                rdb_EliminarCentro.Checked = false;

                fLimpiarCamposCentros();
            }

            if (rdb_EliminarCentro.Checked == true) {

                txt_CenNum.Enabled = true;
                txt_CentroNom.Enabled = false;


                btn_Consultar.Visible = true;
                btn_ConsultarClick = false;
                btn_Agregar.Visible = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;

                rdb_AgregarCentro.Checked = false;
                rdb_ModificarCentro.Checked = false;

                fLimpiarCamposCentros();
            }
        }

        #endregion

        public void fLimpiarCamposCentros()
        {
            txt_CenNum.Text = "";
            txt_CentroNom.Text = "";
        }

        private void rdb_AgregarCentro_CheckedChanged(object sender, EventArgs e)
        {
            fHabilitarAtributosRdb();
        }

        private void rdb_ModificarCentro_CheckedChanged(object sender, EventArgs e)
        {
            fHabilitarAtributosRdb();
        }

        private void rdb_EliminarCentro_CheckedChanged(object sender, EventArgs e)
        {
            fHabilitarAtributosRdb();
        }
        

        private void txt_CenNum_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_CenNum.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo Numeros");
                txt_CenNum.Text = string.Empty;
            }
        }

        private void FrmCentros_Load(object sender, EventArgs e)
        {
            fConfiguracionControles();  
        }

        private void btn_CentrosRegresar_Click(object sender, EventArgs e)
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

