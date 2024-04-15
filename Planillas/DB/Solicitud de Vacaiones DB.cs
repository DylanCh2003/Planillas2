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
    public class Solicitud_de_Vacaiones_DB
    {
        public void Insertar(Solicitud_de_Vacaciones solicitud_De_Vacaciones)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_InsertarSolicitud";
                comando.Parameters.AddWithValue("@IDColaborador", solicitud_De_Vacaciones.IDColaborador);
                comando.Parameters.AddWithValue("@FechaSolicitud", solicitud_De_Vacaciones.FechaSolicitud);
                comando.Parameters.AddWithValue("@FechaDesde", solicitud_De_Vacaciones.FechaDesde);
                comando.Parameters.AddWithValue("@FechaHasta", solicitud_De_Vacaciones.FechaHasta);
                comando.Parameters.AddWithValue("@CantidadDias", solicitud_De_Vacaciones.CantidadDias);
                comando.Parameters.AddWithValue("@Observaciones", solicitud_De_Vacaciones.Observaciones);
                comando.Parameters.AddWithValue("@Estado", solicitud_De_Vacaciones.Estado);
                comando.Parameters.AddWithValue("@IDsoliicitud", solicitud_De_Vacaciones.IDsolicitud);



                db.ExecuteNonQuery(comando);
            }
        }

        public void Actualizar(Solicitud_de_Vacaciones solicitud_De_Vacaciones)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ActualizarSolicitud";
                comando.Parameters.AddWithValue("@IDColaborador", solicitud_De_Vacaciones.IDColaborador);
                comando.Parameters.AddWithValue("@FechaSolicitud", solicitud_De_Vacaciones.FechaSolicitud);
                comando.Parameters.AddWithValue("@FechaDesde", solicitud_De_Vacaciones.FechaDesde);
                comando.Parameters.AddWithValue("@FechaHasta", solicitud_De_Vacaciones.FechaHasta);
                comando.Parameters.AddWithValue("@CantidadDias", solicitud_De_Vacaciones.CantidadDias);
                comando.Parameters.AddWithValue("@Observaciones", solicitud_De_Vacaciones.Observaciones);
                comando.Parameters.AddWithValue("@Estado", solicitud_De_Vacaciones.Estado);
                comando.Parameters.AddWithValue("@IDsoliicitud", solicitud_De_Vacaciones.IDsolicitud);


                db.ExecuteNonQuery(comando);
            }
        }

        public static List<Solicitud_de_Vacaciones> SeleccionarTodos()
        {
            List<Solicitud_de_Vacaciones> lista = new List<Solicitud_de_Vacaciones>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarSolicitudAll";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Solicitud_de_Vacaciones solicitud_De_Vacacione = new Solicitud_de_Vacaciones();
                    solicitud_De_Vacacione.IDColaborador = Convert.ToInt32(dr["IDColaborador"]);
                    solicitud_De_Vacacione.FechaSolicitud = DateTime.Parse(dr["FechaSolicitud"].ToString());
                    solicitud_De_Vacacione.FechaDesde = DateTime.Parse(dr["FechaDesde"].ToString());
                    solicitud_De_Vacacione.FechaHasta = DateTime.Parse(dr["FechaHasta"].ToString());
                    solicitud_De_Vacacione.CantidadDias = Convert.ToInt32(dr["CantidadDias"].ToString());
                    solicitud_De_Vacacione.Observaciones = dr["Observaciones"].ToString();
                    solicitud_De_Vacacione.Estado = Convert.ToInt32(dr["Estado"]);
                    solicitud_De_Vacacione.IDsolicitud = Convert.ToInt32(dr["IDsoliicitud"]);
                    lista.Add(solicitud_De_Vacacione);
                }

            }
            return lista;
        }


        public static Solicitud_de_Vacaciones SeleccionarPorId(int IDsoliicitud)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarSolicitudPorID";
                comando.Parameters.AddWithValue("@IDsoliicitud", IDsoliicitud);

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Solicitud_de_Vacaciones solicitud_De_Vacacione = new Solicitud_de_Vacaciones();
                    solicitud_De_Vacacione.IDColaborador = Convert.ToInt32(dr["IDColaborador"]);
                    solicitud_De_Vacacione.FechaSolicitud = DateTime.Parse(dr["FechaSolicitud"].ToString());
                    solicitud_De_Vacacione.FechaDesde = DateTime.Parse(dr["FechaDesde"].ToString());
                    solicitud_De_Vacacione.FechaHasta = DateTime.Parse(dr["FechaHasta"].ToString());
                    solicitud_De_Vacacione.CantidadDias = Convert.ToInt32(dr["CantidadDias"].ToString());
                    solicitud_De_Vacacione.Observaciones = dr["Observaciones"].ToString();
                    solicitud_De_Vacacione.Estado = Convert.ToInt32(dr["Estado"]);
                    solicitud_De_Vacacione.IDsolicitud = Convert.ToInt32(dr["IDsoliicitud"]);
                    return solicitud_De_Vacacione;

                }

            }
            return null;
        }

        public void Eliminar(int IDsoliicitud)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_EliminarSolicitudPorId";
                comando.Parameters.AddWithValue("@IDsoliicitud ", IDsoliicitud);

                db.ExecuteNonQuery(comando);
            }
        }

//-------------------------- Aprobacione de Solicitud ------------------------------------


        public  List<Solicitud_de_Vacaciones> SeleccionarPorSupervisor(int supervisorID)
        {
            List<Solicitud_de_Vacaciones> lista = new List<Solicitud_de_Vacaciones>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand("PA_ObtenerSolicitudesVacacionesPorSupervisor");
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@SupervisorID", supervisorID);

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Solicitud_de_Vacaciones solicitud_De_Vacacione = new Solicitud_de_Vacaciones();
                    solicitud_De_Vacacione.IDColaborador = Convert.ToInt32(dr["IDColaborador"]);
                    solicitud_De_Vacacione.FechaSolicitud = DateTime.Parse(dr["FechaSolicitud"].ToString());
                    solicitud_De_Vacacione.FechaDesde = DateTime.Parse(dr["FechaDesde"].ToString());
                    solicitud_De_Vacacione.FechaHasta = DateTime.Parse(dr["FechaHasta"].ToString());
                    solicitud_De_Vacacione.CantidadDias = Convert.ToInt32(dr["CantidadDias"].ToString());
                    solicitud_De_Vacacione.Observaciones = dr["Observaciones"].ToString();
                    solicitud_De_Vacacione.IDsolicitud = Convert.ToInt32(dr["IDsoliicitud"]);
                    solicitud_De_Vacacione.Estado = Convert.ToInt32(dr["Estado"]);
                    lista.Add(solicitud_De_Vacacione);
                }

            }
            return lista;
        }


    }
}

