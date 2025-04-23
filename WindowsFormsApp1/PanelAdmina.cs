using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1
{
    public partial class PanelAdmina : Form
    {
        
        private int selectedUserId;
        private DataBaseHelper _dbHelper;

        public PanelAdmina()
        {
            InitializeComponent();
            UkryjFormularzLekarza();
            try
            {
                _dbHelper = new DataBaseHelper(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd inicjalizacji bazy: {ex.Message}");
                this.Close();
            }
        }

        

        private void buttonWyswietlPacjentow_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dbHelper.PobierzWszystkichPacjentow();
            dataGridView1.Visible = true;
        }

        private void buttonNadajUprawienia_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                textBoxSpecjalizacjaUprawnienia.Visible = true;
                
                if (!string.IsNullOrWhiteSpace(textBoxSpecjalizacjaUprawnienia.Text))
                {
                    try
                    {
                        _dbHelper.NadajUprawnieniaLekarza(selectedUserId, textBoxSpecjalizacjaUprawnienia.Text);
                        MessageBox.Show("Uprawnienia nadane pomyślnie.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Podaj specjalizację.");
                }
            }
            else
            {
                MessageBox.Show("Wybierz użytkownika z listy.");
            }
        }

        private void buttonFormNadaniaUprawnien_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSpecjalizacjaUprawnienia.Text))
            {
                MessageBox.Show("Proszę podać specjalizację");
                return;
            }

            try
            {
                _dbHelper.NadajUprawnieniaLekarza(selectedUserId, textBoxSpecjalizacjaUprawnienia.Text);
                MessageBox.Show("Pomyślnie nadano uprawnienia lekarza");
                textBoxSpecjalizacjaUprawnienia.Clear();
                textBoxSpecjalizacjaUprawnienia.Visible = false;


                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        private void buttonZabierzUprawnienia_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                var confirm = MessageBox.Show("Czy na pewno chcesz zabrać uprawnienia lekarza?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        _dbHelper.ZabierzUprawnieniaLekarza(selectedUserId);
                        MessageBox.Show("Zabrano uprawnienia lekarza.");
                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Zaznacz użytkownika z listy.");
            }
        }

        private void buttonUsunRekordy_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                var result = MessageBox.Show("Czy na pewno chcesz usunąć tego użytkownika?", "Potwierdzenie", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                       _dbHelper.UsunUzytkownika(selectedUserId);
                        MessageBox.Show("Użytkownik został usunięty.");
                        RefreshGrid();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd podczas usuwania użytkownika: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Proszę zaznaczyć użytkownika do usunięcia.");
            }
        }

        private void buttonDodajLekarza_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBoxImie.Text) ||
                    string.IsNullOrEmpty(textBoxNazwisko.Text) ||
                    string.IsNullOrEmpty(textBoxEmail.Text) ||
                    string.IsNullOrEmpty(textBoxHaslo.Text) ||
                    string.IsNullOrEmpty(textBoxSpecjalizacja.Text))
                {
                    MessageBox.Show("Wypełnij wszystkie pola formularza");
                    return;
                }

                var user = new Users
                {
                    Imie = textBoxImie.Text,
                    Nazwisko = textBoxNazwisko.Text,
                    Email = textBoxEmail.Text
                };

                string haslo = textBoxHaslo.Text;
                string specjalizacja = textBoxSpecjalizacja.Text;

                _dbHelper.RegisterUser(user, haslo, "Lekarz");

                int userId = _dbHelper.GetUserIdByEmailPublic(user.Email);
                _dbHelper.DodajDoLekarzy(userId, user.Imie, user.Nazwisko, specjalizacja);

                MessageBox.Show("Lekarz został dodany");
                ClearForm();
                RefreshGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd przy dodawaniu lekarza: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            textBoxImie.Clear();
            textBoxNazwisko.Clear();
            textBoxEmail.Clear();
            textBoxHaslo.Clear();
            textBoxSpecjalizacja.Clear();
        }

        private void RefreshGrid()
        {
            if (radioButtonLekarze.Checked)
            {
                dataGridView1.DataSource = _dbHelper.PobierzWszystkichLekarzy();
            }
            else if (radioButtonPacjenci.Checked)
            {
                dataGridView1.DataSource = _dbHelper.PobierzWszystkichPacjentow();
            }
        }

        private void UkryjFormularzLekarza()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox || control is Label)
                {
                    control.Visible = false;
                }
            }
            buttonDodajLekarza.Visible = false;
        }

        private void buttonFormDodaniaLekarza_Click(object sender, EventArgs e)
        {
            bool isVisible = textBoxImie.Visible;

            textBoxImie.Visible = !isVisible;
            textBoxNazwisko.Visible = !isVisible;
            textBoxEmail.Visible = !isVisible;
            textBoxHaslo.Visible = !isVisible;
            textBoxSpecjalizacja.Visible = !isVisible;
            buttonDodajLekarza.Visible = !isVisible;

            label1.Visible = !isVisible;
            label2.Visible = !isVisible;
            label3.Visible = !isVisible;
            label4.Visible = !isVisible;
            label5.Visible = !isVisible;

            buttonFormDodaniaLekarza.Text = isVisible ? "Formularz dodania lekarza" : "Ukryj formularz";
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
            this.Hide();
            var formLogowanie = new FormLogowanieLekarz(_dbHelper);
            formLogowanie.ShowDialog();
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                selectedUserId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
            }
        }

        private void buttonWyswierlLekarzy_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dbHelper.PobierzWszystkichLekarzy();
            dataGridView1.Visible = true;
        }
    }
}