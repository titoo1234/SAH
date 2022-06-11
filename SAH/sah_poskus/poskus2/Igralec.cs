using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class Igralec
    {
        private int vsota;
        private string barva;
        public Igralec(string barva)
        {
            this.Barva = barva;
            this.Vsota = 39;

        }

        public string Barva { get;  set; }
        public int Vsota { get;  set; }

        public void  SpremeniStanje(Celica celica,bool rezerva)
        {
            if (rezerva)
            {
                this.Vsota += celica.Figura.Vrednost - 1;
            }
            else
            {
                this.Vsota -= celica.Figura.Vrednost;
            }
            

        }
    }
}
