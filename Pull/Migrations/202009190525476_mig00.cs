namespace Pull.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig00 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DatosEmpleado", "DatosEmpresa_DatosEmpresaID", "dbo.DatosEmpresa");
            DropIndex("dbo.DatosEmpleado", new[] { "DatosEmpresa_DatosEmpresaID" });
            RenameColumn(table: "dbo.DatosEmpleado", name: "DatosEmpresa_DatosEmpresaID", newName: "DatosEmpresaID");
            AlterColumn("dbo.DatosEmpleado", "DatosEmpresaID", c => c.Int(nullable: false));
            CreateIndex("dbo.DatosEmpleado", "DatosEmpresaID");
            AddForeignKey("dbo.DatosEmpleado", "DatosEmpresaID", "dbo.DatosEmpresa", "DatosEmpresaID", cascadeDelete: true);
            DropColumn("dbo.DatosEmpleado", "EmpresaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DatosEmpleado", "EmpresaID", c => c.Int(nullable: false));
            DropForeignKey("dbo.DatosEmpleado", "DatosEmpresaID", "dbo.DatosEmpresa");
            DropIndex("dbo.DatosEmpleado", new[] { "DatosEmpresaID" });
            AlterColumn("dbo.DatosEmpleado", "DatosEmpresaID", c => c.Int());
            RenameColumn(table: "dbo.DatosEmpleado", name: "DatosEmpresaID", newName: "DatosEmpresa_DatosEmpresaID");
            CreateIndex("dbo.DatosEmpleado", "DatosEmpresa_DatosEmpresaID");
            AddForeignKey("dbo.DatosEmpleado", "DatosEmpresa_DatosEmpresaID", "dbo.DatosEmpresa", "DatosEmpresaID");
        }
    }
}
