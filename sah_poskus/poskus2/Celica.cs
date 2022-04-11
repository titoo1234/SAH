using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace poskus2
{
    public class Celica : Button
    {
        private int x;
        private int y;
        private string figura;
        public Celica(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Figura = "";
        }

        public string Figura { get; set; }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentException("X mora biti med 0 in 7");
                }
                this.x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value < 0 || value > 7)
                {
                    throw new ArgumentException("Y mora biti med 0 in 7");
                }
                this.y = value;
            }
        }
    }
}
