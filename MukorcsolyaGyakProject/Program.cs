using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MukorcsolyaGyakProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. fealadat
            RovidProgramRepository rovidRepo = new RovidProgramRepository();
            DontoRepository dontoRepo = new DontoRepository();
           
            //2. feladat
            Console.WriteLine("2. feladat\n\tA rövid programban {0} induló volt", rovidRepo.Count());

            //3. feladat
            Console.WriteLine("3. feladt");
            if (dontoRepo.MagyarVersenyzo())
            {
                Console.WriteLine("\tMagyar versenyző bejutott a kűrbe");
            }
            else
            {
                Console.WriteLine("\tMagyar versenyző nem jutott be a kűrbe");
            }

            //5. feladat:
            Console.WriteLine("5. feladat");
            string name = "";
            do
            {
                Console.Write("\tKérem a versenyző nevét: ");
                name = Console.ReadLine();
            } while (!rovidRepo.VersenyzoLetezik(name));

            //6. feladat
            Console.WriteLine("6. feladat");
            double OsszPontszam = rovidRepo.GetPontszamByName(name) + dontoRepo.GetPontszamByName(name);
            Console.WriteLine("\tA versenyző összpontszáma: " + OsszPontszam);

            //7. feladat
            Console.WriteLine("7. feladat");
            dontoRepo.OrszagStatisztika();

            //8. feladat
            List<Versenyzo> osszes = dontoRepo.dontoLista.Concat(rovidRepo.rovidProgramLista).ToList();

            var adatok = osszes.GroupBy(x => x.nev).Select(
                                                            g => new
                                                            {
                                                                Key = g.Key,
                                                                Osszpont = g.Sum(y => y.osszPontszam),   
                                                                Orszag = g.First().orszag
                                                            }).OrderByDescending(x => x.Osszpont).ToList();


            using (var sw = new StreamWriter("vegeredmeny.csv",false,Encoding.UTF8))
            {
                int helyezes = 0;
                foreach (var item in adatok)
                {
                    sw.WriteLine(++helyezes + ";" + item.Key + ";" + item.Orszag + ";" + item.Osszpont);
                }
            }
            

            Console.ReadKey();

            
        }
        
    }
}
