namespace Pull.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DatosEmpleado", "IdEmpresa", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DatosEmpleado", "IdEmpresa");
        }
    }
}
