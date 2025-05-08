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

namespace WindowsFormsApp1
{
    public partial class FormPacjent : Form
    {
        private readonly DataBaseHelper _dbHelper;
        private int _pacjentId;
        private string _wybranyPlik;


        public FormPacjent(DataBaseHelper dbHelper, int patientId = 0)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            _pacjentId = patientId;


            UstawFormularz();
            WczytajDanePacjenta();
            WczytajLekarzy();
            WczytajHistorieWizyt();
            WczytajDokumenty();
            WczytajDanePacjenta();


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

            buttonZapiszZmiany.Click += buttonZapiszZmiany_Click;
            buttonDodajWizyte.Click += buttonDodajWizyte_Click;
            buttonWybierzPlik.Click += ButtonWybierzPlik_Click;
            buttonZapiszZmiany.Click += buttonZapiszZmiany_Click;
           
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
            dateTimePickerDU.Value = pacjent.DateofBirth;
            textBoxPesel.Text = pacjent.PESEL;
            textBoxAdres.Text = pacjent.Adres;
            textBoxMiasto.Text = pacjent.Miasto;
            textBoxKodPocztowy.Text = pacjent.KodPocztowy;
            textBoxTelefon.Text = pacjent.PhoneNumber;
            textBoxEmail.Text = pacjent.Email;
            checkBoxAktywny.Checked = pacjent.IsActive;
        }

        private void buttonZapiszZmiany_Click(object sender, EventArgs e)
        {
            var pacjent = new Patient
            {
                Id = _pacjentId,
                Imie = textBoxImie.Text,
                Nazwisko = textBoxNazwisko.Text,
                DateofBirth = dateTimePickerDU.Value,
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
                dateTimePickerDU.Value = pacjent.DateofBirth;
                textBoxPesel.Text = pacjent.PESEL;
                textBoxAdres.Text = pacjent.Adres;
                textBoxMiasto.Text = pacjent.Miasto;
                textBoxKodPocztowy.Text = pacjent.KodPocztowy;
                textBoxTelefon.Text = pacjent.PhoneNumber;
                textBoxEmail.Text = pacjent.Email;
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
            var opis = richTextBoxOpisProblemu.Text.Trim();

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
                Opis = opis,
                Status = "Zaplanowana"
            };

            _dbHelper.DodajWizyte(wizyta);
            MessageBox.Show("Dodano wizytę.");
            WczytajHistorieWizyt();
        }

        private void WczytajHistorieWizyt()
        {
            if (_pacjentId == 0) return;
            dataGridViewHistoria.DataSource = _dbHelper.PobierzHistorieWizyt(_pacjentId);
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
                DateofBirth = dateTimePickerDU.Value,
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
    }
}