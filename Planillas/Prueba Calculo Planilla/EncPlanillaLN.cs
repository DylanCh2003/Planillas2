using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.Prueba_Calculo_Planilla
{
    public class EncPlanillaLN
    {
        public void Guardar(EncabezadoPlanilla EncabezadoPlanilla)
        {
            EncPlanillaDB db = new EncPlanillaDB();
            // Preguntar si el colaborador existe
            if (EncPlanillaDB.SeleccionarPorId(EncabezadoPlanilla.ID) == null)
            {
                db.Insertar(EncabezadoPlanilla);
            }
            else
            {
                db.Actualizar(EncabezadoPlanilla);
            }
        }

        public List<EncabezadoPlanilla> ObtenerTodos()
        {
            return EncPlanillaDB.SeleccionarTodos();
        }


    }
}
