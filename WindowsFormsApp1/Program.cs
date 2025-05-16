using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            const string connectionString = "Server=localhost;Port=3306;Database=przychodnia;Uid=root;Pwd=;";

            try
            {

                var dbHelper = new DataBaseHelper(connectionString);


                if (!dbHelper.TestConnection())
                {
                    MessageBox.Show("Nie można połączyć się z bazą danych. Sprawdź połączenie.",
                                  "Błąd połączenia",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                    return;
                }

                 // dbHelper.SprawdzIntegralnoscDanych(); // @TODO Dawiwd Kotlinski: Odkomentawać dla testu

                Application.Run(new FormRejestracja(dbHelper));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Krytyczny błąd inicjalizacji: {ex.Message}\n\nSzczegóły: {ex.StackTrace}",
                          "Błąd aplikacji",
                          MessageBoxButtons.OK,
                          MessageBoxIcon.Error);
            }
        }
    }
}
