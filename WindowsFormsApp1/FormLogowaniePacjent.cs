using System;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1
{
    public partial class FormLogowaniePacjent : Form
    {
        private readonly DataBaseHelper _dbHelper;

        public FormLogowaniePacjent(DataBaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper ?? throw new ArgumentNullException(nameof(_dbHelper));
            textBoxHasloPacjent.PasswordChar = '•';
            checkBoxPokazHaslo.Checked = false;
            this.FormClosed += new FormClosedEventHandler(FormLogowaniePacjent_FormClosed);
        }

        public FormLogowaniePacjent()
        {
            InitializeComponent();
            this.AcceptButton = this.buttonZalogujPacjent;
        }

       

        private void checkBoxPokazHaslo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxHasloPacjent.PasswordChar = checkBoxPokazHaslo.Checked ? '\0' : '•';
        }

        private void buttonZalogujPacjent_Click(object sender, EventArgs e)
        {

            try
            {
                string email = textBoxLoginPacjent.Text.Trim();
                string haslo = textBoxHasloPacjent.Text.Trim();

                if (!ValidateLoginForm(email, haslo)) return;

                var users = _dbHelper.ZalogujUzytkownika(email, haslo);

                if (users == null)
                {
                    MessageBox.Show("Nieprawidłowy email lub hasło!", "Błąd logowania",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var pelneDane = _dbHelper.PobierzDanePacjenta(users.Id);

                if (pelneDane == null)
                {
                    MessageBox.Show("Nie znaleziono pełnych danych pacjenta!", "Błąd",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.Hide();
                var formPacjent = new FormPacjent(_dbHelper, users.Id);
                formPacjent.Closed += (s, args) => this.Close();
                formPacjent.Show();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd logowania: {ex.Message}\n\nSzczegóły: {ex.StackTrace}",
                              "blad jak ciul",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private bool ValidateLoginForm(string email, string haslo)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email jest wymagany!", "powazny blad panie kolego",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLoginPacjent.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Hasło jest wymagane!", "powazny blad panie kolego",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxHasloPacjent.Focus();
                return false;
            }

            return true;
        }

        

       

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            var formLogowanieRola = new FormLogowanieRola(_dbHelper);
            formLogowanieRola.Closed += (s, args) => Close();
            formLogowanieRola.Show();
            this.AcceptButton = this.button3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormRejestracja formRejestracja = new FormRejestracja(_dbHelper);
            formRejestracja.Show();
            this.Hide();

        }

        private void FormLogowaniePacjent_Load(object sender, EventArgs e)
        {

        }

        private void FormLogowaniePacjent_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}