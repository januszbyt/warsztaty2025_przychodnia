using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class FormPanelAdmin : Form
    {
        public FormPanelAdmin()
        {
            InitializeComponent(); // Inicjalizuje kontrolki z FormPanelAdmin.Designer.cs
        }

        // Obsługuje kliknięcie przycisku "Zarządzaj Lekarzami"
        private void buttonZarzadzajLekarzami_Click(object sender, EventArgs e)
        {
            
            FormZarzadzajLekarzami formLekarze = new FormZarzadzajLekarzami();
            formLekarze.ShowDialog();
        }

        // Obsługuje kliknięcie przycisku "Zarządzaj Pacjentami"
        private void buttonZarzadzajPacjentami_Click(object sender, EventArgs e)
        {
            // Otwarcie formularza zarządzania pacjentami
            FormZarzadzajPacjentami formPacjenci = new FormZarzadzajPacjentami();
            formPacjenci.ShowDialog();
        }

        // Obsługuje kliknięcie przycisku "Wyloguj"
        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            // Możesz dodać kod do wylogowania użytkownika, np. czyszczenie sesji

            // Otwarcie formularza logowania i zamknięcie bieżącego formularza
            FormLogowanieAdmin formLogin = new FormLogowanieAdmin(); // Zakładając, że masz formularz logowania o nazwie FormLogin
            formLogin.Show();
            this.Close(); // Zamykamy formularz admina
        }

        private void FormPanelAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
