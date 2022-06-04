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
        public Trdnjava(string barva, Size velikost)
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
    }
}