namespace poskus2
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
            this.Zacetek_gumb = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Zacetek_gumb
            // 
            this.Zacetek_gumb.Location = new System.Drawing.Point(560, 205);
            this.Zacetek_gumb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Zacetek_gumb.Name = "Zacetek_gumb";
            this.Zacetek_gumb.Size = new System.Drawing.Size(97, 47);
            this.Zacetek_gumb.TabIndex = 0;
            this.Zacetek_gumb.Text = "ZAČETEK";
            this.Zacetek_gumb.UseVisualStyleBackColor = true;
            this.Zacetek_gumb.Click += new System.EventHandler(this.button1_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 569);
            this.Controls.Add(this.Zacetek_gumb);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Game";
            this.Text = "ŠAH ;-)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Game_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Zacetek_gumb;
    }
}

