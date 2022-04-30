using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace poskus2
{
    public class RezervaFigure // ta razred ustvari 4 gumbe, ki se pojavijo, ko kmet pride do vrha 
    {

        private Celica[] tabela_celic;
        private Sahovnica sahovnica;

        public RezervaFigure(int velikost,Form podlaga,string barva, Sahovnica sahovnica)
        {


            Celica[] tabela = new Celica[4];
            this.sahovnica = sahovnica;
            int lokacija_figure = 0;
            for (int i = 0;i < 4; i++)
            {
                Celica gumb = new Celica(lokacija_figure, lokacija_figure);
                gumb.Size = new Size(velikost, velikost);
                if (barva == "B")
                {
                    
                    //lokacija bo odvisna od tega ali je barva bela ali črna...
                    gumb.Location = new Point(50 + i * velikost, 10);
                    if (i == 0)
                    {
                        Figura fig = new Figura("BQ", lokacija_figure, lokacija_figure, gumb.Size);
                        gumb.Tag = "BQ";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;

                    }
                    if (i == 1)
                    {


                        Figura fig = new Figura("BR", lokacija_figure, lokacija_figure, gumb.Size);
                        gumb.Tag = "BR";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                    if (i == 2)
                    {
                        Figura fig = new Figura("BB", lokacija_figure, lokacija_figure, gumb.Size);
                        gumb.Tag = "BB";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                    if (i == 3)
                    {
                        Figura fig = new Figura("BN", lokacija_figure, lokacija_figure, gumb.Size);
                        gumb.Tag = "BN";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }

                }
                else
                {
                    gumb.Location = new Point(50 + i * velikost, 50 + 8 * velikost);
                    if (i == 0)
                    {
                        Figura fig = new Figura("WQ", lokacija_figure, lokacija_figure, gumb.Size);
                        gumb.Tag = "WQ";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;

                    }
                    if (i == 1)
                    {


                        Figura fig = new Figura("WR", lokacija_figure, lokacija_figure, gumb.Size);
                        gumb.Tag = "WR";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                    if (i == 2)
                    {
                        Figura fig = new Figura("WB", lokacija_figure, lokacija_figure, gumb.Size);
                        gumb.Tag = "WB";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                    if (i == 3)
                    {
                        Figura fig = new Figura("WN", lokacija_figure, lokacija_figure, gumb.Size);
                        gumb.Tag = "WN";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                }


                gumb.Click += button2_Click;
                gumb.UseVisualStyleBackColor = true;
                gumb.Hide();
                podlaga.Controls.Add(gumb);
                tabela[i] = gumb;


            }
            this.Tabela_celic =  tabela;

        }

        public Celica[] Tabela_celic { get;  set; }

        public void Prikaži()//prikaže vse gumbe 
        {
            for (int i = 0;i< 4; i++)
            {
                this.Tabela_celic[i].Show();
            }
        }

        public void Skrij()//Skrije vse gumbe 
        {
            for (int i = 0; i < 4; i++)
            {
                this.Tabela_celic[i].Hide();
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            //ko se to zgodi, moramo zamenjati zadnjo prestavljeno
            //figuro (kmeta) z figuro ki jo izberemo
            Celica gumb = (Celica)sender;
            Figura fig = gumb.Figura;
            fig.X = sahovnica.
   
            //zadnja_celica.Figura = fig;


        }









    }
}
