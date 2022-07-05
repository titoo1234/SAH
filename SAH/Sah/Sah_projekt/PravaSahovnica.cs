using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah_projekt
{
    public class PravaSahovnica
    {
        private NavideznaSahovnica navideznaSahovnica;
        private Game podlaga;
        private Celica[,] celice;
        private Color[] tema;
        private PravaRezerva pravaRezerva;
        

        public PravaSahovnica(NavideznaSahovnica navideznaSahovnica, Game podlaga, Color[] tema)
        {
            this.NavideznaSahovnica = navideznaSahovnica;
            this.Podlaga = podlaga;
            this.Celice = new Celica[8, 8];
            this.Tema = tema;
            this.PravaRezerva = new PravaRezerva(navideznaSahovnica.NavideznaRezerva, Podlaga, Tema);
            NarediSahovnico();
        }
        public NavideznaSahovnica NavideznaSahovnica { get; set; }
        public Game Podlaga { get;  set; }
        public Celica[,] Celice { get; set; }
        public Color[] Tema { get; set; }
        public PravaRezerva PravaRezerva { get;  set; }

        /// <summary>
        /// Funkcija ustvari "pravo" šahovnico
        /// </summary>
        public void NarediSahovnico()
        {
            Size velikost = NavideznaSahovnica.Velikost;
            for (int vrstica = 0; vrstica < 8; vrstica++)
            {
                for (int stolpec = 0; stolpec < 8; stolpec++)
                {   
                    Celica gumb  = new Celica(vrstica, stolpec);
                    gumb.Location = new Point(50 + stolpec * velikost.Width, 50 + vrstica * velikost.Width);
                    gumb.Size = velikost;
                    gumb.TabStop = false;
                    gumb.FlatStyle = FlatStyle.Flat;
                    gumb.FlatAppearance.BorderSize = 0;
                    if (!(NavideznaSahovnica.Celice[vrstica, stolpec].Figura is null))
                    {
                        Bitmap slika = NavideznaSahovnica.Celice[vrstica, stolpec].Figura.Slika;
                        gumb.Image = slika;
                    }
                    Podlaga.Controls.Add(gumb);
                    Celice[vrstica, stolpec] = gumb;
                    gumb.SpremeniBarvo(Tema[0], Tema[1]);
                    gumb.FlatAppearance.BorderSize = 0;
                }
            }
        }

        public void PrestaviFiguro(Celica gumb)
        {
            PonastaviMozneCelice();

            List<NavideznaCelica> prejsneCelice = NavideznaSahovnica.PrestaviFiguro(gumb);
            if (prejsneCelice.Count == 2) // Če je bila narejena rošada
            {
                // premik trdnjave
                Celica trdnjavaNaCelico = this.Celice[prejsneCelice[1].X, prejsneCelice[1].Y];
                if (trdnjavaNaCelico.Y < 4) // leva rošada  
                {
                    Celica trdnjava = this.Celice[trdnjavaNaCelico.X, 0];
                    //NavideznaFigura premaknjenaTrdnjava = NavideznaSahovnica.Celice[trdnjava.X, trdnjava.Y + 2].Figura;
                    this.Celice[trdnjavaNaCelico.X, trdnjavaNaCelico.Y].Image = trdnjava.Image;
                    trdnjava.Image = null;
                }
                else // desna rošada
                {
                    Celica trdnjava = this.Celice[trdnjavaNaCelico.X, 7];
                    //NavideznaFigura premaknjenaTrdnjava = NavideznaSahovnica.Celice[trdnjava.X, trdnjava.Y - 3].Figura;
                    this.Celice[trdnjavaNaCelico.X, trdnjavaNaCelico.Y].Image = trdnjava.Image;
                    trdnjava.Image = null;
                }
                
            }
            // naredimo EnPassant - izbrisemo ustreznega kmeta
            if (this.NavideznaSahovnica.IzvedenEnPassant)
            {
                this.Celice[prejsneCelice[0].X, gumb.Y].Image = null;
            }
            Celica prejsniGumb = this.Celice[prejsneCelice[0].X, prejsneCelice[0].Y];
            gumb.Image = prejsniGumb.Image;
            prejsniGumb.Image = null;   
        }
        /// <summary>
        /// Funkcija odmrzne vse celice na sahovnici
        /// </summary>
        public void OdmrzniSahovnico()
        {
            for(int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Celice[i, j].Enabled = true;
                }
            }
        }
        /// <summary>
        /// Funkcija "prestavi" figuro, ki jo izbere računalnik
        /// </summary>
        public void RacunalnikNarediPotezo(List<NavideznaCelica> poteza)
        {
            NavideznaCelica prejsnaCelica = poteza[0];
            NavideznaCelica novaCelica = poteza[1];
            Celica gumb = this.Celice[novaCelica.X, novaCelica.Y];
            this.NavideznaSahovnica.PrejsnaCelica = prejsnaCelica;
            PrestaviFiguro(gumb);

            //this.Celice[poteza[1].X, poteza[1].Y].Image = this.Celice[poteza[0].X, poteza[0].Y].Image;
            //this.Celice[poteza[0].X, poteza[0].Y].Image = null;
        }

        /// <summary>
        /// Funkcija zamrzne vse celice na sahovnici
        /// </summary>
        public void ZamrzniSahovnico()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Celice[i, j].Enabled = false;
                }
            }
        }

        /// <summary>
        /// Funkcija pobarva mozne celice nazaj na prvotno barvo ;-)
        /// </summary>
        public void PonastaviMozneCelice()
        {
            foreach (NavideznaCelica moznaCelica in NavideznaSahovnica.MozneCelice)
            {
                Celice[moznaCelica.X, moznaCelica.Y].SpremeniBarvo(Tema[0], Tema[1]);
                Celice[moznaCelica.X, moznaCelica.Y].FlatAppearance.BorderSize = 0;
            }
        }

        /// <summary>
        /// Funkcija obarva vse celice, kamor lahko prestavimo izbrano figuro
        /// </summary>
        public void PrikaziMoznePoteze(Celica gumb,Igralec TrenutniIgralec)
        {
            PonastaviMozneCelice();
            NavideznaCelica celica = NavideznaSahovnica.Celice[gumb.X, gumb.Y];
            if (!(celica.Figura is null) && (celica.Figura.Barva == TrenutniIgralec.Barva))
            {
                List<NavideznaCelica> moznePoteze = NavideznaSahovnica.PoisciMoznePoteze(gumb);
                foreach (NavideznaCelica navideznaCelica in moznePoteze)
                {
                    this.Celice[navideznaCelica.X, navideznaCelica.Y].FlatAppearance.BorderSize = 2;
                    this.Celice[navideznaCelica.X, navideznaCelica.Y].SpremeniBarvo(Tema[2], Tema[2]);
                }
            }
        }
        public void NarediZamenjavo(Celica gumb)
        {
            NavideznaCelica navideznaCelica = NavideznaSahovnica.NarediZamenjavo(gumb);
            Celica celica = this.Celice[navideznaCelica.X, navideznaCelica.Y];
            celica.Image = navideznaCelica.Figura.Slika;
            PravaRezerva.SkrijNasoRezervo();
            PravaRezerva.SkrijNasprotnoRezervo();
        }

    }
}
