using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Register_SystemConsole
{
    internal class Menu
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        public static void Islemler(ConsoleKey secim)
        {
            switch (secim)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    OgrenciEkle("Öğrenci Ekleme Ekranı");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    OgrenciSil("Öğrenci Silme Ekranı");
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    OgrenciListele("Öğrenci Listesi Ekranı");
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    OgrenciAra("Öğrenci Arama Ekranı");
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    ToplamOgrenci("Toplam Öğrenci Ekranı");
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    GenelNotOrtalamasi("Genel Not Ortalaması Ekranı");
                    break;
            }
        }

        private static void BaslikYazdir(string metin)
        {
            Console.Clear();
            Console.WriteLine(metin);
            Console.WriteLine("----------------------");
            Console.WriteLine();
        }
        private static void AnamenuyeDon(string metin)
        {
            Console.WriteLine();
            Console.WriteLine(metin);
            Console.WriteLine("Ana Menüye Dönmek İçin Bir Tuşa Basınız!");
            Console.ReadKey();
        }


        // ----------------------------------------- İŞLEM METODLARI ----------------------------------------

        private static void OgrenciEkle(string metin)
        {
            BaslikYazdir(metin);
            Ogrenci o = new Ogrenci();
            o.Ad = Metodlar.GetString("Öğrencinin Adını Giriniz: ");
            o.Soyad = Metodlar.GetString("Öğrencinin Soyadını Giriniz: ");
            o.OkulNo = Metodlar.GetInt("Öğrenci Numarasını Giriniz: ", 1, 9999);
            o.N1 = Metodlar.GetDouble("Öğrencinin Birinci Sınav Notunu Giriniz: ", 0, 100);
            o.N2 = Metodlar.GetDouble("Öğrencinin İkinci Sınav Notunu Giriniz: ", 0, 100);
            ogrenciler.Add(o);
            AnamenuyeDon("Kayıt İşlemi Başarılı.");
        }

        private static void OgrenciSil(string metin)
        {
            BaslikYazdir(metin);
            Ogrenci o = new Ogrenci();
            if (ogrenciler.Count > 0)
            {
                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    ogrenciler[i].Yazdir(i + 1);
                }
                int siraNo = Metodlar.GetInt("Silmek İstediğiniz Öğrencinin Sıra Numarasını Giriniz: ", 1, ogrenciler.Count);
                ogrenciler.RemoveAt(siraNo - 1);
                AnamenuyeDon("Silme İşlemi Başarılı");
            }
            else
            {

                AnamenuyeDon("Listede Öğrenci Bulunamadı ! ");
            }
        }

        private static void OgrenciListele(string metin)
        {
            BaslikYazdir(metin);
            if (ogrenciler.Any())
            {
                for (int i = 0; i < ogrenciler.Count; i++)
                {
                    ogrenciler[i].Yazdir();
                }
                AnamenuyeDon(string.Format("Toplam {0} adet öğrenci Listelenmiştir", ogrenciler.Count));
            }
            else
            {
                AnamenuyeDon("Listede Öğrenci Bulunamadı ! ");
            }
        }

        private static void OgrenciAra(string metin)
        {
            BaslikYazdir(metin);
            if (ogrenciler.Any())
            {
                string aranacakOgrenci = Metodlar.GetString("Aranacak Öğrencinin Adını veya Soyadını Giriniz:");
                int adet = 0;
                foreach (var ogrenci in ogrenciler)
                {
                    if (ogrenci.tamAd.ToLower().Contains(aranacakOgrenci.ToLower()))
                    {
                        adet++;
                        ogrenci.Yazdir(adet);
                    }
                }
                AnamenuyeDon(string.Format("{0} kelimesine karşılık {1} adet öğrenci bulunmaktadır.", aranacakOgrenci, adet));
            }
            else
            {
                AnamenuyeDon("Listede Öğrenci Bulunmamakta");
            }
        }

        private static void ToplamOgrenci(string metin)
        {
            for (int i = 0; i < ogrenciler.Count; i++)
            {
                BaslikYazdir(metin);
                if (ogrenciler.Any())
                {
                    AnamenuyeDon(string.Format("Listede {0} kayıtlı öğrenci vardır.", ogrenciler.Count));
                }
                else
                {
                    AnamenuyeDon("Kayıtlı Öğrenci Bulunamadı:");
                }
            }
        }

        private static void GenelNotOrtalamasi(string metin)
        {
            BaslikYazdir(metin);
            if (ogrenciler.Any())
            {
                double genelorttoplam = 0;
                foreach (var item in ogrenciler)
                {
                    genelorttoplam += item.ortalama;

                }
                double sonuc = genelorttoplam / ogrenciler.Count();
                AnamenuyeDon(string.Format("{0} adet öğrencinin genel not ortalaması = {1}", ogrenciler.Count, sonuc));
            }
            else
            {
                AnamenuyeDon("Listede Öğrenci Bulunamadı");
            }
        }
    }
}
