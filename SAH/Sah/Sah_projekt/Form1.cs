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
        private Igra igra;

        public Igra Igra { get;  set; }

        public Game()
        {
            this.Igra = null;
            InitializeComponent();
        }
        private void Game_FormClosing(object sender, FormClosingEventArgs e) {}
        private void Game_Load(object sender, EventArgs e) {}
        private void PredajaGumb_Click(object sender, EventArgs e) {}
    }
}
