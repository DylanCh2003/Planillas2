using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.LN
{
    public class ColaboradorLN
    {
        public void Guardar(Colaborador Colaborador)
        {
            ColaboradorDB db = new ColaboradorDB();
            // Preguntar si el colaborador existe
            if (ColaboradorDB.SeleccionarPorId(Colaborador.ID) == null)
            {
                db.Insertar(Colaborador);
            }
            else
            {
                db.Actualizar(Colaborador);
            }
        }

        public void Eliminar(int id)
        {
            ColaboradorDB db = new ColaboradorDB();
            db.Eliminar(id);
        }

        public List<Colaborador> ObtenerTodos()
        {
            return ColaboradorDB.SeleccionarTodos();
        }

        public Colaborador Login(string usuario, string contrasenna)
        {
            return ColaboradorDB.Login(usuario, contrasenna);
        }

        public List<Colaborador> ListaSupervisor()
        {
            return ColaboradorDB.ListaSupervisor("SUPERVISOR");
        }
    }
}
