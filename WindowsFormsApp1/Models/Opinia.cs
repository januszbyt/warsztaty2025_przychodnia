using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Models
{
    public class Opinia
    {
        public int Ocena { get; set; }
        public string Komentarz { get; set; }
        public DateTime DataDodania { get; set; }
        public string ImiePacjenta { get; set; }
        public string NazwiskoPacjenta { get; set; }

        public override string ToString()
        {
            return $"{DataDodania:yyyy-MM-dd} - {ImiePacjenta} {NazwiskoPacjenta} - Ocena: {Ocena}/5\nKomentarz: {Komentarz}\n";
        }
    }
}
