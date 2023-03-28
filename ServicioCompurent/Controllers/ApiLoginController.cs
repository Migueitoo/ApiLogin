using ModeloCompurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ServicioCompurent.Controllers
{
    public class ApiLoginController : ApiController
    {
        [System.Web.Http.HttpPost]
        public bool login([FromBody] ModeloLogin usr)
        {
            if (usr.Usuario == null || usr.Contrasena == null)
            {
                return false;
                // En este método se realizaría inserción de información en base de datos o el tratamiento que se requiera
            }
            return true;
        }
    }
}