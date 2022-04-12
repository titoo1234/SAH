using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace poskus2
{
    public class Figura
    {
        
        private string ime;
        private char barva;
        private Bitmap slika;
        private bool premaknjen;
        private int x;
        private int y;
        public Figura(string ime, int x, int y,Size velikost)
        {
            this.Y = y;
            this.X = x;
            this.Ime = ime;
            if (this.Ime == "")
            {
                this.Barva = "";
            }
            else
            {
                this.Barva = ""+ime[0];
            }
            this.Premaknjen = false;

            if (ime == "BP")
            {
                this.Slika = new Bitmap(Properties.Resources.Black_Pawn, velikost);
            }
            else if (ime == "WP")
            {
                this.Slika = new Bitmap(Properties.Resources.White_Pawn, velikost);
            }
            else if (ime == "BR")
            {
                this.Slika = new Bitmap(Properties.Resources.Black_Rook, velikost);
            }
            else if (ime == "BN")
            {
                this.Slika = new Bitmap(Properties.Resources.Black_Knight, velikost);
            }
            else if (ime == "BB")
            {
                this.Slika = new Bitmap(Properties.Resources.Black_Bishop, velikost);
            }
            else if (ime == "BQ")
            {
                this.Slika = new Bitmap(Properties.Resources.Black_Queen, velikost);
            }
            else if (ime == "BK")
            {
                this.Slika = new Bitmap(Properties.Resources.Black_King, velikost);
            }

            //BELE FIGURE
            else if (ime == "WR")
            {
                this.Slika = new Bitmap(Properties.Resources.White_Rook, velikost);
            }
            else if (ime == "WN")
            {
                this.Slika = new Bitmap(Properties.Resources.White_Knight, velikost);
            }
            else if (ime == "WB")
            {
                this.Slika = new Bitmap(Properties.Resources.White_Bishop, velikost);
            }
            else if (ime == "WQ")
            {
                this.Slika = new Bitmap(Properties.Resources.White_Queen, velikost);
            }
            else if (ime == "WK")
            {
                this.Slika = new Bitmap(Properties.Resources.White_King, velikost);
            }
            else//PRAZNA FIGURA OZ NI FIGURE
            {
                this.Slika = null;
            }

        }

        public int X { get; set; }
        public int Y { get; set; }
        public string Ime { get; set; }
        public string Barva { get; set; }
        public Bitmap Slika { get; set; }
        public bool Premaknjen { get; set; }


        public List<Celica> MoznePoteze(Sahovnica sahovnica)
        {
            List<Celica> mozne = new List<Celica>();


            //POGLEJMO ZA BELEGA KMETA
            if (this.Ime == "WP")
            {
                mozne.Add(sahovnica.Celice[this.X - 1, this.Y]);
                sahovnica.Celice[this.X - 1, this.Y].Mozen = true;
                mozne.Add(sahovnica.Celice[X - 2, Y]);
                sahovnica.Celice[this.X - 2, this.Y].Mozen = true;
            }

            return mozne;
        }


    }
}
