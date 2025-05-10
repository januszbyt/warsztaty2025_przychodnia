using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Wizyta
    {
        public int Id { get; set; }
        public int LekarzId { get; set; }
        public int PacjentId { get; set; }
        public DateTime DataWizyty { get; set; }
        public string Status { get; set; }
        public string Opis { get; set; }
        public string Diagnoza { get; set; }
        public string Zalecenia { get; set; }
        public string Specjalizacja { get; set; }

        public string Lekarz { get; set; }
    }
}
