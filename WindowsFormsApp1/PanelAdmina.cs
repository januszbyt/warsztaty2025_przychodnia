using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Models;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class PanelAdmina : Form
    {
        
        private int selectedUserId;
        private DataBaseHelper _dbHelper;

        public PanelAdmina()
        {
            InitializeComponent();
            
            try
            {
                _dbHelper = new DataBaseHelper();
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

       

        private void buttonZabierzUprawnienia_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz użytkownika z listy", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

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
                    _dbHelper.ZabierzUprawnieniaLekarza(userId);
                    MessageBox.Show("Pomyślnie odebrano uprawnienia lekarza.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OdswiezDane();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OdswiezDane()
        {
            dataGridView1.DataSource = _dbHelper.PobierzListeLekarzy();
            dataGridView1.Refresh();
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
                        // Sprawdź, czy to widok lekarzy, np. po kolumnie "Specjalizacja"
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
            
                dataGridView1.DataSource = _dbHelper.PobierzWszystkichLekarzy();
            
            
                dataGridView1.DataSource = _dbHelper.PobierzWszystkichPacjentow();
            
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

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBoxHaslo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoxSpecjalizacja_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNazwisko_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxImie_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void PanelAdmina_Load(object sender, EventArgs e)
        {

        }
    }
}