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
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(189, 178);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(132, 22);
            this.textBoxEmail.TabIndex = 0;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(189, 139);
            this.textBoxNazwisko.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(132, 22);
            this.textBoxNazwisko.TabIndex = 1;
            // 
            // textBoxHaslo
            // 
            this.textBoxHaslo.Location = new System.Drawing.Point(189, 218);
            this.textBoxHaslo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHaslo.Name = "textBoxHaslo";
            this.textBoxHaslo.Size = new System.Drawing.Size(132, 22);
            this.textBoxHaslo.TabIndex = 2;
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.Location = new System.Drawing.Point(189, 264);
            this.textBoxTelefon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(132, 22);
            this.textBoxTelefon.TabIndex = 3;
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(189, 98);
            this.textBoxImie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(132, 22);
            this.textBoxImie.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(41, 101);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Imię";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(39, 139);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nazwisko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(41, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "E-mail";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(41, 218);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Hasło";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(39, 260);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 25);
            this.label5.TabIndex = 9;
            this.label5.Text = "Numer Tel.";
            // 
            // buttonLogowanie
            // 
            this.buttonLogowanie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonLogowanie.Location = new System.Drawing.Point(445, 87);
            this.buttonLogowanie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLogowanie.Name = "buttonLogowanie";
            this.buttonLogowanie.Size = new System.Drawing.Size(160, 39);
            this.buttonLogowanie.TabIndex = 10;
            this.buttonLogowanie.Text = "Zaloguj";
            this.buttonLogowanie.UseVisualStyleBackColor = true;
            this.buttonLogowanie.Click += new System.EventHandler(this.buttonLogowanie_Click);
            // 
            // buttonRejestruj
            // 
            this.buttonRejestruj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonRejestruj.Location = new System.Drawing.Point(280, 549);
            this.buttonRejestruj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonRejestruj.Name = "buttonRejestruj";
            this.buttonRejestruj.Size = new System.Drawing.Size(139, 40);
            this.buttonRejestruj.TabIndex = 12;
            this.buttonRejestruj.Text = "OK";
            this.buttonRejestruj.UseVisualStyleBackColor = true;
            this.buttonRejestruj.Click += new System.EventHandler(this.buttonRejestruj_Click_1);
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.Location = new System.Drawing.Point(189, 304);
            this.textBoxPesel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(132, 22);
            this.textBoxPesel.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(39, 306);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Pesel";
            // 
            // dtp_DataUrodzenia
            // 
            this.dtp_DataUrodzenia.Location = new System.Drawing.Point(235, 478);
            this.dtp_DataUrodzenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_DataUrodzenia.Name = "dtp_DataUrodzenia";
            this.dtp_DataUrodzenia.Size = new System.Drawing.Size(252, 22);
            this.dtp_DataUrodzenia.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(39, 475);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(144, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Data urodzenia";
            // 
            // comboBoxRola
            // 
            this.comboBoxRola.FormattingEnabled = true;
            this.comboBoxRola.Location = new System.Drawing.Point(445, 168);
            this.comboBoxRola.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxRola.Name = "comboBoxRola";
            this.comboBoxRola.Size = new System.Drawing.Size(160, 24);
            this.comboBoxRola.TabIndex = 17;
            // 
            // Adres
            // 
            this.Adres.AutoSize = true;
            this.Adres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Adres.Location = new System.Drawing.Point(39, 344);
            this.Adres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Adres.Name = "Adres";
            this.Adres.Size = new System.Drawing.Size(64, 25);
            this.Adres.TabIndex = 18;
            this.Adres.Text = "Adres";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(39, 383);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "Miasto";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(39, 424);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(137, 25);
            this.label10.TabIndex = 20;
            this.label10.Text = "Kod Pocztowy";
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Location = new System.Drawing.Point(189, 344);
            this.textBoxAdres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(132, 22);
            this.textBoxAdres.TabIndex = 21;
            // 
            // textBoxMiasto
            // 
            this.textBoxMiasto.Location = new System.Drawing.Point(189, 383);
            this.textBoxMiasto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMiasto.Name = "textBoxMiasto";
            this.textBoxMiasto.Size = new System.Drawing.Size(132, 22);
            this.textBoxMiasto.TabIndex = 22;
            // 
            // textBoxKodPocztowy
            // 
            this.textBoxKodPocztowy.Location = new System.Drawing.Point(189, 424);
            this.textBoxKodPocztowy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxKodPocztowy.Name = "textBoxKodPocztowy";
            this.textBoxKodPocztowy.Size = new System.Drawing.Size(132, 22);
            this.textBoxKodPocztowy.TabIndex = 23;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(137, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(377, 64);
            this.label8.TabIndex = 24;
            this.label8.Text = "Rejestracja do Przychodni \r\n               Witamy ";
            // 
            // FormRejestracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 602);
            this.Controls.Add(this.label8);
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
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormRejestracja";
            this.Text = "FormRejestracja";
            this.Load += new System.EventHandler(this.FormRejestracja_Load);
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
        private System.Windows.Forms.Label label8;
    }
}