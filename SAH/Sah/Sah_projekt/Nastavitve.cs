using System;
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
        public Nastavitve(string nacinIgre,string ip = null)
        {
            
            InitializeComponent();

            PrivzeteNastavitve();
            this.NacinIgre = nacinIgre;
            this.IpNaslov = ip;
            this.Text += NacinIgre;
            VzpostaviPovezavo();
            if (NacinIgre != "RACUNALNIK") IzberiTezavnost.Visible = false;
        }
        /// <summary>
        /// funkcija vzpostavi povezavo med igralcema
        /// </summary>
        private void VzpostaviPovezavo()
        {
            if (NacinIgre == "HOST")
            {
                this.MessageReceiver = new BackgroundWorker();
                MessageReceiver.DoWork += SprejmiSignalHost;
                server = new TcpListener(System.Net.IPAddress.Any, 5742);
                server.Start();
                Socket = server.AcceptSocket();
            }
            if (NacinIgre == "GOST")
            {
                label1.Visible = false;
                label3.Visible = false;
                BelaBarva_Gumb.Visible = false;
                CrnaBarva_gumb.Visible = false;
                IzberiCas.Visible = false;
                this.IpNaslov = "localhost";
                ZacetekIgre.Enabled = false;
                this.MessageReceiver = new BackgroundWorker();
                MessageReceiver.DoWork += SprejmiSignalGost;
                try
                {
                    client = new TcpClient(IpNaslov, 5742);
                    Socket = client.Client;
                    MessageReceiver.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //this.Close();
                }
            }
        }

        private void SprejmiSignalGost(object sender, DoWorkEventArgs e)
        { 
            byte[] buffer = new byte[2];
            Socket.Receive(buffer);
            int barva = int.Parse(buffer[0].ToString());
            if (barva == 1) this.Barva = "W";
            else this.Barva = "B";
            this.Cas = int.Parse(buffer[1].ToString());
            ZacetekIgre.Enabled = true;
            MessageReceiver.DoWork -= SprejmiSignalGost;
            
            //sprejmemo podatke ... nastavimo temo....
        }

        private void SprejmiSignalHost(object sender, DoWorkEventArgs e)
        {
            byte[] buffer = new byte[5];
            Socket.Receive(buffer);
            int x = int.Parse(buffer[0].ToString());
            MessageReceiver.DoWork -= SprejmiSignalHost;
            server.Stop();
            ZacniIgro();
            
        }

        /// <summary>
        /// Funkcija nastavi privzete nastavitve od strani
        /// </summary>
        private void PrivzeteNastavitve()
        {
            BelaBarva_Gumb.Enabled = false;
            temaSahovnicaGumb1.Enabled = false;
            IzberiCas.SelectedIndex = 2;
            IzberiTezavnost.SelectedIndex = 9;
          

        }

        public Socket Socket { get; set; }
        public BackgroundWorker MessageReceiver { get; set; }
        public object Server { get; set; }
        public object Client { get; set; }
        public Game Game { get; set; }
        public Color[] Tema { get; set; }
        public Size Velikost { get; set; }
        public string Barva { get; set; }
        public int Cas { get; set; }
        public string NacinIgre { get; set; }
        public string IpNaslov { get; set; }

        public string Tezavnost { get; set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void BelaBarva_Gumb_Click(object sender, EventArgs e)
        {
            BelaBarva_Gumb.Enabled = false;
            CrnaBarva_gumb.Enabled = true;
            IzbranaBarva.Image = BelaBarva_Gumb.BackgroundImage;
        }
        private void CrnaBarva_Gumb_Click(object sender, EventArgs e)
        {
            CrnaBarva_gumb.Enabled = false;
            BelaBarva_Gumb.Enabled = true;
            IzbranaBarva.Image = CrnaBarva_gumb.BackgroundImage;
        }

        private void ZacetekIgre_Click(object sender, EventArgs e)
        {
            NastaviTemo();
            this.Velikost = new Size(40, 40);
            if (NacinIgre != "GOST")
            {
                this.Cas = int.Parse((string)IzberiCas.SelectedItem);
                NastaviBarvo();
            }
            int pretovri = Int32.Parse(this.IzberiTezavnost.Text) * 2;
            this.Tezavnost = pretovri.ToString();
            this.Game = new Game(true, false, false);
            NastaviIgro();
            if (NacinIgre == "GOST") PosljiSignal(); 
            if (NacinIgre != "HOST") ZacniIgro();
            else PosljiNastavitveIgre();
        }

        private void PosljiNastavitveIgre()
        {
            byte[] num;
            if (this.Barva == "W") num = new byte[] { (byte)0, (byte)this.Cas };
            else num = new byte[] { (byte)1, (byte)this.Cas };
            this.ZacetekIgre.Enabled = false;
            Socket.Send(num);
            MessageReceiver.RunWorkerAsync();
        }

        private void PosljiSignal()
        {
            byte[] num = { (byte)1 };
            Socket.Send(num);
            MessageReceiver.RunWorkerAsync();

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
            //this.MessageReceiver.CancelAsync();
            MessageReceiver.RunWorkerAsync();
            this.Close();
            
        }
        /// <summary>
        /// Funkcija nastavi temo igre
        /// </summary>
        private void NastaviTemo()
        {
            if (temaSahovnicaGumb1.Enabled == false)
            {
                this.Tema  = new Color[] { Color.White, Color.Green, Color.Yellow };
            }
            else
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#4F2B1B");
                System.Drawing.Color col1 = System.Drawing.ColorTranslator.FromHtml("#fccc74");
                this.Tema = new Color[] { col1, col, Color.Yellow };
            }
        }

        private void temaSahovnicaGumb1_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb1.Enabled = false;
            temaSahovnicaGumb2.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb1.Image;
        }

        private void temaSahovnicaGumb2_Click(object sender, EventArgs e)
        {
            temaSahovnicaGumb2.Enabled = false;
            temaSahovnicaGumb1.Enabled = true;
            IzbranaTema.Image = temaSahovnicaGumb2.Image;
        }

        private void Izbrano_Click(object sender, EventArgs e)
        {

        }

        private void Nastavitve_Load(object sender, EventArgs e)
        {

        }
    }
}
