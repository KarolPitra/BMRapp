using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMRapp
{
    /// <summary>
    /// Klasa odpowiadająca za dekorowanie
    /// </summary>
    public abstract class DietaDekorator : IDieta
    {
        /// <summary>
        /// Zmienna prywatna jako instancja interfejsu
        /// </summary>
        private IDieta _dieta;

        /// <summary>
        /// Konstruktor 
        /// </summary>
        /// <param name="posilek"></param>
        protected DietaDekorator(IDieta posilek)
        {
            this._dieta = posilek;
        }

        /// <summary>
        /// Metoda zwracająca cenę aktualną diety
        /// </summary>
        /// <returns></returns>
        public virtual double WyliczenieCeny()
        {
            return _dieta.WyliczenieCeny();
        }

    }
}
