﻿namespace WindowsFormsApp1
{
    partial class FormLogowanieAdmin
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxLoginAdmin = new System.Windows.Forms.TextBox();
            this.textBoxHasloAdmin = new System.Windows.Forms.TextBox();
            this.checkBoxHasloAdmin = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(138, 171);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Zaloguj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxLoginAdmin
            // 
            this.textBoxLoginAdmin.Location = new System.Drawing.Point(126, 61);
            this.textBoxLoginAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLoginAdmin.Name = "textBoxLoginAdmin";
            this.textBoxLoginAdmin.Size = new System.Drawing.Size(148, 26);
            this.textBoxLoginAdmin.TabIndex = 3;
            this.textBoxLoginAdmin.TextChanged += new System.EventHandler(this.textBoxLoginAdmin_TextChanged);
            // 
            // textBoxHasloAdmin
            // 
            this.textBoxHasloAdmin.Location = new System.Drawing.Point(126, 102);
            this.textBoxHasloAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxHasloAdmin.Name = "textBoxHasloAdmin";
            this.textBoxHasloAdmin.Size = new System.Drawing.Size(148, 26);
            this.textBoxHasloAdmin.TabIndex = 4;
            // 
            // checkBoxHasloAdmin
            // 
            this.checkBoxHasloAdmin.AutoSize = true;
            this.checkBoxHasloAdmin.Location = new System.Drawing.Point(140, 136);
            this.checkBoxHasloAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxHasloAdmin.Name = "checkBoxHasloAdmin";
            this.checkBoxHasloAdmin.Size = new System.Drawing.Size(122, 24);
            this.checkBoxHasloAdmin.TabIndex = 5;
            this.checkBoxHasloAdmin.Text = "Pokaż hasło";
            this.checkBoxHasloAdmin.UseVisualStyleBackColor = true;
            this.checkBoxHasloAdmin.CheckedChanged += new System.EventHandler(this.checkBoxHasloAdmin_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(48, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "WITAMY W KLINICE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(35, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "E-MAIL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(35, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "HASŁO:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 222);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(276, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "PONOWNY WYBÓR UŻYTKOWNIKA";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(79, 248);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(161, 58);
            this.button3.TabIndex = 19;
            this.button3.Text = "<< COFNIJ";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormLogowanieAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 344);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBoxHasloAdmin);
            this.Controls.Add(this.textBoxHasloAdmin);
            this.Controls.Add(this.textBoxLoginAdmin);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormLogowanieAdmin";
            this.Text = "Logowanie Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxLoginAdmin;
        private System.Windows.Forms.TextBox textBoxHasloAdmin;
        private System.Windows.Forms.CheckBox checkBoxHasloAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button3;
    }
}