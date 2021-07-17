using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BMRapp.Fabryka;

namespace BMRapp
{
    /// <summary>
    /// Klasa subskrymt
    /// </summary>
    public class Subskrybent : ISubskrybent
    {
        /// <summary>
        /// Właściwość mail
        /// </summary>
        public string _email { get; set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="email"></param>
        public Subskrybent(string email)
        {
            _email = email;
        }

        /// <summary>
        /// Wykonanie metody subskrypcji dla danego maila
        /// </summary>
        /// <param name="wiadomosc"></param>
        public void wykonaj(string wiadomosc)
        {
            //Informacja o tym co się stanie w momencie rozesłania wiadomości
            MessageBox.Show($"Ten adres mailowy [{_email}] zostanie poinformowany! : {wiadomosc}");
            //MailMailing _mailing = new MailMailing(_email, wiadomosc);
            //_mailing.wyslij();
        }
    }
}
