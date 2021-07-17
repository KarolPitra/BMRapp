using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp.Fabryka 
{
    public class MailMailing : Wysylka
    {
        private string _adresat;
        private string _tresc;
        public MailMailing(string adresat, string tresc)
        {
            this._adresat = adresat;
            this._tresc = tresc;
        }
        /// <summary>
        /// Metoda wysłania wiadomości do użytkownika
        /// </summary>
        public override void wyslij()
        {
            AkcjaWysylkowa mail = new AkcjaWysylkowa();
            mail.send6(adresat: _adresat
                , temat: "MAILING!"
                , tresc: _tresc);
        }

    }
}
