using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MukorcsolyaGyakProject
{
    class Versenyzo
    {
        //Név;Ország;Technikai;Komponens;Levonás
        //Anne Line GJERSEM; NOR;25.3;21.69;0
        public string nev { get; set; }
        public string orszag { get; set; }
        public double technikai { get; set; }
        public double komponens { get; set; }
        public double levonas { get; set; }
        public double osszPontszam { get; set; }
        public Versenyzo(string nev, string orszag, double technikai, double komponens, double levonas)
        {
            this.nev = nev;
            this.orszag = orszag;
            this.technikai = technikai;
            this.komponens = komponens;
            this.levonas = levonas;
            osszPontszam = (technikai + komponens) - levonas;
        }
    }
}
