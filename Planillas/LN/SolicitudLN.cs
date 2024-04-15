using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.LN
{
    public class SolicitudLN
    {
        public void Guardar(Solicitud_de_Vacaciones Solicitud_De_Vacaciones)
        {
            Solicitud_de_Vacaiones_DB db = new Solicitud_de_Vacaiones_DB();
            // Preguntar si la solicitud existe
            if (Solicitud_de_Vacaiones_DB.SeleccionarPorId(Solicitud_De_Vacaciones.IDsolicitud) == null)
            {
                db.Insertar(Solicitud_De_Vacaciones);
            }
            else
            {
                db.Actualizar(Solicitud_De_Vacaciones);
            }
        }

        public void Eliminar(int Codigo)
        {
            Solicitud_de_Vacaiones_DB db = new Solicitud_de_Vacaiones_DB();
            db.Eliminar(Codigo);
        }

        public List<Solicitud_de_Vacaciones> ObtenerTodos()
        {
            return Solicitud_de_Vacaiones_DB.SeleccionarTodos();
        }

        public List<Solicitud_de_Vacaciones> ObtenerPorSupervisor(int SupervisorID)
        {
            Solicitud_de_Vacaiones_DB db = new Solicitud_de_Vacaiones_DB();
            return db.SeleccionarPorSupervisor(SupervisorID);
        }
    }
}
