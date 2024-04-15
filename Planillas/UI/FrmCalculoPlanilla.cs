using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Planillas.LN;
using Planillas.Entidades.DTO;
using Planillas.DB;
using Planillas.Prueba_Calculo_Planilla;
using System.Drawing.Imaging;
using Planillas.UI.Reportes;

namespace Planillas.UI
{
    public partial class FrmCalculoPlanilla : Form
    {
        public FrmCalculoPlanilla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process calc = new System.Diagnostics.Process { StartInfo = { FileName = @"calc.exe" } };
            calc.Start();
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

       

       

        private void FrmCalculoPlanilla_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

      

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
          
        }

        private void dvgColaborador_SelectionChanged(object sender, EventArgs e)
        {
           
        }

      

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Calculos()
        {
            var logica = new CalculoPrueba1();
            logica.GenerarCaculos();
        }

        private void Refrescar()
        {
            var logica = new EncPlanillaLN();
            dvgColaborador.DataSource =  logica.ObtenerTodos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string rutaImagen = @"c:\temp\qr.png";
            int numeroPlanilla = 1;
            Calculos();
            Refrescar();

            if (File.Exists(rutaImagen))
                File.Delete(rutaImagen);

            // Crear imagen quickresponse
            Image quickResponseImage = QuickResponse.QuickResponseGenerador(numeroPlanilla.ToString(), 53);

            // Salvarla en c:\temp para luego ser leida
            quickResponseImage.Save(rutaImagen, ImageFormat.Png);

            Prueba1 ofrmReporteFactura = new Prueba1(numeroPlanilla);
            ofrmReporteFactura.ShowDialog();
        }
    }
}
