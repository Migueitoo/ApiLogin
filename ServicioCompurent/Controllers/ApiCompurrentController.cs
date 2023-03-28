using ModeloCompurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ServicioCompurent.Controllers
{
    public class ApiCompurrentController : ApiController
    {
        [HttpPost]
        public bool CrearUsuario([FromBody] ModeloRegistro usr)
        {
            if (usr.NumIdentificacion != null && usr.Contrasena != null) {
                // En este método se realizaría inserción de información en base de datos o el tratamiento que se requiera
                return true;
            }
            return false;
        }
    }
}
