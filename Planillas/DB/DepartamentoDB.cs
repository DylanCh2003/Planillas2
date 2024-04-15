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
    public class DepartamentoDB
    {
        public void Insertar(Departamento Departamento)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_InsertarDepartamento";
                comando.Parameters.AddWithValue("@ID", Departamento.ID);
                comando.Parameters.AddWithValue("@Nombre", Departamento.Nombre);
                comando.Parameters.AddWithValue("@Activo", Departamento.Activo);



                db.ExecuteNonQuery(comando);
            }
        }

        public void Actualizar(Departamento Departamento)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ActualizarDepartamento";
                comando.Parameters.AddWithValue("@ID", Departamento.ID);
                comando.Parameters.AddWithValue("@Nombre", Departamento.Nombre);
                comando.Parameters.AddWithValue("@Activo", Departamento.Activo);

                db.ExecuteNonQuery(comando);
            }
        }

        public static List<Departamento> SeleccionarTodos()
        {
            List<Departamento> lista = new List<Departamento>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarDepartamentoAll";

                DataSet ds = db.ExecuteDataSet(comando);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Departamento oDepartamento = new Departamento();
                    oDepartamento.ID = Convert.ToInt32(dr["ID"]);
                    oDepartamento.Nombre = dr["Nombre"].ToString();
                    oDepartamento.Activo = Convert.ToInt32(dr["Activo"]);
                    lista.Add(oDepartamento);

                }



            }

            return lista;
        }


        public static Departamento SeleccionarPorId(int ID)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarDepartamentoPorID ";
                comando.Parameters.AddWithValue("@ID", ID);

                DataSet ds = db.ExecuteDataSet(comando);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Departamento oDepartamento = new Departamento();
                    oDepartamento.ID = Convert.ToInt32(dr["ID"]);
                    oDepartamento.Nombre = dr["Nombre"].ToString();
                    oDepartamento.Activo = Convert.ToInt32(dr["Activo"]);
                    return oDepartamento;

                }



            }
            return null;
        }



        public void Eliminar(int ID)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_EliminarDepartamentoPorId";
                comando.Parameters.AddWithValue("@ID  ", ID);

                db.ExecuteNonQuery(comando);
            }
        }
    }
}
