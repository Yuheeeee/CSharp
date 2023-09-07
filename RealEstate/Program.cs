using System;
using System.Collections.Generic;

namespace RealEstate
{
    public class Program
    {
        static void Main(string[] args)
        {
            //5. feladat
            List<Ad> hirdetesek = Ad.LoadFromCsv("realestates.csv");
            //beolvasás ellenőrzés
            //Console.WriteLine($"Darab: {hirdetesek.Count} első createat: {hirdetesek[0].CreateAt}");

            //6. feladat
            double osszTerulet = 0;
            double fszdb = 0;
            hirdetesek.ForEach(ad => {
                if (ad.Floors == 0)
                {
                    osszTerulet += ad.Area;
                    fszdb++;
                }
            });
            double atlag = osszTerulet / fszdb;
            Console.WriteLine($"6. feladat: Földszinti átlagos alapterület: {atlag:F2}");

            //7. feladat Lásd az Ad osztály kódjában

            //8. feladat
            double mvx = 47.4164220114023;
            double mvy = 19.066342425796986;
            Ad legkozelebb = null;
            foreach (var ad in hirdetesek)
            {
                if (ad.FreeOfCharge)
                {
                    if (legkozelebb==null || ad.DistanceTo(mvx,mvy)<legkozelebb.DistanceTo(mvx,mvy))
                    {
                        legkozelebb = ad;
                    }
                }
            }
            Console.WriteLine("8. feladat: Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai:");
            Console.WriteLine($"\tEladó neve     : {legkozelebb.Seller.Name}");
            Console.WriteLine($"\tEladó telefonja: {legkozelebb.Seller.Phone}");
            Console.WriteLine($"\tAlapterület    : {legkozelebb.Area}");
            Console.WriteLine($"\tSzobák száma   : {legkozelebb.Rooms}");
        }
    }
}
