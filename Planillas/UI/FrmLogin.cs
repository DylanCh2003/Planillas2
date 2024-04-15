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


namespace Planillas
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Colaborador colaborador = new Colaborador();
                string usuario = txtUsuario.Text;
                string contrasenna = txtContraseña.Text;

                ColaboradorLN colLogica = new ColaboradorLN();
                colaborador = colLogica.Login(usuario, contrasenna);
                if (colaborador != null)
                {
                    var form = new FrmMenu();
                    form.permisosUsuario(colaborador.Rol);
                    form.Show();
                    this.Hide();

                    form.FormClosing += Form_closing;
                }
                else
                {
                    MessageBox.Show("Error", "Error de autenticación.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message);
            }

        }

        private void Form_closing(object sender, FormClosingEventArgs e)
        {
            txtContraseña.Text = "";
            txtUsuario.Text = "";

            this.Show();
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool ValidarCampos()
        {
            if (txtContraseña.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtUsuario, "Debe de tener lleno el usuario");
                MessageBox.Show("Debe de tener el campo lleno", "Atención", MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtUsuario.Text.Equals(""))
            {
                this.errorProvider1.SetError(this.txtContraseña, "Debe de tener la contrseña");
                MessageBox.Show("Debe de tener el campo lleno", "Atención", MessageBoxButtons.OK
                    , MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }
    }
}
