using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class PanelLekarza : Form
    {
        private List<Pacjent> pacjenci = new List<Pacjent>{
        new Pacjent { Id = 1, Imie = "Jan", Nazwisko = "Kowalski", Pesel = "12345678901" },
        new Pacjent { Id = 2, Imie = "Anna", Nazwisko = "Nowak", Pesel = "23456789012" },
        new Pacjent { Id = 3, Imie = "Piotr", Nazwisko = "Wiśniewski", Pesel = "34567890123" }
        };

        public PanelLekarza()
        {
            InitializeComponent();
            InitializeDataGridView();
            
            dataGridView1.Visible = false;
            txtSzukaj.Visible = false;

            
            btnPacjenci.Click+= btnPacjenci_Click_1;
            buttonWizyty.Click += buttonWizyty_Click;
            txtSzukaj.TextChanged += TxtSzukaj_TextChanged;
        }

       

        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
            FormLogowanieLekarz logowanielekarz = new FormLogowanieLekarz();
            logowanielekarz.Show();
            this.Hide();

        }

        private void buttonWizyty_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            txtSzukaj.Visible = false;

            dataGridView1.Visible = !dataGridView1.Visible;
            if (dataGridView1.Visible)
            {
                LoadAppointments();
            }

        }
        private void btnPacjenci_Click_1(object sender, EventArgs e)
        {
            bool showPatients = !dataGridView1.Visible;

            dataGridView1.Visible = showPatients;
            txtSzukaj.Visible = showPatients;

            if (showPatients)
            {
                LoadPacjenci();
            }
        }


        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Add("Data", "Data");
            dataGridView1.Columns.Add("Pacjent", "Pacjent");

           
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "Szczegóły";
            buttonColumn.Text = "Pokaż";
            buttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Add(buttonColumn);

           
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private void LoadAppointments()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Data", "Data");
            dataGridView1.Columns.Add("Pacjent", "Pacjent");
            dataGridView1.Rows.Add("30.01.2025", "Jan Kowalski");
            
        }
        

        private void LoadPacjenci(string filtr = "")
        {
            dataGridView1.Rows.Clear();

            var wynik = string.IsNullOrEmpty(filtr)
        ? pacjenci
        : pacjenci.Where(p =>
            p.Imie.IndexOf(filtr, StringComparison.OrdinalIgnoreCase) >= 0 ||
            p.Nazwisko.IndexOf(filtr, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            foreach (var pacjent in wynik)
            {
                dataGridView1.Rows.Add(
                    pacjent.Id,
                    pacjent.Imie,
                    pacjent.Nazwisko,
                    pacjent.Pesel
                );
            }
        }

        private void TxtSzukaj_TextChanged(object sender, EventArgs e)
        {
            LoadPacjenci(txtSzukaj.Text);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Szczegóły"].Index && e.RowIndex >= 0)
            {
                string data = dataGridView1.Rows[e.RowIndex].Cells["Data"].Value.ToString();
                string pacjent = dataGridView1.Rows[e.RowIndex].Cells["Pacjent"].Value.ToString();

                MessageBox.Show($"Wizyta: {data}\nPacjent: {pacjent}", "Szczegóły");
            }

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
                var pacjent = pacjenci.FirstOrDefault(p => p.Id == id);

                MessageBox.Show($"ID: {pacjent.Id}\nImię: {pacjent.Imie}\nNazwisko: {pacjent.Nazwisko}",
                              "Szczegóły pacjenta");
            }
        }
    }

        public class Pacjent{
            public int Id { get; set; }
            public string Nazwisko { get; set; }
            public string Pesel { get; set; }
            public string Imie { get; set; }
        } 
}
