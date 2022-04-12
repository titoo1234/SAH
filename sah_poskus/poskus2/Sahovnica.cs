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
        //private List<Kmet> kmeti;
        public Sahovnica(int velikost,Form podlaga)
        {
            //kmeti = new List<Kmet>();   
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
                        Figura fig = new Figura("BP", vrstica, stolpec, gumb.Size);
                        //kmeti.Add(kmet);
                        gumb.Figura = fig;
                        gumb.Tag = "BP";
                        gumb.Image = fig.Slika;
                        
                    }
                    else if (vrstica == 6)//beli kmetje
                    {
                        Figura fig = new Figura("WP", vrstica, stolpec, gumb.Size);
                        //kmeti.Add(kmet);
                        gumb.Figura = fig;

                        gumb.Tag = "WP";
                        gumb.Image = fig.Slika;
                    }
                    else if (vrstica == 0)//beli kmetje
                    {
                        if (stolpec == 0 || stolpec == 7)
                        {
                            Figura fig = new Figura("BR", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "BR";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                        else if (stolpec == 1 || stolpec == 6)
                        {
                            Figura fig = new Figura("BN", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "BN";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                        else if (stolpec == 2 || stolpec == 5)
                        {
                            Figura fig = new Figura("BB", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "BB";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                        else if (stolpec == 3)
                        {
                            Figura fig = new Figura("BQ", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "BQ";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                        else
                        {
                            Figura fig = new Figura("BK", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "BK";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                    }
                    else if (vrstica == 7)//beli kmetje
                    {
                        if (stolpec == 0 || stolpec == 7)
                        {
                            Figura fig = new Figura("WR", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "WR";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                        else if (stolpec == 1 || stolpec == 6)
                        {
                            Figura fig = new Figura("WN", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "WN";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                        else if (stolpec == 2 || stolpec == 5)
                        {
                            Figura fig = new Figura("WB", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "WB";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                        else if (stolpec == 3)
                        {
                            Figura fig = new Figura("WQ", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "WQ";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                        else
                        {
                            Figura fig = new Figura("WK", vrstica, stolpec, gumb.Size);
                            gumb.Tag = "WK";
                            gumb.Image = fig.Slika;
                            gumb.Figura = fig;
                        }
                    }
                    else //PRAZNO POLJE
                    {
                        Figura fig = new Figura("", vrstica, stolpec, gumb.Size);
                        gumb.Tag = "";
                        gumb.Figura = fig;
                    }


                    

                    gumb.Click += button1_Click;

                    gumb.UseVisualStyleBackColor = true;

                    podlaga.Controls.Add(gumb);
                    celice[vrstica, stolpec] = gumb;
                }
            }
            this.celice = celice;




        }



        public Celica[,] Celice
        {
            get
            {
                return this.celice;
            }
           
        }
        Figura zadnja_figura;
        Celica zadnja_celica;
        List<Celica> mozne = new List<Celica>();

        private void button1_Click(object sender, EventArgs e)
        {
            Celica gumb = (Celica)sender;
            //string vrstica = (string)gumb.Tag;
            //MessageBox.Show(vrstica);
            if (!gumb.Mozen)
            {
                for (int i = 0; i < mozne.Count; i++)
                {
                    Celica ce = mozne[i];
                    Figura fig = ce.Figura;
                    ce.BackColor = Color.Transparent;
                    ce.Image = fig.Slika;
                    ce.Mozen = false;

                }
                zadnja_celica = gumb;
                zadnja_figura = gumb.Figura;
                int x = gumb.X;
                int y = gumb.Y;
                Figura figura = gumb.Figura;
                mozne = figura.MoznePoteze(this);
                for (int i = 0; i < mozne.Count; i++)
                {
                    Celica ce = mozne[i];
                    ce.BackColor = Color.Red;
                    ce.Mozen = true;
                    
                }
                

            }
            else
            {
                Figura nova = new Figura("", zadnja_celica.X, zadnja_celica.Y, zadnja_celica.Size);
                zadnja_celica.Figura = nova;

                zadnja_celica.Image = nova.Slika;

                zadnja_figura.X = gumb.X;
                zadnja_figura.Y = gumb.Y;
                zadnja_figura.Premaknjen = true;
                gumb.Figura = zadnja_figura;
                gumb.Image = zadnja_figura.Slika;
                //SPREMENI NAZAJ BARVO
                for (int i = 0; i < mozne.Count; i++)
                {
                    Celica ce = mozne[i];
                    Figura fig = ce.Figura;
                    ce.BackColor = Color.Transparent;
                    ce.Image = fig.Slika;
                    ce.Mozen = false;
                }
                //SPRAZNI MOZNE FIGURE
                mozne.Clear();

            }

        }


    }
}
