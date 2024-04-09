using Melygarazs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Melygarazs
{
    internal class Program
    {
        static MelygarazsAdatbazis adatbazis;
        static Random vszg = new Random();
        static int[] valtozatok = new int[3];
        static void Main(string[] args)
        {
            adatbazis = new MelygarazsAdatbazis();
            adatbazis.Database.EnsureCreated();
            Console.Clear();
            string cim = "Parkolóház szimuláció";
            int poz = Console.WindowWidth-cim.Length/2;
            Console.SetCursorPosition(poz, 5);
            
            Console.WriteLine(cim);
            while (true)
            {
                string rendszam = VeletlenRendszam();
                //Ha a kapott rendszám nem szerepel a z autók táblában, akkor nem kell módosítani a változatok értékét, ha viszont szerepelne, akkor -- volna benne szükséges
                Auto auto = new Auto();
                auto.Rendszam = rendszam;
                adatbazis.autok.Add(auto);
                adatbazis.SaveChanges();
                //Console.WriteLine(rendszam); //itt tehetnénk be a rendszámot az autók táblába
                Console.ReadKey(true);
            }
        }
        static string VeletlenRendszam()
        {
            /* Mindaddig, míg nincs 170-170 darab mindhárom rendszámfajtából, tényleg véletlenszerű, miután megvan összességében az 510 db autónk, 
              azok rendszámai közül választunk már véletlenszerűen */
            string rendszam = "";
            //Melyik változat
            //int melyik = (new Random()).Next(1, 3); 
             
            int melyik = vszg.Next(1, 4);
            valtozatok[melyik - 1]++; //hogy melyik változatról van szó, annak megfelelően növeljük a darabszámot
            switch (melyik)
            {
                case 1:
                    rendszam = Valtozat1();
                    break;
                case 2:
                    rendszam = Valtozat2();
                    break;
                case 3:
                    rendszam = Valtozat3();
                    break;
            }
            var lista = adatbazis.autok.ToList();
            foreach (var elem in lista) 
            {
                if (elem.Rendszam == rendszam)
                {
                    // van már ilyen
                    valtozatok[melyik - 1]--;
                }
            }
            return rendszam;
        }
            static string Valtozat1()
            {
                return "AB 12-34";
            }
            static string Valtozat2()
            {
                return "ABC 123";
            }
            static string Valtozat3()
            {
                return "AB-CD 123";
            }
        
    }
}
