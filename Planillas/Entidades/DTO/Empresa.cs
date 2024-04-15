using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.Entidades.DTO
{
    public class Empresa
    {
        public int ID { get; set; }
        public string TipoIdentificacion { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string Direccion { get; set; }
        public byte[] Logo { get; set; }
        public int Estado { get; set; }

    }
}
