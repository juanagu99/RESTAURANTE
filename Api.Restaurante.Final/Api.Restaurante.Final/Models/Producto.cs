using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Restaurante.Final.Models
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public string NombreProducto { get; set; }
        [Required]
        public string NombreCategoria { get; set; }
        [Required]
        public double Precio { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }

    }
}