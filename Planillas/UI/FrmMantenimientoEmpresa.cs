using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using log4net;
using Planillas.LN;
using Planillas.Entidades.DTO;
using Planillas.DB;

namespace Planillas.Resources
{
    public partial class FrmMantenimientoEmpresa : Form
    {
        public FrmMantenimientoEmpresa()
        {
            InitializeComponent();
        }
        private static readonly ILog _MyLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

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

        private void Refrescar()
        {
            var logica = new EmpresaLN();
            dvgEmpresa.DataSource = logica.ObtenerTodos();
        }

        private void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                var empresa = new Empresa();
                empresa.ID = Convert.ToInt32(txtID.Text);
                empresa.TipoIdentificacion = txtTipoindetificacion.Text;
                empresa.Nombre = txtNombre.Text;
                empresa.Telefono = Convert.ToInt32(txtTelefono.Text);
                empresa.Direccion = txtDireccion.Text;
                empresa.Logo = (byte[])this.pbImagen.Tag;
                empresa.Estado = 0;

                var logica =  new EmpresaLN();
                logica.Guardar(empresa);
                Limpiar();
                Refrescar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void dvgEmpresa_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Validar si hay un fila selecionada
                if (dvgEmpresa.SelectedRows.Count > 0)
                {
                    // DataBoundItem retorna el objeto seleccionado en el grid
                    var Empresa = (Empresa)dvgEmpresa.SelectedRows[0].DataBoundItem;
                    txtID.Text = Empresa.ID.ToString();
                    txtTipoindetificacion.Text = Empresa.TipoIdentificacion;
                    txtNombre.Text = Empresa.Nombre;
                    txtTelefono.Text = Empresa.Telefono.ToString();
                    txtDireccion.Text = Empresa.Direccion;
                    this.pbImagen.Image = new Bitmap(new MemoryStream(Empresa.Logo));
                    this.pbImagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    this.pbImagen.Tag = Empresa.Logo;
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
                    EmpresaLN logica = new EmpresaLN();
                    int id = Convert.ToInt32(txtID.Text);
                    logica.Eliminar(id);
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
            txtID.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtTipoindetificacion.Text = "";
            txtDireccion.Text = "";
        }

        private void FrmMantenimientoEmpresa_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void dvgEmpresa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
