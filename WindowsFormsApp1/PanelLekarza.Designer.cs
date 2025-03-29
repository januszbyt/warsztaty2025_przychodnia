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
            this.buttonPacjenci = new System.Windows.Forms.Button();
            this.buttonSkierowania = new System.Windows.Forms.Button();
            this.buttonZwolnienia = new System.Windows.Forms.Button();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.imagebadge;
            this.pictureBox1.Location = new System.Drawing.Point(566, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 136);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(576, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(576, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Imie i Nazwisko Lekarza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(576, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Specjalizacja";
            this.label3.Click += new System.EventHandler(this.label3_Click);
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
            // buttonPacjenci
            // 
            this.buttonPacjenci.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPacjenci.Location = new System.Drawing.Point(25, 97);
            this.buttonPacjenci.Name = "buttonPacjenci";
            this.buttonPacjenci.Size = new System.Drawing.Size(113, 41);
            this.buttonPacjenci.TabIndex = 6;
            this.buttonPacjenci.Text = "Pacjenci";
            this.buttonPacjenci.UseVisualStyleBackColor = false;
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
            this.buttonWyloguj.Location = new System.Drawing.Point(726, 12);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(62, 26);
            this.buttonWyloguj.TabIndex = 9;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = false;
            // 
            // PanelLekarza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonWyloguj);
            this.Controls.Add(this.buttonZwolnienia);
            this.Controls.Add(this.buttonSkierowania);
            this.Controls.Add(this.buttonPacjenci);
            this.Controls.Add(this.buttonRecepty);
            this.Controls.Add(this.buttonWizyty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PanelLekarza";
            this.Text = "PanelLekarza";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button buttonPacjenci;
        private System.Windows.Forms.Button buttonSkierowania;
        private System.Windows.Forms.Button buttonZwolnienia;
        private System.Windows.Forms.Button buttonWyloguj;
    }
}