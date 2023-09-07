using System;
using System.IO;

namespace Valasztasok
{
    class Program
    {
        static void Main(string[] args)
        {
            string fajlnev = @"..\..\..\szavazatok.txt";
            string[] sorok = File.ReadAllLines(fajlnev);
            Console.WriteLine("A fájl sorainak száma: {0}", sorok.Length);

            //képviselő objektumok elkészítése egy új tömbben
            Kepviselok[] klista = new Kepviselok[sorok.Length];
            int cnt = 0;

            foreach (string sor in sorok)
            {
                string[] adatok = sor.Split(" ");
                //Console.WriteLine(adatok[1]+"-"+adatok[2]);
                Kepviselok k = new Kepviselok();
                k.kerulet = int.Parse(adatok[0]);
                k.szavazat = int.Parse(adatok[1]);
                k.vezeteknev = adatok[2];
                k.keresztnev = adatok[3];
                k.part = adatok[4];
                klista[cnt] = k;
                cnt++;
            }
            
            Console.WriteLine(klista[0]);

            //összes szavazatok száma
            int osszes = 0;
            foreach (Kepviselok kepv in klista)
            {
                osszes += kepv.szavazat;
            }
            Console.WriteLine("Az összes szavazat: {0}",osszes);
            Console.WriteLine("Az átlagos szavazatok száma: {0:F2}",(double)osszes/klista.Length);

            //kerületenként induló jelöltek száma
            for (int ker = 1; ker < 9; ker++)
            {
                int hanyan = 0;
                foreach (Kepviselok k in klista)
                {
                    if (k.kerulet == ker) hanyan++;
                }
                Console.WriteLine($"A(z) {ker}. kerületben {hanyan} indultak");
            }
            // az előbbi feladat a klista egyszeri végigjárásával
            int[] kepvdb = new int[9];
            foreach (Kepviselok k in klista)
            {
                kepvdb[k.kerulet]++;
            }
            for (int ker = 1; ker < 9; ker++)
            {
                Console.WriteLine($"A(z) {ker}. kerületben {kepvdb[ker]} indultak");
            }


            Console.WriteLine();
            //Otthoni feladat: Melyik kerületben ki nyerte és hány szavazattal a választást?
            for (int ker = 1; ker < 9; ker++)
            {
                Kepviselok nyertes = null;
                foreach (Kepviselok k in klista)
                {
                    if (k.kerulet==ker && (nyertes==null || k.szavazat>nyertes.szavazat) )
                    {
                        nyertes = k;
                    }
                }
                Console.WriteLine($"A(z) {ker}. kerületben {nyertes.ToString()} nevű jelölt nyert {nyertes.szavazat} vokssal.");
            }

            
        }
    }
}
