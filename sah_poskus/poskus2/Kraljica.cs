using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class Kraljica : NavideznaFigura
    {
        public Kraljica(string barva, Size velikost)
        {
            this.Ime = barva + "Q";
            this.Barva = barva;
            NastaviSliko();
            Premaknjen = false;
            Vrednost = 9;
        }
        /// <summary>
        /// Funkcija nastavi sliko Figure na podlagi njene barve
        /// </summary>
        public void NastaviSliko()
        {
            if (this.Barva == "W") { this.Slika = new Bitmap(Properties.Resources.White_Queen, Velikost); }
            else { this.Slika = new Bitmap(Properties.Resources.Black_Queen, Velikost); }
        }
    }
}