using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_book
{
    internal class Methods
    {
        public static string GetName(string metin)
        {
            string text = string.Empty;
            bool hata = true;
            do
            {
                Console.Write(metin);
                text = Console.ReadLine();
                if (string.IsNullOrEmpty(text))
                {
                    Console.WriteLine("Boş Bırakılamaz !!!");
                    hata = true;
                }
                else
                {
                    hata = false;
                }

            } while (hata);
            return text;
        }

        public static string GetNumara(string metin)
        {
            string text = string.Empty;
            bool hata = true;
            do
            {
                try
                {
                    Console.Write(metin);
                    text = Console.ReadLine();
                    if (text.Length == 11 && IsNumeric(text))
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Girilen sayı 11 haneli ve başında 0 olmalı !!! ");
                        hata = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hata = true;
                }
            } while (hata);
            return text;
        }

        public static int Getint(string metin, int min = int.MinValue, int max = int.MaxValue)
        {
            int sayi = 0;
            bool hata = true;
            do
            {
                Console.Write(metin);
                try
                {
                    sayi = int.Parse(Console.ReadLine());
                    if (sayi >= min && sayi <= max)
                    {
                        hata = false;
                    }
                    else
                    {
                        Console.WriteLine("Girilen sayı {0} ile {1} aralığında olmalı !", min, max);
                        hata = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    hata = true;
                }
            } while (hata);
            return sayi;
        }

        public static void TitlePrint(string metin)
        {
            Console.Clear();
            Console.WriteLine(metin);
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }

        public static void BackToMenu(string metin)
        {
            Console.WriteLine();
            Console.WriteLine(metin);
            Console.WriteLine("Ana Menüye Dönmek İçin Bir Tuşa Basınız!");
            Console.ReadKey();
        }

        private static bool IsNumeric(string value)
        {
            foreach (char c in value)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }
    
    }
}
