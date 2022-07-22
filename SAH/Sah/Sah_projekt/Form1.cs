using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;


namespace Sah_projekt
{
    public partial class Game : Form
    {
        public Button[,] gumbi = new Button[8, 8];
        public int velikost = 40;
        Sahovnica sahovnica;
        RezervaFigure rezerva_beli;
        RezervaFigure rezerva_crni;
        //public Socket socket;
        //public BackgroundWorker MessageReceiver = new BackgroundWorker();
        //private TcpListener server = null;
        //private TcpClient client;
        public bool solo;
        public bool racunalnik;
        private Igra igra;

        public bool IsHost { get;  set; }
        public Igra Igra { get;  set; }

        public Game(bool solo, bool racunalnik, bool isHost, string ip = null)
        {

            //this.solo = solo;
            this.racunalnik = racunalnik;
            this.IsHost = isHost;
            this.Igra = null;
            InitializeComponent();

            //    if (!isHost)
            //    {
            //        if (solo)
            //        {
            //            sahovnica = new Sahovnica(velikost, this, false, "W");
            //        }
            //        else
            //        {
            //            sahovnica = new Sahovnica(velikost, this, false, "B");
            //        }

            //    }
            //    else
            //    {
            //        sahovnica = new Sahovnica(velikost, this, true, "W");

            //    }



            //    rezerva_beli = new RezervaFigure(velikost, this, "W", sahovnica);
            //    rezerva_crni = new RezervaFigure(velikost, this, "B", sahovnica);
            //    sahovnica.rezerva_beli = rezerva_beli;
            //    sahovnica.rezerva_crni = rezerva_crni;


            //    if (!solo)
            //    {
            //        MessageReceiver.DoWork += MessageReceiver_DoWork;
            //        CheckForIllegalCrossThreadCalls = false;

            //        if (isHost)
            //        {
            //            this.Text = "Šah ;-) Host";
            //            //Igralec1.barva = "W"
            //            //Igralec2.barva = "B"

            //            server = new TcpListener(System.Net.IPAddress.Any, 5732);
            //            //server = new TcpListener(5732);
            //            //MessageBox.Show(System.Net.IPAddress.Any.ToString());


            //            //System.Net.IPAddress.Any

            //            server.Start();
            //            socket = server.AcceptSocket();

            //        }
            //        else
            //        {
            //            //Igralec2.barva = "W"
            //            //Igralec1.barva = "B"

            //            try
            //            {
            //                client = new TcpClient(ip,5732);
            //                socket = client.Client;
            //                MessageReceiver.RunWorkerAsync();
            //            }
            //            catch (Exception ex)
            //            {
            //                MessageBox.Show(ex.Message);
            //                Close();
            //            }
            //        }
            //    }


            //}
        }
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }
        //asdad
        

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    MessageReceiver.WorkerSupportsCancellation = true;
            //    MessageReceiver.CancelAsync();
            //    if (server != null)
            //        server.Stop();
            //}
            
        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
