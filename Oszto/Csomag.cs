using System;
using System.Collections.Generic;
using System.Text;


namespace Oszto
{
    class Csomag
    {
        public static readonly string[] frszinek = { "pikk", "kőr", "káró", "treff" };
        public static readonly string[] frertekek = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "D", "K", "A" };

        public Kartyalap[] lapok;
        private int ennyivan;


        public Csomag()
        {
            lapok = new Kartyalap[52];
            ennyivan = 52;
            int lit = 0;
            for (int i = 0; i < frszinek.Length; i++)
            {
                for (int j = 0; j < frertekek.Length; j++)
                {
                    lapok[lit] = new Kartyalap(frszinek[i], frertekek[j]);
                    lit++;
                    //lapok[i*13+j] = new ....
                }
            }

            /*foreach (var item in lapok)
            {
                Console.WriteLine(item.szin+"-"+item.ertek);
            }*/
        }

        public void kever()
        {
            Random rd = new Random();
            for (int i = 0; i < 500; i++)
            {
                int n1 = rd.Next(0, 51);
                int n2 = rd.Next(0, 51);
                if(n1!=n2)
                {
                    Kartyalap temp = lapok[n1];
                    lapok[n1] = lapok[n2];
                    lapok[n2] = temp;
                }
            }
            foreach (var item in lapok)
            {
                Console.WriteLine(item.szin+"-"+item.ertek);
            }
        }

        public Kartyalap[] huzas(int lapszam)
        {
            Kartyalap[] kt = new Kartyalap[lapszam];
            for (int i = 0; i < lapszam; i++)
            {
                kt[i] = lapok[ennyivan - (1 + i)];
                lapok[ennyivan - (1 + i)] = null;
            }
            ennyivan -= lapszam;
            return kt;
            
        }


    }
}
