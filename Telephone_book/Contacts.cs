using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_book
{
    internal class Contacts
    {
        public string Ad, Soyad;
        public string numara;
        public string tamAd
        {
            get { return Ad + " " + Soyad; }
        }

        public void Print()
        {
            Console.WriteLine("Kişinin Adı ve Soyadı : " + tamAd);
            Console.WriteLine("Kişinin Numarası: " + numara);
            Console.WriteLine("--------------------------------\n");
        }

        public void Print(int siraNo)
        {
            Console.WriteLine(siraNo + "-" + tamAd + " : " + numara);
        }
    }
}
