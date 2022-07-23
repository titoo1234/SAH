using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.ComponentModel;

namespace Sah_projekt
{
    class MultiplayerIgra : Igra
    {
        private Socket socket;
        private BackgroundWorker messageReceiver;
        private TcpListener server;
        private TcpClient client;
        private NavideznaCelica prejsnaCelica;
        private Celica gumbPredRezervo;
        private Zacetek zacetekOkno;
        public MultiplayerIgra(Nastavitve nastavitve)
        {
            this.ZacetekOkno = nastavitve.ZacetekOkno;
            string nacinIgre = nastavitve.NacinIgre;
            string ipNaslov = nastavitve.IpNaslov;
            string barva = nastavitve.Barva;
            Size velikost = nastavitve.Velikost;
            this.Podlaga = nastavitve.Game;
            Color[] tema = nastavitve.Tema;
            this.MessageReceiver = nastavitve.MessageReceiver;
            this.MessageReceiver = new BackgroundWorker();
            this.MessageReceiver.DoWork += SprejmiPotezo;
            this.Server = nastavitve.Server;
            this.Socket = nastavitve.Socket;
            this.Client = nastavitve.Client;
            this.Socket = nastavitve.Socket;
            if (barva == "B")
            {
                MessageReceiver.RunWorkerAsync();
            }
            int cas = nastavitve.Cas * 60; // minute 
            this.SteviloPotez = 0;
            NavideznaSahovnica = new NavideznaSahovnica(barva, velikost);
            this.PravaSahovnica = new PravaSahovnica(NavideznaSahovnica, Podlaga, tema);
            this.Igralec1 = new Igralec(barva);
            this.Igralec2 = new Igralec(NavideznaSahovnica.VrniNasprotnoBarvo(barva));
            NastaviCas(cas);
            NastaviTrenutnegaIgralca();
            SpremeniLastnostGumbov();
            Podlaga.PredajaGumb.Visible = true;
            Podlaga.PredajaGumb.Enabled = false;
            Podlaga.PredajaGumb.Click += PredajIgro;
            Podlaga.Text = nacinIgre;
            Podlaga.FormClosing += ZapriOkno;
        }

        private void ZapriOkno(object sender, FormClosingEventArgs e)
        {
            ZacetekOkno.Visible = true;
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (Server != null)
                Server.Stop();
        }
        public Zacetek ZacetekOkno { get; set; }
        public Socket Socket { get;  set; }
        public BackgroundWorker MessageReceiver { get;  set; }
        public TcpListener Server { get;  set; }
        public TcpClient Client { get;  set; }
        public NavideznaCelica PrejsnaCelica { get; set; }
        public Celica GumbPredRezervo { get;  set; }

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
            Igralec1.Timer.Start();
            if (KliknemoNaRezervo(gumb))
            {
                NarediZamenjavo(gumb);
                OdmrzniSahovnico();
                PosljiPotezo(GumbPredRezervo,gumb);
                ZamenjajIgralca();
                PreveriKonecIgre();
            }
            else
            // kliknali smo na šahovnico
            {
                if (jeObarvanoPolje(gumb))
                {
                    if (SemNaPotezi())
                    {
                        if (SteviloPotez == 0) TrenutniIgralec.Timer.Start(); // začnemo odštevati čas
                        PrestaviFiguro(gumb);
                        ZvokPremik.Play();
                        SteviloPotez++;
                        if (PrikaziRezervo(gumb))
                        {
                            this.GumbPredRezervo = gumb;
                            if (TrenutniIgralec == Igralec1) PravaSahovnica.PravaRezerva.PrikaziNasoRezervo();
                            else PravaSahovnica.PravaRezerva.PrikaziNasprotnoRezervo();
                            ZamrzniSahovnico();

                        }
                        else
                        {
                            ZamenjajIgralca();
                            PosljiPotezo(gumb);
                            PreveriKonecIgre();
                        }
                        Podlaga.PredajaGumb.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Nisi na potezi!");
                    }
                }
                else
                {
                    PrikaziMoznePotezeMultiplayer(gumb);
                }
            }
            Igralec1.Timer.Start();
        }

