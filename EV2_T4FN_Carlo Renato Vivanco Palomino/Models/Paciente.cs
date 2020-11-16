using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EV2_T4FN_Carlo_Renato_Vivanco_Palomino.Models
{
    public class Paciente
    {
        [Display(Name = "Codigo del Paciente", Order = 0)]
        public int codigoPaciente { get; set; }

        [Display(Name = "Apellidos", Order = 1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe completar el campo apellido")]
        public string apellidos { get; set; }

        [Display(Name = "Nombre", Order = 2)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe completar el campo nombre")]
        public string nombres { get; set; } 

        [Display(Name = "Dni", Order = 3)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Es necesario ingresar su dni")]
        public string dni { get; set; }

        [Display(Name = "Fecha de Nacimiento", Order = 4)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe completar el campo Fecha de Nacimiento")]
        public DateTime fecNac { get; set; }

        [Display(Name = "Sexo", Order = 5)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe completar el campo sexo")]
        [RegularExpression(@"[FM]{1}", ErrorMessage = "Este campo solo es de una sola letra (F o M)")]
        public string sexo { get; set; }

        [Display(Name = "Estado Actual", Order = 6)]
        public string estado { get; set; }

        [Display(Name = "Fecha de Registro", Order = 7)]
        public DateTime fecRegistro { get; set; }
    }
}