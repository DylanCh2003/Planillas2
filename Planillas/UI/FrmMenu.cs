using Planillas.Resources;
using Planillas.UI;
using Planillas.UI.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planillas
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        public void permisosUsuario(string rol)
        {
            if (rol.Equals("SUPERVISOR"))
            {
                MenuMantenimiento.Enabled = false;
                MenuMantenimiento.Visible = false;
                MenuControlMarcas.Enabled = false;
                MenuControlMarcas.Visible = false;
                MenuCalculoPlanilla.Enabled = false;
                MenuCalculoPlanilla.Visible = false;
                MenuComprobantePago.Enabled = false;
                MenuComprobantePago.Visible = false;
                aprobacionDeVacacionesToolStripMenuItem.Enabled = true;
                aprobacionDeVacacionesToolStripMenuItem.Visible = true;
                solicitudDeVacacionesToolStripMenuItem.Enabled = false;
                solicitudDeVacacionesToolStripMenuItem.Visible = false;
                anulacionYToolStripMenuItem.Enabled = false;
                anulacionYToolStripMenuItem.Visible = false;
            }   
            else if (rol.Equals("COLABORADOR"))
            {
                MenuMantenimiento.Enabled = false;
                MenuMantenimiento.Visible = false;
                MenuControlMarcas.Enabled = false;
                MenuControlMarcas.Visible = false;
                MenuCalculoPlanilla.Enabled = false;
                MenuCalculoPlanilla.Visible = false;
                anulacionYToolStripMenuItem.Enabled = false;
                anulacionYToolStripMenuItem.Visible = false;
                MenuComprobantePago.Enabled = false;
                MenuComprobantePago.Visible = false;
                aprobacionDeVacacionesToolStripMenuItem.Enabled = false;
                aprobacionDeVacacionesToolStripMenuItem.Visible = false;
                reporteplanillaFecha.Enabled = false;
                reporteplanillaFecha.Visible = false;
                ReporteSolicitudVacaciones.Enabled = false;
                ReporteSolicitudVacaciones.Visible = false;

            }

        }

        private void mantenimiendoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmMantenimientoColaborador colaborador = new FrmMantenimientoColaborador();
            colaborador.Show();
            this.Hide();
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            FrmCalculoPlanilla Calculo = new FrmCalculoPlanilla();
            Calculo.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FrmMantenimientoPuesto puesto = new FrmMantenimientoPuesto();
            puesto.Show();
            this.Hide();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            FrmMantenimientoEmpresa Empresa = new FrmMantenimientoEmpresa();
            Empresa.Show();
            this.Hide();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            FrmMantenimientoControlDeMarcas Control = new FrmMantenimientoControlDeMarcas();
            Control.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            FrmControlDeMarcasC ControlDeMarcasC = new FrmControlDeMarcasC();
            ControlDeMarcasC.Show();
            this.Hide();
        }

        private void deduccionesYPercepcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDeduccionesYPercepciones Deducciones = new FrmDeduccionesYPercepciones();
            Deducciones.Show();
            this.Hide();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            FrmComprobanteDePago comprobanteDePago = new FrmComprobanteDePago();
            comprobanteDePago.Show();
            this.Hide();
        }

        private void solicitudDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSol Solicitud = new FrmSol();
            Solicitud.Show();
            this.Hide();
        }

        private void aprobacionDeVacacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAprobacionDeVacaciones Aprobacion = new FrmAprobacionDeVacaciones();
            Aprobacion.Show();
            this.Hide();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            FrmMantenimientoDepartamentos Departamentos = new FrmMantenimientoDepartamentos();
            Departamentos.Show();
            this.Hide();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            this.FormClosed += new FormClosedEventHandler(Cerrarform);
        }

        private void Cerrarform (object sender , EventArgs e)
        {
           Application.Exit();
        }

        private void anulacionYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAnulacionCalculoPlanilla Anulacion = new FrmAnulacionCalculoPlanilla();
            Anulacion.Show();
            this.Hide();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

        }

        private void planilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planilla Planilla = new Planilla();
            Planilla.Show();
            this.Hide();
        }

        private void reporteplanillaFecha_Click(object sender, EventArgs e)
        {
            Prueba1 prueba1 = new Prueba1();
            prueba1.Show();
        }
    }
}
