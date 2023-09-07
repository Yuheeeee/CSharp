using NUnit.Framework;
using System;
using System.IO;


namespace MerkozesTest
{
    public class Tests
    {
        Merkozesek.Merkozes merk;
        Merkozesek.Merkozes merk2;
        [SetUp]
        public void Setup()
        {
            merk = new Merkozesek.Merkozes("2 3 2 1 1 elsocsapat masodikcsapat");
            merk2 = new Merkozesek.Merkozes("2 2 4 1 2 elsocsapat masodikcsapat");
            
        }

        [Test]
        public void MasodikCsapatnev()
        {
            Assert.AreEqual("masodikcsapat",merk.Vendeg);
        }

        [Test]
        public void HazaiGolokTeszt()
        {
            int vart = 3;
            Assert.AreEqual(vart, merk.HazaiRugott);
        }

        
        [Test]
        public void SzovegbeAlakitasTeszt()
        {
           Assert.AreEqual("elsocsapat - masodikcsapat", merk.ToString());
        }

        //konzolra írás tesztelése példa
        [TestCase]
        public void KonzolTeszt()
        {
            using (StringWriter sb = new StringWriter())
            {
                Console.SetOut(sb);
                merk.konzolraIras();
                Assert.AreEqual("Félidõ: döntetlen", sb.ToString().Trim());
            }
            
        }

        [Test]
        [TestCase(3,2,ExpectedResult = true)]
        [TestCase(2,2,ExpectedResult = false)]
        [TestCase(0,0,ExpectedResult = false)]
        [TestCase(2,3,ExpectedResult = false)]
        public bool TippTeszt(int hgol, int vgol)
        {
            return merk.tippeles(hgol, vgol) ;
        }

       

    }
}