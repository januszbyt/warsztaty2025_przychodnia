namespace WindowsFormsApp1
{
    partial class FormZarzadzajLekarzami
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(65, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zarządzanie Lekarzami";
            // 
            // FormZarzadzajLekarzami
            // 
            this.ClientSize = new System.Drawing.Size(270, 150);
            this.Controls.Add(this.label1);
            this.Name = "FormZarzadzajLekarzami";
            this.Text = "Lekarze";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
