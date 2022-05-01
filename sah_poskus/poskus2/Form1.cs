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

        public Game(bool isHost, string ip = null)
        {
            
            
       
            InitializeComponent();
            sahovnica = new Sahovnica(velikost, this);
            rezerva_beli = new RezervaFigure(velikost, this, "W", sahovnica);
            rezerva_crni = new RezervaFigure(velikost, this, "B", sahovnica);
            sahovnica.rezerva_beli = rezerva_beli;
            sahovnica.rezerva_crni = rezerva_crni;
            MessageReceiver.DoWork += MessageReceiver_DoWork;
            CheckForIllegalCrossThreadCalls = false;

            if (isHost)
            {
                //Igralec1.barva = "W"
                //Igralec2.barva = "B"
                
                server = new TcpListener(System.Net.IPAddress.Any, 5732);
                
                server.Stop();
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


        private void MessageReceiver_DoWork(object sender, DoWorkEventArgs e)
        {
            //FREEZEBOARD
            ReceiveMove();
            
        }

        private void ReceiveMove()
        {
            byte[] buffer = new byte[1];
            socket.Receive(buffer);
            MessageBox.Show(buffer[0].ToString());

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
            MessageReceiver.WorkerSupportsCancellation = true;
            MessageReceiver.CancelAsync();
            if (server != null)
                server.Stop();
        }

       
    }
}
