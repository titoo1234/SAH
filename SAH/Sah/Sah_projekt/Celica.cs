using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sah_projekt
{
    public class Celica : Button
    {
        private int x;
        private int y;
        public Celica(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public Celica(int x)
        {
            this.X = x;
            this.Y = -1;
        }
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Funkcija spremeni barvo celice, glede na pozicijo kje se celica nahaja
        /// </summary>
        /// <param name="barvaSodoMesto"></param>
        /// <param name="barvaLihoMesto"></param>
        public void SpremeniBarvo(Color barvaSodoMesto, Color barvaLihoMesto)
        {
            if ((this.X + this.Y) % 2 == 0)
            {
                this.BackColor = barvaSodoMesto;
            }
            else
            {
                this.BackColor= barvaLihoMesto;
            }
        }
    }
}
