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
    public partial class FormLogowanieRola : Form
    {
        public FormLogowanieRola()
        {
            InitializeComponent();

            comboBox1.Items.Add("Pacjent");
            comboBox1.Items.Add("Lekarz");
            comboBox1.Items.Add("Administrator");
            comboBox1.SelectedIndex = 0;
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex == 0)
            {
                MessageBox.Show("Wybrano Pacjenta");
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("Wybrano Lekarza");
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                MessageBox.Show("Wybrano Administratora");
            }

        }

        private void buttonZatwierdz_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null) {
                MessageBox.Show("Proszę wybrać role!", "Blad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string wybranaRola = comboBox1.SelectedItem.ToString();

            switch (wybranaRola)
            {
                case "Pacjent":
                    Form panelPacjenta = new FormLogowaniePacjent();
                    panelPacjenta.Show();
                    this.Hide(); // Opcjonalnie ukrywamy bieżące okno
                    break;

                case "Lekarz":
                    Form panelLekarza = new FormLogowanieLekarz(); 
                    panelLekarza.Show();
                    this.Hide();
                    break;

                case "Administrator":
                    Form panelAdmina = new FormLogowanieAdmin(); 
                    panelAdmina.Show();
                    this.Hide();
                    break;

                default:
                    MessageBox.Show("Nieznana rola!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
