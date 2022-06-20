﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class SoloIgra : Igra
    {
        public SoloIgra(string barva, Color[] tema, Size velikost, Game podlaga) 
        {
            NavideznaSahovnica = new NavideznaSahovnica(barva, velikost);
            this.PravaSahovnica = new PravaSahovnica(NavideznaSahovnica, podlaga, tema);
            this.Igralec1 = new Igralec(barva);
            this.Igralec2 = new Igralec(NavideznaSahovnica.NasprotnaBarva(barva));
            this.TrenutniIgralec = Igralec1;
            SpremeniLastnostGumbov();
        }

        //gremo skozi vse gumbe
        //gumb.click += funckcija
        /// <summary>
        /// Funkcija nastavi lastnosti posameznemu polju(gumbu) na šahovnici
        /// </summary>
        public void SpremeniLastnostGumbov()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Celica celica = PravaSahovnica.Celice[i, j];
                    celica.Click += KlikNaCelico;
                }
            }
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
            }
            else
            {
                if (jeObarvanoPolje(gumb))
                {
                    PrestaviFiguro(gumb);
                    if (PrikaziRezervo(gumb))
                    {
                        if (TrenutniIgralec == Igralec1)
                        {
                            PravaSahovnica.PravaRezerva.PrikaziNasoRezervo();
                        }
                        else
                        {
                            PravaSahovnica.PravaRezerva.PrikaziNasprotnoRezervo();
                        }
                        
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

        public void PrikaziMoznePoteze(Celica gumb)
        {
            PravaSahovnica.PrikaziMoznePoteze(gumb);
        }
    }
}
