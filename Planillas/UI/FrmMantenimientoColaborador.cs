using log4net;
using Planillas.Entidades.DTO;
using Planillas.LN;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Planillas.UI
{
    public partial class FrmMantenimientoColaborador : Form
    {
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public Colaborador Colaborador { get; set; }
        public FrmMantenimientoColaborador()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog opt = new OpenFileDialog();
                opt.Title = "Seleccione la Imagen ";
                opt.SupportMultiDottedExtensions = true;
                opt.DefaultExt = "*.jpg";
                opt.Filter = "Archivos de Imagenes (*.jpg)|*.jpg| All files (*.*)|*.*";
                opt.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                opt.FileName = "";

                if (opt.ShowDialog(this) == DialogResult.OK)
                {

                    //ruta = opt.FileName.Trim();
                    this.pbImagen.ImageLocation = opt.FileName;
                    pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;

                    byte[] cadenaBytes = File.ReadAllBytes(opt.FileName);

                    // Guarla la imagenen Bytes en el Tag de la imagen.
                    pbImagen.Tag = (byte[])cadenaBytes;

                }
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

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmMantenimientoColaborador_Load(object sender, EventArgs e)
        {
            cmbRol.DataSource = System.Enum.GetValues(typeof(Rol));
            cmbRol.DisplayMember = "Name";
            Refrescar();
            CargarPuesto();
            CargarDepartamentos();
            CargarSupervisor();
            ValidarSupervisor();

        }
        private void CargarPuesto()
        {
            var logica = new PuestoLN();
            cmbPuesto.DataSource = logica.ObtenerTodos();
            cmbPuesto.DisplayMember = "Nombre";
            cmbPuesto.ValueMember = "Codigo";
        }

        private void CargarDepartamentos()
        {
            var logica = new DepartamentoLN();
            cbmDepartamento.DataSource = logica.ObtenerTodos();
            cbmDepartamento.DisplayMember = "Nombre";
            cbmDepartamento.ValueMember = "ID";
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                var Colaborador = new Colaborador();
                Colaborador.ID = Convert.ToInt32(mtxid.Text);
                Colaborador.Nombre = txtNombre.Text;
                Colaborador.Apellido = txtApellido.Text;
                Colaborador.FechaNacimiento = dtpNacimiento.Value;
                Colaborador.Direccion = txtDireccion.Text;
                Colaborador.FechaIngreso = dtpIngreso.Value;
                Colaborador.Departamento = (int)cbmDepartamento.SelectedValue;
                Colaborador.Rol = cmbRol.Text;
                Colaborador.SalarioXHora = decimal.Parse(txtSalario.Text);
                Colaborador.Foto = (byte[]) this.pbImagen.Tag;
                Colaborador.Correo = txtCorreo.Text;
                Colaborador.Puesto = (int)cmbPuesto.SelectedValue;
                if (cmbRol.SelectedIndex == 2)
                {
                   Colaborador.Supervisor = (int)cbmSupervisor.SelectedValue;
                }
                else
                {
                    Colaborador.Supervisor = Convert.ToInt32(txtSupervisor.Text);
                }
                Colaborador.CuentaIBAN = txtcuenta.Text;
                Colaborador.Usuario = txtUsuario.Text;
                Colaborador.Contraseña = txtContraseña.Text;
                Colaborador.Estado = 1;
                Limpiar();

                var logica = new ColaboradorLN();
                logica.Guardar(Colaborador);
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Refrescar()
        {
            var logica = new ColaboradorLN();
            dvgColaborador.DataSource = logica.ObtenerTodos();
        }


        private void CargarSupervisor()
        {
            var logica = new ColaboradorLN();
            cbmSupervisor.DataSource = logica.ListaSupervisor();
            cbmSupervisor.DisplayMember = "Nombre";
            cbmSupervisor.ValueMember = "ID";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarSupervisor();
        }

        private void dvgColaborador_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dvgColaborador.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    var Coladorador = (Colaborador)dvgColaborador.SelectedRows[0].DataBoundItem;
                    mtxid.Text = Coladorador.ID.ToString();
                    dtpNacimiento.Value = Coladorador.FechaNacimiento;
                    txtNombre.Text = Coladorador.Nombre.ToString();
                    txtApellido.Text = Coladorador.Apellido.ToString();
                    txtDireccion.Text = Coladorador.Direccion;
                    dtpIngreso.Value = Coladorador.FechaIngreso;
                    cbmDepartamento.SelectedValue = Coladorador.Departamento;
                    cmbPuesto.SelectedValue = Coladorador.Puesto;
                    if(Coladorador.Rol.ToString() == "ADMINISTRADOR")
                    {
                        cmbRol.SelectedIndex = 0;
                    }
                    else if(Coladorador.Rol.ToString() == "SUPERVISOR")
                    {
                        cmbRol.SelectedIndex = 1;
                    }
                    else if (Coladorador.Rol.ToString() == "COLABORADOR")
                    {
                        cmbRol.SelectedIndex = 2;
                    }

                    cmbRol.SelectedItem = Coladorador.Rol.ToString();
                    txtcuenta.Text = Coladorador.CuentaIBAN.ToString();
                    txtSalario.Text = Coladorador.SalarioXHora.ToString();
                    txtCorreo.Text = Coladorador.Correo.ToString();
                    txtSupervisor.Text = Coladorador.Supervisor.ToString();
                    txtUsuario.Text = Coladorador.Usuario.ToString();
                    txtContraseña.Text = Coladorador.Contraseña.ToString();
                    this.pbImagen.Image = new Bitmap(new MemoryStream(Coladorador.Foto));
                    this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pbImagen.Tag = Coladorador.Foto;
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
                    ColaboradorLN logica = new ColaboradorLN();
                    int id = Convert.ToInt32(mtxid.Text);
                    logica.Eliminar(id);

                    MessageBox.Show("Colaborador eliminado con éxito");
                    Refrescar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ValidarSupervisor()
        {
            if(cmbRol.SelectedIndex == 2)
            {
                cbmSupervisor.Visible = true;
                txtSupervisor.Visible = false;
                txtSupervisor.Enabled = false;
            }
            else
            {
                cbmSupervisor.Visible = false;
                txtSupervisor.Visible = true;
                txtSupervisor.Enabled = true;
            }
        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarSupervisor();
        }

        private void cmbRol_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            txtApellido.Text = "";
            mtxid.Text = "";
            txtContraseña.Text = "";
            txtCorreo.Text = "";
            txtcuenta.Text = "";
            txtDireccion.Text = "";
            txtNombre.Text = "";
            txtSalario.Text = "";
            txtSupervisor.Text = "";
            txtUsuario.Text = "";
            // pblImagen.Image = ;
            cbmDepartamento.SelectedIndex = -1;
            cmbPuesto.SelectedIndex = -1;
            cmbRol.SelectedIndex = -1;
            cbmSupervisor.SelectedIndex = -1;
        }

        private void btbNuevo_Click(object sender, EventArgs e)
        {

            try
            {
                if (dvgColaborador.SelectedRows.Count > 0)
                {
                    var Colaborador
                        =
                        dvgColaborador.SelectedRows[0].DataBoundItem;
                    var frm = new FrmDecuccionPercepcionPorColaborador();
                    frm.Colaborador = (Colaborador)Colaborador;
                    frm.ShowDialog();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
