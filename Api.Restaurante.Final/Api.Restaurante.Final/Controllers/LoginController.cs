using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Restaurante.Final.Controllers
{
    public class LoginController : ApiController
    {
        [HttpPost]
        public Autentificacion Post(LoginEmpleado empleado)
        {
            Autentificacion salida = new Autentificacion();
            using (var context = new Context())
            {
                Empleado e = context.Empleados.FirstOrDefault(x => x.Correo == empleado.Usuario);
                if (e != null)
                {
                    if (e.Contraseña == empleado.Contraseña)
                    {
                        salida.respuesta = 2; //significa que puede ingresar
                        return salida;
                    }
                    else {
                        salida.respuesta = 1; //significa que la contraseña es incorrecta
                        return salida;
                    }
                }
                else {
                    salida.respuesta = 0; //significa que no se encuentra el usuario
                    return salida;
                }
                
            }
        }
    }
}
