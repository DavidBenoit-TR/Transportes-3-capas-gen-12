using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_12.Utilidades;
using VO;

namespace Transportes_3_capas_gen_12.Catalogos.Camiones
{
    public partial class listar_Camiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //la variable IsPostBack representa la primera vez que carga la página
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        public void cargarGrid()
        {
            //carga la información desde la BLL al GV
            GVCamiones.DataSource = BLL_Camiones.Get_Camiones();
            //Mostramos los resultados renderizando la información
            GVCamiones.DataBind();
        }

        protected void Insertar_Click(object sender, EventArgs e)
        {
            Response.Redirect("formulariocamiones.aspx");
        }

        protected void GVCamiones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //recupero el ID del renglón efectao
            int idcamion = int.Parse(GVCamiones.DataKeys[e.RowIndex].Values["ID_Camion"].ToString());
            //Invoco mi metodo para eliminar camiones desde la BLL
            string respuesta = BLL_Camiones.eliminar_Camion(idcamion);
            //preparamos el Sweet Alert
            string titulo, msg, tipo;
            if (respuesta.ToUpper().Contains("ERROR"))
            {
                titulo = "Error";
                msg = respuesta;
                tipo = "error";
            }
            else
            {
                titulo = "Correcto!";
                msg = respuesta;
                tipo = "success";
            }

            //sweet alert
            sweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            //recargamos la página
            cargarGrid();
        }

        protected void GVCamiones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Defino si el comando (el click que se detecta) tiene la propiedad "Select"
            if (e.CommandName == "Select")
            {
                //recupero el índice en función de aquel elemento que haya detonado el evento
                int varIndex = int.Parse(e.CommandArgument.ToString());
                //recupero el ID en función del índice que recueramos anteriormente
                string id = GVCamiones.DataKeys[varIndex].Values["ID_Camion"].ToString();
                //redirecciono al formulario de edición, pasando como parámetro el ID
                Response.Redirect($"formulariocamiones.aspx?Id={id}");
            }
        }

        protected void GVCamiones_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //creamos un nuevo índice de Edición
            GVCamiones.EditIndex = e.NewEditIndex;
            //Refresco los datos
            cargarGrid();
        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //recupero el id en función del índice de aquel elemento que detonó el evento
            int idcamion = int.Parse(GVCamiones.DataKeys[e.RowIndex].Values["ID_Camion"].ToString());
            //recupero y creo índices de edición en función de los campos que serán editables dentro del GV (las columnas existentes)
            string matricula = e.NewValues["Matricula"].ToString();
            string TipoCamion = e.NewValues["Tipo_camion"].ToString();
            string Foto = e.NewValues["UrlFoto"].ToString();
            CheckBox chaux = (CheckBox)GVCamiones.Rows[e.RowIndex].FindControl("chkEditDisponible");
            bool disponibilidad = chaux.Checked;
            //Recupero el Objeto Original
            Camiones_VO _camion = BLL_Camiones.Get_Camiones("@ID_Camion", idcamion)[0];
            //creo un nuevo objeto para envar con los datos modificados
            Camiones_VO _camionAux = new Camiones_VO();
            //asignamos los valores que vamos a actualizar
            _camionAux.ID_Camion = idcamion;
            _camionAux.Matricula = matricula;
            _camionAux.Disponibilidad = disponibilidad;
            _camionAux.Tipo_Camion = TipoCamion;
            _camionAux.UrlFoto = Foto;
            //Asignamos los valores anteriores
            _camionAux.Marca = _camion.Marca;
            _camionAux.Modelo = _camion.Modelo;
            _camionAux.Capacidad = _camion.Capacidad;
            _camionAux.Kilometraje = _camion.Kilometraje;

            //Configurar el Sweet Alert
            string respuesta = "";
            string titulo, msg, tipo;

            try
            {
                //invoco mi método de actualizar desde la capa BLL pasándole el nuevo objeto
                respuesta = BLL_Camiones.actualizar_Camion(_camionAux);
                //Configuración para el Sweet Alert
                if (respuesta.ToUpper().Contains("ERROR"))
                {
                    titulo = "Ops...";
                    msg = respuesta;
                    tipo = "error";
                }
                else
                {
                    titulo = "Correcto!";
                    msg = respuesta;
                    tipo = "success";
                }
            }
            catch (Exception ex)
            {
                titulo = "Ops...";
                msg = ex.Message;
                tipo = "error";
            }
            //Sweet Alert
            //Reiniciar los ínidces de Edición
            GVCamiones.EditIndex = -1;
            //recargar el Grid
            cargarGrid();
        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Reiniico los índice de edición
            GVCamiones.EditIndex = -1;
            //refresco los datos
            cargarGrid();
        }
    }
}