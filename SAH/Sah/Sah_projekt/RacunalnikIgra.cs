﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah_projekt
{
    public class RacunalnikIgra : Igra
    {
        public RacunalnikIgra(Nastavitve nastavitve)
        {
            string barva = nastavitve.Barva;
            Size velikost = nastavitve.Velikost;
            this.Podlaga = nastavitve.Game;
            Color[] tema = nastavitve.Tema;
            int cas = nastavitve.Cas;
            NavideznaSahovnica = new NavideznaSahovnica(barva, velikost);
            this.PravaSahovnica = new PravaSahovnica(NavideznaSahovnica, Podlaga, tema);
            this.Igralec1 = new Igralec(barva);
            this.Igralec2 = new Igralec(NavideznaSahovnica.VrniNasprotnoBarvo(barva));
            NastaviCas(cas);
            NastaviTrenutnegaIgralca();
            SpremeniLastnostGumbov();
            if (TrenutniIgralec != Igralec1)
            {  
                RacunalnikNarediPotezo();
            }
        }

        /// <summary>
        /// Funkcija predstavlja delovanje igre. S kllikom na celico lahko:
        /// - prestavimo figuro
        /// - pogledamo možne poteze 
        /// </summary>
        /// <param name="sender">gumb na katerega kliknemo</param>
        /// <param name="e"></param>
        public override void KlikNaCelico(object sender, EventArgs e)
        {
            Celica gumb = (Celica)sender;
            if (KliknemoNaRezervo(gumb))
            {
                NarediZamenjavo(gumb);
                OdmrzniSahovnico();
                ZamenjajIgralca();
                PreveriMat();
                RacunalnikNarediPotezo();
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
                        // break
                    }
                    else
                    {
                        ZamenjajIgralca();
                        PreveriMat();
                        RacunalnikNarediPotezo();
                    }
                }
                else
                {
                    PrikaziMoznePoteze(gumb);
                }
            }
        }

        public void RacunalnikNarediPotezo()
        {
            PravaSahovnica.RacunalnikNarediPotezo();
            ZamenjajIgralca();
        }

        // OSTALE FUNKCIJE SO V RAZREDU IGRA
    }
}
