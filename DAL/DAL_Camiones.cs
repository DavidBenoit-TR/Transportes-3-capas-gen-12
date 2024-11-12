using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Camiones
    {
        //Create

        //Read
        public static List<Camiones_VO> Get_Camiones(params object[] parametros)
        {
            //creo una lista de objetos tipo VO
            List<Camiones_VO> list = new List<Camiones_VO>();
            try
            {
                //crear un dataset el cual recibirá lo que devuelva la ejecución del método "execte_dataset" que proviene de la clase "metodos_Datos"
                DataSet ds_camiones = metodos_datos.execute_DataSet("SP_listar_camiones", parametros);
                //recorremos cada renglón existente de nuesro ds creando objetos de tipo VO y añadiéndilos a una lista
                foreach (DataRow dr in ds_camiones.Tables[0].Rows)
                {
                    list.Add(new Camiones_VO(dr));
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        //Update

        //Delete
    }
}
