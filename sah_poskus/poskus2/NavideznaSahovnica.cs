using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class NavideznaSahovnica
    {
        private string[,] polja;

        public NavideznaSahovnica(string barva)
        {
            this.Polja = NarediSahovnico(barva);
        }

        public string[,] Polja { get; set; }   

        /// <summary>
        /// Funkcija naredi sahovnico v obliki matrike nizov
        /// </summary>
        /// <param name="barva"> barva nam pove s katerim figurim začnemo</param>
        /// <returns>Vrne matriko nizov</returns>
        public static string[,] NarediSahovnico(string barva)
        {
            string[,] polja = new string[8, 8];
            string nasprotna_barva = NasprotnaBarva(barva);

            // v sredini sahovnice so prazna polja, ki jih označimo z praznimi nizi ""
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    polja[i, j] = ""; 
                }
            }

            // ustvarimo kmete
            for (int j = 0; j < 8; j++)
            {
                string zgornji_kmetje = nasprotna_barva + "P";
                string spodnji_kmetje = barva + "P";
                polja[1, j] = zgornji_kmetje;
                polja[6, j] = spodnji_kmetje;
            }

            // ostala polja 
            // Trdnjave:
            string zgornje_trdnjave = nasprotna_barva + "R";
            string spodnje_trdnjave = barva + "R";
            polja[0, 0] = zgornje_trdnjave;
            polja[0, 7] = zgornje_trdnjave;
            polja[7, 0] = spodnje_trdnjave;
            polja[7, 7] = spodnje_trdnjave;

            // konji:
            string zgornji_konji = nasprotna_barva + "N";
            string spodnji_konji = barva + "N";
            polja[0, 1] = zgornji_konji;
            polja[0, 6] = zgornji_konji;
            polja[1, 0] = spodnji_konji;
            polja[6, 7] = spodnji_konji;

            // tekači:
            string zgornji_tekaci = nasprotna_barva + "B";
            string spodnji_tekaci = barva + "B";
            polja[0, 2] = zgornji_tekaci;
            polja[0, 5] = zgornji_tekaci;
            polja[2, 0] = spodnji_tekaci;
            polja[5, 7] = spodnji_tekaci;

            // kraljici:
            string zgornja_kraljica = nasprotna_barva + "Q";
            string spodnja_kraljica = barva + "Q";
            polja[0, 3] = zgornja_kraljica;
            polja[7, 3] = spodnja_kraljica;

            // kraljici:
            string zgornji_kralj = nasprotna_barva + "K";
            string spodnji_kralj = barva + "K";
            polja[0, 4] = zgornji_kralj;
            polja[7, 4] = spodnji_kralj;

            return polja;   
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
