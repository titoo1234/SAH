using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah_projekt
{
    public class PravaRezerva
    {
        private Game podlaga;
        private Celica[] nasaRezerva;
        private Celica[] nasprotnaRezerva;
        private Color[] tema;
        private NavideznaRezerva navideznaRezerva;
        public PravaRezerva(NavideznaRezerva navideznaRezerva, Game podlaga, Color[] tema)
        {
            this.NavideznaRezerva = navideznaRezerva;
            this.Podlaga = podlaga;
            this.NasaRezerva = NarediRezervo(navideznaRezerva.ZacetnaBarva);
            this.NasprotnaRezerva = NarediRezervo(NavideznaSahovnica.NasprotnaBarva(navideznaRezerva.ZacetnaBarva));
            this.Tema = tema;

        }

        public NavideznaRezerva NavideznaRezerva { get; set; }
        public Game Podlaga { get; set; }
        public Celica[] NasaRezerva { get; set; }
        public Celica[] NasprotnaRezerva { get; set; }
        public Color[] Tema { get; set; }
        private Celica[] NarediRezervo(string zacetnaBarva)
        {
            Size velikost = NavideznaRezerva.Velikost;
            Celica[] rezerva = new Celica[4];
            if (zacetnaBarva == NavideznaRezerva.ZacetnaBarva)
            {
                for (int i = 0; i < 4; i++)
                {
                    Celica gumb = new Celica(i);
                    gumb.Location = new Point(50 + i * velikost.Width, 50 - velikost.Width);
                    gumb.Size = velikost;
                    gumb.TabStop = false;
                    gumb.FlatStyle = FlatStyle.Flat;
                    gumb.FlatAppearance.BorderSize = 0;
                    if (zacetnaBarva == "W")
                    {
                        gumb.Image = NavideznaRezerva.BelaRezerva[i].Figura.Slika;
                    }
                    else
                    {
                        gumb.Image = NavideznaRezerva.CrnaRezerva[i].Figura.Slika;

                    }
                    gumb.Visible = false;
                    Podlaga.Controls.Add(gumb);
                    rezerva[i] = gumb;
                }

            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    Celica gumb = new Celica(i);
                    gumb.Location = new Point(50 + i * velikost.Width, 50 + 8 * velikost.Width);
                    gumb.Size = velikost;
                    gumb.TabStop = false;
                    gumb.FlatStyle = FlatStyle.Flat;
                    gumb.FlatAppearance.BorderSize = 0;
                    if (zacetnaBarva == "W")
                    {
                        gumb.Image = NavideznaRezerva.BelaRezerva[i].Figura.Slika;
                    }
                    else
                    {
                        gumb.Image = NavideznaRezerva.CrnaRezerva[i].Figura.Slika;

                    }
                    gumb.Visible = false;
                    Podlaga.Controls.Add(gumb);
                    rezerva[i] = gumb;
                }
            }

            return rezerva;

        }
        public void PrikaziNasoRezervo()
        {
            for (int i = 0; i < 4; i++)
            {
                Celica gumb = NasaRezerva[i];
                gumb.Visible = true;
            }

        }
        public void SkrijNasoRezervo()
        {
            for (int i = 0; i < 4; i++)
            {
                Celica gumb = NasaRezerva[i];
                gumb.Visible = false;
            }
        }
        public void PrikaziNasprotnoRezervo()
        {
            for (int i = 0; i < 4; i++)
            {
                Celica gumb = NasprotnaRezerva[i];
                gumb.Visible = true;
            }
        }
        public void SkrijNasprotnoRezervo()
        {
            for (int i = 0; i < 4; i++)
            {
                Celica gumb = NasprotnaRezerva[i];
                gumb.Visible = false;
            }
        }
    }
}
