using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Camiones_VO
    {
        //VO = View Object
        //Representación de una tabla a nivel de código de C#

        private int _ID_Camion;
        private string _Matricula;
        private string _Tipo_Camion;
        private string _Marca;
        private string _Modelo;
        private int _Capacidad;
        private double _Kilometraje;
        private string _UrlFoto;
        private bool _Disponibilidad;

        //Encapsulamiento
        public int ID_Camion { get => _ID_Camion; set => _ID_Camion = value; }
        public string Matricula { get => _Matricula; set => _Matricula = value; }
        public string Tipo_Camion { get => _Tipo_Camion; set => _Tipo_Camion = value; }
        public string Marca { get => _Marca; set => _Marca = value; }
        public string Modelo { get => _Modelo; set => _Modelo = value; }
        public int Capacidad { get => _Capacidad; set => _Capacidad = value; }
        public double Kilometraje { get => _Kilometraje; set => _Kilometraje = value; }
        public string UrlFoto { get => _UrlFoto; set => _UrlFoto = value; }
        public bool Disponibilidad { get => _Disponibilidad; set => _Disponibilidad = value; }

        //Constructores
        //Por defecto
        public Camiones_VO()
        {
            _ID_Camion = 0;
            _Matricula = string.Empty;
            _Tipo_Camion = string.Empty;
            _Marca = string.Empty;
            _Modelo = string.Empty;
            _Capacidad = 0;
            _Kilometraje = 0;
            _UrlFoto = string.Empty;
            _Disponibilidad = true;
        }

        //Con parámetros
        //Datarow => Objeto de ADO
        public Camiones_VO(DataRow dr)
        {
            _ID_Camion = int.Parse(dr["ID_Camion"].ToString());
            _Matricula = dr["Matricula"].ToString();
            _Tipo_Camion = dr["Tipo_Camion"].ToString();
            _Marca = dr["Marca"].ToString();
            _Modelo = dr["Modelo"].ToString();
            _Capacidad = int.Parse(dr["Capacidad"].ToString());
            _Kilometraje = double.Parse(dr["Kilometraje"].ToString());
            _UrlFoto = dr["UrlFoto"].ToString();
            _Disponibilidad = bool.Parse(dr["Disponibilidad"].ToString());
        }
    }
}