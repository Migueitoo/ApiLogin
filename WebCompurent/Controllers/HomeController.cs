using ModeloCompurrent; //Modelo
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace WebCompurent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            ModeloLogin modeloLogin = new ModeloLogin();
            return View(modeloLogin);
        }
        [HttpPost]
        public async Task<ActionResult> Login(ModeloLogin model)
        {
            try
            {   
                //Pétición ApiLoginController para inicio de sesión
                ModeloRegistro modeloRegistro = new ModeloRegistro();
                var options = new RestClientOptions("http://localhost:55994")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/ApiLogin/login", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddStringBody(JsonConvert.SerializeObject(model), DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                if (response.Content == "true")
                {
                    string[] arrRegistro;
                    string NumIdentificacion, Contraseña;
                    try
                    {
                        // EXCEPCIÓN CONTROLADOA: Si no existe el usuario entrega error el cual que redirige a la vista de registro de usuario (línea 51)
                        arrRegistro = (string[])Session["NuevoUsuario"];
                        NumIdentificacion = arrRegistro[0];
                        Contraseña = arrRegistro[1];
                    }
                    catch (Exception)
                    {
                        TempData["mensaje"] = "Este usuario no se encuentra registrado por favor registrarse";
                        return RedirectToAction("Registro", "Home");
                    }

                    if (model.Usuario == NumIdentificacion && model.Contrasena == Contraseña)
                    {
                        modeloRegistro.NumIdentificacion = arrRegistro[0];
                        modeloRegistro.Contrasena = arrRegistro[1];
                        modeloRegistro.Nombre = arrRegistro[2];
                        modeloRegistro.Correo = arrRegistro[3];
                        modeloRegistro.Direccion = arrRegistro[4];
                        modeloRegistro.Ciudad = arrRegistro[5];
                        modeloRegistro.Telefono = arrRegistro[6];
                        return View("Bienvenida", modeloRegistro);
                    }
                    else
                    {
                        if (model.Usuario != NumIdentificacion)
                        {
                            TempData["mensaje"] = "Este usuario no se encuentra registrado por favor registrarse";
                            return View(model);
                        }
                        else {
                            TempData["mensaje"] = "Error de credenciales, usuario o contrasena equivocados";
                            return View(model);
                        }                    
                    }

                }
                else
                {
                    TempData["mensaje"] = "Ocurrio un error al realizar la peticion a ApiLogin. Estado isSuccessful: " + response.IsSuccessful;
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                TempData["mensaje"] = "La petición a ApiLogin no fue exitosa, error:" + ex;
                return View(model);
            }           
        }

        public ActionResult Registro()
        {
            ModeloRegistro modeloRegistro = new ModeloRegistro();
            return View(modeloRegistro);
        }
        [HttpPost]
        public async Task<ActionResult> Registro(ModeloRegistro model)
        {
            try
            {
                ModeloRegistro modeloRegistro = new ModeloRegistro();
                var options = new RestClientOptions("http://localhost:55994")
                {
                    MaxTimeout = -1,
                };
                var client = new RestClient(options);
                var request = new RestRequest("/api/ApiCompurrent/CrearUsuario", Method.Post);
                request.AddHeader("Content-Type", "application/json");
                request.AddStringBody(JsonConvert.SerializeObject(model), DataFormat.Json);
                RestResponse response = await client.ExecuteAsync(request);
                Console.WriteLine(response.Content);
                //CREAR VARIABLE DE SESIÓN EN LA MEMORIA CON INFORMACIÓN DE NUEVO USUARIO
                string[] arrRegistro = { model.NumIdentificacion, model.Contrasena, model.Nombre, model.Correo, model.Direccion, model.Ciudad, model.Telefono };
                Session["NuevoUsuario"] = arrRegistro;
                if (response.Content == "true")
                {
                    TempData["mensaje"] = "Usuario registrado exitosamente, Realizar Login";
                    return RedirectToAction("Login", "Home");
                }
                else {
                    TempData["mensaje"] = "Ocurrio un error al realizar la peticion a ApiComupurrent. Estado isSuccessful: " + response.IsSuccessful;
                    return View(model);
                }
                         
            }
            catch (Exception ex)
            {
                TempData["mensaje"] = "La petición a ApiRegistro no fue exitosa, error:" + ex;
                return View(model);
            }                    
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Bienvenida()
        {
            return View();
        }    
           
    }
}