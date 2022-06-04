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

        public NavideznaCelica(int x, int y)
        {
            this.X = x; 
            this.Y = y;
            this.Figura = null;
        }
        public int X { get; set; }
        public int Y { get; set; }  
        public NavideznaFigura Figura { get; set; } 

    }

}
