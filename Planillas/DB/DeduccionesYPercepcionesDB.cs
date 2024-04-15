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
    public class DeduccionesYPercepcionesDB
    {
        public void Insertar(DeduccionesYPercepciones DeduccionesYPercepciones)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_InsertarDeduccionesYPercepciones";
                comando.Parameters.AddWithValue("@Codigo", DeduccionesYPercepciones.Codigo);
                comando.Parameters.AddWithValue("@Nombre", DeduccionesYPercepciones.Nombre);
                comando.Parameters.AddWithValue("@Tipo", DeduccionesYPercepciones.Tipo);
                comando.Parameters.AddWithValue("@Valor", DeduccionesYPercepciones.Valor);
                comando.Parameters.AddWithValue("@TipoValor", DeduccionesYPercepciones.TipoValor);




                db.ExecuteNonQuery(comando);
            }
        }

        public void Actualizar(DeduccionesYPercepciones DeduccionesYPercepciones)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ActualizarDeduccionesPercepciones";
                comando.Parameters.AddWithValue("@Codigo", DeduccionesYPercepciones.Codigo);
                comando.Parameters.AddWithValue("@Nombre", DeduccionesYPercepciones.Nombre);
                comando.Parameters.AddWithValue("@Tipo", DeduccionesYPercepciones.Tipo);
                comando.Parameters.AddWithValue("@Valor", DeduccionesYPercepciones.Valor);
                comando.Parameters.AddWithValue("@TipoValor", DeduccionesYPercepciones.TipoValor);


                db.ExecuteNonQuery(comando);
            }
        }

        public static List<DeduccionesYPercepciones> SeleccionarTodos()
        {
            List<DeduccionesYPercepciones> lista = new List<DeduccionesYPercepciones>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarDeduccionesPercepciones_All";

                DataSet ds = db.ExecuteDataSet(comando);
           
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DeduccionesYPercepciones oDeduccionesPercepciones = new DeduccionesYPercepciones();
                    oDeduccionesPercepciones.Codigo = Convert.ToInt32(dr["Codigo"]);
                    oDeduccionesPercepciones.Nombre = dr["Nombre"].ToString();
                    oDeduccionesPercepciones.Tipo = dr["Tipo"].ToString();
                    oDeduccionesPercepciones.Valor = Convert.ToInt32(dr["Valor"].ToString());
                    oDeduccionesPercepciones.TipoValor = dr["TipoValor"].ToString();
                    lista.Add(oDeduccionesPercepciones);

                }



            }

            return lista;
        }


        public static DeduccionesYPercepciones SeleccionarPorId(int Codigo)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarDeduccionesPercepciones_ByID ";
                comando.Parameters.AddWithValue("@Codigo", Codigo);

                DataSet ds = db.ExecuteDataSet(comando);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DeduccionesYPercepciones oDeduccionesPercepciones = new DeduccionesYPercepciones();
                    oDeduccionesPercepciones.Codigo = Convert.ToInt32(dr["Codigo"]);
                    oDeduccionesPercepciones.Nombre = dr["Nombre"].ToString();
                    oDeduccionesPercepciones.Tipo = dr["Tipo"].ToString();
                    oDeduccionesPercepciones.Valor = Convert.ToInt32(dr["Valor"].ToString());
                    oDeduccionesPercepciones.TipoValor = dr["TipoValor"].ToString();
                    return oDeduccionesPercepciones;

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
                comando.CommandText = "PA_EliminarDeduccionesPercepciones_ByID";
                comando.Parameters.AddWithValue("@Codigo  ", Codigo);

                db.ExecuteNonQuery(comando);
            }
        }
    }
}
