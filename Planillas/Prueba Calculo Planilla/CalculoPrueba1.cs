using Newtonsoft.Json;
using Planillas.DB;
using Planillas.Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using Planillas.Prueba_Calculo_Planilla;

namespace Planillas
{
    public class CalculoPrueba1
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

        public void GenerarCaculos()
        {

            ColaboradorDB colaborador = new ColaboradorDB();
            EncPlanillaLN encPlanillaLN = new EncPlanillaLN();
            DeduccionesYPercepcionesXColaboradorDB DPXcolaborador = new DeduccionesYPercepcionesXColaboradorDB();
            List<Colaborador> ListaColaborador = null;
            List<DeduccionesYPercepciones> ListaDeduccionesPercepcione = null;
            List<EncabezadoPlanilla> lista = new List<EncabezadoPlanilla>();
            int Contador = 1;

            //Extraer todo los colaboradores 
            ListaColaborador = colaborador.SeleccionarTodos2();



            foreach (Colaborador oColaborador in ListaColaborador)
            {

                double SalarioXHora;
                double deducciones = 0;
                double TotalDeducciones = 0;
                double TotalPercepciones = 0;
                double Percepcion = 0;
                double SalarioBase;
                double SalarioNeto = 0;
                ListaDeduccionesPercepcione = DPXcolaborador.SeleccionarPorColaborador(oColaborador.ID.ToString());
                SalarioBase = (double)oColaborador.SalarioXHora * ObtenerHorasLaboradas(oColaborador.ID);

                if (ListaDeduccionesPercepcione != null)
                {
                    foreach (DeduccionesYPercepciones deduccionesYPercepciones in ListaDeduccionesPercepcione)
                    {
                        if (deduccionesYPercepciones.Tipo == "Deduccion")
                        {
                            SalarioXHora = (double)oColaborador.SalarioXHora;
                            deducciones += deduccionesYPercepciones.Valor / 100D;
                            TotalDeducciones = SalarioBase * deducciones;
                        }
                        if (deduccionesYPercepciones.Tipo == "Percepcion")
                        {
                            Percepcion += deduccionesYPercepciones.Valor;
                        }

                        SalarioNeto = (SalarioBase - TotalDeducciones) + Percepcion;

                    }

                    
                }
                EncabezadoPlanilla encabezado = new EncabezadoPlanilla()
                {
                    ID = Contador++,
                    IDColaborador = oColaborador.ID,
                    HorasLaboradas = ObtenerHorasLaboradas(oColaborador.ID),
                    //Deduccion = deducciones,
                    TotalDeducciones = TotalDeducciones,
                    TotalPercepciones = Percepcion,
                    //SalarioXhora = (double)oColaborador.SalarioXHora,
                    SalarioBase = SalarioBase,
                    SalarioNeto = SalarioNeto
                };
                encPlanillaLN.Guardar(encabezado);
                lista.Add(encabezado);

                //SalarioXHora = 0;
                //deducciones = 0;
                //TotalDeducciones = 0;
                //Percepcion = 0;

            }


        }
    }
}