        private bool SemNaPotezi()
        {
            if(TrenutniIgralec == Igralec1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Funkcija pošlje podatke nasprotniku
        /// </summary>
        /// <param name="gumb"></param>
        private void PosljiPotezo(Celica gumb)
        {
            Podlaga.PredajaGumb.Enabled = false;
            byte[] poslji;
            poslji = new byte[] { (byte)PrejsnaCelica.X, (byte)PrejsnaCelica.Y, (byte)gumb.X, (byte)gumb.Y,(byte)(4) };
            Socket.Send(poslji);
            MessageReceiver.RunWorkerAsync();
        }
        private void PosljiPotezo(Celica gumb, Celica rezerva)
        {  
            byte[] poslji;
            poslji = new byte[] { (byte)PrejsnaCelica.X, (byte)PrejsnaCelica.Y, (byte)gumb.X, (byte)gumb.Y, (byte)rezerva.X};
            Socket.Send(poslji);
            MessageReceiver.RunWorkerAsync();
        }
        public void PredajIgro(object sender, EventArgs e)
        {
            Podlaga.PredajaGumb.Enabled = false;
            KoncajIgro("IGRO STE PREDALI");
            byte[] poslji;
            poslji = new byte[] { (byte)0, (byte)0, (byte)0, (byte)0, (byte)5 };
            Socket.Send(poslji);
            MessageReceiver.RunWorkerAsync();
        }
        private void SprejmiPotezo(object sender, DoWorkEventArgs e)
        {
            ReceiveMove();
        }

        private void ReceiveMove()
        {
            
            byte[] buffer = new byte[5];
            Socket.Receive(buffer);
            int zacetnaX = obrniXY(int.Parse(buffer[0].ToString()));
            int zacetnaY = obrniXY(int.Parse(buffer[1].ToString()));
            int koncnaX = obrniXY(int.Parse(buffer[2].ToString()));
            int koncnaY = obrniXY(int.Parse(buffer[3].ToString()));
            Podlaga.PredajaGumb.Enabled = true;
            if (int.Parse(buffer[4].ToString()) == 5)//predaja
            {
                Podlaga.PredajaGumb.Enabled = false;
                KoncajIgro("NASPROTNIK SE JE PEDAL");
            }
            else
            {
                SprejmiPotezoPrestaviFiguro(new Celica(zacetnaX, zacetnaY), new Celica(koncnaX, koncnaY));
                if (int.Parse(buffer[4].ToString()) < 4)
                {
                    int rezerva = int.Parse(buffer[4].ToString());
                    Celica rezervaGumb = this.PravaSahovnica.PravaRezerva.NasprotnaRezerva[rezerva];
                    NarediZamenjavo(rezervaGumb);
                }
                ZvokPremik.Play();
                Igralec1.Timer.Start();
                ZamenjajIgralca();
                PreveriKonecIgre();
            }
        }
        /// <summary>
        /// Funkcija prestavi ustrezne figure, ko igralec sprejme podatke od nasprotnika
        /// </summary>
        /// <param name="prejsnaCelica"></param>
        /// <param name="novaCelica"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void SprejmiPotezoPrestaviFiguro(Celica prejsnaCelica, Celica novaCelica)
        {
            this.PravaSahovnica.PrestaviFiguroMultiplayer(prejsnaCelica, novaCelica);
        }

        /// <summary>
        /// Funkcija vrne polje na nasprotni sahovnici
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        private int obrniXY(int st)
        {
            return 7 - st;
        }

        public void PrikaziMoznePotezeMultiplayer(Celica gumb)
        {
            PravaSahovnica.PrikaziMoznePoteze(gumb, Igralec1);
            this.PrejsnaCelica = PravaSahovnica.NavideznaSahovnica.PrejsnaCelica;
        }
    }
}

