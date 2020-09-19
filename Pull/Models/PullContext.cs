using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Pull.Models
{
    public class PullContext : DbContext
    {
        public PullContext() : base("PullContext")
        {

        }

        public DbSet<DatosEmpresa> DatosEmpresa { get; set; }
        public DbSet<DatosEmpleado> DatosEmpleado { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}