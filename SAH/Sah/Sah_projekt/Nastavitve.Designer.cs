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
            this.label3 = new System.Windows.Forms.Label();
            this.IzberiCas = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IzberiTezavnost = new System.Windows.Forms.ComboBox();
            this.temaSahovnicaGumb4 = new System.Windows.Forms.Button();
            this.temaSahovnicaGumb3 = new System.Windows.Forms.Button();
            this.IzbranaTema = new System.Windows.Forms.PictureBox();
            this.IzbranaBarva = new System.Windows.Forms.PictureBox();
            this.temaSahovnicaGumb2 = new System.Windows.Forms.Button();
            this.temaSahovnicaGumb1 = new System.Windows.Forms.Button();
            this.CrnaBarva_gumb = new System.Windows.Forms.Button();
            this.BelaBarva_Gumb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IzbranaTema)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IzbranaBarva)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(570, 394);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izberi barvo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(564, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Izberi temo:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ZacetekIgre
            // 
            this.ZacetekIgre.BackColor = System.Drawing.Color.Silver;
            this.ZacetekIgre.Font = new System.Drawing.Font("Impact", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ZacetekIgre.Location = new System.Drawing.Point(1, 312);
            this.ZacetekIgre.Margin = new System.Windows.Forms.Padding(4);
            this.ZacetekIgre.Name = "ZacetekIgre";
            this.ZacetekIgre.Size = new System.Drawing.Size(313, 240);
            this.ZacetekIgre.TabIndex = 4;
            this.ZacetekIgre.Text = "ZAČNI IGRO";
            this.ZacetekIgre.UseVisualStyleBackColor = false;
            this.ZacetekIgre.Click += new System.EventHandler(this.ZacetekIgre_Click);
            // 
            // Izbrano
            // 
            this.Izbrano.AutoSize = true;
            this.Izbrano.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Izbrano.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Izbrano.Location = new System.Drawing.Point(13, 29);
            this.Izbrano.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Izbrano.Name = "Izbrano";
            this.Izbrano.Size = new System.Drawing.Size(268, 29);
            this.Izbrano.TabIndex = 7;
            this.Izbrano.Text = "Izbrana barva in tema:";
            this.Izbrano.Click += new System.EventHandler(this.Izbrano_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(323, 455);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 29);
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
            this.IzberiCas.Location = new System.Drawing.Point(328, 505);
            this.IzberiCas.Margin = new System.Windows.Forms.Padding(4);
            this.IzberiCas.Name = "IzberiCas";
            this.IzberiCas.Size = new System.Drawing.Size(160, 24);
            this.IzberiCas.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(323, 358);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 29);
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
            this.IzberiTezavnost.Location = new System.Drawing.Point(328, 401);
            this.IzberiTezavnost.Margin = new System.Windows.Forms.Padding(4);
            this.IzberiTezavnost.Name = "IzberiTezavnost";
            this.IzberiTezavnost.Size = new System.Drawing.Size(160, 24);
            this.IzberiTezavnost.TabIndex = 11;
            // 
            // temaSahovnicaGumb4
            // 
            this.temaSahovnicaGumb4.Image = global::Sah_projekt.Properties.Resources.sahovnica4;
            this.temaSahovnicaGumb4.Location = new System.Drawing.Point(753, 222);
            this.temaSahovnicaGumb4.Margin = new System.Windows.Forms.Padding(4);
            this.temaSahovnicaGumb4.Name = "temaSahovnicaGumb4";
            this.temaSahovnicaGumb4.Size = new System.Drawing.Size(139, 117);
            this.temaSahovnicaGumb4.TabIndex = 14;
            this.temaSahovnicaGumb4.UseVisualStyleBackColor = true;
            this.temaSahovnicaGumb4.Click += new System.EventHandler(this.temaSahovnicaGumb4_Click);
            // 
            // temaSahovnicaGumb3
            // 
            this.temaSahovnicaGumb3.Image = global::Sah_projekt.Properties.Resources.sahovnica31;
            this.temaSahovnicaGumb3.Location = new System.Drawing.Point(575, 222);
            this.temaSahovnicaGumb3.Margin = new System.Windows.Forms.Padding(4);
            this.temaSahovnicaGumb3.Name = "temaSahovnicaGumb3";
            this.temaSahovnicaGumb3.Size = new System.Drawing.Size(139, 117);
            this.temaSahovnicaGumb3.TabIndex = 13;
            this.temaSahovnicaGumb3.UseVisualStyleBackColor = true;
            this.temaSahovnicaGumb3.Click += new System.EventHandler(this.temaSahovnicaGumb3_Click);
            // 
            // IzbranaTema
            // 
            this.IzbranaTema.Image = global::Sah_projekt.Properties.Resources.sahovnica2;
            this.IzbranaTema.Location = new System.Drawing.Point(18, 82);
            this.IzbranaTema.Margin = new System.Windows.Forms.Padding(4);
            this.IzbranaTema.Name = "IzbranaTema";
            this.IzbranaTema.Size = new System.Drawing.Size(222, 218);
            this.IzbranaTema.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.IzbranaTema.TabIndex = 9;
            this.IzbranaTema.TabStop = false;
            this.IzbranaTema.Click += new System.EventHandler(this.IzbranaTema_Click);
            // 
            // IzbranaBarva
            // 
            this.IzbranaBarva.Image = global::Sah_projekt.Properties.Resources.White_Queen;
            this.IzbranaBarva.Location = new System.Drawing.Point(248, 226);
            this.IzbranaBarva.Margin = new System.Windows.Forms.Padding(4);
            this.IzbranaBarva.Name = "IzbranaBarva";
            this.IzbranaBarva.Size = new System.Drawing.Size(79, 78);
            this.IzbranaBarva.TabIndex = 8;
            this.IzbranaBarva.TabStop = false;
            // 
            // temaSahovnicaGumb2
            // 
            this.temaSahovnicaGumb2.Image = global::Sah_projekt.Properties.Resources.sahovnica2;
            this.temaSahovnicaGumb2.Location = new System.Drawing.Point(575, 82);
            this.temaSahovnicaGumb2.Margin = new System.Windows.Forms.Padding(4);
            this.temaSahovnicaGumb2.Name = "temaSahovnicaGumb2";
            this.temaSahovnicaGumb2.Size = new System.Drawing.Size(140, 117);
            this.temaSahovnicaGumb2.TabIndex = 6;
            this.temaSahovnicaGumb2.UseVisualStyleBackColor = true;
            this.temaSahovnicaGumb2.Click += new System.EventHandler(this.temaSahovnicaGumb2_Click);
            // 
            // temaSahovnicaGumb1
            // 
            this.temaSahovnicaGumb1.Image = global::Sah_projekt.Properties.Resources.sahovnica1;
            this.temaSahovnicaGumb1.Location = new System.Drawing.Point(753, 82);
            this.temaSahovnicaGumb1.Margin = new System.Windows.Forms.Padding(4);
            this.temaSahovnicaGumb1.Name = "temaSahovnicaGumb1";
            this.temaSahovnicaGumb1.Size = new System.Drawing.Size(139, 117);
            this.temaSahovnicaGumb1.TabIndex = 5;
            this.temaSahovnicaGumb1.UseVisualStyleBackColor = true;
            this.temaSahovnicaGumb1.Click += new System.EventHandler(this.temaSahovnicaGumb1_Click);
            // 
            // CrnaBarva_gumb
            // 
            this.CrnaBarva_gumb.BackColor = System.Drawing.Color.Transparent;
            this.CrnaBarva_gumb.BackgroundImage = global::Sah_projekt.Properties.Resources.Black_Queen;
            this.CrnaBarva_gumb.Location = new System.Drawing.Point(679, 455);
            this.CrnaBarva_gumb.Margin = new System.Windows.Forms.Padding(4);
            this.CrnaBarva_gumb.Name = "CrnaBarva_gumb";
            this.CrnaBarva_gumb.Size = new System.Drawing.Size(81, 81);
            this.CrnaBarva_gumb.TabIndex = 2;
            this.CrnaBarva_gumb.UseVisualStyleBackColor = false;
            this.CrnaBarva_gumb.Click += new System.EventHandler(this.CrnaBarva_Gumb_Click);
            // 
            // BelaBarva_Gumb
            // 
            this.BelaBarva_Gumb.BackgroundImage = global::Sah_projekt.Properties.Resources.White_Queen;
            this.BelaBarva_Gumb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BelaBarva_Gumb.Location = new System.Drawing.Point(575, 455);
            this.BelaBarva_Gumb.Margin = new System.Windows.Forms.Padding(4);
            this.BelaBarva_Gumb.Name = "BelaBarva_Gumb";
            this.BelaBarva_Gumb.Size = new System.Drawing.Size(83, 81);
            this.BelaBarva_Gumb.TabIndex = 1;
            this.BelaBarva_Gumb.UseVisualStyleBackColor = true;
            this.BelaBarva_Gumb.Click += new System.EventHandler(this.BelaBarva_Gumb_Click);
            // 
            // Nastavitve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(92)))), ((int)(((byte)(94)))));
            this.ClientSize = new System.Drawing.Size(981, 554);
            this.Controls.Add(this.temaSahovnicaGumb4);
            this.Controls.Add(this.temaSahovnicaGumb3);
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
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button temaSahovnicaGumb3;
        private System.Windows.Forms.Button temaSahovnicaGumb4;
    }
}