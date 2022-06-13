using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class Tekac : NavideznaFigura
    {
        public Tekac(string barva, Size velikost, NavideznaCelica celica)
        {
            this.Ime = barva + "B";
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
            if (this.Barva == "W") { this.Slika = new Bitmap(Properties.Resources.White_Bishop, Velikost); }
            else { this.Slika = new Bitmap(Properties.Resources.Black_Bishop, Velikost); }
        }

        /// <summary>
        /// Poišče vse možne premike tekača
        /// </summary>
        /// <param name="celica"></param>
        /// <returns>Vrne seznam možnih potez</returns>
        public List<NavideznaCelica> MoznePoteze(NavideznaCelica celica)
        {
            List<NavideznaCelica> mozne = new List<NavideznaCelica>();
            int i = 1;
            while (celica.X + i <= 7 && celica.Y + i <= 7 && DodajPremik_DolDesno(mozne, celica, i))
            {
                i++;
            }
            while (celica.X - i >= 0 && celica.Y + i <= 7 && DodajPremik_GorDesno(mozne, celica, i))
            {
                i++;
            }
            while (celica.X + i <= 7 && celica.Y - i >= 0 && DodajPremik_DolLevo(mozne, celica, i))
            {
                i++;
            }
            while (celica.X - i >= 0 && celica.Y - i >= 0 && DodajPremik_GorLevo(mozne, celica, i))
            {
                i++;
            }
            return mozne;
        }
    }
}
