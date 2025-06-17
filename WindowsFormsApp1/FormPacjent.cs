using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;
using System.ComponentModel;
using System.IO;
using System.Xml.Linq;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System.Linq;

namespace WindowsFormsApp1
{
    public partial class FormPacjent : Form
    {
        private readonly DataBaseHelper _dbHelper;
        private int _pacjentId;
        private string _wybranyPlik;
        private bool ciemnyTryb = false;
       


        public FormPacjent(DataBaseHelper dbHelper, int patientId = 0)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            _pacjentId = patientId;

            

            UstawFormularz();
            WczytajDanePacjenta();
            WczytajLekarzy();
            WczytajHistorieWizyt(_pacjentId);
            WczytajDokumenty();
            WczytajDanePacjenta();
            this.FormClosed += new FormClosedEventHandler(FormPacjent_FormClosed);
            LoadTheme();
            UstawTryb();

            
        }
        



        private void UstawFormularz()
        {
            comboBoxTypDokumentu.Items.AddRange(new string[]
            {
                "Wynik badania krwi", "RTG", "USG", "MRI", "CT",
                "Skierowanie", "Zaświadczenie", "Historia choroby",
                "Karta wypisu", "Notatka", "Recepta", "Zgoda", "Opis zabiegu", "Inne"
            });

            dateTimePickerWizyta.MinDate = DateTime.Today.AddDays(1);


         
            buttonWybierzPlik.Click += ButtonWybierzPlik_Click;


        }

        private void WczytajDanePacjenta()
        {
            if (_pacjentId <= 0)
                return;

            var pacjent = _dbHelper.PobierzDanePacjenta(_pacjentId);

            if (pacjent == null)
            {
                MessageBox.Show("Nie znaleziono pacjenta o podanym ID.");
                return;
            }


            textBoxImie.Text = pacjent.Imie;
            textBoxNazwisko.Text = pacjent.Nazwisko;
            dateTimePicker1.Value = pacjent.DateofBirth;
            textBoxPesel.Text = pacjent.PESEL;
            textBoxAdres.Text = pacjent.Adres;
            textBoxMiasto.Text = pacjent.Miasto;
            textBoxKodPocztowy.Text = pacjent.KodPocztowy;
            textBoxTelefon.Text = pacjent.PhoneNumber;
            textBoxEmail.Text = pacjent.Email;
            textBoxHaslo.Text = pacjent.Haslo;
            checkBoxAktywny.Checked = pacjent.IsActive;
        }

        private void buttonZapiszZmiany_Click(object sender, EventArgs e)
        {
            var pacjent = new Patient
            {
                Id = _pacjentId,
                Imie = textBoxImie.Text,
                Nazwisko = textBoxNazwisko.Text,
                DateofBirth = dateTimePicker1.Value,
                PESEL = textBoxPesel.Text,
                Adres = textBoxAdres.Text,
                Miasto = textBoxMiasto.Text,
                KodPocztowy = textBoxKodPocztowy.Text,
                PhoneNumber = textBoxTelefon.Text,
                Email = textBoxEmail.Text,
                IsActive = checkBoxAktywny.Checked
            };

            if (_pacjentId == 0)
            {
                _pacjentId = _dbHelper.DodajPacjenta(pacjent);
                MessageBox.Show("Dodano pacjenta.");
            }
            else
            {
                _dbHelper.AktualizujPacjenta(pacjent);
                MessageBox.Show("Zaktualizowano dane pacjenta.");
            }
        }

        private void WczytajPacjentaDoFormularza(int id)
        {
            var pacjent = _dbHelper.PobierzDanePacjenta(id);
            if (pacjent != null)
            {
                _pacjentId = pacjent.Id;
                textBoxImie.Text = pacjent.Imie;
                textBoxNazwisko.Text = pacjent.Nazwisko;
                dateTimePicker1.Value = pacjent.DateofBirth;
                textBoxPesel.Text = pacjent.PESEL;
                textBoxAdres.Text = pacjent.Adres;
                textBoxMiasto.Text = pacjent.Miasto;
                textBoxKodPocztowy.Text = pacjent.KodPocztowy;
                textBoxTelefon.Text = pacjent.PhoneNumber;
                textBoxEmail.Text = pacjent.Email;
                textBoxHaslo.Text = pacjent.Haslo;
                checkBoxAktywny.Checked = pacjent.IsActive;
            }
            else
            {
                MessageBox.Show("Nie znaleziono pacjenta o podanym ID.");
            }
        }

        private void WczytajLekarzy()
        {
            dataGridViewLekarze.DataSource = _dbHelper.PobierzDostepnychLekarzy();
            dataGridView1.DataSource = _dbHelper.PobierzDostepnychLekarzy();
        }

