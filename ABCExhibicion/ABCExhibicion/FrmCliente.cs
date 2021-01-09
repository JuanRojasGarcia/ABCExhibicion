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
    public partial class FrmCliente : Form
    {

        SqlConnection con = new SqlConnection("Data Source=10.28.146.71;Initial Catalog=ComprasMuebles;User ID=sysdesarrollo;Password=fl9s9FKLGJUT5YAoqtJFTn9MtQgVo9Zn");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        //Variables bool para Cambiar los atributos de los controls 
        public bool btn_AgregarClick = false;
        public bool btn_ModificarClick = false;
        public bool btn_EliminarClick = false;
        public bool btn_ConsultarClick = false;


        public FrmCliente()
        {
            InitializeComponent();
            fMostrarClientes();
            fConfiguracionControles();
            fObtenerCentros();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {

            if (txt_ClienteNum.Text != "" && cmb_CentroNum.Text != "" && txt_ClienteNom.Text != "" && txt_ClienteApellido.Text != "" && txt_ClienteRFC.Text != "")
            {

                con.Open();
                cmd = new SqlCommand("proc_abclientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iClienteid", txt_ClienteNum.Text);
                cmd.Parameters.AddWithValue("@cCentroNum", cmb_CentroNum.Text);
                cmd.Parameters.AddWithValue("@cClienteNom", txt_ClienteNom.Text);
                cmd.Parameters.AddWithValue("@cClienteApell", txt_ClienteApellido.Text);
                cmd.Parameters.AddWithValue("@cClienteRfc", txt_ClienteRFC.Text);
                cmd.Parameters.AddWithValue("@iOpcion", 1);

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                if (Convert.ToInt32(reader["Error"]) == 1 )
                {
                    MessageBox.Show("Codigo Cliente Existente");
                    con.Close();
                }
                else
                {
                    cmd.Parameters.Clear();
                    con.Close();

                    btn_AgregarClick = true;

                    fLimpiarCamposArticulos();
                    fMostrarClientes();
                }

            }
            else
            {
                MessageBox.Show("Ingrese todos los Clientes");
            }

        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {

            if (txt_ClienteNum.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_abclientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iClienteid", txt_ClienteNum.Text);
                cmd.Parameters.AddWithValue("@cCentroNum", cmb_CentroNum.Text);
                cmd.Parameters.AddWithValue("@cClienteNom", txt_ClienteNom.Text);
                cmd.Parameters.AddWithValue("@cClienteApell", txt_ClienteApellido.Text);
                cmd.Parameters.AddWithValue("@cClienteRfc", txt_ClienteRFC.Text);
                cmd.Parameters.AddWithValue("@iOpcion", 2);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

                btn_ModificarClick = true;

                fLimpiarCamposArticulos();
                fMostrarClientes();
                fAtributosModificarEliminar();
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Cliente");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (txt_ClienteNum.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("proc_abclientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iClienteid", txt_ClienteNum.Text);
                cmd.Parameters.AddWithValue("@cCentroNum", 0);
                cmd.Parameters.AddWithValue("@cClienteNom", "");
                cmd.Parameters.AddWithValue("@cClienteApell", "");
                cmd.Parameters.AddWithValue("@cClienteRfc", "");
                cmd.Parameters.AddWithValue("@iOpcion", 3);
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                con.Close();

                btn_EliminarClick = true;

                fLimpiarCamposArticulos();
                fMostrarClientes();
                fAtributosModificarEliminar();
            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Cliente");
            }
        }

        private void btn_Consultar_Click(object sender, EventArgs e)
        {


            if (txt_ClienteNum.Text != "")
            {

                con.Open();
                cmd = new SqlCommand("proc_abclientes", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iClienteid", txt_ClienteNum.Text);
                cmd.Parameters.AddWithValue("@cCentroNum", 0);
                cmd.Parameters.AddWithValue("@cClienteNom", "");
                cmd.Parameters.AddWithValue("@cClienteApell", "");
                cmd.Parameters.AddWithValue("@cClienteRfc", "");
                cmd.Parameters.AddWithValue("@iOpcion", 4);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    cmb_CentroNum.Text = reader[1].ToString();
                    txt_ClienteNom.Text = reader[2].ToString();
                    txt_ClienteApellido.Text = reader[3].ToString();
                    txt_ClienteRFC.Text = reader[4].ToString();
                    

                    cmd.Parameters.Clear();
                    con.Close();

                    btn_ConsultarClick = true;

                }
                else
                {
                    MessageBox.Show("Codigo Cliente no Existe");
                    btn_ConsultarClick = false;

                }
                con.Close();


            }
            else
            {
                MessageBox.Show("Ingrese el Codigo del Cliente");
            }

            fAtributosConsultar();
        }


        public void fMostrarClientes()
        {
            con.Open();
            DataTable dt = new DataTable();
            cmd = new SqlCommand("proc_abclientes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iClienteid", 0);
            cmd.Parameters.AddWithValue("@cCentroNum", 0);
            cmd.Parameters.AddWithValue("@cClienteNom", "");
            cmd.Parameters.AddWithValue("@cClienteApell", "");
            cmd.Parameters.AddWithValue("@cClienteRfc", "");
            cmd.Parameters.AddWithValue("@iOpcion", 5);
            cmd.ExecuteNonQuery();
            adapt = new SqlDataAdapter(cmd);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.Parameters.Clear();
            con.Close();
        }

        public void fObtenerCentros()
        {
            con.Open();
            cmd = new SqlCommand("proc_abclientes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iClienteid", 0);
            cmd.Parameters.AddWithValue("@cCentroNum", 0);
            cmd.Parameters.AddWithValue("@cClienteNom", "");
            cmd.Parameters.AddWithValue("@cClienteApell", "");
            cmd.Parameters.AddWithValue("@cClienteRfc", "");
            cmd.Parameters.AddWithValue("@iOpcion", 6);

            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                cmb_CentroNum.Items.Add(reader[0]).ToString();
                cmd.Parameters.Clear();
            }     
            con.Close();

        }

        #region Funciones Para Modificar Los Atributos de Los Controles

        public void fConfiguracionControles()
        {
            txt_ClienteNum.Enabled = false;
            cmb_CentroNum.Enabled = false;
            txt_ClienteNom.Enabled = false;
            txt_ClienteApellido.Enabled = false;
            txt_ClienteRFC.Enabled = false;

            btn_Agregar.Visible = false;
            btn_Consultar.Visible = false;
            btn_Eliminar.Visible = false;
            btn_Modificar.Visible = false;

            cmb_CentroNum.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        public void fAtributosConsultar()
        {
            if (btn_ConsultarClick == true && rdb_Modificar.Checked == true)
            {
                txt_ClienteNum.Enabled = true;
                cmb_CentroNum.Enabled = true;
                txt_ClienteNom.Enabled = true;
                txt_ClienteApellido.Enabled = true;
                txt_ClienteRFC.Enabled = true;

                btn_Modificar.Visible = true;
            }
            if (btn_ConsultarClick == true && rdb_Eliminar.Checked == true)
            {
                txt_ClienteNum.Enabled = false;
                cmb_CentroNum.Enabled = false;
                txt_ClienteNom.Enabled = false;
                txt_ClienteApellido.Enabled = false;
                txt_ClienteRFC.Enabled = false;

                btn_Eliminar.Visible = true;
            }
        }

        public void fAtributosModificarEliminar()
        {
            if (btn_ModificarClick == true)
            {

                txt_ClienteNum.Enabled = true;
                cmb_CentroNum.Enabled = false;
                txt_ClienteNom.Enabled = false;
                txt_ClienteApellido.Enabled = false;
                txt_ClienteRFC.Enabled = false;

                btn_Modificar.Visible = false;
                btn_Consultar.Visible = true;
            }

            if (btn_EliminarClick == true)
            {
                txt_ClienteNum.Enabled = true;
                cmb_CentroNum.Enabled = false;
                txt_ClienteNom.Enabled = false;
                txt_ClienteApellido.Enabled = false;
                txt_ClienteRFC.Enabled = false;

                btn_Consultar.Visible = true;
                btn_Eliminar.Visible = false;
            }
        }

        public void fHabilitarAtributosRdb()
        {

            if (rdb_Agregar.Checked == true)
            {
                txt_ClienteNum.Enabled = true;
                cmb_CentroNum.Enabled = true;
                txt_ClienteNom.Enabled = true;
                txt_ClienteApellido.Enabled = true;
                txt_ClienteRFC.Enabled = true;

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
                txt_ClienteNum.Enabled = true;
                cmb_CentroNum.Enabled = false;
                txt_ClienteNom.Enabled = false;
                txt_ClienteApellido.Enabled = false;
                txt_ClienteRFC.Enabled = false;


                btn_Consultar.Visible = true;
                btn_ConsultarClick = false;
                btn_Agregar.Visible = false;
                btn_Eliminar.Visible = false;
                btn_Modificar.Visible = false;

                rdb_Agregar.Checked = false;
                rdb_Eliminar.Checked = false;

                fLimpiarCamposArticulos();
            }

            if (rdb_Eliminar.Checked == true)
            {

                txt_ClienteNum.Enabled = true;
                cmb_CentroNum.Enabled = false;
                txt_ClienteNom.Enabled = false;
                txt_ClienteApellido.Enabled = false;
                txt_ClienteRFC.Enabled = false;


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
            txt_ClienteNum.Text = "";
            cmb_CentroNum.SelectedIndex = -1;
            txt_ClienteNom.Text = "";
            txt_ClienteApellido.Text = "";
            txt_ClienteRFC.Text = "";

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

        private void txt_ClienteNum_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txt_ClienteNum.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo Numeros");
                txt_ClienteNum.Text = string.Empty;
            }
        }

        private void btn_ClienteRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmAbcExhibicion formexhibicion = new FrmAbcExhibicion();
            formexhibicion.StartPosition = FormStartPosition.CenterScreen;
            formexhibicion.ShowDialog(this);
            formexhibicion.Dispose();
            formexhibicion = null;
            this.Close();
        }

        private void cmb_CentroNum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }

}
