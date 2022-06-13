using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah_projekt
{
    public partial class Nastavitve : Form
    {
        private Igra igra;

        

        public Nastavitve()
        {
            InitializeComponent();
            BelaBarva_Gumb.Enabled = false;
            this.Igra = igra;

        }

        public Igra Igra { get; set; }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BelaBarva_Gumb_Click(object sender, EventArgs e)
        {
            BelaBarva_Gumb.Enabled = false;
            CrnaBarva_gumb.Enabled = true;
        }
        private void CrnaBarva_Gumb_Click(object sender, EventArgs e)
        {
            CrnaBarva_gumb.Enabled = false;
            BelaBarva_Gumb.Enabled = true;
        }

        private void ZacetekIgre_Click(object sender, EventArgs e)
        {
            Game newGame = new Game(true, false, false);
            newGame.Igra = new SoloIgra("B",  Color.White, new Size(40,40), newGame);
            //SoloIgra solo = new SoloIgra(string barva, string tema);


            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }
    }
}
