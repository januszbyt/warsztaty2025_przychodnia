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
            this.WylogujAdmin.Location = new System.Drawing.Point(720, 12);
            this.WylogujAdmin.Name = "WylogujAdmin";
            this.WylogujAdmin.Size = new System.Drawing.Size(111, 31);
            this.WylogujAdmin.TabIndex = 15;
            this.WylogujAdmin.Text = "Wyloguj";
            this.WylogujAdmin.UseVisualStyleBackColor = true;
            this.WylogujAdmin.Click += new System.EventHandler(this.WylogujAdmin_Click);
            // 
            // textBoxSpecjalizacjaUprawnienia
            // 
            this.textBoxSpecjalizacjaUprawnienia.Location = new System.Drawing.Point(490, 432);
            this.textBoxSpecjalizacjaUprawnienia.Name = "textBoxSpecjalizacjaUprawnienia";
            this.textBoxSpecjalizacjaUprawnienia.Size = new System.Drawing.Size(160, 20);
            this.textBoxSpecjalizacjaUprawnienia.TabIndex = 32;
            // 
            // PanelAdmina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 482);
            this.Controls.Add(this.textBoxSpecjalizacjaUprawnienia);
            this.Controls.Add(this.WylogujAdmin);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonUsunWszystko);
            this.Controls.Add(this.buttonUsunRekordy);
            this.Controls.Add(this.buttonZabierzUprawnienia);
            this.Controls.Add(this.buttonNadajUprawienia);
            this.Controls.Add(this.buttonWyswietlPacjentow);
            this.Controls.Add(this.buttonWyswierlLekarzy);
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
    }
}