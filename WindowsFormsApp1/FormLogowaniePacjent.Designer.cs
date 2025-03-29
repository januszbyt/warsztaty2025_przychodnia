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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLoginPacjent = new System.Windows.Forms.TextBox();
            this.textBoxHasloPacjent = new System.Windows.Forms.TextBox();
            this.checkBoxPokazHaslo = new System.Windows.Forms.CheckBox();
            this.buttonZalogujPacjent = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasło";
            // 
            // textBoxLoginPacjent
            // 
            this.textBoxLoginPacjent.Location = new System.Drawing.Point(128, 117);
            this.textBoxLoginPacjent.Name = "textBoxLoginPacjent";
            this.textBoxLoginPacjent.Size = new System.Drawing.Size(100, 20);
            this.textBoxLoginPacjent.TabIndex = 4;
            this.textBoxLoginPacjent.TextChanged += new System.EventHandler(this.textBoxLoginPacjent_TextChanged);
            // 
            // textBoxHasloPacjent
            // 
            this.textBoxHasloPacjent.Location = new System.Drawing.Point(128, 163);
            this.textBoxHasloPacjent.Name = "textBoxHasloPacjent";
            this.textBoxHasloPacjent.Size = new System.Drawing.Size(100, 20);
            this.textBoxHasloPacjent.TabIndex = 5;
            this.textBoxHasloPacjent.TextChanged += new System.EventHandler(this.textBoxHasloPacjent_TextChanged);
            // 
            // checkBoxPokazHaslo
            // 
            this.checkBoxPokazHaslo.AutoSize = true;
            this.checkBoxPokazHaslo.Location = new System.Drawing.Point(243, 170);
            this.checkBoxPokazHaslo.Name = "checkBoxPokazHaslo";
            this.checkBoxPokazHaslo.Size = new System.Drawing.Size(88, 17);
            this.checkBoxPokazHaslo.TabIndex = 7;
            this.checkBoxPokazHaslo.Text = "Pokaż Hasło";
            this.checkBoxPokazHaslo.UseVisualStyleBackColor = true;
            this.checkBoxPokazHaslo.CheckedChanged += new System.EventHandler(this.checkBoxPokazHaslo_CheckedChanged);
            // 
            // buttonZalogujPacjent
            // 
            this.buttonZalogujPacjent.Location = new System.Drawing.Point(140, 215);
            this.buttonZalogujPacjent.Name = "buttonZalogujPacjent";
            this.buttonZalogujPacjent.Size = new System.Drawing.Size(75, 23);
            this.buttonZalogujPacjent.TabIndex = 8;
            this.buttonZalogujPacjent.Text = "Zaloguj";
            this.buttonZalogujPacjent.UseVisualStyleBackColor = true;
            this.buttonZalogujPacjent.Click += new System.EventHandler(this.buttonZalogujPacjent_Click);
            // 
            // FormLogowaniePacjent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 334);
            this.Controls.Add(this.buttonZalogujPacjent);
            this.Controls.Add(this.checkBoxPokazHaslo);
            this.Controls.Add(this.textBoxHasloPacjent);
            this.Controls.Add(this.textBoxLoginPacjent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormLogowaniePacjent";
            this.Text = "FormLogowaniePacjent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLoginPacjent;
        private System.Windows.Forms.TextBox textBoxHasloPacjent;
        private System.Windows.Forms.CheckBox checkBoxPokazHaslo;
        private System.Windows.Forms.Button buttonZalogujPacjent;
    }
}