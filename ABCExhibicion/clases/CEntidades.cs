using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABCExhibicion
{
    class CEntidades
    {
    }

    public class CLocacion{
        public string sMunicipio = " ";
        public string sLocacion = " ";
    }

    public class CCliente{
        public int iLocalidad = 0;
        public string sLocalidad = " ";
        public string sClienteNom = " ";
    }

    public class CArticulo{
        public string sArticuloNom = " ";
        public string sModelo = " ";
        public string sMarca = " ";
        public decimal dPrecio = 0;
        public int iExistencia = 0;
    }
}
