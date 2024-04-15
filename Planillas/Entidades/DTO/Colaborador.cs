using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.Entidades.DTO
{
    public class Colaborador
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Departamento { get; set; }
        public string Rol { get; set; }
        public decimal SalarioXHora { get; set; }
        public byte[] Foto { get; set; }
        public string Correo { get; set; }
        public int Puesto { get; set; }
        public int Supervisor { get; set; }
        public string CuentaIBAN { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public int Estado { get; set; }
    }
}
