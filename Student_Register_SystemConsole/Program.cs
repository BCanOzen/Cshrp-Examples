using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Register_SystemConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Öğrenci Kayıt Programı

            ConsoleKey cevap;

            do
            {
                Console.Clear();
                Console.WriteLine("Öğrenci Kayıt Programı");
                Console.WriteLine("----------------------");
                Console.WriteLine("1- Öğrenci Ekle:");
                Console.WriteLine("2- Öğrenci Sil");
                Console.WriteLine("3- Öğrencileri Listele");
                Console.WriteLine("4- Öğrenci Ara");
                Console.WriteLine("5- Toplam Öğrenci Sayısı");
                Console.WriteLine("6- Öğrencilerin Genel Not Ortalaması");
                Console.WriteLine("E- Programdan Çık");
                cevap = Console.ReadKey().Key;
                Menu.Islemler(cevap);

            } while (cevap != ConsoleKey.E);
            Console.Clear();
            Console.WriteLine("Kapatmak için herhangi bir tuşa basınız");
            Console.ReadKey();

            #endregion

        }
    }
}
