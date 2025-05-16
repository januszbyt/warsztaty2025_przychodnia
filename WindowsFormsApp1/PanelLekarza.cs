using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Forms;
using WindowsFormsApp1.Models;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Linq;
// Users System.Windows.Forms; // TODO: Dawid Kotliński: odkomentować

namespace WindowsFormsApp1
{
    public partial class PanelLekarza : Form
    {
        private readonly DataBaseHelper _dbHelper;
        private readonly Lekarz _lekarz;
        private int wybranaWizytaId = -1;
        private int wybranyPacjentId = -1;
        private int lekarzId;
        private int wizytaId;


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
            WczytajAktualneDaneLekarza();
            WczytajPacjentow();

            InitializeWizytyPacjentDataGridView();





        }

        private void InitializeWizytyPacjentDataGridView()
        {
            dataGridViewWizytyPacjent.Columns.Clear();

            dataGridViewWizytyPacjent.Columns.Add("Data", "Data");
            dataGridViewWizytyPacjent.Columns.Add("Status", "Status");
            dataGridViewWizytyPacjent.Columns.Add("Opis", "Opis");
            dataGridViewWizytyPacjent.Columns.Add("Diagnoza", "Diagnoza");
            dataGridViewWizytyPacjent.Columns.Add("Zalecenia", "Zalecenia");
            dataGridViewWizytyPacjent.Columns.Add("Recepta", "Recepta");

            dataGridViewWizytyPacjent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewWizytyPacjent.ReadOnly = true;
            dataGridViewWizytyPacjent.AllowUserToAddRows = false;
        }
        private void WczytajPacjentow()
        {
            var pacjenci = _dbHelper.PobierzPacjentow();
            dataGridViewPacjenci.DataSource = pacjenci;


            if (dataGridViewPacjenci.Columns["Id"] != null)
                dataGridViewPacjenci.Columns["Id"].Visible = false;

            dataGridViewPacjenci.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private DateTime PanelLekarza_GetSelectedDate()
        {
            return dateTimePickerPacjenci.Value.Date;
        }

        private void WczytajWizyty()
        {
            // TODO: Dawid Kotliński: Wykarzacza LINQ
            var wizyty = _dbHelper.PobierzWizytyLekarza(_lekarz.Id);
            // .AsEnumerable()
            // .Where(row => row.Field<DateTime>("DataWizyty").Date == PanelLekarza_GetSelectedDate())
            // .ToList();

            dataGridViewWizyty.DataSource = wizyty;
            if (dataGridViewWizyty.Columns["Id"] != null)
                dataGridViewWizyty.Columns["Id"].Visible = false;
        }

        // TODO: Dawid Kotlinski: ODkomentować, były problemy z dostępem do klasy TextBox.
        // private TextBox LekarzIdTextbox()
        // {
        //     return textBox3;
        // }
        // private TextBox LekarzEmailTextbox()
        // {
        //     return textBox11;
        // }
        // private TextBox LekarzHasloTextbox()
        // {
        //     return textBox12;
        // }
        // private TextBox LekarzImieNazwiskoTextbox()
        // {
        //     return textBox5;
        // }
        // private TextBox LekarzSpecjalizacjaTextbox()
        // {
        //     return textBox4;
        // }
        // private TextBox LekarzTelefonTextBox()
        // {
        //     return textBox8;
        // }
        // private TextBox LekarzAdresTextBox()
        // {
        //     return textBox6;
        // }
        // private TextBox LekarzMiejscowoscTextBox()
        // {
        //     return textBox9;
        // }
        // private TextBox LekarzKodPocztowyTextBox()
        // {
        //     return textBox10;
        // }

        private void WczytajAktualneDaneLekarza()
        {
            // LekarzIdTextbox().Text = $"{_lekarz.Id}";
            // TODO: Dawid Kotlinski: Lekarz musi pobierać Usera, kod w projekcie jest tylko zakomentowany. Trzeba go odkomentować przestować na kompuetrze z bazą danych (model Lekarz).
            // LekarzEmailTextbox().Text = $"{_lekarz.Email}";
            // LekarzHasloTextbox().Text = $"{_lekarz.Haslo}";
            // LekarzImieNazwiskoTextbox().Text = $"{_lekarz.Imie} {_lekarz.Nazwisko}";
            // LekarzSpecjalizacjaTextbox().Text = $"{_lekarz.Specjalizacja}";
            // LekarzTelefonTextBox().Text = $"{_lekarz.Telefon}";
            // LekarzAdresTextBox().Text = $"{_lekarz.Adres}";
            // LekarzMiejscowoscTextBox().Text = $"{_lekarz.Miejscowosc}";
            // LekarzKodPocztowyTextBox().Text = $"{_lekarz.KodPocztowy}";
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

        // TODO: Dawid Kotlinski: Odkomentować, były problemy z dostępem do klasy TextBox.
        // private TextBox ImieNazwiskoSzukajTextBox()
        // {
        //     return textBox2;
        // }

        private void btnSzukaj_Click(object sender, EventArgs e)
        {
            // TODO: Dawid Kotlinski: Odkomentować, były problemy z dostępem do klasy TextBox.
            // string imieNazwisko = ImieNazwiskoSzukajTextBox().Text.Trim();

            // if (string.IsNullOrWhiteSpace(imieNazwisko))
            // {
            //     WczytajWizyty();
            //     return;
            // }

            // var wyniki = _dbHelper.SzukajWizytPoImieniuNazwisku(_lekarz.Id, imieNazwisko);
            // dataGridViewWizyty.DataSource = wyniki;
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
                MessageBox.Show("Wybierz pacjenta.");
                return;
            }

            if (wizytaId == -1) // TODO: wybranaWizytaId czy wizytId?
            {
                MessageBox.Show("Wybierz wizytę.");
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
                wizytaId: wizytaId, // TODO: wybranaWizytaId czy wizytId?
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
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView2.SelectedRows[0];
                var pacjentId = (int)selectedRow.Cells["Id"].Value;

                var wizyty = _dbHelper.PobierzWizytyPacjentaZSzczegolami(pacjentId);
                dataGridViewWizytyPacjent.AutoGenerateColumns = true;
                dataGridViewWizytyPacjent.DataSource = wizyty;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateDetails()
        {
            if (_lekarz.UserId < 0)
            {
                MessageBox.Show("Nieprawidłowy ID użytkownika.");
                return;
            }

            var newMail = textBox3.Text.Trim();
            var newPass = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(newMail))
            {
                MessageBox.Show("Email nie może być pusty.");
                return;
            }

            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Hasło nie może być puste.");
                return;
            }

            try
            {
                _dbHelper.ZmienEmail(_lekarz.UserId, newMail);
                _dbHelper.ZmienHaslo(_lekarz.UserId, newPass);
                MessageBox.Show("Dane zostały zaktualizowane.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas aktualizacji danych: {ex.Message}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDetails();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FormLogowanieRola formrola = new FormLogowanieRola(_dbHelper);
            this.Hide();
            formrola.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateDetails();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelLekarzId_Click(object sender, EventArgs e)
        {

        }

        private void labelSpecjalizacja_Click(object sender, EventArgs e)
        {

        }

        private void labelLekarzImieNazwisko_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            // TODO: Dawid Kotliński: Wykarzacza LINQ
            var wizyty = _dbHelper.PobierzWizytyLekarza(_lekarz.Id);
            //    .AsEnumerable()
            //    .Where(row => row.Field<DateTime>("DataWizyty").Date == PanelLekarza_GetSelectedDate())
            //    .ToList();

            dataGridViewWizyty.DataSource = wizyty;

            if (dataGridViewWizyty.Columns["Id"] != null)
                dataGridViewWizyty.Columns["Id"].Visible = false;
        }

        private void buttonSzukaj_Click(object sender, EventArgs e)
        {
            string imieNazwisko = textBoxImieNazwisko.Text.Trim();
            if (string.IsNullOrWhiteSpace(imieNazwisko))
            {
                MessageBox.Show("Wpisz imię i nazwisko.");
                return;
            }

            var pacjenci = _dbHelper.SzukajPacjentowLekarza(lekarzId, imieNazwisko);

            if (pacjenci.Count == 0)
            {
                MessageBox.Show("Nie znaleziono pacjentów.");
                dataGridView2.DataSource = null;
                dataGridViewWizytyPacjent.DataSource = null;
                return;
            }

            
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.DataSource = pacjenci;

           
            string[] kolumnyDoWyswietlenia = { "Imie", "Nazwisko", "DateOfBirth", "PESEL", "Miasto", "Adres", "PhoneNumber" };

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.Visible = kolumnyDoWyswietlenia.Contains(column.Name);

                
                switch (column.Name)
                {
                    case "DateOfBirth":
                        column.HeaderText = "Data urodzenia";
                        break;
                    case "PESEL":
                        column.HeaderText = "PESEL";
                        break;
                    case "PhoneNumber":
                        column.HeaderText = "Telefon";
                        break;
                }
            }

            
            if (dataGridView2.Columns["DateOfBirth"] != null)
            {
                dataGridView2.Columns["DateOfBirth"].DefaultCellStyle.Format = "dd.MM.yyyy";
            }

            
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void buttonPokazInformacje_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz pacjenta z listy.");
                return;
            }

           
            DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

           
            int pacjentId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

            
            var wizyty = _dbHelper.PobierzWizytyPacjentaZSzczegolami(pacjentId);

          
            dataGridViewWizytyPacjent.Rows.Clear();

            
            foreach (var wizyta in wizyty)
            {
                dynamic w = wizyta; 

                dataGridViewWizytyPacjent.Rows.Add(
                    w.Data,
                    w.Status,
                    w.Opis,
                    w.Diagnoza,
                    w.Zalecenia,
                    w.Recepta
                );
            }

          
          
        }
    }
}
