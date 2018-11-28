using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Restaurante.Final.Models
{
    [Table("ProductoxPedido")]

    public class ProductoxPedido
    {      
            [Key]
            public int Id { get; set; }
            public int NumeroPedido { get; set; }
            public string NombreProducto { get; set; }
            public int Cantidad { get; set; }
      
    }
}