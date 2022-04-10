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
        public Form1()
        {
            
            
       
            InitializeComponent();
            Sahovnica sahovnica = new Sahovnica(velikost, this);
            



        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }
        //asdad
        private void button1_Click(object sender, EventArgs e)
        {
            Button gumb= (Button)sender;
            string vrstica = (string)gumb.Tag;
            MessageBox.Show(vrstica);


        }
    }
}
