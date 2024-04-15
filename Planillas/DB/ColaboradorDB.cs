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
    public class ColaboradorDB
    {
        public void Insertar(Colaborador Colaborador)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_InsertarColaborador";
                comando.Parameters.AddWithValue("@ID", Colaborador.ID);
                comando.Parameters.AddWithValue("@Nombre", Colaborador.Nombre);
                comando.Parameters.AddWithValue("@Apellido", Colaborador.Apellido);
                comando.Parameters.AddWithValue("@FechaNacimiento", Colaborador.FechaNacimiento);
                comando.Parameters.AddWithValue("@Direccion", Colaborador.Direccion);
                comando.Parameters.AddWithValue("@FechaIngreso", Colaborador.FechaIngreso);
                comando.Parameters.AddWithValue("@Departamento", Colaborador.Departamento);
                comando.Parameters.AddWithValue("@Rol", Colaborador.Rol);
                comando.Parameters.AddWithValue("@SalarioXHora", Colaborador.SalarioXHora);
                comando.Parameters.AddWithValue("@Fotografia", Colaborador.Foto);
                comando.Parameters.AddWithValue("@Correo", Colaborador.Correo);
                comando.Parameters.AddWithValue("@Puesto", Colaborador.Puesto);
                comando.Parameters.AddWithValue("@Supervisor", Colaborador.Supervisor);
                comando.Parameters.AddWithValue("@CuentaIBAN", Colaborador.CuentaIBAN);
                comando.Parameters.AddWithValue("@Usuario", Colaborador.Usuario);
                comando.Parameters.AddWithValue("@Contraseña", Colaborador.Contraseña);
                comando.Parameters.AddWithValue("@Estado", Colaborador.Estado);



                db.ExecuteNonQuery(comando);
            }
        }

        public void Actualizar(Colaborador Colaborador)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_ActualizarColaboraddor";
                comando.Parameters.AddWithValue("@ID", Colaborador.ID);
                comando.Parameters.AddWithValue("@Nombre", Colaborador.Nombre);
                comando.Parameters.AddWithValue("@Apellido", Colaborador.Apellido);
                comando.Parameters.AddWithValue("@FechaNacimiento", Colaborador.FechaNacimiento);
                comando.Parameters.AddWithValue("@Direccion", Colaborador.Direccion);
                comando.Parameters.AddWithValue("@FechaIngreso", Colaborador.FechaIngreso);
                comando.Parameters.AddWithValue("@Departamento", Colaborador.Departamento);
                comando.Parameters.AddWithValue("@Rol", Colaborador.Rol);
                comando.Parameters.AddWithValue("@SalarioXHora", Colaborador.SalarioXHora);
                comando.Parameters.AddWithValue("@Fotografia", Colaborador.Foto);
                comando.Parameters.AddWithValue("@Correo", Colaborador.Correo);
                comando.Parameters.AddWithValue("@Puesto", Colaborador.Puesto);
                comando.Parameters.AddWithValue("@Supervisor", Colaborador.Supervisor);
                comando.Parameters.AddWithValue("@CuentaIBAN", Colaborador.CuentaIBAN);
                comando.Parameters.AddWithValue("@Usuario", Colaborador.Usuario);
                comando.Parameters.AddWithValue("@Contraseña", Colaborador.Contraseña);
                comando.Parameters.AddWithValue("@Estado", Colaborador.Estado);

                db.ExecuteNonQuery(comando);
            }
        }

        public static List<Colaborador> SeleccionarTodos()
        {
            List<Colaborador> lista = new List<Colaborador>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarColaboradorAll";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Colaborador oColaborador = new Colaborador();
                    oColaborador.ID = Convert.ToInt32(dr["ID"]);
                    oColaborador.Nombre = dr["Nombre"].ToString();
                    oColaborador.Apellido = dr["Apellido"].ToString();
                    oColaborador.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                    oColaborador.Direccion = dr["Direccion"].ToString();
                    oColaborador.FechaIngreso = DateTime.Parse(dr["FechaIngreso"].ToString());
                    oColaborador.Departamento = Convert.ToInt32(dr["Departamento"]);
                    oColaborador.Rol = dr["Rol"].ToString();
                    oColaborador.SalarioXHora = decimal.Parse(dr["SalarioXHora"].ToString());
                    oColaborador.Foto = (byte[])dr["Fotografia"];
                    oColaborador.Correo = dr["Correo"].ToString();
                    oColaborador.Puesto = Convert.ToInt32(dr["Puesto"].ToString());
                    oColaborador.Supervisor = Convert.ToInt32(dr["Supervisor"]);
                    oColaborador.CuentaIBAN = dr["CuentaIBAN"].ToString();
                    oColaborador.Usuario = dr["Usuario"].ToString();
                    oColaborador.Contraseña = dr["Contraseña"].ToString();
                    oColaborador.Estado = Convert.ToInt32(dr["Estado"]);
                    lista.Add(oColaborador);

                }

            }

            return lista;
        }


        public static Colaborador SeleccionarPorId(int ID)
        {
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarColaboradorPorID";
                comando.Parameters.AddWithValue("@ID", ID);

                DataSet ds = db.ExecuteDataSet(comando);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Colaborador oColaborador = new Colaborador();
                    oColaborador.ID = Convert.ToInt32(dr["ID"]);
                    oColaborador.Nombre = dr["Nombre"].ToString();
                    oColaborador.Apellido = dr["Apellido"].ToString();
                    oColaborador.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                    oColaborador.Direccion = dr["Direccion"].ToString();
                    oColaborador.FechaIngreso = DateTime.Parse(dr["FechaIngreso"].ToString());
                    oColaborador.Departamento = Convert.ToInt32(dr["Departamento"]);
                    oColaborador.Rol = dr["Rol"].ToString();
                    oColaborador.SalarioXHora = decimal.Parse(dr["SalarioXHora"].ToString());
                    oColaborador.Foto = (byte[])dr["Fotografia"];
                    oColaborador.Correo = dr["Correo"].ToString();
                    oColaborador.Puesto = Convert.ToInt32(dr["Puesto"].ToString());
                    oColaborador.Supervisor = Convert.ToInt32(dr["Supervisor"]);
                    oColaborador.CuentaIBAN = dr["CuentaIBAN"].ToString();
                    oColaborador.Usuario = dr["Usuario"].ToString();
                    oColaborador.Contraseña = dr["Contraseña"].ToString();
                    oColaborador.Estado = Convert.ToInt32(dr["Estado"]);
                    return oColaborador;
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
                comando.CommandText = "PA_EliminarColaboradorPorId";
                comando.Parameters.AddWithValue("@ID", ID);

                db.ExecuteNonQuery(comando);    
            }
        }

        public static List<Colaborador> ListaSupervisor(string Rol)
        {
            List<Colaborador> lista = new List<Colaborador>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarColaboradorSupervisor";
                comando.Parameters.AddWithValue("@Rol", Rol);

                DataSet ds = db.ExecuteDataSet(comando);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Colaborador oColaborador = new Colaborador();
                    oColaborador.ID = Convert.ToInt32(dr["ID"]);
                    oColaborador.Nombre = dr["Nombre"].ToString();
                    oColaborador.Apellido = dr["Apellido"].ToString();
                    oColaborador.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                    oColaborador.Direccion = dr["Direccion"].ToString();
                    oColaborador.FechaIngreso = DateTime.Parse(dr["FechaIngreso"].ToString());
                    oColaborador.Departamento = Convert.ToInt32(dr["Departamento"]);
                    oColaborador.Rol = dr["Rol"].ToString();
                    oColaborador.SalarioXHora = decimal.Parse(dr["SalarioXHora"].ToString());
                    oColaborador.Foto = (byte[])dr["Fotografia"];
                    oColaborador.Correo = dr["Correo"].ToString();
                    oColaborador.Puesto = Convert.ToInt32(dr["Puesto"].ToString());
                    oColaborador.Supervisor = Convert.ToInt32(dr["Supervisor"]);
                    oColaborador.CuentaIBAN = dr["CuentaIBAN"].ToString();
                    oColaborador.Usuario = dr["Usuario"].ToString();
                    oColaborador.Contraseña = dr["Contraseña"].ToString();
                    oColaborador.Estado = Convert.ToInt32(dr["Estado"]);
                    lista.Add(oColaborador);
                }

            }
            return lista;
        }

        public  List<Colaborador> SeleccionarTodos2()
        {
            List<Colaborador> lista = new List<Colaborador>();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarColaboradorAll";

                DataSet ds = db.ExecuteDataSet(comando);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Colaborador oColaborador = new Colaborador();
                    oColaborador.ID = Convert.ToInt32(dr["ID"]);
                    oColaborador.Nombre = dr["Nombre"].ToString();
                    oColaborador.Apellido = dr["Apellido"].ToString();
                    oColaborador.FechaNacimiento = DateTime.Parse(dr["FechaNacimiento"].ToString());
                    oColaborador.Direccion = dr["Direccion"].ToString();
                    oColaborador.FechaIngreso = DateTime.Parse(dr["FechaIngreso"].ToString());
                    oColaborador.Departamento = Convert.ToInt32(dr["Departamento"]);
                    oColaborador.Rol = dr["Rol"].ToString();
                    oColaborador.SalarioXHora = decimal.Parse(dr["SalarioXHora"].ToString());
                    oColaborador.Foto = (byte[])dr["Fotografia"];
                    oColaborador.Correo = dr["Correo"].ToString();
                    oColaborador.Puesto = Convert.ToInt32(dr["Puesto"].ToString());
                    oColaborador.Supervisor = Convert.ToInt32(dr["Supervisor"]);
                    oColaborador.CuentaIBAN = dr["CuentaIBAN"].ToString();
                    oColaborador.Usuario = dr["Usuario"].ToString();
                    oColaborador.Contraseña = dr["Contraseña"].ToString();
                    oColaborador.Estado = Convert.ToInt32(dr["Estado"]);
                    lista.Add(oColaborador);

                }

            }

            return lista;
        }

        //------------------------- Login --------------------------------

        public static Colaborador Login(string usuario, string contrasenna)
        {

            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_LoginXRol";
                comando.Parameters.AddWithValue("@Usuario", usuario);
                comando.Parameters.AddWithValue("@Contraseña", contrasenna);

                IDataReader reader = db.ExecuteReader(comando);

                while (reader.Read())
                {
                    Colaborador colab = new Colaborador();
                    colab.Usuario = reader["Usuario"].ToString();
                    colab.Contraseña = reader["Contraseña"].ToString();
                    colab.Rol = reader["Rol"].ToString();   

                    return colab;
                }
            }

            return null;
        }

    }
}
