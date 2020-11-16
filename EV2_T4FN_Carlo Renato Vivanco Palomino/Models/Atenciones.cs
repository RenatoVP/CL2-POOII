using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EV2_T4FN_Carlo_Renato_Vivanco_Palomino.Models
{
    public class Atenciones
    {
        public int codigoAtencion { get; set; }
        public string codigoMedico { get; set; }
        public int codigoPaciente { get; set; }
        public int codigoCentro { get; set; }
        public DateTime FechaAtencion { get; set; }
        public DateTime HoraAtencion { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}