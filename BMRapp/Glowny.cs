using BMRapp.Builder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMRapp
{
    /// <summary>
    /// Główna klasa interfejsu aplikacji
    /// </summary>
    public partial class Glowny : Form
    {
        /// <summary>
        /// Deklaracja zmiennych oraz instancji klas
        /// </summary>
        Dieta dieta = new Dieta();
        Invoker invoker = new Invoker();
        Wydawca wydawca = new Wydawca();
        MailFabryka mailFaktory = new MailFabryka();
        public static string globalna;
        public static string _mail;
        public static string _koszt;
        ZamowinieBuilder builder = new ZamowinieBuilder();
        public static Zamowienie _zamowienie;

        /// <summary>
        /// Inicjalizacja komponentu głównego
        /// </summary>
        public Glowny()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Przycisk obliczania kcl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOblicz_Click(object sender, EventArgs e)
        {
            if (walidacja())
            {
                string waga = tbWaga.Text;
                string wiek = tbWiek.Text;
                string wzrost = tbWzrost.Text;
                bool plec = rbMezczyzna.Checked;
                int aktywnosc = cbxAktywnoscFizyczna.SelectedIndex;
                int planuje = cbxPlanuje.SelectedIndex;
                invoker.initWyliczKcl(new WyliczZapotrzebowanie(wiek, waga, wzrost, plec, aktywnosc, planuje));
                invoker.wykonaj();
                lbKcl.Text = globalna;
            }
        }

        /// <summary>
        /// Metoda walidacji wypełnienia niezbędnych pól do poprawnego wyliczenia zapotrzebowania kcl
        /// </summary>
        /// <returns></returns>
        private bool walidacja()
        {
            if (String.IsNullOrEmpty(tbWiek.Text))
            {
                MessageBox.Show("Nie podano wieku", "KOMUNIKAT", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            if (String.IsNullOrEmpty(tbWaga.Text))
            {
                MessageBox.Show("Nie podano wagi", "KOMUNIKAT", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            if (String.IsNullOrEmpty(tbWzrost.Text))
            {
                MessageBox.Show("Nie podano wzrostu", "KOMUNIKAT", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            if (cbxAktywnoscFizyczna.SelectedIndex < 0)
            {
                MessageBox.Show("Nie wybrano aktywności fizycznej", "KOMUNIKAT", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            if (cbxPlanuje.SelectedIndex < 0)
            {
                MessageBox.Show("Nie wybrano co chesz osiągnąć", "KOMUNIKAT", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Metoda aktualizująca wartość zamówienia
        /// </summary>
        /// <returns></returns>
        private double aktualnaKwota()
        {
            return Convert.ToDouble(lbKwota.Text.Replace(" PLN", ""));
        }

        /// <summary>
        /// Metoda dodawania do aktualnej wartości zaznaczonego posiłku
        /// </summary>
        /// <param name="cena"></param>
        private void dodaj(double cena)
        {
            double _wartosc = aktualnaKwota() + cena;
            lbKwota.Text = Convert.ToString(_wartosc) + " PLN";
        }

        /// <summary>
        /// Metoda odejmująca od wartości cenę odznaczonego posiłku
        /// </summary>
        /// <param name="cena"></param>
        private void odejmij(double cena)
        {
            double _wartosc = aktualnaKwota() - cena;
            lbKwota.Text = Convert.ToString(_wartosc) + " PLN";
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sniadanieI(object sender, EventArgs e)
        {
            var sniadanieI = new SniadanieIDekorator(dieta);
            if (checkBoxSniadanieI.Checked)
            {
                dodaj(sniadanieI.WyliczenieCeny());
                builder.addPosilek(new Posilek {
                    _cena = sniadanieI.WyliczenieCeny(),
                    _nazwa = checkBoxSniadanieI.Text,
                    _przepis = sniadanieI.przepis()
                });
            }
            else
            {
                odejmij(sniadanieI.WyliczenieCeny());
                builder.removePosilek(checkBoxSniadanieI.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sniadanieII(object sender, EventArgs e)
        {
            var sniadanieII = new SniadanieIIDekorator(dieta);
            if (checkBoxSniadanieII.Checked)
            {
                dodaj(sniadanieII.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = sniadanieII.WyliczenieCeny(),
                    _nazwa = checkBoxSniadanieII.Text,
                    _przepis = sniadanieII.przepis()
                });
            }
            else
            {
                odejmij(sniadanieII.WyliczenieCeny());
                builder.removePosilek(checkBoxSniadanieII.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sniadanieIII(object sender, EventArgs e)
        {
            var sniadanieIII = new SniadanieIIIDekorator(dieta);
            if (checkBoxSniadanieIII.Checked)
            {
                dodaj(sniadanieIII.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = sniadanieIII.WyliczenieCeny(),
                    _nazwa = checkBoxSniadanieIII.Text,
                    _przepis = sniadanieIII.przepis()
                });
            }
            else
            {
                odejmij(sniadanieIII.WyliczenieCeny());
                builder.removePosilek(checkBoxSniadanieIII.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sniadanieIV(object sender, EventArgs e)
        {
            var sniadanieIV = new SniadanieIIIDekorator(dieta);
            if (checkBoxSniadanieIV.Checked)
            {
                dodaj(sniadanieIV.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = sniadanieIV.WyliczenieCeny(),
                    _nazwa = checkBoxSniadanieIV.Text,
                    _przepis = sniadanieIV.przepis()
                });
            }
            else
            {
                odejmij(sniadanieIV.WyliczenieCeny());
                builder.removePosilek(checkBoxSniadanieIV.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obiadI(object sender, EventArgs e)
        {
            var obiadI = new ObiadIDekorator(dieta);
            if (checkBoxObiadI.Checked)
            {
                dodaj(obiadI.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = obiadI.WyliczenieCeny(),
                    _nazwa = checkBoxObiadI.Text,
                    _przepis = obiadI.przepis()
                });
            }
            else
            {
                odejmij(obiadI.WyliczenieCeny());
                builder.removePosilek(checkBoxObiadI.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obiadII(object sender, EventArgs e)
        {
            var obiadII = new ObiadIIDekorator(dieta);
            if (checkBoxObiadII.Checked)
            {
                dodaj(obiadII.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = obiadII.WyliczenieCeny(),
                    _nazwa = checkBoxObiadII.Text,
                    _przepis = obiadII.przepis()
                });
            }
            else
            {
                odejmij(obiadII.WyliczenieCeny());
                builder.removePosilek(checkBoxObiadII.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obiadIII(object sender, EventArgs e)
        {
            var obiadIII = new ObiadIIIDekorator(dieta);
            if (checkBoxObiadIII.Checked)
            {
                dodaj(obiadIII.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = obiadIII.WyliczenieCeny(),
                    _nazwa = checkBoxObiadIII.Text,
                    _przepis = obiadIII.przepis()
                });
            }
            else
            {
                odejmij(obiadIII.WyliczenieCeny());
                builder.removePosilek(checkBoxObiadIII.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void obiadIV(object sender, EventArgs e)
        {
            var obiadIV = new ObiadIVDekorator(dieta);
            if (checkBoxObiadIV.Checked)
            {
                dodaj(obiadIV.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = obiadIV.WyliczenieCeny(),
                    _nazwa = checkBoxObiadIV.Text,
                    _przepis = obiadIV.przepis()
                });
            }
            else
            {
                odejmij(obiadIV.WyliczenieCeny());
                builder.removePosilek(checkBoxObiadIV.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kolacjaI(object sender, EventArgs e)
        {
            var kolacjaI = new KolacjaIDekorator(dieta);
            if (checkBoxKolacjaI.Checked)
            {
                dodaj(kolacjaI.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = kolacjaI.WyliczenieCeny(),
                    _nazwa = checkBoxKolacjaI.Text,
                    _przepis = kolacjaI.przepis()
                });
            }
            else
            {
                odejmij(kolacjaI.WyliczenieCeny());
                builder.removePosilek(checkBoxKolacjaI.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kolacjaII(object sender, EventArgs e)
        {
            var kolacjaII = new KolacjaIIDekorator(dieta);
            if (checkBoxKolacjaII.Checked)
            {
                dodaj(kolacjaII.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = kolacjaII.WyliczenieCeny(),
                    _nazwa = checkBoxKolacjaII.Text,
                    _przepis = kolacjaII.przepis()
                });
            }
            else
            {
                odejmij(kolacjaII.WyliczenieCeny());
                builder.removePosilek(checkBoxKolacjaII.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kolacjaIII(object sender, EventArgs e)
        {
            var kolacjaIII = new KolacjaIIIDekorator(dieta);
            if (checkBoxKolacjaIII.Checked)
            {
                dodaj(kolacjaIII.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = kolacjaIII.WyliczenieCeny(),
                    _nazwa = checkBoxKolacjaIII.Text,
                    _przepis = kolacjaIII.przepis()
                });
            }
            else
            {
                odejmij(kolacjaIII.WyliczenieCeny());
                builder.removePosilek(checkBoxKolacjaIII.Text);
            }
        }

        /// <summary>
        /// Dekoracja posilku, zaznaczenie checkbox'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kolacjaIV(object sender, EventArgs e)
        {
            var kolacjaIV = new KolacjaIVDekorator(dieta);
            if (checkBoxKolacjaIV.Checked)
            {
                dodaj(kolacjaIV.WyliczenieCeny());
                builder.addPosilek(new Posilek
                {
                    _cena = kolacjaIV.WyliczenieCeny(),
                    _nazwa = checkBoxKolacjaIV.Text,
                    _przepis = kolacjaIV.przepis()
                });
            }
            else
            {
                odejmij(kolacjaIV.WyliczenieCeny());
                builder.removePosilek(checkBoxKolacjaIV.Text);
            }
        }

        private void btnZamawiam_Click(object sender, EventArgs e)
        {
            dodajSubskrybenta(sender, e);
            var mail = mailFaktory.Utworz(TypWysyłki._mailowa);
            _mail = tbAdresMailowy.Text;
            if (String.IsNullOrEmpty(_mail))
            {
                MessageBox.Show("Nie wypełniono pola adres mailowy", "KOMUNIKAT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            builder.setTytul("Dieta dla Ciebie!");
            builder.setNaglowek("Witaj!");
            builder.setPodsumowanie("Dziękujemy z askorzystanie z naszych usług!");
            _zamowienie = builder.build();
            _koszt = lbKwota.Text;
            mail.wyslij();
        }

        /// <summary>
        /// Metoda która zapisuje na listę subskrybentów osobą chcącą dostawac powiadominia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dodajSubskrybenta(object sender, EventArgs e)
        {

            var subskrybent = new Subskrybent(tbAdresMailowy.Text);
            
            if (cbNewstleter.Checked)
            {
                
                wydawca.dodajSubskrybenta(subskrybent);
            }
            else
            {
                wydawca.usunSubskrybenta(subskrybent);
            }

        }

        private void btMailing_Click(object sender, EventArgs e)
        {
            wydawca.mailing("Jakieś info");
            MessageBox.Show("Zakończono mailing");
        }

        public string _labelText
        {
            get
            {
                return this.lbKcl.Text;
            }
            set
            {
                this.lbKcl.Text = value;
            }
        }

        
        /*
public static bool operator ==(Subskrybent L, Subskrybent P)
{
   if(L._email == P._email)
   {
       return true;
   }
   else
   {
       return false;
   }
}
public static bool operator != (Subskrybent L, Subskrybent P)
{
   return !(L == P);
}
*/
    }
}
