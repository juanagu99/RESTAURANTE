
using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Restaurante.Final.Controllers
{
    public class TipodeempleadoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Tipodeempleado> Get()
        {
            using (var context = new Context())
            {
                return context.Tipodeempleados.ToList();
            }
        }
    }
}
