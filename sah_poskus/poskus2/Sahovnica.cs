using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace poskus2
{
    public class Sahovnica
    {
        private Celica[,] celice;
        private List<Kmet> kmeti;
        public Sahovnica(int velikost,Form podlaga)
        {
            kmeti = new List<Kmet>();   
            celice = new Celica[8, 8];
            for (int vrstica = 0; vrstica < 8; vrstica++)
            {
                //velikost = (int)(this.Height / 16);
                for (int stolpec = 0; stolpec < 8; stolpec++)
                {

                    //this.Height
                    Celica gumb = new Celica(vrstica, stolpec);
                    gumb.Size = new Size(velikost, velikost);

                    gumb.Location = new Point(50 + stolpec * velikost, 50 + vrstica * velikost);
                    //gumb.Text = "" + vrstica + '/' + stolpec;
                    if (vrstica == 1)//beli kmetje
                    {
                        Kmet kmet = new Kmet("B", vrstica, stolpec);
                        kmeti.Add(kmet);
                        gumb.Figura = "BP";
                        gumb.Tag = "BP";
                        gumb.Image = new Bitmap(Properties.Resources.Black_Pawn, gumb.Size);
                    }
                    else if (vrstica == 6)//beli kmetje
                    {
                        Kmet kmet = new Kmet("W", vrstica, stolpec);
                        kmeti.Add(kmet);
                        gumb.Figura = "WP";
                        Bitmap s = new Bitmap(Properties.Resources.White_Pawn, gumb.Size);

                        gumb.Tag = "WP";
                        gumb.Image = s;
                    }
                    else if (vrstica == 0)//beli kmetje
                    {
                        if (stolpec == 0 || stolpec == 7)
                        {
                            gumb.Tag = "BR";
                            gumb.Image = new Bitmap(Properties.Resources.Black_Rook, gumb.Size);
                        }
                        else if (stolpec == 1 || stolpec == 6)
                        {
                            gumb.Tag = "BN";
                            gumb.Image = new Bitmap(Properties.Resources.Black_Knight, gumb.Size);
                        }
                        else if (stolpec == 2 || stolpec == 5)
                        {
                            gumb.Tag = "BB";
                            gumb.Image = new Bitmap(Properties.Resources.Black_Bishop, gumb.Size);
                        }
                        else if (stolpec == 3)
                        {
                            gumb.Tag = "BQ";
                            gumb.Image = new Bitmap(Properties.Resources.Black_Queen, gumb.Size);
                        }
                        else
                        {
                            gumb.Tag = "BK";
                            gumb.Image = new Bitmap(Properties.Resources.Black_King, gumb.Size);
                        }
                    }
                    else if (vrstica == 7)//beli kmetje
                    {
                        if (stolpec == 0 || stolpec == 7)
                        {
                            gumb.Tag = "WR";
                            gumb.Image = new Bitmap(Properties.Resources.White_Rook, gumb.Size);
                        }
                        else if (stolpec == 1 || stolpec == 6)
                        {
                            gumb.Tag = "WN";
                            gumb.Image = new Bitmap(Properties.Resources.White_Knight, gumb.Size);
                        }
                        else if (stolpec == 2 || stolpec == 5)
                        {
                            gumb.Tag = "WB";
                            gumb.Image = new Bitmap(Properties.Resources.White_Bishop, gumb.Size);
                        }
                        else if (stolpec == 3)
                        {
                            gumb.Tag = "WQ";
                            gumb.Image = new Bitmap(Properties.Resources.White_Queen, gumb.Size);
                        }
                        else
                        {
                            gumb.Tag = "WK";
                            gumb.Image = new Bitmap(Properties.Resources.White_King, gumb.Size);
                        }
                    }
                    else
                    {
                        gumb.Tag = "";
                    }


                    

                    gumb.Click += button1_Click;

                    gumb.UseVisualStyleBackColor = true;

                    podlaga.Controls.Add(gumb);
                    celice[vrstica, stolpec] = gumb;
                }
            }
            this.celice = celice;
            this.Kmeti = kmeti;



        }

        public List<Kmet> Kmeti { get; set; }

        public Celica[,] Celice
        {
            get
            {
                return this.celice;
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Celica gumb = (Celica)sender;
            string vrstica = (string)gumb.Tag;
            MessageBox.Show(vrstica);
            int x = gumb.X;
            int y = gumb.Y;
            Kmet kmet;
            foreach (Kmet kmet1 in Kmeti)
            {
                if (kmet1.X == x && kmet1.Y == y)
                {
                    MessageBox.Show(x+" "+y);
                    kmet = kmet1;
                    List<Celica> mozne_celice = kmet1.MoznePoteze(this);
                    foreach (Celica celica in mozne_celice)
                    {
                        celica.BackColor = Color.Red;
                    }
                }
            }
            


        }


    }
}
