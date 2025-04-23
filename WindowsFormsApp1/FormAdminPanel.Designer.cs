namespace WindowsFormsApp1
{
    partial class FormPanelAdmin
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button buttonZarzadzajLekarzami;
        private System.Windows.Forms.Button buttonZarzadzajPacjentami;
        private System.Windows.Forms.Button buttonWyloguj; // Dodany przycisk "Wyloguj"
        private System.Windows.Forms.Label label1;

        // Zwalnianie zasobów
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        // Inicjalizowanie komponentów i ustawianie ich właściwości
        private void InitializeComponent()
        {
            this.buttonZarzadzajLekarzami = new System.Windows.Forms.Button();
            this.buttonZarzadzajPacjentami = new System.Windows.Forms.Button();
            this.buttonWyloguj = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonZarzadzajLekarzami
            // 
            this.buttonZarzadzajLekarzami.Location = new System.Drawing.Point(65, 70);
            this.buttonZarzadzajLekarzami.Name = "buttonZarzadzajLekarzami";
            this.buttonZarzadzajLekarzami.Size = new System.Drawing.Size(150, 30);
            this.buttonZarzadzajLekarzami.TabIndex = 0;
            this.buttonZarzadzajLekarzami.Text = "Zarządzaj Lekarzami";
            this.buttonZarzadzajLekarzami.UseVisualStyleBackColor = true;
            this.buttonZarzadzajLekarzami.Click += new System.EventHandler(this.buttonZarzadzajLekarzami_Click);
            // 
            // buttonZarzadzajPacjentami
            // 
            this.buttonZarzadzajPacjentami.Location = new System.Drawing.Point(65, 120);
            this.buttonZarzadzajPacjentami.Name = "buttonZarzadzajPacjentami";
            this.buttonZarzadzajPacjentami.Size = new System.Drawing.Size(150, 30);
            this.buttonZarzadzajPacjentami.TabIndex = 1;
            this.buttonZarzadzajPacjentami.Text = "Zarządzaj Pacjentami";
            this.buttonZarzadzajPacjentami.UseVisualStyleBackColor = true;
            this.buttonZarzadzajPacjentami.Click += new System.EventHandler(this.buttonZarzadzajPacjentami_Click);
            // 
            // buttonWyloguj
            // 
            this.buttonWyloguj.Location = new System.Drawing.Point(65, 160);
            this.buttonWyloguj.Name = "buttonWyloguj";
            this.buttonWyloguj.Size = new System.Drawing.Size(150, 30);
            this.buttonWyloguj.TabIndex = 2;
            this.buttonWyloguj.Text = "Wyloguj";
            this.buttonWyloguj.UseVisualStyleBackColor = true;
            this.buttonWyloguj.Click += new System.EventHandler(this.buttonWyloguj_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(70, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Panel Administratora";
            // 
            // FormPanelAdmin
            // 
            this.ClientSize = new System.Drawing.Size(280, 210);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonWyloguj);
            this.Controls.Add(this.buttonZarzadzajPacjentami);
            this.Controls.Add(this.buttonZarzadzajLekarzami);
            this.Name = "FormPanelAdmin";
            this.Text = "Panel Administratora";
            this.Load += new System.EventHandler(this.FormPanelAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
