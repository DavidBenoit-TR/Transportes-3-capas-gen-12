using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;
using VO;

namespace Transportes_3_capas_gen_12.Catalogos.Camiones
{
    public partial class formulariocamiones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //validar si es postback
            if (!IsPostBack)
            {
                //validar si voy a insertar o a editar
                if (Request.QueryString["Id"] == null)
                {
                    //voy a insertar
                    Titulo.Text = "Agregar Camión";
                    Subtitulo.Text = "Registro de un nuevo camión";
                    lbldisponibilidad.Visible = false;
                    chkdisponibilidad.Visible = false;
                    imgfoto.Visible = false;
                    lblurlfoto.Visible = false;
                }
                else
                {
                    //voy a actualziar
                    //Recupero el ID que proviene de la URL
                    int _id = Convert.ToInt32(Request.QueryString["Id"]);
                    //obtener el objeto origianl de la BD y colocar los valores en sus campos correspondinetes
                    Camiones_VO _camion_original = BLL_Camiones.Get_Camiones("@ID_Camion", _id)[0];
                    //valido que realmente obtenga el objeto y sus valores, de lo contrario, me regreso al formulario
                    if (_camion_original.ID_Camion != 0)
                    {
                        //si encontré el objeto y comienzo a colocar sus valores
                        Titulo.Text = "Actualizar Camión";
                        Subtitulo.Text = $"Modificar los datos del Camión #{_id}";
                        txtmatricula.Text = _camion_original.Matricula;
                        txtcapacidad.Text = _camion_original.Capacidad.ToString();
                        txtkilometraje.Text = _camion_original.Kilometraje.ToString();
                        txtmarca.Text = _camion_original.Marca;
                        txtmodelo.Text = _camion_original.Modelo;
                        txttipo_camion.Text = _camion_original.Tipo_Camion;
                        chkdisponibilidad.Checked = _camion_original.Disponibilidad;
                        imgfoto.ImageUrl = _camion_original.UrlFoto;
                    }
                    else
                    {
                        //no encontré el objeto y me pa' tras
                        Response.Redirect("listarCamiones.aspx");
                    }
                }
            }
        }

        protected void btnsubeimagen_Click(object sender, EventArgs e)
        {
            //este método sirve para guardar y almacenar la imagen en el servidor y posteriormente recuperar la info necesaria desde la BD
            if (subeimagen.Value != "")
            {
                //recupero el nombre del archivo
                string filename = Path.GetFileName(subeimagen.Value);
                //validar la extención del archivo
                string fileext = Path.GetExtension(filename).ToLower();
                if ((fileext != ".jpg") && (fileext != ".png"))
                {
                    //Sweet Alert
                }
                else
                {
                    //verifico que existe el directorio en el sevidor para poder almacenar la imagen, si es que no, lo creo
                    string pathdir = Server.MapPath("~/Imagenes/Camiones/"); //~ (virgulilla) hace referencia a la dirección completa del servidor, independientemenete de donde esté instalado, permitiendo que la validicación funciones en diferentes entornos

                    //si no existe el directorio, lo creamo
                    if (!Directory.Exists(pathdir))
                    {
                        //creo el directorio
                        Directory.CreateDirectory(pathdir);
                    }
                    //submos la imagen a la carpeta del server
                    subeimagen.PostedFile.SaveAs(pathdir + filename);
                    //recuperamos la ruta de la URL que almacenamos en la BD
                    string urlFoto = "/Imagenes/Camiones/" + filename;
                    //mostramos en pantalla la URL creada
                    this.urlfoto.Text = urlFoto;
                    //mostramos la imagen
                    imgcamion.ImageUrl = urlFoto;
                    //Sweet alert
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            string titulo = "", respuesta = "", tipo = "", salida = "";

            try
            {
                //creamos el objeto que enviaremos para actualiza o insertar
                //forma 1 (x atributos)
                Camiones_VO _camion_aux = new Camiones_VO();
                _camion_aux.Matricula = txtmatricula.Text;
                _camion_aux.Marca = txtmarca.Text;
                _camion_aux.Tipo_Camion = txttipo_camion.Text;
                _camion_aux.Modelo = txtmodelo.Text;
                _camion_aux.Capacidad = Convert.ToInt32(txtcapacidad.Text);
                _camion_aux.Kilometraje = Convert.ToDouble(txtkilometraje.Text);
                _camion_aux.UrlFoto = imgcamion.ImageUrl;
                _camion_aux.Disponibilidad = chkdisponibilidad.Checked;
                //FOrma 2 (durante la instanicación)
                Camiones_VO _camion_aux_2 = new Camiones_VO()
                {
                    Matricula = txtmatricula.Text,
                    Marca = txtmarca.Text,
                    Tipo_Camion = txttipo_camion.Text,
                    Modelo = txtmodelo.Text,
                    Capacidad = Convert.ToInt32(txtcapacidad.Text),
                    Kilometraje = Convert.ToDouble(txtkilometraje.Text),
                    UrlFoto = imgcamion.ImageUrl
                };

                //decido si voy a actualziar o a insertar
                if (Request.QueryString["Id"] == null)
                {
                    //Voy a insertar
                    _camion_aux.Disponibilidad = true;
                    salida = BLL_Camiones.insertar_Camion(_camion_aux);
                }
                else
                {
                    //Actualizar
                    _camion_aux.ID_Camion = int.Parse(Request.QueryString["Id"]);
                    salida = BLL_Camiones.actualizar_Camion(_camion_aux);
                }
                //preparamos la salida para cachar nu error y mostrar un sweer alert
                if (salida.ToUpper().Contains("ERROR"))
                {
                    titulo = "Ops...";
                    respuesta = salida;
                    tipo = "warning";
                }
                else
                {
                    titulo = "Correcto!";
                    respuesta = salida;
                    tipo = "success";
                }

            }
            catch (Exception ex)
            {
                titulo = "Error";
                respuesta = ex.Message;
                tipo = "error";
            }
            //sweet alert
        }
    }
}