using System;
using System.Collections.Generic;
using System.Text;

namespace Oszto
{
    class Jatekos
    {
        public Kartyalap[] lapok;
        public string nev;
        private int ennyivan; 

        public Jatekos(string nev,int lszam)
        {
            this.nev = nev;
            lapok = new Kartyalap[lszam];
            ennyivan = 0;
        }

        public void felvesz(Kartyalap[] osztas)
        {
            for (int i = 0; i < osztas.Length; i++)
            {
                lapok[ennyivan + i] = osztas[i];
            }
            ennyivan += osztas.Length;
        }

        public void terit()
        {
            Console.WriteLine(nev);
            foreach (Kartyalap lap in lapok)
            {
                Console.Write(lap.szin+"-"+lap.ertek+"    ");
            }
            Console.WriteLine();
        }

    }
}
