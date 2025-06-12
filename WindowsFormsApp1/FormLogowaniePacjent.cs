using System;
using System.Drawing;
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
        private bool isDarkMode;

        public FormLogowaniePacjent(DataBaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));
            textBoxHasloPacjent.PasswordChar = '•';
            checkBoxPokazHaslo.Checked = false;

            this.FormClosed += new FormClosedEventHandler(FormLogowaniePacjent_FormClosed);
            LoadTheme();
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
                              "Błąd",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private bool ValidateLoginForm(string email, string haslo)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email jest wymagany!", "Uwaga",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxLoginPacjent.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Hasło jest wymagane!", "Uwaga",
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

        private void LoadTheme()
        {
            isDarkMode = Properties.Settings.Default.IsDarkMode;
            ApplyTheme(isDarkMode);
        }

        private void ApplyTheme(bool darkMode)
        {
            if (darkMode)
                ApplyThemeToControls(this, Color.FromArgb(30, 30, 30), Color.White);
            else
                ApplyThemeToControls(this, Color.White, Color.Black);
        }

        private void ApplyThemeToControls(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            control.ForeColor = foreColor;

            foreach (Control child in control.Controls)
            {
                ApplyThemeToControls(child, backColor, foreColor);
            }
        }

        private void buttonToggleTheme_Click(object sender, EventArgs e)
        {
            isDarkMode = !isDarkMode;
            ApplyTheme(isDarkMode);
            Properties.Settings.Default.IsDarkMode = isDarkMode;
            Properties.Settings.Default.Save();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = textBoxLoginPacjent.Text.Trim();

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Najpierw wpisz email, aby zmienić hasło.", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            var user = _dbHelper.ZnajdzUzytkownikaPoEmailu(email);
            if (user == null)
            {
                MessageBox.Show("Nie znaleziono użytkownika o tym adresie email.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            string noweHaslo = Microsoft.VisualBasic.Interaction.InputBox("Wprowadź nowe hasło:", "Zmiana hasła", "", -1, -1);
            string potwierdzHaslo = Microsoft.VisualBasic.Interaction.InputBox("Potwierdź nowe hasło:", "Zmiana hasła", "", -1, -1);

            if (noweHaslo != potwierdzHaslo)
            {
                MessageBox.Show("Nowe hasła nie są takie same!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(noweHaslo))
            {
                MessageBox.Show("Hasło nie może być puste!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            _dbHelper.ZmienHaslo(user.Id, noweHaslo);
            MessageBox.Show("Hasło zostało zmienione.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
