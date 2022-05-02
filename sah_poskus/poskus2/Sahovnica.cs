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

        private Figura zadnja_figura;
        private Celica zadnja_celica;
        private Celica zadnja_prestavljena_celica;
        private Celica[,] celice;
        private string trenutni_igralec;

        private string zacetekBarva;

        public RezervaFigure rezerva_beli;
        public RezervaFigure rezerva_crni;
        public Game podlaga;
        public Random random = new Random();
        private bool naVrsti;
        public Sahovnica(int velikost, Game podlaga,bool naVrsti,string barva)
        {
            this.NaVrsti = naVrsti;
            this.ZacetekBarva = barva;
            this.rezerva_beli = null;
            this.rezerva_crni = null;
            this.podlaga = podlaga;
            this.Zadnja_celica = null;
            this.Zadnja_figura = null;
            this.Zadnja_prestavljena_celica = null;
            this.Trenutni_igralec =  barva;
            celice = new Celica[8, 8];
            for (int vrstica = 0; vrstica < 8; vrstica++)
            {
                //velikost = (int)(this.Height / 16);
                if (Trenutni_igralec == "W")
                {
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
                else
                {
                    for (int stolpec = 0; stolpec < 8; stolpec++)
                    {

                        //this.Height
                        Celica gumb = new Celica(vrstica, stolpec);
                        gumb.Size = new Size(velikost, velikost);

                        gumb.Location = new Point(50 + stolpec * velikost, 50 + vrstica * velikost);
                        //gumb.Text = "" + vrstica + '/' + stolpec;
                        if (vrstica == 1)//beli kmetje
                        {
                            Figura fig = new Figura("WP", vrstica, stolpec, gumb.Size);
                            //kmeti.Add(kmet);
                            gumb.Figura = fig;
                            gumb.Tag = "WP";
                            gumb.Image = fig.Slika;

                        }
                        else if (vrstica == 6)//beli kmetje
                        {
                            Figura fig = new Figura("BP", vrstica, stolpec, gumb.Size);
                            //kmeti.Add(kmet);
                            gumb.Figura = fig;

                            gumb.Tag = "BP";
                            gumb.Image = fig.Slika;
                        }
                        else if (vrstica == 0)//beli kmetje
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
                        else if (vrstica == 7)//beli kmetje
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
                
            }
            this.celice = celice;

        }
        public bool NaVrsti { get; set; }
        public string ZacetekBarva { get;  set; }
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
            //TODO PREVERI ALI SMO ŽE KLIKNALI NA ZAMENJAVO: OZ LAŽJE, PREVERI ALI JE REZERVA PRIKAZANA

            if (!gumb.Mozen) 
                            //KLIKNALI SMO NA GUMB, KJER NI MOŽNA POTEZA
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

                if (this.podlaga.solo)//IGRAMO SAMI SOLO ALI PROTI RAČUNALNIKU
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
                    //gumb.Figura.Premaknjen = true;
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
                        return;
                    }
                    if (gumb.Figura.Ime == "BP" && gumb.X == 7)
                    {
                        rezerva_crni.Prikaži();
                        return;
                    }


                    //POČAKAJ DA SE PRITISNE REZERVA

                    if (Trenutni_igralec == "W")
                    {
                        Trenutni_igralec = "B";
                        if (Figura.Mat(this, "B"))
                        {
                            MessageBox.Show("MAT");
                            this.podlaga.Close();
                            return;
                        }
                    }
                    else
                    {
                        Trenutni_igralec = "W";
                        if (Figura.Mat(this, "W"))
                        {
                            MessageBox.Show("MAT");
                            this.podlaga.Close();
                            return;
                        }
                    }



                    //ČE IGRAMO PROTI RAČUNALNIKU NAREDI POTEZO
                    if (this.podlaga.racunalnik)
                    {
                        //RAČUNALNIK NAREDI POTEZO

                        List<(Celica, Celica)> vse_poteze = Figura.VseMoznePoteze(this, Trenutni_igralec);

                        int index = random.Next(vse_poteze.Count);

                        Celica celica1 = vse_poteze[index].Item1;
                        Celica celica2 = vse_poteze[index].Item2;


                        nova = new Figura("", this.Zadnja_celica.X, this.Zadnja_celica.Y, this.Zadnja_celica.Size);
                        celica2.Figura = celica1.Figura;
                        celica2.Figura.X = celica2.X;
                        celica2.Figura.Y = celica2.Y;
                        celica2.Figura.Premaknjen = true;
                        celica2.Image = celica2.Figura.Slika;
                        celica1.Figura = nova;
                        celica1.Image = nova.Slika;


                        //PREVERI MAT IN ZAMENJI IGRALCA
                        if (Trenutni_igralec == "W")
                        {
                            Trenutni_igralec = "B";
                            if (Figura.Mat(this, "B"))
                            {
                                MessageBox.Show("MAT");
                                this.podlaga.Close();
                            }
                        }
                        else
                        {
                            Trenutni_igralec = "W";
                            if (Figura.Mat(this, "W"))
                            {
                                MessageBox.Show("MAT");
                                this.podlaga.Close();
                            }
                        }


                    }

                }
                else//IGRAMO MULTIPLAYER
                {
                    if (!NaVrsti)
                    {
                        MessageBox.Show("Nisi na potezi");
                        return;
                    }
                    int posljiX2 = 7-gumb.X;
                    int posljiY2 = gumb.Y;
                    int posljiX1 = 7-Zadnja_figura.X;
                    int posljiY1 = Zadnja_figura.Y;
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
                    //gumb.Figura.Premaknjen = true;
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
                        return;
                    }
                    if (gumb.Figura.Ime == "BP" && gumb.X == 7)
                    {
                        rezerva_crni.Prikaži();
                        return;
                    }


                    //POČAKAJ DA SE PRITISNE REZERVA

                    if (Trenutni_igralec == "W")
                    {
                        //Trenutni_igralec = "B";
                        if (Figura.Mat(this, "B"))
                        {
                            MessageBox.Show("MAT");
                            //MORAMO ŠE POSLATI ZADNJO POTEZO
                            byte[] num1 = { (byte)posljiX1, (byte)posljiY1, (byte)posljiX2, (byte)posljiY2 };
                            this.podlaga.socket.Send(num1);

                            this.podlaga.MessageReceiver.RunWorkerAsync();


                            this.podlaga.Close();
                            return;
                        }
                    }
                    else
                    {
                        //Trenutni_igralec = "W";
                        if (Figura.Mat(this, "W"))
                        {
                            MessageBox.Show("MAT");
                            byte[] num2 = { (byte)posljiX1, (byte)posljiY1, (byte)posljiX2, (byte)posljiY2 };
                            this.podlaga.socket.Send(num2);

                            this.podlaga.MessageReceiver.RunWorkerAsync();
                            this.podlaga.Close();
                            return;
                        }
                    }

                    //POŠLI NASPROTNIKU
                    //[1,2,3,4]
                    byte[] num = { (byte)posljiX1, (byte)posljiY1, (byte)posljiX2, (byte)posljiY2 };
                    this.podlaga.socket.Send(num);

                    this.podlaga.MessageReceiver.RunWorkerAsync();
                    

                    //sem_na_vrsti = false

                    
                }

            }

        }


        public void Zamrzni()
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Celica celica = this.Celice[i, j];
                    celica.Enabled = false;
                }

            }
        }
        public void Odmrzni()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Celica celica = this.Celice[i, j];
                    celica.Enabled = true;
                }

            }
        }

    }
}
