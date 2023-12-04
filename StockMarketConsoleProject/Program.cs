using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            baslangic:
            Console.Write("Sermayenizi giriniz:");
            int balance = int.Parse(Console.ReadLine());
            int mevcutthy = 0, mevcuteregl = 0, mevcutbist100 = 0, adet;
            int thy = 500, bist100 = 100, eregl = 40;
            if (balance <= 0) 
            {
                Console.Clear();
                Console.WriteLine("Hatalı sermaye girişi yaptınız.");
                goto baslangic;
            }
            do 
            {
                tamdongu:
                Console.WriteLine("Mevcut hisseleriniz ve bakiyeniz:" + "\nBakiyeniz=" + balance + "\nTHY=" + mevcutthy + "\nEREGL=" + mevcuteregl + "\nbist100=" + mevcutbist100);
                Console.WriteLine("Alış yapmak için a\nSatış yapmak için s\nÇıkış yapmak için e tuşuna basınız.");
                Console.Write("Lütfen Yapmak istediğiniz işlemi seçiniz:");
                string islem = Console.ReadLine();
                if (islem == "e")
                {
                    Console.WriteLine("Uygulamamızı kullandığınız için teşekkürler !!!\nÇıkış yapıyorsunuz.");
                    break;
                }
                else if (islem == "a")
                {
                    alisdongu:
                    Console.Write("Mevcut hisselerimiz = thy , eregl , bist100\nİşlem yapmak istediğiniz Hisseyi giriniz:");
                    string hisse = Console.ReadLine();
                    Console.Write("Lütfen adet giriniz:");
                    adet = int.Parse(Console.ReadLine());
                    if (hisse == "thy")
                    {
                        mevcutthy = adet + mevcutthy;
                        balance = balance - adet * thy;
                    }
                    else if (hisse == "bist100")
                    {
                        mevcutbist100 = adet + mevcutbist100;
                        balance = balance - adet * bist100;
                    }
                    else if (hisse == "eregl")
                    {
                        mevcuteregl = adet + mevcuteregl;
                        balance = balance - adet * eregl;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Lütfen geçerli bir hisse giriniz.");
                        goto alisdongu;
                    }
                    goto tamdongu;
                }
                else if (islem == "s")
                {
                    satisdongu:
                    Console.Write("Mevcut hisselerimiz = thy , eregl , bist100\nİşlem yapmak istediğiniz Hisseyi giriniz:");
                    string hisse = Console.ReadLine();
                    Console.Write("Lütfen adet giriniz:");
                    adet = int.Parse(Console.ReadLine());
                    if (hisse == "thy")
                    {
                        mevcutthy = mevcutthy - adet;
                        balance = balance + adet * thy;
                    }
                    else if (hisse == "bist100")
                    {
                        mevcutbist100 = mevcutbist100 - adet;
                        balance = balance + adet * bist100;
                    }
                    else if (hisse == "eregl")
                    {
                        mevcuteregl = mevcuteregl - adet;
                        balance = balance + adet * eregl;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Lütfen geçerli bir hisse giriniz.");
                        goto satisdongu;
                    }
                    goto tamdongu;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Lütfen geçerli bir işlem giriniz !!!");
                    goto tamdongu;
                }

            } while (true);

            Console.ReadKey();
        }
    }
}
