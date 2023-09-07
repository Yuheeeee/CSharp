using System;
using System.IO;

namespace Szotar
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string fajlnev = @"..\..\..\szotar.txt";
                string[] sorok = File.ReadAllLines(fajlnev);
                Console.WriteLine("A fájl sorainak száma: {0}", sorok.Length);

                Console.WriteLine("Adjon meg egy kezdőbetűt!");
                string kb = Console.ReadLine();

                foreach (string szo in sorok)
                {
                    if (szo.StartsWith(kb))
                    {
                        Console.WriteLine(szo);
                    }
                }

                //a megfelelő sorszámú szó kiírása

                Console.WriteLine("Kérem egy szó sorszámát!");
                int sor = int.Parse(Console.ReadLine());
                //int sor2 = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("A {0}. szó: {1}",sor,sorok[sor-1]);

                //A leghosszabb szavak megkeresése és listázása
                int maxhossz = 0;
                foreach (var item in sorok)
                {
                    if (item.Length > maxhossz) maxhossz = item.Length;
                }
                //listázás
                Console.WriteLine( $"A leghosszabb szavak ({maxhossz}):" );
                foreach (var item in sorok)
                {
                    if (item.Length == maxhossz) Console.WriteLine(item);
                }

            }
            catch (FormatException f)
            {
                Console.WriteLine("Az egész szám formátuma hibás!");
            }
            catch (Exception hiba)
            {
                Console.WriteLine("Sajnos hiba történt a fájl megnyitása közben!");
                Console.WriteLine(hiba); ;
            }
               
        }
    }
}
