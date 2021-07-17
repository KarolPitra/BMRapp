using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp
{
    /// <summary>
    /// Klasa odpowiadająca za dekorowanie posiłku
    /// </summary>
    public class KolacjaIDekorator : DietaDekorator
    {
        //Zmienna pakowania
        double _pakowanie = 2.00;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="posilek"></param>
        public KolacjaIDekorator(IDieta posilek) : base(posilek)
        {
        }

        /// <summary>
        /// Funkcja w które na te chwilę zwracam tylko cenę posiłku, lecz mogę tutaj dodawać odpowiednio cenę za np. pakowanie 
        /// </summary>
        /// <returns></returns>
        public override double WyliczenieCeny()
        {
            return base.WyliczenieCeny() + 12.50 + _pakowanie;
        }
        public string przepis()
        {
            return "\n   100g Produktu 1" +
                "\n   200g Produktu 2" +
                "\n   300g Produktu 3";
        }
    }
}
