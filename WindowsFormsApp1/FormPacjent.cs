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

namespace WindowsFormsApp1
{
    public partial class FormPacjent : Form
    {
        private readonly DataBaseHelper _dbHelper;
        private int _currentPatientId;
        private bool _isNewPatient;
        private DataGridView dataGridViewDokumenty;
        private Button buttonDodajDokument;
        private OpenFileDialog openFileDialogDokumenty;
        private string _wybranyPlik;


        public FormPacjent(DataBaseHelper dbHelper, int patientId = 0)
        {
            InitializeComponent();
            _dbHelper = dbHelper;
            _currentPatientId = patientId;
            _isNewPatient = patientId == 0;

            InitializeForm();
            LoadPatientData();
            InitializeVisitTab();
            ZaladujDokumenty();


        }

        private void InitializeForm()
        {
            
            this.Text = _isNewPatient ? "Nowy pacjent" : "Edycja pacjenta";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;

            dataGridViewDokumenty = new DataGridView();
            dataGridViewDokumenty.Dock = DockStyle.Fill;
            dataGridViewDokumenty.AutoGenerateColumns = false;
            dataGridViewDokumenty.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            tabPageDokumentacjaMedyczna.Controls.Add(dataGridViewDokumenty);


            dataGridViewDokumenty.Columns.Add("DataDodania", "Data");
            dataGridViewDokumenty.Columns.Add("Typ", "Typ dokumentu");
            dataGridViewDokumenty.Columns.Add("Uwagi", "Uwagi");
            dataGridViewDokumenty.Columns.Add("SciezkaPliku", "Plik");



        }
        private void InitializeVisitTab()
        {

            dataGridViewLekarze.AutoGenerateColumns = false;
            dataGridViewLekarze.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ConfigureDoctorsGridColumns();


            dateTimePickerWizyta.MinDate = DateTime.Today;
            dateTimePickerWizyta.Value = DateTime.Today.AddDays(1);


            buttonDodajWizyte.Click += buttonDodajWizyte_Click;

            comboBoxTypDokumentu.Items.AddRange(new string[]
            {
                "Wynik badania krwi",
                "Wynik RTG",
                "Wynik USG",
                "Wynik rezonansu magnetycznego (MRI)",
                "Wynik tomografii komputerowej (CT)",
                "Skierowanie",
                "Zaświadczenie lekarskie",
                "Historia choroby",
                "Karta wypisu ze szpitala",
                "Notatka z wizyty",
                "Recepta",
                "Zgoda pacjenta",
                "Opis zabiegu",
                "Inne"
            });


            LoadAvailableDoctors();
        }

        private void ConfigureDoctorsGridColumns()
        {
            dataGridViewLekarze.Columns.Clear();

            dataGridViewLekarze.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDoctorId",
                HeaderText = "ID",
                DataPropertyName = "Id",
                Visible = false
            });

