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
            Game newGame = new Game(true);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }

        private void IpGumb_Click(object sender, EventArgs e)
        {
            Game newGame = new Game(false, IpText.Text);
            Visible = false;
            if (!newGame.IsDisposed)
                newGame.ShowDialog();
            Visible = true;
        }
    }
}
