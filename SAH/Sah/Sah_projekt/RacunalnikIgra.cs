using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah_projekt
{
    public class RacunalnikIgra : Igra
    {
        Process process;
        public RacunalnikIgra(Nastavitve nastavitve)
        {
            string barva = nastavitve.Barva;
            Size velikost = nastavitve.Velikost;
            this.Podlaga = nastavitve.Game;
            Color[] tema = nastavitve.Tema;
            int cas = nastavitve.Cas * 60; // minute 
            NavideznaSahovnica = new NavideznaSahovnica(barva, velikost);
            this.PravaSahovnica = new PravaSahovnica(NavideznaSahovnica, Podlaga, tema);
            this.Igralec1 = new Igralec(barva);
            this.Igralec2 = new Igralec(NavideznaSahovnica.VrniNasprotnoBarvo(barva));
            NastaviCas(cas);
            NastaviTrenutnegaIgralca();
            //ZazeniStockFish();
            SpremeniLastnostGumbov();
            if (TrenutniIgralec != Igralec1)
            {  
                RacunalnikNarediPotezo();
            }
        }

        public Process Process { get; set; }

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
                if (PreveriKonecIgre())
                {
                    return;
                }
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
                        if (PreveriKonecIgre())
                        {
                            return;
                        }
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

        public void ZazeniStockFish()
        {
            this.Process = new Process();
            Process.StartInfo.FileName = @"C:\Users\damij\Desktop\stockfish_15_win_x64_popcnt\stockfish_15_x64_popcnt.exe";
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardInput = true;
            Process.StartInfo.RedirectStandardOutput = true;
            //Process.StartInfo.CreateNoWindow = true;
            Process.Start();
        }

        // OSTALE FUNKCIJE SO V RAZREDU IGRA
    }
}
