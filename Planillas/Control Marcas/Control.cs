using Newtonsoft.Json;
using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Planillas
{
    public class Control
    {
        public  void GenerarJSONs()
        {
            DateTime lunesInicio = new DateTime(2024, 5, 27);
            DateTime viernesFinal = new DateTime(2024, 5, 31);
            DateTime ciclo = lunesInicio;
            Random rnd = new Random();
            List<Marcas> listaMarcas = new List<Marcas>();
            List<Colaborador> listaColab;
            try
            {
                listaColab = ColaboradorDB.SeleccionarTodos();
            }
            catch (Exception)
            {

                throw;
            }
            string nombre = "";
            while (ciclo <= viernesFinal)
            {
                if (ciclo.DayOfWeek == DayOfWeek.Monday)
                {
                    nombre = ciclo.Day.ToString() + ciclo.ToString("MMMM");
                }
                foreach (Colaborador colab in listaColab)
                {
                    DateTime fechaEntrada = ciclo;
                    fechaEntrada = fechaEntrada.AddHours(6).AddMinutes(50);
                    fechaEntrada = fechaEntrada.AddMinutes(rnd.Next(0, 20));

                    DateTime fechaSalida = ciclo;
                    fechaSalida = fechaSalida.AddHours(16).AddMinutes(50);
                    fechaSalida = fechaSalida.AddMinutes(rnd.Next(0, 20));

                    double cantHoras = CalcularHorasTrabajadas(fechaEntrada, fechaSalida);
                    cantHoras = Convert.ToDouble(cantHoras.ToString("F2"));
                    Marcas marca = new Marcas()
                    {
                        ID = colab.ID,
                        Fecha = ciclo,
                        Entrada = fechaEntrada,
                        Salida = fechaSalida,
                        CantHoras = cantHoras
                    };
                    listaMarcas.Add(marca);
                }
                if (ciclo.DayOfWeek == DayOfWeek.Friday)
                {
                    nombre += ciclo.Day.ToString() + ciclo.ToString("MMMM");
                    string ruta = Application.StartupPath + @"\JSON\" + nombre + ".json";
                    string json = JsonConvert.SerializeObject(listaMarcas);
                    listaMarcas = new List<Marcas>();

                    try
                    {
                        
                        File.WriteAllText(ruta, json);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    ciclo = ciclo.AddDays(3);
                }
                else
                {
                    ciclo = ciclo.AddDays(1);
                }
            }


        }

        private static double CalcularHorasTrabajadas(DateTime fechaEntrada, DateTime fechaSalida)
        {
            TimeSpan diferencia = fechaSalida - fechaEntrada;
            double horasTrabajadas = Math.Round(diferencia.TotalHours, 2);
            return horasTrabajadas;
        }

        public static double CalcularHorasTrabajadas2(DateTime fechaEntrada, DateTime fechaSalida)
        {
            TimeSpan duracion = fechaSalida - fechaEntrada;
            return duracion.TotalHours;
        }

        public static double CalcularHorasTrabajadas3(DateTime fechaEntrada, DateTime fechaSalida)
        {
            TimeSpan diferencia = fechaSalida - fechaEntrada;
            double horasTrabajadas = diferencia.TotalHours;

            // Es por si las horas son negativas 
            // entonces se considera que no se trabajó y se devuelve 0 horas.
            if (horasTrabajadas < 0)
            {
                horasTrabajadas = 0;
            }

            return horasTrabajadas;
        }
    }
}
