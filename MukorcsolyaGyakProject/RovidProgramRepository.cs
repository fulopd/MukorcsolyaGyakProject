using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukorcsolyaGyakProject
{
    class RovidProgramRepository
    {
        public List<Versenyzo> rovidProgramLista;

        public RovidProgramRepository()
        {
            rovidProgramLista = new List<Versenyzo>();
            Beolvas();
        }

        private void Beolvas() 
        {
            using (var sr = new StreamReader("Forras/rovidprogram.csv"))
            {
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var sor = sr.ReadLine().Split(';');

                    rovidProgramLista.Add(new Versenyzo(
                                                sor[0],
                                                sor[1],
                                                Convert.ToDouble(sor[2].Replace('.',',')),
                                                Convert.ToDouble(sor[3].Replace('.', ',')),
                                                Convert.ToDouble(sor[4].Replace('.', ','))
                                                ));
                }
            }
        }

        public int Count()
        {
            return rovidProgramLista.Count();
        }

        public double GetPontszamByName(string name)
        {
            var versenyzo = rovidProgramLista.Find(x => x.nev.Equals(name));
            if (versenyzo != null)
            {
                return (versenyzo.komponens + versenyzo.technikai) - versenyzo.levonas;
            }
            else
            {
                return 0;
            }
        }

        public bool VersenyzoLetezik(string name) 
        {
            return rovidProgramLista.Any(x => x.nev.Equals(name));
        }

    }
}
