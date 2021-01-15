using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;

namespace ABCExhibicion
{
    class CAccesoDatos
    {
        public static bool abreconexionSql(OdbcConnection conexion)
        {
            string sMensaje = "";
            bool bRegresa = false;
            string sConexion = "";

            sConexion = "Driver={SQL Server};database=" + "ComprasMuebles" + ";server=" + "10.28.146.71" + ";uid=" + "sysdesarrollo" + ";pwd=" + "fl9s9FKLGJUT5YAoqtJFTn9MtQgVo9Zn";
            conexion.ConnectionTimeout = 1000000;
            conexion.ConnectionString = sConexion;
            
            try
            {
                conexion.Open();
                if(conexion.State == ConnectionState.Open){
                    bRegresa = true;
                }
            }
            catch (OdbcException Ex){
                sMensaje = "Conexion Fallida";
                MessageBox.Show(Ex + sMensaje, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bRegresa = false;
            }
            return bRegresa;
        }

        public static bool ejecutaQuery(OdbcConnection odbc, string sConsulta){
            bool bRegresa = true;
            OdbcCommand comando = new OdbcCommand(sConsulta, odbc);
            comando.CommandTimeout = 1000000;
            comando.ExecuteNonQuery();
            return bRegresa;
        }

        public static void cierraconexionSql(OdbcConnection conexion)
        {
            if(conexion.State == ConnectionState.Open){
                conexion.Close();
            }
        }

        public static OdbcDataReader ejecutarconsulta(string sConsulta, OdbcConnection odbcSql)
        {
            OdbcCommand comando = null;
            comando = new OdbcCommand(sConsulta, odbcSql);
            comando.CommandTimeout = 1000000;

            return comando.ExecuteReader();
        }


        //  LOCACIONES SP

        public static bool GrabarLocacion(int iLocacionid, string sMunicipio, string sLocacion){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();
            OdbcDataReader reader;

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclocaciones {0}, '{1}', '{2}', 1", iLocacionid, sMunicipio,sLocacion);

                    reader = ejecutarconsulta(sComandoSQL, odbcSQL);                   
                   
                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader["Error"]) == 1)
                        {
                            bRegresa = false;
                            MessageBox.Show("Codigo Existente");
                        }else{
                            if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                            
                                bRegresa = false;
                                MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                            }else{

                                MessageBox.Show("Se Grabo Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bRegresa = true;
                            } 
                        }
                    }   
                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }


        public static bool ModificarLocacion(int iLocacionid, string sMunicipio, string sLocacion){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclocaciones {0}, '{1}', '{2}', 2", iLocacionid, sMunicipio,sLocacion);

                    if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                    
                        bRegresa = false;
                        MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                    }else{

                        MessageBox.Show("Se Modifico Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = true;
                    } 

                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }

        public static bool EliminarLocacion(int iLocacionid){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclocaciones {0},'','',3", iLocacionid);             
                   
                    if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                    
                        bRegresa = false;
                        MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                    }else{

                        MessageBox.Show("Se Elimino el Centro Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = true;
                    } 

                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }

        public static bool BuscarLocacion(string sLocacionid, ref List<CLocacion> listadoLocacion){
            bool bRegresa = false;
            string sComandoSQL = "";
            int iLocacionid = 0;
            OdbcConnection odbcSQL = new OdbcConnection();
            OdbcDataReader reader;
            CLocacion datosLocacion = new CLocacion();

            if(!string.IsNullOrEmpty(sLocacionid)){
                iLocacionid = Convert.ToInt32(sLocacionid);
            }


            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclocaciones {0},'', '', 4", iLocacionid);             
                   
                    reader = ejecutarconsulta(sComandoSQL,odbcSQL);

                    while (reader.Read()){
                        datosLocacion = new CLocacion();
                        datosLocacion.sMunicipio = reader[1].ToString();
                        datosLocacion.sLocacion = reader[2].ToString();
                        listadoLocacion.Add(datosLocacion);
                        bRegresa = true;
                    }

                    if(!bRegresa){
                        MessageBox.Show("El numero no es valido", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = false;

                    }
                    reader.Close();
                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }

        // CLIENTE SP

        public static bool GrabarCliente(int iClienteid, int iLocacionid, string sClienteNom){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();
            OdbcDataReader reader;

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclientes {0}, {1}, '{2}', 1", iClienteid, iLocacionid,sClienteNom);

                    reader = ejecutarconsulta(sComandoSQL, odbcSQL);                   
                   
                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader["Error"]) == 1)
                        {
                            bRegresa = false;
                            MessageBox.Show("Codigo Existente");
                        }else{
                            if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                            
                                bRegresa = false;
                                MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                            }else{

                                MessageBox.Show("Se Grabo Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bRegresa = true;
                            } 
                        }
                    }   
                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }


        public static bool ModificarCliente(int iClienteid, int iLocacionid, string sClienteNom){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclientes {0}, {1}, '{2}', 2", iClienteid, iLocacionid,sClienteNom);

                    if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                    
                        bRegresa = false;
                        MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                    }else{

                        MessageBox.Show("Se Modifico Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = true;
                    } 

                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }

        public static bool EliminarCliente(int iClienteid){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclientes {0}, 0,'',3", iClienteid);             
                   
                    if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                    
                        bRegresa = false;
                        MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                    }else{

                        MessageBox.Show("Se Elimino el Centro Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = true;
                    } 

                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }

        public static bool BuscarCliente(string sClienteid, ref List<CCliente> listadoCliente){
            bool bRegresa = false;
            string sComandoSQL = "";
            int iClienteid = 0;
            OdbcConnection odbcSQL = new OdbcConnection();
            OdbcDataReader reader;
            CCliente datosCliente = new CCliente();

            if(!string.IsNullOrEmpty(sClienteid)){
                iClienteid = Convert.ToInt32(sClienteid);
            }


            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclientes {0}, 0, '', 4", iClienteid);             
                   
                    reader = ejecutarconsulta(sComandoSQL,odbcSQL);

                    while (reader.Read()){
                        datosCliente = new CCliente();
                        datosCliente.iLocalidad = Convert.ToInt32(reader[1].ToString());
                        datosCliente.sLocalidad = reader[2].ToString();
                        datosCliente.sClienteNom = reader[3].ToString();
                        listadoCliente.Add(datosCliente);
                        bRegresa = true;
                    }

                    if(!bRegresa){
                        MessageBox.Show("El numero no es valido", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = false;

                    }
                    reader.Close();
                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }

        
        //  Articulos Sp

        public static bool GrabarArticulo(int iArticuloid, string sArticuloNom, string sModelo, string sMarca, decimal dPrecio, int iExistencia){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();
            OdbcDataReader reader;

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abcarticulos {0}, '{1}', '{2}', '{3}', {4}, {5}, 1", iArticuloid, sArticuloNom,sModelo, sMarca, dPrecio, iExistencia);

                    reader = ejecutarconsulta(sComandoSQL, odbcSQL);                   
                   
                    if (reader.Read())
                    {
                        if (Convert.ToInt32(reader["Error"]) == 1)
                        {
                            bRegresa = false;
                            MessageBox.Show("Codigo Existente");
                        }else{
                            if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                            
                                bRegresa = false;
                                MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                            }else{

                                MessageBox.Show("Se Grabo Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                bRegresa = true;
                            } 
                        }
                    }   
                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }


        public static bool ModificarArticulo(int iLocacionid, string sMunicipio, string sLocacion){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclocaciones {0}, '{1}', '{2}', 2", iLocacionid, sMunicipio,sLocacion);

                    if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                    
                        bRegresa = false;
                        MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                    }else{

                        MessageBox.Show("Se Modifico Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = true;
                    } 

                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }

        public static bool EliminarArticulo(int iLocacionid){
            bool bRegresa = true;
            string sComandoSQL = "";
            OdbcConnection odbcSQL = new OdbcConnection();

            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclocaciones {0},'','',3", iLocacionid);             
                   
                    if (!ejecutaQuery(odbcSQL, sComandoSQL)){
                    
                        bRegresa = false;
                        MessageBox.Show("Error Al Ejecutar el SP", "ABCExhibicion" + sComandoSQL);
                    }else{

                        MessageBox.Show("Se Elimino el Centro Correctamente", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = true;
                    } 

                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }

        public static bool BuscarArticulo(string sLocacionid, ref List<CLocacion> listadoLocacion){
            bool bRegresa = false;
            string sComandoSQL = "";
            int iLocacionid = 0;
            OdbcConnection odbcSQL = new OdbcConnection();
            OdbcDataReader reader;
            CLocacion datosLocacion = new CLocacion();

            if(!string.IsNullOrEmpty(sLocacionid)){
                iLocacionid = Convert.ToInt32(sLocacionid);
            }


            if(abreconexionSql(odbcSQL)){
                try
                {
                    sComandoSQL = string.Format("EXECUTE ComprasMuebles.dbo.proc_abclocaciones {0},'', '', 4", iLocacionid);             
                   
                    reader = ejecutarconsulta(sComandoSQL,odbcSQL);

                    while (reader.Read()){
                        datosLocacion = new CLocacion();
                        datosLocacion.sMunicipio = reader[1].ToString();
                        datosLocacion.sLocacion = reader[2].ToString();
                        listadoLocacion.Add(datosLocacion);
                        bRegresa = true;
                    }

                    if(!bRegresa){
                        MessageBox.Show("El numero no es valido", "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bRegresa = false;

                    }
                    reader.Close();
                }
                catch (Exception ex){
                    bRegresa = false;
                    MessageBox.Show(ex.Message, "ABCExhibicion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            cierraconexionSql(odbcSQL);
            return bRegresa;

        }



    }
}