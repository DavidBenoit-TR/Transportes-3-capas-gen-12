using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Direcciones
    {
        public static List<Direcciones_VO> get_Direcciones(params object[] parametros)
        {
            List<Direcciones_VO> list_direcciones = new List<Direcciones_VO>();
            try
            {
                DataSet ds_camiones = metodos_datos.execute_DataSet("sp_ListarDirecciones", parametros);

                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list_direcciones.Add(new Direcciones_VO(dr));
                }
                return list_direcciones;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
