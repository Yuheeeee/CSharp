using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekeVerseny
{
    public class Versenyzo
    {
        public int Rajtszam { get; set; }
        public string Nev { get; set; }
        public string Korcsop { get; set; }

        public Versenyzo(int rsz, string nev, string kcs)
        {
            Rajtszam = rsz;
            Nev = nev;
            Korcsop = kcs;
        }
    }
}
