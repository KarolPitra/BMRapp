using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp
{
    /// <summary>
    /// Klasa tworząca obiekty
    /// </summary>
    class MailFabryka
    {
        /// <summary>
        /// Metoda do tworzenia obiektów poszczególnych klas
        /// </summary>
        /// <param name="typ"></param>
        /// <returns></returns>
        public Wysylka Utworz(TypWysyłki typ)
        {
            switch (typ)
            {
                case TypWysyłki._mailowa:
                    return new MailZamowienie();                    
                case TypWysyłki._sms:
                    throw new Exception($"Typ: {typ} nie jest obsługiwany");                    
                case TypWysyłki._portalSpolecznosciowy:
                    throw new Exception($"Typ: {typ} nie jest obsługiwany");
                case TypWysyłki._mailing:
                    return new MailZamowienie();
                default:
                    throw new Exception($"Typ: {typ} nie jest obsługiwany");
                    
            }
        }
    }
}
