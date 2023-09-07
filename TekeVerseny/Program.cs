using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekeVerseny
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ha a csv a projekben a bin\debug mappában az .exe mellett van
            List<Eredmeny> eredmenyek = Eredmeny.LoadFromCsv("tekeverseny.csv");
            //Ha a csv a project mappájában van
            //List<Eredmeny> eredmenyek = Eredmeny.LoadFromCsv(@"..\..\tekeverseny.csv");
            double telisum = 0;
            foreach (var item in eredmenyek)
            {
                telisum += item.Teli;
            }
            double teliatlag = telisum / eredmenyek.Count;
            Console.WriteLine($"6. feladat:\n\tA teli gurítások átlaga: {teliatlag:F2} pont");

            Console.WriteLine("7. feladat:");
            int uresa = 0;
            int uresb = 0;
            foreach (var item in eredmenyek)
            {
                if(item.Jatekos.Korcsop=="A")
                {
                    uresa += item.Ures;
                } else
                {
                    uresb += item.Ures;
                }
            }
            StreamWriter sw = new StreamWriter("uresekszama.txt");
            sw.WriteLine($"Az A korcsoportban az üres gurítások száma: {uresa} db");
            sw.WriteLine($"A B korcsoportban az üres gurítások száma: {uresb} db");
            sw.Close();
            Console.WriteLine("\tAz uresekszama.txt állomány létrehozva.");

            Eredmeny nyerta = null;
            Eredmeny nyertb = null;
            foreach (var item in eredmenyek)
            {
                if(item.Jatekos.Korcsop=="A" && (nyerta==null || item.Osszespont>nyerta.Osszespont))
                {
                    nyerta = item;
                }
                if (item.Jatekos.Korcsop == "B" && (nyertb == null || item.Osszespont > nyertb.Osszespont))
                {
                    nyertb = item;
                }
            }
            Console.WriteLine("8: feladat:");
            Console.WriteLine($"\tAz A korcsoportban {nyerta.Jatekos.Nev} ({nyerta.Klub.Egynev}) nyert {nyerta.Osszespont} ponttal.");
            Console.WriteLine($"\tA B korcsoportban {nyertb.Jatekos.Nev} ({nyertb.Klub.Egynev}) nyert {nyertb.Osszespont} ponttal.");
        }
    }
}
