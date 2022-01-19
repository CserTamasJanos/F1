using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegjobbJatekok
{
    internal class Jatek
    {
        public int KiadasiIdo { get; set; }

        public string Nev { get; set; }

        public string Tipus { get; set; }

        public string Keszito { get; set; }

        public string Platform { get; set; }

        public Jatek(int kiadasiIdo, string nev, string tipus, string keszito, string platform)
        {
            KiadasiIdo = kiadasiIdo;
            Nev = nev;
            Tipus = tipus;
            Keszito = keszito;
            Platform = platform;
        }
    }
}
