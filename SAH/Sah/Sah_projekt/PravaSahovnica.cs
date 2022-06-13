using System;
using System.Collections.Generic;
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

        public PravaSahovnica(NavideznaSahovnica navideznaSahovnica, Game podlaga, Color[] tema)
        {
            this.NavideznaSahovnica = navideznaSahovnica;
            this.Podlaga = podlaga;
            this.Celice = new Celica[8, 8];
            this.Tema = tema;
            NarediSahovnico();
        }
        public NavideznaSahovnica NavideznaSahovnica { get; set; }
        public Game Podlaga { get;  set; }
        public Celica[,] Celice { get; set; }
        public Color[] Tema { get; set; }

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
                }
            }
        }

        public void PrestaviFiguro(Celica gumb)
        {
            PonastaviMozneCelice();
            NavideznaCelica prejsnaCelica = NavideznaSahovnica.PrestaviFiguro(gumb);
            Celica prejsniGumb = Celice[prejsnaCelica.X, prejsnaCelica.Y];
            gumb.Image = prejsniGumb.Image;
            prejsniGumb.Image = null;
        }

        /// <summary>
        /// Funkcija pobarva mozne celice nazaj na prvotno barvo ;-)
        /// </summary>
        public void PonastaviMozneCelice()
        {
            foreach (NavideznaCelica moznaCelica in NavideznaSahovnica.MozneCelice)
            {
                Celice[moznaCelica.X, moznaCelica.Y].SpremeniBarvo(Tema[0], Tema[1]);
            }
        }

    }
}
