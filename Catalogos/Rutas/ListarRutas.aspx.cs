using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Transportes_3_capas_gen_12.Utilidades;

namespace Transportes_3_capas_gen_12.Catalogos.Rutas
{
    public partial class ListarRutas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrid();
            }
        }

        private void cargarGrid()
        {
            GVRutas.DataSource = BLL_Rutas.GetRutas();
            GVRutas.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            Response.Redirect("formulariorutas.aspx");
        }

        protected void GVRutas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int varIndex = int.Parse(e.CommandArgument.ToString());
                string id = GVRutas.DataKeys[varIndex].Values["ID_Ruta"].ToString();

                Response.Redirect($"formulariorutas.aspx?Id={id}");
            }
        }

        protected void GVRutas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int idRuta = int.Parse(GVRutas.DataKeys[e.RowIndex].Values["ID_Ruta"].ToString());
            string respuesta = BLL_Rutas.EliminarRuta(idRuta);
            string titulo, msg, tipo;
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
            sweetAlert.Sweet_Alert(titulo, msg, tipo, this.Page, this.GetType());
            cargarGrid();
        }
    }
}