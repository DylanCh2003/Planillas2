using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.LN
{
    public class DeduccionesYPercepcionesXColaboradorLN
    {
        public static List<DeduccionesYPercepciones> GetDisponibleByDeduccion(string prodId)
        {
            var todos = GetAll(); //todos los proveedores

            var seleccionados = GetByColaboradorId2(prodId); //trae a las deducciones 
                                                             //por cada Colaborador
            var disponible = new List<DeduccionesYPercepciones>();

            foreach (var p in todos)
            {
                var existe = seleccionados.FirstOrDefault(x => x.Codigo == p.Codigo);
                if (existe == null)
                {
                    disponible.Add(p);
                }
            }
            return disponible;
        }

        public static List<DeduccionesYPercepciones> GetAll()
        {
            var db = new DeduccionesYPercepcionesXColaboradorDB();
            return db.SeleccionarTodos();

        }

        public static DeduccionesYPercepciones GetByProductId(int prodId)
        {
            var db = new DeduccionesYPercepcionesXColaboradorDB();
            return db.SeleccionarPorId(prodId);
        }

        public static List<DeduccionesYPercepciones> GetByColaboradorId2(string ColabID)
        {
            var db = new DeduccionesYPercepcionesXColaboradorDB();
            return db.SeleccionarPorColaborador(ColabID);
        }

        public void Add(int DeduccionYPercepcionesID, int ColaboradorID, string Prioridad, int Estado)
        {
            var db = new DeduccionesYPercepcionesXColaboradorDB();
            db.InsertarDeduccionPercepcionXColab(DeduccionYPercepcionesID, ColaboradorID, Prioridad, Estado);
        }


        public void Remove(int DeduccionYPercepcionesID)
        {
            var db = new DeduccionesYPercepcionesXColaboradorDB();
            db.EliminarDeduccionPercepcionXColab(DeduccionYPercepcionesID);

        }

    }
}
