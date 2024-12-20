﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Transportes_3_capas_gen_12.WS.Calculadora
{
    /// <summary>
    /// Descripción breve de calculadora_Service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class calculadora_Service : System.Web.Services.WebService
    {

        [WebMethod]//Decorador (DataAnotation)
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public double Suma(double a, double b)
        {
            return a + b;
        }

        [WebMethod]
        public double Resta(double a, double b)
        {
            return a - b;
        }

        [WebMethod]
        public double Multiplicacion(double a, double b)
        {
            return a * b;
        }

        [WebMethod]
        public double Divicion(double a, double b)
        {
            return a / b;
        }
    }
}
