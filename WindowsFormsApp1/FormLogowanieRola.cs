using System;
using System.Windows.Forms;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class FormLogowanieRola : Form
    {
        private readonly DataBaseHelper _dbHelper;

       
        public FormLogowanieRola(DataBaseHelper dbHelper)
        {
            InitializeComponent();
            _dbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));
            this.FormClosed += new FormClosedEventHandler(FormLogowanieRola_FormClosed);


            comboBox1.Items.AddRange(new[] { "Pacjent", "Lekarz", "Administrator" });
            comboBox1.SelectedIndex = 0;
        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Proszę wybrać rolę!", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string wybranaRola = comboBox1.SelectedItem.ToString();

            
            this.Hide();

            try
            {
                switch (wybranaRola)
                {
                    case "Pacjent":
                        var formPacjent = new FormLogowaniePacjent(_dbHelper);
                        formPacjent.Closed += (s, args) => this.Close();
                        formPacjent.Show();
                        break;

                    case "Lekarz":
                        var formLekarz = new FormLogowanieLekarz(_dbHelper);
                        formLekarz.Closed += (s, args) => this.Close();
                        formLekarz.Show();
                        break;

                    case "Administrator":
                        var formAdmin = new FormLogowanieAdmin(_dbHelper);
                        formAdmin.Closed += (s, args) => this.Close();
                        formAdmin.Show();
                        break;

                    default:
                        MessageBox.Show("Nieznana rola!", "Błąd",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Show();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Błąd podczas otwierania formularza: {ex.Message}", "Błąd",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show(); 
            }
        }

        private void buttonAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogowanieRola_Load(object sender, EventArgs e)
        {

        }

        private void FormLogowanieRola_Validated(object sender, EventArgs e)
        {

        }

        private void FormLogowanieRola_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit(); 
        }
    }
}