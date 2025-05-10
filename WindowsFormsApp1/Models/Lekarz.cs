using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Lekarz
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Specjalizacja { get; set; }
        // public Users User { get; set; }

    }

}
