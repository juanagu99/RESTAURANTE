namespace Api.Restaurante.Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration3 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductosxPedido", newName: "ProductoxPedido");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.ProductoxPedido", newName: "ProductosxPedido");
        }
    }
}
