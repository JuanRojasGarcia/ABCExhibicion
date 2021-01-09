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
    public partial class FrmVentas : Form
    {

        SqlConnection con = new SqlConnection("Data Source=10.28.146.71;Initial Catalog=ComprasMuebles;User ID=sysdesarrollo;Password=fl9s9FKLGJUT5YAoqtJFTn9MtQgVo9Zn");
        SqlCommand cmd;
        SqlDataAdapter adapt;

        //Variables bool para Cambiar los atributos de los controls 
        public bool btn_AgregarClick = false;
        public bool btn_ModificarClick = false;
        public bool btn_EliminarClick = false;
        public bool btn_ConsultarClick = false;

        public bool btn_AgregarArticuloClick = false;
        decimal dTasaFinanciamiento {get; set;}
        int  iPlazoMaximo { get; set;}
        int iEnganchePorcentaje {get; set;}

        decimal dImporte {get; set;}
        decimal dEnganche {get; set;}
        decimal dBonificacionEnganche {get; set;}
        decimal dTotalAdeudo {get;set;}
        decimal dTotalAPagar {get;set;}
        decimal dPrecioAlContado {get;set;}
        decimal dImporteAbono {get;set;}
        decimal dImporteAhorra { get; set; }
        Boolean bDttrue {get;set;}
        DateTime dtFechaHoy { get; set; }
        decimal dPrecio { get; set; }


        public FrmVentas()
        {
            InitializeComponent();
            fObtenerArticulos();
            fObtenerClientes();
            fObtenerConfiguracion();
            fConfiguracionControles();
        }

        private void FrmVentas_Load(object sender, EventArgs e)
        {


        }

        private void cmb_VentaCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("proc_ventas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iVentaid", 0);
            cmd.Parameters.AddWithValue("@iClienteid", cmb_VentaCliente.Text);
            cmd.Parameters.AddWithValue("@cClienteNombre", 0);
            cmd.Parameters.AddWithValue("@cArticuloNombre", "");
            cmd.Parameters.AddWithValue("@iArticuloid", 0);
            cmd.Parameters.AddWithValue("@iTotalVenta", 0);
            cmd.Parameters.AddWithValue("@iFechaVenta", 0);
            cmd.Parameters.AddWithValue("@iOpcion", 8);

            //string str = (string)cmb_VentaCliente.Items[1];
            //MessageBox.Show(str);

            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            lbl_VentasRFCResult.Text = reader["rfc_empleado"].ToString();
  
            con.Close();
      
        }

        private void btn_AgregarArticulo_Click(object sender, EventArgs e)
        {
            btn_AgregarArticuloClick = true;
            fAgregarArticuloData();
        }

        private void btn_VentasCancelar_Click(object sender, EventArgs e)
        {
            cmb_VentaCliente.Enabled = true; ;
            cmb_VentaArticulo.Enabled = true;
            btn_AgregarArticulo.Enabled = true;
            btn_VentasSiguente.Visible = true;
            btn_VentasGrabar.Visible = false;
            lbl_VentasAbonosMensuales.Visible = false;

            cmb_VentaCliente.Text = "";
            cmb_VentaArticulo.Text = "";
            lbl_VentasRFCResult.Text = "";
            txt_VentaBoniEng.Text = "";
            txt_VentasEnganche.Text = "";
            txt_VentaTotal.Text = "";

            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
 
        }

        public void fObtenerArticulos()
        {

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
            cmd.Parameters.AddWithValue("@iOpcion", 7);

            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                cmb_VentaArticulo.Items.Add(reader[0].ToString());
                cmd.Parameters.Clear();
            }     
            con.Close();

        }

        public void fObtenerClientes()
        {
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
            cmd.Parameters.AddWithValue("@iOpcion", 6);

            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                cmb_VentaCliente.Items.Add(reader[0].ToString());
                cmd.Parameters.Clear();

            }     
            con.Close();

        }

        public void fObtenerConfiguracion()
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
            cmd.Parameters.AddWithValue("@iOpcion", 10);

           cmd.ExecuteNonQuery();
           SqlDataReader reader = cmd.ExecuteReader();
           reader.Read(); 

           dTasaFinanciamiento = Convert.ToDecimal(reader["num_tasafinanciamiento"].ToString());
           iPlazoMaximo = Convert.ToInt32(reader["num_plazomaximo"].ToString());
           iEnganchePorcentaje = Convert.ToInt32(reader["num_enganche"].ToString());

           cmd.Parameters.Clear();
           con.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dataGridView1.CurrentCell = dataGridView1.CurrentRow.Cells["Cantidad"];
            dataGridView1.BeginEdit(true);
           
        }

        private void fAgregarArticuloData() {
            con.Open();
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            cmd = new SqlCommand("proc_ventas", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@iVentaid", 0);
            cmd.Parameters.AddWithValue("@iClienteid", 0);
            cmd.Parameters.AddWithValue("@cClienteNombre", "");
            cmd.Parameters.AddWithValue("@cArticuloNombre", cmb_VentaArticulo.Text);
            cmd.Parameters.AddWithValue("@iArticuloid", 0);
            cmd.Parameters.AddWithValue("@iTotalVenta", 0);
            cmd.Parameters.AddWithValue("@iFechaVenta", 0);
            cmd.Parameters.AddWithValue("@iOpcion", 9);

            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();

            dt.Columns.Add("Descripcion Articulo");
            dt.Columns.Add("Modelo");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Importe");

            dPrecio = Convert.ToDecimal(reader["num_preciounitario"]) * (1 + (dTasaFinanciamiento * iPlazoMaximo) / 100);

            dr[0] = reader["des_articulo"].ToString();

            dr[1] = reader["des_modelo"].ToString();
            dr[2] = 2;
            dr[3] = Math.Round( dPrecio,2);
            dImporte = Convert.ToDecimal(dr[3]) * Convert.ToInt32(dr[2]);
            dr[4] = Math.Round(dImporte,2);

            dEnganche = Convert.ToDecimal((iEnganchePorcentaje * 0.01)) * dImporte;
            dBonificacionEnganche = dEnganche * ((dTasaFinanciamiento * iPlazoMaximo) / 100);
            dTotalAdeudo = dImporte - dEnganche -dBonificacionEnganche;
            dPrecioAlContado = dTotalAdeudo / (1 + ((dTasaFinanciamiento * iPlazoMaximo) / 100));

            txt_VentasEnganche.Text = Convert.ToString(Math.Round( dEnganche,2));
            txt_VentaBoniEng.Text = Convert.ToString(Math.Round(dBonificacionEnganche,2));
            txt_VentaTotal.Text = Convert.ToString(Math.Round(dTotalAdeudo,2));

            dt.Rows.Add(dr);
            dataGridView1.DataSource = dt;
            cmd.Parameters.Clear();


            con.Close();
        }

        public void fConfiguracionControles(){
            lbl_VentasAbonosMensuales.Visible = false;
            dataGridView2.Visible = false;
            btn_VentasGrabar.Visible = false;

        }

        private void btn_VentasSiguente_Click(object sender, EventArgs e)
        {
            if(cmb_VentaCliente.Text != "" && cmb_VentaArticulo.Text != "" && btn_AgregarArticuloClick == true){
                cmb_VentaCliente.Enabled = false;;
                cmb_VentaArticulo.Enabled = false;
                btn_AgregarArticulo.Enabled = false;
                btn_VentasSiguente.Visible = false;

                lbl_VentasAbonosMensuales.Visible = true;
                dataGridView2.Visible = true;         
                String sAbonos = "Abonos de";
                String sTotalAPagar = "Total A Pagar";
                String sSeAhorra = "Se Ahorra";

                DataTable dt = new DataTable();
                DataRow dr = dt.NewRow();

                dt.Columns.Add("Periodo de Abonos");
                dt.Columns.Add("Importe Abono");
                dt.Columns.Add("Total a Pagar");
                dt.Columns.Add("Se ahorra");
                dt.Columns.Add("Elegir", typeof(Boolean));

                for (int i = 3; i <= iPlazoMaximo; i += 3){              
    
                    dTotalAPagar = dPrecioAlContado * (1 + (dTasaFinanciamiento * i) / 100);
                    dImporteAbono = dTotalAPagar / i;
                    dImporteAhorra = dTotalAdeudo - dTotalAPagar;

                    dr[0] = i + " " + sAbonos ;
                    dr[1] = Math.Round(dImporteAbono,2);
                    dr[2] = sTotalAPagar + " " + Math.Round(dTotalAPagar,2);
                    dr[3] = sSeAhorra + " " + Math.Round(dImporteAhorra,2);

                    if(i == 3 ){
                        dr[4] = false;
                    }
                    

                    dt.Rows.Add(dr.ItemArray);               

                }

                    bDttrue = Convert.ToBoolean( dr[4]);
                    

                dataGridView2.DataSource = dt;

                btn_VentasGrabar.Visible = true;

            }else{
                MessageBox.Show("Selecciona un Cliente y Agrege un Articulo");
            }

        }


        private void btn_VentasGrabar_Click(object sender, EventArgs e)
        {
            dtFechaHoy = Convert.ToDateTime( DateTime.Now.ToString("d-M-yyyy"));            
            if (bDttrue == false)
            {
                con.Open();
                cmd = new SqlCommand("proc_ventas", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iVentaid", 0);
                cmd.Parameters.AddWithValue("@iClienteid", cmb_VentaCliente.Text);
                cmd.Parameters.AddWithValue("@cClienteNombre", "");
                cmd.Parameters.AddWithValue("@cArticuloNombre", "");
                cmd.Parameters.AddWithValue("@iArticuloid", 0);
                cmd.Parameters.AddWithValue("@iTotalVenta", txt_VentaTotal.Text);
                cmd.Parameters.AddWithValue("@iFechaVenta", dtFechaHoy);
                cmd.Parameters.AddWithValue("@iOpcion", 1);
                
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                cmd.Parameters.Clear();
                con.Close();

                    
                MessageBox.Show("Se ha Generado la Venta");

                this.Hide();
                FrmAbcExhibicion formexhibicion = new FrmAbcExhibicion();
                formexhibicion.StartPosition = FormStartPosition.CenterScreen;
                formexhibicion.ShowDialog(this);
                formexhibicion.Dispose();
                formexhibicion = null;
                this.Close();
            }


        }

        private void btn_VentasREgresar_Click(object sender, EventArgs e)
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
