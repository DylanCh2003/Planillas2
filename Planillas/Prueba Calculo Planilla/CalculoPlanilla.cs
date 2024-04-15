using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Planillas.Entidades.DTO;
using System.Data.SqlClient;
using System.Data;
using Planillas;

namespace Planillas
{
    public class CalculoPlanilla
    {
        public double ObtenerHorasLaboradas(int ID)
        {
            double total;
            var Marcas = JsonConvert.DeserializeObject<List<Marcas>>(File.ReadAllText(@"D:\Programación III\PFinal\Proyecto Progra III\Planillas\Planillas\bin\Debug\JSON\27mayo31mayo.json"));
            var ListaFiltrada = Marcas.FindAll(x => x.ID.Equals(ID));
            var CantidadHorasL = ListaFiltrada.Sum(x => x.CantHoras);
            total = CantidadHorasL;
            return total;
        }

        public List<EncabezadoPlanilla> SeleccionarPorEncabexadoId()
        {
            decimal Salario;
            double SalarioNuevo;
            double SalarioTemp1 = 0;
            List<EncabezadoPlanilla> lista = new List<EncabezadoPlanilla> ();
            using (IDataBase db = FactoryDatabase.CreateDefaultDataBase())
            {
                SqlCommand comando = new SqlCommand();
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.CommandText = "PA_SeleccionarColaboradorAll";
                //comando.Parameters.AddWithValue("@ID", ID);

                DataSet ds = db.ExecuteDataSet(comando);


                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    EncabezadoPlanilla encabezado = new EncabezadoPlanilla();
                    Colaborador oColaborador = new Colaborador();
                    oColaborador.ID = Convert.ToInt32(dr["ID"]);
                    oColaborador.Nombre = dr["Nombre"].ToString();
                    oColaborador.Apellido = dr["Apellido"].ToString();
                    oColaborador.SalarioXHora = decimal.Parse(dr["SalarioXHora"].ToString());

                    Salario = oColaborador.SalarioXHora;
                    SalarioNuevo = (double)Salario;
                    SalarioTemp1 = SalarioNuevo * ObtenerHorasLaboradas(oColaborador.ID);

                    encabezado.ID = oColaborador.ID;
                    encabezado.HorasLaboradas = ObtenerHorasLaboradas(oColaborador.ID);
                    //encabezado.SalarioXhora = (double)oColaborador.SalarioXHora;
                    encabezado.SalarioBase = SalarioTemp1;

                    lista.Add(encabezado);


                }

            }
            return lista;
        }
    }
}
