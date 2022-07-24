using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sah_projekt
{
    public class NavideznaRezerva
    {
        private NavideznaCelica[] belaRezerva;
        private NavideznaCelica[] crnaRezerva;
        private Size velikost;
        private string zacetnaBarva;
        public NavideznaRezerva(string zacetnaBarva, Size velikost)
        {
            this.ZacetnaBarva = zacetnaBarva;
            this.Velikost = velikost;
            this.BelaRezerva = NarediRezervo("W", Velikost);
            this.CrnaRezerva = NarediRezervo("B", Velikost);
        }
        public Size Velikost { get; set; }
        public string ZacetnaBarva { get; set; }
        public NavideznaCelica[] BelaRezerva { get; set; }
        public NavideznaCelica[] CrnaRezerva { get; set; }
        private NavideznaCelica[] NarediRezervo(string zacetnaBarva, Size velikost)
        {
            NavideznaCelica[] celice = new NavideznaCelica[4];
            celice[0] = new NavideznaCelica(0);
            celice[0].Figura = new Kraljica(zacetnaBarva, velikost);
            celice[1] = new NavideznaCelica(1);
            celice[1].Figura = new Trdnjava(zacetnaBarva, velikost);
            celice[2] = new NavideznaCelica(2);
            celice[2].Figura = new Konj(zacetnaBarva, velikost);
            celice[3] = new NavideznaCelica(3);
            celice[3].Figura = new Tekac(zacetnaBarva, velikost);
            return celice;
        }

    }
}
