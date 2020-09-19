namespace Pull.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DatosEmpleado",
                c => new
                    {
                        DatosEmpleadoId = c.Int(nullable: false, identity: true),
                        EmpresaID = c.Int(nullable: false),
                        TipoRegistro = c.String(),
                        TipoIdEmpleado = c.String(),
                        EmpleadoId = c.String(),
                        Sueldo = c.String(),
                        SueldoNeto = c.String(),
                        NoSeguridadSocial = c.String(),
                        DatosEmpresa_DatosEmpresaID = c.Int(),
                    })
                .PrimaryKey(t => t.DatosEmpleadoId)
                .ForeignKey("dbo.DatosEmpresa", t => t.DatosEmpresa_DatosEmpresaID)
                .Index(t => t.DatosEmpresa_DatosEmpresaID);
            
            CreateTable(
                "dbo.DatosEmpresa",
                c => new
                    {
                        DatosEmpresaID = c.Int(nullable: false, identity: true),
                        TipoRegistro = c.String(),
                        TipoArchivo = c.String(),
                        Identificacion = c.String(),
                        Periodo = c.String(),
                    })
                .PrimaryKey(t => t.DatosEmpresaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DatosEmpleado", "DatosEmpresa_DatosEmpresaID", "dbo.DatosEmpresa");
            DropIndex("dbo.DatosEmpleado", new[] { "DatosEmpresa_DatosEmpresaID" });
            DropTable("dbo.DatosEmpresa");
            DropTable("dbo.DatosEmpleado");
        }
    }
}
