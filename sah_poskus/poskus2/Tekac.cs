using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class Tekac : NavideznaFigura
    {
        public Tekac(string barva, Size velikost, NavideznaCelica celica)
        {
            this.Ime = barva + "B";
            this.Barva = barva;
            NastaviSliko();
            Premaknjen = false;
            Vrednost = 3;
            this.Celica = celica;
        }
        /// <summary>
        /// Funkcija nastavi sliko Figure na podlagi njene barve
        /// </summary>
        public void NastaviSliko()
        {
            if (this.Barva == "W") { this.Slika = new Bitmap(Properties.Resources.White_Bishop, Velikost); }
            else { this.Slika = new Bitmap(Properties.Resources.Black_Bishop, Velikost); }
        }
    }
}
