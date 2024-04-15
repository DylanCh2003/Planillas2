using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas
{
    public class Marcas
    {
        public int ID { get; set; }
        public DateTime? Entrada { get; set; }
        public DateTime? Salida { get; set; }
        public DateTime Fecha { get; set; }
        public double CantHoras { get; set; }
    }
}
