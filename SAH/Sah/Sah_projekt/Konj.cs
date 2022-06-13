using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class Konj : NavideznaFigura
    {
        public Konj(string barva, Size velikost, NavideznaCelica celica)
        {
            this.Ime = barva + "N";
            this.Barva = barva;
            this.Velikost = velikost;
            NastaviSliko();
            Premaknjen = false;
            Vrednost = 3;
        }
        /// <summary>
        /// Funkcija nastavi sliko Figure na podlagi njene barve
        /// </summary>
        public void NastaviSliko()
        {
            if (this.Barva == "W") { this.Slika = new Bitmap(Properties.Resources.White_Knight, Velikost); }
            else { this.Slika = new Bitmap(Properties.Resources.Black_Knight, Velikost); }
        }

        /// <summary>
        /// Poišče vse možne premike konja
        /// </summary>
        /// <param name="celica"></param>
        /// <returns>Vrne seznam možnih potez</returns>
        public List<NavideznaCelica> MoznePoteze(NavideznaCelica celica)
        {
            List<NavideznaCelica> mozne = new List<NavideznaCelica>();
            int i = 1;
            int j = 2;
            if (celica.X - i >= 0 && celica.Y - j >= 0)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - i, celica.Y - j];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X + i <= 7 && celica.Y - j >= 0)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + i, celica.Y - j];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X - i >= 0 && celica.Y + j <= 7)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - i, celica.Y + j];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X + i <= 7 && celica.Y + j <= 7)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + i, celica.Y + j];
                this.DodajPremik(mozne, trenutna_celica);
            }
            
            i = 2;
            j = 1;
            if (celica.X - i >= 0 && celica.Y - j >= 0)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - i, celica.Y - j];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X + i <= 7 && celica.Y - j >= 0)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + i, celica.Y - j];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X - i >= 0 && celica.Y + j <= 7)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - i, celica.Y + j];
                this.DodajPremik(mozne, trenutna_celica);
            }
            if (celica.X + i <= 7 && celica.Y + j <= 7)
            {
                NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + i, celica.Y + j];
                this.DodajPremik(mozne, trenutna_celica);
            }
            return mozne;
        }
    }
}