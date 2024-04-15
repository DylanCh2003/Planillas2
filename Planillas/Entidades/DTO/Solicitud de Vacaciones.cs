using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.Entidades.DTO
{
    public class Solicitud_de_Vacaciones
    {
        public int IDColaborador { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public int CantidadDias { get; set; }
        public string Observaciones { get; set; }
        public int Estado { get; set; }
        public int IDsolicitud { get; set; }
    }
}
