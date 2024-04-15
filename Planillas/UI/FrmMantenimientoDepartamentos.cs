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
    public partial class FrmMantenimientoDepartamentos : Form
    {
        public FrmMantenimientoDepartamentos()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void Refrescar()
        {
            var logica = new DepartamentoLN();  
            dvgDepartamentos.DataSource = logica.ObtenerTodos();
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                var Departamento = new Departamento();
                Departamento.ID = Convert.ToInt32(txtCodigo.Text);
                Departamento.Nombre = txtNombre.Text;
                Departamento.Activo = 1;

                var logica = new DepartamentoLN();
                logica.Guardar(Departamento);
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
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            try
            {
                var resultado = MessageBox.Show("¿Esta seguro?", "Pregunta",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    DepartamentoLN logica = new DepartamentoLN();
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

        private void dvgDepartamentos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dvgDepartamentos.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    var Departamentoi = (Departamento)dvgDepartamentos.SelectedRows[0].DataBoundItem;
                    txtCodigo.Text = Departamentoi.ID.ToString();
                    txtNombre.Text = Departamentoi.Nombre;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmMantenimientoDepartamentos_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
