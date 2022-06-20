using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class NavideznaSahovnica
    {
        private NavideznaCelica[,] celice;
        private Size velikost;
        private string zacetnaBarva;
        private NavideznaCelica prejsnaCelica;
        private List<NavideznaCelica> mozneCelice;
        private NavideznaRezerva navideznaRezerva;

        public NavideznaSahovnica(string zacetnaBarva, Size velikost)
        {
            this.ZacetnaBarva = zacetnaBarva;
            this.Velikost = velikost;
            this.Celice = NarediSahovnico(zacetnaBarva, Velikost);
            this.MozneCelice = new List<NavideznaCelica>();
            this.NavideznaRezerva = new NavideznaRezerva(ZacetnaBarva, Velikost);
        }

        public NavideznaCelica[,] Celice { get; set; }   
        public Size Velikost { get; set; }
        public string ZacetnaBarva { get; set; }
        public NavideznaCelica PrejsnaCelica { get; set; }
        public List<NavideznaCelica> MozneCelice { get; set; }
        public NavideznaRezerva NavideznaRezerva { get;  set; }

        /// <summary>
        /// Funkcija naredi sahovnico v obliki matrike Celic
        /// </summary>
        /// <param name="barva"> barva nam pove s katerimi figurami začnemo</param>
        /// <param name="velikost"></param>
        /// <returns>Vrne matriko Celic</returns>
        public NavideznaCelica[,] NarediSahovnico(string barva, Size velikost)
        {
            NavideznaCelica[,] celice = new NavideznaCelica[8, 8];
            string nasprotna_barva = NasprotnaBarva(barva);

            // v sredini sahovnice so prazna polja, ki jih označimo z praznimi nizi ""
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    celice[i, j] = new NavideznaCelica(i, j, this);
                    // Figura je privzeto null
                }
            }

            // ustvarimo kmete
            for (int j = 0; j < 8; j++)
            {
                celice[1, j] = new NavideznaCelica(1, j, this);
                celice[1, j].Figura = new Kmet(nasprotna_barva, velikost);
                celice[6, j] = new NavideznaCelica(6, j, this);
                celice[6, j].Figura = new Kmet(barva, velikost);
            }

            // ostala polja 
            // Trdnjave:
            celice[0, 0] = new NavideznaCelica(0, 0, this);
            celice[0, 0].Figura = new Trdnjava(nasprotna_barva, velikost);
            celice[0, 7] = new NavideznaCelica(0, 7, this);
            celice[0, 7].Figura = new Trdnjava(nasprotna_barva, velikost);

            celice[7, 0] = new NavideznaCelica(7, 0, this);
            celice[7, 0].Figura = new Trdnjava(barva, velikost);
            celice[7, 7] = new NavideznaCelica(7, 7, this);
            celice[7, 7].Figura = new Trdnjava(barva, velikost);

            // konji:
            celice[0, 1] = new NavideznaCelica(0, 1, this);
            celice[0, 1].Figura = new Konj(nasprotna_barva, velikost);
            celice[0, 6] = new NavideznaCelica(0, 6, this);
            celice[0, 6].Figura = new Konj(nasprotna_barva, velikost);

            celice[7, 1] = new NavideznaCelica(7, 1, this);
            celice[7, 1].Figura = new Konj(barva, velikost);
            celice[7, 6] = new NavideznaCelica(7, 6, this);
            celice[7, 6].Figura = new Konj(barva, velikost);

            // tekači:
            celice[0, 2] = new NavideznaCelica(0, 2, this);
            celice[0, 2].Figura = new Tekac(nasprotna_barva, velikost);
            celice[0, 5] = new NavideznaCelica(0, 5, this);
            celice[0, 5].Figura = new Tekac(nasprotna_barva, velikost);

            celice[7, 2] = new NavideznaCelica(7, 2, this);
            celice[7, 2].Figura = new Tekac(barva, velikost);
            celice[7, 5] = new NavideznaCelica(7, 5, this);
            celice[7, 5].Figura = new Tekac(barva, velikost);

            // kraljici:
            if (this.ZacetnaBarva == "W") // bela kraljica je vedno na belem polju, črna pa na črnem!
            {
                celice[0, 3] = new NavideznaCelica(0, 3, this);
                celice[0, 3].Figura = new Kraljica(nasprotna_barva, velikost);

                celice[7, 3] = new NavideznaCelica(7, 3, this);
                celice[7, 3].Figura = new Kraljica(barva, velikost);
            }
            else
            {
                celice[0, 4] = new NavideznaCelica(0, 4, this);
                celice[0, 4].Figura = new Kraljica(nasprotna_barva, velikost);

                celice[7, 4] = new NavideznaCelica(7, 4, this);
                celice[7, 4].Figura = new Kraljica(barva, velikost);
            }

            // kralja:
            if (this.ZacetnaBarva == "W") // bela kralj je vedno na črnem polju, črni pa na belem!
            {
                celice[0, 4] = new NavideznaCelica(0, 4, this);
                celice[0, 4].Figura = new Kralj(nasprotna_barva, velikost);

                celice[7, 4] = new NavideznaCelica(7, 4, this);
                celice[7, 4].Figura = new Kralj(barva, velikost);
            }
            else
            {
                celice[0, 3] = new NavideznaCelica(0, 3, this);
                celice[0, 3].Figura = new Kralj(nasprotna_barva, velikost);

                celice[7, 3] = new NavideznaCelica(7, 3, this);
                celice[7, 3].Figura = new Kralj(barva, velikost);
            }

            return celice;   
        }

        public override string ToString()
        {
            string niz = "";
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (celice[i, j].Figura == null) { niz += "00"; }
                    else { niz += celice[i, j].Figura.Ime + " "; }
                }
                niz += '\n';
            }
            return niz;
        }

        /// <summary>
        /// Funkcija vrne nasprotno barvo 
        /// </summary>
        /// <param name="barva"></param>
        /// <returns>Vrne niz "W" ali "B"</returns>
        public static string NasprotnaBarva(string barva)
        {
            if (barva == "W") return "B";
            else return "W";
        }

        /// <summary>
        /// Funkcija nam pove, ali je polje na katerega kliknemo že obarvano oziroma
        /// lahko tja prestavimo figuro.
        /// </summary>
        /// <returns>true ali false</returns>
        public bool jeObarvanoPolje(Celica gumb)
        {
            NavideznaCelica celica = Celice[gumb.X, gumb.Y];
            return celica.JeMozna;
        }

        /// <summary>
        /// Fumnkcija naredi premik figure na navidezni sahovnici.
        /// </summary>
        /// <param name="gumb"></param>
        /// <returns>Vrne celico, iz katere se je figura prestavila</returns>
        public List<NavideznaCelica> PrestaviFiguro(Celica gumb)
        {
            List<NavideznaCelica> prejsneCelice = new List<NavideznaCelica>();         
            NavideznaCelica celica = Celice[gumb.X, gumb.Y];
            NavideznaFigura figura = Celice[gumb.X, gumb.Y].Figura;
            prejsneCelice.Add(this.PrejsnaCelica);
            if (jeRosada(celica)) {
                NarediRosado(celica, prejsneCelice);
            }
            celica.Figura = PrejsnaCelica.Figura;
            celica.Figura.Premaknjen = true;
            PrejsnaCelica.Figura = null;
            PonastaviMozneCelice();
            PrejsnaCelica = celica;

            return prejsneCelice;
        }

        /// <summary>
        /// Funkcija vrne true, če premik na podano celico predstavlja rošado
        /// </summary>
        /// <param name="celica"></param>
        /// <returns></returns>
        public bool jeRosada(NavideznaCelica celica)
        {
            if (PrejsnaCelica is null) return false;
            if (PrejsnaCelica.Figura is null) return false;
            if (PrejsnaCelica.Figura.GetType() == typeof(Kralj) && Math.Abs(celica.Y - PrejsnaCelica.Y) == 2) // rosada je takrat, ko se kralj pomakne za 2 mesti
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funkcija "premakne" trdnjavo na pravilno mesto po rošadi
        /// </summary>
        /// <param name="celica"></param>
        public void NarediRosado(NavideznaCelica celica, List<NavideznaCelica> prejsneCelice)
        {
            if (celica.Y < this.PrejsnaCelica.Y)
            {
                NarediLevoRosado(celica, prejsneCelice);
            }
            else
            {
                NarediDesnoRosado(celica, prejsneCelice);
            }
        }

        public void NarediLevoRosado(NavideznaCelica celica, List<NavideznaCelica> prejsneCelice)
        {
            if (this.ZacetnaBarva == "W")
            {
                this.Celice[celica.X, 3].Figura = this.Celice[celica.X, 0].Figura;
                this.Celice[celica.X, 3].Figura.Premaknjen = true;
                this.Celice[celica.X, 0].Figura = null;
                prejsneCelice.Add(this.Celice[celica.X, 3]);
                this.Celice[celica.X, 3].Figura.Premaknjen = true;
            }
            else
            {
                this.Celice[celica.X, 2].Figura = this.Celice[celica.X, 0].Figura;
                this.Celice[celica.X, 2].Figura.Premaknjen = true;
                this.Celice[celica.X, 0].Figura = null;
                prejsneCelice.Add(this.Celice[celica.X, 2]);
                this.Celice[celica.X, 2].Figura.Premaknjen = true;
            }
        }
        /// <summary>
        /// Funkcija preveri ali smo prestavili kmeta na zadnjo polje
        /// </summary>
        /// <param name="gumb"></param>
        /// <returns>vrne true, če je kmet na zadnjem polju na sahovnici</returns>
        public bool PrikaziRezervo(Celica gumb)
        {
            NavideznaCelica celica = Celice[gumb.X, gumb.Y];
            NavideznaFigura figura = Celice[gumb.X, gumb.Y].Figura;
            if ((figura.GetType() == typeof(Kmet)) && (celica.X == 0 || celica.X == 7)) return true;
            return false;
        }
        /// <summary>
        /// Naredi zamenjavo kmeta z rezervo.
        /// </summary>
        /// <param name="gumb"></param>
        /// <returns></returns>
        public NavideznaCelica NarediZamenjavo(Celica gumb)
        {
            NavideznaFigura rezervnaFigura;
            if (PrejsnaCelica.Figura.Barva == "W")
            {
                rezervnaFigura = NavideznaRezerva.BelaRezerva[gumb.X].Figura;
            }
            else
            {
                rezervnaFigura = NavideznaRezerva.CrnaRezerva[gumb.X].Figura;
            }
            PrejsnaCelica.Figura = rezervnaFigura;
            return this.PrejsnaCelica;
        }



        public void NarediDesnoRosado(NavideznaCelica celica, List<NavideznaCelica> prejsneCelice)
        {
            if (this.ZacetnaBarva == "W")
            {
                this.Celice[celica.X, 5].Figura = this.Celice[celica.X, 7].Figura;
                this.Celice[celica.X, 5].Figura.Premaknjen = true;
                this.Celice[celica.X, 7].Figura = null;
                prejsneCelice.Add(this.Celice[celica.X, 5]);
                this.Celice[celica.X, 5].Figura.Premaknjen = true;
            }
            else
            {
                this.Celice[celica.X, 4].Figura = this.Celice[celica.X, 7].Figura;
                this.Celice[celica.X, 4].Figura.Premaknjen = true;
                this.Celice[celica.X, 7].Figura = null;
                prejsneCelice.Add(this.Celice[celica.X, 4]);
                this.Celice[celica.X, 4].Figura.Premaknjen = true;
            }
        }

        /// <summary>
        /// Funkcija ponastavi vse celice, ki so bile nastavljene kot mozne
        /// </summary>
        public void PonastaviMozneCelice()
        {
            foreach (NavideznaCelica moznaCelica in this.MozneCelice)
            {
                this.Celice[moznaCelica.X, moznaCelica.Y].JeMozna = false;
            }
            this.MozneCelice = new List<NavideznaCelica>();
        }

        /// <summary>
        /// Funkcija poisce mozne poteze izbrane figure na navidezni sahovnici 
        /// in nastavi lastnost "jeMozna" posamezni celici
        /// </summary>
        /// <param name="gumb"></param>
        /// <returns> vrne seznam moznih celic </returns>
        public List<NavideznaCelica> PoisciMoznePoteze(Celica gumb)
        {
            PonastaviMozneCelice();
            NavideznaCelica celica = this.Celice[gumb.X, gumb.Y];
            NavideznaFigura figura = celica.Figura;

            if (figura is null) return new List<NavideznaCelica>();
            List<NavideznaCelica> moznePoteze = figura.MoznePoteze(celica, this);
            foreach (NavideznaCelica moznaCelica in moznePoteze)
            {
                this.Celice[moznaCelica.X, moznaCelica.Y].JeMozna = true;
            }
            PrejsnaCelica = celica;
            this.MozneCelice = moznePoteze;
            return moznePoteze;
        }

    }
}
