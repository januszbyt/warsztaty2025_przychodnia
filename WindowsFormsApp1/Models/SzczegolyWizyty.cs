using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class SzczegolyWizyty
    {
        public int Id { get; set; }
        public int PacjentId { get; set; }
        public string Opis { get; set; }
        public string Diagnoza { get; set; }
        public string Zalecenia { get; set; }
    }
}
