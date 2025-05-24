using MySql.Data.MySqlClient;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormPowiadomienia : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PrzychodniaConnection"].ConnectionString;
        private string smtpHost = "";
        private int smtpPort = 0;
        private string smtpUser = "";
        private string smtpPassword = "";

        public FormPowiadomienia()
        {
            InitializeComponent();
            LoadDataGridView("wizyta"); // Domyślnie ładuje wizyty
            // Powiązanie zdarzeń
            btnUpdateSmtp.Click += BtnUpdateSmtp_Click;
            cbNotificationType.SelectedIndexChanged += CbNotificationType_SelectedIndexChanged;
            btnSendNotifications.Click += BtnSendNotifications_Click;
        }

        private void LoadDataGridView(string notificationType)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "";
                    switch (notificationType)
                    {
                        case "wizyta":
                            query = @"
                                SELECT w.Id, u.Imie, u.Nazwisko, u.Email, w.DataWizyty, d.Specjalizacja
                                FROM wizyty w
                                JOIN users u ON w.PacjentId = u.Id
                                JOIN doctors d ON w.LekarzId = d.Id
                                WHERE w.DataWizyty BETWEEN '2025-05-22 18:24:00' AND DATE_ADD('2025-05-22 18:24:00', INTERVAL 24 HOUR);";
                            break;
                        case "recepta":
                            query = @"
                                SELECT r.Id, u.Imie, u.Nazwisko, u.Email, r.DataWystawienia
                                FROM recepty r
                                JOIN users u ON r.PacjentId = u.Id
                                WHERE r.DataWystawienia >= DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY);";
                            break;
                        case "skierowanie":
                            query = @"
                                SELECT s.Id, u.Imie, u.Nazwisko, u.Email, s.DataWystawienia, s.Typ
                                FROM skierowania s
                                JOIN users u ON s.PacjentId = u.Id
                                WHERE s.DataWystawienia >= DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY);";
                            break;
                        case "dokument":
                            query = @"
                                SELECT d.Id, u.Imie, u.Nazwisko, u.Email, d.DataDodania, d.Typ
                                FROM dokumentypacjenta d
                                JOIN users u ON d.PacjentId = u.Id
                                WHERE d.DataDodania >= DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY);";
                            break;
                        case "opinia":
                            query = @"
                                SELECT o.Id, u.Imie, u.Nazwisko, u.Email, o.DataDodania, o.Ocena
                                FROM Opinie o
                                JOIN users u ON o.PacjentId = u.Id
                                WHERE o.DataDodania >= DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY);";
                            break;
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvData.DataSource = dt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"Błąd ładowania danych: {ex.Message}");
                }
            }
        }

        private void SendNotifications(string notificationType)
        {
            if (string.IsNullOrWhiteSpace(smtpHost) || smtpPort == 0 || string.IsNullOrWhiteSpace(smtpUser) || string.IsNullOrWhiteSpace(smtpPassword))
            {
                LogMessage("Najpierw ustaw wszystkie dane SMTP.");
                return;
            }

            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "";
                    switch (notificationType)
                    {
                        case "wizyta":
                            query = @"
                                SELECT w.Id, u.Email, u.Imie, u.Nazwisko, w.DataWizyty, d.Specjalizacja
                                FROM wizyty w
                                JOIN users u ON w.PacjentId = u.Id
                                JOIN doctors d ON w.LekarzId = d.Id
                                WHERE w.DataWizyty BETWEEN '2025-05-22 18:24:00' AND DATE_ADD('2025-05-22 18:24:00', INTERVAL 24 HOUR)
                                AND NOT EXISTS (
                                    SELECT 1 FROM Powiadomienia p 
                                    WHERE p.PacjentId = u.Id 
                                    AND p.TypPowiadomienia = 'wizyta' 
                                    AND p.DataWyslania > DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                );";
                            break;
                        case "recepta":
                            query = @"
                                SELECT r.Id, u.Email, u.Imie, u.Nazwisko, r.DataWystawienia
                                FROM recepty r
                                JOIN users u ON r.PacjentId = u.Id
                                WHERE r.DataWystawienia >= DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                AND NOT EXISTS (
                                    SELECT 1 FROM Powiadomienia p 
                                    WHERE p.PacjentId = u.Id 
                                    AND p.TypPowiadomienia = 'recepta' 
                                    AND p.DataWyslania > DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                );";
                            break;
                        case "skierowanie":
                            query = @"
                                SELECT s.Id, u.Email, u.Imie, u.Nazwisko, s.DataWystawienia, s.Typ
                                FROM skierowania s
                                JOIN users u ON s.PacjentId = u.Id
                                WHERE s.DataWystawienia >= DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                AND NOT EXISTS (
                                    SELECT 1 FROM Powiadomienia p 
                                    WHERE p.PacjentId = u.Id 
                                    AND p.TypPowiadomienia = 'skierowanie' 
                                    AND p.DataWyslania > DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                );";
                            break;
                        case "dokument":
                            query = @"
                                SELECT d.Id, u.Email, u.Imie, u.Nazwisko, d.DataDodania, d.Typ
                                FROM dokumentypacjenta d
                                JOIN users u ON d.PacjentId = u.Id
                                WHERE d.DataDodania >= DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                AND NOT EXISTS (
                                    SELECT 1 FROM Powiadomienia p 
                                    WHERE p.PacjentId = u.Id 
                                    AND p.TypPowiadomienia = 'dokument' 
                                    AND p.DataWyslania > DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                );";
                            break;
                        case "opinia":
                            query = @"
                                SELECT o.Id, u.Email, u.Imie, u.Nazwisko, o.DataDodania, o.Ocena
                                FROM Opinie o
                                JOIN users u ON o.PacjentId = u.Id
                                WHERE o.DataDodania >= DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                AND NOT EXISTS (
                                    SELECT 1 FROM Powiadomienia p 
                                    WHERE p.PacjentId = u.Id 
                                    AND p.TypPowiadomienia = 'opinia' 
                                    AND p.DataWyslania > DATE_SUB('2025-05-22 18:24:00', INTERVAL 1 DAY)
                                );";
                            break;
                    }

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int recordId = reader.GetInt32("Id");
                                string email = reader.GetString("Email");
                                string patientName = reader.GetString("Imie") + " " + reader.GetString("Nazwisko");
                                string message = "";

                                switch (notificationType)
                                {
                                    case "wizyta":
                                        DateTime visitDate = reader.GetDateTime("DataWizyty");
                                        string specialization = reader.GetString("Specjalizacja");
                                        message = $"Szanowny/a Panie/i {patientName},\n\nPrzypominamy o wizycie u specjalisty {specialization} w dniu {visitDate:yyyy-MM-dd HH:mm}. Prosimy o przybycie na czas.\n\nZespół Przychodnia";
                                        break;
                                    case "recepta":
                                        message = $"Szanowny/a Panie/i {patientName},\n\nWystawiono nową receptę. Sprawdź szczegóły w systemie.\n\nZespół Przychodnia";
                                        break;
                                    case "skierowanie":
                                        string referralType = reader.GetString("Typ");
                                        message = $"Szanowny/a Panie/i {patientName},\n\nWystawiono skierowanie na {referralType}. Sprawdź szczegóły w systemie.\n\nZespół Przychodnia";
                                        break;
                                    case "dokument":
                                        string docType = reader.GetString("Typ");
                                        message = $"Szanowny/a Panie/i {patientName},\n\nDodano nowy dokument ({docType}). Sprawdź szczegóły w systemie.\n\nZespół Przychodnia";
                                        break;
                                    case "opinia":
                                        int rating = reader.GetInt32("Ocena");
                                        message = $"Szanowny/a Panie/i {patientName},\n\nDziękujemy za dodanie opinii (ocena: {rating}).\n\nZespół Przychodnia";
                                        break;
                                }

                                if (SendEmail(email, $"Powiadomienie: {notificationType}", message))
                                {
                                    SaveNotification(recordId, email, notificationType, message);
                                    LogMessage($"Powiadomienie ({notificationType}) wysłane do {email}.");
                                }
                                else
                                {
                                    LogMessage($"Błąd wysyłki powiadomienia ({notificationType}) do {email}.");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"Błąd: {ex.Message}");
                }
            }
        }

        private bool SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Przychodnia", smtpUser));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;
                message.Body = new TextPart("plain") { Text = body };

                using (var client = new SmtpClient())
                {
                    client.Connect(smtpHost, smtpPort, SecureSocketOptions.SslOnConnect);
                    client.Authenticate(smtpUser, smtpPassword);
                    client.Send(message);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                LogMessage($"Błąd wysyłki e-mail: {ex.Message}");
                return false;
            }
        }

        private void SaveNotification(int recordId, string patientEmail, string type, string message)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "INSERT INTO Powiadomienia (PacjentId, TypPowiadomienia, Wiadomosc, DataWyslania, Kanal, Status) VALUES ((SELECT Id FROM users WHERE Email = @Email), @Type, @Message, NOW(), 'email', 'wysłane')";
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", patientEmail);
                        command.Parameters.AddWithValue("@Type", type);
                        command.Parameters.AddWithValue("@Message", message);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    LogMessage($"Błąd zapisu powiadomienia: {ex.Message}");
                }
            }
        }

        private void LogMessage(string message)
        {
            txtLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message + Environment.NewLine);
            txtLog.ScrollToCaret();
        }

        private void BtnUpdateSmtp_Click(object sender, EventArgs e)
        {
            try
            {
                smtpHost = txtSmtpHost.Text.Trim();
                smtpPort = int.Parse(txtSmtpPort.Text.Trim());
                smtpUser = txtSmtpUser.Text.Trim();
                smtpPassword = txtSmtpPassword.Text.Trim();
                if (string.IsNullOrWhiteSpace(smtpHost) || smtpPort == 0 || string.IsNullOrWhiteSpace(smtpUser) || string.IsNullOrWhiteSpace(smtpPassword))
                {
                    LogMessage("Wszystkie pola SMTP muszą być wypełnione.");
                    return;
                }
                LogMessage($"Ustawienia SMTP zaktualizowane: {smtpHost}:{smtpPort}, login: {smtpUser}");
            }
            catch (Exception ex)
            {
                LogMessage($"Błąd aktualizacji ustawień SMTP: {ex.Message}");
            }
        }

        private void CbNotificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridView(cbNotificationType.SelectedItem.ToString());
        }

        private void BtnSendNotifications_Click(object sender, EventArgs e)
        {
            SendNotifications(cbNotificationType.SelectedItem.ToString());
        }

        private void cbNotificationType_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}