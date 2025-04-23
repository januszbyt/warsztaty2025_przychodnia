using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Skierowanie
    {
        public int Id { get; set; }
        public int WizytaId { get; set; }
        public int PacjentId { get; set; }
        public int LekarzId { get; set; }
        public DateTime DataWystawienia { get; set; }
        public string Typ { get; set; }
        public string Cel { get; set; }
        public string Uwagi { get; set; }
    }
}
