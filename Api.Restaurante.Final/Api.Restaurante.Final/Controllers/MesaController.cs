
using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Restaurante.Final.Controllers
{
    public class MesaController : ApiController
    {
        [HttpGet]
        public IEnumerable<Mesa> Get()
        {
            using (var context = new Context())
            {
                return context.Mesas.ToList();
            }
        }
    }
}
