using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.DB
{
    public class PuestoDB
    {
        public void Insertar(Puesto Puesto)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_InsertarPuesto";
                comando.Parameters.AddWithValue("@Codigo",Puesto.Codigo );
                comando.Parameters.AddWithValue("@Nombre",Puesto.Nombre );
                comando.Parameters.AddWithValue("@Estado",Puesto.Estado );



                db.ExecuteNonQuery(comando);
            }
        }

        public void Actualizar(Puesto Puesto)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ActualizarEmpresa";
                comando.Parameters.AddWithValue("@Codigo", Puesto.Codigo);
                comando.Parameters.AddWithValue("@Nombre", Puesto.Nombre);
                comando.Parameters.AddWithValue("@Estado", Puesto.Estado);

                db.ExecuteNonQuery(comando);
            }
        }

        public static List<Puesto> SeleccionarTodos()
        {
            List<Puesto> lista = new List<Puesto>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarPuestoAll";

                DataSet ds = db.ExecuteDataSet(comando);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Puesto oPuesto = new Puesto();
                    oPuesto.Codigo = Convert.ToInt32(dr["Codigo"]);
                    oPuesto.Nombre = dr["Nombre"].ToString();
                    oPuesto.Estado = Convert.ToInt32(dr["Estado"]);
                    lista.Add(oPuesto);

                }


            }

            return lista;
        }


        public static Puesto SeleccionarPorId(int Codigo)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarPuestoPorID";
                comando.Parameters.AddWithValue("@Codigo", Codigo);

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Puesto oPuesto = new Puesto();
                    oPuesto.Codigo = Convert.ToInt32(dr["Codigo"]);
                    oPuesto.Nombre = dr["Nombre"].ToString();
                    oPuesto.Estado = Convert.ToInt32(dr["Estado"]);
                    return oPuesto;

                }


            }
            return null;
        }



        public void Eliminar(int Codigo)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_EliminarPuestoPorId";
                comando.Parameters.AddWithValue("@Codigo ", Codigo);

                db.ExecuteNonQuery(comando);
            }
        }
    }
}
