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

        private void HostGumb_Click(object sender, EventArgs e)
        {
            Nastavitve nastavitve = new Nastavitve("HOST");
            nastavitve.ZacetekOkno = this;
            Visible = false;
            if (!nastavitve.IsDisposed)
                nastavitve.ShowDialog();
        }

        private void IpGumb_Click(object sender, EventArgs e)
        {
            Nastavitve nastavitve = new Nastavitve("GOST", IpText.Text);
            nastavitve.ZacetekOkno = this;
            Visible = false;
            if (!nastavitve.IsDisposed)
                nastavitve.ShowDialog();
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
        private void IpText_Click(object sender, EventArgs e)
        {
            if (IpText.Text == "Vpiši IP naslov")
            {
                IpText.Text = "";
            }
        }
    }
}
