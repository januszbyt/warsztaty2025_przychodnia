using System.Windows.Forms;
using System;

namespace WindowsFormsApp1
{
    partial class FormPowiadomiania
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
            this.lblSmtpHost.Location = new System.Drawing.Point(10, 10);
            this.lblSmtpHost.Name = "lblSmtpHost";
            this.lblSmtpHost.Size = new System.Drawing.Size(93, 16);
            this.lblSmtpHost.TabIndex = 0;
            this.lblSmtpHost.Text = "Serwer SMTP:";
            // 
            // txtSmtpHost
            // 
            this.txtSmtpHost.Location = new System.Drawing.Point(137, 12);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(200, 22);
            this.txtSmtpHost.TabIndex = 1;
            // 
            // lblSmtpPort
            // 
            this.lblSmtpPort.AutoSize = true;
            this.lblSmtpPort.Location = new System.Drawing.Point(10, 40);
            this.lblSmtpPort.Name = "lblSmtpPort";
            this.lblSmtpPort.Size = new System.Drawing.Size(75, 16);
            this.lblSmtpPort.TabIndex = 2;
            this.lblSmtpPort.Text = "Port SMTP:";
            // 
            // txtSmtpPort
            // 
            this.txtSmtpPort.Location = new System.Drawing.Point(137, 42);
            this.txtSmtpPort.Name = "txtSmtpPort";
            this.txtSmtpPort.Size = new System.Drawing.Size(200, 22);
            this.txtSmtpPort.TabIndex = 3;
            // 
            // lblSmtpUser
            // 
            this.lblSmtpUser.AutoSize = true;
            this.lblSmtpUser.Location = new System.Drawing.Point(10, 70);
            this.lblSmtpUser.Name = "lblSmtpUser";
            this.lblSmtpUser.Size = new System.Drawing.Size(84, 16);
            this.lblSmtpUser.TabIndex = 4;
            this.lblSmtpUser.Text = "Login SMTP:";
            // 
            // txtSmtpUser
            // 
            this.txtSmtpUser.Location = new System.Drawing.Point(137, 72);
            this.txtSmtpUser.Name = "txtSmtpUser";
            this.txtSmtpUser.Size = new System.Drawing.Size(200, 22);
            this.txtSmtpUser.TabIndex = 5;
            // 
            // lblSmtpPassword
            // 
            this.lblSmtpPassword.AutoSize = true;
            this.lblSmtpPassword.Location = new System.Drawing.Point(10, 100);
            this.lblSmtpPassword.Name = "lblSmtpPassword";
            this.lblSmtpPassword.Size = new System.Drawing.Size(90, 16);
            this.lblSmtpPassword.TabIndex = 6;
            this.lblSmtpPassword.Text = "Hasło SMTP:";
            // 
            // txtSmtpPassword
            // 
            this.txtSmtpPassword.Location = new System.Drawing.Point(137, 102);
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.PasswordChar = '*';
            this.txtSmtpPassword.Size = new System.Drawing.Size(200, 22);
            this.txtSmtpPassword.TabIndex = 7;
            // 
            // btnUpdateSmtp
            // 
            this.btnUpdateSmtp.Location = new System.Drawing.Point(365, 10);
            this.btnUpdateSmtp.Name = "btnUpdateSmtp";
            this.btnUpdateSmtp.Size = new System.Drawing.Size(150, 50);
            this.btnUpdateSmtp.TabIndex = 0;
            this.btnUpdateSmtp.Text = "Aktualizuj ustawienia SMTP";
            this.btnUpdateSmtp.UseVisualStyleBackColor = true;
            this.btnUpdateSmtp.Click += new System.EventHandler(this.btnUpdateSmtp_Click);
            // 
            // lblNotificationType
            // 
            this.lblNotificationType.AutoSize = true;
            this.lblNotificationType.Location = new System.Drawing.Point(10, 130);
            this.lblNotificationType.Name = "lblNotificationType";
            this.lblNotificationType.Size = new System.Drawing.Size(148, 16);
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
            this.cbNotificationType.Location = new System.Drawing.Point(187, 130);
            this.cbNotificationType.Name = "cbNotificationType";
            this.cbNotificationType.Size = new System.Drawing.Size(150, 24);
            this.cbNotificationType.TabIndex = 9;
            this.cbNotificationType.SelectedIndexChanged += new System.EventHandler(this.cbNotificationType_SelectedIndexChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(10, 160);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.Size = new System.Drawing.Size(760, 200);
            this.dgvData.TabIndex = 10;
            this.dgvData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellContentClick_1);
            // 
            // btnSendNotifications
            // 
            this.btnSendNotifications.Location = new System.Drawing.Point(10, 370);
            this.btnSendNotifications.Name = "btnSendNotifications";
            this.btnSendNotifications.Size = new System.Drawing.Size(150, 30);
            this.btnSendNotifications.TabIndex = 1;
            this.btnSendNotifications.Text = "Wyślij powiadomienia";
            this.btnSendNotifications.UseVisualStyleBackColor = true;
            this.btnSendNotifications.Click += new System.EventHandler(this.btnSendNotifications_Click);
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
            // FormPowiadomiania
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 577);
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
            this.Name = "FormPowiadomiania";
            this.Text = "FormPowiadomienia";
            this.Load += new System.EventHandler(this.FormPowiadomiania_Load);
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

        private void btnUpdateSmtp_Click(object sender, EventArgs e)
        {
            try
            {
                smtpHost = txtSmtpHost.Text.Trim();
                smtpPort = int.Parse(txtSmtpPort.Text.Trim());
                smtpUser = txtSmtpUser.Text.Trim();
                smtpPassword = txtSmtpPassword.Text.Trim();
                if (string.IsNullOrWhiteSpace(smtpHost) || smtpPort == 0 || string.IsNullOrWhiteSpace(smtpUser) || string.IsNullOrWhiteSpace(smtpPassword))
                {
                    LogMessage("Wszystkie pola SMTP muszą być wypełnione.");
                    return;
                }
                LogMessage($"Ustawienia SMTP zaktualizowane: {smtpHost}:{smtpPort}, login: {smtpUser}");
            }
            catch (Exception ex)
            {
                LogMessage($"Błąd aktualizacji ustawień SMTP: {ex.Message}");
            }
        }

        private void cbNotificationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridView(cbNotificationType.SelectedItem.ToString());
        }

        private void btnSendNotifications_Click(object sender, EventArgs e)
        {
            SendNotifications(cbNotificationType.SelectedItem.ToString());
        }
    }
}