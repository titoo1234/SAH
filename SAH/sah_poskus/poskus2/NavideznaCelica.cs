using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class NavideznaCelica
    {
        private int x;
        private int y;
        private NavideznaFigura figura;
        private NavideznaSahovnica sahovnica;

        public NavideznaCelica(int x, int y)
        {
            this.X = x; 
            this.Y = y;
            this.Figura = null;
        }
        public int X { get; set; }
        public int Y { get; set; }  
        public NavideznaFigura Figura { get; set; } 
        public NavideznaSahovnica Sahovnica { get; set; }

        /// <summary>
        /// Funkcija vrne celico nad trenutno celico.
        /// Če pa je trenutna celica najbolj zgornja VRNE ISTO CELICO
        /// </summary>
        /// <returns>vrne celico</returns>
        public NavideznaCelica ZgornjaCelica()
        {
            if (this.X != 0) { return Sahovnica.Celice[this.X - 1, this.Y]; }
            else return this;
        }

        /// <summary>
        /// Funkcija vrne celico nad trenutno celico.
        /// Če pa je trenutna celica najbolj spodnja VRNE ISTO CELICO
        /// </summary>
        /// <returns>vrne celico</returns>
        public NavideznaCelica SpodnjaCelica()
        {
            if (this.X != 7) { return Sahovnica.Celice[this.X + 1, this.Y]; }
            else return this;
        }

        /// <summary>
        /// Funkcija vrne celico nad trenutno celico.
        /// Če pa je trenutna celica najbolj leva VRNE ISTO CELICO
        /// </summary>
        /// <returns>vrne celico</returns>
        public NavideznaCelica LevaCelica()
        {
            if (this.Y != 0) { return Sahovnica.Celice[this.X, this.Y - 1]; }
            else return this;
        }

        /// <summary>
        /// Funkcija vrne celico nad trenutno celico.
        /// Če pa je trenutna celica najbolj desna VRNE ISTO CELICO
        /// </summary>
        /// <returns>vrne celico</returns>
        public NavideznaCelica DesnaCelica()
        {
            if (this.X != 7) { return Sahovnica.Celice[this.X, this.Y + 1]; }
            else return this;
        }

    }

}
