using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_book
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            ConsoleKey islem;

            do
            {
                Console.Clear();
                Console.WriteLine("Kişi Eklemek için 1");
                Console.WriteLine("Kişi Listesine Erişmek için 2");
                Console.WriteLine("Kayıtlı Kişiyi Bulmak için 3");
                Console.WriteLine("Kişi Silmek için 4");
                Console.WriteLine("Favorilere Ekleme için 5");
                Console.WriteLine("Favoriler Listesi için 6");
                Console.WriteLine("Kişi Engellemek için 7");
                Console.WriteLine("Engelliler Listesi için 8");
                Console.WriteLine("Programdan çıkış yapmak için E");          
                islem = Console.ReadKey().Key;
                Menu.Islemler(islem);

            } while (islem != ConsoleKey.E);

            Console.Clear();
            Console.WriteLine("Programı kullandığınız için teşekkür ederiz.\nKapatmak için herhangi bir tuşa basınız !!!");
            Console.ReadKey();
        }
    }
}
