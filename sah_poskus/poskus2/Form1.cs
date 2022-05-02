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


namespace poskus2
{
    public partial class Game : Form
    {
        public Button[,] gumbi = new Button[8, 8];
        public int velikost = 40;
        Sahovnica sahovnica;
        RezervaFigure rezerva_beli;
        RezervaFigure rezerva_crni;
        public Socket socket;
        public BackgroundWorker MessageReceiver = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;
        public bool solo;
        public bool racunalnik;

        public Game(bool solo,bool racunalnik ,bool isHost, string ip = null)
        {
            
            this.solo = solo;
            this.racunalnik = racunalnik;
       
            InitializeComponent();
            
            if (!isHost)
            {
                if (solo)
                {
                    sahovnica = new Sahovnica(velikost, this, false, "W");
                }
                else
                {
                    sahovnica = new Sahovnica(velikost, this, false, "B");
                }
                
            }
            else
            {
                sahovnica = new Sahovnica(velikost, this, true, "W");
                
            }
            
           
            
            rezerva_beli = new RezervaFigure(velikost, this, "W", sahovnica);
            rezerva_crni = new RezervaFigure(velikost, this, "B", sahovnica);
            sahovnica.rezerva_beli = rezerva_beli;
            sahovnica.rezerva_crni = rezerva_crni;


            if (!solo)
            {
                MessageReceiver.DoWork += MessageReceiver_DoWork;
                CheckForIllegalCrossThreadCalls = false;

                if (isHost)
                {
                    this.Text = "Šah ;-) Host";
                    //Igralec1.barva = "W"
                    //Igralec2.barva = "B"

                    server = new TcpListener(System.Net.IPAddress.Any, 5732);

                    
                    server.Start();
                    socket = server.AcceptSocket();

                }
                else
                {
                    //Igralec2.barva = "W"
                    //Igralec1.barva = "B"
                    
                    try
                    {
                        client = new TcpClient(ip, 5732);
                        socket = client.Client;
                        MessageReceiver.RunWorkerAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Close();
                    }
                }
            }
           

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


            byte[] buffer = new byte[4];
            socket.Receive(buffer);
            int xStara = int.Parse(buffer[0].ToString());
            int yStara = int.Parse(buffer[1].ToString());
            int xNova = int.Parse(buffer[2].ToString());
            int yNova = int.Parse(buffer[3].ToString());
            Celica stara = sahovnica.Celice[xStara, yStara];
            Celica nova = sahovnica.Celice[xNova, yNova];
            nova.Figura = stara.Figura;
            nova.Figura.X = nova.X;
            nova.Figura.Y = nova.Y;
            nova.Image = nova.Figura.Slika;
            Figura nova1 = new Figura("", stara.X, stara.Y, stara.Size);
            stara.Figura = nova1;
            stara.Image = nova1.Slika;
            //if (Figura.Mat(sahovnica,barva)

        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }
        //asdad
        private void button1_Click(object sender, EventArgs e)
        {
            Button gumb= (Button)sender;
            string vrstica = (string)gumb.Tag;
            MessageBox.Show("ŠE NE GRE :)");
        }

        private void Game_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!solo)
            {
                MessageReceiver.WorkerSupportsCancellation = true;
                MessageReceiver.CancelAsync();
                if (server != null)
                    server.Stop();
            }
            
        }

       
    }
}
