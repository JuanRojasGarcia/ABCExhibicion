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
    public partial class FrmConfiguracion : Form
    {
        SqlConnection con = new SqlConnection("Data Source=10.28.146.71;Initial Catalog=ComprasMuebles;User ID=sysdesarrollo;Password=fl9s9FKLGJUT5YAoqtJFTn9MtQgVo9Zn");
        SqlCommand cmd;


        public FrmConfiguracion()
        {
            InitializeComponent();
            fObtenerConfiguracion();
            fConfiguracionControles();
        }

        
        public void fObtenerConfiguracion()
        {

            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("proc_abconfiguracion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iConfid", 1);
            cmd.Parameters.AddWithValue("@iConfTasaFinanciamiento", 0);
            cmd.Parameters.AddWithValue("@iConfEnganche", 0);
            cmd.Parameters.AddWithValue("@iConfPlazoMaximo", 0);
            cmd.Parameters.AddWithValue("@iOpcion", 2);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
       
            txt_tasaFinanciamiento.Text = reader["num_tasafinanciamiento"].ToString();
            txt_Enganche.Text = reader["num_enganche"].ToString();
            lbl_ConfPlazoActual.Text = reader["num_plazomaximo"].ToString();
            
            cmd.Parameters.Clear();
            con.Close();
        }

        public void fConfiguracionControles()
        {
            txt_tasaFinanciamiento.Enabled = false;
            txt_Enganche.Enabled = false;
                      
        }

        private void btn_ModificarConf_Click(object sender, EventArgs e)
        {



            if (txt_PlazoMaximo.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_abconfiguracion", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iConfid", 1);
                cmd.Parameters.AddWithValue("@iConfTasaFinanciamiento", 0);
                cmd.Parameters.AddWithValue("@iConfEnganche", 0);
                cmd.Parameters.AddWithValue("@iConfPlazoMaximo", txt_PlazoMaximo.Text);
                cmd.Parameters.AddWithValue("@iOpcion", 1);
                cmd.ExecuteNonQuery();
                
                txt_PlazoMaximo.Text = "";
                cmd.Parameters.Clear();
                con.Close();

                fActualizarPlazoMAximo();




            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Articulo");
            }
        }

        public void fActualizarPlazoMAximo()
        {
            con.Open();
            cmd = new SqlCommand("proc_abconfiguracion", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iConfid", 1);
            cmd.Parameters.AddWithValue("@iConfTasaFinanciamiento", 0);
            cmd.Parameters.AddWithValue("@iConfEnganche", 0);
            cmd.Parameters.AddWithValue("@iConfPlazoMaximo", 0);
            cmd.Parameters.AddWithValue("@iOpcion", 3);

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            lbl_ConfPlazoActual.Text = reader["num_plazomaximo"].ToString();
            
            cmd.Parameters.Clear();
            con.Close();
        }

        private void txt_PlazoMaximo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_PlazoMaximo.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo Numeros");
                txt_PlazoMaximo.Text = string.Empty;
            }
        }

        private void btn_ConfiguracionRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAbcExhibicion formexhibicion = new FrmAbcExhibicion();
            formexhibicion.StartPosition = FormStartPosition.CenterScreen;
            formexhibicion.ShowDialog(this);
            formexhibicion.Dispose();
            formexhibicion = null;
            this.Close();
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {

        }


    }
}
