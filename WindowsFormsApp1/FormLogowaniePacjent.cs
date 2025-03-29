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
    public partial class FormLogowaniePacjent : Form
    {
        public FormLogowaniePacjent()
        {
            InitializeComponent();
            textBoxHasloPacjent.PasswordChar = '•';
            checkBoxPokazHaslo.Checked = false;
        }


        private void textBoxLoginPacjent_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBoxHasloPacjent_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxPokazHaslo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxHasloPacjent.PasswordChar = checkBoxPokazHaslo.Checked ? '\0' : '•';
        }

        private void buttonZalogujPacjent_Click(object sender, EventArgs e)
        {
         
            string email = textBoxLoginPacjent.Text;
            string haslo = textBoxHasloPacjent.Text;

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
        }
        private bool SprawdzDaneLogowania(string email, string haslo)
        {
            
            return false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
