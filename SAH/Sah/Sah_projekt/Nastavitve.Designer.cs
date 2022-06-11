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
            this.CrnaBarva_gumb = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.BelaBarva_Gumb = new System.Windows.Forms.Button();
            this.ZacetekIgre = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Izberi barvo:";
            // 
            // CrnaBarva_gumb
            // 
            this.CrnaBarva_gumb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CrnaBarva_gumb.Location = new System.Drawing.Point(101, 201);
            this.CrnaBarva_gumb.Name = "CrnaBarva_gumb";
            this.CrnaBarva_gumb.Size = new System.Drawing.Size(75, 47);
            this.CrnaBarva_gumb.TabIndex = 2;
            this.CrnaBarva_gumb.UseVisualStyleBackColor = false;
            this.CrnaBarva_gumb.Click += new System.EventHandler(this.CrnaBarva_Gumb_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Izberi temo:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // BelaBarva_Gumb
            // 
            this.BelaBarva_Gumb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BelaBarva_Gumb.Location = new System.Drawing.Point(101, 110);
            this.BelaBarva_Gumb.Name = "BelaBarva_Gumb";
            this.BelaBarva_Gumb.Size = new System.Drawing.Size(75, 47);
            this.BelaBarva_Gumb.TabIndex = 1;
            this.BelaBarva_Gumb.UseVisualStyleBackColor = true;
            this.BelaBarva_Gumb.Click += new System.EventHandler(this.BelaBarva_Gumb_Click);
            // 
            // ZacetekIgre
            // 
            this.ZacetekIgre.Location = new System.Drawing.Point(244, 321);
            this.ZacetekIgre.Name = "ZacetekIgre";
            this.ZacetekIgre.Size = new System.Drawing.Size(186, 41);
            this.ZacetekIgre.TabIndex = 4;
            this.ZacetekIgre.Text = "Joža požen";
            this.ZacetekIgre.UseVisualStyleBackColor = true;
            this.ZacetekIgre.Click += new System.EventHandler(this.ZacetekIgre_Click);
            // 
            // Nastavitve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 450);
            this.Controls.Add(this.ZacetekIgre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CrnaBarva_gumb);
            this.Controls.Add(this.BelaBarva_Gumb);
            this.Controls.Add(this.label1);
            this.Name = "Nastavitve";
            this.Text = "Nastavitve";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BelaBarva_Gumb;
        private System.Windows.Forms.Button CrnaBarva_gumb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ZacetekIgre;
    }
}