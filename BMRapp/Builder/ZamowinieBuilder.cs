using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp.Builder
{
    public class ZamowinieBuilder
    {
        private Zamowienie _zamowienie = new Zamowienie();

        public Zamowienie build()
        {
            return _zamowienie;
        }
        public void setTytul(string tresc = "Dieta")
        {
            _zamowienie.tytul = tresc;
        }

        public void setNaglowek(string tresc = "Witaj!")
        {
            _zamowienie.naglowek = tresc;
        }

        public void setPodsumowanie(string tresc = "Pozdrawiam!")
        {
            _zamowienie.podsumowanie = tresc;
        }

        public void addPosilek(Posilek posilek)
        {
            _zamowienie.listaPosilkow.Add(posilek);
        }

        public void removePosilek(string nazwa)
        {
            _zamowienie.listaPosilkow.RemoveAll(x => x._nazwa == nazwa);
        }

    }
}
