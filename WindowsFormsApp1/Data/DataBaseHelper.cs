using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using WindowsFormsApp1.Models;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Diagnostics;



namespace WindowsFormsApp1.Data
{
    public class DataBaseHelper
    {
        private readonly string _connectionString;

       
        public DataBaseHelper(string connectionString = null)
        {
            _connectionString = connectionString ?? ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            
            if (string.IsNullOrEmpty(_connectionString))
            {
                throw new Exception("Brak connection string w app.config!");
            }
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                   
                    connection.Open();

                    
                    using (var cmd = new MySqlCommand("SELECT 1", connection))
                    {
                        var result = cmd.ExecuteScalar();
                        return result != null && result.ToString() == "1";
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Błąd MySQL: {ex.Number}\n{ex.Message}", "Błąd połączenia");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Inny błąd: {ex.Message}", "Błąd połączenia");
                return false;
            }
        }

        public void RegisterUser(Users user, string haslo, string rola)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"INSERT INTO Users 
                            (Imie, Nazwisko, Email, Haslo, Rola, DateOfBirth, PESEL, PhoneNumber, Adres, Miasto, KodPocztowy) 
                            VALUES 
                            (@Imie, @Nazwisko, @Email, @Haslo, @Rola, @DateOfBirth, @PESEL, PhoneNumber, @Adres, @Miasto, @KodPocztowy)";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Imie", user.Imie);
                    command.Parameters.AddWithValue("@Nazwisko", user.Nazwisko);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Haslo", haslo); 
                    command.Parameters.AddWithValue("@Rola", rola);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@PESEL", user.PESEL);
                    command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                    command.Parameters.AddWithValue("@Adres", user.Adres);
                    command.Parameters.AddWithValue("@Miasto", user.Miasto);
                    command.Parameters.AddWithValue("@KodPocztowy", user.KodPocztowy);

                    command.ExecuteNonQuery();
                }
            }
        }



        private int GetUserIdByEmail(string email, MySqlConnection connection)
        {
            var query = "SELECT Id FROM Users WHERE Email = @Email";
            using (var command = new MySqlCommand(query, connection))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Id, Imie, Nazwisko, Specjalizacja FROM Doctors WHERE UserId = @UserId";

                using (var command = new MySqlCommand(query, connection))
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

        public Users ZalogujUzytkownika(string email, string Haslo)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    
                    var query = @"
                                SELECT u.Id, u.Imie, u.Nazwisko, u.Email, 
                                IFNULL(ur.RoleName, 'Pacjent') AS Rola
                                FROM users u
                                LEFT JOIN userroles ur ON u.Id = ur.UserId
                                WHERE u.Email = ?Email AND u.Haslo = ?Haslo
                                LIMIT 1";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        
                        command.Parameters.Add("?Email", MySqlDbType.VarChar).Value = email;
                        command.Parameters.Add("?Haslo", MySqlDbType.VarChar).Value = Haslo;

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                return new Users
                                {
                                    Id = reader.GetInt32("Id"),
                                    Imie = reader.IsDBNull(reader.GetOrdinal("Imie")) ? "" : reader.GetString("Imie"),
                                    Nazwisko = reader.IsDBNull(reader.GetOrdinal("Nazwisko")) ? "" : reader.GetString("Nazwisko"),
                                    Email = reader.GetString("Email"),
                                    Rola = new Role { Nazwa = reader.GetString("Rola") }
                                };
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
               
                Console.WriteLine($"[{DateTime.Now}] Błąd MySQL #{ex.Number}: {ex.Message}");
                Debug.WriteLine($"[{DateTime.Now}] Błąd MySQL #{ex.Number}: {ex.Message}");

                throw new Exception("Błąd bazy danych podczas logowania. Spróbuj ponownie.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{DateTime.Now}] Błąd: {ex}");
                Debug.WriteLine($"[{DateTime.Now}] Błąd: {ex}");

                throw new Exception("Wystąpił nieoczekiwany błąd podczas logowania.");
            }

            return null;
        }



        public DataTable PobierzWszystkichLekarzy()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Doctors";
                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        public DataTable PobierzPacjentow()
        {
            var table = new DataTable();

            using (var connection = new MySqlConnection(_connectionString))
            {
                
                string query = @"
                                SELECT 
                                Id,
                                Imie AS 'Imię',
                                Nazwisko,
                                DATE_FORMAT(DateOfBirth, '%d.%m.%Y') AS 'Data urodzenia',
                                PhoneNumber AS 'Numer telefonu',
                                PESEL
                                FROM Users
                                WHERE Id IN (SELECT UserId FROM UserRoles WHERE RoleName = 'Pacjent')";

                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }


        public DataTable PobierzWszystkichPacjentow()
        {
            var table = new DataTable();

            using (var connection = new MySqlConnection(_connectionString))
            {
                string query = @"
                SELECT 
                u.Id,
                u.Imie,
                u.Nazwisko,
                u.Email,
                u.PhoneNumber AS 'PhoneNumber',
                ur.RoleName AS 'Rola'
                FROM Users u
                LEFT JOIN UserRoles ur ON u.Id = ur.UserId
                WHERE ur.RoleName = 'Pacjent' OR ur.RoleName IS NULL";

                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }

      


        public void NadajUprawnieniaLekarza(int userId, string specjalizacja)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        var checkRoleQuery = @"SELECT COUNT(*) FROM UserRoles 
                                     WHERE UserId = @UserId AND RoleName = 'Lekarz'";

                        using (var checkCommand = new MySqlCommand(checkRoleQuery, connection, transaction))
                        {
                            checkCommand.Parameters.AddWithValue("@UserId", userId);

                            long coutnt = Convert.ToInt64(checkCommand.ExecuteScalar());

                            if(coutnt > 0)
                            {
                                throw new Exception("Użytkownik już posiada rolę Lekarza.");
                            }

                        }


                        string imie = "", nazwisko = "";
                       
                        var queryUser = "SELECT Imie, Nazwisko FROM Users WHERE Id = @UserId";

                        using (var command = new MySqlCommand(queryUser, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    imie = reader["Imie"]?.ToString() ?? "";
                                    nazwisko = reader["Nazwisko"]?.ToString() ?? "";
                                }
                                else
                                {
                                    throw new Exception("user nie isniteje");
                                }
                            }
                        }


                        var insertRoleQuery = @"INSERT INTO UserRoles (UserId, RoleName) 
                                      VALUES (@UserId, 'Lekarz')";

                        using (var command = new MySqlCommand(insertRoleQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@UserId", userId);
                            command.ExecuteNonQuery();
                        }


                        var insertLekarzQuery = @"INSERT INTO Doctors 
                                        (UserId, Imie, Nazwisko, Specjalizacja) 
                                        VALUES (@UserId, @Imie, @Nazwisko, @Specjalizacja)";

                        using (var command = new MySqlCommand(insertLekarzQuery, connection, transaction))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();


                string imie = "", nazwisko = "";
                var queryLekarz = "SELECT Imie, Nazwisko FROM Doctors WHERE UserId = @UserId";
                using (var commandLekarz = new MySqlCommand(queryLekarz, connection))
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


                var queryDeleteLekarz = "DELETE FROM Doctors WHERE UserId = @UserId";
                using (var commandDeleteLekarz = new MySqlCommand(queryDeleteLekarz, connection))
                {
                    commandDeleteLekarz.Parameters.AddWithValue("@UserId", userId);
                    commandDeleteLekarz.ExecuteNonQuery();
                }


                var queryDeleteRole = "DELETE FROM UserRoles WHERE UserId = @UserId AND RoleName = 'Lekarz'";
                using (var commandDeleteRole = new MySqlCommand(queryDeleteRole, connection))
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

                var queryDeleteLekarz = "DELETE FROM Doctors WHERE UserId = @UserId";
                var queryDeletePacjent = "DELETE FROM Users WHERE UserId = @UserId";

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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                return GetUserIdByEmail(email, connection);
            }
        }

        public void DodajDoLekarzy(int userId, string imie, string nazwisko, string specjalizacja)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = @"INSERT INTO Lekarze (UzytkownikId, Imie, Nazwisko, Specjalizacja)
                      VALUES (@UzytkownikId, @Imie, @Nazwisko, @Specjalizacja)";
                using (var command = new MySqlCommand(query, connection))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM Users WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", userId);
                command.ExecuteNonQuery();
            }
        }

        public int PoliczLekarzy()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM Doctors";
                using (var command = new MySqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public int PoliczPacjentow()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT COUNT(*) FROM UserRoles WHERE RoleName = 'Pacjent'";
                using (var command = new MySqlCommand(query, connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public void UsunWszystkieDane()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var zapytania = new[]
                        {
                            "DELETE FROM UserRoles",
                            "DELETE FROM Doctors",
                            "DELETE FROM Users"
                        };

                        foreach (var query in zapytania)
                        {
                            using (var command = new MySqlCommand(query, connection, transaction))
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
       
        public DataTable PobierzHistorieWizytPacjenta(int pacjentId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("SELECT w.Data, l.Imie + ' ' + l.Nazwisko AS Lekarz, w.Diagnoza, w.Zalecenia FROM Wizyty w JOIN Lekarze l ON w.LekarzId = l.Id WHERE w.PacjentId = @pacjentId ORDER BY w.Data DESC", conn))
            {
                cmd.Parameters.AddWithValue("@pacjentId", pacjentId);
                var adapter = new MySqlDataAdapter(cmd);
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable SzukajWizytPoImieniuNazwisku(int lekarzId, string imieNazwisko)
        {
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("SELECT w.Id, p.Imie, p.Nazwisko, w.Data, w.Opis FROM Wizyty w JOIN Pacjenci p ON w.PacjentId = p.Id WHERE w.LekarzId = @lekarzId AND (p.Imie + ' ' + p.Nazwisko LIKE @szukaj)", conn))
            {
                cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                cmd.Parameters.AddWithValue("@szukaj", "%" + imieNazwisko + "%");

                var adapter = new MySqlDataAdapter(cmd);
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"
                                SELECT w.Id, w.DataWizyty, w.Status, u.Imie + ' ' + u.Nazwisko AS Pacjent, u.Id AS PacjentId
                                FROM Wizyty w
                                JOIN Users u ON u.Id = w.PacjentId
                                WHERE w.LekarzId = @LekarzId
                                ORDER BY w.DataWizyty DESC";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LekarzId", lekarzId);

                    MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    return table;
                }
            }
        }


        public Wizyta PobierzSzczegolyWizyty(int wizytaId)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Wizyty WHERE Id = @WizytaId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@WizytaId", wizytaId);
                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"
                                UPDATE Wizyty
                                SET Opis = @Opis,
                                Diagnoza = @Diagnoza,
                                Zalecenia = @Zalecenia
                                WHERE Id = @WizytaId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"
            INSERT INTO Skierowania (WizytaId, PacjentId, LekarzId, DataWystawienia, Typ, Cel)
            VALUES (@WizytaId, @PacjentId, @LekarzId, @DataWystawienia, @Typ, @Cel)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                string query = @"
            INSERT INTO Recepty (WizytaId, PacjentId, LekarzId, DataWystawienia, KodRecepty, Leki)
            VALUES (@WizytaId, @PacjentId, @LekarzId, @DataWystawienia, @KodRecepty, @Leki)";

                using (MySqlCommand command = new MySqlCommand(query, connection))
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

            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(
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
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(
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
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"
                   SELECT Id, Imie, Nazwisko, Email, DateOfBirth, PESEL, 
                   PhoneNumber, Adres, Miasto, KodPocztowy
                   FROM Users
                   WHERE Id = @PatientId";

                using (var command = new MySqlCommand(query, connection))
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


        private void SetPatientParameters(MySqlCommand command, Patient patient)
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
            using (var connection = new MySqlConnection(_connectionString))
            using (var command = new MySqlCommand(
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

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT d.Id, d.Imie, d.Nazwisko, d.Specjalizacja
                        FROM Doctors d
                        JOIN Users u ON d.UserId = u.Id
                        JOIN UserRoles ur ON u.Id = ur.UserId
                        WHERE ur.RoleName = 'Lekarz'";

                using (var command = new MySqlCommand(query, connection))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                string query = @"SELECT COUNT(*) 
                        FROM Wizyty 
                        WHERE LekarzId = @lekarzId 
                        AND DataWizyty = @dataWizyty
                        AND Status != 'Anulowana'";

                using (var command = new MySqlCommand(query, connection))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"INSERT INTO Wizyty 
                        (LekarzId, PacjentId, DataWizyty, Status, Opis, Diagnoza, Zalecenia, Specjalizacja)
                        VALUES (@LekarzId, @PacjentId, @DataWizyty, @Status, @Opis, @Diagnoza, @Zalecenia, @Specjalizacja);
                        SELECT SCOPE_IDENTITY();";

                using (var command = new MySqlCommand(query, connection))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"UPDATE Wizyty 
                        SET Status = @Status,
                            Diagnoza = @Diagnoza,
                            Zalecenia = @Zalecenia
                        WHERE Id = @Id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", wizyta.Id);
                    command.Parameters.AddWithValue("@Status", wizyta.Status);
                    command.Parameters.AddWithValue("@Diagnoza", wizyta.Diagnoza ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Zalecenia", wizyta.Zalecenia ?? (object)DBNull.Value);

                    command.ExecuteNonQuery();
                }
            }
        }

        
        public void DodajDokument(DokumentPacjenta dokument)
        {
            using (var connection = new MySqlConnection(_connectionString))
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

            using (var connection = new MySqlConnection(_connectionString))
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
            using (var connection = new MySqlConnection(_connectionString))
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
            using (var connection = new MySqlConnection(_connectionString))
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

        //to sie przyda

        public void ZmienHasloLekarza(int lekarzId, string noweHaslo)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "UPDATE Lekarze SET Haslo = @haslo WHERE Id = @id";
                cmd.Parameters.AddWithValue("@haslo", noweHaslo); 
                cmd.Parameters.AddWithValue("@id", lekarzId);
                cmd.ExecuteNonQuery();
            }
        }


        //to sie przyda
        public void UmowWizyte(int lekarzId, int pacjentId, DateTime data, string specjalizacja)
        {
            using (var connection = new MySqlConnection(_connectionString))
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
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM Wizyty WHERE LekarzId = @lekarzId AND CAST(DataWizyty AS DATE) = @data";
                cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                cmd.Parameters.AddWithValue("@data", data);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }


        public  void ZapiszOpisIWyniki(int wizytaId, string opis, string diagnoza, string zalecenia)
        {
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Wizyty SET Opis = @opis, Diagnoza = @diagnoza, Zalecenia = @zalecenia WHERE Id = @wizytaId", conn);
                cmd.Parameters.AddWithValue("@opis", opis);
                cmd.Parameters.AddWithValue("@diagnoza", diagnoza);
                cmd.Parameters.AddWithValue("@zalecenia", zalecenia);
                cmd.Parameters.AddWithValue("@wizytaId", wizytaId);
                cmd.ExecuteNonQuery();
            }
        }


        private bool SprawdzCzyLekarzIstnieje(int lekarzId, MySqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Doctors WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", lekarzId);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private bool SprawdzCzyPacjentIstnieje(int pacjentId, MySqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Id = @Id AND Rola = 'Pacjent'";
            cmd.Parameters.AddWithValue("@Id", pacjentId);
            return (int)cmd.ExecuteScalar() > 0;
        }

        private bool SprawdzCzyWizytaIstnieje(int wizytaId, MySqlConnection connection)
        {
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM Wizyty WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", wizytaId);
            return (int)cmd.ExecuteScalar() > 0;
        }

        public bool WystawRecepte(int? wizytaId, int pacjentId, int lekarzId, string leki, string uwagi, string kodRecepty)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                
                if (!SprawdzCzyLekarzIstnieje(lekarzId, connection))
                {
                    throw new Exception($"Lekarz o ID {lekarzId} nie istnieje w bazie danych");
                }

                if (!SprawdzCzyPacjentIstnieje(pacjentId, connection))
                {
                    throw new Exception($"Pacjent o ID {pacjentId} nie istnieje w bazie danych");
                }

               
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
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Users SET Email = @Email WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.ExecuteNonQuery();
            }
        }
        public  void ZmienHaslo(int userId, string haslo)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE Users SET Haslo = @Haslo WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue("@Haslo", haslo);
                cmd.Parameters.AddWithValue("@Id", userId);
                cmd.ExecuteNonQuery();
            }
        }
        public int PobierzIdLekarza(int userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
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

