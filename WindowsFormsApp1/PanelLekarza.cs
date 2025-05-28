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
using System.Globalization;
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
            this.dataGridViewPacjenci.SelectionChanged += new System.EventHandler(this.dataGridViewPacjenci_SelectionChanged);
            this.FormClosed += new FormClosedEventHandler(FormPanelLekarza_FormClosed);
            WczytajWizyty();
            WczytajAktualneDaneLekarza();
            WczytajPacjentow();

            InitializeWizytyPacjentDataGridView();
            WczytajDaneLekarza();
            WczytajDzisiejszeWizyty();





        }

        private void InitializeWizytyPacjentDataGridView()
        {
            dataGridViewWizyty.Columns.Clear();

            dataGridViewWizyty.Columns.Add("Data", "Data");
            dataGridViewWizyty.Columns.Add("Status", "Status");
            dataGridViewWizyty.Columns.Add("Opis", "Opis");
            dataGridViewWizyty.Columns.Add("Diagnoza", "Diagnoza");
            dataGridViewWizyty.Columns.Add("Zalecenia", "Zalecenia");
            dataGridViewWizyty.Columns.Add("Recepta", "Recepta");

            dataGridViewWizyty.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewWizyty.ReadOnly = true;
            dataGridViewWizyty.AllowUserToAddRows = false;
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
            DateTime wybranaData = monthCalendar1.SelectionStart;
            dataGridViewWizyty.DataSource = _dbHelper.PobierzWizyty(lekarzId, data: wybranaData);
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

        

        private void btnSkierowanie_Click_1(object sender, EventArgs e)
        {
            if (wybranyPacjentId <= 0)
            {
                MessageBox.Show("Wybierz pacjenta.");
                return;
            }

            
            Form inputForm = new Form
            {
                Width = 400,
                Height = 280,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Nowe Skierowanie",
                StartPosition = FormStartPosition.CenterScreen
            };

            Label labelCel = new Label() { Left = 20, Top = 20, Text = "Cel:" };
            System.Windows.Forms.TextBox txtCel = new System.Windows.Forms.TextBox()
            { Left = 80, Top = 20, Width = 280 };

            Label labelOpis = new Label() { Left = 20, Top = 60, Text = "Opis:" };
            System.Windows.Forms.TextBox txtOpis = new System.Windows.Forms.TextBox() { Left = 80, Top = 60, Width = 280, Height = 100, Multiline = true };

            System.Windows.Forms.Button btnZapisz = new System.Windows.Forms.Button()
            { Text = "Zapisz", Left = 280, Width = 80, Top = 180, DialogResult = DialogResult.OK };

            inputForm.Controls.Add(labelCel);
            inputForm.Controls.Add(txtCel);
            inputForm.Controls.Add(labelOpis);
            inputForm.Controls.Add(txtOpis);
            inputForm.Controls.Add(btnZapisz);
            inputForm.AcceptButton = btnZapisz;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                string cel = txtCel.Text.Trim();
                string opis = txtOpis.Text.Trim();

                if (string.IsNullOrWhiteSpace(cel))
                {
                    MessageBox.Show("Wpisz cel skierowania.");
                    return;
                }

                _dbHelper.DodajSkierowanie(wybranyPacjentId, lekarzId, cel, opis);
                MessageBox.Show("Skierowanie zostało zapisane.");
            }
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
                dataGridViewWizyty.AutoGenerateColumns = true;
                dataGridViewWizyty.DataSource = wizyty;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            var lekarz = new Lekarz
            {
                Id = int.Parse(textBox3.Text),
                Specjalizacja = textBox4.Text,
                Imie = textBox5.Text,
                Nazwisko = textBox2.Text,
                Adres = textBox6.Text,
                Pesel = textBox7.Text,
                Telefon = textBox8.Text,
                Miasto = textBox9.Text,
                KodPocztowy = textBox10.Text,
                Email = textBox11.Text,
                Haslo = textBox12.Text
            };

            bool sukces = _dbHelper.AktualizujDaneLekarza(lekarz);
            if (sukces)
            {
                MessageBox.Show("Dane lekarza zostały zaktualizowane.");
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            FormLogowanieRola formrola = new FormLogowanieRola(_dbHelper);
            this.Hide();
            formrola.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
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
                dataGridViewWizyty.DataSource = null;
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

          
            dataGridViewWizyty.Rows.Clear();

            
            foreach (var wizyta in wizyty)
            {
                dynamic w = wizyta; 

                dataGridViewWizyty.Rows.Add(
                    w.Data,
                    w.Status,
                    w.Opis,
                    w.Diagnoza,
                    w.Zalecenia,
                    w.Recepta
                );
            }



          
          
        }

        private void dataGridViewPacjenci_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewPacjenci.SelectedRows.Count > 0)
            {
                var row = dataGridViewPacjenci.SelectedRows[0];
                try
                {
                    wybranyPacjentId = Convert.ToInt32(row.Cells["Id"].Value);
                }
                catch
                {
                    MessageBox.Show("Nie można odczytać ID pacjenta.");
                }
            }
        }


        private void WczytajDzisiejszeWizyty()
        {
            DataBaseHelper db = new DataBaseHelper();
            dataGridViewPacjenci.DataSource = db.PobierzDzisiejszeWizyty(lekarzId);
        }

        private void WczytajDaneLekarza()
        {
            var lekarz = _dbHelper.PobierzDaneLekarza(_lekarz.Id);
            if (lekarz != null)
            {
                textBox3.Text = lekarz.Id.ToString();
                textBox4.Text = lekarz.Specjalizacja;
                textBox5.Text = lekarz.Imie;
                textBox2.Text = lekarz.Nazwisko;
                textBox6.Text = lekarz.Adres;
                textBox7.Text = lekarz.Pesel;
                textBox8.Text = lekarz.Telefon;
                textBox9.Text = lekarz.Miasto;
                textBox10.Text = lekarz.KodPocztowy;
                textBox11.Text = lekarz.Email;
                textBox12.Text = lekarz.Haslo;
            }
            else
            {
                MessageBox.Show("Nie znaleziono lekarza o podanym ID.");
            }
        }

        private void buttonPokazInformacje_Click_1(object sender, EventArgs e)
        {

            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz pacjenta z listy.");
                return;
            }

            try
            {
                
                DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                int pacjentId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                
                var wizyty = _dbHelper.PobierzWizytyPacjentaZSzczegolami(pacjentId);

                
                dataGridViewWizytyhehe.AutoGenerateColumns = true;
                dataGridViewWizytyhehe.DataSource = null;
                dataGridViewWizytyhehe.DataSource = wizyty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas pobierania wizyt pacjenta: " + ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRecepta_Click_1(object sender, EventArgs e)
        {
            if (wybranyPacjentId <= 0)
            {
                MessageBox.Show("Wybierz pacjenta.");
                return;
            }

            Form inputForm = new Form
            {
                Width = 400,
                Height = 360,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = "Nowa Recepta",
                StartPosition = FormStartPosition.CenterScreen
            };

            var labelKod = new System.Windows.Forms.Label() { Left = 20, Top = 20, Text = "Kod recepty:" };
            var txtKod = new System.Windows.Forms.TextBox() { Left = 120, Top = 20, Width = 240 };

            var labelLeki = new System.Windows.Forms.Label() { Left = 20, Top = 60, Text = "Leki:" };
            var txtLeki = new System.Windows.Forms.TextBox() { Left = 120, Top = 60, Width = 240, Height = 80, Multiline = true };

            var labelUwagi = new System.Windows.Forms.Label() { Left = 20, Top = 150, Text = "Uwagi:" };
            var txtUwagi = new System.Windows.Forms.TextBox() { Left = 120, Top = 150, Width = 240, Height = 80, Multiline = true };

            var btnZapisz = new System.Windows.Forms.Button() { Text = "Zapisz", Left = 280, Width = 80, Top = 250, DialogResult = DialogResult.OK };

            inputForm.Controls.Add(labelKod);
            inputForm.Controls.Add(txtKod);
            inputForm.Controls.Add(labelLeki);
            inputForm.Controls.Add(txtLeki);
            inputForm.Controls.Add(labelUwagi);
            inputForm.Controls.Add(txtUwagi);
            inputForm.Controls.Add(btnZapisz);

            inputForm.AcceptButton = btnZapisz;

            if (inputForm.ShowDialog() == DialogResult.OK)
            {
                string kod = txtKod.Text.Trim();
                string leki = txtLeki.Text.Trim();
                string uwagi = txtUwagi.Text.Trim();

                _dbHelper.DodajRecepte(wybranyPacjentId, lekarzId, kod, leki, uwagi);
                MessageBox.Show("Recepta została zapisana.");
            }
        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            if (wybranyPacjentId <= 0)
            {
                MessageBox.Show("Wybierz pacjenta.");
                return;
            }

            string opis = textBox15.Text.Trim();
            string diagnoza = textBox16.Text.Trim();
            string zalecenia = txtZalecenia.Text.Trim();

            _dbHelper.ZatwierdzWizyteDlaPacjenta(wybranyPacjentId, lekarzId, opis, diagnoza, zalecenia);

            textBox15.Clear();
            textBox16.Clear();
            txtZalecenia.Clear();

            WczytajWizyty(); 
        }

      

        private void buttonPrzeszleWizyty_Click_1(object sender, EventArgs e)
        {
            dataGridViewWizyty.DataSource = _dbHelper.PobierzWizyty(lekarzId, tylkoPrzeszle: true);
        }

        private void buttonPrzyszleWizyty_Click_1(object sender, EventArgs e)
        {
            dataGridViewWizyty.DataSource = _dbHelper.PobierzWizyty(lekarzId, null, tylkoPrzyszle: true);
        }

        private void tabPageUstawienia_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormPanelLekarza_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

