using System;
using System.Collections.Generic;
using System.Text;

namespace Valasztasok
{
    class Kepviselok
    {
        public int kerulet;
        public int szavazat;
        public string vezeteknev;
        public string keresztnev;
        public string part;

        public override string ToString()
        {
            return vezeteknev + " " + keresztnev;
        }


    }
}
