using System;
using System.Collections.Generic;
using System.Text;

namespace EpuletProjekt
{
    class Epulet
    {
        private List<Lakohelyiseg> lhlista;

        public double koNegyzetmeter
        {
            get
            {
                double nm = 0;
                foreach (Lakohelyiseg item in lhlista)
                {
                    nm += item.alapterulet;
                }
                return nm;
            }
        }

        public Epulet()
        {
            lhlista = new List<Lakohelyiseg>();
        }

        public void beKeres()
        {
            string menupont = "";
            do
            {
                Console.WriteLine("a: Új helyiség hozzáadása\nq: Kilépés a menüből");
                menupont = Console.ReadLine();
                if(menupont=="a")
                {
                    Console.WriteLine("Adja meg a helyiség hosszát méterben!");
                    double h = double.Parse(Console.ReadLine());
                    Console.WriteLine("Adja meg a helyiség szélességét méterben!");
                    double sz = double.Parse(Console.ReadLine());
                    Console.WriteLine("Adja meg a helyiség magasságát méterben!");
                    double m = double.Parse(Console.ReadLine());
                    lhlista.Add(new Lakohelyiseg(h, sz, m));
                } else if(menupont=="q")
                {
                    Console.WriteLine($"Az épületben {lhlista.Count} db helyiség van.");
                }

            } while (menupont != "q");
        }

        public double festekLiter(double lpnm)
        {
            double nm = 0;
            foreach (Lakohelyiseg item in lhlista)
            {
                nm += (item.falfelulet + item.mennyezet);
               
            }
            return nm * lpnm;
        }
    }
}
