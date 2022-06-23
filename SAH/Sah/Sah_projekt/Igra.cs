using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sah_projekt
{
    public class Igra
    {
        private static NavideznaSahovnica navideznaSahovnica;
        private PravaSahovnica pravaSahovnica;
        private Sahovnica sahovnica;
        private Igralec igralec1;
        private Igralec igralec2;
        private Igralec trenutniIgralec;
        private Game podlaga;

        public Igra() { }
        public static NavideznaSahovnica NavideznaSahovnica { get; set; }
        public PravaSahovnica PravaSahovnica { get; set; }
        public Sahovnica Sahovnica { get; set; }
        public Igralec Igralec1 { get; set; }
        public Igralec Igralec2 { get; set; }
        public Igralec TrenutniIgralec { get; set; }
        public Game Podlaga { get; set; }

    }
}
