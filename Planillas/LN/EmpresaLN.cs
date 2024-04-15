using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.LN
{
    public class EmpresaLN
    {
        public void Guardar(Empresa Empresa)
        {
            EmpresaDB db = new EmpresaDB();
            // Preguntar si la empresa existe
            if (EmpresaDB.SeleccionarPorId(Empresa.ID) == null)
            {
                db.Insertar(Empresa);
            }
            else
            {
                db.Actualizar(Empresa);
            }
        }

        public void Eliminar(int id)
        {
            EmpresaDB db = new EmpresaDB();
            db.Eliminar(id);
        }

        public List<Empresa> ObtenerTodos()
        {
            return EmpresaDB.SeleccionarTodos();
        }
    }
}
