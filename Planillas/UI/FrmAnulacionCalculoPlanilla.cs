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
    public partial class FrmAnulacionCalculoPlanilla : Form
    {
        public FrmAnulacionCalculoPlanilla()
        {
            InitializeComponent();
        }

        private void FrmAnulacionCalculoPlanilla_Load(object sender, EventArgs e)
        {

        }

        private void linklblmenu_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmMenu menu = new FrmMenu();
            menu.Show();
            this.Hide();
        }
    }
}
