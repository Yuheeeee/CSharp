using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merkozesek
{
    public class Merkozes
    {
        public int Fordulo { get; set; }
        public int HazaiRugott { get; set; }
        public int VendegRugott { get; set; }
        public int HazaiRugottFelido { get; set; }
        public int VendegRugottFelido { get; set; }

        public string Hazai { get; set; }
        public string Vendeg { get; set; }

        public Merkozes(string adatsor)
        {
            string[] t = adatsor.Split(' ');
            Fordulo = int.Parse(t[0]);
            HazaiRugott = int.Parse(t[1]);
            VendegRugott = int.Parse(t[2]);
            HazaiRugottFelido = int.Parse(t[3]);
            VendegRugottFelido = int.Parse(t[4]);
            Hazai = t[5];
            Vendeg = t[6];
        }

        public override string ToString()
        {
            return $"{Hazai} - {Vendeg}";
        }

        //konzolra írás tesztelése példa
        public void konzolraIras()
        {
            if (VendegRugottFelido==HazaiRugottFelido)
            {
                Console.WriteLine("Félidő: döntetlen");
            } else
            {
                Console.WriteLine("Félidő: nem döntetlen");
            }
        }

        public bool tippeles(int hgol, int vgol)
        {
            return (hgol == HazaiRugott && vgol == VendegRugott);
        }

    }
}
