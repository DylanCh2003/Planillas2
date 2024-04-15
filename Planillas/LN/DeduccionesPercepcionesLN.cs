using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.LN
{
    public class DeduccionesPercepcionesLN
    {
        public void Guardar(DeduccionesYPercepciones oDeduccionesPercepciones)
        {
            DeduccionesYPercepcionesDB db = new DeduccionesYPercepcionesDB();
            // Preguntar si la deduccion o percepcion existe
            if (DeduccionesYPercepcionesDB.SeleccionarPorId(oDeduccionesPercepciones.Codigo) == null)
            {
                db.Insertar(oDeduccionesPercepciones);
            }
            else
            {
                db.Actualizar(oDeduccionesPercepciones);
            }
        }

        public void Eliminar(int Codigo)
        {
            DeduccionesYPercepcionesDB db = new DeduccionesYPercepcionesDB();
            db.Eliminar(Codigo);
        }



        //-------------------------------------------------------------------------------
        public List<DeduccionesYPercepciones> ObtenerTodos()
        {
            return DeduccionesYPercepcionesDB.SeleccionarTodos();
        }


      
    }
}
