﻿using System;
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

        private Figura zadnja_figura;
        private Celica zadnja_celica;
        private Celica zadnja_prestavljena_celica;
        private Celica[,] celice;
        private string trenutni_igralec;
        public RezervaFigure rezerva_beli;
        public RezervaFigure rezerva_crni;


        //private List<Kmet> kmeti;
        public Sahovnica(int velikost,Form podlaga)
        {
            this.rezerva_beli = null;
            this.rezerva_crni = null;

            this.Zadnja_celica = null;
            this.Zadnja_figura = null;
            this.Zadnja_prestavljena_celica = null;
            this.Trenutni_igralec = "W";
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

        public string Trenutni_igralec { get;  set; }

        public Celica[,] Celice
        {
            get
            {
                return this.celice;
            }
           
        }

        public Celica Zadnja_celica { get;  set; }
        public Figura Zadnja_figura { get;  set; }
        public Celica Zadnja_prestavljena_celica { get;  set; }

        List<Celica> mozne = new List<Celica>();


        private void button1_Click(object sender, EventArgs e)
        {
            Celica gumb = (Celica)sender;
            //string vrstica = (string)gumb.Tag;
            //MessageBox.Show(vrstica);
            if (!gumb.Mozen) //KLIKNALI SMO NA GUMB, KJER NI MOŽNA POTEZA
                             //ZATO POGLEDAMO KATERE SO MOŽNE POTEZE
            {
                
                for (int i = 0; i < mozne.Count; i++)//STARE MOŽNE POTEZE POBARVAMO NAZAJ NA NAVADNO BARVO
                {
                    Celica ce = mozne[i];
                    Figura fig = ce.Figura;
                    ce.BackColor = Color.Transparent;
                    ce.Image = fig.Slika;
                    ce.Mozen = false;

                }
                mozne.Clear();
                this.Zadnja_celica = gumb;
                this.Zadnja_figura = gumb.Figura;
                int x = gumb.X;
                int y = gumb.Y;
                Figura figura = gumb.Figura;
                //PREVERIMO ČE SMO KLIKNALI NA "PRAVO" FIGURO 
                if (figura.Barva == Trenutni_igralec)
                {
                    mozne = figura.MoznePoteze(this);
                    mozne = Figura.PreveriMoznePoteze(this, mozne, gumb);
                }
                
                //if (Figura.Mat(this, mozne))
                //{
                //    MessageBox.Show("MAT");
                //}

                for (int i = 0; i < mozne.Count; i++)
                {
                    Celica ce = mozne[i];
                    //MessageBox.Show(ce.X.ToString() + ce.Y.ToString());
                    ce.BackColor = Color.Red;
                    ce.Mozen = true;
                    
                }

            }
            else//KLIKNEŠ NA CELICO, KAMOR  JE MOŽNO PRESTAVITI FIGURO
            {
                this.Zadnja_prestavljena_celica = gumb;
                Figura nova = new Figura("", this.Zadnja_celica.X, this.Zadnja_celica.Y, this.Zadnja_celica.Size);
                //MessageBox.Show("tle sem");
                if (this.Zadnja_figura.Ime == "BK" || this.Zadnja_figura.Ime == "WK")
                {
                    Figura.Rosada(this, this.Zadnja_figura, gumb);
                }
                this.Zadnja_celica.Figura = nova;
                this.Zadnja_celica.Image = nova.Slika;
                this.Zadnja_figura.X = gumb.X;
                this.Zadnja_figura.Y = gumb.Y;
                this.Zadnja_figura.Premaknjen = true;

                
                gumb.Figura = this.Zadnja_figura;
                gumb.Image = this.Zadnja_figura.Slika;



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



                //PREVERIMO ALI JE PRIŠEL KMET DO ZADNJEGA POLJA
                //V TEM PRIMERU PRIKAŽEMO "REZERVO" IN IZBEREMO  POLJUBNO FIGURO

                //TODO POTREBNO NAREDITI DA !!MORE!! KLIKNATI NA GUMB
                if (gumb.Figura.Ime == "WP" && gumb.X == 0)
                {
                    rezerva_beli.Prikaži();
                }
                if (gumb.Figura.Ime == "BP" && gumb.X == 7)
                {
                    rezerva_crni.Prikaži();
                }



                
                if (Trenutni_igralec == "W")
                {
                    Trenutni_igralec = "B";
                    if (Figura.Mat(this, "B"))
                    {
                        MessageBox.Show("MAT");
                    }
                }
                else
                {
                    Trenutni_igralec = "W";
                    if (Figura.Mat(this, "W"))
                    {
                        MessageBox.Show("MAT");
                    }
                }

                

            }

        }

    }
}
