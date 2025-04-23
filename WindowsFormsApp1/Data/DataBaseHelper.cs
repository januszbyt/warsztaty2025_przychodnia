using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using WindowsFormsApp1.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SQLite;



namespace WindowsFormsApp1.Data
{
    public class DataBaseHelper
    {
        private readonly string _connectionString;

        public DataBaseHelper(string connectionString)
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Brak connection string w app.config!");
            }

        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool EmailExists(string email, SqlConnection connection)
        {
            var query = "SELECT COUNT(1) FROM dbo.Users WHERE Email = @Email";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        private (string PasswordHash, string Salt) HashPasswordWithSalt(string password)
        {

            string salt = Guid.NewGuid().ToString();

            using (var sha256 = SHA256.Create())
            {
                var combined = password + salt;
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(combined);
                byte[] hash = sha256.ComputeHash(bytes);
                string passwordHash = Convert.ToBase64String(hash);

                return (passwordHash, salt);
            }
        }


        public void RegisterUser(Users user, string password, string rola)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if (EmailExists(user.Email, connection))
                {
                    throw new Exception("Email jest już zarejestrowany.");
                }

                var (passwordHash, salt) = HashPasswordWithSalt(password);

                // Poprawione zapytanie - liczba kolumn zgadza się z liczbą wartości
                var query = @"INSERT INTO dbo.Users 
                     (Imie, Nazwisko, Email, Miasto, Adres, KodPocztowy, DateOfBirth, PESEL, PhoneNumber, PasswordHash, Salt, Rola) 
                     VALUES 
                     (@Imie, @Nazwisko, @Email, @Miasto, @Adres, @KodPocztowy, @DateOfBirth, @PESEL, @PhoneNumber, @PasswordHash, @Salt, @Rola)";

                var queryRole = "INSERT INTO dbo.UserRoles (UserId, RoleName) VALUES (@UserId, @RoleName)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Imie", user.Imie ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nazwisko", user.Nazwisko ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Miasto", user.Miasto ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Adres", user.Adres ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@KodPocztowy", user.KodPocztowy ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@PESEL", user.PESEL ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PasswordHash", passwordHash);
                    command.Parameters.AddWithValue("@Salt", salt);
                    command.Parameters.AddWithValue("@Rola", rola); 

