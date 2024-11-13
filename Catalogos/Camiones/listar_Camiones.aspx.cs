using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

        }

        protected void GVCamiones_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GVCamiones_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }
    }
}