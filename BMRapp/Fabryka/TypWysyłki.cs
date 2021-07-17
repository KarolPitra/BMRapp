using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp
{
    /// <summary>
    /// Deklaracja typów tworzonych obiektów przez metode fabrykującą
    /// </summary>
    enum TypWysyłki
    {
        /// <summary>
        /// Typy jakie można tworzyć za pomocą naszej fabryki
        /// </summary>
        _mailowa,
        _sms,
        _portalSpolecznosciowy,
        _mailing
    }
}
