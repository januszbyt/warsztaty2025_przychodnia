namespace WindowsFormsApp1.Forms
{
    partial class FormRejestracja
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
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.textBoxHaslo = new System.Windows.Forms.TextBox();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonLogowanie = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonRejestruj = new System.Windows.Forms.Button();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_DataUrodzenia = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxRola = new System.Windows.Forms.ComboBox();
            this.Adres = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxAdres = new System.Windows.Forms.TextBox();
            this.textBoxMiasto = new System.Windows.Forms.TextBox();
            this.textBoxKodPocztowy = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(98, 141);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(100, 20);
            this.textBoxEmail.TabIndex = 0;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(98, 115);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(100, 20);
            this.textBoxNazwisko.TabIndex = 1;
            // 
            // textBoxHaslo
            // 
            this.textBoxHaslo.Location = new System.Drawing.Point(98, 169);
            this.textBoxHaslo.Name = "textBoxHaslo";
            this.textBoxHaslo.Size = new System.Drawing.Size(100, 20);
            this.textBoxHaslo.TabIndex = 2;
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.Location = new System.Drawing.Point(98, 195);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(100, 20);
            this.textBoxTelefon.TabIndex = 3;
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(98, 89);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(100, 20);
            this.textBoxImie.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Imie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nazwisko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "haslo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 202);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "nr Tel";
            // 
            // buttonLogowanie
            // 
            this.buttonLogowanie.Location = new System.Drawing.Point(320, 12);
            this.buttonLogowanie.Name = "buttonLogowanie";
            this.buttonLogowanie.Size = new System.Drawing.Size(75, 23);
            this.buttonLogowanie.TabIndex = 10;
            this.buttonLogowanie.Text = "Logowanie";
            this.buttonLogowanie.UseVisualStyleBackColor = true;
            this.buttonLogowanie.Click += new System.EventHandler(this.buttonLogowanie_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(401, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Rejestracja";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // buttonRejestruj
            // 
            this.buttonRejestruj.Location = new System.Drawing.Point(123, 360);
            this.buttonRejestruj.Name = "buttonRejestruj";
            this.buttonRejestruj.Size = new System.Drawing.Size(75, 23);
            this.buttonRejestruj.TabIndex = 12;
            this.buttonRejestruj.Text = "OK";
            this.buttonRejestruj.UseVisualStyleBackColor = true;
            this.buttonRejestruj.Click += new System.EventHandler(this.buttonRejestruj_Click_1);
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.Location = new System.Drawing.Point(98, 221);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(100, 20);
            this.textBoxPesel.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Pesel";
            // 
            // dtp_DataUrodzenia
            // 
            this.dtp_DataUrodzenia.Location = new System.Drawing.Point(98, 334);
            this.dtp_DataUrodzenia.Name = "dtp_DataUrodzenia";
            this.dtp_DataUrodzenia.Size = new System.Drawing.Size(200, 20);
            this.dtp_DataUrodzenia.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 334);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Data urodzenia";
            // 
            // comboBoxRola
            // 
            this.comboBoxRola.FormattingEnabled = true;
            this.comboBoxRola.Location = new System.Drawing.Point(299, 168);
            this.comboBoxRola.Name = "comboBoxRola";
            this.comboBoxRola.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRola.TabIndex = 17;
            // 
            // Adres
            // 
            this.Adres.AutoSize = true;
            this.Adres.Location = new System.Drawing.Point(59, 251);
            this.Adres.Name = "Adres";
            this.Adres.Size = new System.Drawing.Size(34, 13);
            this.Adres.TabIndex = 18;
            this.Adres.Text = "Adres";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 277);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Miasto";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(57, 299);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "KodPocztowy";
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Location = new System.Drawing.Point(99, 248);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(100, 20);
            this.textBoxAdres.TabIndex = 21;
            // 
            // textBoxMiasto
            // 
            this.textBoxMiasto.Location = new System.Drawing.Point(103, 274);
            this.textBoxMiasto.Name = "textBoxMiasto";
            this.textBoxMiasto.Size = new System.Drawing.Size(100, 20);
            this.textBoxMiasto.TabIndex = 22;
            // 
            // textBoxKodPocztowy
            // 
            this.textBoxKodPocztowy.Location = new System.Drawing.Point(135, 300);
            this.textBoxKodPocztowy.Name = "textBoxKodPocztowy";
            this.textBoxKodPocztowy.Size = new System.Drawing.Size(100, 20);
            this.textBoxKodPocztowy.TabIndex = 23;
            // 
            // FormRejestracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 450);
            this.Controls.Add(this.textBoxKodPocztowy);
            this.Controls.Add(this.textBoxMiasto);
            this.Controls.Add(this.textBoxAdres);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Adres);
            this.Controls.Add(this.comboBoxRola);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtp_DataUrodzenia);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxPesel);
            this.Controls.Add(this.buttonRejestruj);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonLogowanie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxImie);
            this.Controls.Add(this.textBoxTelefon);
            this.Controls.Add(this.textBoxHaslo);
            this.Controls.Add(this.textBoxNazwisko);
            this.Controls.Add(this.textBoxEmail);
            this.Name = "FormRejestracja";
            this.Text = "FormRejestracja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.TextBox textBoxHaslo;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonLogowanie;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonRejestruj;
        private System.Windows.Forms.TextBox textBoxPesel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_DataUrodzenia;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxRola;
        private System.Windows.Forms.Label Adres;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxAdres;
        private System.Windows.Forms.TextBox textBoxMiasto;
        private System.Windows.Forms.TextBox textBoxKodPocztowy;
    }
}