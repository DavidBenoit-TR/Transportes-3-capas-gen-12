using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Direcciones_VO
    {
        private int _ID_Direccion;
        private string _Calle;
        private string _Numero;
        private string _Colonia;
        private string _Ciudad;
        private string _Estado;
        private string _CP;

        public int ID_Direccion { get => _ID_Direccion; set => _ID_Direccion = value; }
        public string Calle { get => _Calle; set => _Calle = value; }
        public string Numero { get => _Numero; set => _Numero = value; }
        public string Colonia { get => _Colonia; set => _Colonia = value; }
        public string Ciudad { get => _Ciudad; set => _Ciudad = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string CP { get => _CP; set => _CP = value; }

        public Direcciones_VO()
        {
            _ID_Direccion = 0;
            _Calle = "";
            _Numero = "";
            _Colonia = "";
            _Ciudad = "";
            _Estado = "";
            _CP = "";

        }

        public Direcciones_VO(DataRow dr)
        {
            _ID_Direccion = int.Parse(dr["ID_Direccion"].ToString());
            _Calle = dr["Calle"].ToString();
            _Numero = dr["Numero"].ToString();
            _Colonia = dr["Colonia"].ToString();
            _Ciudad = dr["Ciudad"].ToString();
            _Estado = dr["Estado"].ToString();
            _CP = dr["CP"].ToString();

        }
    }
}
