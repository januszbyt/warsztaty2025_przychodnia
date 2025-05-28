using System;
using System.Configuration;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Forms
{
    public partial class FormLogowanieLekarz : Form
    {

        private DataBaseHelper _dbHelper;

        public FormLogowanieLekarz(DataBaseHelper dbHelper)
        {
            InitializeComponent();
            this._dbHelper = dbHelper;
            this.FormClosed += new FormClosedEventHandler(FormLogowanieLekarz_FormClosed);

            _dbHelper = new DataBaseHelper();

            textBoxHasloLekarz.PasswordChar = '•';
            checkBox1.Checked = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBoxHasloLekarz.PasswordChar = checkBox1.Checked ? '\0' : '•';
        }

        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormLogowanieRola formrola = new FormLogowanieRola(_dbHelper);
            this.Hide();
            formrola.ShowDialog();

        }

        private void buttonZaloguj_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_dbHelper == null)
                {
                    MessageBox.Show("nie loncze z bazom");
                    return;
                }

                string email = textBoxLoginLekarz.Text.Trim();
                string haslo = textBoxHasloLekarz.Text.Trim();

                if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(haslo))
                {
                    MessageBox.Show("Proszę wprowadzić email i hasło.");
                    return;
                }

                var uzytkownik = _dbHelper.ZalogujUzytkownika(email, haslo);

                if (uzytkownik == null)
                {
                    MessageBox.Show("Nieprawidłowe dane logowania lub brak przypisanej roli.");
                    return;
                }

                if (!uzytkownik.Rola.Nazwa.Equals("Lekarz", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Brak uprawnień lekarza.");
                    return;
                }

                var doctor = _dbHelper.PobierzLekarza(uzytkownik.Id);
                if (doctor == null)
                {
                    MessageBox.Show("Brak danych lekarza.");
                    return;
                }

                this.Hide();
                new PanelLekarza(doctor, _dbHelper).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        private void FormLogowanieLekarz_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

