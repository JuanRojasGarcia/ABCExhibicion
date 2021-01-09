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
    public partial class FrmAbcExhibicion : Form
    {

        
        SqlConnection con = new SqlConnection("Data Source=10.28.146.71;Initial Catalog=ComprasMuebles;User ID=sysdesarrollo;Password=fl9s9FKLGJUT5YAoqtJFTn9MtQgVo9Zn");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        //Variables bool para Cambiar los atributos de los controls 
        public bool btn_AgregarClick = false;
        public bool btn_ModificarClick = false;
        public bool btn_EliminarClick = false;
        public bool btn_ConsultarClick = false;
        
        public FrmAbcExhibicion()
        {

            InitializeComponent();
            fMostrarVentas();
            fConfiguracionControles();
            fObtenerTotalArticulos();
            fObtenerTotalCentros();
            fObtenerTotalClientes();
            fObtenerTotalVentas();
        
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmArticulos formArticulos = new FrmArticulos();
            formArticulos.StartPosition = FormStartPosition.CenterScreen;
            formArticulos.ShowDialog(this);
            formArticulos.Dispose();
            formArticulos = null;
            this.Close();
        }

        private void FrmAbcExhibicion_Load(object sender, EventArgs e)
        {
            
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            FrmConfiguracion formConfiguracion = new FrmConfiguracion();
            formConfiguracion.StartPosition = FormStartPosition.CenterScreen;
            formConfiguracion.ShowDialog(this);
            formConfiguracion.Dispose();
            formConfiguracion = null;
            this.Close();
        }

        private void centrosToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            FrmCentros formCentros = new FrmCentros();
            formCentros.StartPosition = FormStartPosition.CenterScreen;
            formCentros.ShowDialog(this);
            formCentros.Dispose();
            formCentros = null;
            this.Close();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            FrmCliente formClientes = new FrmCliente();
            formClientes.StartPosition = FormStartPosition.CenterScreen;
            formClientes.ShowDialog(this);
            formClientes.Dispose();
            formClientes = null;
            this.Close();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.Hide();
            FrmVentas formVentas = new FrmVentas();
            formVentas.StartPosition = FormStartPosition.CenterScreen;
            formVentas.ShowDialog(this);
            formVentas.Dispose();
            formVentas = null;
            this.Close();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {

            if (txt_Codigo.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_ventas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iVentaid", txt_Codigo.Text);
                cmd.Parameters.AddWithValue("@iClienteid", txt_Cliente.Text);
                cmd.Parameters.AddWithValue("@cClienteNombre", "");
                cmd.Parameters.AddWithValue("@cArticuloNombre", "");
                cmd.Parameters.AddWithValue("@iArticuloid", 0);
                cmd.Parameters.AddWithValue("@iTotalVenta", txt_TotalVenta.Text);
                cmd.Parameters.AddWithValue("@iFechaVenta", Convert.ToDateTime( txt_FechaVenta.Text));
                cmd.Parameters.AddWithValue("@iOpcion", 2);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

                btn_ModificarClick = true;

                fLimpiarCamposVentas();
                fMostrarVentas();
                fAtributosModificarEliminar();
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Cliente");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (txt_Codigo.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_ventas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iVentaid", txt_Codigo.Text);
                cmd.Parameters.AddWithValue("@iClienteid", 0);
                cmd.Parameters.AddWithValue("@cClienteNombre", "");
                cmd.Parameters.AddWithValue("@cArticuloNombre", "");
                cmd.Parameters.AddWithValue("@iArticuloid", 0);
                cmd.Parameters.AddWithValue("@iTotalVenta", 0);
                cmd.Parameters.AddWithValue("@iFechaVenta", 0);
                cmd.Parameters.AddWithValue("@iOpcion", 3);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

                btn_EliminarClick = true;

                fLimpiarCamposVentas();
                fMostrarVentas();
                fAtributosModificarEliminar();
                fObtenerTotalVentas();
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Cliente");
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {

            if (txt_Codigo.Text != "")
            {

                con.Open();
                cmd = new SqlCommand("proc_ventas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iVentaid", txt_Codigo.Text);
                cmd.Parameters.AddWithValue("@iClienteid", 0);
                cmd.Parameters.AddWithValue("@cClienteNombre", "");
                cmd.Parameters.AddWithValue("@cArticuloNombre", "");
                cmd.Parameters.AddWithValue("@iArticuloid", 0);
                cmd.Parameters.AddWithValue("@iTotalVenta", 0);
                cmd.Parameters.AddWithValue("@iFechaVenta", 0);
                cmd.Parameters.AddWithValue("@iOpcion", 4);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {                    
                    txt_Cliente.Text = reader[1].ToString();
                    txt_TotalVenta.Text = reader[2].ToString();
                    txt_FechaVenta.Text = reader[3].ToString();                    

                    cmd.Parameters.Clear();
                    con.Close();

                    btn_ConsultarClick = true;

                }
                else
                {
                    MessageBox.Show("Codigo Venta no Existe");
                    btn_ConsultarClick = false;

                }
                con.Close();


            }
            else
            {
                MessageBox.Show("Ingrese el Codigo de la Venta");
            }

            fAtributosConsultar();
        }


        public void fMostrarVentas()
        {
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("proc_ventas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iVentaid", 0);
            cmd.Parameters.AddWithValue("@iClienteid", 0);
            cmd.Parameters.AddWithValue("@cClienteNombre", "");
            cmd.Parameters.AddWithValue("@cArticuloNombre", "");
            cmd.Parameters.AddWithValue("@iArticuloid", 0);
            cmd.Parameters.AddWithValue("@iTotalVenta", 0);
            cmd.Parameters.AddWithValue("@iFechaVenta", 0);
            cmd.Parameters.AddWithValue("@iOpcion", 5);
            cmd.ExecuteNonQuery();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.Parameters.Clear();
            con.Close();
        }


        #region Funciones Para Modificar Los Atributos de Los Controles

        public void fConfiguracionControles()
        {
            txt_Cliente.Enabled = false;
            txt_Codigo.Enabled = false;
            txt_FechaVenta.Enabled = false;
            txt_TotalVenta.Enabled = false;

            btn_Consultar.Visible = false;
            btn_Eliminar.Visible = false;
            btn_Modificar.Visible = false;


        }

        public void fAtributosConsultar()
        {
            if (btn_ConsultarClick == true && rdb_Modificar.Checked == true)
            {
                txt_Cliente.Enabled = true;
                txt_Codigo.Enabled = true;
                txt_FechaVenta.Enabled = true;
                txt_TotalVenta.Enabled = true;

                btn_Modificar.Visible = true;
            }
            if (btn_ConsultarClick == true && rdb_Eliminar.Checked == true)
            {
                txt_Cliente.Enabled = false;
                txt_Codigo.Enabled = false;
                txt_FechaVenta.Enabled = false;
                txt_TotalVenta.Enabled = false;

                btn_Eliminar.Visible = true;
            }
        }

        public void fAtributosModificarEliminar()
        {
            if (btn_ModificarClick == true)
            {

                txt_Codigo.Enabled = true;
                txt_Cliente.Enabled = false;
                txt_FechaVenta.Enabled = false;
                txt_TotalVenta.Enabled = false;


                btn_Modificar.Visible = false;
                btn_Consultar.Visible = true;
            }

            if (btn_EliminarClick == true)
            {
                txt_Codigo.Enabled = true;
                txt_Cliente.Enabled = false;
                txt_FechaVenta.Enabled = false;
                txt_TotalVenta.Enabled = false;

                btn_Consultar.Visible = true;
                btn_Eliminar.Visible = false;
            }
        }

        public void fHabilitarAtributosRdb()
        {

            if (rdb_Modificar.Checked == true)
            {
                txt_Codigo.Enabled = true;
                txt_Cliente.Enabled = false;
                txt_FechaVenta.Enabled = false;
                txt_TotalVenta.Enabled = false;

                btn_Consultar.Visible = true;
                btn_ConsultarClick = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;


                rdb_Eliminar.Checked = false;

                fLimpiarCamposVentas();
            }

            if (rdb_Eliminar.Checked == true)
            {

                txt_Codigo.Enabled = true;
                txt_Cliente.Enabled = false;
                txt_FechaVenta.Enabled = false;
                txt_TotalVenta.Enabled = false;


                btn_Consultar.Visible = true;
                btn_ConsultarClick = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;

                rdb_Modificar.Checked = false;

                fLimpiarCamposVentas();
            }
        }

        #endregion

        public void fLimpiarCamposVentas()
        {
            txt_Cliente.Text = "";
            txt_Codigo.Text = "";
            txt_FechaVenta.Text = "";
            txt_TotalVenta.Text = "";

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

        public void fObtenerTotalArticulos(){
            con.Open();
            cmd = new SqlCommand("proc_abcarticulos", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iArticuloid", 0);
            cmd.Parameters.AddWithValue("@cArticuloNom", "");
            cmd.Parameters.AddWithValue("@cArticuloModelo", "");
            cmd.Parameters.AddWithValue("@cArticuloMarca", "");
            cmd.Parameters.AddWithValue("@dArticuloPrecio", 0);
            cmd.Parameters.AddWithValue("@iArticuloExistencia", 0);
            cmd.Parameters.AddWithValue("@iOpcion", 6);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();                    
            lbl_TAR.Text = reader["total"].ToString();

            cmd.Parameters.Clear();
            con.Close();
        }

        public void fObtenerTotalCentros(){
            con.Open();
            cmd = new SqlCommand("proc_abcentros", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iCentroid", 0);
            cmd.Parameters.AddWithValue("@cCentroNom", "");
            cmd.Parameters.AddWithValue("@iOpcion", 6);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();                    
            lbl_TCE.Text = reader["total"].ToString();

            cmd.Parameters.Clear();
            con.Close();
        }

        public void fObtenerTotalClientes(){
            con.Open();
            cmd = new SqlCommand("proc_abclientes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iClienteid", 0);
            cmd.Parameters.AddWithValue("@cCentroNum", 0);
            cmd.Parameters.AddWithValue("@cClienteNom", "");
            cmd.Parameters.AddWithValue("@cClienteApell", "");
            cmd.Parameters.AddWithValue("@cClienteRfc", "");
            cmd.Parameters.AddWithValue("@iOpcion", 7);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();                    
            lbl_TCL.Text = reader["total"].ToString();

            cmd.Parameters.Clear();
            con.Close();
        }

        public void fObtenerTotalVentas(){
            con.Open();
            cmd = new SqlCommand("proc_ventas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iVentaid", 0);
            cmd.Parameters.AddWithValue("@iClienteid", 0);
            cmd.Parameters.AddWithValue("@cClienteNombre", "");
            cmd.Parameters.AddWithValue("@cArticuloNombre", "");
            cmd.Parameters.AddWithValue("@iArticuloid", 0);
            cmd.Parameters.AddWithValue("@iTotalVenta", 0);
            cmd.Parameters.AddWithValue("@iFechaVenta", 0);
            cmd.Parameters.AddWithValue("@iOpcion", 11);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();                    
            lbl_TVE.Text = reader["total"].ToString();

            cmd.Parameters.Clear();
            con.Close();
        }

        private void txt_Codigo_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_Codigo.Text, "[^0-9]"))
                {
                    MessageBox.Show("Solo Numeros");
                    txt_Codigo.Text = string.Empty;
                }
        }
    
    }
}
