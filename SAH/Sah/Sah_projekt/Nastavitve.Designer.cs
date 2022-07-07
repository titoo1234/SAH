namespace Sah_projekt
{
    partial class Nastavitve
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ZacetekIgre = new System.Windows.Forms.Button();
            this.Izbrano = new System.Windows.Forms.Label();
            this.IzbranaTema = new System.Windows.Forms.PictureBox();
            this.IzbranaBarva = new System.Windows.Forms.PictureBox();
            this.temaSahovnicaGumb2 = new System.Windows.Forms.Button();
            this.temaSahovnicaGumb1 = new System.Windows.Forms.Button();
            this.CrnaBarva_gumb = new System.Windows.Forms.Button();
            this.BelaBarva_Gumb = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.IzberiCas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IzberiTezavnost = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.IzbranaTema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IzbranaBarva)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(29, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izberi barvo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(500, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Izberi temo:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ZacetekIgre
            // 
            this.ZacetekIgre.BackColor = System.Drawing.Color.Silver;
            this.ZacetekIgre.Font = new System.Drawing.Font("Impact", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZacetekIgre.Location = new System.Drawing.Point(77, 298);
            this.ZacetekIgre.Name = "ZacetekIgre";
            this.ZacetekIgre.Size = new System.Drawing.Size(235, 108);
            this.ZacetekIgre.TabIndex = 4;
            this.ZacetekIgre.Text = "Joža požen";
            this.ZacetekIgre.UseVisualStyleBackColor = false;
            this.ZacetekIgre.Click += new System.EventHandler(this.ZacetekIgre_Click);
            // 
            // Izbrano
            // 
            this.Izbrano.AutoSize = true;
            this.Izbrano.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Izbrano.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Izbrano.Location = new System.Drawing.Point(429, 255);
            this.Izbrano.Name = "Izbrano";
            this.Izbrano.Size = new System.Drawing.Size(215, 24);
            this.Izbrano.TabIndex = 7;
            this.Izbrano.Text = "Izbrana barva in tema:";
            this.Izbrano.Click += new System.EventHandler(this.Izbrano_Click);
            // 
            // IzbranaTema
            // 
            this.IzbranaTema.Image = global::Sah_projekt.Properties.Resources.sahovnica1;
            this.IzbranaTema.Location = new System.Drawing.Point(551, 298);
            this.IzbranaTema.Name = "IzbranaTema";
            this.IzbranaTema.Size = new System.Drawing.Size(146, 140);
            this.IzbranaTema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IzbranaTema.TabIndex = 9;
            this.IzbranaTema.TabStop = false;
            // 
            // IzbranaBarva
            // 
            this.IzbranaBarva.Image = global::Sah_projekt.Properties.Resources.White_Queen;
            this.IzbranaBarva.Location = new System.Drawing.Point(454, 330);
            this.IzbranaBarva.Name = "IzbranaBarva";
            this.IzbranaBarva.Size = new System.Drawing.Size(59, 63);
            this.IzbranaBarva.TabIndex = 8;
            this.IzbranaBarva.TabStop = false;
            // 
            // temaSahovnicaGumb2
            // 
            this.temaSahovnicaGumb2.Image = global::Sah_projekt.Properties.Resources.sahovnica2;
            this.temaSahovnicaGumb2.Location = new System.Drawing.Point(592, 85);
            this.temaSahovnicaGumb2.Name = "temaSahovnicaGumb2";
            this.temaSahovnicaGumb2.Size = new System.Drawing.Size(105, 95);
            this.temaSahovnicaGumb2.TabIndex = 6;
            this.temaSahovnicaGumb2.UseVisualStyleBackColor = true;
            this.temaSahovnicaGumb2.Click += new System.EventHandler(this.temaSahovnicaGumb2_Click);
            // 
            // temaSahovnicaGumb1
            // 
            this.temaSahovnicaGumb1.Image = global::Sah_projekt.Properties.Resources.sahovnica1;
            this.temaSahovnicaGumb1.Location = new System.Drawing.Point(454, 85);
            this.temaSahovnicaGumb1.Name = "temaSahovnicaGumb1";
            this.temaSahovnicaGumb1.Size = new System.Drawing.Size(104, 95);
            this.temaSahovnicaGumb1.TabIndex = 5;
            this.temaSahovnicaGumb1.UseVisualStyleBackColor = true;
            this.temaSahovnicaGumb1.Click += new System.EventHandler(this.temaSahovnicaGumb1_Click);
            // 
            // CrnaBarva_gumb
            // 
            this.CrnaBarva_gumb.BackColor = System.Drawing.Color.Transparent;
            this.CrnaBarva_gumb.BackgroundImage = global::Sah_projekt.Properties.Resources.Black_Queen;
            this.CrnaBarva_gumb.Location = new System.Drawing.Point(125, 116);
            this.CrnaBarva_gumb.Name = "CrnaBarva_gumb";
            this.CrnaBarva_gumb.Size = new System.Drawing.Size(61, 66);
            this.CrnaBarva_gumb.TabIndex = 2;
            this.CrnaBarva_gumb.UseVisualStyleBackColor = false;
            this.CrnaBarva_gumb.Click += new System.EventHandler(this.CrnaBarva_Gumb_Click);
            // 
            // BelaBarva_Gumb
            // 
            this.BelaBarva_Gumb.BackgroundImage = global::Sah_projekt.Properties.Resources.White_Queen;
            this.BelaBarva_Gumb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BelaBarva_Gumb.Location = new System.Drawing.Point(23, 116);
            this.BelaBarva_Gumb.Name = "BelaBarva_Gumb";
            this.BelaBarva_Gumb.Size = new System.Drawing.Size(62, 66);
            this.BelaBarva_Gumb.TabIndex = 1;
            this.BelaBarva_Gumb.UseVisualStyleBackColor = true;
            this.BelaBarva_Gumb.Click += new System.EventHandler(this.BelaBarva_Gumb_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(267, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "Izberi čas:";
            // 
            // IzberiCas
            // 
            this.IzberiCas.FormattingEnabled = true;
            this.IzberiCas.Items.AddRange(new object[] {
            "1",
            "3",
            "5",
            "10"});
            this.IzberiCas.Location = new System.Drawing.Point(271, 85);
            this.IzberiCas.Name = "IzberiCas";
            this.IzberiCas.Size = new System.Drawing.Size(121, 21);
            this.IzberiCas.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(267, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "Izberi težavnost:";
            // 
            // IzberiTezavnost
            // 
            this.IzberiTezavnost.FormattingEnabled = true;
            this.IzberiTezavnost.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.IzberiTezavnost.Location = new System.Drawing.Point(271, 205);
            this.IzberiTezavnost.Name = "IzberiTezavnost";
            this.IzberiTezavnost.Size = new System.Drawing.Size(121, 21);
            this.IzberiTezavnost.TabIndex = 11;
            // 
            // Nastavitve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 450);
            this.Controls.Add(this.IzberiTezavnost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IzberiCas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IzbranaTema);
            this.Controls.Add(this.IzbranaBarva);
            this.Controls.Add(this.Izbrano);
            this.Controls.Add(this.temaSahovnicaGumb2);
            this.Controls.Add(this.temaSahovnicaGumb1);
            this.Controls.Add(this.ZacetekIgre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CrnaBarva_gumb);
            this.Controls.Add(this.BelaBarva_Gumb);
            this.Controls.Add(this.label1);
            this.Name = "Nastavitve";
            this.Text = "Nastavitve";
            this.Load += new System.EventHandler(this.Nastavitve_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IzbranaTema)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IzbranaBarva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CrnaBarva_gumb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ZacetekIgre;
        private System.Windows.Forms.Button temaSahovnicaGumb1;
        private System.Windows.Forms.Button temaSahovnicaGumb2;
        private System.Windows.Forms.Button BelaBarva_Gumb;
        private System.Windows.Forms.Label Izbrano;
        private System.Windows.Forms.PictureBox IzbranaBarva;
        private System.Windows.Forms.PictureBox IzbranaTema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox IzberiCas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox IzberiTezavnost;
    }
}