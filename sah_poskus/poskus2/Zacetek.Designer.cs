namespace poskus2
{
    partial class Zacetek
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
            this.HostGumb = new System.Windows.Forms.Button();
            this.IpText = new System.Windows.Forms.TextBox();
            this.IpGumb = new System.Windows.Forms.Button();
            this.SoloGumb = new System.Windows.Forms.Button();
            this.RacunalnikGumb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HostGumb
            // 
            this.HostGumb.Location = new System.Drawing.Point(70, 311);
            this.HostGumb.Name = "HostGumb";
            this.HostGumb.Size = new System.Drawing.Size(302, 54);
            this.HostGumb.TabIndex = 0;
            this.HostGumb.Text = "JAZ BOM HOST";
            this.HostGumb.UseVisualStyleBackColor = true;
            this.HostGumb.Click += new System.EventHandler(this.HostGumb_Click);
            // 
            // IpText
            // 
            this.IpText.Location = new System.Drawing.Point(70, 248);
            this.IpText.Name = "IpText";
            this.IpText.Size = new System.Drawing.Size(129, 22);
            this.IpText.TabIndex = 1;
            // 
            // IpGumb
            // 
            this.IpGumb.Location = new System.Drawing.Point(218, 248);
            this.IpGumb.Name = "IpGumb";
            this.IpGumb.Size = new System.Drawing.Size(154, 57);
            this.IpGumb.TabIndex = 2;
            this.IpGumb.Text = "Poveži se";
            this.IpGumb.UseVisualStyleBackColor = true;
            this.IpGumb.Click += new System.EventHandler(this.IpGumb_Click);
            // 
            // SoloGumb
            // 
            this.SoloGumb.Location = new System.Drawing.Point(70, 85);
            this.SoloGumb.Name = "SoloGumb";
            this.SoloGumb.Size = new System.Drawing.Size(302, 50);
            this.SoloGumb.TabIndex = 3;
            this.SoloGumb.Text = "Solo";
            this.SoloGumb.UseVisualStyleBackColor = true;
            this.SoloGumb.Click += new System.EventHandler(this.SoloGumb_Click);
            // 
            // RacunalnikGumb
            // 
            this.RacunalnikGumb.Location = new System.Drawing.Point(400, 85);
            this.RacunalnikGumb.Name = "RacunalnikGumb";
            this.RacunalnikGumb.Size = new System.Drawing.Size(302, 50);
            this.RacunalnikGumb.TabIndex = 4;
            this.RacunalnikGumb.Text = "Računalnik";
            this.RacunalnikGumb.UseVisualStyleBackColor = true;
            this.RacunalnikGumb.Click += new System.EventHandler(this.RacunalnikGumb_Click);
            // 
            // Zacetek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RacunalnikGumb);
            this.Controls.Add(this.SoloGumb);
            this.Controls.Add(this.IpGumb);
            this.Controls.Add(this.IpText);
            this.Controls.Add(this.HostGumb);
            this.Name = "Zacetek";
            this.Text = "Zacetek";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button HostGumb;
        private System.Windows.Forms.TextBox IpText;
        private System.Windows.Forms.Button IpGumb;
        private System.Windows.Forms.Button SoloGumb;
        private System.Windows.Forms.Button RacunalnikGumb;
    }
}