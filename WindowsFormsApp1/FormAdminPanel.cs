using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class FormPanelAdmin : Form
    {
        public FormPanelAdmin()
        {
            InitializeComponent(); 
        }

        
        private void buttonZarzadzajLekarzami_Click(object sender, EventArgs e)
        {
            
            FormZarzadzajLekarzami formLekarze = new FormZarzadzajLekarzami();
            formLekarze.ShowDialog();
        }

        
        private void buttonZarzadzajPacjentami_Click(object sender, EventArgs e)
        {
            
            FormZarzadzajPacjentami formPacjenci = new FormZarzadzajPacjentami();
            formPacjenci.ShowDialog();
        }

        
        private void buttonWyloguj_Click(object sender, EventArgs e)
        {
           

            
            FormLogowanieAdmin formLogin = new FormLogowanieAdmin(); 
            formLogin.Show();
            this.Close(); 
        }

        private void FormPanelAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
