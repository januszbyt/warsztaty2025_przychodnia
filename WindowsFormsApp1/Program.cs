using System.Windows.Forms;
using System;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Forms;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        try
        {
            var dbHelper = new DataBaseHelper();

            if (!dbHelper.TestConnection())
            {
                MessageBox.Show("Nie można połączyć się z bazą danych MySQL. Sprawdź XAMPP i dane logowania.",
                              "Błąd połączenia",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                return;
            }

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