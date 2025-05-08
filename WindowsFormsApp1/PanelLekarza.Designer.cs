namespace WindowsFormsApp1
{
    partial class PanelLekarza
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelLekarzId = new System.Windows.Forms.Label();
            this.labelLekarzImieNazwisko = new System.Windows.Forms.Label();
            this.labelSpecjalizacja = new System.Windows.Forms.Label();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.txtSzukajPacjenta = new System.Windows.Forms.TextBox();
            this.txtSkierowanie = new System.Windows.Forms.TextBox();
            this.txtRecepta = new System.Windows.Forms.TextBox();
            this.btnRecepta = new System.Windows.Forms.Button();
            this.btnZapisz = new System.Windows.Forms.Button();
            this.btnSkierowanie = new System.Windows.Forms.Button();
            this.btnSzukaj = new System.Windows.Forms.Button();
            this.txtZalecenia = new System.Windows.Forms.TextBox();
            this.buttonPokazPacjentow = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageWizyty = new System.Windows.Forms.TabPage();
            this.dataGridViewWizyty = new System.Windows.Forms.DataGridView();
            this.tabPagePacjenci = new System.Windows.Forms.TabPage();
            this.tabPageEdycjaWizyty = new System.Windows.Forms.TabPage();
            this.buttonpokapacjentow = new System.Windows.Forms.Button();
            this.buttonZatwierdzSkierowanie = new System.Windows.Forms.Button();
            this.buttonZatwierdzRecepte = new System.Windows.Forms.Button();
            this.dataGridViewPacjenci = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Recepta = new System.Windows.Forms.Label();
            this.OPIS = new System.Windows.Forms.Label();
            this.tabPageZlecenia = new System.Windows.Forms.TabPage();
            this.tabPagePowiadomienia = new System.Windows.Forms.TabPage();
            this.tabPageUstawienia = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonZmienHaslo = new System.Windows.Forms.Button();
            this.txtHaslo = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageWizyty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWizyty)).BeginInit();
            this.tabPagePacjenci.SuspendLayout();
            this.tabPageEdycjaWizyty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacjenci)).BeginInit();
            this.tabPageUstawienia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.imagebadge;
            this.pictureBox1.Location = new System.Drawing.Point(32, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(311, 254);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // labelLekarzId
            // 
            this.labelLekarzId.AutoSize = true;
            this.labelLekarzId.Location = new System.Drawing.Point(39, 290);
            this.labelLekarzId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLekarzId.Name = "labelLekarzId";
            this.labelLekarzId.Size = new System.Drawing.Size(23, 16);
            this.labelLekarzId.TabIndex = 1;
            this.labelLekarzId.Text = "ID:";
            // 
            // labelLekarzImieNazwisko
            // 
            this.labelLekarzImieNazwisko.AutoSize = true;
            this.labelLekarzImieNazwisko.Location = new System.Drawing.Point(39, 318);
            this.labelLekarzImieNazwisko.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLekarzImieNazwisko.Name = "labelLekarzImieNazwisko";
            this.labelLekarzImieNazwisko.Size = new System.Drawing.Size(150, 16);
            this.labelLekarzImieNazwisko.TabIndex = 2;
            this.labelLekarzImieNazwisko.Text = "Imie i Nazwisko Lekarza";
            // 
            // labelSpecjalizacja
            // 
            this.labelSpecjalizacja.AutoSize = true;
            this.labelSpecjalizacja.Location = new System.Drawing.Point(39, 345);
            this.labelSpecjalizacja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSpecjalizacja.Name = "labelSpecjalizacja";
            this.labelSpecjalizacja.Size = new System.Drawing.Size(88, 16);
            this.labelSpecjalizacja.TabIndex = 3;
            this.labelSpecjalizacja.Text = "Specjalizacja";
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonWyloguj.Location = new System.Drawing.Point(971, 39);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(83, 32);
            this.buttonWyloguj.TabIndex = 9;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = false;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(1169, 183);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(265, 22);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(626, 40);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(12, 11, 12, 11);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 11;
            // 
            // txtSzukajPacjenta
            // 
            this.txtSzukajPacjenta.Location = new System.Drawing.Point(165, 27);
            this.txtSzukajPacjenta.Name = "txtSzukajPacjenta";
            this.txtSzukajPacjenta.Size = new System.Drawing.Size(316, 22);
            this.txtSzukajPacjenta.TabIndex = 13;
            // 
            // txtSkierowanie
            // 
            this.txtSkierowanie.Location = new System.Drawing.Point(31, 397);
            this.txtSkierowanie.Multiline = true;
            this.txtSkierowanie.Name = "txtSkierowanie";
            this.txtSkierowanie.Size = new System.Drawing.Size(268, 125);
            this.txtSkierowanie.TabIndex = 14;
            // 
            // txtRecepta
            // 
            this.txtRecepta.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtRecepta.Location = new System.Drawing.Point(1091, 69);
            this.txtRecepta.Multiline = true;
            this.txtRecepta.Name = "txtRecepta";
            this.txtRecepta.Size = new System.Drawing.Size(399, 368);
            this.txtRecepta.TabIndex = 15;
            // 
            // btnRecepta
            // 
            this.btnRecepta.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRecepta.Location = new System.Drawing.Point(31, 94);
            this.btnRecepta.Name = "btnRecepta";
            this.btnRecepta.Size = new System.Drawing.Size(221, 75);
            this.btnRecepta.TabIndex = 16;
            this.btnRecepta.Text = "Recepta";
            this.btnRecepta.UseVisualStyleBackColor = false;
            this.btnRecepta.Click += new System.EventHandler(this.btnRecepta_Click_1);
            // 
            // btnZapisz
            // 
            this.btnZapisz.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnZapisz.Location = new System.Drawing.Point(1007, 729);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(123, 32);
            this.btnZapisz.TabIndex = 17;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = false;
            // 
            // btnSkierowanie
            // 
            this.btnSkierowanie.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSkierowanie.Location = new System.Drawing.Point(31, 28);
            this.btnSkierowanie.Name = "btnSkierowanie";
            this.btnSkierowanie.Size = new System.Drawing.Size(221, 74);
            this.btnSkierowanie.TabIndex = 18;
            this.btnSkierowanie.Text = "Skierowanie";
            this.btnSkierowanie.UseVisualStyleBackColor = false;
            this.btnSkierowanie.Click += new System.EventHandler(this.btnSkierowanie_Click_1);
            // 
            // btnSzukaj
            // 
            this.btnSzukaj.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSzukaj.Location = new System.Drawing.Point(549, 21);
            this.btnSzukaj.Name = "btnSzukaj";
            this.btnSzukaj.Size = new System.Drawing.Size(151, 38);
            this.btnSzukaj.TabIndex = 19;
            this.btnSzukaj.Text = "Szukaj";
            this.btnSzukaj.UseVisualStyleBackColor = false;
            this.btnSzukaj.Click += new System.EventHandler(this.btnSzukaj_Click);
            // 
            // txtZalecenia
            // 
            this.txtZalecenia.Location = new System.Drawing.Point(1105, 600);
            this.txtZalecenia.Multiline = true;
            this.txtZalecenia.Name = "txtZalecenia";
            this.txtZalecenia.Size = new System.Drawing.Size(368, 190);
            this.txtZalecenia.TabIndex = 20;
            // 
            // buttonPokazPacjentow
            // 
            this.buttonPokazPacjentow.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPokazPacjentow.Location = new System.Drawing.Point(549, 399);
            this.buttonPokazPacjentow.Name = "buttonPokazPacjentow";
            this.buttonPokazPacjentow.Size = new System.Drawing.Size(151, 38);
            this.buttonPokazPacjentow.TabIndex = 22;
            this.buttonPokazPacjentow.Text = "Pokaz Pacjentow";
            this.buttonPokazPacjentow.UseVisualStyleBackColor = false;
            this.buttonPokazPacjentow.Click += new System.EventHandler(this.buttonPokazPacjentow_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageWizyty);
            this.tabControl1.Controls.Add(this.tabPagePacjenci);
            this.tabControl1.Controls.Add(this.tabPageEdycjaWizyty);
            this.tabControl1.Controls.Add(this.tabPageZlecenia);
            this.tabControl1.Controls.Add(this.tabPagePowiadomienia);
            this.tabControl1.Controls.Add(this.tabPageUstawienia);
            this.tabControl1.Location = new System.Drawing.Point(-1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1106, 1021);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPageWizyty
            // 
            this.tabPageWizyty.Controls.Add(this.dataGridViewWizyty);
            this.tabPageWizyty.Controls.Add(this.btnSzukaj);
            this.tabPageWizyty.Controls.Add(this.buttonPokazPacjentow);
            this.tabPageWizyty.Controls.Add(this.buttonWyloguj);
            this.tabPageWizyty.Controls.Add(this.txtSzukajPacjenta);
            this.tabPageWizyty.Location = new System.Drawing.Point(4, 25);
            this.tabPageWizyty.Name = "tabPageWizyty";
            this.tabPageWizyty.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWizyty.Size = new System.Drawing.Size(1098, 992);
            this.tabPageWizyty.TabIndex = 0;
            this.tabPageWizyty.Text = "Wizyty";
            this.tabPageWizyty.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWizyty
            // 
            this.dataGridViewWizyty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWizyty.Location = new System.Drawing.Point(165, 53);
            this.dataGridViewWizyty.Name = "dataGridViewWizyty";
            this.dataGridViewWizyty.RowHeadersWidth = 51;
            this.dataGridViewWizyty.Size = new System.Drawing.Size(663, 406);
            this.dataGridViewWizyty.TabIndex = 22;
            // 
            // tabPagePacjenci
            // 
            this.tabPagePacjenci.Controls.Add(this.label7);
            this.tabPagePacjenci.Controls.Add(this.label6);
            this.tabPagePacjenci.Controls.Add(this.dateTimePicker2);
            this.tabPagePacjenci.Controls.Add(this.textBox2);
            this.tabPagePacjenci.Controls.Add(this.button2);
            this.tabPagePacjenci.Controls.Add(this.dataGridView2);
            this.tabPagePacjenci.Location = new System.Drawing.Point(4, 25);
            this.tabPagePacjenci.Name = "tabPagePacjenci";
            this.tabPagePacjenci.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePacjenci.Size = new System.Drawing.Size(1098, 992);
            this.tabPagePacjenci.TabIndex = 1;
            this.tabPagePacjenci.Text = "Pacjenci";
            this.tabPagePacjenci.UseVisualStyleBackColor = true;
            // 
            // tabPageEdycjaWizyty
            // 
            this.tabPageEdycjaWizyty.Controls.Add(this.buttonpokapacjentow);
            this.tabPageEdycjaWizyty.Controls.Add(this.buttonZatwierdzSkierowanie);
            this.tabPageEdycjaWizyty.Controls.Add(this.buttonZatwierdzRecepte);
            this.tabPageEdycjaWizyty.Controls.Add(this.dataGridViewPacjenci);
            this.tabPageEdycjaWizyty.Controls.Add(this.label2);
            this.tabPageEdycjaWizyty.Controls.Add(this.Recepta);
            this.tabPageEdycjaWizyty.Controls.Add(this.OPIS);
            this.tabPageEdycjaWizyty.Controls.Add(this.txtRecepta);
            this.tabPageEdycjaWizyty.Controls.Add(this.txtZalecenia);
            this.tabPageEdycjaWizyty.Controls.Add(this.btnZapisz);
            this.tabPageEdycjaWizyty.Controls.Add(this.btnSkierowanie);
            this.tabPageEdycjaWizyty.Controls.Add(this.btnRecepta);
            this.tabPageEdycjaWizyty.Controls.Add(this.txtSkierowanie);
            this.tabPageEdycjaWizyty.Location = new System.Drawing.Point(4, 25);
            this.tabPageEdycjaWizyty.Name = "tabPageEdycjaWizyty";
            this.tabPageEdycjaWizyty.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdycjaWizyty.Size = new System.Drawing.Size(1098, 992);
            this.tabPageEdycjaWizyty.TabIndex = 2;
            this.tabPageEdycjaWizyty.Text = "Edycja Wizyty";
            this.tabPageEdycjaWizyty.UseVisualStyleBackColor = true;
            // 
            // buttonpokapacjentow
            // 
            this.buttonpokapacjentow.Location = new System.Drawing.Point(961, 6);
            this.buttonpokapacjentow.Name = "buttonpokapacjentow";
            this.buttonpokapacjentow.Size = new System.Drawing.Size(100, 28);
            this.buttonpokapacjentow.TabIndex = 27;
            this.buttonpokapacjentow.Text = "Pokaz";
            this.buttonpokapacjentow.UseVisualStyleBackColor = true;
            this.buttonpokapacjentow.Click += new System.EventHandler(this.buttonpokapacjentow_Click);
            // 
            // buttonZatwierdzSkierowanie
            // 
            this.buttonZatwierdzSkierowanie.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonZatwierdzSkierowanie.Location = new System.Drawing.Point(120, 505);
            this.buttonZatwierdzSkierowanie.Name = "buttonZatwierdzSkierowanie";
            this.buttonZatwierdzSkierowanie.Size = new System.Drawing.Size(151, 39);
            this.buttonZatwierdzSkierowanie.TabIndex = 26;
            this.buttonZatwierdzSkierowanie.Text = "Zatwierdz";
            this.buttonZatwierdzSkierowanie.UseVisualStyleBackColor = false;
            this.buttonZatwierdzSkierowanie.Click += new System.EventHandler(this.buttonZatwierdzSkierowanie_Click);
            // 
            // buttonZatwierdzRecepte
            // 
            this.buttonZatwierdzRecepte.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonZatwierdzRecepte.Location = new System.Drawing.Point(1278, 375);
            this.buttonZatwierdzRecepte.Name = "buttonZatwierdzRecepte";
            this.buttonZatwierdzRecepte.Size = new System.Drawing.Size(151, 39);
            this.buttonZatwierdzRecepte.TabIndex = 25;
            this.buttonZatwierdzRecepte.Text = "Zatwierdz";
            this.buttonZatwierdzRecepte.UseVisualStyleBackColor = false;
            this.buttonZatwierdzRecepte.Click += new System.EventHandler(this.buttonZatwierdzRecepte_Click);
            // 
            // dataGridViewPacjenci
            // 
            this.dataGridViewPacjenci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPacjenci.Location = new System.Drawing.Point(260, 6);
            this.dataGridViewPacjenci.Name = "dataGridViewPacjenci";
            this.dataGridViewPacjenci.RowHeadersWidth = 51;
            this.dataGridViewPacjenci.Size = new System.Drawing.Size(927, 949);
            this.dataGridViewPacjenci.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1549, 565);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Diagnoza";
            // 
            // Recepta
            // 
            this.Recepta.AutoSize = true;
            this.Recepta.Location = new System.Drawing.Point(1636, 48);
            this.Recepta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Recepta.Name = "Recepta";
            this.Recepta.Size = new System.Drawing.Size(59, 16);
            this.Recepta.TabIndex = 22;
            this.Recepta.Text = "Recepta";
            // 
            // OPIS
            // 
            this.OPIS.AutoSize = true;
            this.OPIS.Location = new System.Drawing.Point(1549, 549);
            this.OPIS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OPIS.Name = "OPIS";
            this.OPIS.Size = new System.Drawing.Size(38, 16);
            this.OPIS.TabIndex = 21;
            this.OPIS.Text = "OPIS";
            // 
            // tabPageZlecenia
            // 
            this.tabPageZlecenia.Location = new System.Drawing.Point(4, 25);
            this.tabPageZlecenia.Name = "tabPageZlecenia";
            this.tabPageZlecenia.Size = new System.Drawing.Size(1098, 992);
            this.tabPageZlecenia.TabIndex = 3;
            this.tabPageZlecenia.Text = "Zalecenia";
            this.tabPageZlecenia.UseVisualStyleBackColor = true;
            // 
            // tabPagePowiadomienia
            // 
            this.tabPagePowiadomienia.Location = new System.Drawing.Point(4, 25);
            this.tabPagePowiadomienia.Name = "tabPagePowiadomienia";
            this.tabPagePowiadomienia.Size = new System.Drawing.Size(1098, 992);
            this.tabPagePowiadomienia.TabIndex = 4;
            this.tabPagePowiadomienia.Text = "Powiadomienia";
            this.tabPagePowiadomienia.UseVisualStyleBackColor = true;
            // 
            // tabPageUstawienia
            // 
            this.tabPageUstawienia.Controls.Add(this.label4);
            this.tabPageUstawienia.Controls.Add(this.label3);
            this.tabPageUstawienia.Controls.Add(this.buttonZmienHaslo);
            this.tabPageUstawienia.Controls.Add(this.txtHaslo);
            this.tabPageUstawienia.Controls.Add(this.txtEmail);
            this.tabPageUstawienia.Controls.Add(this.pictureBox1);
            this.tabPageUstawienia.Controls.Add(this.dateTimePicker1);
            this.tabPageUstawienia.Controls.Add(this.monthCalendar1);
            this.tabPageUstawienia.Controls.Add(this.labelLekarzId);
            this.tabPageUstawienia.Controls.Add(this.labelLekarzImieNazwisko);
            this.tabPageUstawienia.Controls.Add(this.labelSpecjalizacja);
            this.tabPageUstawienia.Location = new System.Drawing.Point(4, 25);
            this.tabPageUstawienia.Name = "tabPageUstawienia";
            this.tabPageUstawienia.Size = new System.Drawing.Size(1098, 992);
            this.tabPageUstawienia.TabIndex = 5;
            this.tabPageUstawienia.Text = "Ustawienia";
            this.tabPageUstawienia.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 580);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Zmien Haslo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(494, 503);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Zmien Email";
            // 
            // buttonZmienHaslo
            // 
            this.buttonZmienHaslo.Location = new System.Drawing.Point(1267, 681);
            this.buttonZmienHaslo.Name = "buttonZmienHaslo";
            this.buttonZmienHaslo.Size = new System.Drawing.Size(100, 28);
            this.buttonZmienHaslo.TabIndex = 14;
            this.buttonZmienHaslo.Text = "Zatwierdz";
            this.buttonZmienHaslo.UseVisualStyleBackColor = true;
            // 
            // txtHaslo
            // 
            this.txtHaslo.Location = new System.Drawing.Point(1242, 639);
            this.txtHaslo.Name = "txtHaslo";
            this.txtHaslo.Size = new System.Drawing.Size(132, 22);
            this.txtHaslo.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(1242, 613);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(132, 22);
            this.txtEmail.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(444, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Pacjenci";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(64, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Wpisz Imię Inazwisko";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 133);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(280, 45);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(60, 261);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "Wyszukaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(449, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(597, 334);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(368, 67);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(659, 416);
            this.dataGridView2.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(34, 419);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(197, 64);
            this.button2.TabIndex = 1;
            this.button2.Text = "Wyszukaj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(34, 67);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(286, 52);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(827, 15);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker2.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(372, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "Lista Pacjenta";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(39, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Wpisz Imię i Nazwisko";
            // 
            // PanelLekarza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 1044);
            this.Controls.Add(this.tabControl1);
            this.Name = "PanelLekarza";
            this.Text = "PanelLekarza";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageWizyty.ResumeLayout(false);
            this.tabPageWizyty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWizyty)).EndInit();
            this.tabPagePacjenci.ResumeLayout(false);
            this.tabPagePacjenci.PerformLayout();
            this.tabPageEdycjaWizyty.ResumeLayout(false);
            this.tabPageEdycjaWizyty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacjenci)).EndInit();
            this.tabPageUstawienia.ResumeLayout(false);
            this.tabPageUstawienia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelLekarzId;
        private System.Windows.Forms.Label labelLekarzImieNazwisko;
        private System.Windows.Forms.Label labelSpecjalizacja;
        private System.Windows.Forms.Button buttonWyloguj;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TextBox txtSzukajPacjenta;
        private System.Windows.Forms.TextBox txtSkierowanie;
        private System.Windows.Forms.TextBox txtRecepta;
        private System.Windows.Forms.Button btnRecepta;
        private System.Windows.Forms.Button btnZapisz;
        private System.Windows.Forms.Button btnSkierowanie;
        private System.Windows.Forms.Button btnSzukaj;
        private System.Windows.Forms.TextBox txtZalecenia;
        private System.Windows.Forms.Button buttonPokazPacjentow;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageWizyty;
        private System.Windows.Forms.DataGridView dataGridViewWizyty;
        private System.Windows.Forms.TabPage tabPagePacjenci;
        private System.Windows.Forms.TabPage tabPageEdycjaWizyty;
        private System.Windows.Forms.TabPage tabPageZlecenia;
        private System.Windows.Forms.TabPage tabPagePowiadomienia;
        private System.Windows.Forms.TabPage tabPageUstawienia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Recepta;
        private System.Windows.Forms.Label OPIS;
        private System.Windows.Forms.DataGridView dataGridViewPacjenci;
        private System.Windows.Forms.Button buttonZmienHaslo;
        private System.Windows.Forms.TextBox txtHaslo;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonZatwierdzRecepte;
        private System.Windows.Forms.Button buttonZatwierdzSkierowanie;
        private System.Windows.Forms.Button buttonpokapacjentow;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}