                    command.ExecuteNonQuery();
                }

                using (var commandRole = new SqlCommand(queryRole, connection))
                {
                    commandRole.Parameters.AddWithValue("@UserId", GetUserIdByEmail(user.Email, connection));
                    commandRole.Parameters.AddWithValue("@RoleName", rola);

                    commandRole.ExecuteNonQuery();
                }
            }
        }

        public Patient GetPatientById(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT Id, Imie, Nazwisko, DataUrodzenia, PESEL, 
                        Adres, Miasto, KodPocztowy, Telefon, Email, IsActive
                        FROM Patients
                        WHERE UserId = @UserId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Patient
                            {
                                Id = reader.GetInt32(0),
                                Imie = reader.GetString(1),
                                Nazwisko = reader.GetString(2),
                                DataUrodzenia = reader.GetDateTime(3),
                                PESEL = reader.GetString(4),
                                Adres = reader.GetString(5),
                                Miasto = reader.GetString(6),
                                KodPocztowy = reader.GetString(7),
                                Telefon = reader.GetString(8),
                                Email = reader.GetString(9),
                                IsActive = reader.GetBoolean(10)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public DataTable GetPatientAppointments(int patientId)
        {
            var dt = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT a.Id, a.DataWizyty, 
                        d.Imie + ' ' + d.Nazwisko AS Lekarz,
                        s.Nazwa AS Specjalizacja,
                        CASE 
                            WHEN a.Status = 0 THEN 'Zaplanowana'
                            WHEN a.Status = 1 THEN 'Zakończona'
                            WHEN a.Status = 2 THEN 'Odwołana'
                            ELSE 'Nieznany'
                        END AS Status
                        FROM Appointments a
                        JOIN Doctors d ON a.DoctorId = d.Id
                        JOIN Specializations s ON d.SpecializationId = s.Id
                        WHERE a.PatientId = @PatientId
                        ORDER BY a.DataWizyty DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public bool CancelAppointment(int appointmentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"UPDATE Appointments 
                        SET Status = 2 
                        WHERE Id = @AppointmentId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        private int GetUserIdByEmail(string email, SqlConnection connection)
        {
            var query = "SELECT Id FROM dbo.Users WHERE Email = @Email";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);
                var result = command.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    throw new Exception("Użytkownik z podanym adresem email nie istnieje.");

                return Convert.ToInt32(result);
            }
        }

        public Lekarz PobierzLekarza(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Id, Imie, Nazwisko, Specjalizacja FROM dbo.Doctors WHERE UserId = @UserId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lekarz
                            {
                                Id = reader.GetInt32(0),
                                Imie = reader.GetString(1),
                                Nazwisko = reader.GetString(2),
                                Specjalizacja = reader.GetString(3)
                            };
                        }
                    }
                }
            }
            return null;
        }

        private bool VerifyPassword(string inputPassword, string storedPasswordHash, string salt)
        {
            if (string.IsNullOrEmpty(inputPassword) || string.IsNullOrEmpty(storedPasswordHash) || string.IsNullOrEmpty(salt))
                return false;

            using (var sha256 = SHA256.Create())
            {
                var combined = inputPassword + salt;
                byte[] bytes = Encoding.UTF8.GetBytes(combined);
                byte[] hash = sha256.ComputeHash(bytes);
                string inputPasswordHash = Convert.ToBase64String(hash);
                return inputPasswordHash == storedPasswordHash;
            }
        }

        public Users ZalogujUzytkownika(string email, string password)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"
                        SELECT 
                        u.Id, 
                        u.Imie, 
                        u.Nazwisko, 
                        u.Email, 
                        u.PasswordHash, 
                        u.Salt,
                        ISNULL(ur.RoleName, 'Pacjent') AS RoleName
                        FROM dbo.Users u
                        LEFT JOIN dbo.UserRoles ur ON u.Id = ur.UserId
                        WHERE u.Email = @Email";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            var id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                            var imie = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            var nazwisko = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            var emailDb = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                            var passwordHash = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                            var salt = reader.IsDBNull(5) ? string.Empty : reader.GetString(5);
                            var roleName = reader.IsDBNull(6) ? "Pacjent" : reader.GetString(6);

                            if (!string.IsNullOrEmpty(passwordHash) &&
                                VerifyPassword(password, passwordHash, salt))
                            {
                                return new Users
                                {
                                    Id = id,
                                    Imie = imie,
                                    Nazwisko = nazwisko,
                                    Email = emailDb,
                                    Rola = new Role { Nazwa = roleName }
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }




        public DataTable PobierzWszystkichLekarzy()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM dbo.Doctors";
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public DataTable PobierzPacjentow()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            SELECT 
                Id,
                Imie AS 'Imię',
                Nazwisko,
                CONVERT(varchar, DateOfBirth, 104) AS 'Data urodzenia',
                PhoneNumber AS 'Numer telefonu',
                PESEL
            FROM Users
            WHERE Id IN (SELECT UserId FROM UserRoles WHERE RoleName = 'Pacjent')";

                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }


        public DataTable PobierzWszystkichPacjentow()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM dbo.Users";
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public DataTable PobierzPacjentowhe()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            SELECT 
                Id,
                Imie AS 'Imię',
                Nazwisko,
                DateOfBirth AS 'Data urodzenia',
                PhoneNumber AS 'Numer telefonu',
                PESEL
            FROM Users
            WHERE Id IN (SELECT UserId FROM UserRoles WHERE RoleName = 'Pacjent')";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }


        public void NadajUprawnieniaLekarza(int userId, string specjalizacja)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        var checkRoleQuery = @"SELECT COUNT(*) FROM dbo.UserRoles 
                                     WHERE UserId = @UserId AND RoleName = 'Lekarz'";

                        using (var checkCommand = new SqlCommand(checkRoleQuery, connection, transaction))
                        {
                            checkCommand.Parameters.AddWithValue("@UserId", userId);
                            if ((int)checkCommand.ExecuteScalar() > 0)
                            {
                                throw new Exception("Użytkownik już posiada rolę Lekarza.");
                            }
                        }


                        string imie = "", nazwisko = "";
                        var queryUser = "SELECT Imie, Nazwisko FROM dbo.Users WHERE Id = @UserId";

                        using (var command = new SqlCommand(queryUser, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    imie = reader["Imie"].ToString();
                                    nazwisko = reader["Nazwisko"].ToString();
                                }
                                else
                                {
                                    throw new Exception("Użytkownik nie istnieje!");
                                }
                            }
                        }


                        var insertRoleQuery = @"INSERT INTO dbo.UserRoles (UserId, RoleName) 
                                      VALUES (@UserId, 'Lekarz')";

                        using (var command = new SqlCommand(insertRoleQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            command.ExecuteNonQuery();
                        }


                        var insertLekarzQuery = @"INSERT INTO dbo.Doctors 
                                        (UserId, Imie, Nazwisko, Specjalizacja) 
                                        VALUES (@UserId, @Imie, @Nazwisko, @Specjalizacja)";

                        using (var command = new SqlCommand(insertLekarzQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            command.Parameters.AddWithValue("@Imie", imie);
                            command.Parameters.AddWithValue("@Nazwisko", nazwisko);
                            command.Parameters.AddWithValue("@Specjalizacja", specjalizacja);
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }


        public void ZabierzUprawnieniaLekarza(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();


                string imie = "", nazwisko = "";
                var queryLekarz = "SELECT Imie, Nazwisko FROM dbo.Doctors WHERE UserId = @UserId";
                using (var commandLekarz = new SqlCommand(queryLekarz, connection))
                {
                    commandLekarz.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = commandLekarz.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            imie = reader.GetString(0);
                            nazwisko = reader.GetString(1);
                        }
                        else
                        {
                            throw new Exception("Nie znaleziono lekarza o podanym Id.");
                        }
                    }
                }


                var queryDeleteLekarz = "DELETE FROM dbo.Doctors WHERE UserId = @UserId";
                using (var commandDeleteLekarz = new SqlCommand(queryDeleteLekarz, connection))
                {
                    commandDeleteLekarz.Parameters.AddWithValue("@UserId", userId);
                    commandDeleteLekarz.ExecuteNonQuery();
                }


                var queryDeleteRole = "DELETE FROM dbo.UserRoles WHERE UserId = @UserId AND RoleName = 'Lekarz'";
                using (var commandDeleteRole = new SqlCommand(queryDeleteRole, connection))
                {
                    commandDeleteRole.Parameters.AddWithValue("@UserId", userId);
                    commandDeleteRole.ExecuteNonQuery();
                }
            }
        }



        public void UsunRekord(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var queryDeleteLekarz = "DELETE FROM dbo.Doctors WHERE UserId = @UserId";
                var queryDeletePacjent = "DELETE FROM dbo.Users WHERE UserId = @UserId";

                using (var commandLekarz = new SqlCommand(queryDeleteLekarz, connection))
                {
                    commandLekarz.Parameters.AddWithValue("@UserId", userId);
                    commandLekarz.ExecuteNonQuery();
                }

                using (var commandPacjent = new SqlCommand(queryDeletePacjent, connection))
                {
                    commandPacjent.Parameters.AddWithValue("@UserId", userId);
                    commandPacjent.ExecuteNonQuery();
                }
            }
        }

        public int GetUserIdByEmailPublic(string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                return GetUserIdByEmail(email, connection);
            }
        }

        public void DodajDoLekarzy(int userId, string imie, string nazwisko, string specjalizacja)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO dbo.Lekarze (UzytkownikId, Imie, Nazwisko, Specjalizacja)
                      VALUES (@UzytkownikId, @Imie, @Nazwisko, @Specjalizacja)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UzytkownikId", userId);
                    command.Parameters.AddWithValue("@Imie", imie);
                    command.Parameters.AddWithValue("@Nazwisko", nazwisko);
                    command.Parameters.AddWithValue("@Specjalizacja", specjalizacja);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void UsunUzytkownika(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM dbo.Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", userId);
                command.ExecuteNonQuery();
            }
        }

        public int PoliczLekarzy()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM dbo.Doctors";
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public int PoliczPacjentow()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM dbo.UserRoles WHERE RoleName = 'Pacjent'";
                using (var command = new SqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void UsunWszystkieDane()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var zapytania = new[]
                        {
                            "DELETE FROM dbo.UserRoles",
                            "DELETE FROM dbo.Doctors",
                            "DELETE FROM dbo.Users"
                        };

                        foreach (var query in zapytania)
                        {
                            using (var command = new SqlCommand(query, connection, transaction))
                            {
                                command.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        MessageBox.Show("Wszystkie dane zostały usunięte.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Błąd podczas usuwania danych: {ex.Message}");
                    }
                }
            }
        }

        public DataTable GetDoctorVisits(int doctorId, bool upcomingOnly = true)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"SELECT w.Id, w.DataWizyty, u.Imie, u.Nazwisko, u.PESEL, w.Status
                      FROM dbo.Wizyty w
                      INNER JOIN dbo.Users u ON w.PacjentId = u.Id
                      WHERE w.LekarzId = @DoctorId" +
                              (upcomingOnly ? " AND w.DataWizyty >= @Today AND w.Status = 'Zaplanowana'" : "") +
                              " ORDER BY w.DataWizyty";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);
                    if (upcomingOnly)
                    {
                        command.Parameters.AddWithValue("@Today", DateTime.Today);
                    }

                    var adapter = new SqlDataAdapter(command);
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public DataTable GetPatientHistory(int patientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"SELECT w.DataWizyty, d.Imie + ' ' + d.Nazwisko AS Lekarz, 
                             w.Specjalizacja, w.Diagnoza, w.Zalecenia, w.Opis
                      FROM dbo.Wizyty w
                      INNER JOIN dbo.Doctors d ON w.LekarzId = d.Id
                      WHERE w.PacjentId = @PatientId AND w.Status = 'Odbyta'
                      ORDER BY w.DataWizyty DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    var adapter = new SqlDataAdapter(command);
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public bool CompleteVisit(int visitId, string diagnosis, string recommendations, string description)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"UPDATE dbo.Wizyty 
                      SET Status = 'Odbyta', 
                          Diagnoza = @Diagnosis, 
                          Zalecenia = @Recommendations, 
                          Opis = @Description
                      WHERE Id = @VisitId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VisitId", visitId);
                    command.Parameters.AddWithValue("@Diagnosis", diagnosis);
                    command.Parameters.AddWithValue("@Recommendations", recommendations);
                    command.Parameters.AddWithValue("@Description", description);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public int AddPrescription(int doctorId, int patientId, int? visitId, string medications, string notes)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO dbo.Recepty 
                     (LekarzId, PacjentId, WizytaId, DataWystawienia, KodRecepty, Leki, Uwagi)
                      VALUES 
                     (@DoctorId, @PatientId, @VisitId, @IssueDate, @PrescriptionCode, @Medications, @Notes);
                      SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);
                    command.Parameters.AddWithValue("@PatientId", patientId);
                    command.Parameters.AddWithValue("@VisitId", visitId.HasValue ? (object)visitId.Value : DBNull.Value);
                    command.Parameters.AddWithValue("@IssueDate", DateTime.Now);
                    command.Parameters.AddWithValue("@PrescriptionCode", GeneratePrescriptionCode());
                    command.Parameters.AddWithValue("@Medications", medications);
                    command.Parameters.AddWithValue("@Notes", notes);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }
        public DataTable PobierzDzisiejszeWizytyLekarza(int lekarzId)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT w.Id, p.Imie, p.Nazwisko, w.Data, w.Opis FROM Wizyty w JOIN Pacjenci p ON w.PacjentId = p.Id WHERE w.LekarzId = @lekarzId AND CAST(w.Data AS DATE) = CAST(GETDATE() AS DATE)", conn))
            {
                cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
        public DataTable PobierzHistorieWizytPacjenta(int pacjentId)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT w.Data, l.Imie + ' ' + l.Nazwisko AS Lekarz, w.Diagnoza, w.Zalecenia FROM Wizyty w JOIN Lekarze l ON w.LekarzId = l.Id WHERE w.PacjentId = @pacjentId ORDER BY w.Data DESC", conn))
            {
                cmd.Parameters.AddWithValue("@pacjentId", pacjentId);
                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable SzukajWizytPoImieniuNazwisku(int lekarzId, string imieNazwisko)
        {
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT w.Id, p.Imie, p.Nazwisko, w.Data, w.Opis FROM Wizyty w JOIN Pacjenci p ON w.PacjentId = p.Id WHERE w.LekarzId = @lekarzId AND (p.Imie + ' ' + p.Nazwisko LIKE @szukaj)", conn))
            {
                cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                cmd.Parameters.AddWithValue("@szukaj", "%" + imieNazwisko + "%");

                var adapter = new SqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        private string GeneratePrescriptionCode()
        {
            return "R/" + DateTime.Now.ToString("yyyyMMdd") + "/" + Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
        }

        public DataTable PobierzWizytyLekarza(int lekarzId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            SELECT w.Id, w.DataWizyty, w.Status, u.Imie + ' ' + u.Nazwisko AS Pacjent, u.Id AS PacjentId
            FROM Wizyty w
            JOIN Users u ON u.Id = w.PacjentId
            WHERE w.LekarzId = @LekarzId
            ORDER BY w.DataWizyty DESC";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LekarzId", lekarzId);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    return table;
                }
            }
        }


        public Wizyta PobierzSzczegolyWizyty(int wizytaId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Wizyty WHERE Id = @WizytaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WizytaId", wizytaId);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Wizyta
                            {
                                Id = (int)reader["Id"],
                                Opis = reader["Opis"]?.ToString(),
                                Diagnoza = reader["Diagnoza"]?.ToString(),
                                Zalecenia = reader["Zalecenia"]?.ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }


        public void ZaktualizujWizyte(int wizytaId, string opis, string diagnoza, string zalecenia)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            UPDATE Wizyty
            SET Opis = @Opis,
                Diagnoza = @Diagnoza,
                Zalecenia = @Zalecenia
            WHERE Id = @WizytaId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Opis", string.IsNullOrEmpty(opis) ? DBNull.Value : (object)opis);
                    command.Parameters.AddWithValue("@Diagnoza", string.IsNullOrEmpty(diagnoza) ? DBNull.Value : (object)diagnoza);
                    command.Parameters.AddWithValue("@Zalecenia", string.IsNullOrEmpty(zalecenia) ? DBNull.Value : (object)zalecenia);
                    command.Parameters.AddWithValue("@WizytaId", wizytaId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void WystawSkierowanie(int pacjentId, int lekarzId, string typ, string cel, int? wizytaId = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            INSERT INTO Skierowania (WizytaId, PacjentId, LekarzId, DataWystawienia, Typ, Cel)
            VALUES (@WizytaId, @PacjentId, @LekarzId, @DataWystawienia, @Typ, @Cel)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WizytaId", (object)wizytaId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PacjentId", pacjentId);
                    command.Parameters.AddWithValue("@LekarzId", lekarzId);
                    command.Parameters.AddWithValue("@DataWystawienia", DateTime.Now);
                    command.Parameters.AddWithValue("@Typ", typ);
                    command.Parameters.AddWithValue("@Cel", cel);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }



        public void WystawRecepte(int pacjentId, int lekarzId, string kodRecepty, string leki, int? wizytaId = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
            INSERT INTO Recepty (WizytaId, PacjentId, LekarzId, DataWystawienia, KodRecepty, Leki)
            VALUES (@WizytaId, @PacjentId, @LekarzId, @DataWystawienia, @KodRecepty, @Leki)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WizytaId", (object)wizytaId ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PacjentId", pacjentId);
                    command.Parameters.AddWithValue("@LekarzId", lekarzId);
                    command.Parameters.AddWithValue("@DataWystawienia", DateTime.Now);
                    command.Parameters.AddWithValue("@KodRecepty", kodRecepty);
                    command.Parameters.AddWithValue("@Leki", leki);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public DataTable PobierzHistorieWizyt(int patientId)
        {
            DataTable table = new DataTable();

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(
                @"SELECT 
                w.Id,
                w.DataWizyty AS 'Data wizyty',
                d.Imie + ' ' + d.Nazwisko AS 'Lekarz',
                w.Diagnoza,
                w.Status
              FROM Wizyty w
              INNER JOIN Doctors d ON w.LekarzId = d.Id
              WHERE w.PacjentId = @PatientId
              ORDER BY w.DataWizyty DESC", connection))
            {
                command.Parameters.AddWithValue("@PatientId", patientId);

                try
                {
                    connection.Open();
                    table.Load(command.ExecuteReader());


                    if (table.Columns.Contains("Data wizyty"))
                    {
                        table.Columns["Data wizyty"].DataType = typeof(DateTime);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Błąd podczas pobierania historii wizyt", ex);
                }
            }

            return table;
        }


        public int DodajPacjenta(Patient patient)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(
                @"INSERT INTO Users (
                Imie, Nazwisko, DateOfBirth, PESEL, 
                Adres, Miasto, KodPocztowy, PhoneNumber, Email, IsActive
              ) 
              OUTPUT INSERTED.Id
              VALUES (
                @Imie, @Nazwisko, @DateOfBirth, @PESEL, 
                @Adres, @Miasto, @KodPocztowy, @PhoneNumber, @Email, @IsActive
              )", connection))
            {
                SetPatientParameters(command, patient);

                try
                {
                    connection.Open();
                    int newId = (int)command.ExecuteScalar();

                    // Dodaj rolę pacjenta
                    AddUserRole(newId, "Pacjent");

                    return newId;
                }
                catch (Exception ex)
                {
                    throw new Exception("Błąd podczas dodawania pacjenta", ex);
                }
            }
        }


        public void AktualizujPacjenta(Patient patient)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(
                @"UPDATE Users SET
                Imie = @Imie,
                Nazwisko = @Nazwisko,
                DateOfBirth = @DateOfBirth,
                PESEL = @PESEL,
                Adres = @Adres,
                Miasto = @Miasto,
                KodPocztowy = @KodPocztowy,
                PhoneNumber = @PhoneNumber,
                Email = @Email,
                IsActive = @IsActive
                WHERE Id = @Id", connection))
            {
                SetPatientParameters(command, patient);
                command.Parameters.AddWithValue("@Id", patient.Id);

                try
                {
                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();

                    if (affectedRows == 0)
                        throw new Exception("Nie znaleziono pacjenta o podanym ID");
                }
                catch (Exception ex)
                {
                    throw new Exception("Błąd podczas aktualizacji pacjenta", ex);
                }
            }
        }


        public Patient PobierzDanePacjenta(int patientId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
            SELECT Id, Imie, Nazwisko, Email, DateOfBirth, PESEL, 
                   PhoneNumber, Adres, Miasto, KodPocztowy
            FROM Users
            WHERE Id = @PatientId";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Patient
                            {
                                Id = reader.GetInt32(0),
                                Imie = reader.GetString(1),
                                Nazwisko = reader.GetString(2),
                                Email = reader.GetString(3),
                                DataUrodzenia = reader.GetDateTime(4),
                                PESEL = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Telefon = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Adres = reader.IsDBNull(7) ? null : reader.GetString(7),
                                Miasto = reader.IsDBNull(8) ? null : reader.GetString(8),
                                KodPocztowy = reader.IsDBNull(9) ? null : reader.GetString(9)
                            };
                        }
                    }
                }
            }
            return null;
        }


        private void SetPatientParameters(SqlCommand command, Patient patient)
        {
            command.Parameters.AddWithValue("@Imie", patient.Imie);
            command.Parameters.AddWithValue("@Nazwisko", patient.Nazwisko);
            command.Parameters.AddWithValue("@DateOfBirth", patient.DataUrodzenia);
            command.Parameters.AddWithValue("@PESEL", (object)patient.PESEL ?? DBNull.Value);
            command.Parameters.AddWithValue("@Adres", (object)patient.Adres ?? DBNull.Value);
            command.Parameters.AddWithValue("@Miasto", (object)patient.Miasto ?? DBNull.Value);
            command.Parameters.AddWithValue("@KodPocztowy", (object)patient.KodPocztowy ?? DBNull.Value);
            command.Parameters.AddWithValue("@PhoneNumber", (object)patient.Telefon ?? DBNull.Value);
            command.Parameters.AddWithValue("@Email", (object)patient.Email ?? DBNull.Value);
            command.Parameters.AddWithValue("@IsActive", patient.IsActive);
        }

        private void AddUserRole(int userId, string roleName)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(
                @"IF NOT EXISTS (SELECT 1 FROM UserRoles WHERE UserId = @UserId AND RoleName = @RoleName)
              BEGIN
                  INSERT INTO UserRoles (UserId, RoleName)
                  VALUES (@UserId, @RoleName)
              END", connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);
                command.Parameters.AddWithValue("@RoleName", roleName);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<Lekarz> PobierzDostepnychLekarzy()
        {
            var lekarze = new List<Lekarz>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT d.Id, d.Imie, d.Nazwisko, d.Specjalizacja
                        FROM Doctors d
                        JOIN Users u ON d.UserId = u.Id
                        JOIN UserRoles ur ON u.Id = ur.UserId
                        WHERE ur.RoleName = 'Lekarz'";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lekarze.Add(new Lekarz
                            {
                                Id = reader.GetInt32(0),
                                Imie = reader.IsDBNull(1) ? null : reader.GetString(1),
                                Nazwisko = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Specjalizacja = reader.IsDBNull(3) ? null : reader.GetString(3)
                            });
                        }
                    }
                }
            }

            return lekarze;
        }

        public bool CzyLekarzMaWolnyTermin(int lekarzId, DateTime dataWizyty)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT COUNT(*) 
                        FROM Wizyty 
                        WHERE LekarzId = @lekarzId 
                        AND DataWizyty = @dataWizyty
                        AND Status != 'Anulowana'";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@lekarzId", lekarzId);
                    command.Parameters.AddWithValue("@dataWizyty", dataWizyty);

                    int count = (int)command.ExecuteScalar();
                    return count == 0;
                }
            }
        }

        public int DodajWizyte(Wizyta wizyta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Wizyty 
                        (LekarzId, PacjentId, DataWizyty, Status, Opis, Diagnoza, Zalecenia, Specjalizacja)
                        VALUES (@LekarzId, @PacjentId, @DataWizyty, @Status, @Opis, @Diagnoza, @Zalecenia, @Specjalizacja);
                        SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LekarzId", wizyta.LekarzId);
                    command.Parameters.AddWithValue("@PacjentId", wizyta.PacjentId);
                    command.Parameters.AddWithValue("@DataWizyty", wizyta.DataWizyty);
                    command.Parameters.AddWithValue("@Status", wizyta.Status ?? "Zaplanowana");
                    command.Parameters.AddWithValue("@Opis", wizyta.Opis ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Diagnoza", wizyta.Diagnoza ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Zalecenia", wizyta.Zalecenia ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Specjalizacja", wizyta.Specjalizacja ?? (object)DBNull.Value);

                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public void AktualizujWizyte(Wizyta wizyta)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Wizyty 
                        SET Status = @Status,
                            Diagnoza = @Diagnoza,
                            Zalecenia = @Zalecenia
                        WHERE Id = @Id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", wizyta.Id);
                    command.Parameters.AddWithValue("@Status", wizyta.Status);
                    command.Parameters.AddWithValue("@Diagnoza", wizyta.Diagnoza ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Zalecenia", wizyta.Zalecenia ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Wizyta> PobierzWizytyPacjenta(int pacjentId)
        {
            var wizyty = new List<Wizyta>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT w.Id, w.LekarzId, w.PacjentId, w.DataWizyty, w.Status, 
                        w.Opis, w.Diagnoza, w.Zalecenia, w.Specjalizacja,
                        d.Imie AS LekarzImie, d.Nazwisko AS LekarzNazwisko
                        FROM Wizyty w
                        JOIN Doctors d ON w.LekarzId = d.Id
                        WHERE w.PacjentId = @pacjentId
                        ORDER BY w.DataWizyty DESC";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@pacjentId", pacjentId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            wizyty.Add(new Wizyta
                            {
                                Id = reader.GetInt32(0),
                                LekarzId = reader.GetInt32(1),
                                PacjentId = reader.GetInt32(2),
                                DataWizyty = reader.GetDateTime(3),
                                Status = reader.GetString(4),
                                Opis = reader.IsDBNull(5) ? null : reader.GetString(5),
                                Diagnoza = reader.IsDBNull(6) ? null : reader.GetString(6),
                                Zalecenia = reader.IsDBNull(7) ? null : reader.GetString(7),
                                Specjalizacja = reader.IsDBNull(8) ? null : reader.GetString(8)
                            });
                        }
                    }
                }
            }

            return wizyty;
        }
        public void DodajDokument(DokumentPacjenta dokument)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"INSERT INTO DokumentyPacjenta (PacjentId, DataDodania, Typ, Uwagi, SciezkaPliku)
                            VALUES (@PacjentId, @DataDodania, @Typ, @Uwagi, @SciezkaPliku)";
                cmd.Parameters.AddWithValue("@PacjentId", dokument.PacjentId);
                cmd.Parameters.AddWithValue("@DataDodania", dokument.DataDodania.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@Typ", dokument.Typ);
                cmd.Parameters.AddWithValue("@Uwagi", dokument.Uwagi);
                cmd.Parameters.AddWithValue("@SciezkaPliku", dokument.SciezkaPliku);
                cmd.ExecuteNonQuery();
            }
        }

        public List<DokumentPacjenta> PobierzDokumentyDlaPacjenta(int pacjentId)
        {
            var lista = new List<DokumentPacjenta>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM DokumentyPacjenta WHERE PacjentId = @PacjentId ORDER BY DataDodania DESC";
                cmd.Parameters.AddWithValue("@PacjentId", pacjentId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new DokumentPacjenta
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            PacjentId = Convert.ToInt32(reader["PacjentId"]),
                            DataDodania = DateTime.Parse(reader["DataDodania"].ToString()),
                            Typ = reader["Typ"].ToString(),
                            Uwagi = reader["Uwagi"].ToString(),
                            SciezkaPliku = reader["SciezkaPliku"].ToString()
                        });
                    }
                }
            }

            return lista;
        }


        public DokumentPacjenta PobierzDokumentPoIndeksie(int pacjentId, int index)
        {
            var dokumenty = PobierzDokumentyDlaPacjenta(pacjentId);
            if (index >= 0 && index < dokumenty.Count)
            {
                return dokumenty[index];
            }
            return null;
        }


        public void UsunDokument(int dokumentId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM DokumentyPacjenta WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", dokumentId);
                cmd.ExecuteNonQuery();
            }
        }

        public void WyslijPowiadomienie(int pacjentId, string tresc)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
                INSERT INTO Powiadomienia (PacjentId, Tresc, DataDodania)
                VALUES (@pacjentId, @tresc, @data)";
                cmd.Parameters.AddWithValue("@pacjentId", pacjentId);
                cmd.Parameters.AddWithValue("@tresc", tresc);
                cmd.Parameters.AddWithValue("@data", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }


        public void ZmienHasloLekarza(int lekarzId, string noweHaslo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Lekarze SET Haslo = @haslo WHERE Id = @id";
                cmd.Parameters.AddWithValue("@haslo", noweHaslo); // Można zahashować!
                cmd.Parameters.AddWithValue("@id", lekarzId);
                cmd.ExecuteNonQuery();
            }
        }

        public void UmowWizyte(int lekarzId, int pacjentId, DateTime data, string specjalizacja)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Wizyty (LekarzId, PacjentId, DataWizyty, Status, Specjalizacja) VALUES (@lekarzId, @pacjentId, @data, 'Zaplanowana', @specjalizacja";
                cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                cmd.Parameters.AddWithValue("@pacjentId", pacjentId);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@specjalizacja", specjalizacja);
                cmd.ExecuteNonQuery();
            }
        }

        public  DataTable PobierzWizytyDlaLekarza(int lekarzId, DateTime data)
        {
            DataTable dt = new DataTable();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Wizyty WHERE LekarzId = @lekarzId AND CAST(DataWizyty AS DATE) = @data";
                cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                cmd.Parameters.AddWithValue("@data", data);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }


        public  void ZapiszOpisIWyniki(int wizytaId, string opis, string diagnoza, string zalecenia)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Wizyty SET Opis = @opis, Diagnoza = @diagnoza, Zalecenia = @zalecenia WHERE Id = @wizytaId", conn);
                cmd.Parameters.AddWithValue("@opis", opis);
                cmd.Parameters.AddWithValue("@diagnoza", diagnoza);
                cmd.Parameters.AddWithValue("@zalecenia", zalecenia);
                cmd.Parameters.AddWithValue("@wizytaId", wizytaId);
                cmd.ExecuteNonQuery();
            }
        }

        public bool WystawRecepte(int? wizytaId, int pacjentId, int lekarzId, string leki, string uwagi, string kodRecepty)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                // Najpierw sprawdź czy lekarz i pacjent istnieją
                if (!SprawdzCzyLekarzIstnieje(lekarzId, connection))
                {
                    throw new Exception($"Lekarz o ID {lekarzId} nie istnieje w bazie danych");
                }

                if (!SprawdzCzyPacjentIstnieje(pacjentId, connection))
                {
                    throw new Exception($"Pacjent o ID {pacjentId} nie istnieje w bazie danych");
                }

                // Jeśli podano wizytę, sprawdź czy istnieje
                if (wizytaId.HasValue && !SprawdzCzyWizytaIstnieje(wizytaId.Value, connection))
                {
                    throw new Exception($"Wizyta o ID {wizytaId} nie istnieje w bazie danych");
                }

                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
            INSERT INTO Recepty (WizytaId, PacjentId, LekarzId, DataWystawienia, KodRecepty, Leki, Uwagi)
            VALUES (@WizytaId, @PacjentId, @LekarzId, @DataWystawienia, @KodRecepty, @Leki, @Uwagi)";

                cmd.Parameters.AddWithValue("@WizytaId", (object)wizytaId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@PacjentId", pacjentId);
                cmd.Parameters.AddWithValue("@LekarzId", lekarzId);
                cmd.Parameters.AddWithValue("@DataWystawienia", DateTime.Now);
                cmd.Parameters.AddWithValue("@KodRecepty", kodRecepty);
                cmd.Parameters.AddWithValue("@Leki", leki);
                cmd.Parameters.AddWithValue("@Uwagi", (object)uwagi ?? DBNull.Value);

                cmd.ExecuteNonQuery();
                return true;
            }
        }

        private bool SprawdzCzyLekarzIstnieje(int lekarzId, SqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Doctors WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", lekarzId);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private bool SprawdzCzyPacjentIstnieje(int pacjentId, SqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Id = @Id AND Rola = 'Pacjent'";
            cmd.Parameters.AddWithValue("@Id", pacjentId);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private bool SprawdzCzyWizytaIstnieje(int wizytaId, SqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Wizyty WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", wizytaId);
            return (int)cmd.ExecuteScalar() > 0;
        }


        public  void WystawSkierowanie(int wizytaId, int pacjentId, int lekarzId, string typ, string cel, string uwagi)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Skierowania (WizytaId, PacjentId, LekarzId, DataWystawienia, Typ, Cel, Uwagi) " +
                                                "VALUES (@wizytaId, @pacjentId, @lekarzId, @dataWystawienia, @typ, @cel, @uwagi)", conn);
                cmd.Parameters.AddWithValue("@wizytaId", wizytaId);
                cmd.Parameters.AddWithValue("@pacjentId", pacjentId);
                cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                cmd.Parameters.AddWithValue("@dataWystawienia", DateTime.Now);
                cmd.Parameters.AddWithValue("@typ", typ);
                cmd.Parameters.AddWithValue("@cel", cel);
                cmd.Parameters.AddWithValue("@uwagi", uwagi);
                cmd.ExecuteNonQuery();
            }
        }

        public  void ZmienEmail(int userId, string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users SET Email = @Email WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.ExecuteNonQuery();
            }
        }
        public  void ZmienHaslo(int userId, string haslo)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Users SET Haslo = @Haslo WHERE Id = @Id", conn);
                cmd.Parameters.AddWithValue("@Haslo", haslo);
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.ExecuteNonQuery();
            }
        }
        public int PobierzIdLekarza(int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT Id FROM Doctors WHERE UserId = @UserId";
                cmd.Parameters.AddWithValue("@UserId", userId);

                var result = cmd.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1;
            }
        }

    }
}

