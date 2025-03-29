namespace WindowsFormsApp1
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
            this.Login = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxLoginAdmin = new System.Windows.Forms.TextBox();
            this.textBoxHasloAdmin = new System.Windows.Forms.TextBox();
            this.checkBoxHasloAdmin = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Login
            // 
            this.Login.AutoSize = true;
            this.Login.Location = new System.Drawing.Point(105, 146);
            this.Login.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(48, 20);
            this.Login.TabIndex = 0;
            this.Login.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 206);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Haslo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(230, 283);
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
            this.textBoxLoginAdmin.Location = new System.Drawing.Point(214, 135);
            this.textBoxLoginAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxLoginAdmin.Name = "textBoxLoginAdmin";
            this.textBoxLoginAdmin.Size = new System.Drawing.Size(148, 26);
            this.textBoxLoginAdmin.TabIndex = 3;
            this.textBoxLoginAdmin.TextChanged += new System.EventHandler(this.textBoxLoginAdmin_TextChanged);
            // 
            // textBoxHasloAdmin
            // 
            this.textBoxHasloAdmin.Location = new System.Drawing.Point(214, 195);
            this.textBoxHasloAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxHasloAdmin.Name = "textBoxHasloAdmin";
            this.textBoxHasloAdmin.Size = new System.Drawing.Size(148, 26);
            this.textBoxHasloAdmin.TabIndex = 4;
            // 
            // checkBoxHasloAdmin
            // 
            this.checkBoxHasloAdmin.AutoSize = true;
            this.checkBoxHasloAdmin.Location = new System.Drawing.Point(374, 205);
            this.checkBoxHasloAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxHasloAdmin.Name = "checkBoxHasloAdmin";
            this.checkBoxHasloAdmin.Size = new System.Drawing.Size(122, 24);
            this.checkBoxHasloAdmin.TabIndex = 5;
            this.checkBoxHasloAdmin.Text = "Pokaż hasło";
            this.checkBoxHasloAdmin.UseVisualStyleBackColor = true;
            this.checkBoxHasloAdmin.CheckedChanged += new System.EventHandler(this.checkBoxHasloAdmin_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(214, 392);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 26);
            this.textBox1.TabIndex = 6;
            // 
            // FormLogowanieAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 505);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.checkBoxHasloAdmin);
            this.Controls.Add(this.textBoxHasloAdmin);
            this.Controls.Add(this.textBoxLoginAdmin);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Login);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormLogowanieAdmin";
            this.Text = "FormLogowanieAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxLoginAdmin;
        private System.Windows.Forms.TextBox textBoxHasloAdmin;
        private System.Windows.Forms.CheckBox checkBoxHasloAdmin;
        private System.Windows.Forms.TextBox textBox1;
    }
}