using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sah_projekt
{
    public class PravaSahovnica
    {
        private NavideznaSahovnica navideznaSahovnica;
        private Game podlaga;

        public PravaSahovnica(NavideznaSahovnica navideznaSahovnica,Game podlaga)
        {
            this.NavideznaSahovnica = navideznaSahovnica;
            this.Podlaga = podlaga;
            NarediSahovnico();

        }
        public NavideznaSahovnica NavideznaSahovnica { get; set; }
        public Game Podlaga { get;  set; }

        public void NarediSahovnico()
        {
            Size velikost = NavideznaSahovnica.Velikost;
            for (int vrstica = 0; vrstica < 8; vrstica++)
            {

                for (int stolpec = 0; stolpec < 8; stolpec++)
                {   
 
                    Button gumb  = new Button();
                    gumb.Location = new Point(50 + stolpec * velikost.Width, 50 + vrstica * velikost.Width);
                    gumb.Size = velikost;
                    if (!(NavideznaSahovnica.Celice[vrstica, stolpec].Figura is null))
                    {
                        Bitmap slika = NavideznaSahovnica.Celice[vrstica, stolpec].Figura.Slika;
                        gumb.Image = slika;
                    }
                    //gumb.UseVisualStyleBackColor = true;


                    Podlaga.Controls.Add(gumb);

                }
            }
        }
        
    }
}
