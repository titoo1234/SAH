using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class Kmet : NavideznaFigura
    {
        public Kmet(string barva, Size velikost, NavideznaCelica celica)
        {
            this.Ime = barva + "P";
            this.Barva = barva;
            NastaviSliko();
            Premaknjen = false;
            Vrednost = 1;
        }
        /// <summary>
        /// Funkcija nastavi sliko Figure na podlagi njene barve
        /// </summary>
        public void NastaviSliko()
        {
            if (this.Barva == "W") { this.Slika = new Bitmap(Properties.Resources.White_Pawn, Velikost); }
            else { this.Slika = new Bitmap(Properties.Resources.Black_Pawn, Velikost); }
        }

        /// <summary>
        /// Funkcija vrne seznam moznih potez kmeta 
        /// </summary>
        /// <param name="celica"></param>
        /// <returns>Vrne seznam</returns>
        public List<NavideznaCelica> MoznePoteze(NavideznaCelica celica)
        {
            List<NavideznaCelica> mozne = new List<NavideznaCelica>();
            if ((this.Barva == "W" && Sahovnica.ZacetnaBarva == "W") || (this.Barva == "B" && Sahovnica.ZacetnaBarva == "B"))
            // Igramo z belimi in so bele figure spodaj, igramo s črnimi in so črne spodaj
            {
                if (celica.X > 0) // Če nismo v zadnji vrstici 
                {
                    NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - 1, celica.Y]; // "gledamo" za eno mesto naprej
                    NavideznaFigura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura is null) // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        if (celica.X == 6) // če smo na začetnem položaju 
                        {
                            trenutna_celica = Sahovnica.Celice[celica.X - 2, celica.Y];
                            trenutna_figura = trenutna_celica.Figura;
                            if (trenutna_figura is null)
                            {
                                mozne.Add(trenutna_celica);
                            }
                        }
                    }
                }
                if (celica.X > 0 && celica.Y > 0) // zbijanje figur
                {
                    NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - 1, celica.Y - 1];
                    NavideznaFigura trenutna_figura = trenutna_celica.Figura;
                    if (this.Nasprotnik(trenutna_figura))
                    {
                        mozne.Add(trenutna_celica);
                    }
                }
                if (celica.X - 1 >= 0 && celica.Y + 1 <= 7)
                {
                    NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X - 1, celica.Y + 1];
                    NavideznaFigura trenutna_figura = trenutna_celica.Figura;

                    if (this.Nasprotnik(trenutna_figura))
                    {
                        mozne.Add(trenutna_celica);
                    }
                }
            }
            else
            {
                if (celica.X < 7)
                {
                    NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + 1, celica.Y];
                    NavideznaFigura trenutna_figura = trenutna_celica.Figura;
                    if (trenutna_figura is null) // prazna celica
                    {
                        mozne.Add(trenutna_celica);
                        if (celica.X == 1)
                        {
                            trenutna_celica = Sahovnica.Celice[celica.X + 2, celica.Y];
                            trenutna_figura = trenutna_celica.Figura;
                            if (trenutna_figura is null)
                            {
                                mozne.Add(trenutna_celica);
                            }
                        }
                    }
                }
                if (celica.X < 7 && celica.Y > 0)
                {
                    NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + 1, celica.Y - 1];
                    NavideznaFigura trenutna_figura = trenutna_celica.Figura;
                    if (this.Nasprotnik(trenutna_figura))
                    {
                        mozne.Add(trenutna_celica);
                    }
                }
                if (celica.X < 7 && celica.Y < 7)
                {
                    NavideznaCelica trenutna_celica = Sahovnica.Celice[celica.X + 1, celica.Y + 1];
                    NavideznaFigura trenutna_figura = trenutna_celica.Figura;

                    if (this.Nasprotnik(trenutna_figura))
                    {
                        mozne.Add(trenutna_celica);
                    }
                }
            }
            return mozne;
        }
    }
}