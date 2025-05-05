namespace WindowsFormsApp1
{
    partial class FormPacjent
    {
        /// <summary>aaaaaaaaaaaaaaaaabbbbbbbbbb
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabPageDanePacjenta = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxAktywny = new System.Windows.Forms.CheckBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxKodPocztowy = new System.Windows.Forms.TextBox();
            this.textBoxMiasto = new System.Windows.Forms.TextBox();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.textBoxAdres = new System.Windows.Forms.TextBox();
            this.textBoxNazwisko = new System.Windows.Forms.TextBox();
            this.textBoxImie = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonZapiszZmiany = new System.Windows.Forms.Button();
            this.dateTimePickerDU = new System.Windows.Forms.DateTimePicker();
            this.tabControlPanelLekarza = new System.Windows.Forms.TabControl();
            this.tabPageWizyty = new System.Windows.Forms.TabPage();
            this.dataGridViewHistoria = new System.Windows.Forms.DataGridView();
            this.richTextBoxOpisProblemu = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerWizyta = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewLekarze = new System.Windows.Forms.DataGridView();
            this.buttonDodajWizyte = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridViewDocuments = new System.Windows.Forms.DataGridView();
            this.buttonDodajDocument = new System.Windows.Forms.Button();
            this.buttonWybierzPlik = new System.Windows.Forms.Button();
            this.textBoxUwagiDokument = new System.Windows.Forms.TextBox();
            this.comboBoxTypDokumentu = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.wybranyplik = new System.Windows.Forms.Label();
            this.buttonZmienDane = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabPageDanePacjenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControlPanelLekarza.SuspendLayout();
            this.tabPageWizyty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLekarze)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1391, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // tabPageDanePacjenta
            // 
            this.tabPageDanePacjenta.BackColor = System.Drawing.Color.DimGray;
            this.tabPageDanePacjenta.Controls.Add(this.buttonZmienDane);
            this.tabPageDanePacjenta.Controls.Add(this.label9);
            this.tabPageDanePacjenta.Controls.Add(this.label8);
            this.tabPageDanePacjenta.Controls.Add(this.label7);
            this.tabPageDanePacjenta.Controls.Add(this.label6);
            this.tabPageDanePacjenta.Controls.Add(this.label5);
            this.tabPageDanePacjenta.Controls.Add(this.checkBoxAktywny);
            this.tabPageDanePacjenta.Controls.Add(this.textBoxEmail);
            this.tabPageDanePacjenta.Controls.Add(this.textBoxKodPocztowy);
            this.tabPageDanePacjenta.Controls.Add(this.textBoxMiasto);
            this.tabPageDanePacjenta.Controls.Add(this.textBoxTelefon);
            this.tabPageDanePacjenta.Controls.Add(this.textBoxPesel);
            this.tabPageDanePacjenta.Controls.Add(this.textBoxAdres);
            this.tabPageDanePacjenta.Controls.Add(this.textBoxNazwisko);
            this.tabPageDanePacjenta.Controls.Add(this.textBoxImie);
            this.tabPageDanePacjenta.Controls.Add(this.label4);
            this.tabPageDanePacjenta.Controls.Add(this.label3);
            this.tabPageDanePacjenta.Controls.Add(this.label2);
            this.tabPageDanePacjenta.Controls.Add(this.label1);
            this.tabPageDanePacjenta.Controls.Add(this.pictureBox1);
            this.tabPageDanePacjenta.Controls.Add(this.buttonZapiszZmiany);
            this.tabPageDanePacjenta.Controls.Add(this.dateTimePickerDU);
            this.errorProvider.SetIconAlignment(this.tabPageDanePacjenta, System.Windows.Forms.ErrorIconAlignment.BottomLeft);
            this.tabPageDanePacjenta.Location = new System.Drawing.Point(4, 22);
            this.tabPageDanePacjenta.Name = "tabPageDanePacjenta";
            this.tabPageDanePacjenta.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDanePacjenta.Size = new System.Drawing.Size(1466, 796);
            this.tabPageDanePacjenta.TabIndex = 0;
            this.tabPageDanePacjenta.Text = "Dane Pacjenta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(747, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Tu bedzie zdjecie ryja";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "email";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Miasto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Nr Tel.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Kod Pocztowy";
            // 
            // checkBoxAktywny
            // 
            this.checkBoxAktywny.AutoSize = true;
            this.checkBoxAktywny.Location = new System.Drawing.Point(273, 30);
            this.checkBoxAktywny.Name = "checkBoxAktywny";
            this.checkBoxAktywny.Size = new System.Drawing.Size(92, 17);
            this.checkBoxAktywny.TabIndex = 17;
            this.checkBoxAktywny.Text = "Czy Aktywny?";
            this.checkBoxAktywny.UseVisualStyleBackColor = true;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(61, 209);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(182, 20);
            this.textBoxEmail.TabIndex = 16;
            // 
            // textBoxKodPocztowy
            // 
            this.textBoxKodPocztowy.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBoxKodPocztowy.Location = new System.Drawing.Point(88, 183);
            this.textBoxKodPocztowy.Name = "textBoxKodPocztowy";
            this.textBoxKodPocztowy.Size = new System.Drawing.Size(182, 20);
            this.textBoxKodPocztowy.TabIndex = 15;
            // 
            // textBoxMiasto
            // 
            this.textBoxMiasto.Location = new System.Drawing.Point(61, 157);
            this.textBoxMiasto.Name = "textBoxMiasto";
            this.textBoxMiasto.Size = new System.Drawing.Size(182, 20);
            this.textBoxMiasto.TabIndex = 14;
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.Location = new System.Drawing.Point(61, 131);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(182, 20);
            this.textBoxTelefon.TabIndex = 13;
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.Location = new System.Drawing.Point(61, 105);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(182, 20);
            this.textBoxPesel.TabIndex = 6;
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Location = new System.Drawing.Point(61, 79);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(182, 20);
            this.textBoxAdres.TabIndex = 2;
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(61, 53);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(182, 20);
            this.textBoxNazwisko.TabIndex = 1;
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(61, 27);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(182, 20);
            this.textBoxImie.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Pesel";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Adres";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "nazwisko";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "imie";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.imagebadge;
            this.pictureBox1.Location = new System.Drawing.Point(533, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(491, 316);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // buttonZapiszZmiany
            // 
            this.buttonZapiszZmiany.Location = new System.Drawing.Point(199, 273);
            this.buttonZapiszZmiany.Name = "buttonZapiszZmiany";
            this.buttonZapiszZmiany.Size = new System.Drawing.Size(62, 23);
            this.buttonZapiszZmiany.TabIndex = 7;
            this.buttonZapiszZmiany.Text = "Zapisz zmiany";
            this.buttonZapiszZmiany.UseVisualStyleBackColor = true;
            this.buttonZapiszZmiany.Click += new System.EventHandler(this.buttonZapiszZmiany_Click);
            // 
            // dateTimePickerDU
            // 
            this.dateTimePickerDU.Location = new System.Drawing.Point(61, 235);
            this.dateTimePickerDU.Name = "dateTimePickerDU";
            this.dateTimePickerDU.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDU.TabIndex = 4;
            // 
            // tabControlPanelLekarza
            // 
            this.tabControlPanelLekarza.Controls.Add(this.tabPageDanePacjenta);
            this.tabControlPanelLekarza.Controls.Add(this.tabPageWizyty);
            this.tabControlPanelLekarza.Controls.Add(this.tabPage1);
            this.tabControlPanelLekarza.Cursor = System.Windows.Forms.Cursors.Hand;
            this.errorProvider.SetIconAlignment(this.tabControlPanelLekarza, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.tabControlPanelLekarza.Location = new System.Drawing.Point(12, 12);
            this.tabControlPanelLekarza.Name = "tabControlPanelLekarza";
            this.tabControlPanelLekarza.SelectedIndex = 0;
            this.tabControlPanelLekarza.Size = new System.Drawing.Size(1474, 822);
            this.tabControlPanelLekarza.TabIndex = 2;
            // 
            // tabPageWizyty
            // 
            this.tabPageWizyty.Controls.Add(this.dataGridViewHistoria);
            this.tabPageWizyty.Controls.Add(this.richTextBoxOpisProblemu);
            this.tabPageWizyty.Controls.Add(this.dateTimePickerWizyta);
            this.tabPageWizyty.Controls.Add(this.dataGridViewLekarze);
            this.tabPageWizyty.Controls.Add(this.buttonDodajWizyte);
            this.tabPageWizyty.Location = new System.Drawing.Point(4, 22);
            this.tabPageWizyty.Name = "tabPageWizyty";
            this.tabPageWizyty.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWizyty.Size = new System.Drawing.Size(1466, 796);
            this.tabPageWizyty.TabIndex = 6;
            this.tabPageWizyty.Text = "Wizyty";
            this.tabPageWizyty.UseVisualStyleBackColor = true;
            // 
            // dataGridViewHistoria
            // 
            this.dataGridViewHistoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoria.Location = new System.Drawing.Point(728, 30);
            this.dataGridViewHistoria.Name = "dataGridViewHistoria";
            this.dataGridViewHistoria.Size = new System.Drawing.Size(457, 311);
            this.dataGridViewHistoria.TabIndex = 7;
            // 
            // richTextBoxOpisProblemu
            // 
            this.richTextBoxOpisProblemu.Location = new System.Drawing.Point(360, 347);
            this.richTextBoxOpisProblemu.Name = "richTextBoxOpisProblemu";
            this.richTextBoxOpisProblemu.Size = new System.Drawing.Size(305, 210);
            this.richTextBoxOpisProblemu.TabIndex = 6;
            this.richTextBoxOpisProblemu.Text = "";
            // 
            // dateTimePickerWizyta
            // 
            this.dateTimePickerWizyta.Location = new System.Drawing.Point(58, 347);
            this.dateTimePickerWizyta.Name = "dateTimePickerWizyta";
            this.dateTimePickerWizyta.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerWizyta.TabIndex = 5;
            // 
            // dataGridViewLekarze
            // 
            this.dataGridViewLekarze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLekarze.Location = new System.Drawing.Point(58, 30);
            this.dataGridViewLekarze.Name = "dataGridViewLekarze";
            this.dataGridViewLekarze.Size = new System.Drawing.Size(607, 311);
            this.dataGridViewLekarze.TabIndex = 4;
            // 
            // buttonDodajWizyte
            // 
            this.buttonDodajWizyte.Location = new System.Drawing.Point(58, 375);
            this.buttonDodajWizyte.Name = "buttonDodajWizyte";
            this.buttonDodajWizyte.Size = new System.Drawing.Size(148, 51);
            this.buttonDodajWizyte.TabIndex = 3;
            this.buttonDodajWizyte.Text = "Dodaj Wizyte";
            this.buttonDodajWizyte.UseVisualStyleBackColor = true;
            this.buttonDodajWizyte.Click += new System.EventHandler(this.buttonDodajWizyte_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.wybranyplik);
            this.tabPage1.Controls.Add(this.dataGridViewDocuments);
            this.tabPage1.Controls.Add(this.buttonDodajDocument);
            this.tabPage1.Controls.Add(this.buttonWybierzPlik);
            this.tabPage1.Controls.Add(this.textBoxUwagiDokument);
            this.tabPage1.Controls.Add(this.comboBoxTypDokumentu);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1466, 796);
            this.tabPage1.TabIndex = 7;
            this.tabPage1.Text = "Dokumentacja Medyczna";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDocuments
            // 
            this.dataGridViewDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocuments.Location = new System.Drawing.Point(109, 47);
            this.dataGridViewDocuments.Name = "dataGridViewDocuments";
            this.dataGridViewDocuments.Size = new System.Drawing.Size(992, 353);
            this.dataGridViewDocuments.TabIndex = 4;
            this.dataGridViewDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocuments_CellContentClick);
            // 
            // buttonDodajDocument
            // 
            this.buttonDodajDocument.Location = new System.Drawing.Point(726, 581);
            this.buttonDodajDocument.Name = "buttonDodajDocument";
            this.buttonDodajDocument.Size = new System.Drawing.Size(75, 23);
            this.buttonDodajDocument.TabIndex = 3;
            this.buttonDodajDocument.Text = "Dodaj Dokument";
            this.buttonDodajDocument.UseVisualStyleBackColor = true;
            this.buttonDodajDocument.Click += new System.EventHandler(this.buttonDodajDocument_Click);
            // 
            // buttonWybierzPlik
            // 
            this.buttonWybierzPlik.Location = new System.Drawing.Point(645, 581);
            this.buttonWybierzPlik.Name = "buttonWybierzPlik";
            this.buttonWybierzPlik.Size = new System.Drawing.Size(75, 23);
            this.buttonWybierzPlik.TabIndex = 2;
            this.buttonWybierzPlik.Text = "Wybierz Plik";
            this.buttonWybierzPlik.UseVisualStyleBackColor = true;
            // 
            // textBoxUwagiDokument
            // 
            this.textBoxUwagiDokument.Location = new System.Drawing.Point(454, 406);
            this.textBoxUwagiDokument.Multiline = true;
            this.textBoxUwagiDokument.Name = "textBoxUwagiDokument";
            this.textBoxUwagiDokument.Size = new System.Drawing.Size(347, 169);
            this.textBoxUwagiDokument.TabIndex = 1;
            // 
            // comboBoxTypDokumentu
            // 
            this.comboBoxTypDokumentu.FormattingEnabled = true;
            this.comboBoxTypDokumentu.Location = new System.Drawing.Point(327, 406);
            this.comboBoxTypDokumentu.Name = "comboBoxTypDokumentu";
            this.comboBoxTypDokumentu.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypDokumentu.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // wybranyplik
            // 
            this.wybranyplik.AutoSize = true;
            this.wybranyplik.Location = new System.Drawing.Point(451, 586);
            this.wybranyplik.Name = "wybranyplik";
            this.wybranyplik.Size = new System.Drawing.Size(0, 13);
            this.wybranyplik.TabIndex = 5;
            // 
            // buttonZmienDane
            // 
            this.buttonZmienDane.Location = new System.Drawing.Point(73, 273);
            this.buttonZmienDane.Name = "buttonZmienDane";
            this.buttonZmienDane.Size = new System.Drawing.Size(62, 23);
            this.buttonZmienDane.TabIndex = 24;
            this.buttonZmienDane.Text = "Zmien Dane";
            this.buttonZmienDane.UseVisualStyleBackColor = true;
            this.buttonZmienDane.Click += new System.EventHandler(this.buttonZmienDane_Click);
            // 
            // FormPacjent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 834);
            this.Controls.Add(this.tabControlPanelLekarza);
            this.Controls.Add(this.button1);
            this.Name = "FormPacjent";
            this.Text = "FormPacjent";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabPageDanePacjenta.ResumeLayout(false);
            this.tabPageDanePacjenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControlPanelLekarza.ResumeLayout(false);
            this.tabPageWizyty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLekarze)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabControl tabControlPanelLekarza;
        private System.Windows.Forms.TabPage tabPageDanePacjenta;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxAktywny;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxKodPocztowy;
        private System.Windows.Forms.TextBox textBoxMiasto;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.TextBox textBoxPesel;
        private System.Windows.Forms.TextBox textBoxAdres;
        private System.Windows.Forms.TextBox textBoxNazwisko;
        private System.Windows.Forms.TextBox textBoxImie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonZapiszZmiany;
        private System.Windows.Forms.DateTimePicker dateTimePickerDU;
        private System.Windows.Forms.TabPage tabPageWizyty;
        private System.Windows.Forms.RichTextBox richTextBoxOpisProblemu;
        private System.Windows.Forms.DateTimePicker dateTimePickerWizyta;
        private System.Windows.Forms.DataGridView dataGridViewLekarze;
        private System.Windows.Forms.Button buttonDodajWizyte;
        private System.Windows.Forms.DataGridView dataGridViewHistoria;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox comboBoxTypDokumentu;
        private System.Windows.Forms.TextBox textBoxUwagiDokument;
        private System.Windows.Forms.DataGridView dataGridViewDocuments;
        private System.Windows.Forms.Button buttonDodajDocument;
        private System.Windows.Forms.Button buttonWybierzPlik;
        private System.Windows.Forms.Label wybranyplik;
        private System.Windows.Forms.Button buttonZmienDane;
    }
}