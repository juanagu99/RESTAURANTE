

using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Restaurante.Final.Controllers
{
    public class CategoriaController : ApiController
    {
        [HttpGet]
        public IEnumerable<Categoria> Get()
        {          
            using (var context = new Context())
            {
                var l= context.Categorias.ToList();
                l.ForEach(x => x.Foto = Url.Content("~"+"/"+"Content/Imagenes/"+x.Foto));
                return l;
            }
        }
    }
}
