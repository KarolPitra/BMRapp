using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp
{
    /// <summary>
    /// Interfejs odpowiadający za przesyłanie komendy
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Metoda Execut czyli wykonanie odpowiedniej czynności
        /// </summary>
        void Execute();
    }
}
