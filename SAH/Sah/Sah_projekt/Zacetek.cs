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
    public partial class Zacetek : Form
    {
        public Zacetek()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            IpText.Text = GetLocalIPAddress().ToString();
        }

        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                //return ip;
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
                
            }
           
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }


        private void HostGumb_Click(object sender, EventArgs e)
        {
            Nastavitve nastavitve = new Nastavitve("HOST");
            nastavitve.ZacetekOkno = this;
            Visible = false;
            if (!nastavitve.IsDisposed)
                nastavitve.ShowDialog();
            //Visible = true;
        }

        private void IpGumb_Click(object sender, EventArgs e)
        {
        
            Nastavitve nastavitve = new Nastavitve("GOST", IpText.Text); // ,this.IpText.Text
            nastavitve.ZacetekOkno = this;
            Visible = false;
            if (!nastavitve.IsDisposed)
                nastavitve.ShowDialog();
            //Visible = true;
        }

        private void SoloGumb_Click(object sender, EventArgs e)
        {
            Nastavitve nastavitve = new Nastavitve("SOLO");
            nastavitve.ZacetekOkno = this;
            Visible = false;
            if (!nastavitve.IsDisposed)
                nastavitve.ShowDialog();
            Visible = true;
        }

        private void RacunalnikGumb_Click(object sender, EventArgs e)
        {
            //Game newGame = new Game(true,true, false);
            Nastavitve nastavitve = new Nastavitve("RACUNALNIK");
            nastavitve.ZacetekOkno = this;
            Visible = false;
            if (!nastavitve.IsDisposed)
                nastavitve.ShowDialog();
            Visible = true;
        }

        private void Zacetek_Load(object sender, EventArgs e)
        {
            
        }
    }
}
