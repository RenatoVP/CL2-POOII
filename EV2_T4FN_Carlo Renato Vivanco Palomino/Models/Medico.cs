using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EV2_T4FN_Carlo_Renato_Vivanco_Palomino.Models
{
    public class Medico
    {
        public int codigoMedico { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string Especialidad { get; set; }
        public string CMP { get; set; }
        public string RNE { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}