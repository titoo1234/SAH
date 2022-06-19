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
        public Kralj(string barva, Size velikost)
        {
            this.Ime = barva + "K";
            this.Barva = barva;
            this.Velikost = velikost;
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
        public bool MoznaLevaRosada(NavideznaCelica celica, NavideznaSahovnica Sahovnica)
        {
            NavideznaCelica celica_trdnjava = Sahovnica.Celice[celica.X, 0];
            NavideznaFigura trdnjava_figura = celica_trdnjava.Figura;
            if (trdnjava_figura is null) return false; // če trdnjave ni več na svojem mestu ne moremo narediti rošade

            if (!this.Premaknjen && !trdnjava_figura.Premaknjen)
            {
                //preverimo če so vmesne celice prazne
                return PreglejVmesneCelice(celica_trdnjava, celica, Sahovnica);
            }
            return false;
        }

        /// <summary>
        /// Funkcija vrne true, če je na šahovnici možno narediti desno rošado
        /// </summary>
        /// <param name="celica"></param>
        /// <returns></returns>
        public bool MoznaDesnaRosada(NavideznaCelica celica, NavideznaSahovnica Sahovnica)
        {
            NavideznaCelica celica_trdnjava = Sahovnica.Celice[celica.X, 7];
            NavideznaFigura trdnjava_figura = celica_trdnjava.Figura;
            if (trdnjava_figura is null) return false; // če trdnjave ni več na svojem mestu ne moremo narediti rošade

            if (!this.Premaknjen && !trdnjava_figura.Premaknjen)
            {
                //preverimo če so vmesne celice prazne
                return PreglejVmesneCelice(celica, celica_trdnjava, Sahovnica);
            }
            return false;
        }

        /// <summary>
        /// Funkcija vrne true, če so vmesne celice (vodoravno) prazne in false sicer
        /// </summary>
        /// <param name="zacetna"></param>
        /// <param name="koncna"></param>
        /// <param name="sahovnica"></param>
        /// <returns></returns>
        public bool PreglejVmesneCelice(NavideznaCelica zacetna, NavideznaCelica koncna, NavideznaSahovnica sahovnica)
        {
            for (int i = zacetna.Y + 1; i < koncna.Y; i++)
            {
                if (!(sahovnica.Celice[zacetna.X, i].Figura is null)) return false;
            }
            return true;
        }

        /// <summary>
        /// Poišče vse možne premike kralja
        /// </summary>
        /// <param name="celica"></param>
        /// <returns>Vrne seznam možnih potez</returns>
        public override List<NavideznaCelica> MoznePoteze(NavideznaCelica celica, NavideznaSahovnica Sahovnica)
        {
            List<NavideznaCelica> mozne = new List<NavideznaCelica>();
            if (this.MoznaDesnaRosada(celica, Sahovnica))
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X, celica.Y + 2];
                mozne.Add(trenutna_celica);
            }
            if (this.MoznaLevaRosada(celica, Sahovnica))
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
