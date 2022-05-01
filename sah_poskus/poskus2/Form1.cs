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
    public partial class Form1 : Form
    {
        public Button[,] gumbi = new Button[8, 8];
        public int velikost = 40;
        Sahovnica sahovnica;
        RezervaFigure rezerva_beli;
        RezervaFigure rezerva_crni;
        public Form1()
        {
            
            
       
            InitializeComponent();
            sahovnica = new Sahovnica(velikost, this);
            rezerva_beli = new RezervaFigure(velikost, this, "W", sahovnica);
            rezerva_crni = new RezervaFigure(velikost, this, "B", sahovnica);
            sahovnica.rezerva_beli = rezerva_beli;
            sahovnica.rezerva_crni = rezerva_crni;
            //rezerva_beli.Prikaži();
            //rezerva_crni.Prikaži();




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
    }
}
