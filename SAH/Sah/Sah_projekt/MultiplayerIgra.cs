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
        private BackgroundWorker messageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        public MultiplayerIgra(Nastavitve nastavitve)
        {
            string nacinIgre = nastavitve.NacinIgre;
            string ipNaslov = nastavitve.IpNaslov;
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
            this.MessageReceiver = new BackgroundWorker();
            nastavitve.MessageReceiver.DoWork += MessageReceiver_DoWork;
            Podlaga.Text = nacinIgre;
            //CheckForIllegalCrossThreadCalls = false;
            //if (nacinIgre == "HOST")
            //{
            //    server = new TcpListener(System.Net.IPAddress.Any, 5732);
            //    server.Start();
            //    Socket = server.AcceptSocket();
            //}
            //else
            //{
            //    try
            //    {
            //        client = new TcpClient(ipNaslov, 5732);
            //        Socket = client.Client;
            //        MessageReceiver.RunWorkerAsync();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //        Podlaga.Close();
            //    }
            //}


        }

        public Socket Socket { get;  set; }
        public BackgroundWorker MessageReceiver { get;  set; }
        public object Server { get;  set; }
        public object Client { get;  set; }
        
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
                    if (SemNaPotezi())
                    {
                        if (SteviloPotez == 0) TrenutniIgralec.Timer.Start(); // začnemo odštevati čas
                        PrestaviFiguro(gumb);
                        SteviloPotez++;
                        if (PrikaziRezervo(gumb))
                        {
                            if (TrenutniIgralec == Igralec1) PravaSahovnica.PravaRezerva.PrikaziNasoRezervo();
                            else PravaSahovnica.PravaRezerva.PrikaziNasprotnoRezervo();
                            ZamrzniSahovnico();
                        }
                        PosljiPotezo(gumb);
                        ZamenjajIgralca();
                        PreveriKonecIgre();
                    }
                }
                else
                {
                    PrikaziMoznePoteze(gumb);
                }
            }
        }

        private bool SemNaPotezi()
        {
            if(TrenutniIgralec == Igralec1)
            {
                return true;
            }
            MessageBox.Show("Nisi na potezi");
            return false;
        }

        /// <summary>
        /// Funkcija pošlje podatke nasprotniku
        /// </summary>
        /// <param name="gumb"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void PosljiPotezo(Celica gumb)
        {
            byte[] num = { (byte)gumb.X, (byte)gumb.Y };
            Socket.Send(num);
            MessageReceiver.RunWorkerAsync();
        }
        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            //FREEZEBOARD
            //sahovnica.Zamrzni();
            //sahovnica.NaVrsti = false;
            ReceiveMove();
            //sahovnica.NaVrsti = true;
            //sahovnica.Odmrzni();

        }
        private void ReceiveMove()
        {
            byte[] buffer = new byte[5];
            Socket.Receive(buffer);
            int x = int.Parse(buffer[0].ToString());
            int y = int.Parse(buffer[1].ToString());
            PravaSahovnica.Celice[x,y].BackColor = Color.Red;
            ZamenjajIgralca();
        }

    }
}

