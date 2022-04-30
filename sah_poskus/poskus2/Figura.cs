﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
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
        public Figura(string ime, int x, int y, Size velikost)
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
                this.Barva = "" + ime[0];
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
                        //trenutna_celica.Mozen = true;
                        if (this.X - 2 >= 0 && !this.Premaknjen)
                        {
                            trenutna_celica = sahovnica.Celice[this.X - 2, this.Y];
                            trenutna_figura = trenutna_celica.Figura;
                            if (trenutna_figura.Ime == "")
                            {
                                mozne.Add(trenutna_celica);
                                //trenutna_celica.Mozen = true;
                            }
                        }
                    }
                }
                if (this.X - 1 >= 0 && this.Y - 1 >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - 1, this.Y - 1];
                    Figura trenutna_figura = trenutna_celica.Figura;

                    if (this.Nasprotnik(trenutna_figura) && trenutna_figura.Ime != "")
                    {
                        mozne.Add(trenutna_celica);
                        ////trenutna_celica.Mozen = true;
                    }
                }
                if (this.X - 1 >= 0 && this.Y + 1 <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - 1, this.Y + 1];
                    Figura trenutna_figura = trenutna_celica.Figura;

                    if (this.Nasprotnik(trenutna_figura) && trenutna_figura.Ime != "")
                    {
                        mozne.Add(trenutna_celica);
                        ////trenutna_celica.Mozen = true;
                    }
                    //trenutna_celica.Mozen = true
                }
            }

            //ČRNI KMET
            if (this.Ime == "BP")
            {

                if (this.X + 1 <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + 1, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        //trenutna_celica.Mozen = true;
                        if (this.X + 2 <= 7 && !this.Premaknjen)
                        {
                            trenutna_celica = sahovnica.Celice[this.X + 2, this.Y];
                            trenutna_figura = trenutna_celica.Figura;
                            if (trenutna_figura.Ime == "")
                            {
                                mozne.Add(trenutna_celica);
                                //trenutna_celica.Mozen = true;
                            }
                        }
                    }
                }
                if (this.X + 1 <= 7 && this.Y - 1 >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + 1, this.Y - 1];
                    Figura trenutna_figura = trenutna_celica.Figura;

                    if (this.Nasprotnik(trenutna_figura) && trenutna_figura.Ime != "")
                    {
                        mozne.Add(trenutna_celica);
                        //trenutna_celica.Mozen = true;
                    }
                }
                if (this.X + 1 <= 7 && this.Y + 1 <= 7)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X + 1, this.Y + 1];
                    Figura trenutna_figura = trenutna_celica.Figura;

                    if (this.Nasprotnik(trenutna_figura) && trenutna_figura.Ime != "")
                    {
                        mozne.Add(trenutna_celica);
                        //trenutna_celica.Mozen = true;
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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

                        }
                        break;
                    }
                    i++;
                }
            }

            // KRALJ
            if (this.Ime == "WK" || this.Ime == "BK")
            {

                if (this.MoznaDesnaRosada(sahovnica))
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X, this.Y + 2];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    mozne.Add(trenutna_celica);
                    //trenutna_celica.Mozen = true;
                }
                if (this.MoznaLevaRosada(sahovnica))
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X, this.Y - 2];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    mozne.Add(trenutna_celica);
                    //trenutna_celica.Mozen = true;
                }

                int i = 1;
                if (this.X - i >= 0)
                {
                    Celica trenutna_celica = sahovnica.Celice[this.X - i, this.Y];
                    Figura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura.Ime == "") // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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
                        //trenutna_celica.Mozen = true;
                    }

                    else
                    {
                        if (this.Nasprotnik(trenutna_figura))
                        {
                            mozne.Add(trenutna_celica);
                            //trenutna_celica.Mozen = true;

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

        public bool MoznaLevaRosada(Sahovnica sahovnica)
        {

            Celica celica_trdnjava = sahovnica.Celice[this.X, 0];
            Figura trdnjava_figura = celica_trdnjava.Figura;
            if (!this.Premaknjen && !trdnjava_figura.Premaknjen && (trdnjava_figura.Ime == "WR" || trdnjava_figura.Ime == "BR"))
            {
                //preverimo če so umesne prazne
                if (sahovnica.Celice[this.X, 1].Figura.Ime == "" && sahovnica.Celice[this.X, 2].Figura.Ime == "" && sahovnica.Celice[this.X, 3].Figura.Ime == "")
                {
                    return true;
                }
            }
            return false;
        }
        public bool MoznaDesnaRosada(Sahovnica sahovnica)
        {

            Celica celica_trdnjava = sahovnica.Celice[this.X, 7];
            Figura trdnjava_figura = celica_trdnjava.Figura;
            if (!this.Premaknjen && !trdnjava_figura.Premaknjen && (trdnjava_figura.Ime == "WR" || trdnjava_figura.Ime == "BR"))
            {
                //preverimo če so umesne prazne
                if (sahovnica.Celice[this.X, 6].Figura.Ime == "" && sahovnica.Celice[this.X, 5].Figura.Ime == "")
                {
                    return true;
                }
            }
            return false;
        }

        public static void Rosada(Sahovnica sahovnica, Figura kralj, Celica gumb)
        {

            if (kralj.Y - gumb.Y == -2)//JE ROŠADA NA DESNI
            {

                Celica celica_trdnjava = sahovnica.Celice[gumb.X, gumb.Y + 1];

                //SPREMENIMO CELICO ZA ENA LEVO OD CELICE NA KATERO KLIKNEMO
                Figura trdnjava = celica_trdnjava.Figura;
                trdnjava.X = gumb.X;
                trdnjava.Y = gumb.Y - 1;
                trdnjava.Premaknjen = true;
                sahovnica.Celice[gumb.X, gumb.Y - 1].Figura = trdnjava;
                sahovnica.Celice[gumb.X, gumb.Y - 1].Image = trdnjava.Slika;

                //SPREMENIMO SKRAJNO DESNO CELICO

                Figura nova = new Figura("", gumb.X, gumb.Y +1, gumb.Size);
                celica_trdnjava.Figura = nova;
                celica_trdnjava.Image = nova.Slika;

            }

            if (kralj.Y - gumb.Y == 2)//JE ROŠADA NA LEVI
            {

                Celica celica_trdnjava = sahovnica.Celice[gumb.X, gumb.Y - 2];

                //SPREMENIMO CELICO ZA ENA DESNO OD CELICE NA KATERO KLIKNEMO
                Figura trdnjava = celica_trdnjava.Figura;
                trdnjava.X = gumb.X;
                trdnjava.Y = gumb.Y + 1;
                trdnjava.Premaknjen = true;
                sahovnica.Celice[gumb.X, gumb.Y + 1].Figura = trdnjava;
                sahovnica.Celice[gumb.X, gumb.Y + 1].Image = trdnjava.Slika;

                //SPREMENIMO SKRAJNO LEVO CELICO

                Figura nova = new Figura("", gumb.X, gumb.Y - 2, gumb.Size);
                celica_trdnjava.Figura = nova;
                celica_trdnjava.Image = nova.Slika;

            }





        }
    
        public static bool JeSah(Sahovnica sahovnica, string kralj)
        {
            //GREMO SKOZI VSE FIGURE, ZA VSAKO PREVERIMO ČE "NAPADA" NASPROTNEGA KRALJA
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Celica celica = sahovnica.Celice[i, j];
                    Figura figura = celica.Figura;
                    List < Celica > mozne_poteze = figura.MoznePoteze(sahovnica);
                    foreach(Celica mozna in mozne_poteze)
                    {
                        if (mozna.Figura.Ime == kralj)
                        {
                            return true;
                        }
                    }
               
                }
                
            }
            return false;
        }

        public static List<Celica> PreveriMoznePoteze(Sahovnica sahovnica, List<Celica> mozne_poteze, Celica gumb)
        {
            List<Celica> ustrezne = new List<Celica>();
            //FIGURO "PRESTAVIMO" NA MOZNO POLJE
            //PREVERIMO ALI JE STORJENA NAPAKA (ŠAH NA SVOJEGA KRALJA)
            foreach(Celica mozna in mozne_poteze)
            {
   
                string barva = gumb.Figura.Barva;
                Figura shrani1 = sahovnica.Celice[mozna.X, mozna.Y].Figura;
                Figura sh1 = new Figura(shrani1.Ime, shrani1.X, shrani1.Y, gumb.Size);
                sh1.premaknjen = shrani1.Premaknjen;
                Figura shrani2 = sahovnica.Celice[gumb.X, gumb.Y].Figura;
                Figura sh2 = new Figura(shrani2.Ime, shrani2.X, shrani2.Y, gumb.Size);
                sh2.premaknjen = shrani2.Premaknjen;
                //PRESTAVIMO FIGURO
                sahovnica.Celice[mozna.X, mozna.Y].Figura = gumb.Figura;

                //sahovnica.Celice[mozna.X, mozna.Y].Figura.X = mozna.X;
                //sahovnica.Celice[mozna.X, mozna.Y].Figura.Y = mozna.Y;
                //NA STAREM MESTU SEDAJ NI FIGURE
                sahovnica.Celice[gumb.X, gumb.Y].Figura = new Figura("", gumb.X, gumb.Y, gumb.Size);
                //PREVERIMO ALI JE PO TEM KORAKU ŠAH


                if (!JeSah(sahovnica, barva + "K"))
                {

                    ustrezne.Add(mozna);
                }


            sahovnica.Celice[mozna.X, mozna.Y].Figura = sh1;
                sahovnica.Celice[gumb.X, gumb.Y].Figura = sh2;
                //NASTAVIMO NAZAJ VSE TAK KOT JE BILO PRED NAVIDEZNIM PREMIKOM


            }
     

            return ustrezne;
        }
    
        public static bool Mat(Sahovnica sahovnica, List<Celica> mozne)
        {
            if (mozne.Count == 0)
            {
                return true;
            }
            return false;
        }

        public static void ZamenjajKmeta()
        {

        }
    }

}