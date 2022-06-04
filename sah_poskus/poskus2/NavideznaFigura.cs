using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class NavideznaFigura
    {
        private string ime;
        private string barva;
        private Bitmap slika;
        private bool premaknjen;
        private int vrednost;
        private Size velikost;
        public NavideznaFigura()
        {

        }

        public string Ime { get; set; }
        public int Vrednost { get; set; }
        public string Barva { get; set; }
        public Bitmap Slika { get; set; }
        public bool Premaknjen { get; set; }
        public Size Velikost { get; set; }
 
    }
    
}
