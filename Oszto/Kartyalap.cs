using System;
using System.Collections.Generic;
using System.Text;

namespace Oszto
{
    class Kartyalap
    {
        public string szin;
        public string ertek;


        public Kartyalap()
        {
            szin = "nincs";
            ertek = "nincs";
        }

        public Kartyalap(String szin, String ertek)
        {
            this.szin = szin;
            this.ertek = ertek;
        }

       
    }
}
