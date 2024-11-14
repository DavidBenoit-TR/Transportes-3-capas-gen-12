using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VO
{
    public class Rutas_VO
    {
        private int _ID_Ruta;
        private int _Camion_ID;
        private double _Distancia;
        private string _Fecha_salida;
        private string _Fecha_llegadaestimada;
        private string _Fecha_llegadareal;
        private int _Chofer_ID;
        private int _Direccionorigen_ID;
        private int _Direcciondestino_ID;

        public int ID_Ruta { get => _ID_Ruta; set => _ID_Ruta = value; }
        public int Camion_ID { get => _Camion_ID; set => _Camion_ID = value; }
        public double Distancia { get => _Distancia; set => _Distancia = value; }
        public string Fecha_salida { get => _Fecha_salida; set => _Fecha_salida = value; }
        public string Fecha_llegadaestimada { get => _Fecha_llegadaestimada; set => _Fecha_llegadaestimada = value; }
        public string Fecha_llegadareal { get => _Fecha_llegadareal; set => _Fecha_llegadareal = value; }
        public int Chofer_ID { get => _Chofer_ID; set => _Chofer_ID = value; }
        public int Direccionorigen_ID { get => _Direccionorigen_ID; set => _Direccionorigen_ID = value; }
        public int Direcciondestino_ID { get => _Direcciondestino_ID; set => _Direcciondestino_ID = value; }

        public Rutas_VO()
        {
            _ID_Ruta = 0;
            _Camion_ID = 0;
            _Distancia = 0;
            _Fecha_salida = "";
            _Fecha_llegadaestimada = "";
            _Fecha_llegadareal = "";
            _Chofer_ID = 0;
            _Direccionorigen_ID = 0;
            _Direcciondestino_ID = 0;

        }

        public Rutas_VO(DataRow dr)
        {
            _ID_Ruta = int.Parse(dr["ID_Ruta"].ToString());
            _Camion_ID = int.Parse(dr["Camion_ID"].ToString()); ;
            _Distancia = int.Parse(dr["Distancia"].ToString()); ;
            //1. Recupero la Fecha del DR => dr["Fecha_Salida"].ToString()
            //2. Convierto la fecha a un DateTime => DateTime.Parse()
            //3. Convierto nuevamente la fecha a un string con formato aaaa/MM/dd => .ToShortDateString()
            _Fecha_salida = DateTime.Parse(dr["Fecha_salida"].ToString()).ToShortDateString();
            _Fecha_llegadaestimada = DateTime.Parse(dr["Fecha_llegadaestimada"].ToString()).ToShortDateString();
            _Fecha_llegadareal = DateTime.Parse(dr["Fecha_llegadareal"].ToString()).ToShortDateString();
            _Chofer_ID = int.Parse(dr["Chofer_ID"].ToString());
            _Direccionorigen_ID = int.Parse(dr["Direccionorigen_ID"].ToString());
            _Direcciondestino_ID = int.Parse(dr["Direcciondestino_ID"].ToString());
        }
    }
}
