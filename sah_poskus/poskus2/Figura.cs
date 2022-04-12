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


            // BEL KMET
            if (this.Ime == "WP")
            {
                
                if (this.X - 1 >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - 1, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                        if (this.X - 2 >= 0 && !this.Premaknjen)
                        {
                            trenutna_celica = sahovnica.Celice[this.X - 2, this.Y];
                            trenutna_figura = trenutna_celica.Figura;
                            if (trenutna_figura.Ime == "")
                            {
                                mozne.Add(trenutna_celica);
                                trenutna_celica.Mozen = true;
                            }
                        }
                    }
                }
            }

            // KRALJICA
            if (this.Ime == "WQ" || this.Ime == "BQ")
            {
                int i = 1;
                while (this.X - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;
                            
                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X + i <= 7 && this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X - i >= 0 && this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X + i <= 7 && this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X - i >= 0 && this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }



            }

            // TRDNJAVA
            if (this.Ime == "WR" || this.Ime == "BR")
            {
                int i = 1;
                while (this.X - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
            }

            // TEKAČ
            if (this.Ime == "WB" || this.Ime == "BB")
            {
                int i = 1;
                while (this.X + i <= 7 && this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X - i >= 0 && this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X + i <= 7 && this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
                i = 1;
                while (this.X - i >= 0 && this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
            }

            // KRALJ
            if (this.Ime == "WK" || this.Ime == "BK")
            {

                int i = 1;
                if (this.X - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        
                    }
                    
                }
                
                if (this.X + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        
                    }
                    
                }
                
                if (this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        
                    }
                    
                }
                
                if (this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        
                    }
                    
                }
                
                if (this.X + i <= 7 && this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        
                    }
                    
                }
                
                if (this.X - i >= 0 && this.Y + i <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y + i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        
                    }
                    
                }
                
                if (this.X + i <= 7 && this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        
                    }
                    
                }
                
                if (this.X - i >= 0 && this.Y - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y - i];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }
                        
                    }
                    
                }

            }

            // KONJ
            if (this.Ime == "WN" || this.Ime == "BN")
            {
                int i = 1;
                int j = 2;
                if (this.X - i >= 0 && this.Y - j >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y - j];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }

                    }

                }
                if (this.X + i <= 7 && this.Y - j >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y - j];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }

                    }

                }
                if (this.X - i >= 0 && this.Y + j <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y + j];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }

                    }

                }
                if (this.X + i <= 7 && this.Y + j <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y + j];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }

                    }

                }
                i = 2;
                j = 1;
                if (this.X - i >= 0 && this.Y - j >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y - j];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }

                    }

                }
                if (this.X + i <= 7 && this.Y - j >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y - j];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }

                    }

                }
                if (this.X - i >= 0 && this.Y + j <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y + j];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }

                    }

                }
                if (this.X + i <= 7 && this.Y + j <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + i, this.Y + j];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            trenutna_celica.Mozen = true;

                        }

                    }

                }
            }

            return mozne;
        }

        public bool Nasprotnik(Figura druga)
        {
            if (this.Barva == druga.Barva)
            {
                return false;
            }
            return true;
        }


    }
}