        private void buttonDodajWizyte_Click(object sender, EventArgs e)
        {
            if (_pacjentId == 0)
            {
                MessageBox.Show("Najpierw zapisz dane pacjenta.");
                return;
            }

            if (dataGridViewLekarze.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz lekarza.");
                return;
            }

            var lekarz = (Lekarz)dataGridViewLekarze.SelectedRows[0].DataBoundItem;
            var data = dateTimePickerWizyta.Value;


            if (!_dbHelper.CzyLekarzMaWolnyTermin(lekarz.Id, data))
            {
                MessageBox.Show("Lekarz nie ma wolnego terminu.");
                return;
            }

            var wizyta = new Wizyta
            {
                PacjentId = _pacjentId,
                LekarzId = lekarz.Id,
                DataWizyty = data,
                Status = "Zaplanowana",
                Specjalizacja = lekarz.Specjalizacja
            };

            _dbHelper.DodajWizyte(wizyta);
            MessageBox.Show("Dodano wizytę.");
            WczytajHistorieWizyt(_pacjentId);
        }

        private void WczytajHistorieWizyt(int _pacjentId)
        {
            dataGridViewHistoria.Rows.Clear();

            if (dataGridViewHistoria.Columns.Count == 0)
            {
                dataGridViewHistoria.Columns.Add("Id", "Id");
                dataGridViewHistoria.Columns.Add("DataWizyty", "Data Wizyty");
                dataGridViewHistoria.Columns.Add("Lekarz", "Lekarz");
                dataGridViewHistoria.Columns.Add("Status", "Status");
                dataGridViewHistoria.Columns.Add("Specjalizacja", "Specjalizacja");
                dataGridViewHistoria.Columns.Add("Opis", "Opis");
                dataGridViewHistoria.Columns.Add("Diagnoza", "Diagnoza");
                dataGridViewHistoria.Columns.Add("Zalecenia", "Zalecenia");
            }

            var wizyty = _dbHelper.PobierzWizytyPacjenta(_pacjentId);

            foreach (var wizyta in wizyty)
            {
                dataGridViewHistoria.Rows.Add(
                    wizyta.Id,
                    wizyta.DataWizyty.ToString("yyyy-MM-dd HH:mm"),
                    wizyta.Lekarz,
                    wizyta.Status,
                    wizyta.Specjalizacja,
                    wizyta.Opis,
                    wizyta.Diagnoza,
                    wizyta.Zalecenia);
            }
        }

