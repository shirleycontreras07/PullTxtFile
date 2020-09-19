using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pull.Models
{
    public class DatosEmpresa
    {
        
        
        [Key]
        public int DatosEmpresaID { get; set; }

        public string TipoRegistro { get; set; }

        public string TipoArchivo { get; set; }

        public string Identificacion { get; set; }

        public string Periodo { get; set; }

     
    }
}