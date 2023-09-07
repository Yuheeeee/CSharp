using System;

namespace EpuletProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Epulet ep = new Epulet();
            ep.beKeres();
            Console.WriteLine("Szükséges kő: "+ep.koNegyzetmeter);
            Console.WriteLine("Szükséges festék: "+ep.festekLiter(0.2));
        }
    }
}
