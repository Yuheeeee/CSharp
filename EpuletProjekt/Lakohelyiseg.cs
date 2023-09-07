using System;
using System.Collections.Generic;
using System.Text;

namespace EpuletProjekt
{
    class Lakohelyiseg
    {
        private double hossz;
        private double szelesseg;
        private double magassag;
        private double _alapterulet;

        //Az alapterulet nevű property megadása
        public double alapterulet {
            get 
            {
                _alapterulet = hossz * szelesseg;
                return _alapterulet;
            }
        }

        public double legkobmeter
        {
            get
            {
                return hossz * szelesseg * magassag;
            }
        }

        public double falfelulet
        {
            get
            {
                return 2 * hossz * magassag + 2 * szelesseg * magassag;
            }
        }

        public double mennyezet
        {
            get
            {
                return alapterulet;
            }
        }


        public Lakohelyiseg(double h, double sz, double m)
        {
            setHossz(h);
            setSzelesseg(sz);
            setMagassag(m);
        }

        public void setHossz(double h)
        {
            hossz = h;
        }

        public double getHossz()
        {
            return hossz;
        }

        public void setSzelesseg(double sz)
        {
            szelesseg = sz;
        }

        public double getSzelesseg()
        {
            return szelesseg;
        }

        public void setMagassag(double m)
        {
            magassag = m;
        }

        public double getMagassag()
        {
            return magassag;
        }

        /*public void setHossz(double hl,bool lab)
        {
            hossz = hl * 0.33;
        }*/


    }
}
