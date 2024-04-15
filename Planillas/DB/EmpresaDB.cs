using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planillas.DB
{
    public class EmpresaDB
    {
        public void Insertar(Empresa Empresa)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_InsertarEmpresa";
                comando.Parameters.AddWithValue("@Id", Empresa.ID);
                comando.Parameters.AddWithValue("@TipoIdentificacion", Empresa.TipoIdentificacion);
                comando.Parameters.AddWithValue("@Nombre", Empresa.Nombre);
                comando.Parameters.AddWithValue("@Telefono", Empresa.Telefono);
                comando.Parameters.AddWithValue("@Direccion", Empresa.Direccion);
                comando.Parameters.AddWithValue("@LogoEmpresa", Empresa.Logo);
                comando.Parameters.AddWithValue("@Estado", Empresa.Estado);


                db.ExecuteNonQuery(comando);
            }
        }

        public void Actualizar(Empresa Empresa)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ActualizarEmpresa";
                comando.Parameters.AddWithValue("@Id", Empresa.ID);
                comando.Parameters.AddWithValue("@TipoIdentificacion", Empresa.TipoIdentificacion);
                comando.Parameters.AddWithValue("@Nombre", Empresa.Nombre);
                comando.Parameters.AddWithValue("@Telefono", Empresa.Telefono);
                comando.Parameters.AddWithValue("@Direccion",Empresa.Direccion);
                comando.Parameters.AddWithValue("@LogoEmpresa", Empresa.Logo);
                comando.Parameters.AddWithValue("@Estado", Empresa.Estado);

                db.ExecuteNonQuery(comando);
            }
        }

        public static List<Empresa> SeleccionarTodos()
        {
            List<Empresa> lista = new List<Empresa>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarEmpresaAll";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Empresa oEmpresa = new Empresa();
                    oEmpresa.ID = Convert.ToInt32(dr["ID"]);
                    oEmpresa.TipoIdentificacion = dr["TipoIdentificacion"].ToString();
                    oEmpresa.Nombre = dr["Nombre"].ToString();
                    oEmpresa.Telefono = Convert.ToInt32(dr["Telefono"].ToString());
                    oEmpresa.Direccion = dr["Direccion"].ToString();
                    oEmpresa.Logo = (byte[])dr["LogoEmpresa"];
                    oEmpresa.Estado = Convert.ToInt32(dr["Estado"]);
                    lista.Add(oEmpresa);

                }

            }

            return lista;
        }


        public static Empresa SeleccionarPorId(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarEmpresaPorID";
                comando.Parameters.AddWithValue("@id", id);

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Empresa oEmpresa = new Empresa();
                    oEmpresa.ID = Convert.ToInt32(dr["ID"]);
                    oEmpresa.TipoIdentificacion = dr["TipoIdentificacion"].ToString();
                    oEmpresa.Nombre = dr["Nombre"].ToString();
                    oEmpresa.Telefono = Convert.ToInt32(dr["Telefono"]);
                    oEmpresa.Direccion = dr["Direccion"].ToString();
                    oEmpresa.Logo = (byte[])dr["LogoEmpresa"];
                    oEmpresa.Estado = Convert.ToInt32(dr["Estado"]);
                    return oEmpresa;

                }

            }
            return null;
        }



        public void Eliminar(int id)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_EliminarEmpresaPorId";
                comando.Parameters.AddWithValue("@ID", id);

                db.ExecuteNonQuery(comando);
            }
        }



    }
}
