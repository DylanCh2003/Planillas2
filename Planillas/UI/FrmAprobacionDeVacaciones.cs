using Planillas.DB;
using Planillas.Entidades.DTO;
using Planillas.LN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planillas.UI
{
    public partial class FrmAprobacionDeVacaciones : Form
    {
        public FrmAprobacionDeVacaciones()
        {
            InitializeComponent();
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var AprobacionSolicitud = (Solicitud_de_Vacaciones)dvgColaboradorSolicitud.SelectedRows[0].DataBoundItem;
                var Solicitud = new Solicitud_de_Vacaciones();
                Solicitud.IDsolicitud = AprobacionSolicitud.IDsolicitud;
                Solicitud.IDColaborador = AprobacionSolicitud.IDColaborador;
                Solicitud.FechaSolicitud = AprobacionSolicitud.FechaSolicitud;
                Solicitud.FechaDesde = AprobacionSolicitud.FechaDesde;
                Solicitud.FechaHasta = AprobacionSolicitud.FechaHasta;
                Solicitud.CantidadDias = AprobacionSolicitud.CantidadDias;
                Solicitud.Observaciones = "Aprobado";
                Solicitud.Estado = 1;

                var logica = new SolicitudLN();
                logica.Guardar(Solicitud);
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Refrescar()
        {
            Solicitud_de_Vacaiones_DB db = new Solicitud_de_Vacaiones_DB();
            dvgColaboradorSolicitud.DataSource =db.SeleccionarPorSupervisor(int.Parse(txtSupervisorID.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var AprobacionSolicitud = (Solicitud_de_Vacaciones)dvgColaboradorSolicitud.SelectedRows[0].DataBoundItem;
                var Solicitud = new Solicitud_de_Vacaciones();
                Solicitud.IDsolicitud = AprobacionSolicitud.IDsolicitud;
                Solicitud.IDColaborador = AprobacionSolicitud.IDColaborador;
                Solicitud.FechaSolicitud = AprobacionSolicitud.FechaSolicitud;
                Solicitud.FechaDesde = AprobacionSolicitud.FechaDesde;
                Solicitud.FechaHasta = AprobacionSolicitud.FechaHasta;
                Solicitud.CantidadDias = AprobacionSolicitud.CantidadDias;
                Solicitud.Observaciones = "Denegado";
                Solicitud.Estado = 0;

                var logica = new SolicitudLN();
                logica.Guardar(Solicitud);
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
