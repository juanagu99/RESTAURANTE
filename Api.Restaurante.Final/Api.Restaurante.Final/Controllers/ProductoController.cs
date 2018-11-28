
using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Restaurante.Final.Controllers
{
    public class ProductoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Producto> Get()
        {
            using (var context = new Context())
            {
                var l = context.Productos.ToList();
                l.ForEach(x => x.Foto = Url.Content("~" + "/" + "Content/Imagenes/" + x.Foto));
                return l;
            }
        }
    }
}
