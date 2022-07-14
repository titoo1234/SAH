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
        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            //FREEZEBOARD
            //sahovnica.Zamrzni();
            sahovnica.NaVrsti = false;
            ReceiveMove();
            sahovnica.NaVrsti = true;
            //sahovnica.Odmrzni();

        }

        private void ReceiveMove()
        {

            //Celica.PobarvajCeliceNazaj(sahovnica.)
            


            //byte[] buffer = new byte[5];
            //socket.Receive(buffer);
            //int xStara = int.Parse(buffer[0].ToString());
            //int yStara = int.Parse(buffer[1].ToString());
            //int xNova = int.Parse(buffer[2].ToString());
            //int yNova = int.Parse(buffer[3].ToString());

            ////Rezerva bo število od 0 do 4, če je 0, potem gre za navaden premik,
            ////sicer pa je igralec zamenjal figuro z neko rezervo
            //int rezerva = int.Parse(buffer[4].ToString());


           

            //if (rezerva != 0)//Premaknjena je bila rezerva
            //{
            //    Celica nova = sahovnica.Celice[xNova, yNova];

            //    //Najdimo pravo rezervo
            //    Figura izbranaFiguraRezerva;
            //    if (IsHost)
            //    {
            //        izbranaFiguraRezerva = sahovnica.rezerva_crni.Tabela_celic[rezerva-1].Figura;
            //    }
            //    else
            //    {
            //        izbranaFiguraRezerva = sahovnica.rezerva_beli.Tabela_celic[rezerva-1].Figura;
                   
            //    }
            //    Celica stara = sahovnica.Celice[xStara, yStara];
            //    Figura NovaFigura = new Figura(izbranaFiguraRezerva.Ime, nova.X, nova.Y, nova.Size); 
             
            //    nova.Figura = NovaFigura;
            //    nova.Image = NovaFigura.Slika;
            //    Figura nova1 = new Figura("", stara.X, stara.Y, stara.Size);
            //    stara.Figura = nova1;
            //    stara.Image = nova1.Slika;

            //}
            //else
            //{
                
            //    Celica stara = sahovnica.Celice[xStara, yStara];
            //    Celica nova = sahovnica.Celice[xNova, yNova];
            //    nova.Figura = stara.Figura;
            //    nova.Figura.X = nova.X;
            //    nova.Figura.Y = nova.Y;
            //    nova.Image = nova.Figura.Slika;
            //    Figura nova1 = new Figura("", stara.X, stara.Y, stara.Size);
            //    stara.Figura = nova1;
            //    stara.Image = nova1.Slika;

            //}
            ////for (int stolpec = 0; stolpec < 8; stolpec++)
            ////{
            ////    for (int vrtica = 0; stolpec < 8; stolpec++)
            ////    {
            ////        Celica cel = sahovnica.Celice[stolpec, vrtica];

            ////        Figura fig = cel.Figura;
            ////        cel.BackColor = Color.Transparent;
            ////        cel.Image = fig.Slika;
            ////        cel.Mozen = false;
            ////    }
            ////}
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }
        //asdad
        private void button1_Click(object sender, EventArgs e)
        {
            //Button gumb= (Button)sender;
            //string vrstica = (string)gumb.Tag;
            //MessageBox.Show("ŠE NE GRE :)");

            if (!label3.Visible)
            {
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label3.Visible = true;
            }
            else
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label3.Visible = false;
            }
            
            


        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (!solo)
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
