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
            this.NapisMultiplayer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HostGumb
            // 
            this.HostGumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.HostGumb.Location = new System.Drawing.Point(55, 222);
            this.HostGumb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HostGumb.Name = "HostGumb";
            this.HostGumb.Size = new System.Drawing.Size(225, 47);
            this.HostGumb.TabIndex = 0;
            this.HostGumb.Text = "Začni igro";
            this.HostGumb.UseVisualStyleBackColor = true;
            this.HostGumb.Click += new System.EventHandler(this.HostGumb_Click);
            // 
            // IpText
            // 
            this.IpText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IpText.Location = new System.Drawing.Point(55, 345);
            this.IpText.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IpText.Name = "IpText";
            this.IpText.Size = new System.Drawing.Size(225, 21);
            this.IpText.TabIndex = 1;
            this.IpText.Text = "Vpiši IP naslov";
            this.IpText.Click += new System.EventHandler(this.IpText_Click);
            // 
            // IpGumb
            // 
            this.IpGumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IpGumb.Location = new System.Drawing.Point(55, 293);
            this.IpGumb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.IpGumb.Name = "IpGumb";
            this.IpGumb.Size = new System.Drawing.Size(225, 48);
            this.IpGumb.TabIndex = 2;
            this.IpGumb.Text = "Poveži se";
            this.IpGumb.UseVisualStyleBackColor = true;
            this.IpGumb.Click += new System.EventHandler(this.IpGumb_Click);
            // 
            // SoloGumb
            // 
            this.SoloGumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SoloGumb.Location = new System.Drawing.Point(490, 35);
            this.SoloGumb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SoloGumb.Name = "SoloGumb";
            this.SoloGumb.Size = new System.Drawing.Size(225, 44);
            this.SoloGumb.TabIndex = 3;
            this.SoloGumb.Text = "Solo";
            this.SoloGumb.UseVisualStyleBackColor = true;
            this.SoloGumb.Click += new System.EventHandler(this.SoloGumb_Click);
            // 
            // RacunalnikGumb
            // 
            this.RacunalnikGumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RacunalnikGumb.Location = new System.Drawing.Point(490, 94);
            this.RacunalnikGumb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.RacunalnikGumb.Name = "RacunalnikGumb";
            this.RacunalnikGumb.Size = new System.Drawing.Size(225, 44);
            this.RacunalnikGumb.TabIndex = 4;
            this.RacunalnikGumb.Text = "Računalnik";
            this.RacunalnikGumb.UseVisualStyleBackColor = true;
            this.RacunalnikGumb.Click += new System.EventHandler(this.RacunalnikGumb_Click);
            // 
            // NapisMultiplayer
            // 
            this.NapisMultiplayer.BackColor = System.Drawing.Color.Transparent;
            this.NapisMultiplayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NapisMultiplayer.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.NapisMultiplayer.Location = new System.Drawing.Point(59, 176);
            this.NapisMultiplayer.Name = "NapisMultiplayer";
            this.NapisMultiplayer.Size = new System.Drawing.Size(221, 33);
            this.NapisMultiplayer.TabIndex = 5;
            this.NapisMultiplayer.Text = "MULTIPLAYER";
            // 
            // Zacetek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sah_projekt.Properties.Resources.naslovnaSlika;
            this.ClientSize = new System.Drawing.Size(793, 430);
            this.Controls.Add(this.NapisMultiplayer);
            this.Controls.Add(this.RacunalnikGumb);
            this.Controls.Add(this.SoloGumb);
            this.Controls.Add(this.IpGumb);
            this.Controls.Add(this.IpText);
            this.Controls.Add(this.HostGumb);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Label NapisMultiplayer;
    }
}