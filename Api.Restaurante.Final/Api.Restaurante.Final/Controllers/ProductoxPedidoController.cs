
using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Restaurante.Final.Controllers
{
    public class ProductoxPedidoController : ApiController
    {
        
        [HttpGet]
        public IEnumerable<ProductoxPedido> Get()
        {
            using (var context = new Context())
            {
                return context.ProductoxPedido.ToList();
            }
        }
        [HttpPost]
        public ProductoxPedido Post(ProductoxPedido p)
        {
            using (var context = new Context())
            {
                context.ProductoxPedido.Add(p);
                context.SaveChanges();
                return p;
            }
        }
        [HttpDelete]
        public bool Delete(int id) {
            using (var context = new Context()) {
                var elim = context.ProductoxPedido.FirstOrDefault(x=>x.Id == id);
                context.ProductoxPedido.Remove(elim);
                context.SaveChanges();
                return true;
            }
        }
        [HttpPut]
        public ProductoxPedido Put(ProductoxPedido p)
        {
            using (var context = new Context())
            {
                var pedidoupdate = context.ProductoxPedido.FirstOrDefault(x => x.Id == p.Id);
                pedidoupdate.NombreProducto = p.NombreProducto;
                pedidoupdate.NumeroPedido = p.NumeroPedido;
                pedidoupdate.Cantidad = p.Cantidad;
                context.SaveChanges();
                return p;
            }
        }
    }
}
