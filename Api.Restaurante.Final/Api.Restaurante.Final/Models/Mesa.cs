using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Restaurante.Final.Models
{
    [Table("Mesa")]
    public class Mesa
    {
        [Key]
        public int NumeroMesa { get; set; }
        public bool Estado { get; set; }
        public int Capacidad { get; set; }
    }
}