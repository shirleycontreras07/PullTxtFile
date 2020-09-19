 using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pull.Models
{
    public class DatosEmpleado
    {
        [Key]
        public int DatosEmpleadoId { get; set; }



        public string IdEmpresa { get; set; }
        
        public string TipoRegistro { get; set; }

        public string TipoIdEmpleado { get; set; }

        public string EmpleadoId { get; set; }

        public string Sueldo { get; set; }

        public string SueldoNeto { get; set; }

        public string NoSeguridadSocial { get; set; }

   
    }

}
