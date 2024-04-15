using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.Prueba_Calculo_Planilla
{
    public class EncPlanillaDB
    {
        public void Insertar(EncabezadoPlanilla EncPlanilla)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_EncPlanilla";
                comando.Parameters.AddWithValue("@IDEncPlanilla", EncPlanilla.ID);
                comando.Parameters.AddWithValue("@IDColaborador",EncPlanilla.IDColaborador);
                comando.Parameters.AddWithValue("@HorasTrabajadas",EncPlanilla.HorasLaboradas);
                comando.Parameters.AddWithValue("@SalarioBase",EncPlanilla.SalarioBase);
                comando.Parameters.AddWithValue("@SalarioNeto",EncPlanilla.SalarioNeto);
                comando.Parameters.AddWithValue("@TotalDeducciones", EncPlanilla.TotalDeducciones);
                comando.Parameters.AddWithValue("@TotalPercepcion",EncPlanilla.TotalPercepciones);




                db.ExecuteNonQuery(comando);
            }
        }

        public void Actualizar(EncabezadoPlanilla EncPlanilla)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ActualizarEncPlanilla";
                comando.Parameters.AddWithValue("@IDEncPlanilla", EncPlanilla.ID);
                comando.Parameters.AddWithValue("@IDColaborador", EncPlanilla.IDColaborador);
                comando.Parameters.AddWithValue("@HorasTrabajadas", EncPlanilla.HorasLaboradas);
                comando.Parameters.AddWithValue("@SalarioBase", EncPlanilla.SalarioBase);
                comando.Parameters.AddWithValue("@SalarioNeto", EncPlanilla.SalarioNeto);
                comando.Parameters.AddWithValue("@TotalDeducciones", EncPlanilla.TotalDeducciones);
                comando.Parameters.AddWithValue("@TotalPercepcion", EncPlanilla.TotalPercepciones);




                db.ExecuteNonQuery(comando);
            }
        }


        public static List<EncabezadoPlanilla> SeleccionarTodos()
        {
            List<EncabezadoPlanilla> lista = new List<EncabezadoPlanilla>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "usp_SELECT_EncPlanilla_All";

                DataSet ds = db.ExecuteDataSet(comando);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    EncabezadoPlanilla oEncPlanilla = new EncabezadoPlanilla();
                    oEncPlanilla.ID = Convert.ToInt32(dr["IDEncPlanilla"]);
                    oEncPlanilla.IDColaborador = Convert.ToInt32(dr["IDColaborador"]);
                    oEncPlanilla.HorasLaboradas = double.Parse(dr["HorasTrabajadas"].ToString());
                    oEncPlanilla.SalarioBase = double.Parse(dr["SalarioBase"].ToString());
                    oEncPlanilla.SalarioNeto = double.Parse(dr["SalarioNeto"].ToString());
                    oEncPlanilla.TotalDeducciones = double.Parse(dr["TotalDeducciones"].ToString());
                    oEncPlanilla.TotalPercepciones = double.Parse(dr["TotalPercepcion"].ToString());
                    lista.Add(oEncPlanilla);

                }


            }

            return lista;
        }


        public static EncabezadoPlanilla SeleccionarPorId(int ID)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_Seleccionar_EncPlanilla_ByID";
                comando.Parameters.AddWithValue("@IDEncPlanilla", ID);

                DataSet ds = db.ExecuteDataSet(comando);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    EncabezadoPlanilla oEncPlanilla = new EncabezadoPlanilla();
                    oEncPlanilla.ID = Convert.ToInt32(dr["IDEncPlanilla"]);
                    oEncPlanilla.IDColaborador = Convert.ToInt32(dr["IDColaborador"]);
                    oEncPlanilla.HorasLaboradas = double.Parse(dr["HorasTrabajadas"].ToString());
                    oEncPlanilla.SalarioBase = double.Parse(dr["SalarioBase"].ToString());
                    oEncPlanilla.SalarioNeto = double.Parse(dr["SalarioNeto"].ToString());
                    oEncPlanilla.TotalDeducciones = double.Parse(dr["TotalDeducciones"].ToString());
                    oEncPlanilla.TotalPercepciones = double.Parse(dr["TotalPercepcion"].ToString());
                    return oEncPlanilla;

                }



            }
            return null;
        }


    }
}
