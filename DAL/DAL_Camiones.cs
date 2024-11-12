using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VO;

namespace DAL
{
    public class DAL_Camiones
    {
        //Create
        public static string insertar_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("SP_Insert_Camion",
                    "@Matricula", camion.Matricula,
                    "@Tipo_Camion", camion.Tipo_Camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.UrlFoto,
                    "@Disponibilidad", camion.Disponibilidad
                    );

                if (respuesta != 0)
                {
                    salida = "Camión registrado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                //salida = "Error: " + e.Message;
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

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
        public static string actualizar_Camion(Camiones_VO camion)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("SP_Update_Camion",
                    "@Matricula", camion.Matricula,
                    "@Tipo_Camion", camion.Tipo_Camion,
                    "@Marca", camion.Marca,
                    "@Modelo", camion.Modelo,
                    "@Capacidad", camion.Capacidad,
                    "@Kilometraje", camion.Kilometraje,
                    "@UrlFoto", camion.UrlFoto,
                    "@Disponibilidad", camion.Disponibilidad,
                    "@Id_Camion", camion.ID_Camion
                    );

                if (respuesta != 0)
                {
                    salida = "Camión actualizado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error: {e.Message}";
            }
            return salida;
        }

        //Delete

        public static string eliminar_Camion(int id)
        {
            string salida = "";
            int respuesta = 0;
            try
            {
                respuesta = metodos_datos.execute_nonQuery("SP_Delete_Camion",
                    "@Id_Camion", id
                    );

                if (respuesta != 0)
                {
                    salida = "Camión eliminado con éxito";
                }
                else
                {
                    salida = "Ha ocurrido un error";
                }
            }
            catch (Exception e)
            {
                salida = $"Error: {e.Message}";
            }
            return salida;
        }
    }
}
