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
    public partial class FrmDecuccionPercepcionPorColaborador : Form
    {
        public Colaborador Colaborador { get; set; }

        public FrmDecuccionPercepcionPorColaborador()
        {
            InitializeComponent();
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }
        private void Refrescar()
        {
            lbDisponible.DataSource = DeduccionesYPercepcionesXColaboradorLN.GetDisponibleByDeduccion(Colaborador.ID.ToString());
            if (Colaborador != null)
            {
                lbSeleccionado.DataSource =
                                        DeduccionesYPercepcionesXColaboradorLN.GetByColaboradorId2(Colaborador.ID.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbDisponible.SelectedItem != null)
                {
                    var DeduccionesYPercepcionesXColaborador = new DeduccionesYPercepcionesXColaborador();
                    var prov = (DeduccionesYPercepciones)lbDisponible.SelectedItem;
                    var logica = new DeduccionesYPercepcionesXColaboradorLN();
                    logica.Add(prov.Codigo,Colaborador.ID,cmbPrioridad.Text,1);
                    Refrescar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmDecuccionPercepcionPorColaborador_Load(object sender, EventArgs e)
        {
            cmbPrioridad.DataSource = System.Enum.GetValues(typeof(Prioridad));
            cmbPrioridad.DisplayMember = "Name";
            Refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lbSeleccionado.SelectedItem != null)
                {
                    var DeduccionesYPercepcionesXColaborador = new DeduccionesYPercepcionesXColaborador();
                    var prov = (DeduccionesYPercepciones)lbSeleccionado.SelectedItem;
                    var logica = new DeduccionesYPercepcionesXColaboradorLN();
                    logica.Remove(prov.Codigo);
                    Refrescar();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
    }
}
