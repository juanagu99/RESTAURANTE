namespace Api.Restaurante.Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        NombreCategoria = c.String(nullable: false, maxLength: 128),
                        Foto = c.String(),
                    })
                .PrimaryKey(t => t.NombreCategoria);
            
            CreateTable(
                "dbo.Empleado",
                c => new
                    {
                        Idempleado = c.Int(nullable: false, identity: true),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        Correo = c.String(),
                        Tipodeempleado = c.String(),
                    })
                .PrimaryKey(t => t.Idempleado);
            
            CreateTable(
                "dbo.Mesa",
                c => new
                    {
                        NumeroMesa = c.Int(nullable: false, identity: true),
                        Estado = c.Boolean(nullable: false),
                        Capacidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroMesa);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        NumeroPedido = c.Int(nullable: false, identity: true),
                        NumeroMesa = c.Int(nullable: false),
                        Idempleado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NumeroPedido);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        NombreProducto = c.String(nullable: false, maxLength: 128),
                        NombreCategoria = c.String(nullable: false),
                        Precio = c.Double(nullable: false),
                        Foto = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.NombreProducto);
            
            CreateTable(
                "dbo.ProductosxPedido",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        NumeroPedido = c.Int(nullable: false),
                        NombreProducto = c.String(),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tipodeempleado",
                c => new
                    {
                        Nombre = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Nombre);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tipodeempleado");
            DropTable("dbo.ProductosxPedido");
            DropTable("dbo.Producto");
            DropTable("dbo.Pedido");
            DropTable("dbo.Mesa");
            DropTable("dbo.Empleado");
            DropTable("dbo.Categoria");
        }
    }
}
