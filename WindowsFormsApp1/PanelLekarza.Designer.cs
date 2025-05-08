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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageWizyty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWizyty)).BeginInit();
            this.tabPageEdycjaWizyty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacjenci)).BeginInit();
            this.tabPageUstawienia.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.imagebadge;
            this.pictureBox1.Location = new System.Drawing.Point(43, 17);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.buttonWyloguj.Location = new System.Drawing.Point(1295, 48);
            this.buttonWyloguj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(83, 32);
            this.buttonWyloguj.TabIndex = 9;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = false;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(667, 312);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.txtSzukajPacjenta.Location = new System.Drawing.Point(220, 33);
            this.txtSzukajPacjenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSzukajPacjenta.Name = "txtSzukajPacjenta";
            this.txtSzukajPacjenta.Size = new System.Drawing.Size(316, 22);
            this.txtSzukajPacjenta.TabIndex = 13;
            // 
            // txtSkierowanie
            // 
            this.txtSkierowanie.Location = new System.Drawing.Point(41, 489);
            this.txtSkierowanie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSkierowanie.Multiline = true;
            this.txtSkierowanie.Name = "txtSkierowanie";
            this.txtSkierowanie.Size = new System.Drawing.Size(268, 125);
            this.txtSkierowanie.TabIndex = 14;
            // 
            // txtRecepta
            // 
            this.txtRecepta.BackColor = System.Drawing.SystemColors.HotTrack;
            this.txtRecepta.Location = new System.Drawing.Point(1455, 85);
            this.txtRecepta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRecepta.Multiline = true;
            this.txtRecepta.Name = "txtRecepta";
            this.txtRecepta.Size = new System.Drawing.Size(399, 368);
            this.txtRecepta.TabIndex = 15;
            // 
            // btnRecepta
            // 
            this.btnRecepta.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnRecepta.Location = new System.Drawing.Point(41, 116);
            this.btnRecepta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnZapisz.Location = new System.Drawing.Point(1343, 897);
            this.btnZapisz.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnZapisz.Name = "btnZapisz";
            this.btnZapisz.Size = new System.Drawing.Size(123, 32);
            this.btnZapisz.TabIndex = 17;
            this.btnZapisz.Text = "Zapisz";
            this.btnZapisz.UseVisualStyleBackColor = false;
            // 
            // btnSkierowanie
            // 
            this.btnSkierowanie.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnSkierowanie.Location = new System.Drawing.Point(41, 34);
            this.btnSkierowanie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.btnSzukaj.Location = new System.Drawing.Point(732, 26);
            this.btnSzukaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSzukaj.Name = "btnSzukaj";
            this.btnSzukaj.Size = new System.Drawing.Size(151, 38);
            this.btnSzukaj.TabIndex = 19;
            this.btnSzukaj.Text = "Szukaj";
            this.btnSzukaj.UseVisualStyleBackColor = false;
            this.btnSzukaj.Click += new System.EventHandler(this.btnSzukaj_Click);
            // 
            // txtZalecenia
            // 
            this.txtZalecenia.Location = new System.Drawing.Point(1473, 738);
            this.txtZalecenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtZalecenia.Multiline = true;
            this.txtZalecenia.Name = "txtZalecenia";
            this.txtZalecenia.Size = new System.Drawing.Size(368, 190);
            this.txtZalecenia.TabIndex = 20;
            // 
            // buttonPokazPacjentow
            // 
            this.buttonPokazPacjentow.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPokazPacjentow.Location = new System.Drawing.Point(732, 491);
            this.buttonPokazPacjentow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.tabPageWizyty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageWizyty.Name = "tabPageWizyty";
            this.tabPageWizyty.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageWizyty.Size = new System.Drawing.Size(1973, 992);
            this.tabPageWizyty.TabIndex = 0;
            this.tabPageWizyty.Text = "Wizyty";
            this.tabPageWizyty.UseVisualStyleBackColor = true;
            // 
            // dataGridViewWizyty
            // 
            this.dataGridViewWizyty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWizyty.Location = new System.Drawing.Point(220, 65);
            this.dataGridViewWizyty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewWizyty.Name = "dataGridViewWizyty";
            this.dataGridViewWizyty.RowHeadersWidth = 51;
            this.dataGridViewWizyty.Size = new System.Drawing.Size(663, 406);
            this.dataGridViewWizyty.TabIndex = 22;
            // 
            // tabPagePacjenci
            // 
            this.tabPagePacjenci.Location = new System.Drawing.Point(4, 25);
            this.tabPagePacjenci.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePacjenci.Name = "tabPagePacjenci";
            this.tabPagePacjenci.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePacjenci.Size = new System.Drawing.Size(1959, 992);
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
            this.tabPageEdycjaWizyty.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageEdycjaWizyty.Name = "tabPageEdycjaWizyty";
            this.tabPageEdycjaWizyty.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageEdycjaWizyty.Size = new System.Drawing.Size(1959, 992);
            this.tabPageEdycjaWizyty.TabIndex = 2;
            this.tabPageEdycjaWizyty.Text = "Edycja Wizyty";
            this.tabPageEdycjaWizyty.UseVisualStyleBackColor = true;
            // 
            // buttonpokapacjentow
            // 
            this.buttonpokapacjentow.Location = new System.Drawing.Point(1281, 7);
            this.buttonpokapacjentow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.buttonZatwierdzSkierowanie.Location = new System.Drawing.Point(160, 622);
            this.buttonZatwierdzSkierowanie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.buttonZatwierdzRecepte.Location = new System.Drawing.Point(1704, 462);
            this.buttonZatwierdzRecepte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.dataGridViewPacjenci.Location = new System.Drawing.Point(347, 7);
            this.dataGridViewPacjenci.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.tabPageZlecenia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPageZlecenia.Name = "tabPageZlecenia";
            this.tabPageZlecenia.Size = new System.Drawing.Size(1959, 992);
            this.tabPageZlecenia.TabIndex = 3;
            this.tabPageZlecenia.Text = "Zalecenia";
            this.tabPageZlecenia.UseVisualStyleBackColor = true;
            // 
            // tabPagePowiadomienia
            // 
            this.tabPagePowiadomienia.Location = new System.Drawing.Point(4, 25);
            this.tabPagePowiadomienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPagePowiadomienia.Name = "tabPagePowiadomienia";
            this.tabPagePowiadomienia.Size = new System.Drawing.Size(1959, 992);
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
            this.tabPageUstawienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.buttonZmienHaslo.Location = new System.Drawing.Point(658, 666);
            this.buttonZmienHaslo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZmienHaslo.Name = "buttonZmienHaslo";
            this.buttonZmienHaslo.Size = new System.Drawing.Size(100, 28);
            this.buttonZmienHaslo.TabIndex = 14;
            this.buttonZmienHaslo.Text = "Zatwierdz";
            this.buttonZmienHaslo.UseVisualStyleBackColor = true;
            // 
            // txtHaslo
            // 
            this.txtHaslo.Location = new System.Drawing.Point(626, 580);
            this.txtHaslo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHaslo.Name = "txtHaslo";
            this.txtHaslo.Size = new System.Drawing.Size(132, 22);
            this.txtHaslo.TabIndex = 13;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(626, 500);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(132, 22);
            this.txtEmail.TabIndex = 12;
            // 
            // PanelLekarza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1140, 1044);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PanelLekarza";
            this.Text = "PanelLekarza";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageWizyty.ResumeLayout(false);
            this.tabPageWizyty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWizyty)).EndInit();
            this.tabPageEdycjaWizyty.ResumeLayout(false);
            this.tabPageEdycjaWizyty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPacjenci)).EndInit();
            this.tabPageUstawienia.ResumeLayout(false);
            this.tabPageUstawienia.PerformLayout();
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
    }
}