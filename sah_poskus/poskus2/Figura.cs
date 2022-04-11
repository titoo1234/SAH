using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace poskus2
{
    public class Figura
    {
        private string barva;
        public Figura(string barva)
        {
            this.Barva = barva;
        }
        public string Barva { get; set; }
    }
}
