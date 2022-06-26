using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Sah_projekt
{
    public class RezervaFigure // ta razred ustvari 4 gumbe, ki se pojavijo, ko kmet pride do vrha 
    {

        private Celica[] tabela_celic;
        private Sahovnica sahovnica;

        public RezervaFigure(int velikost, Form podlaga, string barva, Sahovnica sahovnica)
        {


            Celica[] tabela = new Celica[4];
            this.sahovnica = sahovnica;
            int lokacija_figure = 0;
            for (int i = 0; i < 4; i++)
            {
                Celica gumb = new Celica(lokacija_figure, lokacija_figure);
                gumb.Size = new Size(velikost, velikost);
                if (barva == "B")
                {

                    //lokacija bo odvisna od tega ali je barva bela ali črna...
                    gumb.Location = new Point(50 + i * velikost, 50 + 8 * velikost);
                    if (i == 0)
                    {
                        Figura fig = new Figura("BQ", i + 1, lokacija_figure, gumb.Size);
                        gumb.Tag = "BQ";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                        

                    }
                    if (i == 1)
                    {


                        Figura fig = new Figura("BR", i + 1, lokacija_figure, gumb.Size);
                        gumb.Tag = "BR";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                    if (i == 2)
                    {
                        Figura fig = new Figura("BB", i + 1, lokacija_figure, gumb.Size);
                        gumb.Tag = "BB";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                    if (i == 3)
                    {
                        Figura fig = new Figura("BN", i + 1, lokacija_figure, gumb.Size);
                        gumb.Tag = "BN";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }

                }
                else
                {
                    gumb.Location = new Point(50 + i * velikost, 10);
                    if (i == 0)
                    {
                        Figura fig = new Figura("WQ", i + 1, lokacija_figure, gumb.Size);
                        gumb.Tag = "WQ";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;

                    }
                    if (i == 1)
                    {


                        Figura fig = new Figura("WR", i + 1, lokacija_figure, gumb.Size);
                        gumb.Tag = "WR";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                    if (i == 2)
                    {
                        Figura fig = new Figura("WB", i + 1, lokacija_figure, gumb.Size);
                        gumb.Tag = "WB";
                        gumb.Image = fig.Slika;
                        gumb.Figura = fig;
                    }
                    if (i == 3)
                    {
                        Figura fig = new Figura("WN", i + 1, lokacija_figure, gumb.Size);
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
            this.Tabela_celic = tabela;

        }

        public Celica[] Tabela_celic { get; set; }

        public void Prikaži()//prikaže vse gumbe 
        {
            for (int i = 0; i < 4; i++)
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
            int poslji = fig.X;
            Sahovnica.Odmrzni(sahovnica);
            Figura novaFigura = new Figura(fig.Ime, fig.X, fig.Y, gumb.Size);
            fig.X = sahovnica.Zadnja_prestavljena_celica.Figura.X;
            fig.Y = sahovnica.Zadnja_prestavljena_celica.Figura.Y;
            int posljiX2 = 7 - fig.X;
            int posljiY2 = fig.Y;

            sahovnica.Trenutni_igralec.SpremeniStanje(gumb, true);
            sahovnica.podlaga.Igralec1_Cas.Text = sahovnica.igralec1.Vsota.ToString();
            sahovnica.podlaga.Igralec2_Cas.Text = sahovnica.igralec2.Vsota.ToString(); 

            sahovnica.Zadnja_prestavljena_celica.Figura = fig;
            sahovnica.Zadnja_prestavljena_celica.Image = fig.Slika;
            gumb.Figura = novaFigura;
            this.Skrij();

            //PreveriMAt();
            if (sahovnica.Trenutni_igralec == sahovnica.igralec1)
            {

                if (Figura.Mat(sahovnica, sahovnica.igralec1.Barva))
                {
                    MessageBox.Show("MAT");
                }
                if (sahovnica.podlaga.solo)
                {
                    sahovnica.Trenutni_igralec = sahovnica.igralec2;
                }
            }
            else
            {

                if (Figura.Mat(sahovnica, sahovnica.igralec2.Barva))
                {
                    MessageBox.Show("MAT");
                }
                if (sahovnica.podlaga.solo)
                {
                    sahovnica.Trenutni_igralec = sahovnica.igralec1;
                }
            }
            if (sahovnica.podlaga.racunalnik)
            {
                //RAČUNALNIK NAREDI POTEZO
                if (sahovnica.Trenutni_igralec == sahovnica.igralec1)
                {
                    //sahovnica.Trenutni_igralec = "B";
                    if (Figura.Mat(sahovnica, sahovnica.igralec2.Barva))
                    {
                        MessageBox.Show("MAT");
                        sahovnica.podlaga.Close();
                    }
                }
                else
                {
                    //sahovnica.Trenutni_igralec = "W";
                    if (Figura.Mat(sahovnica, sahovnica.igralec1.Barva))
                    {
                        MessageBox.Show("MAT");
                        sahovnica.podlaga.Close();
                    }
                }

                List<(Celica, Celica)> vse_poteze = Figura.VseMoznePoteze(sahovnica, sahovnica.Trenutni_igralec.Barva);
                int index = sahovnica.random.Next(vse_poteze.Count);
                Celica celica1 = vse_poteze[index].Item1;
                Celica celica2 = vse_poteze[index].Item2;
                Figura nova = new Figura("", sahovnica.Zadnja_celica.X, sahovnica.Zadnja_celica.Y, sahovnica.Zadnja_celica.Size);

                celica2.Figura = celica1.Figura;
                celica2.Figura.X = celica2.X;
                celica2.Figura.Y = celica2.Y;
                celica2.Figura.Premaknjen = true;
                celica2.Image = celica2.Figura.Slika;
                celica1.Figura = nova;
                celica1.Image = nova.Slika;


                //PREVERI MAT IN ZAMENJI IGRALCA
                if (sahovnica.Trenutni_igralec == sahovnica.igralec1)
                {
                    if (sahovnica.podlaga.solo)
                    {
                        sahovnica.Trenutni_igralec = sahovnica.igralec2;
                    }
                    if (Figura.Mat(sahovnica, sahovnica.igralec2.Barva))
                    {
                        MessageBox.Show("MAT");
                        sahovnica.podlaga.Close();
                    }
                }
                else
                {
                    if (sahovnica.podlaga.solo)
                    {
                        sahovnica.Trenutni_igralec = sahovnica.igralec1;
                    }
                    
                    if (Figura.Mat(sahovnica, sahovnica.igralec1.Barva))
                    {
                        MessageBox.Show("MAT");
                        sahovnica.podlaga.Close();
                    }
                }
            }

            if (!sahovnica.podlaga.solo)//Pošlji podatek še nasprotniku
            {

                int posljiX1 = 7-sahovnica.ZadnjaPrestavljenaCelicaRezerva.X;
                int posljiY1 = sahovnica.ZadnjaPrestavljenaCelicaRezerva.Y;
                byte[] num = { (byte)posljiX1, (byte)posljiY1, (byte)posljiX2, (byte)posljiY2, (byte)poslji};
                MessageBox.Show(poslji.ToString());
    
                sahovnica.podlaga.socket.Send(num);
                sahovnica.podlaga.MessageReceiver.RunWorkerAsync();
                

            }


        }









    }
}