            dataGridViewLekarze.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDoctorName",
                HeaderText = "Imię",
                DataPropertyName = "Imie",
                Width = 100
            });

            dataGridViewLekarze.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDoctorLastName",
                HeaderText = "Nazwisko",
                DataPropertyName = "Nazwisko",
                Width = 120
            });

            dataGridViewLekarze.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colSpecialization",
                HeaderText = "Specjalizacja",
                DataPropertyName = "Specjalizacja",
                Width = 150
            });

            dataGridViewLekarze.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colAvailableHours",
                HeaderText = "Dostępne godziny",
                DataPropertyName = "DostepneGodziny",
                Width = 200
            });
        }

       
        private void LoadAvailableDoctors()
        {
            try
            {
                var doctors = _dbHelper.PobierzDostepnychLekarzy();
                dataGridViewLekarze.DataSource = doctors;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania lekarzy: {ex.Message}", "Błąd",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureHistoryGridColumns()
        {
            dataGridViewHistoria.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDate",
                HeaderText = "Data wizyty",
                DataPropertyName = "DataWizyty",
                Width = 120
            });

            dataGridViewHistoria.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDoctor",
                HeaderText = "Lekarz",
                DataPropertyName = "Lekarz",
                Width = 150
            });

            dataGridViewHistoria.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colDiagnosis",
                HeaderText = "Diagnoza",
                DataPropertyName = "Diagnoza",
                Width = 200
            });
        }

        private void LoadPatientData()
        {
            if (!_isNewPatient)
            {
                
                var patient = _dbHelper.PobierzDanePacjenta(_currentPatientId);
                if (patient != null)
                {
                    textBoxImie.Text = patient.Imie;
                    textBoxNazwisko.Text = patient.Nazwisko;
                    dateTimePickerDU.Value = patient.DataUrodzenia;
                    textBoxPesel.Text = patient.PESEL;
                    textBoxAdress.Text = patient.Adres;
                    textBoxMiasto.Text = patient.Miasto;
                    textBoxKodPocztowy.Text = patient.KodPocztowy;
                    textBoxTelefon.Text = patient.Telefon;
                    textBoxEmail.Text = patient.Email;
                    checkBoxAktywny.Checked = patient.IsActive;

                    
                    LoadVisitHistory();
                }
            }
            else
            {
                dateTimePickerDU.Value = DateTime.Now.AddYears(-30);
                checkBoxAktywny.Checked = true;
            }
        }

        private void LoadVisitHistory()
        {
            try
            {
                dataGridViewHistoria.DataSource = _dbHelper.PobierzHistorieWizyt(_currentPatientId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd ładowania historii wizyt: {ex.Message}", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void dataGridViewHistoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Pokaż szczegóły w MessageBox zamiast osobnego formularza
                var row = dataGridViewHistoria.Rows[e.RowIndex];
                string details = $"Data: {row.Cells["colDate"].Value}\n" +
                                $"Lekarz: {row.Cells["colDoctor"].Value}\n" +
                                $"Diagnoza: {row.Cells["colDiagnosis"].Value}";

                MessageBox.Show(details, "Szczegóły wizyty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBoxImie_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNazwisko_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdres_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxAdress_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxPesel_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTelefon_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMiasto_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxKodPocztowy_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxEmail.Text) && !IsValidEmail(textBoxEmail.Text))
            {
                errorProvider.SetError(textBoxEmail, "Nieprawidłowy format email");
                
            }
            else
            {
                errorProvider.SetError(textBoxEmail, null);
            }
        }

        private void dateTimePickerDU_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxAktywny_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ButtonZapiszZmiany_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.Enabled))
            {
                MessageBox.Show("Proszę poprawić błędne dane", "Błąd walidacji",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var patient = new Patient
            {
                Id = _currentPatientId,
                Imie = textBoxImie.Text.Trim(),
                Nazwisko = textBoxNazwisko.Text.Trim(),
                DataUrodzenia = dateTimePickerDU.Value,
                PESEL = textBoxPesel.Text.Trim(),
                Adres = textBoxAdres.Text.Trim(),
                Miasto = textBoxMiasto.Text.Trim(),
                KodPocztowy = textBoxKodPocztowy.Text.Trim(),
                Telefon = textBoxTelefon.Text.Trim(),
                Email = textBoxEmail.Text.Trim(),
                IsActive = checkBoxAktywny.Checked
            };

            try
            {
                if (_isNewPatient)
                {
                    _currentPatientId = _dbHelper.DodajPacjenta(patient);
                    _isNewPatient = false;
                    MessageBox.Show("Pacjent został dodany", "Sukces",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _dbHelper.AktualizujPacjenta(patient);
                    MessageBox.Show("Dane pacjenta zostały zaktualizowane", "Sukces",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd zapisu danych: {ex.Message}", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnuluj_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void buttonDodajWizyte_Click(object sender, EventArgs e)
        {
            if (_isNewPatient)
            {
                MessageBox.Show("Najpierw zapisz dane pacjenta przed dodaniem wizyty", "Informacja",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dataGridViewLekarze.SelectedRows.Count == 0)
            {
                MessageBox.Show("Wybierz lekarza", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(richTextBoxOpisProblemu.Text))
            {
                MessageBox.Show("Wpisz opis problemu", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedDoctor = (Lekarz)dataGridViewLekarze.SelectedRows[0].DataBoundItem;
            var visitDate = dateTimePickerWizyta.Value;

            try
            {
                var wizyta = new Wizyta
                {
                    PacjentId = _currentPatientId,
                    LekarzId = selectedDoctor.Id,
                    DataWizyty = visitDate,
                    Opis = richTextBoxOpisProblemu.Text.Trim(),
                    Status = "Zaplanowana"
                };

                if (_dbHelper.CzyLekarzMaWolnyTermin(selectedDoctor.Id, visitDate))
                {
                    _dbHelper.DodajWizyte(wizyta);
                    MessageBox.Show("Wizyta została dodana", "Sukces",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    LoadVisitHistory();
                    richTextBoxOpisProblemu.Clear();
                }
                else
                {
                    MessageBox.Show("Lekarz nie ma wolnego terminu w wybranym czasie", "Błąd",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas dodawania wizyty: {ex.Message}", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonWybierzPlik_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pliki PDF, obrazy i dokumenty|*.pdf;*.jpg;*.jpeg;*.png;*.docx;*.txt";


            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _wybranyPlik = ofd.FileName;
                labelWybranyPlik.Text = Path.GetFileName(_wybranyPlik);
            }
        }

        private void ZaladujDokumenty()
        {
            var dokumenty = _dbHelper.PobierzDokumentyDlaPacjenta(_currentPatientId);

            dataGridViewDokumenty.Rows.Clear();
            foreach (var d in dokumenty)
            {
                dataGridViewDokumenty.Rows.Add(
                    d.DataDodania.ToString("yyyy-MM-dd"),
                    d.Typ,
                    d.Uwagi,
                    "Zobacz",
                    "Usuń"
                );
            }
        }

        private void buttonDodajDocument_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_wybranyPlik))
            {
                MessageBox.Show("Wybierz plik do dodania.");
                return;
            }

            if (comboBoxTypDokumentu.SelectedItem == null)
            {
                MessageBox.Show("Wybierz typ dokumentu.");
                return;
            }

            string typ = comboBoxTypDokumentu.SelectedItem.ToString();
            string uwagi = textBoxUwagiDokument.Text;

            string folder = Path.Combine("Dokumenty", _currentPatientId.ToString());
            Directory.CreateDirectory(folder);

            string nowaSciezka = Path.Combine(folder, Path.GetFileName(_wybranyPlik));
            File.Copy(_wybranyPlik, nowaSciezka, true);

            var dokument = new DokumentPacjenta
            {
                PacjentId = _currentPatientId,
                DataDodania = DateTime.Now,
                Typ = typ,
                Uwagi = uwagi,
                SciezkaPliku = nowaSciezka
            };

            _dbHelper.DodajDokument(dokument);
            _wybranyPlik = null;
            labelWybranyPlik.Text = "";

            comboBoxTypDokumentu.SelectedIndex = -1;
            textBoxUwagiDokument.Clear();

            ZaladujDokumenty();
        }

        private void dataGridViewDocuments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var dokument = _dbHelper.PobierzDokumentPoIndeksie(_currentPatientId, e.RowIndex);

            if (dataGridViewDokumenty.Columns[e.ColumnIndex].Name == "colPodglad")
            {
                Process.Start(dokument.SciezkaPliku);
            }
            else if (dataGridViewDokumenty.Columns[e.ColumnIndex].Name == "colUsun")
            {
                if (MessageBox.Show("Czy usunąć dokument?", "Potwierdź", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(dokument.SciezkaPliku);
                    _dbHelper.UsunDokument(dokument.Id);
                    ZaladujDokumenty();
                }
            }
        }
    }
}