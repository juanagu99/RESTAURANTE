
using Api.Restaurante.Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Restaurante.Final.Controllers
{
    public class PedidoController : ApiController
    {
        [HttpGet]
        public IEnumerable<Pedido> Get()
        {
            using (var context = new Context())
            {
                return context.Pedidos.ToList();
            }
        }
        [HttpPost]
        public Pedido Post(Pedido pedido)
        {
            using (var context = new Context()) {
                context.Pedidos.Add(pedido);
                context.SaveChanges();
                return pedido;
            }
        }
        [HttpPut]
        public Pedido Put(Pedido pedido) {
            using (var context = new Context())
            {
                var pedidoupdate = context.Pedidos.FirstOrDefault(x=>x.NumeroPedido == pedido.NumeroPedido);
                pedidoupdate.Idempleado = pedido.Idempleado;
                pedidoupdate.NumeroMesa = pedido.NumeroMesa;
                pedidoupdate.NumeroPedido = pedido.NumeroPedido;
                pedidoupdate.confirmado = pedido.confirmado;
                context.SaveChanges();
                return pedido;
            }
        }
    }
}
