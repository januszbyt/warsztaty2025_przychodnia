using System;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        public string PESEL { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }

        public string Adres { get; set; }
        public string Miasto { get; set; }
        public string KodPocztowy { get; set; }
        public Role Rola { get; set; }
        
    }
}


