namespace Sah_projekt
{
    partial class Game
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
            this.Igralec1_Cas = new System.Windows.Forms.Label();
            this.Igralec2_Cas = new System.Windows.Forms.Label();
            this.KonecIgreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Igralec1_Cas
            // 
            this.Igralec1_Cas.AutoSize = true;
            this.Igralec1_Cas.Font = new System.Drawing.Font("Times New Roman", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Igralec1_Cas.Location = new System.Drawing.Point(1052, 619);
            this.Igralec1_Cas.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Igralec1_Cas.Name = "Igralec1_Cas";
            this.Igralec1_Cas.Size = new System.Drawing.Size(81, 61);
            this.Igralec1_Cas.TabIndex = 1;
            this.Igralec1_Cas.Text = "39";
            // 
            // Igralec2_Cas
            // 
            this.Igralec2_Cas.AutoSize = true;
            this.Igralec2_Cas.Font = new System.Drawing.Font("Times New Roman", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Igralec2_Cas.Location = new System.Drawing.Point(1052, 125);
            this.Igralec2_Cas.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Igralec2_Cas.Name = "Igralec2_Cas";
            this.Igralec2_Cas.Size = new System.Drawing.Size(81, 61);
            this.Igralec2_Cas.TabIndex = 2;
            this.Igralec2_Cas.Text = "39";
            // 
            // KonecIgreLabel
            // 
            this.KonecIgreLabel.AutoSize = true;
            this.KonecIgreLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KonecIgreLabel.Location = new System.Drawing.Point(864, 393);
            this.KonecIgreLabel.Name = "KonecIgreLabel";
            this.KonecIgreLabel.Size = new System.Drawing.Size(0, 60);
            this.KonecIgreLabel.TabIndex = 3;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(1527, 811);
            this.Controls.Add(this.KonecIgreLabel);
            this.Controls.Add(this.Igralec2_Cas);
            this.Controls.Add(this.Igralec1_Cas);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Game";
            this.Text = "ŠAH ;-)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label Igralec1_Cas;
        public System.Windows.Forms.Label Igralec2_Cas;
        public System.Windows.Forms.Label KonecIgreLabel;
    }
}

