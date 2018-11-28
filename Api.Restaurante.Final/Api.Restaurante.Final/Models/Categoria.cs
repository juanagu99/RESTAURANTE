using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.Restaurante.Final.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key,Required]
        public string NombreCategoria { get; set; } //nombre de la categoria
        public string Foto { get; set; } //nombre de la categoria
    }
}