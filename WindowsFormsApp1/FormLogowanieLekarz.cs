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
    public partial class FormLogowanieLekarz : Form
    {
        public FormLogowanieLekarz()
        {
            InitializeComponent();

            textBoxHasloLekarz.PasswordChar = '•';
            checkBox1.Checked = false;

            
        }

        private void textBoxLoginLekarz_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHasloLekarz_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textBoxLoginLekarz.Text;
            string haslo = textBoxHasloLekarz.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Proszę wypełnić wszystkie pola!", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            if (SprawdzDaneLogowania(email, haslo))
            {
                MessageBox.Show("Brawo! Udało Ci się zalogować!", "Sukces",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                MessageBox.Show("Nieprawidłowy email lub hasło!", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            PanelLekarza panellekarza = new PanelLekarza();
            panellekarza.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxHasloLekarz.PasswordChar = checkBox1.Checked ? '\0' : '•';
        }

        private bool SprawdzDaneLogowania(string email, string haslo)
        {

            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FormLogowanieRola logowanieRola = new FormLogowanieRola();
            logowanieRola.Show();
            this.Hide();
        }
    }
}
