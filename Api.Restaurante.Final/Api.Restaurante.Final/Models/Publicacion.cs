using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Restaurante.Final.Models
{
    [Table("Publicacion")]
    public class Publicacion
    {
        [Key, Required]
        public int Id{ get; set; } //nombre de la categoria
        public string Foto { get; set; } //nombre de la categoria        
    }
}