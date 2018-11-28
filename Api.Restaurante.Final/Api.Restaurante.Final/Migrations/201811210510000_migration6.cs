namespace Api.Restaurante.Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Empleado", "Contraseña", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Empleado", "Contraseña");
        }
    }
}
