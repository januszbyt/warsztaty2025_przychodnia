using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace WindowsFormsApp1
{
    static class Program
    {
        static SqlConnection db;

        [STAThread]
        static void Main()
        {
            var connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            db = new SqlConnection(connectString);
            db.Open();
            //W jakim formacie jest Baza danych?
            //Jaką ma Nazwę?

            // var createTables = true; // Odkomentowac zeby stworzyc tablice w bazie, jesli ich nie ma obecnie.

            //if (createTables)
            //{
            //    var queryPath = "Resources/baza.txt";
            //    var query = File.ReadAllText(queryPath);
            //    var cmd = new SqlCommand(query, db);
            //    cmd.ExecuteNonQuery();
            //}

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new PanelLekarza());
           
        }
    }

}
