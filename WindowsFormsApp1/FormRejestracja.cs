using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.Forms
{
    public partial class FormRejestracja : Form
    {
        private DataBaseHelper _dbHelper;

        public FormRejestracja(DataBaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
            InitializeComponent();

            comboBoxRola.Items.Add("Pacjent");
            comboBoxRola.SelectedItem = "Pacjent";
            comboBoxRola.Enabled = false;
        }


        private void buttonRejestruj_Click_1(object sender, EventArgs e)
        {
            var imie = textBoxImie.Text;
            var nazwisko = textBoxNazwisko.Text;
            var email = textBoxEmail.Text;
            var haslo = textBoxHaslo.Text;
            var dataUrodzenia = dtp_DataUrodzenia.Value;
            var pesel = textBoxPesel.Text;
            var numerTel = textBoxTelefon.Text;
            var adres = textBoxAdres.Text;
            var miasto = textBoxMiasto.Text;
            var kodPocztowy = textBoxKodPocztowy.Text;


            var rola = "Pacjent";

            
            if (string.IsNullOrEmpty(imie) || string.IsNullOrEmpty(nazwisko) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(haslo))
            {
                MessageBox.Show("Proszę uzupełnić wszystkie pola.");
                return;
            }

            var user = new Users
            {
                Imie = imie,
                Nazwisko = nazwisko,
                Email = email,
                DateOfBirth = dataUrodzenia, 
                PESEL = pesel,
                PhoneNumber = numerTel,
                Miasto = miasto,
                Adres = adres,
                KodPocztowy = kodPocztowy,
            };

            try
            {
                
                _dbHelper.RegisterUser(user, haslo, rola);
                MessageBox.Show("Użytkownik zarejestrowany pomyślnie!");
            }
            catch (MySqlException ex) when (ex.Number == 2627) 
            {
                MessageBox.Show("Ten email jest już zarejestrowany.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Wystąpił błąd: {ex.Message}");
            }
        }

        private void buttonLogowanie_Click(object sender, EventArgs e)
        {
            FormLogowanieRola formlogowanierola = new FormLogowanieRola(_dbHelper);
            this.Hide();
            formlogowanierola.Show();
        }
    }
}
