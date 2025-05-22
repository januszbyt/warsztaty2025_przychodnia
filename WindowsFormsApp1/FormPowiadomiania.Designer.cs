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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Text = "FormPowiadomienia";
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Kontrolki dla ustawień SMTP
            this.lblSmtpHost = new System.Windows.Forms.Label();
            this.txtSmtpHost = new System.Windows.Forms.TextBox();
            this.lblSmtpPort = new System.Windows.Forms.Label();
            this.txtSmtpPort = new System.Windows.Forms.TextBox();
            this.lblSmtpUser = new System.Windows.Forms.Label();
            this.txtSmtpUser = new System.Windows.Forms.TextBox();
            this.lblSmtpPassword = new System.Windows.Forms.Label();
            this.txtSmtpPassword = new System.Windows.Forms.TextBox();
            this.btnUpdateSmtp = new System.Windows.Forms.Button();

            // Wybór rodzaju powiadomienia
            this.lblNotificationType = new System.Windows.Forms.Label();
            this.cbNotificationType = new System.Windows.Forms.ComboBox();

            // DataGridView dla rekordów
            this.dgvData = new System.Windows.Forms.DataGridView();

            // Przycisk do wysyłania powiadomień
            this.btnSendNotifications = new System.Windows.Forms.Button();

            // Logi
            this.txtLog = new System.Windows.Forms.TextBox();

            // Ustawienia kontrolek
            this.lblSmtpHost.AutoSize = true;
            this.lblSmtpHost.Location = new System.Drawing.Point(10, 10);
            this.lblSmtpHost.Name = "lblSmtpHost";
            this.lblSmtpHost.Text = "Serwer SMTP:";

            this.txtSmtpHost.Location = new System.Drawing.Point(100, 10);
            this.txtSmtpHost.Name = "txtSmtpHost";
            this.txtSmtpHost.Size = new System.Drawing.Size(200, 20);
            this.txtSmtpHost.Text = "";

            this.lblSmtpPort.AutoSize = true;
            this.lblSmtpPort.Location = new System.Drawing.Point(10, 40);
            this.lblSmtpPort.Name = "lblSmtpPort";
            this.lblSmtpPort.Text = "Port SMTP:";

            this.txtSmtpPort.Location = new System.Drawing.Point(100, 40);
            this.txtSmtpPort.Name = "txtSmtpPort";
            this.txtSmtpPort.Size = new System.Drawing.Size(200, 20);
            this.txtSmtpPort.Text = "";

            this.lblSmtpUser.AutoSize = true;
            this.lblSmtpUser.Location = new System.Drawing.Point(10, 70);
            this.lblSmtpUser.Name = "lblSmtpUser";
            this.lblSmtpUser.Text = "Login SMTP:";

            this.txtSmtpUser.Location = new System.Drawing.Point(100, 70);
            this.txtSmtpUser.Name = "txtSmtpUser";
            this.txtSmtpUser.Size = new System.Drawing.Size(200, 20);
            this.txtSmtpUser.Text = "";

            this.lblSmtpPassword.AutoSize = true;
            this.lblSmtpPassword.Location = new System.Drawing.Point(10, 100);
            this.lblSmtpPassword.Name = "lblSmtpPassword";
            this.lblSmtpPassword.Text = "Hasło SMTP:";

            this.txtSmtpPassword.Location = new System.Drawing.Point(100, 100);
            this.txtSmtpPassword.Name = "txtSmtpPassword";
            this.txtSmtpPassword.Size = new System.Drawing.Size(200, 20);
            this.txtSmtpPassword.Text = "";
            this.txtSmtpPassword.PasswordChar = '*';

            this.btnUpdateSmtp.Location = new System.Drawing.Point(310, 10);
            this.btnUpdateSmtp.Name = "btnUpdateSmtp";
            this.btnUpdateSmtp.Size = new System.Drawing.Size(150, 50);
            this.btnUpdateSmtp.TabIndex = 0;
            this.btnUpdateSmtp.Text = "Aktualizuj ustawienia SMTP";
            this.btnUpdateSmtp.UseVisualStyleBackColor = true;

            this.lblNotificationType.AutoSize = true;
            this.lblNotificationType.Location = new System.Drawing.Point(10, 130);
            this.lblNotificationType.Name = "lblNotificationType";
            this.lblNotificationType.Text = "Rodzaj powiadomienia:";

            this.cbNotificationType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbNotificationType.Items.AddRange(new string[] { "wizyta", "recepta", "skierowanie", "dokument", "opinia" });
            this.cbNotificationType.Location = new System.Drawing.Point(150, 130);
            this.cbNotificationType.Name = "cbNotificationType";
            this.cbNotificationType.Size = new System.Drawing.Size(150, 21);
            this.cbNotificationType.SelectedIndex = 0;

            this.dgvData.Location = new System.Drawing.Point(10, 160);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(760, 200);
            this.dgvData.ReadOnly = true;
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.btnSendNotifications.Location = new System.Drawing.Point(10, 370);
            this.btnSendNotifications.Name = "btnSendNotifications";
            this.btnSendNotifications.Size = new System.Drawing.Size(150, 30);
            this.btnSendNotifications.TabIndex = 1;
            this.btnSendNotifications.Text = "Wyślij powiadomienia";
            this.btnSendNotifications.UseVisualStyleBackColor = true;

            this.txtLog.Location = new System.Drawing.Point(10, 410);
            this.txtLog.Name = "txtLog";
            this.txtLog.Multiline = true;
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(760, 150);

            // Dodanie kontrolek do formularza
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