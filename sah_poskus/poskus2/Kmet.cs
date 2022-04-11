using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace poskus2
{
    public class Kmet
    {
        private int x;
        private int y;
        private Bitmap slika;
        private bool premaknjen;

        public Kmet(string barva, int x, int y)
        {
            this.Barva = barva;
            this.Y = y;
            this.X = x;
            this.Premaknjen = false;
            if (barva == "b")
            {
                this.Slika = new Bitmap(Properties.Resources.Black_Pawn);
            }
            else
            {
                this.Slika = new Bitmap(Properties.Resources.White_Pawn);
            }
        }
        public string Barva { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Bitmap Slika { get; set; }
        public bool Premaknjen { get; set; }

        public List<Celica> MoznePoteze(Sahovnica sahovnica)
        {
            List<Celica> moznePoteze = new List<Celica>();
            if (Barva == "W")
            {
                // TODO: ZADNJA VRSTICA - KMET PRIDE DO KONCA
                // pogledamo zgornjo celico
                // če imamo prosto pot..
                Celica zgoraj = sahovnica.Celice[x-1, y];
                if (zgoraj.Figura == "")
                {
                    moznePoteze.Add(zgoraj);
                    // ali je prosta naslednja? 
                    Celica zgoraj2 = sahovnica.Celice[x-2,y];
                    if (zgoraj2.Figura == "" && !Premaknjen)
                    {
                        moznePoteze.Add(zgoraj2);
                        MessageBox.Show($"{x}, {y}");
                    }
                }

                try
                {
                    Celica zgoraj_levo = sahovnica.Celice[x - 1, y - 1];
                    if (zgoraj_levo.Figura != "" && zgoraj_levo.Figura[0] == 'B')
                    {
                        moznePoteze.Add(zgoraj_levo);
                        Console.WriteLine($"{x}, {y}");
                    }
                }
                catch
                {
                    // Ne dodamo med možne poteze
                }

                try
                {
                    Celica zgoraj_desno = sahovnica.Celice[x - 1, y + 1];
                    if (zgoraj_desno.Figura != "" && zgoraj_desno.Figura[0] == 'B')
                    {
                        moznePoteze.Add(zgoraj_desno);
                        Console.WriteLine($"{x}, {y}");
                    }
                }
                catch
                {
                    // Ne dodamo med možne poteze
                }

            }
            else
            {
                // TODO: ZADNJA VRSTICA - KMET PRIDE DO KONCA
                // pogledamo zgornjo celico
                // če imamo prosto pot..
                Celica zgoraj = sahovnica.Celice[x+1, y];
                if (zgoraj.Figura == "")
                {
                    moznePoteze.Add(zgoraj);
                    // ali je prosta naslednja? 
                    Celica zgoraj2 = sahovnica.Celice[x+2, y];
                    if (zgoraj2.Figura == "" && !Premaknjen)
                    {
                        moznePoteze.Add(zgoraj2); 
                        MessageBox.Show($"{x}, {y}");
                    }
                }

                try
                {
                    Celica zgoraj_levo = sahovnica.Celice[x + 1, y - 1];
                    if (zgoraj_levo.Figura != "" && zgoraj_levo.Figura[0] == 'W')
                    {
                        moznePoteze.Add(zgoraj_levo);
                        MessageBox.Show($"{x}, {y}");
                    }
                }
                catch
                {
                    // Ne dodamo med možne poteze
                }

                try
                {
                    Celica zgoraj_desno = sahovnica.Celice[x + 1, y + 1];
                    if (zgoraj_desno.Figura != "" && zgoraj_desno.Figura[0] == 'W')
                    {
                        moznePoteze.Add(zgoraj_desno);
                        MessageBox.Show($"{x}, {y}");
                    }
                }
                catch
                {
                    // Ne dodamo med možne poteze
                }
            }
            return moznePoteze;

        }
    }

} 
