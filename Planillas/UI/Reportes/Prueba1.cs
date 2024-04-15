using log4net;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planillas.UI.Reportes
{
    public partial class Prueba1 : Form
    {
        private int NumeroPlanilla;
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public Prueba1()
        {
            InitializeComponent();
        }
        public Prueba1(int NumeroPlanilla2)
        {
            InitializeComponent();
            NumeroPlanilla = NumeroPlanilla2;
        }

        private void Prueba1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'prueba002DataSet.EncPlanilla' table. You can move, or remove it, as needed.
            this.encPlanillaTableAdapter.Fill(this.prueba002DataSet.EncPlanilla);
            try
            {


                // TODO: This line of code loads data into the 'prueba002DataSet.EncPlanilla' table. You can move, or remove it, as needed.
                this.encPlanillaTableAdapter.Fill(this.prueba002DataSet.EncPlanilla);

                //this.reportViewer1.RefreshReport();



                string ruta = @"file:///" + @"C:/TEMP/qr.png";
                // Habilitar imagenes externas
                this.reportViewer1.LocalReport.EnableExternalImages = true;
                ReportParameter param = new ReportParameter("quickresponse", ruta);
                this.reportViewer1.LocalReport.SetParameters(param);
                this.reportViewer1.RefreshReport();
            }
            catch (SqlException sqlError)
            {
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error: \n" + Utilitarios.GetCustomErrorByNumber(sqlError), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            string ruta = @"c:\temp\reporte.pdf";
            try
            {
                if (!Directory.Exists(@"c:\temp"))
                    Directory.CreateDirectory(@"c:\temp");

                byte[] Bytes = this.reportViewer1.LocalReport.Render(format: "PDF", deviceInfo: "");

                using (FileStream stream = new FileStream(ruta, FileMode.Create))
                {
                    stream.Write(Bytes, 0, Bytes.Length);
                }

                Process.Start(ruta);
            }

            catch (SqlException sqlError)
            {
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error: \n" + Utilitarios.GetCustomErrorByNumber(sqlError), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception er)
            {

                StringBuilder msg = new StringBuilder();
                msg.AppendFormat(Utilitarios.CreateGenericErrorExceptionDetail(MethodBase.GetCurrentMethod(), er));
                _MyLogControlEventos.ErrorFormat("Error {0}", msg.ToString());
                // Mensaje de Error
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
