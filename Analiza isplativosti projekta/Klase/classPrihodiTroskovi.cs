using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analiza_isplativosti_projekta.Klase
{
    class classPrihodiTroskovi
    {
        public string name { get; set; }
        public int year { get; set; }
        public int years_in_progress { get; set; }
        public int povecanje_zarade { get; set; }
        public int smanjenje_troskova{ get; set; }
        public int troskovi_rada { get; set; }
        public int troskovi_razvoja { get; set; }
        public int ukupni_prihodi { get; set; }
        public int ukupni_troskovi{ get; set; }
    }
}
