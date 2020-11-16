using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EV2_T4FN_Carlo_Renato_Vivanco_Palomino.Models
{
    public class Centros
    {
        [Display(Name = "Codigo de Centro", Order = 0)]
        public int codigoCentro { get; set; }

        [Display(Name = "Nombre", Order = 1)]
        public string NombreCentro { get; set; }

        [Display(Name = "Nombre", Order = 2)]
        public string Distrito { get; set; } 

        [Display(Name = "Nombre", Order = 3)]
        public string telefono { get; set; }

        [Display(Name = "Nombre", Order = 4)]
        public string estado { get; set; }

        [Display(Name = "Nombre", Order = 5)]
        public DateTime fechaRegistro { get; set; }
    }
}