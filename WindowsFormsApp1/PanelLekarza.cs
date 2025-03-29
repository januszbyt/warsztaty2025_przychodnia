using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PanelLekarza : Form
    {
        public PanelLekarza()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            FormLogowanieLekarz logowanielekarz = new FormLogowanieLekarz();
            logowanielekarz.Show();
            this.Hide();

        }
    }
}
