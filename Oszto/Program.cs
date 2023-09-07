using System;
using System.Collections.Generic;

namespace Oszto
{
    class Program
    {
        static void Main(string[] args)
        {
            Csomag pakli = new Csomag();
            pakli.kever();

            try
            {
                Console.WriteLine("Adja meg hány játékosnak osztok lapot:");
                int jszam = int.Parse(Console.ReadLine());
                Console.WriteLine("Adja meg hány lapot osztok egy játékosnak:");
                int lszam = int.Parse(Console.ReadLine());
                Console.WriteLine("Adja meg hányasával osszam a lapokat:");
                int hszam = int.Parse(Console.ReadLine());

                if (jszam*lszam>52)
                {
                    throw new Exception("Nem lehet ennyi lapot kiosztani!");
                }
                if(lszam%hszam!=0)
                {
                    throw new Exception("Nem lehet ilyen adagokban kiosztani lapokat!");
                }

                List<Jatekos> jatekosok = new List<Jatekos>();
                for (int i = 0; i < jszam; i++)
                {
                    jatekosok.Add(new Jatekos("játékos" + i,lszam));
                }

                //az osztás végrehajtása
                int kor = lszam / hszam;
                for (int i = 0; i < kor; i++)
                {
                    for (int j = 0; j < jatekosok.Count; j++)
                    {
                        Kartyalap[] adag = pakli.huzas(hszam);
                        jatekosok[j].felvesz(adag);
                    }
                }

                for (int j = 0; j < jatekosok.Count; j++)
                {
                    jatekosok[j].terit();
                }

                foreach (var item in pakli.lapok)
                {
                    Console.WriteLine(item);
                }


            }
            catch (Exception hiba)
            {
                Console.WriteLine(hiba.Message);
                
            }
        }
    }
}
