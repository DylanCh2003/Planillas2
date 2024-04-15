using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas
{
    public class DeduccionesYPercepciones
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public int Valor { get; set; }
        public string TipoValor { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
