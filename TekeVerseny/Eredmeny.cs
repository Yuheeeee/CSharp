using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekeVerseny
{
    public class Eredmeny
    {
        public Versenyzo Jatekos { get; set; }
        public Egyesulet Klub { get; set; }
        public int Teli { get; set; }
        public int Tarolas { get; set; }
        public int Ures { get; set; }
        public int Osszespont { get
            {
                return Teli + Tarolas;
            }
        }

        public static List<Eredmeny> LoadFromCsv(string fname)
        {
            List<Eredmeny> lista = new List<Eredmeny>();
            string[] sorok = File.ReadAllLines(fname);
            for (int i = 1; i < sorok.Length; i++)
            {
                lista.Add(new Eredmeny(sorok[i]));
            }

            return lista;
        }

        public Eredmeny(string adatsor)
        {
            string[] t = adatsor.Split(';');
            Teli = int.Parse(t[0]);
            Tarolas = int.Parse(t[1]);
            Ures = int.Parse(t[2]);
            Jatekos = new Versenyzo(int.Parse(t[3]), t[4], t[5]);
            Klub = new Egyesulet(int.Parse(t[6]), t[7]);
        }

        public override string ToString()
        {
            return Jatekos.Nev;
        }

    }
}
