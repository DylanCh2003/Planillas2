using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Planillas.LN;

namespace Planillas.DB
{
    public class DeduccionesYPercepcionesXColaboradorDB
    {


        public List<DeduccionesYPercepciones> SeleccionarTodos()
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

        public DeduccionesYPercepciones SeleccionarPorId(int Codigo)
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


        public List<DeduccionesYPercepciones> SeleccionarPorColaborador(string id)
        {
            List<DeduccionesYPercepciones> lista = new List<DeduccionesYPercepciones>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarDeduccionesYPercepcionesXColaborador_ByIDColaborador";
                comando.Parameters.AddWithValue("@IDColaborador", id);

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


        public int SeleccionarPorColaboradorDeduccion2(string id)
        {
            int Subtotal = 0;
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarDeduccionesYPercepcionesXColaborador_ByIDColaborador";
                comando.Parameters.AddWithValue("@IDColaborador", id);

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DeduccionesYPercepciones oDeduccionesPercepciones = new DeduccionesYPercepciones();
                    oDeduccionesPercepciones.Codigo = Convert.ToInt32(dr["Codigo"]);
                    oDeduccionesPercepciones.Nombre = dr["Nombre"].ToString();
                    oDeduccionesPercepciones.Tipo = dr["Tipo"].ToString();
                    oDeduccionesPercepciones.Valor = Convert.ToInt32(dr["Valor"].ToString());
                    oDeduccionesPercepciones.TipoValor = dr["TipoValor"].ToString();

                    if (oDeduccionesPercepciones.Tipo == "Deduccion")
                    {
                        Subtotal += oDeduccionesPercepciones.Valor;
                    }

                }
            }
            return Subtotal;
        }


        public int SeleccionarPorColaboradorPercepcion2(string id)
        {
            int Subtotal = 0;
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarDeduccionesYPercepcionesXColaborador_ByIDColaborador";
                comando.Parameters.AddWithValue("@IDColaborador", id);

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    DeduccionesYPercepciones oDeduccionesPercepciones = new DeduccionesYPercepciones();
                    oDeduccionesPercepciones.Codigo = Convert.ToInt32(dr["Codigo"]);
                    oDeduccionesPercepciones.Nombre = dr["Nombre"].ToString();
                    oDeduccionesPercepciones.Tipo = dr["Tipo"].ToString();
                    oDeduccionesPercepciones.Valor = Convert.ToInt32(dr["Valor"].ToString());
                    oDeduccionesPercepciones.TipoValor = dr["TipoValor"].ToString();

                    if (oDeduccionesPercepciones.Tipo == "Percepcion")
                    {
                        Subtotal += oDeduccionesPercepciones.Valor;
                    }

                }
            }
            return Subtotal;
        }



        public void InsertarDeduccionPercepcionXColab(int DeduccionYPercepcionesID, int ColaboradorID, string Prioridad, int Estado)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_InsertarDeduccionesYPercepcionesXColaborador";
                comando.Parameters.AddWithValue("@CodigoDeduccionPercecion", DeduccionYPercepcionesID);
                comando.Parameters.AddWithValue("@IDColaborador", ColaboradorID);
                comando.Parameters.AddWithValue("@Prioridad", Prioridad);
                comando.Parameters.AddWithValue("@Estado", Estado);

                db.ExecuteNonQuery(comando);
            }
        }
        public void EliminarDeduccionPercepcionXColab(int DeduccionYPercepcionesID)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_EliminarDeduccionesYPercepcionesXColaborador_ByID";
                comando.Parameters.AddWithValue("@CodigoDeduccionPercecion  ", DeduccionYPercepcionesID);

                db.ExecuteNonQuery(comando);
            }
        }


        //--------------------------------------- Prueba -------------------------------------------------------------------
        public DeduccionesYPercepcionesXColaborador GetDeduccionPercepcionById(int pIdTipoExamenMedico)
        {
            DeduccionesYPercepcionesXColaborador oDeduccionesPercepciones = null;
            SqlCommand command = new SqlCommand();
            IDataReader dr;
            
                string sql = @" select * from DeduccionesYPercepcionesXColaborador where CodigoDeduccionPercecion = @CodigoDeduccionPercecion";
                command.Parameters.AddWithValue("@CodigoDeduccionPercecion", pIdTipoExamenMedico);
                command.CommandText = sql;
                command.CommandType = CommandType.Text;

                using (IDataBase db = FactoryDatabase.CreateDataBase(FactoryConexion.CreateConnection()))
                {
                    dr = db.ExecuteReader(command);
                    // Si devolvió filas
                    if (dr != null)
                    {

                        // Iterar en todas las filas y Mapearlas
                        while (dr.Read())
                        {
                            oDeduccionesPercepciones = new DeduccionesYPercepcionesXColaborador();
                            oDeduccionesPercepciones.CodigoDP = Convert.ToInt32(dr["CodigoDeduccionPercecion"]);
                            oDeduccionesPercepciones.ColaboradorID = Convert.ToInt32(dr["IDColaborador"]);
                            oDeduccionesPercepciones.Prioridad = dr["Prioridad"].ToString();
                            oDeduccionesPercepciones.Estado = Convert.ToInt32(dr["Estado"]);


                        }
                    }
                }
                return oDeduccionesPercepciones;
 
        }
    }
}
