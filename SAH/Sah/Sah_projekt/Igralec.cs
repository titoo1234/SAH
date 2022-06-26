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
        private double cas;
        private Timer timer;
        private Label napis;

        public Igralec(string barva)
        {
            this.Barva = barva;
            this.Vsota = 39;
        }
        public string Barva { get;  set; }
        public int Vsota { get;  set; }
        public double Cas { get; set; }
        public Timer Timer { get; set; }
        public Label Napis { get; set; }
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
        public void NastaviCas(int cas,Label napis)
        {
            this.Cas = cas;
            this.Timer = new Timer();
            this.Napis = napis;
            napis.Text = cas.ToString();
            Timer.Interval = 100;
            Timer.Tick += TimerTick;    
        }

        private void TimerTick(object sender, EventArgs e)
        {
            this.Cas -= ((double)Timer.Interval / (double)1000);
            Napis.Text = Cas.ToString();
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
