using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekeVerseny
{
    public class Egyesulet
    {
        public int Egyid { get; set; }
        public string Egynev { get; set; }

        public Egyesulet(int id, string nev)
        {
            Egyid = id;
            Egynev = nev;
        }
    }
}
