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
            this.buttonWyswierlLekarzy.BackColor = System.Drawing.Color.Silver;
            this.buttonWyswierlLekarzy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonWyswierlLekarzy.Location = new System.Drawing.Point(16, 15);
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
            this.buttonWyswietlPacjentow.Location = new System.Drawing.Point(16, 81);
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
            this.buttonNadajUprawienia.Location = new System.Drawing.Point(16, 148);
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
            this.buttonZabierzUprawnienia.Location = new System.Drawing.Point(16, 214);
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
            this.buttonUsunRekordy.Location = new System.Drawing.Point(16, 281);
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
            this.buttonUsunWszystko.BackColor = System.Drawing.Color.Silver;
            this.buttonUsunWszystko.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonUsunWszystko.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonUsunWszystko.Location = new System.Drawing.Point(16, 427);
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
            this.dataGridView1.Location = new System.Drawing.Point(252, 13);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(545, 498);
            this.dataGridView1.TabIndex = 14;
            // 
            // WylogujAdmin
            // 
            this.WylogujAdmin.BackColor = System.Drawing.Color.Silver;
            this.WylogujAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.WylogujAdmin.Location = new System.Drawing.Point(889, 13);
            this.WylogujAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WylogujAdmin.Name = "WylogujAdmin";
            this.WylogujAdmin.Size = new System.Drawing.Size(178, 61);
            this.WylogujAdmin.TabIndex = 15;
            this.WylogujAdmin.Text = "Wyloguj";
            this.WylogujAdmin.UseVisualStyleBackColor = false;
            this.WylogujAdmin.Click += new System.EventHandler(this.WylogujAdmin_Click);
            // 
            // textBoxSpecjalizacjaUprawnienia
            // 
            this.textBoxSpecjalizacjaUprawnienia.Location = new System.Drawing.Point(653, 532);
            this.textBoxSpecjalizacjaUprawnienia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxSpecjalizacjaUprawnienia.Name = "textBoxSpecjalizacjaUprawnienia";
            this.textBoxSpecjalizacjaUprawnienia.Size = new System.Drawing.Size(212, 22);
            this.textBoxSpecjalizacjaUprawnienia.TabIndex = 32;
            // 
            // PanelAdmina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1092, 593);
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
    }
}