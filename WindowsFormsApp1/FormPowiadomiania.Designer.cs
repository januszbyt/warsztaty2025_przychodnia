using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class FormPowiadomienia
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
            this.lblSmtpHost = new System.Windows.Forms.Label();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.lblSmtpPort = new System.Windows.Forms.Label();
            this.txtSmtpPort = new System.Windows.Forms.TextBox();
            this.lblSmtpUser = new System.Windows.Forms.Label();
            this.txtSmtpUser = new System.Windows.Forms.TextBox();
            this.lblSmtpPassword = new System.Windows.Forms.Label();
            this.txtSmtpPassword = new System.Windows.Forms.TextBox();
            this.btnUpdateSmtp = new System.Windows.Forms.Button();
            this.lblNotificationType = new System.Windows.Forms.Label();
            this.cbNotificationType = new System.Windows.Forms.ComboBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnSendNotifications = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSmtpHost
            // 
            this.lblSmtpHost.AutoSize = true;
            this.lblSmtpHost.Location = new System.Drawing.Point(12, 10);
            this.lblSmtpHost.Name = "lblSmtpHost";
            this.lblSmtpHost.Size = new System.Drawing.Size(110, 20);
            this.lblSmtpHost.TabIndex = 0;
            this.lblSmtpHost.Text = "Serwer SMTP:";
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Location = new System.Drawing.Point(168, 10);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(200, 26);
            this.txtSmtpHost.TabIndex = 1;
            // 
            // lblSmtpPort
            // 
            this.lblSmtpPort.AutoSize = true;
            this.lblSmtpPort.Location = new System.Drawing.Point(12, 42);
            this.lblSmtpPort.Name = "lblSmtpPort";
            this.lblSmtpPort.Size = new System.Drawing.Size(89, 20);
            this.lblSmtpPort.TabIndex = 2;
            this.lblSmtpPort.Text = "Port SMTP:";
            // 
            // txtSmtpPort
            // 
            this.txtSmtpPort.Location = new System.Drawing.Point(168, 42);
            this.txtSmtpPort.Name = "txtSmtpPort";
            this.txtSmtpPort.Size = new System.Drawing.Size(200, 26);
            this.txtSmtpPort.TabIndex = 3;
            // 
            // lblSmtpUser
            // 
            this.lblSmtpUser.AutoSize = true;
            this.lblSmtpUser.Location = new System.Drawing.Point(10, 70);
            this.lblSmtpUser.Name = "lblSmtpUser";
            this.lblSmtpUser.Size = new System.Drawing.Size(99, 20);
            this.lblSmtpUser.TabIndex = 4;
            this.lblSmtpUser.Text = "Login SMTP:";
            // 
            // txtSmtpUser
            // 
            this.txtSmtpUser.Location = new System.Drawing.Point(168, 74);
            this.txtSmtpUser.Name = "txtSmtpUser";
            this.txtSmtpUser.Size = new System.Drawing.Size(200, 26);
            this.txtSmtpUser.TabIndex = 5;
            // 
            // lblSmtpPassword
            // 
            this.lblSmtpPassword.AutoSize = true;
            this.lblSmtpPassword.Location = new System.Drawing.Point(10, 100);
            this.lblSmtpPassword.Name = "lblSmtpPassword";
            this.lblSmtpPassword.Size = new System.Drawing.Size(102, 20);
            this.lblSmtpPassword.TabIndex = 6;
            this.lblSmtpPassword.Text = "Hasło SMTP:";
            // 
            // txtSmtpPassword
            // 
            this.txtSmtpPassword.Location = new System.Drawing.Point(168, 106);
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.PasswordChar = '*';
            this.txtSmtpPassword.Size = new System.Drawing.Size(200, 26);
            this.txtSmtpPassword.TabIndex = 7;
            // 
            // btnUpdateSmtp
            // 
            this.btnUpdateSmtp.Location = new System.Drawing.Point(397, 10);
            this.btnUpdateSmtp.Name = "btnUpdateSmtp";
            this.btnUpdateSmtp.Size = new System.Drawing.Size(150, 50);
            this.btnUpdateSmtp.TabIndex = 0;
            this.btnUpdateSmtp.Text = "Aktualizuj ustawienia SMTP";
            this.btnUpdateSmtp.UseVisualStyleBackColor = true;
            // 
            // lblNotificationType
            // 
            this.lblNotificationType.AutoSize = true;
            this.lblNotificationType.Location = new System.Drawing.Point(10, 130);
            this.lblNotificationType.Name = "lblNotificationType";
            this.lblNotificationType.Size = new System.Drawing.Size(172, 20);
            this.lblNotificationType.TabIndex = 8;
            this.lblNotificationType.Text = "Rodzaj powiadomienia:";
            // 
            // cbNotificationType
            // 
            this.cbNotificationType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbNotificationType.Items.AddRange(new object[] {
            "wizyta",
            "recepta",
            "skierowanie",
            "dokument",
            "opinia"});
            this.cbNotificationType.Location = new System.Drawing.Point(188, 138);
            this.cbNotificationType.Name = "cbNotificationType";
            this.cbNotificationType.Size = new System.Drawing.Size(150, 28);
            this.cbNotificationType.TabIndex = 9;
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(10, 160);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 62;
            this.dgvData.Size = new System.Drawing.Size(760, 200);
            this.dgvData.TabIndex = 10;
            // 
            // btnSendNotifications
            // 
            this.btnSendNotifications.Location = new System.Drawing.Point(10, 370);
            this.btnSendNotifications.Name = "btnSendNotifications";
            this.btnSendNotifications.Size = new System.Drawing.Size(150, 30);
            this.btnSendNotifications.TabIndex = 1;
            this.btnSendNotifications.Text = "Wyślij powiadomienia";
            this.btnSendNotifications.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(10, 410);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(760, 150);
            this.txtLog.TabIndex = 11;
            // 
            // FormPowiadomienia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblSmtpHost);
            this.Controls.Add(this.txtSmtpHost);
            this.Controls.Add(this.lblSmtpPort);
            this.Controls.Add(this.txtSmtpPort);
            this.Controls.Add(this.lblSmtpUser);
            this.Controls.Add(this.txtSmtpUser);
            this.Controls.Add(this.lblSmtpPassword);
            this.Controls.Add(this.txtSmtpPassword);
            this.Controls.Add(this.btnUpdateSmtp);
            this.Controls.Add(this.lblNotificationType);
            this.Controls.Add(this.cbNotificationType);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnSendNotifications);
            this.Controls.Add(this.txtLog);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPowiadomienia";
            this.Text = "FormPowiadomienia";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSmtpHost;
        private System.Windows.Forms.TextBox txtSmtpHost;
        private System.Windows.Forms.Label lblSmtpPort;
        private System.Windows.Forms.TextBox txtSmtpPort;
        private System.Windows.Forms.Label lblSmtpUser;
        private System.Windows.Forms.TextBox txtSmtpUser;
        private System.Windows.Forms.Label lblSmtpPassword;
        private System.Windows.Forms.TextBox txtSmtpPassword;
        private System.Windows.Forms.Button btnUpdateSmtp;
        private System.Windows.Forms.Label lblNotificationType;
        private System.Windows.Forms.ComboBox cbNotificationType;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnSendNotifications;
        private System.Windows.Forms.TextBox txtLog;
    }
}