using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    public class Ad
    {
        public int Area { get; set; }
        public int Floors { get; set; }
        public int Id { get; set; }
        public int Rooms { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string LatLong { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public bool FreeOfCharge { get; set; }
        public Seller Seller { get; set; }

        //4. feladat megvalósítása
        public Ad(string adatsor)
        {
            string[] t = adatsor.Split(';');
            Id = int.Parse(t[0]);
            Rooms = int.Parse(t[1]);
            LatLong = t[2];
            Floors = int.Parse(t[3]);
            Area = int.Parse(t[4]);
            Description = t[5];
            FreeOfCharge = (t[6]=="1");
            ImageUrl = t[7];
            CreateAt = DateTime.Parse(t[8]);
            Seller = new Seller(int.Parse(t[9]), t[10], t[11]);
            Category = new Category(int.Parse(t[12]), t[13]);
        }

        //3. feladat megvalósítása
        public static List<Ad> LoadFromCsv(string fajlnev)
        {
            List<Ad> lista = new List<Ad>();
            string[] sorok = File.ReadAllLines(fajlnev);
            for (int i = 1; i < sorok.Length; i++)
            {
                lista.Add(new Ad(sorok[i]));
            }
            return lista;
        }

        //7. feladat megoldása
        public double DistanceTo(double x2, double y2)
        {
            double tav = 0;
            double x1 = double.Parse(LatLong.Split(',')[0].Replace(".",","));
            double y1 = double.Parse(LatLong.Split(',')[1].Replace(".",","));
            tav = Math.Sqrt(Math.Pow(x1 - x2 , 2)+ Math.Pow(y1 - y2, 2));
            return tav;
        }
    }
}
