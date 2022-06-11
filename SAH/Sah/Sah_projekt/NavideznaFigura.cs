using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class NavideznaFigura
    {
        private string ime;
        private string barva;
        private Bitmap slika;
        private bool premaknjen;
        private int vrednost;
        private Size velikost;
        private NavideznaSahovnica sahovnica;
        public NavideznaFigura()
        {

        }

        public string Ime { get; set; }
        public int Vrednost { get; set; }
        public string Barva { get; set; }
        public Bitmap Slika { get; set; }
        public bool Premaknjen { get; set; }
        public Size Velikost { get; set; }
        public NavideznaSahovnica Sahovnica { get; set; }

        /// <summary>
        /// Funkcija pove ali je podana figura nasprotne barve
        /// </summary>
        /// <param name="druga"></param>
        /// <returns></returns>
        public bool Nasprotnik(NavideznaFigura druga)
        {
            if (druga is null) // prazna celica
            {
                return false;
            }
            if (this.Barva == druga.Barva)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Funkcija doda podano celico med mozne poteze
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="trenutna_celica"></param>
        /// <returns>Vrne false, če se figura v podani smeri ne more več premikati, sicer true</returns>
        public bool DodajPremik(List<NavideznaCelica> mozne_poteze, NavideznaCelica trenutna_celica)
        {
            NavideznaFigura trenutna_figura = trenutna_celica.Figura;
            if (trenutna_figura is null) // prazna celica
            {
                mozne_poteze.Add(trenutna_celica);
                return true;
            }
            else
            {
                if (this.Nasprotnik(trenutna_figura))
                {
                    mozne_poteze.Add(trenutna_celica);
                }
                return false;
            }
        }

        /// <summary>
        /// Funkcija doda zgornjo celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        public bool DodajPremik_Gor(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X + i, celica.Y];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda spodnjo celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="trenutna_celica"></param>
        /// <returns></returns>
        public bool DodajPremik_Dol(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X - i, celica.Y];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda levo celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="celica"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DodajPremik_Levo(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X, celica.Y - i];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda desno celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="celica"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DodajPremik_Desno(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X, celica.Y + i];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda zgornjo-desno celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="celica"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DodajPremik_GorDesno(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X - i, celica.Y + i];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda spodnjo-desno celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="celica"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DodajPremik_DolDesno(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X + i, celica.Y + i];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda zgornjo-levo celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="celica"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DodajPremik_GorLevo(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X - i, celica.Y - i];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda spodnjo-levo celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="celica"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DodajPremik_DolLevo(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X + i, celica.Y - i];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija nam vrne true, če je trenutno na šahovnici napaden naš kralj
        /// </summary>
        /// <param name="sahovnica"></param>
        /// <param name="kralj"></param>
        /// <returns>true ali false</returns>
        public bool JeSah()
        {
            return false;
            //GREMO SKOZI VSE FIGURE, ZA VSAKO PREVERIMO ČE "NAPADA" NASPROTNEGA KRALJA
            //for (int i = 0; i < 8; i++)
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        NavideznaCelica celica = Sahovnica.Celice[i, j];
            //        NavideznaFigura figura = celica.Figura;
            //        List<Celica> mozne_poteze = figura.MoznePoteze(sahovnica);
            //        foreach (Celica mozna in mozne_poteze)
            //        {
            //            if (mozna.Figura.Ime == kralj)
            //            {
            //                return true;
            //            }
            //        }
            //    }
            //}
            //return false;
        }

    }
    
}
