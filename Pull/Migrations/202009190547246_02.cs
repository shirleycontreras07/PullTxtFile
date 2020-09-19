namespace Pull.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _02 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DatosEmpleado", "DatosEmpresaID", "dbo.DatosEmpresa");
            DropIndex("dbo.DatosEmpleado", new[] { "DatosEmpresaID" });
            DropColumn("dbo.DatosEmpleado", "DatosEmpresaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DatosEmpleado", "DatosEmpresaID", c => c.Int(nullable: false));
            CreateIndex("dbo.DatosEmpleado", "DatosEmpresaID");
            AddForeignKey("dbo.DatosEmpleado", "DatosEmpresaID", "dbo.DatosEmpresa", "DatosEmpresaID", cascadeDelete: true);
        }
    }
}
