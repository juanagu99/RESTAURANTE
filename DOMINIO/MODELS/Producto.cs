using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DOMINIO
{
  
    public class Producto
    {       
        public string NombreProducto { get; set; }        
        public string NombreCategoria { get; set; }       
        public double Precio { get; set; }
        public string Foto { get; set; }
        public string Descripcion { get; set; }
    }
}