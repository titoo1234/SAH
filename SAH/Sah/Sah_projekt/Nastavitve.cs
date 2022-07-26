﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class Nastavitve : Form
    {
        private Socket socket;
        private BackgroundWorker messageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        private Color[] tema;
        private Size velikost;
        private string barva;
        private Game game;
        private int cas;
        private string nacinIgre;
        private string ipNaslov;
        private string tezavnost;
        private Boolean zacetek;
        private Zacetek zacetekOkno;
        public Nastavitve(string nacinIgre,string ip = null)
        {
            InitializeComponent();
            this.ControlBox = false;
            PrivzeteNastavitve();
            this.zacetek = true;
            this.NacinIgre = nacinIgre;
            this.IpNaslov = ip;
            if (ip == "" || ip == "Vpiši IP naslov")
            {
                this.IpNaslov = "localhost";
            }
            this.Text += NacinIgre;
            VzpostaviPovezavo();
            if (NacinIgre != "RACUNALNIK")
            {
                IzberiTezavnost.Visible = false;
                label4.Visible = false;
            }
            
        }
        public Zacetek ZacetekOkno { get; set; }
        public Socket Socket { get; set; }
        public BackgroundWorker MessageReceiver { get; set; }
        public TcpListener Server { get; set; }
        public TcpClient Client { get; set; }
        public Game Game { get; set; }
        public Color[] Tema { get; set; }
        public Size Velikost { get; set; }
        public string Barva { get; set; }
        public int Cas { get; set; }
        public string NacinIgre { get; set; }
        public string IpNaslov { get; set; }
        public string Tezavnost { get; set; }
        /// <summary>
        /// funkcija vzpostavi povezavo med igralcema
        /// </summary>
        private void VzpostaviPovezavo()
        {
            if (NacinIgre == "HOST")
            {
                this.MessageReceiver = new BackgroundWorker();
                MessageReceiver.DoWork += SprejmiSignalHost;
                this.Server = new TcpListener(System.Net.IPAddress.Any, 5742);
                this.Server.Start();
                Socket = Server.AcceptSocket();
            }
            if (NacinIgre == "GOST")
            {
                IzbranaBarva.Visible = false;
                Izbrano.Text = "Izbrana tema:";
                label1.Visible = false;
                label3.Visible = false;
                BelaBarva_Gumb.Visible = false;
                CrnaBarva_gumb.Visible = false;
                IzberiCas.Visible = false;
                ZacetekIgre.Enabled = false;
                this.MessageReceiver = new BackgroundWorker();
                MessageReceiver.DoWork += SprejmiSignalGost;
                try
                {
                    this.Client = new TcpClient(IpNaslov, 5742);
                    this.Socket = Client.Client;
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.Close();
                }
            }
        }
        /// <summary>
        /// Funkcija sprejme signal, ki ga pošlje Host (nastavitve časa in barve). 
        /// Nato omogoči gumb začetek igre.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SprejmiSignalGost(object sender, DoWorkEventArgs e)
        { 
            byte[] buffer = new byte[2];
            Socket.Receive(buffer);
            int barva = int.Parse(buffer[0].ToString());
            if (barva == 1) this.Barva = "W";
            else this.Barva = "B";
            this.Cas = int.Parse(buffer[1].ToString());
            ZacetekIgre.Enabled = true;
        }
        /// <summary>
        /// Funkcija sprejme signal gosta, ko le-ta klikne gumb začetek igre.
        /// Ustvari novo igro (za oba igralca).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SprejmiSignalHost(object sender, DoWorkEventArgs e)
        {
            byte[] buffer = new byte[5];
            Socket.Receive(buffer);
            int x = int.Parse(buffer[0].ToString());
            NastaviIgro();
            ZacniIgro();
        }

        /// <summary>
        /// Funkcija nastavi privzete nastavitve od strani
        /// </summary>
        private void PrivzeteNastavitve()
        {
            BelaBarva_Gumb.Enabled = false;
            temaSahovnicaGumb2.Enabled = false;
            IzberiCas.SelectedIndex = 1;
            IzberiTezavnost.SelectedIndex = 9;
        }
        /// <summary>
        /// Nastavimo barvo figure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BelaBarva_Gumb_Click(object sender, EventArgs e)
        {
            BelaBarva_Gumb.Enabled = false;
            CrnaBarva_gumb.Enabled = true;
            IzbranaBarva.Image = BelaBarva_Gumb.BackgroundImage;
        }
        /// <summary>
        /// Nastavimo barvo figure
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CrnaBarva_Gumb_Click(object sender, EventArgs e)
        {
            CrnaBarva_gumb.Enabled = false;
            BelaBarva_Gumb.Enabled = true;
            IzbranaBarva.Image = CrnaBarva_gumb.BackgroundImage;
        }
        /// <summary>
        /// Funkcija se izvede, ko kliknemo na gumb začetek igre
        /// Funkcija ustvari igro in ji nastavi njene izbrane nastavitve 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZacetekIgre_Click(object sender, EventArgs e)
        {
            NastaviTemo();
            this.Velikost = new Size(40, 40);
            if (NacinIgre != "GOST")
            {
                this.Cas = int.Parse((string)IzberiCas.SelectedItem);
                NastaviBarvo();
            }
            int pretovri = Int32.Parse(this.IzberiTezavnost.Text) * 1;
            this.Tezavnost = pretovri.ToString();
            this.Game = new Game();
            if (NacinIgre != "GOST" && NacinIgre != "HOST") NastaviIgro(); 
            if (NacinIgre == "GOST") PosljiSignal(); 
            if (NacinIgre != "HOST") ZacniIgro();
            else PosljiNastavitveIgre();
        }
        /// <summary>
        /// Host pošlje gostu nastavitve igre 
        /// </summary>
        private void PosljiNastavitveIgre()
        {
            byte[] num;
            if (this.Barva == "W") num = new byte[] { (byte)0, (byte)this.Cas };
            else num = new byte[] { (byte)1, (byte)this.Cas };
            this.ZacetekIgre.Enabled = false;
            Socket.Send(num);
            MessageReceiver.RunWorkerAsync();
        }
        /// <summary>
        /// Gost pošlje hostu signal, da lahko ta začne igro.
        /// </summary>
        private void PosljiSignal()
        {
            byte[] num = { (byte)1 };
            Socket.Send(num);
            NastaviIgro();
        }

        /// <summary>
        /// Funkcija nastavi zacetno barvo sahovnice
        /// </summary>
        private void NastaviBarvo()
        {
            if (BelaBarva_Gumb.Enabled == false) this.Barva = "W";
            else this.Barva = "B";
        }
        /// <summary>
        /// Funkcija nastavi način igre, ki ga bomo igrali
        /// </summary>
        private void NastaviIgro()
        {
            if (this.NacinIgre == "SOLO") this.Game.Igra = new SoloIgra(this);
            else if (this.NacinIgre == "RACUNALNIK") this.Game.Igra = new RacunalnikIgra(this);
            else this.Game.Igra = new MultiplayerIgra(this);
        }
        /// <summary>
        /// Funkcija začne igro
        /// </summary>
        private void ZacniIgro()
        {
            this.Visible = false;
            //POŠLJEMO NASPORTONIKUs
            if (!this.Game.IsDisposed)
                this.Game.ShowDialog();
        }
        /// <summary>
        /// Funkcija nastavi temo igre
        /// </summary>
        private void NastaviTemo()
        {
            if (temaSahovnicaGumb1.Enabled == false)
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#D4FFB9");
                this.Tema  = new Color[] { col, Color.Green, Color.Yellow };
            }
            else if (temaSahovnicaGumb2.Enabled == false)
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#4F2B1B");
                System.Drawing.Color col1 = System.Drawing.ColorTranslator.FromHtml("#fccc74");
                this.Tema = new Color[] { col1, col, Color.Yellow };
            }
            else if (temaSahovnicaGumb3.Enabled == false)

            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#0097FF");
                System.Drawing.Color col1 = System.Drawing.ColorTranslator.FromHtml("#60EEFF");
                this.Tema = new Color[] { col1, col, Color.Yellow };
            }
            else
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#A72600");
                System.Drawing.Color col1 = System.Drawing.ColorTranslator.FromHtml("#F9A07C");
                this.Tema = new Color[] { col1, col, Color.Yellow };
            }
        }

        private void temaSahovnicaGumb1_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb1.Enabled = false;
            temaSahovnicaGumb4.Enabled = true;
            temaSahovnicaGumb2.Enabled = true;
            temaSahovnicaGumb3.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb1.Image;
        }
        /// <summary>
        /// Nastavimo temo igre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void temaSahovnicaGumb2_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb2.Enabled = false;
            temaSahovnicaGumb1.Enabled = true;
            temaSahovnicaGumb4.Enabled = true;
            temaSahovnicaGumb3.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb2.Image;
        }
        /// <summary>
        /// Nastavimo temo igre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void temaSahovnicaGumb3_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb3.Enabled = false;
            temaSahovnicaGumb1.Enabled = true;
            temaSahovnicaGumb2.Enabled = true;
            temaSahovnicaGumb4.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb3.Image;
        }
        /// <summary>
        /// Nastavimo temo igre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void temaSahovnicaGumb4_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb4.Enabled = false;
            temaSahovnicaGumb1.Enabled = true;
            temaSahovnicaGumb2.Enabled = true;
            temaSahovnicaGumb3.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb4.Image;
        }
    }
}
