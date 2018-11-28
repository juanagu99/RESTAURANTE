using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOMINIO
{

    public class Pedido
    {
        public int NumeroPedido { get; set; }
        public int NumeroMesa { get; set; }
        public int Idempleado { get; set; }
        public bool confirmado { get; set; }
    }
}