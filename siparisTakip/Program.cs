using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace siparisTakip
{
    public delegate void SiparisIslemi(string mesaj);
    internal class Program
    {
        //sipariş işlemleri için metotlar
        public static void mutfagaBildirim(string mesaj)
        {
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine(mesaj);
            Console.ResetColor();
        }
        public static void musteriyeBildirim(string mesaj)
        {
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(mesaj);
            Console.ResetColor();
        }

        public static void kasayaBildirim(string mesaj)
        {
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(mesaj);
            Console.ResetColor();
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Sipariş Takip Sistemi");
            Console.WriteLine("1- Sipariş Oluştur");


            //Tekil Delegate Kullanımı

            Console.WriteLine("Tekil Delegate Kullanımı");
            SiparisIslemi tekilDelegate = mutfagaBildirim;
            tekilDelegate("Mutfakta sipariş oluşturuldu");

            //Çoklu Delegate Kullanımı

            Console.WriteLine("");
            Console.WriteLine("Çoklu Delegate Kullanımı");
            SiparisIslemi cokluDelegate = mutfagaBildirim;
            cokluDelegate += musteriyeBildirim;
            cokluDelegate += kasayaBildirim;
            cokluDelegate("Sipariş oluşturuldu");

            //Generic Delegate Kullanımı - Action

            Console.WriteLine("");
            Console.WriteLine("Generic Delegate Kullanımı");
            Action<string> actionOrnek = tesekkurMesajiGonder;
            tesekkurMesajiGonder("Teşekkürler, yine bekleriz");

            //Generic Delegate Kullanımı - Func
            Func<int, int, int> funcOrnek = siparisToplamHesapla;
            Console.WriteLine("Toplam: " + funcOrnek(100, 18));

            //Generic Delegate Kullanımı - Predicate
            Predicate<string> siparisHazirmi = siparisHazir;
            Console.WriteLine("Sipariş hazır mı: " + siparisHazirmi("Hazır"));

            //Anonim Delegate Kullanımı

            SiparisIslemi anonimDelegate = delegate (string mesaj)
            {
                Console.WriteLine("");
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(mesaj);
                Console.ResetColor();
            };

            anonimDelegate("Sipariş teslim ediliyor..");
        }

        static void tesekkurMesajiGonder(string mesaj)
        {
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.WriteLine(mesaj);
            Console.ResetColor();
        }

        static int siparisToplamHesapla(int tutar, int kdv)
        {
            return tutar + kdv;
        }

        static bool siparisHazir(string durum)
        {
            if (durum == "Hazır")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
