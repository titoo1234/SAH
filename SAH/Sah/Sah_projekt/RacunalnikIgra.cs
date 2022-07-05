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
            StringBuilder stockFishOutput;
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
            ZazeniStockFish();
            SpremeniLastnostGumbov();
            if (TrenutniIgralec != Igralec1)
            {
                RacunalnikNarediPotezo();
            }
        }

        public Process Process { get; set; }
        public StringBuilder StockFishOutput { get; set; }

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
            // StockFish-u podamo trenutne pozicije figur ter zaženemo program
            string nastaviPozicijo = "position fen " + this.PravaSahovnica.NavideznaSahovnica.FENniz(TrenutniIgralec.Barva);
            Process.StandardInput.WriteLine(nastaviPozicijo);
            // zaženemo program (počaka 3 sekunde)
            string narediPotezo = "go movetime 1000";
            Process.StandardInput.WriteLine(narediPotezo);
        }

        public void ZazeniStockFish()
        {
            //this.Process = new Process();
            //Process.StartInfo.FileName = @"C:\Users\damij\Desktop\stockfish_15_win_x64_popcnt\stockfish_15_x64_popcnt.exe";
            //Process.StartInfo.UseShellExecute = false;
            //Process.StartInfo.RedirectStandardInput = true;
            //Process.StartInfo.RedirectStandardOutput = true;
            ////Process.StartInfo.CreateNoWindow = true;
            //Process.Start();

            this.Process = new Process();
            Process.StartInfo.FileName = @"C:\Users\damij\Desktop\stockfish_15_win_x64_popcnt\stockfish_15_x64_popcnt.exe";
            Process.StartInfo.UseShellExecute = false;
            Process.StartInfo.RedirectStandardInput = true;
            Process.StartInfo.RedirectStandardOutput = true;
            StockFishOutput = new StringBuilder();
            Process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
            Process.StartInfo.CreateNoWindow = true;
            Process.Start();
            Process.BeginOutputReadLine();

            string nastaviTezavnost = "setoption name Skill Level value 20";
            Process.StandardInput.WriteLine(nastaviTezavnost);
        }

        /// <summary>
        /// Funkcija sproti "bere" zapise v StockFish programu
        /// </summary>
        /// <param name="sendingProcess"></param>
        /// <param name="izpis"></param>
        public void OutputHandler(object sendingProcess, DataReceivedEventArgs izpis)
        {
            if (jePoteza(izpis.Data)) // prišli smo do zadnje vrstice outputa
            {
                List<NavideznaCelica> poteza = pretvoriVPotezo(izpis.Data, this.PravaSahovnica.NavideznaSahovnica);
                PravaSahovnica.RacunalnikNarediPotezo(poteza);
                ZamenjajIgralca();
            }
        }

        /// <summary>
        /// Funkcija pregleda podani niz in vrne true, če predstavlja potezo v StockFish programu 
        /// oziroma, če je npr. oblike "bestmove d2d4 ponder d7d5"
        /// </summary>
        /// <param name="niz"></param>
        /// <returns></returns>
        public static bool jePoteza(string niz)
        {
            if (niz.Substring(0, 8) == "bestmove") return true;
            return false;
        }

        /// <summary>
        /// Funkcija pretvori potezo iz niza v seznam [zacetna poteza, koncna poteza]
        /// </summary>
        /// <param name="nizPoteza"></param>
        /// <returns></returns>
        public static List<NavideznaCelica> pretvoriVPotezo(string nizPoteza, NavideznaSahovnica sahovnica)
        {
            string[] zadnjaVrstica = nizPoteza.Split(' ');
            string najPoteza = zadnjaVrstica[1];
            string prvaCelica = najPoteza.Substring(0, 2);
            string drugaCelica = najPoteza.Substring(2, 2);
            NavideznaCelica prejsna = pretvoriVCelico(prvaCelica, sahovnica);
            NavideznaCelica novaCelica = pretvoriVCelico(drugaCelica, sahovnica);
            return new List<NavideznaCelica> { prejsna, novaCelica };
        }

        /// <summary>
        /// Funkcija pretvori zapis polja na sahovnici iz niza v celico npr.: "a1" --> polje 
        /// </summary>
        /// <param name="niz"></param>
        /// <returns></returns>
        public static NavideznaCelica pretvoriVCelico(string niz, NavideznaSahovnica sahovnica)
        {
            Dictionary<char, int> slovar = new Dictionary<char, int>() {
                {'a', 0},
                {'b', 1},
                {'c', 2},
                {'d', 3},
                {'e', 4},
                {'f', 5},
                {'g', 6},
                {'h', 7},
            };
            int x = 8 - int.Parse(niz[1] + ""); // zapisa v x smeri se razlikujeta (nasa impl: 0 -> 7 ; stockFish impl: 8 -> 1)
            int y = slovar[niz[0]];
            NavideznaCelica celica = sahovnica.Celice[x, y];
            return celica;
        }

        // OSTALE FUNKCIJE SO V RAZREDU IGRA
    }
}
