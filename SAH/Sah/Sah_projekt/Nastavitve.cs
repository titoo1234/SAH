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
            temaSagovnicaGumb1.Enabled = false;
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
            IzbranaBarva.Image = BelaBarva_Gumb.BackgroundImage;
        }
        private void CrnaBarva_Gumb_Click(object sender, EventArgs e)
        {
            CrnaBarva_gumb.Enabled = false;
            BelaBarva_Gumb.Enabled = true;
            //Image slika = CrnaBarva_gumb.Image;
            IzbranaBarva.Image = CrnaBarva_gumb.BackgroundImage;
            //IzbranaBarva.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void ZacetekIgre_Click(object sender, EventArgs e)
        {
            
            string barvaFigur;
            if (BelaBarva_Gumb.Enabled == false)
            {
                barvaFigur = "W";
            }
            else
            {
                barvaFigur = "B";
            }
            Color[] barve;
            if(temaSagovnicaGumb1.Enabled == false)
            {

                barve = new Color[] {Color.White, Color.Green, Color.Yellow };
            }
            else
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#4F2B1B");
                System.Drawing.Color col1 = System.Drawing.ColorTranslator.FromHtml("#fccc74");
                barve = new Color[] { col1, col, Color.Yellow };
            }
            Game newGame = new Game(true, false, false);
            newGame.Igra = new SoloIgra(barvaFigur, barve, new Size(40,40), newGame);
            //SoloIgra solo = new SoloIgra(string barva, string tema);


            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }

        private void temaSagovnicaGumb1_Click(object sender, EventArgs e)
        {
            temaSagovnicaGumb1.Enabled = false;
            temaSahovnicaGumb2.Enabled = true;
            IzbranaTema.Image = temaSagovnicaGumb1.Image;
        }

        private void temaSahovnicaGumb2_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb2.Enabled = false;
            temaSagovnicaGumb1.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb2.Image;
        }

        private void Izbrano_Click(object sender, EventArgs e)
        {

        }
    }
}
