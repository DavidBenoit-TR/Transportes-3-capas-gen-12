using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace BLL
{
    public class BLL_Rutas
    {
        public static string InsertarRuta(Rutas_VO ruta)
        {
            return DAL_Rutas.InsertarRuta(ruta);
        }

        public static List<Rutas_VO> GetRutas(params object[] parametros)
        {
            return DAL_Rutas.GetRutas(parametros);
        }

        public static string ActualizarRuta(Rutas_VO ruta)
        {
            return DAL_Rutas.ActualizarRuta(ruta);
        }

        public static string EliminarRuta(int id)
        {
            return DAL_Rutas.EliminarRuta(id);
        }
    }
}
