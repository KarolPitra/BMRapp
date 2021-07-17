using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp.Builder
{
    public class Zamowienie
    {
        public string tytul { get; set; }
        public string naglowek { get; set; }
        
        public List<Posilek> listaPosilkow = new List<Posilek>();
        public string podsumowanie { get; set; }


    }
}
