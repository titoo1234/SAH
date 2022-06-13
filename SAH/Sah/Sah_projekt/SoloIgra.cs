using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class SoloIgra : Igra
    {
        public SoloIgra(string barva, Color tema, Size velikost, Game podlaga) 
        {
            this.NavideznaSahovnica = new NavideznaSahovnica(barva, velikost);
            this.PravaSahovnica = new PravaSahovnica(NavideznaSahovnica, podlaga);

            //this.Sahovnica = new Sahovnica();
            //SpremeniLastnostGumbov();
        }

        //gremo skozi vse gumbe
        //gumb.click += funckcija
        /// <summary>
        /// Funkcija nastavi lastnosti posameznemu polju(gumbu) na šahovnici
        /// </summary>
        public void SpremeniLastnostGumbov()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Celica celica = Sahovnica.Celice[i, j];
                    celica.Click += KlikNaCelico;
                }
            }
        }

        List<Celica> mozne = new List<Celica>();
        private void KlikNaCelico(object sender, EventArgs e)
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
                this.Sahovnica.Zadnja_celica = gumb;
                this.Sahovnica.Zadnja_figura = gumb.Figura;
                int x = gumb.X;
                int y = gumb.Y;
                Figura figura = gumb.Figura;
                //PREVERIMO ČE SMO KLIKNALI NA "PRAVO" FIGURO 
                if (figura.Barva == this.Sahovnica.Trenutni_igralec.Barva)
                {
                    mozne = figura.MoznePoteze(this.Sahovnica);
                    mozne = Figura.PreveriMoznePoteze(this.Sahovnica, mozne, gumb);
                }
                Celica.PobarvajMozneCelice(mozne);
            }

            else//KLIKNEŠ NA CELICO, KAMOR  JE MOŽNO PRESTAVITI FIGURO
            {
                if (this.Sahovnica.podlaga.solo)//IGRAMO SAMI SOLO ALI PROTI RAČUNALNIKU
                {
                    //ZADNJO FIGURO PRESTAVIMO, TO POMENI DA NA ZADNJO CELICO NASTAVIMO FIGURO, KI JE PRAZNA
                    this.Sahovnica.Zadnja_prestavljena_celica = gumb;
                    Figura nova = new Figura("", this.Sahovnica.Zadnja_celica.X, this.Sahovnica.Zadnja_celica.Y, this.Sahovnica.Zadnja_celica.Size);
                    if (this.Sahovnica.Zadnja_figura.Ime == "BK" || this.Sahovnica.Zadnja_figura.Ime == "WK")
                    {
                        Figura.Rosada(this.Sahovnica, this.Sahovnica.Zadnja_figura, gumb);
                    }
                    if (this.Sahovnica.Trenutni_igralec == this.Sahovnica.igralec1)
                    {
                        this.Sahovnica.igralec2.SpremeniStanje(gumb, false);
                        this.Sahovnica.podlaga.label2.Text = this.Sahovnica.igralec2.Vsota.ToString();
                    }
                    else
                    {
                        this.Sahovnica.igralec1.SpremeniStanje(gumb, false);
                        this.Sahovnica.podlaga.label1.Text = this.Sahovnica.igralec1.Vsota.ToString();
                    }

                    Celica.Premik(this.Sahovnica.Zadnja_celica, gumb, this.Sahovnica.Zadnja_figura, nova);

                    //SPREMENI NAZAJ BARVO 
                    Celica.PobarvajCeliceNazaj(mozne);
                    //SPRAZNI MOZNE FIGURE
                    mozne.Clear();
                    //PREVERIMO ALI JE PRIŠEL KMET DO ZADNJEGA POLJA
                    //V TEM PRIMERU PRIKAŽEMO "REZERVO" IN IZBEREMO  POLJUBNO FIGURO

                    //TODO POTREBNO NAREDITI DA !!MORE!! KLIKNATI NA GUMB
                    if (gumb.Figura.Ime == "WP" && gumb.X == 0)
                    {
                        this.Sahovnica.rezerva_beli.Prikaži();
                        Sahovnica.Zamrzni(this.Sahovnica);
                        return;
                    }
                    if (gumb.Figura.Ime == "BP" && gumb.X == 7)
                    {
                        this.Sahovnica.rezerva_crni.Prikaži();
                        Sahovnica.Zamrzni(this.Sahovnica);
                        return;
                    }

                    if (this.Sahovnica.Trenutni_igralec == this.Sahovnica.igralec1)
                    {

                        this.Sahovnica.Trenutni_igralec = this.Sahovnica.igralec2;
                        if (Figura.Mat(this.Sahovnica, this.Sahovnica.igralec2.Barva))
                        {
                            //MessageBox.Show("MAT");
                            this.Sahovnica.podlaga.Close();
                            return;
                        }
                    }
                    else
                    {
                        this.Sahovnica.Trenutni_igralec = this.Sahovnica.igralec1;
                        if (Figura.Mat(this.Sahovnica, this.Sahovnica.igralec1.Barva))
                        {
                            //MessageBox.Show("MAT");
                            this.Sahovnica.podlaga.Close();
                            return;
                        }
                    }
                }
            }


        }
    }
}
