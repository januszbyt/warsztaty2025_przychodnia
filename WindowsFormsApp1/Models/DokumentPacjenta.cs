using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class DokumentPacjenta
    {
        public int Id { get; set; }
        public int PacjentId { get; set; }
        public DateTime DataDodania { get; set; }
        public string Typ { get; set; }
        public string Uwagi { get; set; }
        public string SciezkaPliku { get; set; }
    }

}
