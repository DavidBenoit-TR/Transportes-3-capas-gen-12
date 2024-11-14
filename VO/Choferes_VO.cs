using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Choferes_VO
    {
        private int _ID_Chofer;
        private string _Nombre;
        private string _Apellido_Paterno;
        private string _Apellido_Materno;
        private string _FechaNacimiento;
        private string _Licencia;
        private string _Telefono;
        private bool _Disponibilidad;
        private string _UrlFoto;

        public int ID_Chofer { get => _ID_Chofer; set => _ID_Chofer = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido_Paterno { get => _Apellido_Paterno; set => _Apellido_Paterno = value; }
        public string Apellido_Materno { get => _Apellido_Materno; set => _Apellido_Materno = value; }
        public string FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Licencia { get => _Licencia; set => _Licencia = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public bool Disponibilidad { get => _Disponibilidad; set => _Disponibilidad = value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto = value; }

        public Choferes_VO()
        {
            _ID_Chofer = 0;
            _Nombre = "";
            _Apellido_Paterno = "";
            _Apellido_Materno = "";
            _FechaNacimiento = "";
            _Licencia = "";
            _Telefono = "";
            _Disponibilidad = true;
            _UrlFoto = "";
        }

        public Choferes_VO(DataRow dr)
        {
            _ID_Chofer = int.Parse(dr["ID_Chofer"].ToString());
            _Nombre = dr["Nombre"].ToString();
            _Apellido_Paterno = dr["Apellido_Paterno"].ToString();
            _Apellido_Materno = dr["Apellido_Materno"].ToString();
            _FechaNacimiento = dr["FechaNacimiento"].ToString();
            _Licencia = dr["Licencia"].ToString();
            _Telefono = dr["Telefono"].ToString();
            _Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
            _UrlFoto = dr["UrlFoto"].ToString();
        }
    }
}