        private void ButtonWybierzPlik_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Wszystkie pliki|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _wybranyPlik = ofd.FileName;
                    wybranyplik.Text = Path.GetFileName(_wybranyPlik);
                }
            }
        }

        private void buttonDodajDocument_Click(object sender, EventArgs e)
        {
            if (_pacjentId == 0 || string.IsNullOrEmpty(_wybranyPlik) || comboBoxTypDokumentu.SelectedIndex == -1)
            {
                MessageBox.Show("Uzupełnij dane dokumentu.");
                return;
            }

            var folder = Path.Combine("Dokumenty", _pacjentId.ToString());
            Directory.CreateDirectory(folder);

            var nowaSciezka = Path.Combine(folder, Path.GetFileName(_wybranyPlik));
            File.Copy(_wybranyPlik, nowaSciezka, true);

            var dokument = new DokumentPacjenta
            {
                PacjentId = _pacjentId,
                DataDodania = DateTime.Now,
                Typ = comboBoxTypDokumentu.Text,
                Uwagi = textBoxUwagiDokument.Text,
                SciezkaPliku = nowaSciezka
            };

            _dbHelper.DodajDokument(dokument);
            MessageBox.Show("Dodano dokument.");
            WczytajDokumenty();
        }

        private void WczytajDokumenty()
        {
            //kolumny sa dodawne automatycznie
            if (_pacjentId == 0) return;

            var lista = _dbHelper.PobierzDokumentyDlaPacjenta(_pacjentId);
            dataGridViewDocuments.Columns.Clear();
            dataGridViewDocuments.Rows.Clear();
            dataGridViewDocuments.Columns.Add("DataDodania", "Data dodania");
            dataGridViewDocuments.Columns.Add("Typ", "Typ");
            dataGridViewDocuments.Columns.Add("Uwagi", "Uwagi");

            var kolOtworz = new DataGridViewButtonColumn
            {
                Name = "Otworz",
                HeaderText = "",
                Text = "Otwórz",
                UseColumnTextForButtonValue = true
            };

            var kolUsun = new DataGridViewButtonColumn
            {
                Name = "Usun",
                HeaderText = "",
                Text = "Usuń",
                UseColumnTextForButtonValue = true
            };

            dataGridViewDocuments.Columns.Add(kolOtworz);
            dataGridViewDocuments.Columns.Add(kolUsun);

            foreach (var d in lista)
            {
                dataGridViewDocuments.Rows.Add(
                    d.DataDodania.ToString("yyyy-MM-dd"),
                    d.Typ,
                    d.Uwagi,
                    "Otwórz",
                    "Usuń"
                );
            }
        }

        private void dataGridViewDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dokument = _dbHelper.PobierzDokumentPoIndeksie(_pacjentId, e.RowIndex);

            if (e.ColumnIndex == 3)
            {
                Process.Start(dokument.SciezkaPliku);
            }
            else if (e.ColumnIndex == 4)
            {
                if (MessageBox.Show("Czy usunąć dokument?", "Potwierdź", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(dokument.SciezkaPliku);
                    _dbHelper.UsunDokument(dokument.Id);
                    WczytajDokumenty();
                }
            }
        }

        private void buttonZmienDane_Click(object sender, EventArgs e)
        {
            var pacjent = new Patient
            {
                Id = _pacjentId,
                Imie = textBoxImie.Text,
                Nazwisko = textBoxNazwisko.Text,
                DateofBirth = dateTimePicker1.Value,
                PESEL = textBoxPesel.Text,
                Adres = textBoxAdres.Text,
                Miasto = textBoxMiasto.Text,
                KodPocztowy = textBoxKodPocztowy.Text,
                PhoneNumber = textBoxTelefon.Text,
                Email = textBoxEmail.Text,
                Haslo = textBoxHaslo.Text,
                IsActive = checkBoxAktywny.Checked
            };

            try
            {
                _dbHelper.AktualizujPacjenta(pacjent);
                MessageBox.Show("Zaktualizowano dane pacjenta.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas aktualizacji: " + ex.Message);
            }
        }

        private void dataGridViewLekarze_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBoxNazwisko_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBoxHaslo_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewHistoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                this.Hide();

                var formLogowaniePacjent = new FormLogowaniePacjent();
                formLogowaniePacjent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                this.Hide();

                var formLogowaniePacjent = new FormLogowaniePacjent();
                formLogowaniePacjent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                this.Hide();

                var formLogowaniePacjent = new FormLogowaniePacjent();
                formLogowaniePacjent.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        }

        private void dateTimePickerWizyta_ValueChanged(object sender, EventArgs e)
        {

        }



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxImie_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Hide();
            var formLogowaniePacjent = new FormLogowaniePacjent(_dbHelper);
            formLogowaniePacjent.Closed += (s, args) => Close();
            formLogowaniePacjent.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            var formLogowaniePacjent = new FormLogowaniePacjent(_dbHelper);
            formLogowaniePacjent.Closed += (s, args) => Close();
            formLogowaniePacjent.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Hide();
            var formLogowaniePacjent = new FormLogowaniePacjent(_dbHelper);
            formLogowaniePacjent.Closed += (s, args) => Close();
            formLogowaniePacjent.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Hide();
            var formLogowaniePacjent = new FormLogowaniePacjent(_dbHelper);
            formLogowaniePacjent.Closed += (s, args) => Close();
            formLogowaniePacjent.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            if (dataGridViewHistoria.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznaczyć wizytę do anulowania.");
                return;
            }

            var selectedRow = dataGridViewHistoria.SelectedRows[0];
            if (!int.TryParse(selectedRow.Cells["Id"].Value?.ToString(), out int wizytaId))
            {
                MessageBox.Show("Nieprawidłowy identyfikator wizyty.");
                return;
            }

            var potwierdzenie = MessageBox.Show("Czy na pewno chcesz anulować wizytę?", "Potwierdzenie", MessageBoxButtons.YesNo);
            if (potwierdzenie != DialogResult.Yes)
                return;

            try
            {
                using (var connection = new MySql.Data.MySqlClient.MySqlConnection(_dbHelper.ConnectionString))
                {
                    connection.Open();
                    string zapytanie = "UPDATE wizyty SET status = 'Anulowana' WHERE id = @id";

                    using (var cmd = new MySql.Data.MySqlClient.MySqlCommand(zapytanie, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", wizytaId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Wizyta została anulowana.");
                WczytajHistorieWizyt(_pacjentId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas anulowania wizyty: " + ex.Message);
            }
        }

        private int? PobierzWizytaId()
        {
            if (dataGridViewHistoria.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dataGridViewHistoria.SelectedRows[0].Cells["Id"].Value);
            }
            MessageBox.Show("Zaznacz wizytę z listy.");
            return null;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (dataGridViewHistoria.SelectedRows.Count == 0)
            {
                MessageBox.Show("Zaznacz wizytę z listy.");
                return;
            }

            int wizytaId = Convert.ToInt32(dataGridViewHistoria.SelectedRows[0].Cells["Id"].Value);
            var skierowania = _dbHelper.PobierzSkierowaniaDlaWizyty(wizytaId);

            if (skierowania.Count == 0)
                MessageBox.Show("Brak skierowań dla tej wizyty.");
            else
                MessageBox.Show(string.Join("\n\n", skierowania), "Skierowania");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            {
                if (dataGridViewHistoria.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zaznacz wizytę z listy.");
                    return;
                }

                int wizytaId = Convert.ToInt32(dataGridViewHistoria.SelectedRows[0].Cells["Id"].Value);
                var recepty = _dbHelper.PobierzReceptyDlaWizyty(wizytaId);

                if (recepty.Count == 0)
                    MessageBox.Show("Brak recept dla tej wizyty.");
                else
                    MessageBox.Show(string.Join("\n\n", recepty), "Recepty");
            };
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Wybierz lekarza i ocenę.");
                return;
            }

            var wybranyLekarz = (Lekarz)dataGridView1.SelectedRows[0].DataBoundItem;
            int lekarzId = wybranyLekarz.Id;
            int ocena = Convert.ToInt32(comboBox3.SelectedItem);
            string komentarz = textBox1.Text.Trim();

            _dbHelper.DodajOpinie(_pacjentId, lekarzId, ocena, komentarz);
            MessageBox.Show("Opinia została dodana.");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void FormPacjent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
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
        private void buttonToggleTheme_Click(object sender, EventArgs e)
        {
           
        }

        private void FormPacjent_Load(object sender, EventArgs e)
        {
            dataGridViewLekarze.DefaultCellStyle.ForeColor = Color.Red;
            dataGridViewHistoria.DefaultCellStyle.ForeColor = Color.Red;
            dataGridViewDocuments.DefaultCellStyle.ForeColor = Color.Red;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Red;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz lekarza.");
                return;
            }

            var wybranyLekarz = (Lekarz)dataGridView1.SelectedRows[0].DataBoundItem;
            int lekarzId = wybranyLekarz.Id;

            var opinie = _dbHelper.PobierzOpinieDlaLekarza(lekarzId);

            if (opinie.Count == 0)
            {
                MessageBox.Show("Brak opinii dla wybranego lekarza.");
                return;
            }

            string wynik = string.Join("\n---------------------\n", opinie.Select(o => o.ToString()));
            MessageBox.Show(wynik, $"Opinie dla: {wybranyLekarz.Imie} {wybranyLekarz.Nazwisko}");
        }

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {
            ciemnyTryb = !ciemnyTryb;
            UstawTryb();
        }

        private void UstawTryb()
        {
            Color tloFormularza, kolorTekstu, kolorTabPage;
            string napisPrzycisku;

            if (ciemnyTryb)
            {
                tloFormularza = Color.FromArgb(64, 64, 64);       
                kolorTabPage = Color.FromArgb(64, 64, 64);       
                kolorTekstu = Color.White;
                napisPrzycisku = "Tryb jasny";
            }
            else
            {
                tloFormularza = Color.FromArgb(255, 192, 192);     
                kolorTabPage = Color.FromArgb(255, 224, 192);     
                kolorTekstu = Color.Black;
                napisPrzycisku = "Tryb ciemny";
            }

            this.BackColor = tloFormularza;
            this.ForeColor = kolorTekstu;
            btnToggleTheme.Text = napisPrzycisku;

            
            foreach (Control ctrl in this.Controls)
            {
                ZastosujTrybDoKontrolki(ctrl, tloFormularza, kolorTekstu, kolorTabPage);
            }
        }

        private void ZastosujTrybDoKontrolki(Control ctrl, Color tlo, Color tekst, Color kolorTabPage)
        {
            if (ctrl is System.Windows.Forms.TextBox)
            {
                ctrl.BackColor = Color.White;
                ctrl.ForeColor = Color.Black;
            }
            else if (ctrl is TabControl tabControl)
            {
                foreach (TabPage tab in tabControl.TabPages)
                {
                    tab.BackColor = kolorTabPage;
                    tab.ForeColor = tekst;

                    foreach (Control child in tab.Controls)
                    {
                        ZastosujTrybDoKontrolki(child, tlo, tekst, kolorTabPage);
                    }
                }

                tabControl.BackColor = tlo;
                tabControl.ForeColor = tekst;
            }
            else
            {
                ctrl.BackColor = tlo;
                ctrl.ForeColor = tekst;

               
                foreach (Control child in ctrl.Controls)
                {
                    ZastosujTrybDoKontrolki(child, tlo, tekst, kolorTabPage);
                }
            }
        }

       

    }
}



   