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
            this.tabPageWizyty = new System.Windows.Forms.TabPage();
            this.richTextBoxOpisProblemu = new System.Windows.Forms.RichTextBox();
            this.dateTimePickerWizyta = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewLekarze = new System.Windows.Forms.DataGridView();
            this.buttonDodajWizyte = new System.Windows.Forms.Button();
            this.tabPageStatystyki = new System.Windows.Forms.TabPage();
            this.tabPageDokumentacjaMedyczna = new System.Windows.Forms.TabPage();
            this.comboBoxTypDokumentu = new System.Windows.Forms.ComboBox();
            this.textBoxUwagiDokument = new System.Windows.Forms.TextBox();
            this.labelWybranyPlik = new System.Windows.Forms.Label();
            this.buttonDodajDocument = new System.Windows.Forms.Button();
            this.buttonWybierzPlik = new System.Windows.Forms.Button();
            this.dataGridViewDocuments = new System.Windows.Forms.DataGridView();
            this.tabPageHistoriaMedyczna = new System.Windows.Forms.TabPage();
            this.buttonWizyta = new System.Windows.Forms.Button();
            this.comboBoxMiesiac = new System.Windows.Forms.ComboBox();
            this.dataGridViewHistoria = new System.Windows.Forms.DataGridView();
            this.tabPageInformacje = new System.Windows.Forms.TabPage();
            this.btnAnuluj = new System.Windows.Forms.Button();
            this.checkBoxAktywny = new System.Windows.Forms.CheckBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxKodPocztowy = new System.Windows.Forms.TextBox();
            this.textBoxMiasto = new System.Windows.Forms.TextBox();
            this.textBoxTelefon = new System.Windows.Forms.TextBox();
            this.textBoxPesel = new System.Windows.Forms.TextBox();
            this.textBoxAdress = new System.Windows.Forms.TextBox();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageNote = new System.Windows.Forms.TabPage();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabPageWizyty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLekarze)).BeginInit();
            this.tabPageDokumentacjaMedyczna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).BeginInit();
            this.tabPageHistoriaMedyczna.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoria)).BeginInit();
            this.tabPageInformacje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            // tabPageWizyty
            // 
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
            // richTextBoxOpisProblemu
            // 
            this.richTextBoxOpisProblemu.Location = new System.Drawing.Point(666, 391);
            this.richTextBoxOpisProblemu.Name = "richTextBoxOpisProblemu";
            this.richTextBoxOpisProblemu.Size = new System.Drawing.Size(305, 210);
            this.richTextBoxOpisProblemu.TabIndex = 6;
            this.richTextBoxOpisProblemu.Text = "";
            // 
            // dateTimePickerWizyta
            // 
            this.dateTimePickerWizyta.Location = new System.Drawing.Point(364, 391);
            this.dateTimePickerWizyta.Name = "dateTimePickerWizyta";
            this.dateTimePickerWizyta.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerWizyta.TabIndex = 5;
            // 
            // dataGridViewLekarze
            // 
            this.dataGridViewLekarze.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLekarze.Location = new System.Drawing.Point(364, 74);
            this.dataGridViewLekarze.Name = "dataGridViewLekarze";
            this.dataGridViewLekarze.Size = new System.Drawing.Size(607, 311);
            this.dataGridViewLekarze.TabIndex = 4;
            // 
            // buttonDodajWizyte
            // 
            this.buttonDodajWizyte.Location = new System.Drawing.Point(364, 417);
            this.buttonDodajWizyte.Name = "buttonDodajWizyte";
            this.buttonDodajWizyte.Size = new System.Drawing.Size(148, 51);
            this.buttonDodajWizyte.TabIndex = 3;
            this.buttonDodajWizyte.Text = "Dodaj Wizyte";
            this.buttonDodajWizyte.UseVisualStyleBackColor = true;
            this.buttonDodajWizyte.Click += new System.EventHandler(this.buttonDodajWizyte_Click);
            // 
            // tabPageStatystyki
            // 
            this.tabPageStatystyki.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatystyki.Name = "tabPageStatystyki";
            this.tabPageStatystyki.Size = new System.Drawing.Size(1466, 796);
            this.tabPageStatystyki.TabIndex = 4;
            this.tabPageStatystyki.Text = "Statystyki Pacjenta";
            this.tabPageStatystyki.UseVisualStyleBackColor = true;
            // 
            // tabPageDokumentacjaMedyczna
            // 
            this.tabPageDokumentacjaMedyczna.BackColor = System.Drawing.Color.DimGray;
            this.tabPageDokumentacjaMedyczna.Controls.Add(this.comboBoxTypDokumentu);
            this.tabPageDokumentacjaMedyczna.Controls.Add(this.textBoxUwagiDokument);
            this.tabPageDokumentacjaMedyczna.Controls.Add(this.labelWybranyPlik);
            this.tabPageDokumentacjaMedyczna.Controls.Add(this.buttonDodajDocument);
            this.tabPageDokumentacjaMedyczna.Controls.Add(this.buttonWybierzPlik);
            this.tabPageDokumentacjaMedyczna.Controls.Add(this.dataGridViewDocuments);
            this.tabPageDokumentacjaMedyczna.Location = new System.Drawing.Point(4, 22);
            this.tabPageDokumentacjaMedyczna.Name = "tabPageDokumentacjaMedyczna";
            this.tabPageDokumentacjaMedyczna.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDokumentacjaMedyczna.Size = new System.Drawing.Size(1466, 796);
            this.tabPageDokumentacjaMedyczna.TabIndex = 2;
            this.tabPageDokumentacjaMedyczna.Text = "Dokumentacja Medyczna";
            // 
            // comboBoxTypDokumentu
            // 
            this.comboBoxTypDokumentu.FormattingEnabled = true;
            this.comboBoxTypDokumentu.Location = new System.Drawing.Point(1067, 458);
            this.comboBoxTypDokumentu.Name = "comboBoxTypDokumentu";
            this.comboBoxTypDokumentu.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypDokumentu.TabIndex = 5;
            // 
            // textBoxUwagiDokument
            // 
            this.textBoxUwagiDokument.Location = new System.Drawing.Point(338, 415);
            this.textBoxUwagiDokument.Multiline = true;
            this.textBoxUwagiDokument.Name = "textBoxUwagiDokument";
            this.textBoxUwagiDokument.Size = new System.Drawing.Size(417, 218);
            this.textBoxUwagiDokument.TabIndex = 4;
            // 
            // labelWybranyPlik
            // 
            this.labelWybranyPlik.AutoSize = true;
            this.labelWybranyPlik.Location = new System.Drawing.Point(1064, 497);
            this.labelWybranyPlik.Name = "labelWybranyPlik";
            this.labelWybranyPlik.Size = new System.Drawing.Size(35, 13);
            this.labelWybranyPlik.TabIndex = 3;
            this.labelWybranyPlik.Text = "label5";
            // 
            // buttonDodajDocument
            // 
            this.buttonDodajDocument.Location = new System.Drawing.Point(1194, 456);
            this.buttonDodajDocument.Name = "buttonDodajDocument";
            this.buttonDodajDocument.Size = new System.Drawing.Size(106, 23);
            this.buttonDodajDocument.TabIndex = 2;
            this.buttonDodajDocument.Text = "Dodaj Dokument";
            this.buttonDodajDocument.UseVisualStyleBackColor = true;
            this.buttonDodajDocument.Click += new System.EventHandler(this.buttonDodajDocument_Click);
            // 
            // buttonWybierzPlik
            // 
            this.buttonWybierzPlik.Location = new System.Drawing.Point(1306, 456);
            this.buttonWybierzPlik.Name = "buttonWybierzPlik";
            this.buttonWybierzPlik.Size = new System.Drawing.Size(75, 23);
            this.buttonWybierzPlik.TabIndex = 1;
            this.buttonWybierzPlik.Text = "Otworz";
            this.buttonWybierzPlik.UseVisualStyleBackColor = true;
            this.buttonWybierzPlik.Click += new System.EventHandler(this.buttonWybierzPlik_Click);
            // 
            // dataGridViewDocuments
            // 
            this.dataGridViewDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDocuments.Location = new System.Drawing.Point(473, 160);
            this.dataGridViewDocuments.Name = "dataGridViewDocuments";
            this.dataGridViewDocuments.Size = new System.Drawing.Size(908, 249);
            this.dataGridViewDocuments.TabIndex = 0;
            this.dataGridViewDocuments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDocuments_CellContentClick);
            // 
            // tabPageHistoriaMedyczna
            // 
            this.tabPageHistoriaMedyczna.BackColor = System.Drawing.Color.DimGray;
            this.tabPageHistoriaMedyczna.Controls.Add(this.buttonWizyta);
            this.tabPageHistoriaMedyczna.Controls.Add(this.comboBoxMiesiac);
            this.tabPageHistoriaMedyczna.Controls.Add(this.dataGridViewHistoria);
            this.tabPageHistoriaMedyczna.Location = new System.Drawing.Point(4, 22);
            this.tabPageHistoriaMedyczna.Name = "tabPageHistoriaMedyczna";
            this.tabPageHistoriaMedyczna.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHistoriaMedyczna.Size = new System.Drawing.Size(1466, 796);
            this.tabPageHistoriaMedyczna.TabIndex = 1;
            this.tabPageHistoriaMedyczna.Text = "Historia medyczna";
            // 
            // buttonWizyta
            // 
            this.buttonWizyta.Location = new System.Drawing.Point(949, 651);
            this.buttonWizyta.Name = "buttonWizyta";
            this.buttonWizyta.Size = new System.Drawing.Size(148, 51);
            this.buttonWizyta.TabIndex = 2;
            this.buttonWizyta.Text = "Dodaj Wizyte";
            this.buttonWizyta.UseVisualStyleBackColor = true;
            // 
            // comboBoxMiesiac
            // 
            this.comboBoxMiesiac.FormattingEnabled = true;
            this.comboBoxMiesiac.Location = new System.Drawing.Point(233, 105);
            this.comboBoxMiesiac.Name = "comboBoxMiesiac";
            this.comboBoxMiesiac.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMiesiac.TabIndex = 1;
            // 
            // dataGridViewHistoria
            // 
            this.dataGridViewHistoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistoria.Location = new System.Drawing.Point(313, 166);
            this.dataGridViewHistoria.Name = "dataGridViewHistoria";
            this.dataGridViewHistoria.Size = new System.Drawing.Size(784, 479);
            this.dataGridViewHistoria.TabIndex = 0;
            this.dataGridViewHistoria.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHistoria_CellContentClick);
            // 
            // tabPageInformacje
            // 
            this.tabPageInformacje.BackColor = System.Drawing.Color.DimGray;
            this.tabPageInformacje.Controls.Add(this.btnAnuluj);
            this.tabPageInformacje.Controls.Add(this.checkBoxAktywny);
            this.tabPageInformacje.Controls.Add(this.textBoxEmail);
            this.tabPageInformacje.Controls.Add(this.textBoxKodPocztowy);
            this.tabPageInformacje.Controls.Add(this.textBoxMiasto);
            this.tabPageInformacje.Controls.Add(this.textBoxTelefon);
            this.tabPageInformacje.Controls.Add(this.textBoxPesel);
            this.tabPageInformacje.Controls.Add(this.textBoxAdress);
            this.tabPageInformacje.Controls.Add(this.textBoxAdres);
            this.tabPageInformacje.Controls.Add(this.textBoxNazwisko);
            this.tabPageInformacje.Controls.Add(this.textBoxImie);
            this.tabPageInformacje.Controls.Add(this.label4);
            this.tabPageInformacje.Controls.Add(this.label3);
            this.tabPageInformacje.Controls.Add(this.label2);
            this.tabPageInformacje.Controls.Add(this.label1);
            this.tabPageInformacje.Controls.Add(this.pictureBox1);
            this.tabPageInformacje.Controls.Add(this.buttonZapiszZmiany);
            this.tabPageInformacje.Controls.Add(this.dateTimePickerDU);
            this.tabPageInformacje.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformacje.Name = "tabPageInformacje";
            this.tabPageInformacje.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformacje.Size = new System.Drawing.Size(1466, 796);
            this.tabPageInformacje.TabIndex = 0;
            this.tabPageInformacje.Text = "Informacje";
            // 
            // btnAnuluj
            // 
            this.btnAnuluj.Location = new System.Drawing.Point(225, 451);
            this.btnAnuluj.Name = "btnAnuluj";
            this.btnAnuluj.Size = new System.Drawing.Size(62, 23);
            this.btnAnuluj.TabIndex = 18;
            this.btnAnuluj.Text = "Anuluj";
            this.btnAnuluj.UseVisualStyleBackColor = true;
            this.btnAnuluj.Click += new System.EventHandler(this.btnAnuluj_Click_1);
            // 
            // checkBoxAktywny
            // 
            this.checkBoxAktywny.AutoSize = true;
            this.checkBoxAktywny.Location = new System.Drawing.Point(264, 238);
            this.checkBoxAktywny.Name = "checkBoxAktywny";
            this.checkBoxAktywny.Size = new System.Drawing.Size(72, 17);
            this.checkBoxAktywny.TabIndex = 17;
            this.checkBoxAktywny.Text = "Aktywny?";
            this.checkBoxAktywny.UseVisualStyleBackColor = true;
            this.checkBoxAktywny.CheckedChanged += new System.EventHandler(this.checkBoxAktywny_CheckedChanged);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(27, 235);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(182, 20);
            this.textBoxEmail.TabIndex = 16;
            this.textBoxEmail.TextChanged += new System.EventHandler(this.textBoxEmail_TextChanged);
            // 
            // textBoxKodPocztowy
            // 
            this.textBoxKodPocztowy.Location = new System.Drawing.Point(27, 209);
            this.textBoxKodPocztowy.Name = "textBoxKodPocztowy";
            this.textBoxKodPocztowy.Size = new System.Drawing.Size(182, 20);
            this.textBoxKodPocztowy.TabIndex = 15;
            this.textBoxKodPocztowy.TextChanged += new System.EventHandler(this.textBoxKodPocztowy_TextChanged);
            // 
            // textBoxMiasto
            // 
            this.textBoxMiasto.Location = new System.Drawing.Point(27, 183);
            this.textBoxMiasto.Name = "textBoxMiasto";
            this.textBoxMiasto.Size = new System.Drawing.Size(182, 20);
            this.textBoxMiasto.TabIndex = 14;
            this.textBoxMiasto.TextChanged += new System.EventHandler(this.textBoxMiasto_TextChanged);
            // 
            // textBoxTelefon
            // 
            this.textBoxTelefon.Location = new System.Drawing.Point(27, 157);
            this.textBoxTelefon.Name = "textBoxTelefon";
            this.textBoxTelefon.Size = new System.Drawing.Size(182, 20);
            this.textBoxTelefon.TabIndex = 13;
            this.textBoxTelefon.TextChanged += new System.EventHandler(this.textBoxTelefon_TextChanged);
            // 
            // textBoxPesel
            // 
            this.textBoxPesel.Location = new System.Drawing.Point(27, 131);
            this.textBoxPesel.Name = "textBoxPesel";
            this.textBoxPesel.Size = new System.Drawing.Size(182, 20);
            this.textBoxPesel.TabIndex = 6;
            this.textBoxPesel.TextChanged += new System.EventHandler(this.textBoxPesel_TextChanged);
            // 
            // textBoxAdress
            // 
            this.textBoxAdress.Location = new System.Drawing.Point(27, 105);
            this.textBoxAdress.Name = "textBoxAdress";
            this.textBoxAdress.Size = new System.Drawing.Size(182, 20);
            this.textBoxAdress.TabIndex = 3;
            this.textBoxAdress.TextChanged += new System.EventHandler(this.textBoxAdress_TextChanged);
            // 
            // textBoxAdres
            // 
            this.textBoxAdres.Location = new System.Drawing.Point(27, 79);
            this.textBoxAdres.Name = "textBoxAdres";
            this.textBoxAdres.Size = new System.Drawing.Size(182, 20);
            this.textBoxAdres.TabIndex = 2;
            this.textBoxAdres.TextChanged += new System.EventHandler(this.textBoxAdres_TextChanged);
            // 
            // textBoxNazwisko
            // 
            this.textBoxNazwisko.Location = new System.Drawing.Point(27, 53);
            this.textBoxNazwisko.Name = "textBoxNazwisko";
            this.textBoxNazwisko.Size = new System.Drawing.Size(182, 20);
            this.textBoxNazwisko.TabIndex = 1;
            this.textBoxNazwisko.TextChanged += new System.EventHandler(this.textBoxNazwisko_TextChanged);
            // 
            // textBoxImie
            // 
            this.textBoxImie.Location = new System.Drawing.Point(27, 27);
            this.textBoxImie.Name = "textBoxImie";
            this.textBoxImie.Size = new System.Drawing.Size(182, 20);
            this.textBoxImie.TabIndex = 0;
            this.textBoxImie.TextChanged += new System.EventHandler(this.textBoxImie_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(921, 461);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "label4";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(921, 438);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(921, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(921, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.imagebadge;
            this.pictureBox1.Location = new System.Drawing.Point(914, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(491, 316);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // buttonZapiszZmiany
            // 
            this.buttonZapiszZmiany.Location = new System.Drawing.Point(147, 451);
            this.buttonZapiszZmiany.Name = "buttonZapiszZmiany";
            this.buttonZapiszZmiany.Size = new System.Drawing.Size(62, 23);
            this.buttonZapiszZmiany.TabIndex = 7;
            this.buttonZapiszZmiany.Text = "Zapisz zmiany";
            this.buttonZapiszZmiany.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDU
            // 
            this.dateTimePickerDU.Location = new System.Drawing.Point(27, 270);
            this.dateTimePickerDU.Name = "dateTimePickerDU";
            this.dateTimePickerDU.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDU.TabIndex = 4;
            this.dateTimePickerDU.ValueChanged += new System.EventHandler(this.dateTimePickerDU_ValueChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageInformacje);
            this.tabControl1.Controls.Add(this.tabPageHistoriaMedyczna);
            this.tabControl1.Controls.Add(this.tabPageDokumentacjaMedyczna);
            this.tabControl1.Controls.Add(this.tabPageStatystyki);
            this.tabControl1.Controls.Add(this.tabPageWizyty);
            this.tabControl1.Controls.Add(this.tabPageNote);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1474, 822);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPageNote
            // 
            this.tabPageNote.Location = new System.Drawing.Point(4, 22);
            this.tabPageNote.Name = "tabPageNote";
            this.tabPageNote.Size = new System.Drawing.Size(1466, 796);
            this.tabPageNote.TabIndex = 7;
            this.tabPageNote.Text = "Notatki Lekarza";
            this.tabPageNote.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // FormPacjent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1486, 834);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Name = "FormPacjent";
            this.Text = "FormPacjent";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabPageWizyty.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLekarze)).EndInit();
            this.tabPageDokumentacjaMedyczna.ResumeLayout(false);
            this.tabPageDokumentacjaMedyczna.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDocuments)).EndInit();
            this.tabPageHistoriaMedyczna.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistoria)).EndInit();
            this.tabPageInformacje.ResumeLayout(false);
            this.tabPageInformacje.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageInformacje;
        private System.Windows.Forms.Button btnAnuluj;
        private System.Windows.Forms.CheckBox checkBoxAktywny;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxKodPocztowy;
        private System.Windows.Forms.TextBox textBoxMiasto;
        private System.Windows.Forms.TextBox textBoxTelefon;
        private System.Windows.Forms.TextBox textBoxPesel;
        private System.Windows.Forms.TextBox textBoxAdress;
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
        private System.Windows.Forms.TabPage tabPageHistoriaMedyczna;
        private System.Windows.Forms.Button buttonWizyta;
        private System.Windows.Forms.ComboBox comboBoxMiesiac;
        private System.Windows.Forms.DataGridView dataGridViewHistoria;
        private System.Windows.Forms.TabPage tabPageDokumentacjaMedyczna;
        private System.Windows.Forms.TabPage tabPageStatystyki;
        private System.Windows.Forms.TabPage tabPageWizyty;
        private System.Windows.Forms.RichTextBox richTextBoxOpisProblemu;
        private System.Windows.Forms.DateTimePicker dateTimePickerWizyta;
        private System.Windows.Forms.DataGridView dataGridViewLekarze;
        private System.Windows.Forms.Button buttonDodajWizyte;
        private System.Windows.Forms.TabPage tabPageNote;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridViewDocuments;
        private System.Windows.Forms.ComboBox comboBoxTypDokumentu;
        private System.Windows.Forms.TextBox textBoxUwagiDokument;
        private System.Windows.Forms.Label labelWybranyPlik;
        private System.Windows.Forms.Button buttonDodajDocument;
        private System.Windows.Forms.Button buttonWybierzPlik;
    }
}