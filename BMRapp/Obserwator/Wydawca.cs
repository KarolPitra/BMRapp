using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMRapp
{
    class Wydawca
    {
        //Lista do przetrzymywania subskrybentów
        private List<ISubskrybent> _subskrybent = new List<ISubskrybent>();

        //Metoda do zapisania się na listę subskrybentów
        public void dodajSubskrybenta(ISubskrybent subskrybent)
        {
            
            if (_subskrybent.Contains(subskrybent))
            {
                MessageBox.Show("ISNIEJE");
                return;
            }            
            _subskrybent.Add(subskrybent);
        }

        //Metoda do wypisania się na listę subskrybentów
        public void usunSubskrybenta(ISubskrybent subskrybent)
        {
            _subskrybent.Remove(subskrybent);
        }

        /// <summary>
        /// Główna metoda do mailingu z promocjami, dla każdego subskrybenta można wykonac odrębną metodę
        /// </summary>

        public void mailing(string wiadomosc)
        {
            foreach (ISubskrybent subskrybent in _subskrybent)
            {
                subskrybent.wykonaj(wiadomosc);
            }
        }

    }
}
