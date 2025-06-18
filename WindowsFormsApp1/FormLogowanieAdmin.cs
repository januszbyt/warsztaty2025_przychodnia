using System;
using System.Windows.Forms;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1
{
    public partial class FormLogowanieAdmin : Form
    {
        private readonly DataBaseHelper _dbHelper;

        public FormLogowanieAdmin(DataBaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));

            textBoxHasloAdmin.PasswordChar = '•';
            textBoxLoginAdmin.Text = "Admin";
            textBoxHasloAdmin.Focus();
            this.AcceptButton = this.button1;
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
                MessageBox.Show("Logowanie udane, Witaj Administratorze!", "Sukces",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide(); 

                var panelAdmin = new PanelAdmina();

                panelAdmin.Wylogowano += (s, args) =>
                {
                    this.Close(); 
                };

                panelAdmin.Show();
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
            var rolaForm = new FormLogowanieRola(_dbHelper);
            rolaForm.Show();
            this.Hide();
        }
    }
}
