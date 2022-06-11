namespace Sah_projekt
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
            this.HostGumb.Location = new System.Drawing.Point(52, 253);
            this.HostGumb.Margin = new System.Windows.Forms.Padding(2);
            this.HostGumb.Name = "HostGumb";
            this.HostGumb.Size = new System.Drawing.Size(226, 44);
            this.HostGumb.TabIndex = 0;
            this.HostGumb.Text = "JAZ BOM HOST";
            this.HostGumb.UseVisualStyleBackColor = true;
            this.HostGumb.Click += new System.EventHandler(this.HostGumb_Click);
            // 
            // IpText
            // 
            this.IpText.Location = new System.Drawing.Point(52, 202);
            this.IpText.Margin = new System.Windows.Forms.Padding(2);
            this.IpText.Name = "IpText";
            this.IpText.Size = new System.Drawing.Size(98, 20);
            this.IpText.TabIndex = 1;
            // 
            // IpGumb
            // 
            this.IpGumb.Location = new System.Drawing.Point(164, 202);
            this.IpGumb.Margin = new System.Windows.Forms.Padding(2);
            this.IpGumb.Name = "IpGumb";
            this.IpGumb.Size = new System.Drawing.Size(116, 46);
            this.IpGumb.TabIndex = 2;
            this.IpGumb.Text = "Poveži se";
            this.IpGumb.UseVisualStyleBackColor = true;
            this.IpGumb.Click += new System.EventHandler(this.IpGumb_Click);
            // 
            // SoloGumb
            // 
            this.SoloGumb.Location = new System.Drawing.Point(52, 69);
            this.SoloGumb.Margin = new System.Windows.Forms.Padding(2);
            this.SoloGumb.Name = "SoloGumb";
            this.SoloGumb.Size = new System.Drawing.Size(226, 41);
            this.SoloGumb.TabIndex = 3;
            this.SoloGumb.Text = "Solo";
            this.SoloGumb.UseVisualStyleBackColor = true;
            this.SoloGumb.Click += new System.EventHandler(this.SoloGumb_Click);
            // 
            // RacunalnikGumb
            // 
            this.RacunalnikGumb.Location = new System.Drawing.Point(300, 69);
            this.RacunalnikGumb.Margin = new System.Windows.Forms.Padding(2);
            this.RacunalnikGumb.Name = "RacunalnikGumb";
            this.RacunalnikGumb.Size = new System.Drawing.Size(226, 41);
            this.RacunalnikGumb.TabIndex = 4;
            this.RacunalnikGumb.Text = "Računalnik";
            this.RacunalnikGumb.UseVisualStyleBackColor = true;
            this.RacunalnikGumb.Click += new System.EventHandler(this.RacunalnikGumb_Click);
            // 
            // Zacetek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 429);
            this.Controls.Add(this.RacunalnikGumb);
            this.Controls.Add(this.SoloGumb);
            this.Controls.Add(this.IpGumb);
            this.Controls.Add(this.IpText);
            this.Controls.Add(this.HostGumb);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Zacetek";
            this.Text = "Zacetek";
            this.Load += new System.EventHandler(this.Zacetek_Load);
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