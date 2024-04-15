using Planillas.Entidades.DTO;
using Planillas.LN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Planillas
{
    public partial class FrmMantenimientoPuesto : Form
    {
        public FrmMantenimientoPuesto()
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
            var logica = new PuestoLN();
            dvgPuesto.DataSource = logica.ObtenerTodos();
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {

            try
            {
                var Puesto = new Puesto();
                Puesto.Codigo = Convert.ToInt32(txtCodigo.Text);
                Puesto.Nombre = txtNombre.Text;
                Puesto.Estado = 1;

                var logica = new PuestoLN();
                logica.Guardar(Puesto);
                Limpiar();
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mtxId_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void dvgPuesto_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dvgPuesto.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    var Puesto = (Puesto)dvgPuesto.SelectedRows[0].DataBoundItem;
                    txtCodigo.Text = Puesto.Codigo.ToString();
                    txtNombre.Text = Puesto.Nombre;
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var resultado = MessageBox.Show("¿Esta seguro?", "Pregunta",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    PuestoLN logica = new PuestoLN();
                    int Codigo = Convert.ToInt32(txtCodigo.Text);
                    logica.Eliminar(Codigo);
                    Limpiar();

                    MessageBox.Show("Empresa eliminado con éxito");
                    Refrescar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Limpiar()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }

        private void FrmMantenimientoPuesto_Load(object sender, EventArgs e)
        {
            Refrescar();
        }
    }
}
