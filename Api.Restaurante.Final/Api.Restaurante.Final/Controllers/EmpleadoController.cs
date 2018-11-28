
using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Restaurante.Final.Controllers
{
    public class EmpleadoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Empleado> Get()
        {
            using (var context = new Context())
            {
                return context.Empleados.ToList();
            }
        }

    }
}
