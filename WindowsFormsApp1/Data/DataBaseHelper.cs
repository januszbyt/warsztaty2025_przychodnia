using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System;
using WindowsFormsApp1.Models;
using System.Windows.Forms;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Text;
using Org.BouncyCastle.Bcpg;
using Microsoft.VisualBasic.ApplicationServices;
using System.Linq;



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

        public string ConnectionString => _connectionString;

        public IEnumerable<Users> WyliczUzytkownikow()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();

                var query = "SELECT * FROM Users";
                using (var cmd = new MySqlCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Users
                            {
                                Id = reader.GetInt32("Id"),
                                Imie = reader.GetString("Imie"),
                                Nazwisko = reader.GetString("Nazwisko"),
                                Email = reader.GetString("Email"),
                                Haslo = reader.GetString("Haslo"),
                                Rola = new Role { Nazwa = reader.GetString("Rola") },
                                DateOfBirth = reader.GetDateTime("DateOfBirth"),
                                PESEL = reader.GetString("PESEL"),
                                PhoneNumber = reader.GetString("PhoneNumber"),
                                Adres = reader.GetString("Adres"),
                                Miasto = reader.GetString("Miasto"),
                                KodPocztowy = reader.GetString("KodPocztowy"),
                            };
                        }
                    }
                }
            }
        }

        // // Dawid Kotlinski
        // public string LosoweImie()
        // {
        //     var imiona = new List<string> { "Jan", "Adam", "Marek", "Piotr", "Krzysztof", "Andrzej", "Marcin", "Kamil", "Maciej", "Sebastian" };
        //     return imiona[new Random().Next(imiona.Count)];
        // }

        // // Dawid Kotlinski
        // public string LosoweNazwisko()
        // {
        //     var nazwiska = new List<string> { "Kowalski", "Nowak", "Wiśniewski", "Kowalczyk", "Kowalska", "Nowak", "Wiśniewska", "Kowalczyk", "Kowalska", "Nowak" };
        //     return nazwiska[new Random().Next(nazwiska.Count)];
        // }

        // // Dawid Kotlinski
        // public string LosowyEmail(string imie, string nazwisko)
        // {
        //     var domeny = new List<string> { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "example.com" };
        //     return $"{imie}.{nazwisko}@{domeny[new Random().Next(domeny.Count)]}";
        // }

        // // Dawid Kotlinski
        // public string LosoweHaslo()
        // {
        //     var hasla = new List<string> { "haslo123", "password", "qwerty", "admin", "user" };
        //     return hasla[new Random().Next(hasla.Count)];
        // }

        // // Dawid Kotlinski
        // public string LosowyPESEL()
        // {
        //     var pesele = new List<string> { "12345678901", "12345678902", "12345678903", "12345678904", "12345678905" };
        //     return pesele[new Random().Next(pesele.Count)];
        // }

        // // Dawid Kotlinski
        // public string LosowyTelefon()
        // {
        //     var telefony = new List<string> { "1234567890", "12345678901", "12345678902", "12345678903", "12345678904" };
        //     return telefony[new Random().Next(telefony.Count)];
        // }

        // // Dawid Kotlinski
        // public string LosowyAdres()
        // {
        //     var adresy = new List<string> { "ul. Sikorskiego", "ul. Długa", "ul. Szeroka", "ul. Krótka", "ul. Wąska" };
        //     return adresy[new Random().Next(adresy.Count)];
        // }

        // // Dawid Kotlinski
        // public string LosoweMiasto()
        // {
        //     var miasta = new List<string> { "Warszawa", "Krakow", "Wroclaw", "Gdansk", "Poznan" };
        //     return miasta[new Random().Next(miasta.Count)];
        // }

        // // Dawid Kotlinski
        // public string LosowyKodPocztowy()
        // {
        //     var kodyPocztowe = new List<string> { "00-000", "11-111", "22-222", "33-333", "44-444" };
        //     return kodyPocztowe[new Random().Next(kodyPocztowe.Count)];
        // }

        // public string LosowaRola()
        // {
        //     var role = new List<string> { "Pacjent", "Lekarz", "Admin" };
        //     return role[new Random().Next(role.Count)];
        // }

        // public DateTime LosowaDataUrodzenia()
        // {
        //     var rok = new Random().Next(1900, 2025);
        //     var miesiac = new Random().Next(1, 13);
        //     var dzien = new Random().Next(1, 32);
        //     return new DateTime(rok, miesiac, dzien);
        // }



        // // Dawid Kotlinski
        // public void DodajLosoweUzytkownika()
        // {
        //     using (var conn = new MySqlConnection(_connectionString))
        //     {
        //         conn.Open();

        //         var imie = LosoweImie();
        //         var nazwisko = LosoweNazwisko();
        //         var email = LosowyEmail(imie, nazwisko);
        //         var haslo = LosoweHaslo();
        //         var pesel = LosowyPESEL();
        //         var telefon = LosowyTelefon();
        //         var adres = LosowyAdres();
        //         var miasto = LosoweMiasto();
        //         var kodPocztowy = LosowyKodPocztowy();
        //         var rola = LosowaRola();
        //         var dataUrodzenia = LosowaDataUrodzenia();
        //         int? userId = null;

        //         {
        //             var query = "INSERT INTO Users (Imie, Nazwisko, Email, Rola, DateOfBirth, PESEL, PhoneNumber, Adres, Miasto, KodPocztowy) VALUES (@Imie, @Nazwisko, @Email, @Rola, @DateOfBirth, @PESEL, @PhoneNumber, @Adres, @Miasto, @KodPocztowy)";

        //             using (var cmd = new MySqlCommand(query, conn))
        //             {
        //                 cmd.Parameters.AddWithValue("@Imie", imie);
        //                 cmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
        //                 cmd.Parameters.AddWithValue("@Email", email);
        //                 cmd.Parameters.AddWithValue("@Rola", rola);
        //                 cmd.Parameters.AddWithValue("@PESEL", pesel);
        //                 cmd.Parameters.AddWithValue("@PhoneNumber", telefon);
        //                 cmd.Parameters.AddWithValue("@Adres", adres);
        //                 cmd.Parameters.AddWithValue("@Miasto", miasto);
        //                 cmd.Parameters.AddWithValue("@KodPocztowy", kodPocztowy);
        //                 cmd.Parameters.AddWithValue("@DateOfBirth", dataUrodzenia);

        //                 cmd.ExecuteNonQuery();
        //                 userId = (int)cmd.LastInsertedId;
        //             }
        //         }

        //         Debug.Assert(userId != null);

        //         if (rola == "Pacjent")
        //         {
        //             var query = "INSERT INTO Patients (UserId, PESEL, PhoneNumber, Adres, Miasto, KodPocztowy, DateOfBirth, Imie, Nazwisko, Email, Haslo, IsActive) VALUES (@UserId, @PESEL, @PhoneNumber, @Adres, @Miasto, @KodPocztowy, @DateOfBirth, @Imie, @Nazwisko, @Email, @Haslo, @IsActive)";
        //             using (var cmd = new MySqlCommand(query, conn))
        //             {
        //                 cmd.Parameters.AddWithValue("@UserId", userId);
        //                 cmd.Parameters.AddWithValue("@PESEL", pesel);
        //                 cmd.Parameters.AddWithValue("@PhoneNumber", telefon);
        //                 cmd.Parameters.AddWithValue("@Adres", adres);
        //                 cmd.Parameters.AddWithValue("@Miasto", miasto);
        //                 cmd.Parameters.AddWithValue("@KodPocztowy", kodPocztowy);
        //                 cmd.Parameters.AddWithValue("@DateOfBirth", dataUrodzenia);
        //                 cmd.Parameters.AddWithValue("@Imie", imie);
        //                 cmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
        //                 cmd.Parameters.AddWithValue("@Email", email);
        //                 cmd.Parameters.AddWithValue("@Haslo", haslo);
        //                 cmd.Parameters.AddWithValue("@IsActive", true);
        //                 cmd.ExecuteNonQuery();
        //             }
        //         }
        //         else if (rola == "Lekarz")
        //         {
        //             var query = "INSERT INTO Doctors (UserId, Specialization, IsActive) VALUES (@UserId, @Specialization, @IsActive)";
        //             using (var cmd = new MySqlCommand(query, conn))
        //             {
        //                 cmd.Parameters.AddWithValue("@UserId", userId);
        //                 cmd.Parameters.AddWithValue("@Specialization", "Testowa specjalizacja");
        //                 cmd.Parameters.AddWithValue("@IsActive", true);
        //                 cmd.ExecuteNonQuery();
        //             }
        //         }

        //         {
        //             var query = "INSERT INTO UserRoles (UserId, RoleName) VALUES (@UserId, @RoleName)";
        //             using (var cmd = new MySqlCommand(query, conn))
        //             {
        //                 cmd.Parameters.AddWithValue("@UserId", userId);
        //                 cmd.Parameters.AddWithValue("@RoleName", rola);
        //                 cmd.ExecuteNonQuery();
        //             }
        //         }
        //     }
        // }

        // // Dawid Kotlinski
        // public void SprawdzIntegralnoscDanych()
        // {
        //     using (var conn = new MySqlConnection(_connectionString))
        //     {
        //         conn.Open();

        //         // Sprawdz userów
        //         foreach (var user in WyliczUzytkownikow())
        //         {
        //             // Sprawdź hasło
        //             if (user.Haslo == null || user.Haslo == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma hasła");
        //             }
        //             // Sprawdź mail
        //             if (user.Email == null || user.Email == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma adresu email");
        //             }
        //             if (user.Rola.Nazwa == null || user.Rola.Nazwa == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma przypisanej roli");
        //             }
        //             if (user.Rola.Nazwa != "Pacjent" && user.Rola.Nazwa != "Lekarz" && user.Rola.Nazwa != "Admin")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} ma nieprawidłową rolę");
        //             }
        //             if (user.Imie == null || user.Imie == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma imienia");
        //             }
        //             if (user.Nazwisko == null || user.Nazwisko == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma nazwiska");
        //             }
        //             if (user.PESEL == null || user.PESEL == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma numeru PESEL");
        //             }
        //             if (user.PESEL.Length != 11)
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} ma nieprawidłową długość numeru PESEL");
        //             }
        //             // if (user.PESEL.Any(c => !char.IsDigit(c)))
        //             // {
        //             //     MessageBox.Show($"Użytkownik {user.Id} ma nieprawidłowy numer PESEL (powinien zawierać tylko cyfry)");
        //             // }
        //             if (user.PhoneNumber == null || user.PhoneNumber == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma numeru telefonu");
        //             }
        //             if (user.PhoneNumber.Length != 9)
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} ma nieprawidłową długość numeru telefonu");
        //             }
        //             // if (user.PhoneNumber.Any(c => !char.IsDigit(c)))
        //             // {
        //             //     MessageBox.Show($"Użytkownik {user.Id} ma nieprawidłowy numer telefonu (powinien zawierać tylko cyfry)");
        //             // }
        //             if (user.Adres == null || user.Adres == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma adresu");
        //             }
        //             if (user.Miasto == null || user.Miasto == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma miasta");
        //             }
        //             if (user.KodPocztowy == null || user.KodPocztowy == "")
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} nie ma kodu pocztowego");
        //             }
        //             if (user.KodPocztowy.Length != 6)
        //             {
        //                 MessageBox.Show($"Użytkownik {user.Id} ma nieprawidłową długość kodu pocztowego");
        //             }
        //             // if (user.KodPocztowy.Any(c => !char.IsDigit(c)))
        //             // {
        //             //     MessageBox.Show($"Użytkownik {user.Id} ma nieprawidłowy kod pocztowy (powinien zawierać tylko cyfry)");
        //             // }
        //         }
        //     }
        // }
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

        // Dawid Kotlinski
        // public Users PobierzUzytkownika(int userId)
        // {
        //     using (var connection = new MySqlConnection(_connectionString))
        //     {
        //         connection.Open();

        //         var query = "SELECT Id, Imie, Nazwisko, Email, Rola, DateOfBirth, PESEL, PhoneNumber, Adres, Miasto, KodPocztowy, Haslo FROM Users WHERE Id = @UserId";
        //         using (var command = new MySqlCommand(query, connection))
        //         {
        //             command.Parameters.AddWithValue("@UserId", userId);
        //             using (var reader = command.ExecuteReader())
        //             {
        //                 if (reader.Read())
        //                 {
        //                     return new Users
        //                     {
        //                         Id = reader.GetInt32(0),
        //                         Imie = reader.GetString(1),
        //                         Nazwisko = reader.GetString(2),
        //                         Email = reader.GetString(3),
        //                         Rola = new Role { Nazwa = reader.GetString(4) },
        //                         DateOfBirth = reader.GetDateTime(5),
        //                         PESEL = reader.GetString(6),
        //                         PhoneNumber = reader.GetString(7),
        //                         Adres = reader.GetString(8),
        //                         Miasto = reader.GetString(9),
        //                         KodPocztowy = reader.GetString(10),
        //                         Haslo = reader.GetString(11),
        //                     };
        //                 }
        //             }
        //         }
        //     }
        //     return null;
        // }

        public Lekarz PobierzLekarza(int userId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT Id, Imie, Nazwisko, Specjalizacja, UserId FROM Doctors WHERE UserId = @UserId";

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
                                Specjalizacja = reader.GetString(3),
                                UserId = reader.GetInt32(4),
                                // User = PobierzUzytkownika(reader.GetInt32(4)),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public Users ZalogujUzytkownika(string email, string Haslo)
        {
            //try
            //{
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();


                var query = @"
                                SELECT u.Id, u.Imie, u.Nazwisko, u.Email, u.Rola AS Rola
                                FROM users u
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
                            var user = new Users
                            {
                                Id = reader.GetInt32("Id"),
                                Imie = reader.IsDBNull(reader.GetOrdinal("Imie")) ? "" : reader.GetString("Imie"),
                                Nazwisko = reader.IsDBNull(reader.GetOrdinal("Nazwisko")) ? "" : reader.GetString("Nazwisko"),
                                Email = reader.GetString("Email"),
                                Rola = new Role { Nazwa = reader.GetString("Rola") }
                            };
                            Debug.Assert(user.Rola.Nazwa == "Pacjent" || user.Rola.Nazwa == "Lekarz" || user.Rola.Nazwa == "Admin");
                            return user;
                        }
                    }
                }
            }
            //}
            //catch (MySqlException ex)
            //{

            //    Console.WriteLine($"[{DateTime.Now}] Błąd MySQL #{ex.Number}: {ex.Message}");
            //    Debug.WriteLine($"[{DateTime.Now}] Błąd MySQL #{ex.Number}: {ex.Message}");

            //    throw new Exception("Błąd bazy danych podczas logowania. Spróbuj ponownie.");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"[{DateTime.Now}] Błąd: {ex}");
            //    Debug.WriteLine($"[{DateTime.Now}] Błąd: {ex}");

            //    throw ex;
            //    //throw new Exception("Wystąpił nieoczekiwany błąd podczas logowania.");
            //}

            return null;
        }


        //Nowe dla lekarza 

       

        public List<Users> SzukajPacjentowLekarza(int lekarzId, string imieNazwisko)
        {
            var list = new List<Users>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                SELECT DISTINCT u.*
                FROM users u
                INNER JOIN wizyty w ON w.PacjentId = u.Id
                WHERE w.LekarzId = @lekarzId
                AND CONCAT(u.Imie, ' ', u.Nazwisko) LIKE @szukaj
                ";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                    cmd.Parameters.AddWithValue("@szukaj", $"%{imieNazwisko}%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new Users
                            {
                                Id = reader.GetInt32("Id"),
                                Imie = reader.GetString("Imie"),
                                Nazwisko = reader.GetString("Nazwisko"),
                                Email = reader["Email"]?.ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public List<object> PobierzWizytyPacjentaZSzczegolami(int pacjentId)
        {
            var lista = new List<object>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                w.DataWizyty, w.Status, w.Opis, w.Diagnoza, w.Zalecenia,
                r.Leki AS ReceptaLeki
                FROM wizyty w
                LEFT JOIN recepty r ON r.WizytaId = w.Id
                WHERE w.PacjentId = @pacjentId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pacjentId", pacjentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new
                            {
                                Data = reader.GetDateTime("DataWizyty").ToString("yyyy-MM-dd"),
                                Status = reader["Status"]?.ToString(),
                                Opis = reader["Opis"]?.ToString(),
                                Diagnoza = reader["Diagnoza"]?.ToString(),
                                Zalecenia = reader["Zalecenia"]?.ToString(),
                                Recepta = reader["ReceptaLeki"]?.ToString()
                            });
                        }
                    }
                }
            }

            return lista;
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

        public Lekarz PobierzDaneLekarza(int id)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
            SELECT u.Id, u.Imie, u.Nazwisko, u.Adres, u.PESEL, u.PhoneNumber,
                   u.Miasto, u.KodPocztowy, u.Email, u.Haslo,
                   d.Specjalizacja
            FROM Users u
            LEFT JOIN Doctors d ON u.Id = d.UserId
            WHERE u.Id = @Id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Lekarz
                            {
                                Id = reader.GetInt32("Id"),
                                Imie = reader.GetString("Imie"),
                                Nazwisko = reader.GetString("Nazwisko"),
                                Adres = reader.GetString("Adres"),
                                Pesel = reader.GetString("PESEL"),
                                Telefon = reader.GetString("PhoneNumber"),
                                Miasto = reader.GetString("Miasto"),
                                KodPocztowy = reader.GetString("KodPocztowy"),
                                Email = reader.GetString("Email"),
                                Haslo = reader.GetString("Haslo"),
                                Specjalizacja = reader.IsDBNull(reader.GetOrdinal("Specjalizacja"))
                                    ? ""
                                    : reader.GetString("Specjalizacja")
                            };
                        }
                    }
                }
            }

            return null;
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
                                WHERE Rola = 'Pacjent'";

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
                u.Rola
                FROM Users u
                WHERE u.Rola = 'Pacjent'";

                using (var adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(table);
                }
            }

            return table;
        }


        public DataTable PobierzListeLekarzy()
        {
            var table = new DataTable();

            using (var connection = new MySqlConnection(_connectionString))
            {
                var query = @"
            SELECT 
                u.Id,
                u.Imie AS 'Imię',
                u.Nazwisko,
                d.Specjalizacja,
                u.Email
             FROM Users u
             LEFT JOIN Doctors d ON u.Id = d.UserId
             WHERE u.Rola = 'Lekarz'";

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
                        // Pobierz aktualną rolę
                        string currentRole = null;
                        var checkRoleQuery = @"SELECT Rola FROM Users WHERE Id = @UserId";
                        using (var checkCommand = new MySqlCommand(checkRoleQuery, connection, transaction))
                        {
                            checkCommand.Parameters.AddWithValue("@UserId", userId);
                            currentRole = checkCommand.ExecuteScalar()?.ToString();
                        }

                        // Jeśli rola jest inna niż Lekarz, aktualizuj ją
                        if (currentRole != "Lekarz")
                        {
                            var updateRoleQuery = @"UPDATE Users SET Rola = 'Lekarz' WHERE Id = @UserId";
                            using (var updateCommand = new MySqlCommand(updateRoleQuery, connection, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@UserId", userId);
                                updateCommand.ExecuteNonQuery();
                            }
                        }

                        // Sprawdź, czy lekarz jest już w tabeli Doctors
                        long lekarzCount = 0;
                        var checkDoctorQuery = @"SELECT COUNT(*) FROM Doctors WHERE UserId = @UserId";
                        using (var checkDoctorCmd = new MySqlCommand(checkDoctorQuery, connection, transaction))
                        {
                            checkDoctorCmd.Parameters.AddWithValue("@UserId", userId);
                            lekarzCount = Convert.ToInt64(checkDoctorCmd.ExecuteScalar());
                        }

                        if (lekarzCount == 0)
                        {
                            // Pobierz dane użytkownika (imię i nazwisko)
                            string imie = "";
                            string nazwisko = "";

                            var getUserQuery = @"SELECT Imie, Nazwisko FROM Users WHERE Id = @UserId";
                            using (var getUserCmd = new MySqlCommand(getUserQuery, connection, transaction))
                            {
                                getUserCmd.Parameters.AddWithValue("@UserId", userId);
                                using (var reader = getUserCmd.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        imie = reader["Imie"]?.ToString() ?? "";
                                        nazwisko = reader["Nazwisko"]?.ToString() ?? "";
                                    }
                                    else
                                    {
                                        throw new Exception("Użytkownik nie istnieje.");
                                    }
                                }
                            }

                            // Dodaj wpis do Doctors
                            var insertDoctorQuery = @"INSERT INTO Doctors (UserId, Imie, Nazwisko, Specjalizacja) 
                                              VALUES (@UserId, @Imie, @Nazwisko, @Specjalizacja)";
                            using (var insertCmd = new MySqlCommand(insertDoctorQuery, connection, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@UserId", userId);
                                insertCmd.Parameters.AddWithValue("@Imie", imie);
                                insertCmd.Parameters.AddWithValue("@Nazwisko", nazwisko);
                                insertCmd.Parameters.AddWithValue("@Specjalizacja", specjalizacja);
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Jeśli lekarz jest już w tabeli Doctors, możesz np. aktualizować specjalizację
                            var updateSpecjalizacjaQuery = @"UPDATE Doctors SET Specjalizacja = @Specjalizacja WHERE UserId = @UserId";
                            using (var updateCmd = new MySqlCommand(updateSpecjalizacjaQuery, connection, transaction))
                            {
                                updateCmd.Parameters.AddWithValue("@Specjalizacja", specjalizacja);
                                updateCmd.Parameters.AddWithValue("@UserId", userId);
                                updateCmd.ExecuteNonQuery();
                            }
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
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        bool maRoleLekarza = false;
                        var checkRoleQuery = "SELECT COUNT(*) FROM users WHERE UserId = @UserId AND TRIM(LOWER(Rola)) = 'Lekarz'";

                        using (var checkCmd = new MySqlCommand(checkRoleQuery, connection, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@UserId", userId);
                            maRoleLekarza = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0;
                        }

                        if (!maRoleLekarza)
                        {
                            throw new Exception("Użytkownik nie ma przypisanej roli 'Lekarz'.");
                        }


                        var deleteDoctorQuery = "DELETE FROM Doctors WHERE UserId = @UserId";
                        int affectedRows;
                        using (var doctorCmd = new MySqlCommand(deleteDoctorQuery, connection, transaction))
                        {
                            doctorCmd.Parameters.AddWithValue("@UserId", userId);
                            affectedRows = doctorCmd.ExecuteNonQuery();
                        }

                        if (affectedRows == 0)
                        {
                            throw new Exception("Użytkownik ma rolę 'Lekarz', ale nie ma powiązanego wpisu w tabeli Doctors.");
                        }


                        var deleteRoleQuery = "DELETE FROM users WHERE UserId = @UserId AND TRIM(LOWER(Rola)) = 'lekarz'";
                        using (var roleCmd = new MySqlCommand(deleteRoleQuery, connection, transaction))
                        {
                            roleCmd.Parameters.AddWithValue("@UserId", userId);
                            roleCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Pomyślnie odebrano uprawnienia lekarza.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Błąd podczas odbierania uprawnień lekarza: " + ex.Message);
                    }
                }
            }
        }





        public string SprawdzStatusLekarza(int userId)
        {
            var sb = new StringBuilder();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();


                var queryUser = "SELECT Imie, Nazwisko FROM Users WHERE Id = @UserId";
                using (var cmd = new MySqlCommand(queryUser, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            sb.AppendLine($"Użytkownik: {reader["Imie"]} {reader["Nazwisko"]}");
                        }
                        else
                        {
                            return "Użytkownik nie istnieje";
                        }
                    }
                }


                var queryRoles = "SELECT Rola FROM Users WHERE Id = @UserId";
                using (var cmd = new MySqlCommand(queryRoles, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        sb.Append("Przypisane role: ");
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                sb.Append($"{reader["Rola"]}, ");
                            }
                        }
                        else
                        {
                            sb.Append("brak ról");
                        }
                        sb.AppendLine();
                    }
                }


                var queryDoctor = "SELECT Specjalizacja FROM Doctors WHERE UserId = @UserId";
                using (var cmd = new MySqlCommand(queryDoctor, connection))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    var result = cmd.ExecuteScalar();
                    sb.AppendLine(result != null
                        ? $"Specjalizacja: {result}"
                        : "Brak danych w tabeli lekarzy");
                }
            }

            return sb.ToString();
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
                var query = @"INSERT INTO Doctors (UserId, Imie, Nazwisko, Specjalizacja)
                      VALUES (@UserId, @Imie, @Nazwisko, @Specjalizacja)";
                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
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

        public void UsunLekarza(int doctorId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var command = new MySqlCommand("DELETE FROM Doctors WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", doctorId);
                command.ExecuteNonQuery();
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
                            "DELETE FROM users",
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

        // TODO: Dawid Kotliński: Powinno przyjmować argument DateTime.
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

        //domyślnie funkcje takie jak reader.GetString czy reader.GetDateTime nie obsługują wartości NULL — jeśli kolumna zawiera NULL, dostajesz wyjątek, dlatego sporawdzam znim pobiore czu wartosc jest DBNULL
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

        public void ZmienStatusWizyty(int wizytaId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var query = "UPDATE wizyty SET Status = 'Odbyta' WHERE Id = @WizytaId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@WizytaId", wizytaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Wizyta> PobierzWizytyPacjenta(int pacjentId)
        {
            var wizyty = new List<Wizyta>();

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var query = @"
            SELECT 
                w.Id, 
                w.DataWizyty, 
                CONCAT(d.Imie, ' ', d.Nazwisko) AS Lekarz, 
                w.Status, 
                w.Specjalizacja,
                w.Opis,
                w.Diagnoza,
                w.Zalecenia
            FROM wizyty w
            JOIN doctors d ON w.LekarzId = d.Id
            WHERE w.PacjentId = @PacjentId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@PacjentId", pacjentId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var wizyta = new Wizyta
                            {
                                Id = reader.GetInt32("Id"),
                                DataWizyty = reader.GetDateTime("DataWizyty"),
                                Lekarz = reader.IsDBNull(reader.GetOrdinal("Lekarz")) ? "" : reader.GetString("Lekarz"),
                                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? "" : reader.GetString("Status"),
                                Specjalizacja = reader.IsDBNull(reader.GetOrdinal("Specjalizacja")) ? "" : reader.GetString("Specjalizacja"),
                                Opis = reader.IsDBNull(reader.GetOrdinal("Opis")) ? "" : reader.GetString("Opis"),
                                Diagnoza = reader.IsDBNull(reader.GetOrdinal("Diagnoza")) ? "" : reader.GetString("Diagnoza"),
                                Zalecenia = reader.IsDBNull(reader.GetOrdinal("Zalecenia")) ? "" : reader.GetString("Zalecenia")
                            };
                            wizyty.Add(wizyta);
                        }
                    }
                }
            }

            return wizyty;
        }


        public int DodajPacjenta(Patient patient)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var query = @"INSERT INTO Users 
                      (Imie, Nazwisko, DateOfBirth, PESEL, Adres, Miasto, KodPocztowy, PhoneNumber, Email) 
                      VALUES (@Imie, @Nazwisko, @DateOfBirth, @PESEL, @Adres, @Miasto, @KodPocztowy, @PhoneNumber, @Email);
                      SELECT LAST_INSERT_ID();";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Imie", patient.Imie);
                    cmd.Parameters.AddWithValue("@Nazwisko", patient.Nazwisko);
                    cmd.Parameters.AddWithValue("@DateofBirth", patient.DateofBirth);
                    cmd.Parameters.AddWithValue("@PESEL", patient.PESEL);
                    cmd.Parameters.AddWithValue("@Adres", patient.Adres);
                    cmd.Parameters.AddWithValue("@Miasto", patient.Miasto);
                    cmd.Parameters.AddWithValue("@KodPocztowy", patient.KodPocztowy);
                    cmd.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", patient.Email);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }


        public void AktualizujPacjenta(Patient patient)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var query = @"UPDATE Users SET 
                        Imie = @Imie,
                        Nazwisko = @Nazwisko,
                        DateofBirth = @DateofBirth,
                        PESEL = @PESEL,
                        Adres = @Adres,
                        Miasto = @Miasto,
                        KodPocztowy = @KodPocztowy,
                        PhoneNumber = @PhoneNumber,
                        Email = @Email,
                        Haslo = @Haslo
                        WHERE Id = @Id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", patient.Id);
                    cmd.Parameters.AddWithValue("@Imie", patient.Imie);
                    cmd.Parameters.AddWithValue("@Nazwisko", patient.Nazwisko);
                    cmd.Parameters.AddWithValue("@DateofBirth", patient.DateofBirth);
                    cmd.Parameters.AddWithValue("@PESEL", patient.PESEL);
                    cmd.Parameters.AddWithValue("@Adres", patient.Adres);
                    cmd.Parameters.AddWithValue("@Miasto", patient.Miasto);
                    cmd.Parameters.AddWithValue("@KodPocztowy", patient.KodPocztowy);
                    cmd.Parameters.AddWithValue("@PhoneNumber", patient.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", patient.Email);
                    cmd.Parameters.AddWithValue("@Haslo", patient.Haslo);


                    cmd.ExecuteNonQuery();
                }
            }
        }


        

        public Patient PobierzDanePacjenta(int patientId)
        {
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var query = "SELECT * FROM Users WHERE Id = @Id AND Rola = 'Pacjent'";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", patientId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Patient
                            {
                                Id = reader.GetInt32("Id"),
                                Imie = reader.IsDBNull(reader.GetOrdinal("Imie")) ? null : reader.GetString("Imie"),
                                Nazwisko = reader.IsDBNull(reader.GetOrdinal("Nazwisko")) ? null : reader.GetString("Nazwisko"),
                                DateofBirth = reader.IsDBNull(reader.GetOrdinal("DateofBirth")) ? DateTime.MinValue : reader.GetDateTime("DateOfBirth"),
                                PESEL = reader.IsDBNull(reader.GetOrdinal("PESEL")) ? null : reader.GetString("PESEL"),
                                Adres = reader.IsDBNull(reader.GetOrdinal("Adres")) ? null : reader.GetString("Adres"),
                                Miasto = reader.IsDBNull(reader.GetOrdinal("Miasto")) ? null : reader.GetString("Miasto"),
                                KodPocztowy = reader.IsDBNull(reader.GetOrdinal("KodPocztowy")) ? null : reader.GetString("KodPocztowy"),
                                PhoneNumber = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? null : reader.GetString("PhoneNumber"),
                                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString("Email"),

                            };
                        }
                    }
                }
            }
            return null;
        }



        public List<Lekarz> PobierzDostepnychLekarzy()
        {
            var lekarze = new List<Lekarz>();

            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = @"SELECT d.Id, d.Imie, d.Nazwisko, d.Specjalizacja, d.UserId
                        FROM Doctors d
                        JOIN Users u ON d.UserId = u.Id
                        WHERE u.Rola = 'Lekarz'";

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
                                Specjalizacja = reader.IsDBNull(3) ? null : reader.GetString(3),
                                UserId = reader.GetInt32(4),
                            });
                        }
                    }
                }
            }

            return lekarze;
        }

        //TODO jak lekarz ma wolny termin to poakzuje lekarz nie ma wolnego terminu cos jest pokickane xD
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

                    int count = Convert.ToInt32(command.ExecuteScalar());
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
                SELECT LAST_INSERT_ID();";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@LekarzId", wizyta.LekarzId);
                    command.Parameters.AddWithValue("@PacjentId", wizyta.PacjentId);
                    command.Parameters.AddWithValue("@DataWizyty", wizyta.DataWizyty);
                    command.Parameters.AddWithValue("@Status", wizyta.Status ?? "Zaplanowana");
                    command.Parameters.AddWithValue("@Opis", string.IsNullOrEmpty(wizyta.Opis) ? (object)DBNull.Value : wizyta.Opis);
                    command.Parameters.AddWithValue("@Diagnoza", string.IsNullOrEmpty(wizyta.Diagnoza) ? (object)DBNull.Value : wizyta.Diagnoza);
                    command.Parameters.AddWithValue("@Zalecenia", string.IsNullOrEmpty(wizyta.Zalecenia) ? (object)DBNull.Value : wizyta.Zalecenia);
                    command.Parameters.AddWithValue("@Specjalizacja", string.IsNullOrEmpty(wizyta.Specjalizacja) ? (object)DBNull.Value : wizyta.Specjalizacja);


                    object result = command.ExecuteScalar();
                    return Convert.ToInt32(result);
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

        public void WystlijPowiadomienie(int pacjentId, string tresc)
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

    

        public DataTable PobierzWizytyDlaLekarza(int lekarzId, DateTime data)
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

        public List<string> PobierzSkierowaniaDlaWizyty(int wizytaId)
        {
            var wynik = new List<string>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Typ, Cel, Uwagi FROM skierowania WHERE WizytaId = @id";
                cmd.Parameters.AddWithValue("@id", wizytaId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string linia = $"Typ: {reader["Typ"]}, Cel: {reader["Cel"]}, Uwagi: {reader["Uwagi"]}";
                        wynik.Add(linia);
                    }
                }
            }
            return wynik;
        }


        public List<string> PobierzReceptyDlaWizyty(int wizytaId)
        {
            var wynik = new List<string>();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT KodRecepty, Leki, Uwagi FROM recepty WHERE WizytaId = @id";
                cmd.Parameters.AddWithValue("@id", wizytaId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string linia = $"Kod: {reader["KodRecepty"]}, Leki: {reader["Leki"]}, Uwagi: {reader["Uwagi"]}";
                        wynik.Add(linia);
                    }
                }
            }
            return wynik;
        }

        public void DodajOpinie(int pacjentId, int lekarzId, int ocena, string komentarz)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = @"
            INSERT INTO opinie (PacjentId, LekarzId, Ocena, Komentarz, DataDodania)
            VALUES (@pacjentId, @lekarzId, @ocena, @komentarz, @data)";
                cmd.Parameters.AddWithValue("@pacjentId", pacjentId);
                cmd.Parameters.AddWithValue("@lekarzId", lekarzId);
                cmd.Parameters.AddWithValue("@ocena", ocena);
                cmd.Parameters.AddWithValue("@komentarz", komentarz);
                cmd.Parameters.AddWithValue("@data", DateTime.Now);
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable PobierzLekarzy()
        {
            var dt = new DataTable();
            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT Id, Imie, Nazwisko, Specjalizacja FROM doctors";
                var adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            return dt;
        }


        public void ZapiszOpisIWyniki(int wizytaId, string opis, string diagnoza, string zalecenia)
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




        public void WystawSkierowanie(int wizytaId, int pacjentId, int lekarzId, string typ, string cel, string uwagi)
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

        public void ZmienEmail(int userId, string email)
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
        public void ZmienHaslo(int userId, string haslo)
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

