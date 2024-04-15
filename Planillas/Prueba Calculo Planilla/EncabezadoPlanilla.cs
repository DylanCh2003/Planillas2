using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas
{
    public class EncabezadoPlanilla
    {

        public int ID { get; set; }
        public int IDColaborador { get; set; }
        public double HorasLaboradas { get; set; }
        //public double Deduccion { get; set; }
        public double TotalDeducciones { get; set; }
        public double TotalPercepciones { get; set; }
        //public double SalarioXhora { get; set; }
        public double SalarioBase { get; set; }
        public double SalarioNeto { get; set; }

    }
}
