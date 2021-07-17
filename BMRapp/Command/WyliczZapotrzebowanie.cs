using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace BMRapp
{
    /// <summary>
    /// Klasa odpowiedzialna za wyliczeie zapotrzebowania kalorycznego
    /// </summary>
    class WyliczZapotrzebowanie : ICommand
    {
        private double _wiek = 0;
        private double _waga = 0;
        private double _wzrost = 0;
        private bool _mezczyzna = true;
        private int _aktywnosc = -1;
        private int _cel = -1;
        private double _BMR;

        /// <summary>
        /// Konstruktor klasy
        /// </summary>
        /// <param name="wiek"></param>
        /// <param name="waga"></param>
        /// <param name="wzrost"></param>
        /// <param name="plec"></param>
        /// <param name="aktywnosc"></param>
        /// <param name="cel"></param>
        public WyliczZapotrzebowanie(string wiek, string waga, string wzrost, bool plec, int aktywnosc, int cel)
        {
            this._wiek = Convert.ToDouble(wiek);
            this._waga = Convert.ToDouble(waga);
            this._wzrost = Convert.ToDouble(wzrost);
            this._mezczyzna = plec;
            this._aktywnosc = aktywnosc;
            this._cel = cel;
        }

        /// <summary>
        /// ///Metoda wyliczająca zapotrzebowanie kaloryczne
        /// </summary>
        /// Dla kobiet: BMR = 655 + (9,6 × waga w kg) + (1,8 × wysokość w cm) - (4,7 × wiek w latach),
        /// Dla mężczyzn: BMR = 66 + (13,7 × waga w kg) + (5 × wysokość w cm) - (6,8 × wiek w latach).
        public void Execute()
        {
            if (this._mezczyzna)
            {
                this._BMR = 66.00 + (13.70 * this._waga) + (5 * this._wzrost) - (6.80 * this._wiek);
            }
            else
            {
                this._BMR = 665.00 + (9.60 * this._waga) + (1.80 * this._wzrost) - (4.70 * this._wiek);
            }
            //W zależności od aktywności fizycznej wybranej w combobox w interfejsie głównym, mnoże BMR razy wskaźnik
            switch (this._aktywnosc)
            {
                case 0:
                    _BMR = _BMR * 1.20;
                    break;
                case 1:
                    _BMR = _BMR * 1.375;
                    break;
                case 2:
                    _BMR = _BMR * 1.725;
                    break;
                case 3:
                    _BMR = _BMR * 1.9;
                    break;
                case 4:
                    _BMR = _BMR * 2.0;
                    break;
                default:
                    break;
            }
            //W zależności od celu odejmuję, dodaję lub pozostawiem zapotrzebowanie bez zmian
            switch (this._cel)
            {
                //Jeżeli schudnąć odejmuję 500kcl
                case 0:
                    _BMR = _BMR - 500;
                    break;
                //Jeżeli chce przytyć dodaję 500kcl
                case 2:
                    _BMR = _BMR + 500;
                    break;
                default:
                    break;
            }
            //Przypisuje do zmiennej globalnej wyliczony wynik
            Glowny.globalna = Convert.ToString(_BMR) + "kcl";

            //Glowny.ustawLabelKcl(Convert.ToString(_BMR) + "kcl");
        }

        
    }
}
