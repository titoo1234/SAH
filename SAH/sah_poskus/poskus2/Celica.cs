using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace poskus2
{
    public class Celica : Button
    {
        private int x;
        private int y;
        private bool mozen; // S to lastnostnjo povemo, ali se da na to celico priti (s trenutno figuro)
        private Figura figura;

        public Celica(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Figura = null;
            this.Mozen= false;
        }

        // LASTNOSTI: 
        // ====================================================
        public bool Mozen { get; set; }

        public Figura Figura { get; set; }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentException("X mora biti med 0 in 7");
                }
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentException("Y mora biti med 0 in 7");
                }
                this.y = value;
            }
        }

        // FUNKCIJE:
        // ==================================================================

        /// <summary>
        /// STARE MOŽNE POTEZE POBARVAMO NAZAJ NA PRVOTNO BARVO CELIC
        /// </summary>
        /// <param name="mozne"> Možne celice so tiste, na katere lahko prestavimo na figuro</param>
        public static void PobarvajCeliceNazaj(List<Celica> mozne)
        {
            for (int i = 0; i < mozne.Count; i++)
            {
                Celica ce = mozne[i];
                Figura fig = ce.Figura;
                //SpremeniBarvo(ce,barva1,barva2);
                //ce.SpremeniBarvo(Color.Transparent, Color.Green);
                ce.BackColor = Color.Transparent;
                ce.Image = fig.Slika;
                ce.Mozen = false;
            }
        }
        /// <summary>
        /// Možne celice pobarva v "ustrezno" barvo, da vemo kam lahko prestavimo neko figuro
        /// </summary>
        /// <param name="mozne">Možne celice so tiste, na katere lahko prestavimo na figuro</param>
        public static void PobarvajMozneCelice(List<Celica> mozne)
        {
            for (int i = 0; i < mozne.Count; i++)
            {
                Celica ce = mozne[i];
                ce.BackColor = Color.Red;
                ce.Mozen = true;
            }
        }

        /// <summary>
        /// Naredi premik iz "zadnje celice" na "trenutno celico", 
        /// na zadnjo celico "nastavi" novo figuro, ki je "prazna".
        /// </summary>
        /// <param name="ZadnjaCelica"></param>
        /// <param name="TrenutnaCelica"></param>
        /// <param name="ZadnjaFigura"></param>
        /// <param name="PraznaFigura"></param>
        public static void Premik(Celica ZadnjaCelica,  Celica TrenutnaCelica, Figura ZadnjaFigura, Figura PraznaFigura)
        {
            ZadnjaCelica.Figura = PraznaFigura;
            ZadnjaCelica.Image = PraznaFigura.Slika;
            ZadnjaFigura.X = TrenutnaCelica.X;
            ZadnjaFigura.Y = TrenutnaCelica.Y;
            ZadnjaFigura.Premaknjen = true;
            TrenutnaCelica.Figura = ZadnjaFigura;
            TrenutnaCelica.Image = ZadnjaFigura.Slika;
        }

        /// <summary>
        /// Funkcija spremeni barvo celice, glede na pozicijo kje se celica nahaja
        /// </summary>
        /// <param name="barvaSodoMesto"></param>
        /// <param name="barvaLihoMesto"></param>
        public void SpremeniBarvo(Color barvaSodoMesto, Color barvaLihoMesto)
        {
            if ((this.X + this.Y) % 2 == 0)
            {
                this.BackColor = barvaSodoMesto;
            }
            else
            {
                this.BackColor= barvaLihoMesto;
            }
        }

        public static void NavidezniPremik(Celica ZadnjaCelica, Celica TrenutnaCelica, Figura ZadnjaFigura, Figura PraznaFigura)
        {
            ZadnjaCelica.Figura = PraznaFigura;         
            ZadnjaFigura.X = TrenutnaCelica.X;
            ZadnjaFigura.Y = TrenutnaCelica.Y;
            ZadnjaFigura.Premaknjen = true;
            TrenutnaCelica.Figura = ZadnjaFigura;  
        }

        public static void NavidezniPremik_nazaj(Celica CelicaNazaj, Celica TrenutnaCelica, Figura fig1, Figura fig2, bool premik1, bool premik2)
        {
            fig1.Premaknjen = premik1;
            fig1.X = CelicaNazaj.X;
            fig1.Y = CelicaNazaj.Y;
            fig2.Premaknjen = premik2;
            fig2.X = TrenutnaCelica.X;
            fig2.Y = TrenutnaCelica.Y;
            CelicaNazaj.Figura = fig1;
            TrenutnaCelica.Figura = fig2;
        }
    }
}
