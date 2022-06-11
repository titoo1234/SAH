using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class Kralj : NavideznaFigura
    {
        public Kralj(string barva, Size velikost, NavideznaCelica celica)
        {
            this.Ime = barva + "K";
            this.Barva = barva;
            NastaviSliko();
            Premaknjen = false;
            Vrednost = 200;
        }
        /// <summary>
        /// Funkcija nastavi sliko Figure na podlagi njene barve
        /// </summary>
        public void NastaviSliko()
        {
            if (this.Barva == "W") { this.Slika = new Bitmap(Properties.Resources.White_King, Velikost); }
            else { this.Slika = new Bitmap(Properties.Resources.Black_King, Velikost); }
        }

        /// <summary>
        /// Funkcija vrne true, če je na šahovnici možno narediti levo rošado
        /// </summary>
        /// <param name="celica"></param>
        /// <returns></returns>
        public bool MoznaLevaRosada(NavideznaCelica celica)
        {
            NavideznaCelica celica_trdnjava = Sahovnica.Celice[celica.X, 0];
            NavideznaFigura trdnjava_figura = celica_trdnjava.Figura;

            if (!this.Premaknjen && !trdnjava_figura.Premaknjen && (trdnjava_figura.Ime == "WR" || trdnjava_figura.Ime == "BR"))
            {
                //preverimo če so umesne prazne
                if (Sahovnica.Celice[celica.X, 1].Figura is null && Sahovnica.Celice[celica.X, 2].Figura is null && Sahovnica.Celice[celica.X, 3].Figura is null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Funkcija vrne true, če je na šahovnici možno narediti desno rošado
        /// </summary>
        /// <param name="celica"></param>
        /// <returns></returns>
        public bool MoznaDesnaRosada(NavideznaCelica celica)
        {
            NavideznaCelica celica_trdnjava = Sahovnica.Celice[celica.X, 7];
            NavideznaFigura trdnjava_figura = celica_trdnjava.Figura;

            if (!this.Premaknjen && !trdnjava_figura.Premaknjen && (trdnjava_figura.Ime == "WR" || trdnjava_figura.Ime == "BR"))
            {
                //preverimo če so umesne prazne
                if (Sahovnica.Celice[celica.X, 6].Figura is null && Sahovnica.Celice[celica.X, 5].Figura is null)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Poišče vse možne premike kralja
        /// </summary>
        /// <param name="celica"></param>
        /// <returns>Vrne seznam možnih potez</returns>
        public List<NavideznaCelica> MoznePoteze(NavideznaCelica celica)
        {
            List<NavideznaCelica> mozne = new List<NavideznaCelica>();
            if (this.MoznaDesnaRosada(celica))
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X, celica.Y + 2];
                mozne.Add(trenutna_celica);
            }
            if (this.MoznaLevaRosada(celica))
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X, celica.Y - 2];
                mozne.Add(trenutna_celica);
            }

            int i = 1;
            if (celica.X - i >= 0)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - i, celica.Y];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X + i <= 7)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + i, celica.Y];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.Y + i <= 7)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X, celica.Y + i];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.Y - i >= 0)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X, celica.Y - i];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X + i <= 7 && celica.Y + i <= 7)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + i, celica.Y + i];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X - i >= 0 && celica.Y + i <= 7)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - i, celica.Y + i];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X + i <= 7 && celica.Y - i >= 0)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + i, celica.Y - i];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X - i >= 0 && celica.Y - i >= 0)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - i, celica.Y - i];
                this.DodajPremik(mozne, trenutna_celica);
            }
            return mozne;
        }
    }
}
