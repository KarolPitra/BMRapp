using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp
{
    /// <summary>
    /// Klasa odpowiadająca za twozenie instancje poleceń
    /// </summary>
    class Invoker : ICommand
    {
        private ICommand _wyliczKcl;
        private ICommand _zamowienie;

        /// <summary>
        /// Metoda inicjalizująca czynność Wyliczania kalorii
        /// </summary>
        /// <param name="command"></param>
        public void initWyliczKcl(ICommand command)
        {
            this._wyliczKcl = command;
        }

        /// <summary>
        /// Metoda inicjalizująca czynność składania zamówienia
        /// </summary>
        /// <param name="command"></param>
        public void initZamowinie(ICommand command)
        {
            this._zamowienie = command;
        }

        /// <summary>
        /// Metoda wykonująca poszczególne czynności
        /// </summary>
        public void wykonaj()
        {
            if (this._zamowienie is ICommand)
            {
                this._zamowienie.Execute();
            }

            if (this._wyliczKcl is ICommand)
            {
                this._wyliczKcl.Execute();
            }
        }
    }
}
