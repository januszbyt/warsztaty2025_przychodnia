using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Models;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class PanelLekarza : Form
    {
        private readonly DataBaseHelper _dbHelper;
        private readonly Lekarz _lekarz;
        private int wybranaWizytaId = -1;
        private int wybranyPacjentId = -1;
        private int lekarzId;
        private int wizytId;

        public PanelLekarza(Lekarz lekarz, DataBaseHelper dbHelper)
        {
            InitializeComponent();

            _lekarz = lekarz ?? throw new ArgumentNullException(nameof(lekarz));
            _dbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));
            lekarzId = _lekarz.Id;
            Text = $"Panel Lekarza - {_lekarz.Imie} {_lekarz.Nazwisko}";

            dataGridViewWizyty.AutoGenerateColumns = true;
            dataGridViewPacjenci.AutoGenerateColumns = true;

            WczytajWizyty();
            WyswietlDaneLekarza();
            WczytajPacjentow();
            
        }
        private void WczytajPacjentow()
        {
            var pacjenci = _dbHelper.PobierzPacjentow();
            dataGridViewPacjenci.DataSource = pacjenci;

           
            if (dataGridViewPacjenci.Columns["Id"] != null)
                dataGridViewPacjenci.Columns["Id"].Visible = false;

            dataGridViewPacjenci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void WczytajWizyty()
        {
            var wizyty = _dbHelper.PobierzWizytyLekarza(_lekarz.Id);
            dataGridViewWizyty.DataSource = wizyty;

            if (dataGridViewWizyty.Columns["Id"] != null)
                dataGridViewWizyty.Columns["Id"].Visible = false;
        }
        private void WyswietlDaneLekarza()
        {
            labelLekarzId.Text = $"ID: {_lekarz.Id}";
            labelLekarzImieNazwisko.Text = $"Lekarz: {_lekarz.Imie} {_lekarz.Nazwisko}";
            labelSpecjalizacja.Text = $"Specjalizacja: {_lekarz.Specjalizacja}";
        }

        private void dataGridViewWizyty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridViewWizyty.Rows[e.RowIndex];
                wybranaWizytaId = Convert.ToInt32(row.Cells["Id"].Value);
                wybranyPacjentId = Convert.ToInt32(row.Cells["PacjentId"].Value);

                var szczegoly = _dbHelper.PobierzSzczegolyWizyty(wybranaWizytaId);
                if (szczegoly != null)
                {
                    txtRecepta.Text = szczegoly.Opis ?? string.Empty;
                    txtSkierowanie.Text = szczegoly.Diagnoza ?? string.Empty;
                    txtZalecenia.Text = szczegoly.Zalecenia ?? string.Empty;
                }
            }
        }

        private void WczytajHistoriePacjenta(int pacjentId)
        {
            try
            {
                var historia = _dbHelper.PobierzHistorieWizytPacjenta(pacjentId);
                dataGridViewPacjenci.DataSource = historia;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania historii: {ex.Message}", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWizyty_Click(object sender, EventArgs e)
        {
            if (wybranyPacjentId > 0)
            {
                WczytajHistoriePacjenta(wybranyPacjentId);
            }
            else
            {
                MessageBox.Show("Najpierw wybierz wizytę pacjenta z listy.");
            }
        }

        private void btnZapisz_Click(object sender, EventArgs e)
        {
            if (wybranaWizytaId == -1)
            {
                MessageBox.Show("Wybierz wizytę.");
                return;
            }

            _dbHelper.ZaktualizujWizyte(
                wybranaWizytaId,
                txtRecepta.Text,
                txtSkierowanie.Text,
                txtZalecenia.Text
            );

            MessageBox.Show("Wizyta została zaktualizowana.");
            WczytajWizyty();
        }

        private void btnRecepta_Click(object sender, EventArgs e)
        {
            if (wybranyPacjentId == -1)
            {
                MessageBox.Show("Wybierz wizytę.");
                return;
            }

            string kodRecepty = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            string leki = Microsoft.VisualBasic.Interaction.InputBox("Wprowadź leki:", "Recepta");

            if (!string.IsNullOrWhiteSpace(leki))
            {
                _dbHelper.WystawRecepte(wybranyPacjentId, _lekarz.Id, kodRecepty, leki);
                MessageBox.Show($"Recepta wystawiona. Kod: {kodRecepty}");
            }
        }

        private void btnSkierowanie_Click(object sender, EventArgs e)
        {
            if (wybranyPacjentId == -1)
            {
                MessageBox.Show("Wybierz wizytę.");
                return;
            }

            string specjalizacja = Microsoft.VisualBasic.Interaction.InputBox("Na jaką specjalizację kierujesz?", "Skierowanie");
            string cel = Microsoft.VisualBasic.Interaction.InputBox("Wprowadź cel skierowania:", "Skierowanie");

            if (!string.IsNullOrWhiteSpace(specjalizacja) && !string.IsNullOrWhiteSpace(cel))
            {
                _dbHelper.WystawSkierowanie(wybranyPacjentId, _lekarz.Id, specjalizacja, cel);
                MessageBox.Show("Skierowanie wystawione.");
            }
        }

        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            this.Hide();
            var formLogowanie = new FormLogowanieLekarz(_dbHelper);
            formLogowanie.FormClosed += (s, args) => this.Close();
            formLogowanie.Show();
        }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            string imieNazwisko = btnSzukaj.Text.Trim();

            if (string.IsNullOrWhiteSpace(imieNazwisko))
            {
                WczytajWizyty();
                return;
            }

            var wyniki = _dbHelper.SzukajWizytPoImieniuNazwisku(_lekarz.Id, imieNazwisko);
            dataGridViewWizyty.DataSource = wyniki;
        }

      

        private void buttonPokazPacjentow_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridViewPacjenci.DataSource = _dbHelper.PobierzPacjentow();

                
                dataGridViewPacjenci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewPacjenci.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas ładowania pacjentów: {ex.Message}");
            }
        }

        private void btnRecepta_Click_1(object sender, EventArgs e)
        {
            txtRecepta.Visible = true;
            buttonZatwierdzRecepte.Visible = true;
        }

        private void buttonZatwierdzRecepte_Click(object sender, EventArgs e)
        {
            if (dataGridViewPacjenci.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz pacjenta.");
                return;
            }

            int pacjentId = Convert.ToInt32(dataGridViewPacjenci.SelectedRows[0].Cells["Id"].Value);
            string leki = txtRecepta.Text;
            string kod = Guid.NewGuid().ToString().Substring(0, 8);

            try
            {
                _dbHelper.WystawRecepte(
                    wizytaId: wybranaWizytaId, 
                    pacjentId: pacjentId,
                    lekarzId: _lekarz.Id, 
                    leki: leki,
                    uwagi: null,
                    kodRecepty: kod
                );

                MessageBox.Show("Recepta wystawiona pomyślnie!");
                txtRecepta.Text = "";
                txtRecepta.Visible = false;
                buttonZatwierdzRecepte.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas wystawiania recepty: {ex.Message}");
            }
        }

        private void btnSkierowanie_Click_1(object sender, EventArgs e)
        {
            txtSkierowanie.Visible = true;
            buttonZatwierdzSkierowanie.Visible = true;
        }

        private void buttonZatwierdzSkierowanie_Click(object sender, EventArgs e)
        {
            if (dataGridViewPacjenci.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz pacjentaa.");
                return;
            }

            int pacjentId = Convert.ToInt32(dataGridViewPacjenci.SelectedRows[0].Cells["Id"].Value);
            string cel = txtSkierowanie.Text.Trim();

            if (string.IsNullOrEmpty(cel))
            {
                MessageBox.Show("Wprowadź cel skierowania.");
                return;
            }

            string specjalizacja = Microsoft.VisualBasic.Interaction.InputBox("Na jaką specjalizację?", "Specjalizacja");

            if (string.IsNullOrEmpty(specjalizacja))
            {
                MessageBox.Show("Specjalizacja jest wymagana.");
                return;
            }

            _dbHelper.WystawSkierowanie(
                wizytaId: wizytId,
                pacjentId: pacjentId,
                lekarzId: _lekarz.Id,
                typ: specjalizacja,
                cel: cel,
                uwagi: null
            );

            MessageBox.Show("Skierowanie zostało wystawione.");
            txtSkierowanie.Clear();
            txtSkierowanie.Visible = false;
            buttonZatwierdzSkierowanie.Visible = false;
        }

        private void buttonpokapacjentow_Click(object sender, EventArgs e)
        {

            WczytajPacjentow();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormLogowanieRola rolaForm = new FormLogowanieRola(_dbHelper);
            rolaForm.Show();
            this.Hide();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewWizyty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
