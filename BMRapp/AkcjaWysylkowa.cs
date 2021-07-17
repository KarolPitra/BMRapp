using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace BMRapp
{
    public partial class AkcjaWysylkowa
    {

        public void send6(string adresat = "karas030489@gmail.com",
                          string nadawca = "szkolenie_techniczne2@wp.pl",
                          string temat = "Zamówienie",
                          string tresc = "Treść",
                          string serwer = "smtp.wp.pl",
                          string login = "szkolenie_techniczne2",
                          string haslo = "karas030489",
                          int port = /*465*/ 587)
        {
            MailAddress to = new MailAddress(adresat);
            MailAddress from = new MailAddress(nadawca);

            MailMessage message = new MailMessage(from, to);
            message.Subject = temat;
            message.Body = tresc;

            SmtpClient client = new SmtpClient(serwer, port)
            {
                Credentials = new NetworkCredential(login, haslo),
                EnableSsl = true
            };

            try
            {
                client.Send(message);
                MessageBox.Show("Wysłano zamówienie do " + adresat);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}