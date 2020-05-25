using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukorcsolyaGyakProject
{
    class DontoRepository
    {

        public List<Versenyzo> dontoLista;

        public DontoRepository()
        {
            dontoLista = new List<Versenyzo>();
            Beolvas();
        }

        private void Beolvas()
        {
            using (var sr = new StreamReader("forras/donto.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(';');

                    dontoLista.Add(new Versenyzo(
                                                sor[0],
                                                sor[1],
                                                Convert.ToDouble(sor[2].Replace('.', ',')),
                                                Convert.ToDouble(sor[3].Replace('.', ',')),
                                                Convert.ToDouble(sor[4].Replace('.', ','))
                                                ));
                }
            }
        }

        public bool MagyarVersenyzo() 
        {
            return dontoLista.Any(x => x.orszag.Equals("HUN"));
        }

        public double GetPontszamByName(string name)
        {
            
            var versenyzo = dontoLista.SingleOrDefault(x => x.nev.Equals(name));
            if (versenyzo != null)
            {
                return (versenyzo.komponens + versenyzo.technikai) - versenyzo.levonas;
            }
            else
            {
                return 0;
            }
            
        }

        public void OrszagStatisztika()
        {
            var orszag = dontoLista.GroupBy(x => x.orszag).Where(x => x.Count() > 1).ToList();
            orszag.ForEach(x => Console.WriteLine("\t" + x.Key + ": " + x.Count() + " versenyző"));
        }
    }
}
