using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.LN
{
    public class PuestoLN
    {
        public void Guardar(Puesto Puesto)
        {
            PuestoDB db = new PuestoDB();
            // Preguntar si el puesto existe
            if (PuestoDB.SeleccionarPorId(Puesto.Codigo) == null)
            {
                db.Insertar(Puesto);
            }
            else
            {
                db.Actualizar(Puesto);
            }
        }

        public void Eliminar(int Codigo)
        {
            PuestoDB db = new PuestoDB();
            db.Eliminar(Codigo);
        }

        public List<Puesto> ObtenerTodos()
        {
            return PuestoDB.SeleccionarTodos();
        }
    }
}
