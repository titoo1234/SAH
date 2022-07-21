﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Sah_projekt
{
    public class SoloIgra : Igra
    {
        public SoloIgra(Nastavitve nastavitve)
        {
            string barva = nastavitve.Barva;
            Size velikost = nastavitve.Velikost;
            this.Podlaga = nastavitve.Game;
            Color[] tema = nastavitve.Tema;
            int cas = nastavitve.Cas * 60; // minute 
            this.SteviloPotez = 0;
            NavideznaSahovnica = new NavideznaSahovnica(barva, velikost);
            this.PravaSahovnica = new PravaSahovnica(NavideznaSahovnica, Podlaga, tema);
            this.Igralec1 = new Igralec(barva);
            this.Igralec2 = new Igralec(NavideznaSahovnica.VrniNasprotnoBarvo(barva));
            NastaviCas(cas);
            NastaviTrenutnegaIgralca();
            SpremeniLastnostGumbov();
         
            ZvokPremik.Play();//ker sicer je treba počakati nekaj časa
        }
            
       
        /// <summary>
        /// Funkcija predstavlja delovanje igre. S klikom na celico lahko:
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
                PreveriKonecIgre();
            }
            else 
            // kliknali smo na šahovnico
            {
                if (jeObarvanoPolje(gumb))
                {
                    if (SteviloPotez == 0) TrenutniIgralec.Timer.Start(); // začnemo odštevati čas
                    PrestaviFiguro(gumb);
                    if (NavideznaSahovnica.JeSah(NavideznaSahovnica.VrniNasprotnoBarvo(TrenutniIgralec.Barva))) ZvokEvent.Play();//mogoče bolš da preverimo tam ko je preveri konec igre
                    else ZvokPremik.Play();
                    SteviloPotez++;
                    if (PrikaziRezervo(gumb))
                    {
                        if (TrenutniIgralec == Igralec1) PravaSahovnica.PravaRezerva.PrikaziNasoRezervo();
                        else PravaSahovnica.PravaRezerva.PrikaziNasprotnoRezervo();
                        ZamrzniSahovnico();
                    }

                    ZamenjajIgralca();
                    PreveriKonecIgre();
                }
                else
                {
                    PrikaziMoznePoteze(gumb); 
                }
            }
        }
        // OSTALE FUNKCIJE SO V RAZREDU IGRA

    }
}
