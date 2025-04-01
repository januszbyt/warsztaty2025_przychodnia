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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonWizyty = new System.Windows.Forms.Button();
            this.buttonRecepty = new System.Windows.Forms.Button();
            this.btnPacjenci = new System.Windows.Forms.Button();
            this.buttonSkierowania = new System.Windows.Forms.Button();
            this.buttonZwolnienia = new System.Windows.Forms.Button();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtSzukaj = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.imagebadge;
            this.pictureBox1.Location = new System.Drawing.Point(739, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 166);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(736, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(736, 254);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Imie i Nazwisko Lekarza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(736, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Specjalizacja";
            // 
            // buttonWizyty
            // 
            this.buttonWizyty.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonWizyty.Location = new System.Drawing.Point(25, 50);
            this.buttonWizyty.Name = "buttonWizyty";
            this.buttonWizyty.Size = new System.Drawing.Size(113, 41);
            this.buttonWizyty.TabIndex = 4;
            this.buttonWizyty.Text = "Wizyty";
            this.buttonWizyty.UseVisualStyleBackColor = false;
            this.buttonWizyty.Click += new System.EventHandler(this.buttonWizyty_Click);
            // 
            // buttonRecepty
            // 
            this.buttonRecepty.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonRecepty.Location = new System.Drawing.Point(25, 145);
            this.buttonRecepty.Name = "buttonRecepty";
            this.buttonRecepty.Size = new System.Drawing.Size(113, 41);
            this.buttonRecepty.TabIndex = 5;
            this.buttonRecepty.Text = "E-Recepty";
            this.buttonRecepty.UseVisualStyleBackColor = false;
            // 
            // btnPacjenci
            // 
            this.btnPacjenci.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnPacjenci.Location = new System.Drawing.Point(25, 97);
            this.btnPacjenci.Name = "btnPacjenci";
            this.btnPacjenci.Size = new System.Drawing.Size(113, 41);
            this.btnPacjenci.TabIndex = 6;
            this.btnPacjenci.Text = "Pacjenci";
            this.btnPacjenci.UseVisualStyleBackColor = false;
            this.btnPacjenci.Click += new System.EventHandler(this.btnPacjenci_Click_1);
            // 
            // buttonSkierowania
            // 
            this.buttonSkierowania.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSkierowania.Location = new System.Drawing.Point(25, 192);
            this.buttonSkierowania.Name = "buttonSkierowania";
            this.buttonSkierowania.Size = new System.Drawing.Size(113, 41);
            this.buttonSkierowania.TabIndex = 7;
            this.buttonSkierowania.Text = "E-Skierowania";
            this.buttonSkierowania.UseVisualStyleBackColor = false;
            // 
            // buttonZwolnienia
            // 
            this.buttonZwolnienia.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonZwolnienia.Location = new System.Drawing.Point(25, 239);
            this.buttonZwolnienia.Name = "buttonZwolnienia";
            this.buttonZwolnienia.Size = new System.Drawing.Size(113, 41);
            this.buttonZwolnienia.TabIndex = 8;
            this.buttonZwolnienia.Text = "E-Zwolenienia";
            this.buttonZwolnienia.UseVisualStyleBackColor = false;
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonWyloguj.Location = new System.Drawing.Point(896, 12);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(62, 26);
            this.buttonWyloguj.TabIndex = 9;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = false;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(690, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(690, 351);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(202, 177);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 310);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
            // 
            // txtSzukaj
            // 
            this.txtSzukaj.Location = new System.Drawing.Point(231, 151);
            this.txtSzukaj.Name = "txtSzukaj";
            this.txtSzukaj.Size = new System.Drawing.Size(100, 20);
            this.txtSzukaj.TabIndex = 13;
           
            // 
            // PanelLekarza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 531);
            this.Controls.Add(this.txtSzukaj);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.buttonWyloguj);
            this.Controls.Add(this.buttonZwolnienia);
            this.Controls.Add(this.buttonSkierowania);
            this.Controls.Add(this.btnPacjenci);
            this.Controls.Add(this.buttonRecepty);
            this.Controls.Add(this.buttonWizyty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PanelLekarza";
            this.Text = "PanelLekarza";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonWizyty;
        private System.Windows.Forms.Button buttonRecepty;
        private System.Windows.Forms.Button btnPacjenci;
        private System.Windows.Forms.Button buttonSkierowania;
        private System.Windows.Forms.Button buttonZwolnienia;
        private System.Windows.Forms.Button buttonWyloguj;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSzukaj;
    }
}