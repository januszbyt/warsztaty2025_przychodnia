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
        
        private void buttonWyswierlLekarzy_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _dbHelper.PobierzWszystkichLekarzy();
            dataGridView1.Visible = true;
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
                MessageBox.Show("Podaj specjalizację, zanim nadasz uprawnienia.", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSpecjalizacjaUprawnienia.Visible = true;
                textBoxSpecjalizacjaUprawnienia.Focus();
                return;
            }

            string specjalizacja = textBoxSpecjalizacjaUprawnienia.Text.Trim();

            try
            {
                _dbHelper.NadajUprawnieniaLekarza(selectedUserId, specjalizacja);
                MessageBox.Show("Uprawnienia nadane pomyślnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBoxSpecjalizacjaUprawnienia.Clear();
                textBoxSpecjalizacjaUprawnienia.Visible = false;
                RefreshGrid(); // odśwież listę użytkowników/lekarzy
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
            this.Hide();
            var formLogowanie = new FormLogowanieRola(_dbHelper);
            formLogowanie.ShowDialog();
            this.Close();
        }

     
        

       
        private void PanelAdmina_Load(object sender, EventArgs e)
        {

        }
    }
}