using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp
{
    /// <summary>
    /// Główna klasa od której rozpoczynam dekorowanie posiłków
    /// </summary>
    class Dieta : IDieta
    {
        /// <summary>
        /// Bazowa cena diety, jeżeli ulegnie zmianie i będę naliczał dodatkowe koszty (nie wiem na te chwilę jakie) 
        /// to ta funkcja odpowiada za zamieszanie tego typu informacji
        /// </summary>
        /// <returns></returns>
        public double WyliczenieCeny()
        {
            return 0;
        }

    }
}
