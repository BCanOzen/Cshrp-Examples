using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Telephone_book
{
    internal class Menu
    {
        static List<Contacts> kisiler = new List<Contacts>();
        static List<Contacts> Favorites = new List<Contacts>();
        static List<Contacts> blocked = new List<Contacts>();
        public static void Islemler(ConsoleKey islem)
        {
            switch (islem)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    AddCont("Kişi Ekleme Ekranı");
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    ListCont("Kişi Listesi");
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    FindCont("Kişi Bulma");
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    DeleteCont("Kişi Silme Ekranı");
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    Favcalladd("Favoriye Ekleme Ekranı");
                    break;
                case ConsoleKey.D6:
                case ConsoleKey.NumPad6:
                    FavCallList("Favoriler Listesi");
                    break;
                case ConsoleKey.D7:
                case ConsoleKey.NumPad7:
                    Block("Bloklama Ekranı");
                    break;
                case ConsoleKey.D8:
                case ConsoleKey.NumPad8:
                    BlockList("Blok Listesi");
                    break;

            }
        }

        //----------------------------------------------------MENÜ METODLARI------------------------------------------------------------------

        #region Menü Metodları

        #region 1-) Kişi Ekleme 

        private static void AddCont(string metin)
        {
            Methods.TitlePrint(metin);
            Contacts k = new Contacts();
            k.Ad = Methods.GetName("Kişi Adı Giriniz: ");
            k.Soyad = Methods.GetName("Kişinin Soyadını Giriniz: ");
            k.numara = Methods.GetNumara("Kişinin Numarasını giriniz: ");
            kisiler.Add(k);
            Methods.BackToMenu("Kişi Kaydedildi.");
        }

        #endregion

        #region 2-) Kişi Listesi

        private static void ListCont(string metin)
        {
            Methods.TitlePrint(metin);
            int arama = 0;
            if (kisiler.Any())
            {
                for (int i = 0; i < kisiler.Count; i++)
                {
                    Console.WriteLine("Sıra no: " + (i + 1));
                    Console.WriteLine("-------------------");
                    kisiler[i].Print();
                }
                Console.WriteLine("Ana menü için 0");
                arama = Methods.Getint("Arama yapmak istediğiniz sıra numarasını giriniz:", 0, kisiler.Count);
                if (arama == 0)
                {
                    Methods.BackToMenu("Ana Menüye Yönlendiriliyorsunuz.");
                }
                else if (arama >= 1 && arama <= kisiler.Count)
                {
                    Console.WriteLine("{0} kişisi aranıyor", kisiler[arama - 1].tamAd);
                    Console.WriteLine("Çağrıyı Sonlandırmak için Bir Tuşa Basınız");
                    Console.ReadKey();
                }
                else
                {
                    Methods.BackToMenu("Yanlış tuşlama yaptınız Menüye yönlendiriliyorsunuz.");
                }
            }
            else
            {
                Methods.BackToMenu("Listede Kişi Bulunamadı");
            }
        }

        #endregion

        #region 3-) Kayıtlı Kişi Bulma

        private static void FindCont(string metin)
        {
            Methods.TitlePrint(metin);
            if (kisiler.Any())
            {
                string aranacakkisi = Methods.GetName("Aranacak Kişinin Adını veya Soyadını giriniz:");
                Console.WriteLine("----------------------------");
                int adet = 0;
                foreach (var kisi in kisiler)
                {
                    if (kisi.tamAd.ToLower().Contains(aranacakkisi.ToLower()))
                    {
                        adet++;
                        Console.WriteLine("sıra no: {0}", adet);
                        kisi.Print();
                    }
                }
                Methods.BackToMenu(string.Format("{0} kelimesine karşılık {1} adet kişi bulunmaktadır.\n", aranacakkisi, adet));
            }
            else
            {
                Methods.BackToMenu("Listede Kişi Bulunmamakta");
            }
        }

        #endregion

        #region 4-) Kişi Silme

        private static void DeleteCont(string metin)
        {
            Methods.TitlePrint(metin);
            int siraNo = 0;
            if (kisiler.Any())
            {
                for (int i = 0; i < kisiler.Count; i++)
                {
                    kisiler[i].Print(i + 1);
                }
                Console.WriteLine("\nSilme İşlemi Yapmayacaksanız 0");
                siraNo = Methods.Getint("\nSilmek İstediğiniz Kişinin Sıra Numarasını Giriniz: ", 0, kisiler.Count);
                if (siraNo == 0)
                {
                    Methods.BackToMenu("Ana Menüye Döndürülüyorsunuz");
                }
                else if (siraNo >= 1 && siraNo <= kisiler.Count)
                {
                    if (Favorites.Contains(kisiler[siraNo - 1]))
                    {
                        Favorites.Remove(kisiler[siraNo - 1]);
                    }
                    kisiler.RemoveAt(siraNo - 1);
                    Methods.BackToMenu("Kişi Silindi");
                }
                else
                {
                    Methods.BackToMenu("Yanlış tuşlama yaptınız Menüye yönlendiriliyorsunuz.");
                }           
            }
            else
            {
                Methods.BackToMenu("Listede Kişi Bulunamadı");
            }
        }

        #endregion

        #region 5-) Favorilere Kişi Ekleme
        private static void Favcalladd(string metin)
        {

            Methods.TitlePrint(metin);
            int ekleme = 0;
            if (kisiler.Any())
            {
                for (int i = 0; i < kisiler.Count; i++)
                {
                    Console.WriteLine("Sıra no: " + (i + 1));
                    Console.WriteLine("-------------------");
                    kisiler[i].Print();
                }
                Console.WriteLine("Ana Menüye Dönmek için 0");
                ekleme = Methods.Getint("Favori Listesine Eklemek istediğiniz Sıra No giriniz:", 0, kisiler.Count);
                if (ekleme == 0)
                {
                    Methods.BackToMenu("Ana Menüye Döndürülüyorsunuz");
                }
                else if (ekleme >= 1 && ekleme <= kisiler.Count)
                {
                    Console.WriteLine("{0} kişisi Favoriler Listesine Ekleniyor", kisiler[ekleme - 1].tamAd);
                    Favorites.Add(kisiler[ekleme-1]);
                    Console.ReadKey();
                }
                else
                {
                    Methods.BackToMenu("Yanlış tuşlama yaptınız Menüye yönlendiriliyorsunuz.");
                }
            }
            
        }

        #endregion

        #region 6-) Favoriler Listesi
        private static void FavCallList(string metin) 
        {
            Methods.TitlePrint(metin);
            int arama = 0;
            if (Favorites.Any())
            {
                for (int i = 0; i < Favorites.Count; i++)
                {
                    Console.WriteLine("Favori no: " + (i + 1));
                    Console.WriteLine("-------------------");
                    Favorites[i].Print();
                }
                Console.WriteLine("\nAna menü için 0");
                Console.WriteLine("Arama Yapmak için 1");
                Console.WriteLine("Favoriden kişi çıkarmak için 2");
                int islem = Methods.Getint("Yapmak istediğiniz işlemi giriniz:", 0, 2);
                if (islem == 0)
                {
                    Methods.BackToMenu("Ana Menüye Döndürülüyorsunuz.");
                }
                else if (islem == 1)
                {
                    Console.Clear();
                    for (int i = 0; i < Favorites.Count; i++)
                    {
                        Console.WriteLine("Favori no: " + (i + 1));
                        Console.WriteLine("-------------------");
                        Favorites[i].Print();
                    }
                    Console.WriteLine("\nAna menü için 0");
                    arama = Methods.Getint("Arama yapmak istediğiniz Favori numarasını giriniz:", 0, Favorites.Count);
                    if (arama == 0)
                    {
                        Methods.BackToMenu("Ana Menüye Yönlendiriliyorsunuz.");
                    }
                    else if (arama >= 1 && arama <= kisiler.Count)
                    {
                        Console.WriteLine("{0} kişisi aranıyor", Favorites[arama - 1].tamAd);
                        Console.WriteLine("Çağrıyı Sonlandırmak için Bir Tuşa Basınız");
                        Console.ReadKey();
                    }
                    else
                    {
                        Methods.BackToMenu("Yanlış tuşlama yaptınız Menüye yönlendiriliyorsunuz.");
                    }
                }
                else
                {
                    Console.Clear();
                    if (Favorites.Any())
                    {
                        for (int i = 0; i < Favorites.Count; i++)
                        {
                            Console.WriteLine("Favori no: " + (i + 1));
                            Console.WriteLine("-------------------");
                            Favorites[i].Print();
                        }
                        Console.WriteLine("Ana Menü için 0");
                        arama = Methods.Getint("Favoriden Kaldırmak istiyorsanız istediğiniz favori numarasını giriniz:", 0, Favorites.Count);
                        if (arama == 0)
                        {
                            Methods.BackToMenu("Ana Menüye Döndürülüyorsunuz.");
                        }
                        else if (arama >= 1 && arama <= Favorites.Count)
                        {
                            Console.WriteLine("{0} kişisi Favoriden kaldırılıyor", Favorites[arama - 1].tamAd);
                            Favorites.RemoveAt(arama - 1);
                            Console.ReadKey();
                        }
                        else
                        {
                            Methods.BackToMenu("Yanlış tuşlama yaptınız Menüye yönlendiriliyorsunuz.");
                        }
                    }
                    else
                    {
                        Methods.BackToMenu("Listede Kişi Bulunamadı");
                    }
                }
            }
            else
            {
                Methods.BackToMenu("Listede Kişi Bulunamadı");
            }
        }

        #endregion

        #region 7-) Kişi Engelle
        private static void Block(string metin)
        {
            Contacts b = new Contacts();
            Methods.TitlePrint(metin);
            int engelleme = 0;
            if (kisiler.Any())
            {
                for (int i = 0; i < kisiler.Count; i++)
                {
                    Console.WriteLine("Sıra no: " + (i + 1));
                    Console.WriteLine("-------------------");
                    kisiler[i].Print();
                }
                Console.WriteLine("AnaMenü için 0");
                engelleme = Methods.Getint("Engellemek istediğiniz Sıra No giriniz:", 0, kisiler.Count);
                if (engelleme == 0)
                {
                    Methods.BackToMenu("Ana Menüye Döndürülüyorsunuz");
                }
                else if (engelleme >= 1 && engelleme <= kisiler.Count)
                {
                    Console.WriteLine("{0} kişisi Engelliler Listesine Ekleniyor", kisiler[engelleme - 1].tamAd);
                    blocked.Add(kisiler[engelleme - 1]);
                    if (Favorites.Contains(kisiler[engelleme - 1]))
                    {
                        Favorites.Remove(kisiler[engelleme - 1]);
                    }
                    kisiler.RemoveAt(engelleme - 1);           
                    Console.ReadKey();
                }
                else
                {
                    Methods.BackToMenu("Yanlış tuşlama yaptınız Menüye yönlendiriliyorsunuz.");
                }
            }
        }
        #endregion

        #region 8-) Engelliler Listesi

        private static void BlockList(string metin)
        {
 
            Methods.TitlePrint(metin);
            int arama = 0;
            if (blocked.Any())
            {
                for (int i = 0; i < blocked.Count; i++)
                {
                    Console.WriteLine("Block no: " + (i + 1));
                    Console.WriteLine("-------------------");
                    blocked[i].Print();
                }
                Console.WriteLine("Ana Menü için 0");
                arama = Methods.Getint("Engelini Kaldırmak istiyorsanız istediğiniz blok numarasını giriniz:", 0, blocked.Count);
                if (arama == 0)
                {
                    Methods.BackToMenu("Ana Menüye Döndürülüyorsunuz.");
                }
                else if (arama >= 1 && arama <= blocked.Count)
                {
                    Console.WriteLine("{0} kişisinin bloku kaldırılıyor", blocked[arama - 1].tamAd);
                    blocked.RemoveAt(arama - 1);
                    Console.ReadKey();
                }
                else
                {
                    Methods.BackToMenu("Yanlış tuşlama yaptınız Menüye yönlendiriliyorsunuz.");
                }
            }
            else
            {
                Methods.BackToMenu("Listede Kişi Bulunamadı");
            }    
        }

        #endregion

        #endregion
    }
}
