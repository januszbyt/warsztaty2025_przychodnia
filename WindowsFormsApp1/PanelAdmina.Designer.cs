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
            this.buttonUsunWszystko = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.WylogujAdmin = new System.Windows.Forms.Button();
            this.textBoxSpecjalizacjaUprawnienia = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonResetujHaslo = new System.Windows.Forms.Button();
            this.ResetHasla = new System.Windows.Forms.Button();
            this.buttonToggleThema = new System.Windows.Forms.Button();
            this.buttonPowiadomienia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonWyswierlLekarzy
            // 
            this.buttonWyswierlLekarzy.BackColor = System.Drawing.Color.Silver;
            this.buttonWyswierlLekarzy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonWyswierlLekarzy.Location = new System.Drawing.Point(16, 16);
            this.buttonWyswierlLekarzy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonWyswierlLekarzy.Name = "buttonWyswierlLekarzy";
            this.buttonWyswierlLekarzy.Size = new System.Drawing.Size(209, 59);
            this.buttonWyswierlLekarzy.TabIndex = 0;
            this.buttonWyswierlLekarzy.Text = "Wyswietl Lekarzy";
            this.buttonWyswierlLekarzy.UseVisualStyleBackColor = false;
            this.buttonWyswierlLekarzy.Click += new System.EventHandler(this.buttonWyswierlLekarzy_Click);
            // 
            // buttonWyswietlPacjentow
            // 
            this.buttonWyswietlPacjentow.BackColor = System.Drawing.Color.Silver;
            this.buttonWyswietlPacjentow.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonWyswietlPacjentow.Location = new System.Drawing.Point(16, 98);
            this.buttonWyswietlPacjentow.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonWyswietlPacjentow.Name = "buttonWyswietlPacjentow";
            this.buttonWyswietlPacjentow.Size = new System.Drawing.Size(209, 59);
            this.buttonWyswietlPacjentow.TabIndex = 1;
            this.buttonWyswietlPacjentow.Text = "Wyświetl Pacjentow";
            this.buttonWyswietlPacjentow.UseVisualStyleBackColor = false;
            this.buttonWyswietlPacjentow.Click += new System.EventHandler(this.buttonWyswietlPacjentow_Click);
            // 
            // buttonNadajUprawienia
            // 
            this.buttonNadajUprawienia.BackColor = System.Drawing.Color.Silver;
            this.buttonNadajUprawienia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonNadajUprawienia.Location = new System.Drawing.Point(16, 183);
            this.buttonNadajUprawienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonNadajUprawienia.Name = "buttonNadajUprawienia";
            this.buttonNadajUprawienia.Size = new System.Drawing.Size(209, 59);
            this.buttonNadajUprawienia.TabIndex = 2;
            this.buttonNadajUprawienia.Text = "Nadaj Uprawnienia";
            this.buttonNadajUprawienia.UseVisualStyleBackColor = false;
            this.buttonNadajUprawienia.Click += new System.EventHandler(this.buttonNadajUprawienia_Click);
            // 
            // buttonZabierzUprawnienia
            // 
            this.buttonZabierzUprawnienia.BackColor = System.Drawing.Color.Silver;
            this.buttonZabierzUprawnienia.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZabierzUprawnienia.Location = new System.Drawing.Point(16, 270);
            this.buttonZabierzUprawnienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZabierzUprawnienia.Name = "buttonZabierzUprawnienia";
            this.buttonZabierzUprawnienia.Size = new System.Drawing.Size(209, 59);
            this.buttonZabierzUprawnienia.TabIndex = 3;
            this.buttonZabierzUprawnienia.Text = "Zabierz Uprawnienia";
            this.buttonZabierzUprawnienia.UseVisualStyleBackColor = false;
            this.buttonZabierzUprawnienia.Click += new System.EventHandler(this.buttonZabierzUprawnienia_Click);
            // 
            // buttonUsunRekordy
            // 
            this.buttonUsunRekordy.BackColor = System.Drawing.Color.Silver;
            this.buttonUsunRekordy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUsunRekordy.Location = new System.Drawing.Point(16, 441);
            this.buttonUsunRekordy.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUsunRekordy.Name = "buttonUsunRekordy";
            this.buttonUsunRekordy.Size = new System.Drawing.Size(209, 59);
            this.buttonUsunRekordy.TabIndex = 4;
            this.buttonUsunRekordy.Text = "Usun Uzytkownika";
            this.buttonUsunRekordy.UseVisualStyleBackColor = false;
            this.buttonUsunRekordy.Click += new System.EventHandler(this.buttonUsunRekordy_Click);
            // 
            // buttonUsunWszystko
            // 
            this.buttonUsunWszystko.BackColor = System.Drawing.Color.Red;
            this.buttonUsunWszystko.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUsunWszystko.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUsunWszystko.Location = new System.Drawing.Point(16, 519);
            this.buttonUsunWszystko.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUsunWszystko.Name = "buttonUsunWszystko";
            this.buttonUsunWszystko.Size = new System.Drawing.Size(209, 59);
            this.buttonUsunWszystko.TabIndex = 7;
            this.buttonUsunWszystko.Text = "Usun wszystko z bazy";
            this.buttonUsunWszystko.UseVisualStyleBackColor = false;
            this.buttonUsunWszystko.Click += new System.EventHandler(this.buttonUsunWszystko_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(252, 14);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(629, 486);
            this.dataGridView1.TabIndex = 14;
            // 
            // WylogujAdmin
            // 
            this.WylogujAdmin.BackColor = System.Drawing.Color.Silver;
            this.WylogujAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WylogujAdmin.Location = new System.Drawing.Point(915, 16);
            this.WylogujAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WylogujAdmin.Name = "WylogujAdmin";
            this.WylogujAdmin.Size = new System.Drawing.Size(179, 62);
            this.WylogujAdmin.TabIndex = 15;
            this.WylogujAdmin.Text = "Wyloguj";
            this.WylogujAdmin.UseVisualStyleBackColor = false;
            this.WylogujAdmin.Click += new System.EventHandler(this.WylogujAdmin_Click);
            // 
            // textBoxSpecjalizacjaUprawnienia
            // 
            this.textBoxSpecjalizacjaUprawnienia.BackColor = System.Drawing.SystemColors.HighlightText;
            this.textBoxSpecjalizacjaUprawnienia.Location = new System.Drawing.Point(893, 288);
            this.textBoxSpecjalizacjaUprawnienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSpecjalizacjaUprawnienia.Name = "textBoxSpecjalizacjaUprawnienia";
            this.textBoxSpecjalizacjaUprawnienia.Size = new System.Drawing.Size(199, 22);
            this.textBoxSpecjalizacjaUprawnienia.TabIndex = 32;
            this.textBoxSpecjalizacjaUprawnienia.TextChanged += new System.EventHandler(this.textBoxSpecjalizacjaUprawnienia_TextChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(889, 208);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 70);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nadawanie Specjalizacji Lekarzowi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(905, 414);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 22);
            this.textBox1.TabIndex = 34;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(901, 347);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 58);
            this.label2.TabIndex = 35;
            this.label2.Text = "Reset Hasła             Wpisz nowe Hasło";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // buttonResetujHaslo
            // 
            this.buttonResetujHaslo.BackColor = System.Drawing.Color.DarkGray;
            this.buttonResetujHaslo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonResetujHaslo.Location = new System.Drawing.Point(919, 519);
            this.buttonResetujHaslo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonResetujHaslo.Name = "buttonResetujHaslo";
            this.buttonResetujHaslo.Size = new System.Drawing.Size(149, 47);
            this.buttonResetujHaslo.TabIndex = 36;
            this.buttonResetujHaslo.Text = "Reset";
            this.buttonResetujHaslo.UseVisualStyleBackColor = false;
            this.buttonResetujHaslo.Click += new System.EventHandler(this.buttonResetujHaslo_Click);
            // 
            // ResetHasla
            // 
            this.ResetHasla.BackColor = System.Drawing.Color.Silver;
            this.ResetHasla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ResetHasla.Location = new System.Drawing.Point(16, 352);
            this.ResetHasla.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ResetHasla.Name = "ResetHasla";
            this.ResetHasla.Size = new System.Drawing.Size(209, 66);
            this.ResetHasla.TabIndex = 37;
            this.ResetHasla.Text = "Reset Hasła";
            this.ResetHasla.UseMnemonic = false;
            this.ResetHasla.UseVisualStyleBackColor = false;
            this.ResetHasla.Click += new System.EventHandler(this.ResetHasla_Click);
            // 
            // buttonToggleThema
            // 
            this.buttonToggleThema.Location = new System.Drawing.Point(639, 537);
            this.buttonToggleThema.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonToggleThema.Name = "buttonToggleThema";
            this.buttonToggleThema.Size = new System.Drawing.Size(100, 28);
            this.buttonToggleThema.TabIndex = 38;
            this.buttonToggleThema.Text = "Tryb Jasny";
            this.buttonToggleThema.UseVisualStyleBackColor = true;
            this.buttonToggleThema.Click += new System.EventHandler(this.buttonToggleThema_Click);
            // 
            // buttonPowiadomienia
            // 
            this.buttonPowiadomienia.Location = new System.Drawing.Point(313, 519);
            this.buttonPowiadomienia.Name = "buttonPowiadomienia";
            this.buttonPowiadomienia.Size = new System.Drawing.Size(200, 47);
            this.buttonPowiadomienia.TabIndex = 39;
            this.buttonPowiadomienia.Text = "Panel Powiadomień";
            this.buttonPowiadomienia.UseVisualStyleBackColor = true;
            this.buttonPowiadomienia.Click += new System.EventHandler(this.buttonPowiadomienia_Click);
            // 
            // PanelAdmina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1123, 598);
            this.Controls.Add(this.buttonPowiadomienia);
            this.Controls.Add(this.buttonToggleThema);
            this.Controls.Add(this.ResetHasla);
            this.Controls.Add(this.buttonResetujHaslo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxSpecjalizacjaUprawnienia);
            this.Controls.Add(this.WylogujAdmin);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonUsunWszystko);
            this.Controls.Add(this.buttonUsunRekordy);
            this.Controls.Add(this.buttonZabierzUprawnienia);
            this.Controls.Add(this.buttonNadajUprawienia);
            this.Controls.Add(this.buttonWyswietlPacjentow);
            this.Controls.Add(this.buttonWyswierlLekarzy);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "PanelAdmina";
            this.Text = "PanelAdmina";
            this.Load += new System.EventHandler(this.PanelAdmina_Load);
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
        private System.Windows.Forms.Button buttonUsunWszystko;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button WylogujAdmin;
        private System.Windows.Forms.TextBox textBoxSpecjalizacjaUprawnienia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonResetujHaslo;
        private System.Windows.Forms.Button ResetHasla;
        private System.Windows.Forms.Button buttonToggleThema;
        private System.Windows.Forms.Button buttonPowiadomienia;
    }
}