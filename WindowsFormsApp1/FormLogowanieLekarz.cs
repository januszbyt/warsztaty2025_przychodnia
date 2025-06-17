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
        private readonly DataBaseHelper _dbHelper;

        public FormLogowanieLekarz(DataBaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));

            textBoxHasloLekarz.PasswordChar = '•';
            checkBox1.Checked = false;
            this.AcceptButton = buttonZaloguj;
            this.FormClosed += FormLogowanieLekarz_FormClosed;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1 == null) return;
            textBoxHasloLekarz.PasswordChar = checkBox1.Checked ? '\0' : '•';
        }

        private void buttonZamknij_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var formRola = new FormLogowanieRola(_dbHelper);
            this.Hide();
            formRola.ShowDialog();
        }

        private void buttonZaloguj_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_dbHelper == null)
                {
                    MessageBox.Show("Błąd połączenia z bazą danych", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string email = textBoxLoginLekarz?.Text?.Trim() ?? string.Empty;
                string haslo = textBoxHasloLekarz?.Text?.Trim() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(haslo))
                {
                    MessageBox.Show("Proszę wprowadzić email i hasło", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var uzytkownik = _dbHelper.ZalogujUzytkownika(email, haslo);
                if (uzytkownik == null)
                {
                    MessageBox.Show("Nieprawidłowe dane logowania", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!uzytkownik.Rola?.Nazwa?.Equals("Lekarz", StringComparison.OrdinalIgnoreCase) ?? true)
                {
                    MessageBox.Show("Brak uprawnień lekarza", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var lekarz = _dbHelper.PobierzDaneLekarza(uzytkownik.Id);
                if (lekarz == null)
                {
                    MessageBox.Show("Nie znaleziono danych lekarza", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                
                lekarz.Email = uzytkownik.Email;
                lekarz.Haslo = haslo; 

                this.Hide();
                var panelLekarza = new PanelLekarza(lekarz, _dbHelper);
                panelLekarza.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
#if DEBUG
                Console.WriteLine(ex.ToString());
#endif
            }
        }

        private void FormLogowanieLekarz_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                Application.Exit();
            }
        }
    }
}