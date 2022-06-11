using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class Trdnjava : NavideznaFigura
    {
        public Trdnjava(string barva, Size velikost, NavideznaCelica celica)
        {
            this.Ime = barva + "R";
            this.Barva = barva;
            NastaviSliko();
            Premaknjen = false;
            Vrednost = 5;
        }
        /// <summary>
        /// Funkcija nastavi sliko Figure na podlagi njene barve
        /// </summary>
        public void NastaviSliko()
        {
            if (this.Barva == "W") { this.Slika = new Bitmap(Properties.Resources.White_Rook, Velikost); }
            else { this.Slika = new Bitmap(Properties.Resources.Black_Rook, Velikost); }
        }

        /// <summary>
        /// Poišče vse možne premike trdnjave
        /// </summary>
        /// <param name="celica"></param>
        /// <returns>Vrne seznam možnih potez</returns>
        public List<NavideznaCelica> MoznePoteze(NavideznaCelica celica)
        {
            List<NavideznaCelica> mozne = new List<NavideznaCelica>();
            int i = 1;
            while (celica.X - i >= 0 && DodajPremik_Gor(mozne, celica, i))
            {
                i++;
            }
            while (celica.X + i <= 7 && DodajPremik_Dol(mozne, celica, i))
            {
                i++;
            }
            while (celica.Y + i <= 7 && DodajPremik_Desno(mozne, celica, i))
            {
                i++;
            }
            while (celica.X - i >= 0 && DodajPremik_Levo(mozne, celica, i))
            {
                i++;
            }
            return mozne;
        }
    }
}