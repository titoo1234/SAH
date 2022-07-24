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
            this.PredajaGumb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Igralec1_Cas
            // 
            this.Igralec1_Cas.AutoSize = true;
            this.Igralec1_Cas.Font = new System.Drawing.Font("Times New Roman", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Igralec1_Cas.Location = new System.Drawing.Point(381, 340);
            this.Igralec1_Cas.Name = "Igralec1_Cas";
            this.Igralec1_Cas.Size = new System.Drawing.Size(51, 38);
            this.Igralec1_Cas.TabIndex = 1;
            this.Igralec1_Cas.Text = "39";
            // 
            // Igralec2_Cas
            // 
            this.Igralec2_Cas.AutoSize = true;
            this.Igralec2_Cas.Font = new System.Drawing.Font("Times New Roman", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Igralec2_Cas.Location = new System.Drawing.Point(381, 44);
            this.Igralec2_Cas.Name = "Igralec2_Cas";
            this.Igralec2_Cas.Size = new System.Drawing.Size(51, 38);
            this.Igralec2_Cas.TabIndex = 2;
            this.Igralec2_Cas.Text = "39";
            // 
            // KonecIgreLabel
            // 
            this.KonecIgreLabel.AutoSize = true;
            this.KonecIgreLabel.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.KonecIgreLabel.Location = new System.Drawing.Point(432, 204);
            this.KonecIgreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.KonecIgreLabel.Name = "KonecIgreLabel";
            this.KonecIgreLabel.Size = new System.Drawing.Size(0, 37);
            this.KonecIgreLabel.TabIndex = 3;
            // 
            // PredajaGumb
            // 
            this.PredajaGumb.Font = new System.Drawing.Font("Impact", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PredajaGumb.Location = new System.Drawing.Point(664, 352);
            this.PredajaGumb.Name = "PredajaGumb";
            this.PredajaGumb.Size = new System.Drawing.Size(88, 58);
            this.PredajaGumb.TabIndex = 4;
            this.PredajaGumb.Text = "PREDAJ IGRO";
            this.PredajaGumb.UseVisualStyleBackColor = true;
            this.PredajaGumb.Visible = false;
            this.PredajaGumb.Click += new System.EventHandler(this.PredajaGumb_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(764, 422);
            this.Controls.Add(this.PredajaGumb);
            this.Controls.Add(this.KonecIgreLabel);
            this.Controls.Add(this.Igralec2_Cas);
            this.Controls.Add(this.Igralec1_Cas);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximumSize = new System.Drawing.Size(782, 469);
            this.MinimumSize = new System.Drawing.Size(782, 469);
            this.Name = "Game";
            this.Text = "ŠAH ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label Igralec1_Cas;
        public System.Windows.Forms.Label Igralec2_Cas;
        public System.Windows.Forms.Label KonecIgreLabel;
        public System.Windows.Forms.Button PredajaGumb;
    }
}

