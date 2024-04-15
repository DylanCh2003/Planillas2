using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.LN
{
    public class DepartamentoLN
    {
        public void Guardar(Departamento Depatamento)
        {
            DepartamentoDB db = new DepartamentoDB();
            // Preguntar si ell departamento existe
            if (DepartamentoDB.SeleccionarPorId(Depatamento.ID) == null)
            {
                db.Insertar(Depatamento);
            }
            else
            {
                db.Actualizar(Depatamento);
            }
        }

        public void Eliminar(int id)
        {
            DepartamentoDB db = new DepartamentoDB();
            db.Eliminar(id);
        }

        public List<Departamento> ObtenerTodos()
        {
            return DepartamentoDB.SeleccionarTodos();
        }
    }
}
