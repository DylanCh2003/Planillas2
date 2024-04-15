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
    public partial class FrmDeduccionesYPercepciones : Form
    {
        public FrmDeduccionesYPercepciones()
        {
            InitializeComponent();
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }

        private void FrmDeduccionesYPercepciones_Load(object sender, EventArgs e)
        {
            cmbTipo.DataSource = System.Enum.GetValues(typeof(Tipo));
            cmbTipo.DisplayMember = "Name";
            cmbTipoValor.DataSource = System.Enum.GetValues(typeof(TipoValor));
            cmbTipoValor.DisplayMember = "Name";
            Refrescar();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                var ODeduccionesPercepciones = new DeduccionesYPercepciones();
                ODeduccionesPercepciones.Codigo = Convert.ToInt32(txtCodigo.Text);
                ODeduccionesPercepciones.Nombre = txtNombre.Text;
                ODeduccionesPercepciones.Tipo = cmbTipo.Text;
                ODeduccionesPercepciones.Valor = Convert.ToInt32(txtValor.Text);
                ODeduccionesPercepciones.TipoValor = cmbTipoValor.Text;


                var logica = new DeduccionesPercepcionesLN();
                logica.Guardar(ODeduccionesPercepciones);
                Refrescar();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Refrescar()
        {
            var logica = new DeduccionesPercepcionesLN();
            dvgDeduccionesYPercepciones.DataSource = logica.ObtenerTodos();
        }

        private void dvgDeduccionesYPercepciones_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dvgDeduccionesYPercepciones.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    var oDeduccionesYperceciones = (DeduccionesYPercepciones)dvgDeduccionesYPercepciones.SelectedRows[0].DataBoundItem;
                    txtCodigo.Text = oDeduccionesYperceciones.Codigo.ToString();
                    txtNombre.Text = oDeduccionesYperceciones.Nombre;

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
                    DeduccionesPercepcionesLN logica = new DeduccionesPercepcionesLN();
                    int Codigo = Convert.ToInt32(txtCodigo.Text);
                    logica.Eliminar(Codigo);
                    

                    MessageBox.Show("Eliminado con éxito");
                    Refrescar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
