using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace poskus2
{
    
    public class Funkcije
    {

        public Button[] MozniGumbi(Button gumb, Button[,] gumbi)
        {
            //Najdi kje se nahaja


            List<Button> list = new List<Button>();
            if (gumb.Tag == "WP")
            {
                list.Add(gumb);
            }
           
            return new Button[] { gumb };
        }
        
    }
}
