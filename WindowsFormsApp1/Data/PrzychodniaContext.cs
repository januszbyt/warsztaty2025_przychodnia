using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.Entity;
using System.Numerics;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Data
{
 

    public class PrzychodniaContext : DbContext
    {
        public PrzychodniaContext() : base("name=DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Lekarz> Doctors { get; set; }
        public DbSet<Wizyta> Wizyty { get; set; }
        public DbSet<Recepta> Recepty { get; set; }
        public DbSet<Skierowanie> Skierowania { get; set; }
        public DbSet<DokumentPacjenta> DokumentyPacjenta { get; set; }
        public DbSet<Role> UserRoles { get; set; }
    }

}
