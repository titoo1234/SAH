using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace poskus2
{
    public partial class Form1 : Form
    {
        public Button[,] gumbi = new Button[8, 8];
        public int velikost = 40;
        public Form1()
        {
            
            
       
            InitializeComponent();
            for (int vrstica = 0; vrstica < 8; vrstica++)
            {
                //velikost = (int)(this.Height / 16);
                for (int stolpec = 0; stolpec < 8; stolpec++)
                {
                    
                    //this.Height
                    Button gumb = new Button();
                    gumb.Size = new Size(velikost, velikost);
                    
                    gumb.Location = new Point(50 + stolpec * velikost, 50 + vrstica * velikost);
                    //gumb.Text = "" + vrstica + '/' + stolpec;
                    if (vrstica == 1)//beli kmetje
                    {
                        gumb.Tag = "BP";
                        gumb.Text = "BP";
                    }
                    else if (vrstica == 6)//beli kmetje
                    {
                        gumb.Tag = "WP";
                        gumb.Text = "WP";
                    }
                    else if (vrstica == 0)//beli kmetje
                    {
                        if (stolpec == 0 || stolpec == 7)
                        {
                            gumb.Tag = "BR";
                            gumb.Text= "BR";
                        }
                        else if (stolpec == 1 || stolpec == 6)
                        {
                            gumb.Tag = "BN";
                            gumb.Text = "BN";
                        }
                        else if (stolpec == 2 || stolpec == 5)
                        {
                            gumb.Tag = "BB";
                            gumb.Text = "BB";
                        }
                        else if (stolpec == 3)
                        {
                            gumb.Tag = "BQ";
                            gumb.Text = "BQ";
                        }
                        else
                        {
                            gumb.Tag = "BK";
                            gumb.Text = "BK";
                        }
                    }
                    else if (vrstica == 7)//beli kmetje
                    {
                        if (stolpec == 0 || stolpec == 7)
                        {
                            gumb.Tag = "WR";
                            gumb.Text = "WR";
                        }
                        else if (stolpec == 1 || stolpec == 6)
                        {
                            gumb.Tag = "WN";
                            gumb.Text = "WN";
                        }
                        else if (stolpec == 2 || stolpec == 5)
                        {
                            gumb.Tag = "WB";
                            gumb.Text = "WB";
                        }
                        else if (stolpec == 3)
                        {
                            gumb.Tag = "WQ";
                            gumb.Text = "WQ";
                        }
                        else
                        {
                            gumb.Tag = "WK";
                            gumb.Text = "WK";
                        }
                    }
                    else
                    {
                        gumb.Tag = "";
                    }

                    

                    gumb.Click += button1_Click;
                    
                    gumb.UseVisualStyleBackColor = true;
                   
                    this.Controls.Add(gumb);
                    gumbi[vrstica, stolpec] = gumb;
                }
            }



        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }
        //asd
        private void button1_Click(object sender, EventArgs e)
        {
            Button gumb= (Button)sender;
            string vrstica = (string)gumb.Tag;
            MessageBox.Show(vrstica);
        }
    }
}
