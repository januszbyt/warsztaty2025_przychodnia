using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Models;
using MySql.Data.MySqlClient;
using System.Drawing;


namespace WindowsFormsApp1
{
    public partial class PanelAdmina : Form
    {

        private int selectedUserId;
        private DataBaseHelper _dbHelper;

        private bool oczekujeNaSpecjalizacje = false;
        private bool ciemnyTryb = false;
        public event EventHandler Wylogowano;
        public PanelAdmina()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FormPanelAdmina_FormClosed);

            try
            {
                _dbHelper = new DataBaseHelper();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd inicjalizacji bazy: {ex.Message}");
                this.Close();
            }
            // Ukrycie specjalizacji
            textBoxSpecjalizacjaUprawnienia.Visible = false;
            label1.Visible = false;
            textBoxSpecjalizacjaUprawnienia.Clear();
            // ukrycie resetu hasla
            textBox1.Visible = false;
            label2.Visible = false;
            buttonResetujHaslo.Visible = false;

            LoadTheme();
        }



        private void buttonWyswietlPacjentow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dbHelper.PobierzWszystkichPacjentow();
            dataGridView1.Visible = true;


            // Ukrycie specjalizacji
            textBoxSpecjalizacjaUprawnienia.Visible = false;
            label1.Visible = false;
            textBoxSpecjalizacjaUprawnienia.Clear();
            // ukrycie resetu hasla
            textBox1.Visible = false;
            label2.Visible = false;
            buttonResetujHaslo.Visible = false;
        }

        private void buttonWyswierlLekarzy_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dbHelper.PobierzWszystkichLekarzy();
            dataGridView1.Visible = true;

            // Ukrycie specjalizacji
            textBoxSpecjalizacjaUprawnienia.Visible = false;
            label1.Visible = false;
            textBoxSpecjalizacjaUprawnienia.Clear();
            // ukrycie resetu hasla
            textBox1.Visible = false;
            label2.Visible = false;
            buttonResetujHaslo.Visible = false;
        }

        private void buttonNadajUprawienia_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika z listy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            if (string.IsNullOrWhiteSpace(textBoxSpecjalizacjaUprawnienia.Text))
            {
                textBoxSpecjalizacjaUprawnienia.Visible = true;
                label1.Visible = true;
                textBoxSpecjalizacjaUprawnienia.Focus();
                oczekujeNaSpecjalizacje = true;
                //TEGO NIE TRZEBA CHYBA ŻE CHCECIE
                // MessageBox.Show("Podaj specjalizację, zanim nadasz uprawnienia.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (oczekujeNaSpecjalizacje)
            {
                oczekujeNaSpecjalizacje = false; // reset flagi
            }

            string specjalizacja = textBoxSpecjalizacjaUprawnienia.Text.Trim();

            try
            {
                _dbHelper.NadajUprawnieniaLekarza(selectedUserId, specjalizacja);
                MessageBox.Show("Uprawnienia nadane pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxSpecjalizacjaUprawnienia.Clear();
                textBoxSpecjalizacjaUprawnienia.Visible = false;
                label1.Visible = false;
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas nadawania uprawnień: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonZabierzUprawnienia_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika z listy", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["UserId"].Value);
            int Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

            try
            {
                string status = _dbHelper.SprawdzStatusLekarza(userId);

                var potwierdzenie = MessageBox.Show(
                    $"Czy na pewno chcesz odebrać uprawnienia lekarza?\n\n{status}",
                    "Potwierdzenie",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (potwierdzenie == DialogResult.Yes)
                {
                    _dbHelper.ZabierzUprawnieniaLekarza(Id, userId);
                    MessageBox.Show("Pomyślnie odebrano uprawnienia lekarza.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonUsunRekordy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                var result = MessageBox.Show("Czy na pewno chcesz usunąć ten rekord?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Sprawdzenie, czy to widok lekarzy,  po kolumnie "Specjalizacja"
                        if (dataGridView1.Columns.Contains("Specjalizacja"))
                        {
                            _dbHelper.UsunLekarza(selectedUserId);
                            MessageBox.Show("Lekarz został usunięty.");
                        }
                        else
                        {
                            _dbHelper.UsunUzytkownika(selectedUserId);
                            MessageBox.Show("Użytkownik został usunięty.");
                        }

                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd podczas usuwania: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć rekord do usunięcia.");
            }
        }


        private void RefreshGrid()
        {

            dataGridView1.DataSource = _dbHelper.PobierzWszystkichLekarzy();
            dataGridView1.Refresh();

            dataGridView1.DataSource = _dbHelper.PobierzWszystkichPacjentow();
            dataGridView1.Refresh();

        }



        private void buttonUsunWszystko_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Czy na pewno chcesz usunąć wszystkie dane z bazy?", "Potwierdzenie", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                _dbHelper.UsunWszystkieDane();
                RefreshGrid();
            }
        }

        private void WylogujAdmin_Click(object sender, EventArgs e)
        {
            Wylogowano?.Invoke(this, EventArgs.Empty); // Powiadom o wylogowaniu
            this.Close();

        }





        private void PanelAdmina_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
        }

        private void textBoxSpecjalizacjaUprawnienia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Działanie przycisku reset hasła resetuje hasła w tabeli users
        private void buttonResetujHaslo_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika z listy.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            string noweHaslo = textBox1.Text.Trim();

            if (string.IsNullOrEmpty(noweHaslo))
            {
                MessageBox.Show("Wprowadź nowe hasło.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                _dbHelper.ZmienHasloUzytkownika(selectedUserId, noweHaslo);
                MessageBox.Show("Hasło zostało zresetowane.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd przy resetowaniu hasła: " + ex.Message);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {
            //etykieta resetu hasła
        }

        //przycisk wyświetlający reset hasla

        private void ResetHasla_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Visible = true;
                label2.Visible = true;
                buttonResetujHaslo.Visible = true;
                return;
            }

        }

        private void FormPanelAdmina_FormClosed(object sender, FormClosedEventArgs e)
        {
           // Application.Exit();
        }

        private void LoadTheme()
        {

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

        private void buttonToggleThema_Click(object sender, EventArgs e)
        {

        }

        private void buttonPowiadomienia_Click(object sender, EventArgs e)
        {
            FormPowiadomienia formPowiadomienia = new FormPowiadomienia();


            formPowiadomienia.Show();
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            ciemnyTryb = !ciemnyTryb;
            UstawTryb();
        }

        private void UstawTryb()
        {
            Color tloFormularza, kolorTekstu;
            string napisPrzycisku;

            if (ciemnyTryb)
            {
                tloFormularza = Color.FromArgb(64, 64, 64);
                kolorTekstu = Color.White;
                napisPrzycisku = "Tryb jasny";
            }
            else
            {
                tloFormularza = Color.FromArgb(255, 192, 192);
                kolorTekstu = Color.Black;
                napisPrzycisku = "Tryb ciemny";
            }

            this.BackColor = tloFormularza;
            this.ForeColor = kolorTekstu;
            btnToggleTheme.Text = napisPrzycisku;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.BackColor = Color.White;
                    ctrl.ForeColor = Color.Black;
                }
                else
                {
                    ctrl.BackColor = tloFormularza;
                    ctrl.ForeColor = kolorTekstu;
                }
            }
        }
    }
}