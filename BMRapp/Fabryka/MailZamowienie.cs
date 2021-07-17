using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMRapp.Builder;

namespace BMRapp
{
    /// <summary>
    /// Klasa odpowiadająca za wysłanie wiadomości
    /// </summary>
    class MailZamowienie : Wysylka
    {
        
        /// <summary>
        /// Metoda wysłania wiadomości do użytkownika
        /// </summary>
        public override void wyslij()
        {
            
            var _zamowienie = Glowny._zamowienie;
            var _posilek = new Posilek();
            var _tresc = "";
            AkcjaWysylkowa mail = new AkcjaWysylkowa();
            _tresc += _zamowienie.naglowek;
            _tresc += "\n" +
                "\nLista posiłków: ";
            foreach (object obj in _zamowienie.listaPosilkow)
            {
                _posilek = (Posilek)obj;
                _tresc += $"\n" +
                    $"\nNazwa posiłku: {_posilek._nazwa}" +
                    $"\nCena: {_posilek._cena}" +
                    $"\nSposób przyżadzenia: {_posilek._przepis}";
            }
            _tresc += $"\n" +
                $"\n" +
                $"Całkowity koszt: {Glowny._koszt}" +
                $"\n" +
                $"\n{_zamowienie.podsumowanie}";
            mail.send6(adresat: Glowny._mail
                ,temat: _zamowienie.tytul
                ,tresc: _tresc);
        }

        
    }
}
