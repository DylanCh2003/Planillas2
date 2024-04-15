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
    public partial class FrmSol : Form
    {
        public FrmSol()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }
        private void Refrescar()
        {
            var logica = new SolicitudLN();
            dvgSolicitud.DataSource = logica.ObtenerTodos();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var Solicitud = new Solicitud_de_Vacaciones();
                Solicitud.IDsolicitud = Convert.ToInt32(txtSolicitud.Text);
                Solicitud.IDColaborador = Convert.ToInt32(txtColaborador.Text);
                Solicitud.FechaSolicitud = dtpSolicitud.Value;
                Solicitud.FechaDesde = dtpDesde.Value;
                Solicitud.FechaHasta = dtpHasta.Value;
                Solicitud.Observaciones = "En Espera";
                Solicitud.CantidadDias = Convert.ToInt32(nudDias.Value);
                Solicitud.Estado = 0;

                var logica = new SolicitudLN();
                logica.Guardar(Solicitud);
                Limpiar();
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void Limpiar()
        {
            txtColaborador.Text = "";
            txtSolicitud.Text = "";
            nudDias.Value = 0;
            dtpSolicitud.Value = DateTime.Now;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;

        }

        private void FrmSol_Load(object sender, EventArgs e)
        {
            Refrescar();
        }
    }
}
