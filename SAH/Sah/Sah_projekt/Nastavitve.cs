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
        private Color[] tema;
        private Size velikost;
        private string barva;
        private Game game;
        private int cas;

        public Nastavitve()
        {
            InitializeComponent();
            BelaBarva_Gumb.Enabled = false;
            temaSahovnicaGumb1.Enabled = false;
            IzberiCas.SelectedIndex = 2;
        }
        public Game Game { get; set; }
        public Color[] Tema { get; set; }
        public Size Velikost { get; set; }
        public string Barva { get; set; }
        public int Cas { get; set; }

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
            Color[] barve;

            if (BelaBarva_Gumb.Enabled == false)
            {
                barvaFigur = "W";
                this.Barva = "W";

            }
            else
            {
                barvaFigur = "B";
                this.Barva = "B";
            }
            
            if (temaSahovnicaGumb1.Enabled == false)
            {
                barve = new Color[] {Color.White, Color.Green, Color.Yellow };
                this.Tema = barve = new Color[] { Color.White, Color.Green, Color.Yellow };
            }
            else
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#4F2B1B");
                System.Drawing.Color col1 = System.Drawing.ColorTranslator.FromHtml("#fccc74");
                barve = new Color[] { col1, col, Color.Yellow };
                this.Tema = new Color[] { col1, col, Color.Yellow };
            }
            this.Velikost = new Size(40, 40);
            this.Cas = int.Parse((string)IzberiCas.SelectedItem);
            this.Game = new Game(true, false, false);

            

            this.Game.Igra = new SoloIgra(this);
            

            //barvaFigur, barve, new Size(40,40), newGame

            //SoloIgra solo = new SoloIgra(string barva, string tema);

            Visible = false;
            if (!this.Game.IsDisposed)
                this.Game.ShowDialog();
            Visible = true;
        }

        private void temaSahovnicaGumb1_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb1.Enabled = false;
            temaSahovnicaGumb2.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb1.Image;
        }

        private void temaSahovnicaGumb2_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb2.Enabled = false;
            temaSahovnicaGumb1.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb2.Image;
        }

        private void Izbrano_Click(object sender, EventArgs e)
        {

        }

        private void Nastavitve_Load(object sender, EventArgs e)
        {

        }
    }
}
