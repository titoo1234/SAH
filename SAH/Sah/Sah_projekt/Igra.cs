using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Sah_projekt
{
    public abstract class Igra
    {
        private static NavideznaSahovnica navideznaSahovnica;
        private PravaSahovnica pravaSahovnica;
        private Sahovnica sahovnica;
        private Igralec igralec1;
        private Igralec igralec2;
        private Igralec trenutniIgralec;
        private Game podlaga;

        public Igra() { }
        public static NavideznaSahovnica NavideznaSahovnica { get; set; }
        public PravaSahovnica PravaSahovnica { get; set; }
        public Sahovnica Sahovnica { get; set; }
        public Igralec Igralec1 { get; set; }
        public Igralec Igralec2 { get; set; }
        public Igralec TrenutniIgralec { get; set; }
        public Game Podlaga { get; set; }

        public void NastaviCas(int cas)
        {
            Igralec1.NastaviCas(cas, Podlaga.label1);
            Igralec2.NastaviCas(cas, Podlaga.label2);
        }
        /// <summary>
        /// Funckija nastavi začetnega igralca glede na barvo
        /// </summary>
        public void NastaviTrenutnegaIgralca()
        {
            if (Igralec1.Barva == "W")
            {
                this.TrenutniIgralec = Igralec1;
            }
            else
            {
                this.TrenutniIgralec = Igralec2;
            }
            TrenutniIgralec.Timer.Start();
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
            for (int i = 0; i < 4; i++)
            {
                Celica nasaCelica = PravaSahovnica.PravaRezerva.NasaRezerva[i];
                nasaCelica.Click += KlikNaCelico;
                Celica nasprotnaCelica = PravaSahovnica.PravaRezerva.NasprotnaRezerva[i];
                nasprotnaCelica.Click += KlikNaCelico;
            }
        }
        /// <summary>
        /// To metodo prepišejo vsi razredi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public abstract void KlikNaCelico(object sender, EventArgs e);

        /// <summary>
        /// Funkcija odmrzne vse celice na sahovnici
        /// </summary>
        public void ZamrzniSahovnico()
        {
            PravaSahovnica.ZamrzniSahovnico();
        }

        /// <summary>
        /// Funkcija "zamrzne" vse celice v sahovnici
        /// </summary>
        public void OdmrzniSahovnico()
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
            TrenutniIgralec.Timer.Stop();
            if (this.TrenutniIgralec == this.Igralec1)
            {
                this.TrenutniIgralec = this.Igralec2;
            }
            else
            {
                this.TrenutniIgralec = this.Igralec1;
            }
            TrenutniIgralec.Timer.Start();
        }

        /// <summary>
        /// Funkcija na šahovnici obarva polja, na katere se lahko prestavimo z izbrano figuro
        /// </summary>
        /// <param name="gumb"></param>
        public void PrikaziMoznePoteze(Celica gumb)
        {
            PravaSahovnica.PrikaziMoznePoteze(gumb, TrenutniIgralec);
        }
        public void PreveriMat()
        {
            if (NavideznaSahovnica.JeMat(TrenutniIgralec.Barva))
            {
                //Podlaga.
                MessageBox.Show("MAT, ZAMGAL JE " + TrenutniIgralec.Barva + "IGRALEC");
                Podlaga.Close();
                
                
            }
        }

    }
}
