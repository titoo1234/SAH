﻿using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class Kraljica : NavideznaFigura
    {
        public Kraljica(string barva, Size velikost)
        {
            this.Ime = barva + "Q";
            this.Barva = barva;
            this.Velikost = velikost;
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

        /// <summary>
        /// Poišče vse možne premike kraljica
        /// </summary>
        /// <param name="celica"></param>
        /// <returns>Vrne seznam možnih potez</returns>
        public override List<NavideznaCelica> MoznePoteze(NavideznaCelica celica, NavideznaSahovnica Sahovnica)
        {
            this.Sahovnica = celica.Sahovnica;
            List<NavideznaCelica> mozne = new List<NavideznaCelica>();
            int i = 1;
            while (celica.X - i >= 0 && DodajPremik_Gor(mozne, celica, i, Sahovnica))
            {
                i++;
            }
            i = 1;
            while (celica.X + i <= 7 && DodajPremik_Dol(mozne, celica, i, Sahovnica))
            {
                i++;
            }
            i = 1;
            while (celica.Y + i <= 7 && DodajPremik_Desno(mozne, celica, i, Sahovnica))
            {
                i++;
            }
            i = 1;
            while (celica.Y - i >= 0 && DodajPremik_Levo(mozne, celica, i, Sahovnica))
            {
                i++;
            }
            i = 1;
            while (celica.X + i <= 7 && celica.Y + i <= 7 && DodajPremik_DolDesno(mozne, celica, i, Sahovnica))
            {
                i++;
            }
            i = 1;
            while (celica.X - i >= 0 && celica.Y + i <= 7 && DodajPremik_GorDesno(mozne, celica, i, Sahovnica))
            {
                i++;
            }
            i = 1;
            while (celica.X + i <= 7 && celica.Y - i >= 0 && DodajPremik_DolLevo(mozne, celica, i, Sahovnica))
            {
                i++;
            }
            i = 1;
            while (celica.X - i >= 0 && celica.Y - i >= 0 && DodajPremik_GorLevo(mozne, celica, i, Sahovnica))
            {
                i++;
            }
            return mozne;
        }
    }

}