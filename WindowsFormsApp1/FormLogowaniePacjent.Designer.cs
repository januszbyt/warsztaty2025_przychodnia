namespace WindowsFormsApp1
{
    partial class FormLogowaniePacjent
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
            System.Windows.Forms.Button buttonToggleTheme;
            this.textBoxLoginPacjent = new System.Windows.Forms.TextBox();
            this.textBoxHasloPacjent = new System.Windows.Forms.TextBox();
            this.checkBoxPokazHaslo = new System.Windows.Forms.CheckBox();
            this.buttonZalogujPacjent = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            buttonToggleTheme = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonToggleTheme
            // 
            buttonToggleTheme.Location = new System.Drawing.Point(35, 420);
            buttonToggleTheme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            buttonToggleTheme.Name = "buttonToggleTheme";
            buttonToggleTheme.Size = new System.Drawing.Size(99, 39);
            buttonToggleTheme.TabIndex = 21;
            buttonToggleTheme.Text = "Tryb jasny";
            buttonToggleTheme.UseVisualStyleBackColor = true;
            buttonToggleTheme.Click += new System.EventHandler(this.buttonToggleTheme_Click);
            // 
            // textBoxLoginPacjent
            // 
            this.textBoxLoginPacjent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxLoginPacjent.Location = new System.Drawing.Point(145, 103);
            this.textBoxLoginPacjent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLoginPacjent.Multiline = true;
            this.textBoxLoginPacjent.Name = "textBoxLoginPacjent";
            this.textBoxLoginPacjent.Size = new System.Drawing.Size(195, 40);
            this.textBoxLoginPacjent.TabIndex = 4;
            // 
            // textBoxHasloPacjent
            // 
            this.textBoxHasloPacjent.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxHasloPacjent.Location = new System.Drawing.Point(145, 177);
            this.textBoxHasloPacjent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxHasloPacjent.Multiline = true;
            this.textBoxHasloPacjent.Name = "textBoxHasloPacjent";
            this.textBoxHasloPacjent.Size = new System.Drawing.Size(195, 40);
            this.textBoxHasloPacjent.TabIndex = 5;
            // 
            // checkBoxPokazHaslo
            // 
            this.checkBoxPokazHaslo.AutoSize = true;
            this.checkBoxPokazHaslo.Location = new System.Drawing.Point(501, 167);
            this.checkBoxPokazHaslo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxPokazHaslo.Name = "checkBoxPokazHaslo";
            this.checkBoxPokazHaslo.Size = new System.Drawing.Size(106, 20);
            this.checkBoxPokazHaslo.TabIndex = 7;
            this.checkBoxPokazHaslo.Text = "Pokaż hasło";
            this.checkBoxPokazHaslo.UseVisualStyleBackColor = true;
            this.checkBoxPokazHaslo.CheckedChanged += new System.EventHandler(this.checkBoxPokazHaslo_CheckedChanged);
            // 
            // buttonZalogujPacjent
            // 
            this.buttonZalogujPacjent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonZalogujPacjent.Location = new System.Drawing.Point(501, 103);
            this.buttonZalogujPacjent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonZalogujPacjent.Name = "buttonZalogujPacjent";
            this.buttonZalogujPacjent.Size = new System.Drawing.Size(143, 47);
            this.buttonZalogujPacjent.TabIndex = 8;
            this.buttonZalogujPacjent.Text = "Zaloguj";
            this.buttonZalogujPacjent.UseVisualStyleBackColor = true;
            this.buttonZalogujPacjent.Click += new System.EventHandler(this.buttonZalogujPacjent_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(220, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "WITAMY W KLINICE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(47, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "E-MAIL:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(47, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "HASŁO:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(408, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Nie możesz się zalogować?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(587, 203);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(83, 16);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Zmień hasło";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(203, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(306, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "BRAK KONTA? ZAREJESTRUJ SIĘ";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(275, 321);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 52);
            this.button2.TabIndex = 18;
            this.button2.Text = "REJESTRACJA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(203, 393);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(313, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "PONOWNY WYBÓR UŻYTKOWNIKA";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(275, 420);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 47);
            this.button3.TabIndex = 20;
            this.button3.Text = "<< COFNIJ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormLogowaniePacjent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(713, 501);
            this.Controls.Add(buttonToggleTheme);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonZalogujPacjent);
            this.Controls.Add(this.checkBoxPokazHaslo);
            this.Controls.Add(this.textBoxHasloPacjent);
            this.Controls.Add(this.textBoxLoginPacjent);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormLogowaniePacjent";
            this.Text = "Logowanie Pacjent";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.FormLogowaniePacjent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxLoginPacjent;
        private System.Windows.Forms.TextBox textBoxHasloPacjent;
        private System.Windows.Forms.CheckBox checkBoxPokazHaslo;
        private System.Windows.Forms.Button buttonZalogujPacjent;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
    }
}