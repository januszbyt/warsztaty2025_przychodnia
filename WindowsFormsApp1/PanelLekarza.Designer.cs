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
            this.pictureBox1.Location = new System.Drawing.Point(849, 77);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 209);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(864, 312);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "ID:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(864, 352);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Imie i Nazwisko Lekarza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(864, 391);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Specjalizacja";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // buttonWizyty
            // 
            this.buttonWizyty.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonWizyty.Location = new System.Drawing.Point(38, 77);
            this.buttonWizyty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonWizyty.Name = "buttonWizyty";
            this.buttonWizyty.Size = new System.Drawing.Size(170, 63);
            this.buttonWizyty.TabIndex = 4;
            this.buttonWizyty.Text = "Wizyty";
            this.buttonWizyty.UseVisualStyleBackColor = false;
            // 
            // buttonRecepty
            // 
            this.buttonRecepty.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonRecepty.Location = new System.Drawing.Point(38, 223);
            this.buttonRecepty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRecepty.Name = "buttonRecepty";
            this.buttonRecepty.Size = new System.Drawing.Size(170, 63);
            this.buttonRecepty.TabIndex = 5;
            this.buttonRecepty.Text = "E-Recepty";
            this.buttonRecepty.UseVisualStyleBackColor = false;
            // 
            // buttonPacjenci
            // 
            this.buttonPacjenci.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonPacjenci.Location = new System.Drawing.Point(38, 149);
            this.buttonPacjenci.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPacjenci.Name = "buttonPacjenci";
            this.buttonPacjenci.Size = new System.Drawing.Size(170, 63);
            this.buttonPacjenci.TabIndex = 6;
            this.buttonPacjenci.Text = "Pacjenci";
            this.buttonPacjenci.UseVisualStyleBackColor = false;
            // 
            // buttonSkierowania
            // 
            this.buttonSkierowania.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonSkierowania.Location = new System.Drawing.Point(38, 295);
            this.buttonSkierowania.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSkierowania.Name = "buttonSkierowania";
            this.buttonSkierowania.Size = new System.Drawing.Size(170, 63);
            this.buttonSkierowania.TabIndex = 7;
            this.buttonSkierowania.Text = "E-Skierowania";
            this.buttonSkierowania.UseVisualStyleBackColor = false;
            // 
            // buttonZwolnienia
            // 
            this.buttonZwolnienia.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonZwolnienia.Location = new System.Drawing.Point(38, 368);
            this.buttonZwolnienia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonZwolnienia.Name = "buttonZwolnienia";
            this.buttonZwolnienia.Size = new System.Drawing.Size(170, 63);
            this.buttonZwolnienia.TabIndex = 8;
            this.buttonZwolnienia.Text = "E-Zwolenienia";
            this.buttonZwolnienia.UseVisualStyleBackColor = false;
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonWyloguj.Location = new System.Drawing.Point(1089, 18);
            this.buttonWyloguj.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(93, 40);
            this.buttonWyloguj.TabIndex = 9;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = false;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // PanelLekarza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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