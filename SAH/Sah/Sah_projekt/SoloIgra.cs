using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class SoloIgra : Igra
    {
        public SoloIgra(Nastavitve nastavitve)
        {//string barva, Color[] tema, Size velikost, Game podlaga
            string barva = nastavitve.Barva;
            Size velikost = nastavitve.Velikost;
            Game podlaga = nastavitve.Game;
            Color[] tema = nastavitve.Tema;
            NavideznaSahovnica = new NavideznaSahovnica(barva, velikost);
            this.PravaSahovnica = new PravaSahovnica(NavideznaSahovnica, podlaga, tema);
            this.Igralec1 = new Igralec(barva);
            this.Igralec2 = new Igralec(NavideznaSahovnica.NasprotnaBarva(barva));
            NastaviTrenutnegaIgralca();
            SpremeniLastnostGumbov();
        }


        /// <summary>
        /// Funckija nastavi začetnega igralca glede na barvo
        /// </summary>
        private void NastaviTrenutnegaIgralca()
        {
            if (Igralec1.Barva == "W")
            {
                this.TrenutniIgralec = Igralec1;
            }
            else
            {
                this.TrenutniIgralec = Igralec2;
            }
        }

        //gremo skozi vse gumbe
        //gumb.click += funckcija
        /// <summary>
        /// Funkcija nastavi lastnosti posameznemu polju(gumbu) na šahovnici
        /// </summary>
        public void SpremeniLastnostGumbov()
        {
            // Za šahovnico
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Celica celica = PravaSahovnica.Celice[i, j];
                    celica.Click += KlikNaCelico;
                }
            }
            // Za rezervne figure (ko pridemo s kmetom do konca)
            for (int i = 0;i < 4; i++)
            {
                Celica nasaCelica = PravaSahovnica.PravaRezerva.NasaRezerva[i];
                nasaCelica.Click += KlikNaCelico;
                Celica nasprotnaCelica = PravaSahovnica.PravaRezerva.NasprotnaRezerva[i];
                nasprotnaCelica.Click += KlikNaCelico;
            }
        }

        /// <summary>
        /// Funkcija predstavlja delovanje igre. S kllikom na celico lahko:
        /// - prestavimo figuro
        /// - pogledamo možne poteze 
        /// </summary>
        /// <param name="sender">gumb na katerega kliknemo</param>
        /// <param name="e"></param>
        private void KlikNaCelico(object sender, EventArgs e)
        {
            Celica gumb = (Celica)sender;
            if (KliknemoNaRezervo(gumb))
            {
                NarediZamenjavo(gumb);
                OdmrzniSahovnico();
                //ODMRZNICELICE
            }
            else 
            // kliknali smo na šahovnico
            {
                if (jeObarvanoPolje(gumb))
                {
                    PrestaviFiguro(gumb);

                    if (PrikaziRezervo(gumb))
                    {
                        if (TrenutniIgralec == Igralec1) PravaSahovnica.PravaRezerva.PrikaziNasoRezervo();
                        else PravaSahovnica.PravaRezerva.PrikaziNasprotnoRezervo();
                        ZamrzniSahovnico();
                    }

                    ZamenjajIgralca();
                }
                else
                {
                    PrikaziMoznePoteze(gumb); 
                }
            }
        }
        /// <summary>
        /// Funkcija odmrzne vse celice na sahovnici
        /// </summary>
        private void ZamrzniSahovnico()
        {
            PravaSahovnica.ZamrzniSahovnico();
        }

        /// <summary>
        /// Funkcija "zamrzne" vse celice v sahovnici
        /// </summary>
        private void OdmrzniSahovnico()
        {
            PravaSahovnica.OdmrzniSahovnico();
        }

        /// <summary>
        /// Funkcija preveri ali je kmet na koncu.
        /// </summary>
        /// <returns>true, če je kmet na koncu</returns>
        public bool PrikaziRezervo(Celica gumb)
        {
            return (NavideznaSahovnica.PrikaziRezervo(gumb));
        }

        /// <summary>
        /// Preveri ali smo kliknali na gumb, ki se nahaja v rezervi
        /// </summary>
        /// <param name="gumb"></param>
        /// <returns></returns>
        public bool KliknemoNaRezervo(Celica gumb)
        {
            
            return (gumb.Y == -1);
        }

        /// <summary>
        /// Funkcija naredi zamenjavo rezerve s kmetom.
        /// </summary>
        public void NarediZamenjavo(Celica gumb)
        {
            PravaSahovnica.NarediZamenjavo(gumb);
        }

        /// <summary>
        /// Funkcija nam pove, ali je polje na katerega kliknemo že obarvano oziroma
        /// lahko tja prestavimo figuro.
        /// </summary>
        /// <returns>true ali false</returns>
        public bool jeObarvanoPolje(Celica gumb)
        {
            return NavideznaSahovnica.jeObarvanoPolje(gumb);
        }
        
        /// <summary>
        /// Funkcija za prestavljanje figur
        /// </summary>
        /// <param name="gumb"></param>
        public void PrestaviFiguro(Celica gumb)
        {
            PravaSahovnica.PrestaviFiguro(gumb);
        }

        /// <summary>
        /// Funkcija zamenja trenutnega igralca 
        /// </summary>
        public void ZamenjajIgralca()
        {
            if (this.TrenutniIgralec == this.Igralec1)
            {
                this.TrenutniIgralec = this.Igralec2;
            }
            else
            {
                this.TrenutniIgralec = this.Igralec1;
            }
        }

        /// <summary>
        /// Funkcija na šahovnici obarva polja, na katere se lahko prestavimo z izbrano figuro
        /// </summary>
        /// <param name="gumb"></param>
        public void PrikaziMoznePoteze(Celica gumb)
        {
            PravaSahovnica.PrikaziMoznePoteze(gumb, TrenutniIgralec);
        }
    }
}
