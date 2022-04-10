﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace poskus2
{
    public class Sahovnica
    {
        private Celica[,] celice;
        public Sahovnica(int velikost,Form podlaga)
        {
            celice = new Celica[8, 8];
            for (int vrstica = 0; vrstica < 8; vrstica++)
            {
                //velikost = (int)(this.Height / 16);
                for (int stolpec = 0; stolpec < 8; stolpec++)
                {

                    //this.Height
                    Celica gumb = new Celica(vrstica, stolpec);
                    gumb.Size = new Size(velikost, velikost);

                    gumb.Location = new Point(50 + stolpec * velikost, 50 + vrstica * velikost);
                    //gumb.Text = "" + vrstica + '/' + stolpec;
                    if (vrstica == 1)//beli kmetje
                    {
                        gumb.Tag = "BP";
                        gumb.Image = new Bitmap(Properties.Resources.Black_Pawn, gumb.Size);
                    }
                    else if (vrstica == 6)//beli kmetje
                    {

                        Bitmap s = new Bitmap(Properties.Resources.White_Pawn, gumb.Size);

                        gumb.Tag = "WP";
                        gumb.Image = s;
                    }
                    else if (vrstica == 0)//beli kmetje
                    {
                        if (stolpec == 0 || stolpec == 7)
                        {
                            gumb.Tag = "BR";
                            gumb.Image = new Bitmap(Properties.Resources.Black_Rook, gumb.Size);
                        }
                        else if (stolpec == 1 || stolpec == 6)
                        {
                            gumb.Tag = "BN";
                            gumb.Image = new Bitmap(Properties.Resources.Black_Knight, gumb.Size);
                        }
                        else if (stolpec == 2 || stolpec == 5)
                        {
                            gumb.Tag = "BB";
                            gumb.Image = new Bitmap(Properties.Resources.Black_Bishop, gumb.Size);
                        }
                        else if (stolpec == 3)
                        {
                            gumb.Tag = "BQ";
                            gumb.Image = new Bitmap(Properties.Resources.Black_Queen, gumb.Size);
                        }
                        else
                        {
                            gumb.Tag = "BK";
                            gumb.Image = new Bitmap(Properties.Resources.Black_King, gumb.Size);
                        }
                    }
                    else if (vrstica == 7)//beli kmetje
                    {
                        if (stolpec == 0 || stolpec == 7)
                        {
                            gumb.Tag = "WR";
                            gumb.Image = new Bitmap(Properties.Resources.White_Rook, gumb.Size);
                        }
                        else if (stolpec == 1 || stolpec == 6)
                        {
                            gumb.Tag = "WN";
                            gumb.Image = new Bitmap(Properties.Resources.White_Knight, gumb.Size);
                        }
                        else if (stolpec == 2 || stolpec == 5)
                        {
                            gumb.Tag = "WB";
                            gumb.Image = new Bitmap(Properties.Resources.White_Bishop, gumb.Size);
                        }
                        else if (stolpec == 3)
                        {
                            gumb.Tag = "WQ";
                            gumb.Image = new Bitmap(Properties.Resources.White_Queen, gumb.Size);
                        }
                        else
                        {
                            gumb.Tag = "WK";
                            gumb.Image = new Bitmap(Properties.Resources.White_King, gumb.Size);
                        }
                    }
                    else
                    {
                        gumb.Tag = "";
                    }



                    //gumb.Click += button1_Click;

                    gumb.UseVisualStyleBackColor = true;

                    podlaga.Controls.Add(gumb);
                    celice[vrstica, stolpec] = gumb;
                }
            }
            this.celice = celice;



        }

        public Celica[,] Celice
        {
            get
            {
                return this.celice;
            }
           
        }

        public List<Celica> MoznePoteze(Celica celica)
        {
            List<Celica> mozni = new List<Celica>();
            int x = celica.X;
            int y = celica.Y;
            if(celica.Tag == "BP")
            //TODO Če smo v prvi vrstici....
            {
                mozni.Add(this.Celice[x,y + 1]);
            }
            else if (celica.Tag == "WP")
            {
                //Poglejmo, če je zgornja celica prazna
                if(this.Celice[x, y - 1].Tag == "")
                {
                    mozni.Add(this.Celice[x, y - 1]);
                }
                //Zgoraj levo, ali je "nasprotnik"
                //if (this.Celice[x-1, y - 1].Tag[0] == "B")
                //{

                //}





            }
            else if (celica.Tag == "BR")
            {


                mozni.Add(this.Celice[x, y + 1]);
            }




            return mozni;
        }






        



    }
}
