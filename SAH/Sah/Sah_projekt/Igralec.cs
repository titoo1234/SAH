using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Sah_projekt
{
    public class Igralec
    {
        private int vsota;
        private string barva;
        private int cas;
        private Timer timer;
        private Label napis;
        private Form podlaga;
        private Igra igra;

        public Igralec(string barva)
        {
            this.Barva = barva;
            this.Vsota = 39;
        }
        public string Barva { get;  set; }
        public int Vsota { get;  set; }
        public Igra Igra { get;  set; }

        //public double Cas { get; set; }
        public int Cas { get; set; }
        public Timer Timer { get; set; }
        public Label Napis { get; set; }
        public Form Podlaga { get; set; }
        public void  SpremeniStanje(Celica celica,bool rezerva)
        {
            if (rezerva)
            {
                this.Vsota += celica.Figura.Vrednost - 1;
            }
            else
            {
                this.Vsota -= celica.Figura.Vrednost;
            }
        }
        public void NastaviCas(int cas, Label napis, Form podlaga, Igra igra)
        {
            this.Igra = igra;
            this.Cas = cas;
            this.Timer = new Timer();
            this.Napis = napis;
            this.Podlaga = podlaga;
            napis.Text = ZapisCasa(this.Cas);
            Timer.Interval = 1000;
            Timer.Tick += TimerTick;    
        }
        /// <summary>
        /// Funkcija vrne urejen zapis casa mm:ss
        /// </summary>
        /// <param name="cas"></param>
        /// <returns></returns>
        public string ZapisCasa(int cas)
        {
            int minute = (cas / 60);
            int sekunde = (cas % 60);
            if (sekunde < 10)
            {
                return $"{minute}:0{sekunde}";
            }
            return $"{minute}:{sekunde}";
        }

        private void TimerTick(object sender, EventArgs e)
        {
            //this.Cas -= ((double)Timer.Interval / (double)1000);
            this.Cas -= 1;
            Napis.Text = ZapisCasa(this.Cas);
            if (this.Cas == 0)
            {
                if (this.jeBel()) this.Igra.KoncajIgro("MAT, ZAMGAL JE ČRNI IGRALEC");
                else this.Igra.KoncajIgro("MAT, ZAMGAL JE BEL IGRALEC");
            }
        }
        /// <summary>
        /// Funkcija nam pove ali je igralec bel ali črn
        /// </summary>
        /// <returns></returns>
        public bool jeBel()
        {
            if (this.Barva == "W") return true;
            else return false;
        }
    }
}
