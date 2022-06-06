using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class NavideznaSahovnica
    {
        private NavideznaCelica[,] celice;
        private Size velikost;
        private string zacetnaBarva;

        public NavideznaSahovnica(string zacetnaBarva, Size velikost)
        {
            this.ZacetnaBarva = zacetnaBarva;
            this.Velikost = velikost;
            this.Celice = NarediSahovnico(zacetnaBarva, Velikost);
        }

        public NavideznaCelica[,] Celice { get; set; }   
        public Size Velikost { get; set; }
        public string ZacetnaBarva { get; set; }

        /// <summary>
        /// Funkcija naredi sahovnico v obliki matrike Celic
        /// </summary>
        /// <param name="barva"> barva nam pove s katerimi figurami začnemo</param>
        /// <param name="velikost"></param>
        /// <returns>Vrne matriko Celic</returns>
        public static NavideznaCelica[,] NarediSahovnico(string barva, Size velikost)
        {
            NavideznaCelica[,] celice = new NavideznaCelica[8, 8];
            string nasprotna_barva = NasprotnaBarva(barva);

            // v sredini sahovnice so prazna polja, ki jih označimo z praznimi nizi ""
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    celice[i, j] = new NavideznaCelica(i, j);
                    // Figura je privzeto null
                }
            }

            // ustvarimo kmete
            for (int j = 0; j < 8; j++)
            {
                celice[1, j] = new NavideznaCelica(1, j);
                celice[1, j].Figura = new Kmet(nasprotna_barva, velikost, celice[1, j]);
                celice[6, j] = new NavideznaCelica(1, j);
                celice[6, j].Figura = new Kmet(barva, velikost, celice[6, j]);
            }

            // ostala polja 
            // Trdnjave:
            celice[0, 0] = new NavideznaCelica(0, 0);
            celice[0, 0].Figura = new Trdnjava(nasprotna_barva, velikost, celice[0, 0]);
            celice[0, 7] = new NavideznaCelica(0, 7);
            celice[0, 7].Figura = new Trdnjava(nasprotna_barva, velikost, celice[0, 7]);

            celice[7, 0] = new NavideznaCelica(7, 0);
            celice[7, 0].Figura = new Trdnjava(barva, velikost, celice[7, 0]);
            celice[7, 7] = new NavideznaCelica(7, 7);
            celice[7, 7].Figura = new Trdnjava(barva, velikost, celice[7, 7]);

            // konji:
            celice[0, 1] = new NavideznaCelica(0, 1);
            celice[0, 1].Figura = new Konj(nasprotna_barva, velikost, celice[0, 1]);
            celice[0, 6] = new NavideznaCelica(0, 6);
            celice[0, 6].Figura = new Konj(nasprotna_barva, velikost, celice[0, 6]);

            celice[7, 1] = new NavideznaCelica(7, 1);
            celice[7, 1].Figura = new Konj(barva, velikost, celice[7, 1]);
            celice[7, 6] = new NavideznaCelica(7, 6);
            celice[7, 6].Figura = new Konj(barva, velikost, celice[7, 6]);

            // tekači:
            celice[0, 2] = new NavideznaCelica(0, 2);
            celice[0, 2].Figura = new Tekac(nasprotna_barva, velikost, celice[0, 2]);
            celice[0, 5] = new NavideznaCelica(0, 5);
            celice[0, 5].Figura = new Tekac(nasprotna_barva, velikost, celice[0, 5]);

            celice[7, 2] = new NavideznaCelica(7, 2);
            celice[7, 2].Figura = new Tekac(barva, velikost, celice[7, 2]);
            celice[7, 5] = new NavideznaCelica(7, 5);
            celice[7, 5].Figura = new Tekac(barva, velikost, celice[7, 5]);

            // kraljici:
            celice[0, 3] = new NavideznaCelica(0, 3);
            celice[0, 3].Figura = new Kraljica(nasprotna_barva, velikost, celice[0, 3]);

            celice[7, 3] = new NavideznaCelica(7, 3);
            celice[7, 3].Figura = new Kraljica(barva, velikost, celice[7, 3]);

            // kraljici:
            celice[0, 4] = new NavideznaCelica(0, 4);
            celice[0, 4].Figura = new Kralj(nasprotna_barva, velikost, celice[0, 4]);

            celice[7, 4] = new NavideznaCelica(7, 4);
            celice[7, 4].Figura = new Kralj(barva, velikost, celice[7, 4]);

            return celice;   
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

    }
}
