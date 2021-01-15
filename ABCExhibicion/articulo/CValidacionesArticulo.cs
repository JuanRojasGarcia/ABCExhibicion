using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data;

namespace ABCExhibicion
{
    public partial class FrmArticulos
    {
        public bool validarGrabar()
        {
            bool bRegresa = false;
            int iArticuloid;
            string sArticuloNom = "";
            string sMarca = "";
            string sModelo ="";
            decimal dPrecio = 0;
            int iExistencia = 0;

            iArticuloid = Convert.ToInt32(txt_iduarticulo.Text);
            sArticuloNom = txt_nombre.Text;
            sMarca = txt_Marca.Text;
            sModelo = txt_Modelo.Text;
            dPrecio =Convert.ToDecimal( txt_Precio.Text);
            iExistencia = Convert.ToInt32( txt_Stock.Text);

            bRegresa = CAccesoDatos.GrabarArticulo(iArticuloid, sArticuloNom, sModelo, sMarca, dPrecio,iExistencia);
            
            return bRegresa;
        }

        public bool validarModificar()
        {
            bool bRegresa = false;
            int iArticuloid;
            string sArticuloNom = "";
            string sMarca = "";
            string sModelo ="";
            decimal dPrecio = 0;
            int iExistencia = 0;

            iArticuloid = Convert.ToInt32(txt_iduarticulo.Text);
            sArticuloNom = txt_nombre.Text;
            sMarca = txt_Marca.Text;
            sModelo = txt_Modelo.Text;
            dPrecio =Convert.ToDecimal( txt_Precio.Text);
            iExistencia = Convert.ToInt32( txt_Stock.Text);


            bRegresa = CAccesoDatos.ModificarArticulo(iArticuloid, sArticuloNom, sModelo, sMarca, dPrecio, iExistencia);
            if(bRegresa){
                btn_ModificarClick = true;
                fLimpiarCampos();
                fAtributosModificarEliminar();

            }
            
            return bRegresa;
        }

        public bool validarBuscar(ref List<CArticulo> listaArticulos)
        {
            bool bRegresa = false;
            string sArticuloid = "";
            sArticuloid = txt_iduarticulo.Text;

            if(!string.IsNullOrEmpty(sArticuloid)){
                if(CAccesoDatos.BuscarArticulo(sArticuloid, ref listaArticulos)){
                    btn_ConsultarClick = true;
                    bRegresa = true;
                    fAtributosConsultar();
                }
                btn_ConsultarClick = false;

            }else{
                MessageBox.Show("Favor de capturar un numero", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bRegresa = false;
                btn_ConsultarClick = false;
                txt_iduarticulo.Focus();
            }


            return bRegresa;
        }

        public bool validarEliminar()
        {
            bool bRegresa = false;
            int sArticuloid = 0;

            sArticuloid = Convert.ToInt32(txt_iduarticulo.Text);

            if(MessageBox.Show("¿Desea Eliminar El Articulo: " + sArticuloid, "ABCExhibicion", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes){
                CAccesoDatos.EliminarLocacion(sArticuloid);
                bRegresa = true;
                btn_EliminarClick = true;
                fLimpiarCampos();
                fAtributosModificarEliminar();
            }
            
            return bRegresa;
        }

        // public bool ValidarNumeroLocacion()
        // {
        //     bool bRegresa = true;

        //     if (txt_LocacionNum.TextLength < 6 || txt_LocacionNum.TextLength > 6)
        //     {
        //         MessageBox.Show("El numero de Centro Menor o mayor a 6 digitos","ABC Empleados",MessageBoxButtons.OK,MessageBoxIcon.Information);
        //         bRegresa = false;
        //     }

        //     return bRegresa;
        // }
    }
}
