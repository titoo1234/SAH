using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poskus2
{
    public partial class Zacetek : Form
    {
        public Zacetek()
        {
            InitializeComponent();
        }

        private void HostGumb_Click(object sender, EventArgs e)
        {
            Game newGame = new Game(false, false, true);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }

        private void IpGumb_Click(object sender, EventArgs e)
        {
            Game newGame = new Game(false,false, false, IpText.Text);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }

        private void SoloGumb_Click(object sender, EventArgs e)
        {
            Game newGame = new Game(true,false, false);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }

        private void RacunalnikGumb_Click(object sender, EventArgs e)
        {
            Game newGame = new Game(true,true, false);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;

        }
    }
}
