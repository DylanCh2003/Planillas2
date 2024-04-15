using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using System.IO;
using Planillas.LN;



namespace Planillas.UI
{
    public partial class FrmControlDeMarcasC : Form
    {
        public FrmControlDeMarcasC()
        {
            InitializeComponent();
        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }

        private void FrmControlDeMarcasC_Load(object sender, EventArgs e)
        {
            Refrescar();
            CargarColaborador();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Generar();
        }

        public void Generar()
        {
            Control control = new Control();
            control.GenerarJSONs();
            Refrescar();
        }

        public void Refrescar()
        {
            var Marcas = JsonConvert.DeserializeObject<List<Marcas>>(File.ReadAllText(@"D:\Programación III\PFinal\Proyecto Progra III\Planillas\Planillas\bin\Debug\JSON\27mayo31mayo.json"));
            Marcas.FindAll(x => x.ID.Equals(cmbColaborador.SelectedValue));
            dvgControl.DataSource = Marcas;
        }

        public void Refrescar2()
        {
            var Marcas = JsonConvert.DeserializeObject<List<Marcas>>(File.ReadAllText(@"D:\Programación III\PFinal\Proyecto Progra III\Planillas\Planillas\bin\Debug\JSON\27mayo31mayo.json"));
            var ListaFiltrada = Marcas.FindAll(x => x.ID.Equals(cmbColaborador.SelectedValue));
            dvgControl.DataSource = ListaFiltrada;
        }

        private void CargarColaborador()
        {
            var logica = new ColaboradorLN();
            cmbColaborador.DataSource = logica.ObtenerTodos();
            cmbColaborador.DisplayMember = "Nombre";
            cmbColaborador.ValueMember = "ID";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Refrescar2();
        }

        public void Refrescar3()
        {
            var Marcas = JsonConvert.DeserializeObject<List<Marcas>>(File.ReadAllText(@"D:\Programación III\PFinal\Proyecto Progra III\Planillas\Planillas\bin\Debug\JSON\27mayo31mayo.json"));
            var ListaFiltrada = Marcas.FindAll(x => x.ID.Equals(cmbColaborador.SelectedValue));
            var CantidadHorasL = ListaFiltrada.Sum(x => x.CantHoras);
            CantidadHoras.Text = CantidadHorasL.ToString();
        }

        private void CantidadHoras_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Refrescar3();
        }
    }
}
