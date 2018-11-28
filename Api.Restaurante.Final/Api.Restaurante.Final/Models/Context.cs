
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Api.Restaurante.Final.Models
{
    public class Context : DbContext
    {
        public Context() : base("RestauranteConnection") { }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Publicacion> Publicacion { get; set; }
        public DbSet<ProductoxPedido> ProductoxPedido { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Tipodeempleado> Tipodeempleados { get; set; }

    }
}