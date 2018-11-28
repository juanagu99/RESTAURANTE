using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Restaurante.Final.Models
{
    [Table("Tipodeempleado")]
    public class Tipodeempleado
    {
        [Key]
        public string Nombre { get; set; }
    }
}