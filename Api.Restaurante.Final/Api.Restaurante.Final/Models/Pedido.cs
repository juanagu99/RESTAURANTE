using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Restaurante.Final.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        public int NumeroPedido { get; set; }
        public int NumeroMesa { get; set; }
        public int Idempleado { get; set; }
        public bool confirmado { get; set; }

    }
}