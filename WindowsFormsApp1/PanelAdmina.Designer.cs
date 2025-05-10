namespace WindowsFormsApp1
{
    partial class PanelAdmina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonWyswierlLekarzy = new System.Windows.Forms.Button();
            this.buttonWyswietlPacjentow = new System.Windows.Forms.Button();
            this.buttonNadajUprawienia = new System.Windows.Forms.Button();
            this.buttonZabierzUprawnienia = new System.Windows.Forms.Button();
            this.buttonUsunRekordy = new System.Windows.Forms.Button();
            this.buttonDodajLekarza = new System.Windows.Forms.Button();
            this.buttonFormDodaniaLekarza = new System.Windows.Forms.Button();
            this.buttonUsunWszystko = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.WylogujAdmin = new System.Windows.Forms.Button();
            this.buttonPokaz = new System.Windows.Forms.Button();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.textBoxSpecjalizacja = new System.Windows.Forms.TextBox();
            this.radioButtonLekarze = new System.Windows.Forms.RadioButton();
            this.radioButtonPacjenci = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxHaslo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSpecjalizacjaUprawnienia = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWyswierlLekarzy
            // 
            this.buttonWyswierlLekarzy.Location = new System.Drawing.Point(12, 12);
            this.buttonWyswierlLekarzy.Name = "buttonWyswierlLekarzy";
            this.buttonWyswierlLekarzy.Size = new System.Drawing.Size(127, 48);
            this.buttonWyswierlLekarzy.TabIndex = 0;
            this.buttonWyswierlLekarzy.Text = "Wyswietl Lekarzy";
            this.buttonWyswierlLekarzy.UseVisualStyleBackColor = true;
            this.buttonWyswierlLekarzy.Click += new System.EventHandler(this.buttonWyswierlLekarzy_Click);
            // 
            // buttonWyswietlPacjentow
            // 
            this.buttonWyswietlPacjentow.Location = new System.Drawing.Point(12, 66);
            this.buttonWyswietlPacjentow.Name = "buttonWyswietlPacjentow";
            this.buttonWyswietlPacjentow.Size = new System.Drawing.Size(127, 48);
            this.buttonWyswietlPacjentow.TabIndex = 1;
            this.buttonWyswietlPacjentow.Text = "Wyświetl Pacjentow";
            this.buttonWyswietlPacjentow.UseVisualStyleBackColor = true;
            this.buttonWyswietlPacjentow.Click += new System.EventHandler(this.buttonWyswietlPacjentow_Click);
            // 
            // buttonNadajUprawienia
            // 
            this.buttonNadajUprawienia.Location = new System.Drawing.Point(12, 120);
            this.buttonNadajUprawienia.Name = "buttonNadajUprawienia";
            this.buttonNadajUprawienia.Size = new System.Drawing.Size(127, 48);
            this.buttonNadajUprawienia.TabIndex = 2;
            this.buttonNadajUprawienia.Text = "Nadaj Uprawnienia";
            this.buttonNadajUprawienia.UseVisualStyleBackColor = true;
            this.buttonNadajUprawienia.Click += new System.EventHandler(this.buttonNadajUprawienia_Click);
            // 
            // buttonZabierzUprawnienia
            // 
            this.buttonZabierzUprawnienia.Location = new System.Drawing.Point(12, 174);
            this.buttonZabierzUprawnienia.Name = "buttonZabierzUprawnienia";
            this.buttonZabierzUprawnienia.Size = new System.Drawing.Size(127, 48);
            this.buttonZabierzUprawnienia.TabIndex = 3;
            this.buttonZabierzUprawnienia.Text = "Zabierz Uprawnienia";
            this.buttonZabierzUprawnienia.UseVisualStyleBackColor = true;
            this.buttonZabierzUprawnienia.Click += new System.EventHandler(this.buttonZabierzUprawnienia_Click);
            // 
            // buttonUsunRekordy
            // 
            this.buttonUsunRekordy.Location = new System.Drawing.Point(12, 228);
            this.buttonUsunRekordy.Name = "buttonUsunRekordy";
            this.buttonUsunRekordy.Size = new System.Drawing.Size(127, 48);
            this.buttonUsunRekordy.TabIndex = 4;
            this.buttonUsunRekordy.Text = "Usun Uzytkownika";
            this.buttonUsunRekordy.UseVisualStyleBackColor = true;
            this.buttonUsunRekordy.Click += new System.EventHandler(this.buttonUsunRekordy_Click);
            // 
            // buttonDodajLekarza
            // 
            this.buttonDodajLekarza.Location = new System.Drawing.Point(672, 383);
            this.buttonDodajLekarza.Name = "buttonDodajLekarza";
            this.buttonDodajLekarza.Size = new System.Drawing.Size(127, 48);
            this.buttonDodajLekarza.TabIndex = 5;
            this.buttonDodajLekarza.Text = "Dodaj Lekarza";
            this.buttonDodajLekarza.UseVisualStyleBackColor = true;
            this.buttonDodajLekarza.Click += new System.EventHandler(this.buttonDodajLekarza_Click);
            // 
            // buttonFormDodaniaLekarza
            // 
            this.buttonFormDodaniaLekarza.Location = new System.Drawing.Point(12, 282);
            this.buttonFormDodaniaLekarza.Name = "buttonFormDodaniaLekarza";
            this.buttonFormDodaniaLekarza.Size = new System.Drawing.Size(127, 48);
            this.buttonFormDodaniaLekarza.TabIndex = 6;
            this.buttonFormDodaniaLekarza.Text = "Formularz dodania Lekarza";
            this.buttonFormDodaniaLekarza.UseVisualStyleBackColor = true;
            this.buttonFormDodaniaLekarza.Click += new System.EventHandler(this.buttonFormDodaniaLekarza_Click);
            // 
            // buttonUsunWszystko
            // 
            this.buttonUsunWszystko.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUsunWszystko.Location = new System.Drawing.Point(12, 347);
            this.buttonUsunWszystko.Name = "buttonUsunWszystko";
            this.buttonUsunWszystko.Size = new System.Drawing.Size(127, 48);
            this.buttonUsunWszystko.TabIndex = 7;
            this.buttonUsunWszystko.Text = "Usun wszystko z bazy";
            this.buttonUsunWszystko.UseVisualStyleBackColor = true;
            this.buttonUsunWszystko.Click += new System.EventHandler(this.buttonUsunWszystko_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(152, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(409, 405);
            this.dataGridView1.TabIndex = 14;
            // 
            // WylogujAdmin
            // 
            this.WylogujAdmin.Location = new System.Drawing.Point(1367, 12);
            this.WylogujAdmin.Name = "WylogujAdmin";
            this.WylogujAdmin.Size = new System.Drawing.Size(117, 48);
            this.WylogujAdmin.TabIndex = 15;
            this.WylogujAdmin.Text = "Wyloguj";
            this.WylogujAdmin.UseVisualStyleBackColor = true;
            this.WylogujAdmin.Click += new System.EventHandler(this.WylogujAdmin_Click);
            // 
            // buttonPokaz
            // 
            this.buttonPokaz.Location = new System.Drawing.Point(631, 22);
            this.buttonPokaz.Name = "buttonPokaz";
            this.buttonPokaz.Size = new System.Drawing.Size(59, 29);
            this.buttonPokaz.TabIndex = 16;
            this.buttonPokaz.Text = "Pokaż";
            this.buttonPokaz.UseVisualStyleBackColor = true;
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(671, 241);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(128, 20);
            this.textBoxImie.TabIndex = 19;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(671, 267);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(128, 20);
            this.textBoxNazwisko.TabIndex = 20;
            // 
            // textBoxSpecjalizacja
            // 
            this.textBoxSpecjalizacja.Location = new System.Drawing.Point(671, 293);
            this.textBoxSpecjalizacja.Name = "textBoxSpecjalizacja";
            this.textBoxSpecjalizacja.Size = new System.Drawing.Size(128, 20);
            this.textBoxSpecjalizacja.TabIndex = 21;
            // 
            // radioButtonLekarze
            // 
            this.radioButtonLekarze.AutoSize = true;
            this.radioButtonLekarze.Location = new System.Drawing.Point(621, 97);
            this.radioButtonLekarze.Name = "radioButtonLekarze";
            this.radioButtonLekarze.Size = new System.Drawing.Size(63, 17);
            this.radioButtonLekarze.TabIndex = 22;
            this.radioButtonLekarze.TabStop = true;
            this.radioButtonLekarze.Text = "Lekarze";
            this.radioButtonLekarze.UseVisualStyleBackColor = true;
            // 
            // radioButtonPacjenci
            // 
            this.radioButtonPacjenci.AutoSize = true;
            this.radioButtonPacjenci.Location = new System.Drawing.Point(621, 128);
            this.radioButtonPacjenci.Name = "radioButtonPacjenci";
            this.radioButtonPacjenci.Size = new System.Drawing.Size(66, 17);
            this.radioButtonPacjenci.TabIndex = 23;
            this.radioButtonPacjenci.TabStop = true;
            this.radioButtonPacjenci.Text = "Pacjenci";
            this.radioButtonPacjenci.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(607, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "IMIE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(607, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "NAZWISKO";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(576, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "SPECJALIZACJA";
            // 
            // textBoxHaslo
            // 
            this.textBoxHaslo.Location = new System.Drawing.Point(671, 347);
            this.textBoxHaslo.Name = "textBoxHaslo";
            this.textBoxHaslo.Size = new System.Drawing.Size(128, 20);
            this.textBoxHaslo.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(618, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "HASLO";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(671, 321);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(128, 20);
            this.textBoxEmail.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(618, 328);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Email";
            // 
            // textBoxSpecjalizacjaUprawnienia
            // 
            this.textBoxSpecjalizacjaUprawnienia.Location = new System.Drawing.Point(490, 441);
            this.textBoxSpecjalizacjaUprawnienia.Name = "textBoxSpecjalizacjaUprawnienia";
            this.textBoxSpecjalizacjaUprawnienia.Size = new System.Drawing.Size(160, 20);
            this.textBoxSpecjalizacjaUprawnienia.TabIndex = 32;
            // 
            // PanelAdmina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 477);
            this.Controls.Add(this.textBoxSpecjalizacjaUprawnienia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxHaslo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButtonPacjenci);
            this.Controls.Add(this.radioButtonLekarze);
            this.Controls.Add(this.textBoxSpecjalizacja);
            this.Controls.Add(this.textBoxNazwisko);
            this.Controls.Add(this.textBoxImie);
            this.Controls.Add(this.buttonPokaz);
            this.Controls.Add(this.WylogujAdmin);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonUsunWszystko);
            this.Controls.Add(this.buttonFormDodaniaLekarza);
            this.Controls.Add(this.buttonDodajLekarza);
            this.Controls.Add(this.buttonUsunRekordy);
            this.Controls.Add(this.buttonZabierzUprawnienia);
            this.Controls.Add(this.buttonNadajUprawienia);
            this.Controls.Add(this.buttonWyswietlPacjentow);
            this.Controls.Add(this.buttonWyswierlLekarzy);
            this.Name = "PanelAdmina";
            this.Text = "PanelAdmina";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonWyswierlLekarzy;
        private System.Windows.Forms.Button buttonWyswietlPacjentow;
        private System.Windows.Forms.Button buttonNadajUprawienia;
        private System.Windows.Forms.Button buttonZabierzUprawnienia;
        private System.Windows.Forms.Button buttonUsunRekordy;
        private System.Windows.Forms.Button buttonDodajLekarza;
        private System.Windows.Forms.Button buttonFormDodaniaLekarza;
        private System.Windows.Forms.Button buttonUsunWszystko;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button WylogujAdmin;
        private System.Windows.Forms.Button buttonPokaz;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.TextBox textBoxSpecjalizacja;
        private System.Windows.Forms.RadioButton radioButtonLekarze;
        private System.Windows.Forms.RadioButton radioButtonPacjenci;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxHaslo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSpecjalizacjaUprawnienia;
    }
}