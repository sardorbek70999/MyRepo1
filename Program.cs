using _3_Modul_Imtixon_1_Savol;
using RestoranManagement;
using System;
using System.Collections.Generic;

namespace RestoranManagement
{
  
    public class Program:Taom
          
    {
        public static string path = @"C:\Users\Noutbuk Savdosi\Desktop\G3_Ibroximov_Sardorbek_3_Modul\Savol.txt";
        static List<Taom> taomlar = new List<Taom>();

        static void Main(string[] args)
        {
            bool davom = true;

            while (davom)
            {
                Console.WriteLine("Qanday amal bajarishni xohlaysiz?");
                Console.WriteLine("1. Taom qo'shish");
                Console.WriteLine("2. Taomlarni ko'rish");
                Console.WriteLine("3. Taomlarni yangilash");
                Console.WriteLine("4. Taomni o'chirish");
                Console.WriteLine("5. Eng qimmat ovqat");
                Console.WriteLine("6. Eng ko'p buyurtma qilingan taom");
                Console.WriteLine("7. Eng kam buyurtma qilingan taom");
                Console.WriteLine("0. Dasturdan chiqish");
                Console.Write("Tanlang: ");

                int tanlov = Convert.ToInt32(Console.ReadLine());

                switch (tanlov)
                {
                    case 0:
                        davom = false;
                        break;
                    case 1:
                        TaomniQoshish();
                        break;
                    case 2:
                        TaomlarniKorish();
                        break;
                    case 3:
                        TaomlarniYangilash();
                        break;
                    case 4:
                        TaomniOchirish();
                        break;
                    case 5:
                        EngQimmatOvqat();
                        break;
                    case 6:
                        EngKopBuyurtma();
                        break;
                    case 7:
                        EngKamBuyurtma();
                        break;
                    default:
                        Console.WriteLine("Noto'g'ri tanlov!");
                        break;
                }

                Console.WriteLine();
            }
        }

        public static void TaomniQoshish()
        {
            Console.WriteLine("Taom nomini kiriting:");
            string nomi = Console.ReadLine();

            Console.WriteLine("Taom narxini kiriting:");
            double narxi = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Taom buyurtma sonini kiriting:");
            int buyurtmaSoni = Convert.ToInt32(Console.ReadLine());

            Taom taom = new Taom { Nomi = nomi, Narxi = narxi, BuyurtmaSoni = buyurtmaSoni };
            taomlar.Add(taom);
            StreamWriter streamWriter = new StreamWriter(path, true);
           {
                streamWriter.WriteLine($"Nomi: {nomi}, Narxi :{narxi}," +
                    $" Buyurtmalar Soni :{buyurtmaSoni}");
                Console.WriteLine();
                streamWriter.Close();
           }
           
            Console.WriteLine("Faylga Nusxa kochirildi !!!");

            Console.WriteLine("Taom muvaffaqiyatli qo'shildi!");
        }

        

        static void TaomlarniKorish()
        {
            Console.WriteLine("Taomlar ro'yxati:");

            foreach (Taom taom in taomlar)
            {
                Console.WriteLine($"Nomi: {taom.Nomi}, Narxi: {taom.Narxi}, Buyurtma soni: {taom.BuyurtmaSoni}");
            }
        }

        static void TaomlarniYangilash()
        {
            Console.WriteLine("Yangilash uchun taom nomini kiriting:");
            string nomi = Console.ReadLine();

            Taom taom = taomlar.Find(t => t.Nomi == nomi);

            if (taom != null)
            {
                Console.WriteLine("Yangi taom narxini kiriting:");
                double narxi = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Yangi taom buyurtma sonini kiriting:");
                int buyurtmaSoni = Convert.ToInt32(Console.ReadLine());

                taom.Narxi = narxi;
                taom.BuyurtmaSoni = buyurtmaSoni;

                Console.WriteLine("Taom muvaffaqiyatli yangilandi!");
            }
            else
            {
                Console.WriteLine("Taom topilmadi!");
            }
        }

        static void TaomniOchirish()
        {
            Console.WriteLine("O'chirish uchun taom nomini kiriting:");
            string nomi = Console.ReadLine();

            Taom taom = taomlar.Find(t => t.Nomi == nomi);

            if (taom != null)
            {
                taomlar.Remove(taom);
                Console.WriteLine("Taom muvaffaqiyatli o'chirildi!");
            }
            else
            {
                Console.WriteLine("Taom topilmadi!");
            }
        }

        static void EngQimmatOvqat()
        {
            double engQimmatNarx = 0;
            string engQimmatTaom = "";

            foreach (Taom taom in taomlar)
            {
                if (taom.Narxi > engQimmatNarx)
                {
                    engQimmatNarx = taom.Narxi;
                    engQimmatTaom = taom.Nomi;
                }
            }

            Console.WriteLine($"Eng qimmat taom: {engQimmatTaom}, Narxi: {engQimmatNarx}");
        }

        static void EngKopBuyurtma()
        {
            int engKopBuyurtmaSoni = 0;
            string engKopBuyurtmaTaom = "";

            foreach (Taom taom in taomlar)
            {
                if (taom.BuyurtmaSoni > engKopBuyurtmaSoni)
                {
                    engKopBuyurtmaSoni = taom.BuyurtmaSoni;
                    engKopBuyurtmaTaom = taom.Nomi;
                }
            }

            Console.WriteLine($"Eng ko'p buyurtma qilingan taom: {engKopBuyurtmaTaom}, Buyurtma soni: {engKopBuyurtmaSoni}");
        }

        static void EngKamBuyurtma()
        {
            int engKamBuyurtmaSoni = int.MaxValue;
            string engKamBuyurtmaTaom = "";

            foreach (Taom taom in taomlar)
            {
                if (taom.BuyurtmaSoni < engKamBuyurtmaSoni)
                {
                    engKamBuyurtmaSoni = taom.BuyurtmaSoni;
                    engKamBuyurtmaTaom = taom.Nomi;
                }
            }

            Console.WriteLine($"Eng kam buyurtma qilingan taom: {engKamBuyurtmaTaom}, Buyurtma soni: {engKamBuyurtmaSoni}");
        }
    }
}
