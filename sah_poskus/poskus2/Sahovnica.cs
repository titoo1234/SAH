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
        private Igralec trenutni_igralec;
        private string zacetekBarva;
        public RezervaFigure rezerva_beli;
        public RezervaFigure rezerva_crni;
        public Game podlaga;
        public Random random = new Random();
        private bool naVrsti;
        public Igralec igralec1;
        public Igralec igralec2;
        public Celica ZadnjaPrestavljenaCelicaRezerva;//Zadnja celica kmeta, preden gre le ta v zadnjo vrstico
        public Sahovnica(int velikost, Game podlaga,bool naVrsti,string barva)
        {
            igralec1 = new Igralec(barva);
            if (barva == "W")
            {
                igralec2 = new Igralec("B");
            }
            else
            {
                igralec2 = new Igralec("W");
            }

            this.ZadnjaPrestavljenaCelicaRezerva = null;
            this.NaVrsti = naVrsti;
            this.ZacetekBarva = barva;
            this.rezerva_beli = null;
            this.rezerva_crni = null;
            this.podlaga = podlaga;
            this.Zadnja_celica = null;
            this.Zadnja_figura = null;
            this.Zadnja_prestavljena_celica = null;
            this.Trenutni_igralec =  igralec1;
            celice = new Celica[8, 8];
            for (int vrstica = 0; vrstica < 8; vrstica++)
            {
                //velikost = (int)(this.Height / 16);
                if (Trenutni_igralec.Barva == "W")
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
                        //gumb.SpremeniBarvo(Color.Transparent, Color.Green);
                        

                        podlaga.Controls.Add(gumb);
                        celice[vrstica, stolpec] = gumb;
                    }
                }
                
            }
            this.celice = celice;
            

        }
        public bool NaVrsti { get; set; }
        public string ZacetekBarva { get;  set; }
        public Igralec Trenutni_igralec { get;  set; }

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
            //ZATO NAJPREJ IZBIRŠEMO STARE MOŽNE POTEZE
            //ZATO POGLEDAMO KATERE SO MOŽNE POTEZE
            {
                Celica.PobarvajCeliceNazaj(mozne);
                mozne.Clear();
                // TO CELICO SI SHRANIMO ZA KASNEJE, KO BOMO KLIKANLI NA MOŽNO CELICO,
                // DA BOMO VEDELI, KATERO FIGURO SMO PRESTAVILI NA TO MESTO 
                this.Zadnja_celica = gumb;
                this.Zadnja_figura = gumb.Figura;
                int x = gumb.X;
                int y = gumb.Y;
                Figura figura = gumb.Figura;
                //PREVERIMO ČE SMO KLIKNALI NA "PRAVO" FIGURO 
                if (figura.Barva == Trenutni_igralec.Barva)
                {
                    mozne = figura.MoznePoteze(this);
                    mozne = Figura.PreveriMoznePoteze(this, mozne, gumb);
                }
                Celica.PobarvajMozneCelice(mozne);
            }

            else//KLIKNEŠ NA CELICO, KAMOR  JE MOŽNO PRESTAVITI FIGURO
            {

                if (this.podlaga.solo)//IGRAMO SAMI SOLO ALI PROTI RAČUNALNIKU
                {
                    //ZADNJO FIGURO PRESTAVIMO, TO POMENI DA NA ZADNJO CELICO NASTAVIMO FIGURO, KI JE PRAZNA
                    this.Zadnja_prestavljena_celica = gumb;
                    Figura nova = new Figura("", this.Zadnja_celica.X, this.Zadnja_celica.Y, this.Zadnja_celica.Size);
                    if (this.Zadnja_figura.Ime == "BK" || this.Zadnja_figura.Ime == "WK")
                    {
                        Figura.Rosada(this, this.Zadnja_figura, gumb);
                    }

                    if (this.Trenutni_igralec == igralec1)
                    {
                        igralec2.SpremeniStanje(gumb,false);
                        this.podlaga.label2.Text = igralec2.Vsota.ToString();
                    }
                    else
                    {
                        igralec1.SpremeniStanje(gumb,false);
                        this.podlaga.label1.Text = igralec1.Vsota.ToString();
                    }
                    
                    
                    Celica.Premik(this.Zadnja_celica, gumb,this.Zadnja_figura, nova);
                    


                    //SPREMENI NAZAJ BARVO 
                    Celica.PobarvajCeliceNazaj(mozne);
                    //SPRAZNI MOZNE FIGURE
                    mozne.Clear();
                    //PREVERIMO ALI JE PRIŠEL KMET DO ZADNJEGA POLJA
                    //V TEM PRIMERU PRIKAŽEMO "REZERVO" IN IZBEREMO  POLJUBNO FIGURO

                    //TODO POTREBNO NAREDITI DA !!MORE!! KLIKNATI NA GUMB
                    if (gumb.Figura.Ime == "WP" && gumb.X == 0)
                    {
                        rezerva_beli.Prikaži();
                        Zamrzni(this);
                        return;
                    }
                    if (gumb.Figura.Ime == "BP" && gumb.X == 7)
                    {
                        rezerva_crni.Prikaži();
                        Zamrzni(this);
                        return;
                    }


                    

                    if (Trenutni_igralec == igralec1)
                    {
                        
                        Trenutni_igralec = igralec2;
                        if (Figura.Mat(this, igralec2.Barva))
                        {
                            MessageBox.Show("MAT");
                            this.podlaga.Close();
                            return;
                        }
                    }
                    else
                    {
                        Trenutni_igralec = igralec1;
                        if (Figura.Mat(this, igralec1.Barva))
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

                        List<(Celica, Celica)> vse_poteze = Figura.VseMoznePoteze(this, Trenutni_igralec.Barva);
                        //PoisciNajboljso(VseMoznePoteze,korak)
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
                        if (Trenutni_igralec == igralec1)
                        {
                            Trenutni_igralec = igralec2;
                            if (Figura.Mat(this, igralec2.Barva))
                            {
                                MessageBox.Show("MAT");
                                this.podlaga.Close();
                            }
                        }
                        else
                        {
                            Trenutni_igralec = igralec1;
                            if (Figura.Mat(this, igralec1.Barva))
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
                    this.ZadnjaPrestavljenaCelicaRezerva = Zadnja_prestavljena_celica;
                    this.Zadnja_prestavljena_celica = gumb;
                    Figura nova = new Figura("", this.Zadnja_celica.X, this.Zadnja_celica.Y, this.Zadnja_celica.Size);
                    //MessageBox.Show("tle sem");
                    if (this.Zadnja_figura.Ime == "BK" || this.Zadnja_figura.Ime == "WK")
                    {
                        Figura.Rosada(this, this.Zadnja_figura, gumb);
                    }
                    Celica.Premik(this.Zadnja_celica, gumb, this.Zadnja_figura, nova);
                    //SPREMENI NAZAJ BARVO
                    Celica.PobarvajCeliceNazaj(mozne);
                    mozne.Clear();
                    //PREVERIMO ALI JE PRIŠEL KMET DO ZADNJEGA POLJA
                    //V TEM PRIMERU PRIKAŽEMO "REZERVO" IN IZBEREMO  POLJUBNO FIGURO
                    //TODO POTREBNO NAREDITI DA !!MORE!! KLIKNATI NA GUMB
                    if (gumb.Figura.Ime == "WP" && gumb.X == 0)
                    {
                        Zamrzni(this);
                        rezerva_beli.Prikaži();

                        return;
                    }
                    else if (gumb.Figura.Ime == "BP" && gumb.X == 0)
                    {
                        Zamrzni(this);
                        rezerva_crni.Prikaži();

                        return;
                    }
                    else
                    {
                        if (Trenutni_igralec == igralec1)
                        {
                            if (Figura.Mat(this, igralec2.Barva))
                            {
                                MessageBox.Show("MAT");
                                //MORAMO ŠE POSLATI ZADNJO POTEZO
                                byte[] num1 = { (byte)posljiX1, (byte)posljiY1, (byte)posljiX2, (byte)posljiY2,(byte)0 };
                                this.podlaga.socket.Send(num1);
                                this.podlaga.MessageReceiver.RunWorkerAsync();
                                this.podlaga.Close();
                                return;
                            }
                        }
                        else
                        {
                            if (Figura.Mat(this, igralec1.Barva))
                            {
                                MessageBox.Show("MAT");
                                byte[] num2 = { (byte)posljiX1, (byte)posljiY1, (byte)posljiX2, (byte)posljiY2,(byte)0 };
                                this.podlaga.socket.Send(num2);
                                this.podlaga.MessageReceiver.RunWorkerAsync();
                                this.podlaga.Close();
                                return;
                            }
                        }

                        //POŠLI NASPROTNIKU
                        byte[] num = { (byte)posljiX1, (byte)posljiY1, (byte)posljiX2, (byte)posljiY2,(byte)0 };
                        this.podlaga.socket.Send(num);
                        this.podlaga.MessageReceiver.RunWorkerAsync();
                    }
                    
                    
                }

            }

        }


        public static void Zamrzni(Sahovnica sahovnica)
        {
            for(int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Celica celica = sahovnica.Celice[i, j];
                    celica.Enabled = false;
                }

            }
        }
        public static void Odmrzni(Sahovnica sahovnica)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Celica celica = sahovnica.Celice[i, j];
                    celica.Enabled = true;
                }

            }
        }

        public int TrenutnoStanje()
        {
            return igralec1.Vsota - igralec2.Vsota;
        }

        public (Celica,Celica) NajboljsaPoteza(List<(Celica, Celica)> VseMoznePoteze,int korak)
        {
            if (korak == 0)
            {
                return (null,null);
            }
            int najStanje = 5000000;
            (Celica, Celica) najboljsa = VseMoznePoteze[0];
            foreach ((Celica, Celica) poteza in VseMoznePoteze)
            {
                Celica c1 = poteza.Item1;
                Celica c2 = poteza.Item2;
                bool premaknjen1 = c1.Figura.Premaknjen;
                bool premaknjen2 = c2.Figura.Premaknjen;
                Figura PraznaFigura = new Figura("", c1.X, c1.Y, c1.Size);
                Celica.NavidezniPremik(c1, c2, c1.Figura, PraznaFigura);
                int stanje = this.TrenutnoStanje();
                if (stanje < najStanje)
                {
                    najStanje = stanje;
                    najboljsa = poteza;
                }

            }



            return najboljsa;
        }
        


    }
}
