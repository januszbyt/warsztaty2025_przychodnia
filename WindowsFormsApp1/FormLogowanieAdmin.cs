using System;
using System.Windows.Forms;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1
{
    public partial class FormLogowanieAdmin : Form
    {
        private readonly DataBaseHelper _dbHelper;
        public FormLogowanieAdmin()
        {
            InitializeComponent();
            textBoxHasloAdmin.PasswordChar = '•';

            textBoxLoginAdmin.Text = "Admin";
            textBoxHasloAdmin.Focus();
        }

        private void textBoxLoginAdmin_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxHasloAdmin_TextChanged(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }   
        }

        private void checkBoxHasloAdmin_CheckedChanged(object sender, EventArgs e)
        {
            textBoxHasloAdmin.PasswordChar = checkBoxHasloAdmin.Checked ? '\0' : '•';
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string login = textBoxLoginAdmin.Text.Trim();
            string haslo = textBoxHasloAdmin.Text;

            if (login.Equals("Admin", StringComparison.OrdinalIgnoreCase) && haslo == "PANS")
            {
                MessageBox.Show("Logowanie udane, Witaj Administratorze !","Sukces", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                PanelAdmina panelAdmin = new PanelAdmina();
                panelAdmin.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Nieprawidłowy login lub hasło!", "Błąd logowania",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);

                textBoxHasloAdmin.Text = "";
                textBoxHasloAdmin.Focus();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormLogowanieRola logowanieRola = new FormLogowanieRola(_dbHelper);
            logowanieRola.Show();
            this.Hide();
        }

        private void FormLogowanieAdmin_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
