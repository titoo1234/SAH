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
        private bool enPassant;
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
        public bool EnPassant { get; set; }

        public virtual List<NavideznaCelica> MoznePoteze(NavideznaCelica celica, NavideznaSahovnica sahovnica)
        {
            return new List<NavideznaCelica>();
        }
        // Naslednje funkcije preverijo ali je podana figura ustreznega tipa
        // ===================================================
        public bool jeKmet()
        {
            if (this != null && this.GetType() == typeof(Kmet)) return true;
            return false;
        }
        public bool jeTrdnjava()
        {
            if (this != null && this.GetType() == typeof(Trdnjava)) return true;
            return false;
        }
        public bool jeKonj()
        {
            if (this != null && this.GetType() == typeof(Konj)) return true;
            return false;
        }
        public bool jeTekac()
        {
            if (this != null && this.GetType() == typeof(Tekac)) return true;
            return false;
        }
        public bool jeKraljica()
        {
            if (this != null && this.GetType() == typeof(Kraljica)) return true;
            return false;
        }
        public bool jeKralj()
        {
            if (this != null && this.GetType() == typeof(Kralj)) return true;
            return false;
        }
        // ===================================================

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
        public bool DodajPremik_Gor(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i, NavideznaSahovnica sahovnica)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X - i, celica.Y];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda spodnjo celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="trenutna_celica"></param>
        /// <returns></returns>
        public bool DodajPremik_Dol(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i, NavideznaSahovnica sahovnica)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X + i, celica.Y];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }

        /// <summary>
        /// Funkcija doda levo celico med mozne_poteze, ce se lahko tja prestavimo 
        /// </summary>
        /// <param name="mozne_poteze"></param>
        /// <param name="celica"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool DodajPremik_Levo(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i, NavideznaSahovnica sahovnica)
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
        public bool DodajPremik_Desno(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i, NavideznaSahovnica sahovnica)
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
        public bool DodajPremik_GorDesno(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i, NavideznaSahovnica sahovnica)
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
        public bool DodajPremik_DolDesno(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i, NavideznaSahovnica sahovnica)
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
        public bool DodajPremik_GorLevo(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i, NavideznaSahovnica sahovnica)
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
        public bool DodajPremik_DolLevo(List<NavideznaCelica> mozne_poteze, NavideznaCelica celica, int i, NavideznaSahovnica sahovnica)
        {
            NavideznaCelica trenutna_celica = sahovnica.Celice[celica.X + i, celica.Y - i];
            return DodajPremik(mozne_poteze, trenutna_celica);
        }
    }
    
}
