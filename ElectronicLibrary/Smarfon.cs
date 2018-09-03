using System;
using System.Windows.Forms;


namespace ElectronicLibrary
{
    public class Smarfon : Laptop
    {
        //--------pola---------
        protected double aparat;

        //-------właściwości-----------
        public double rozdzielczosc_aparatu
        {
            get { return aparat; }
        }




        public Smarfon(string marka, double cena_urzadzenia, double pobierana_moc, double ciezar, string system, double taktowanie_procesora, double przekatna_ekranu, double rozdzielczosc_aparatu) : base(marka, cena_urzadzenia, pobierana_moc, ciezar, system, taktowanie_procesora, przekatna_ekranu)
        {
            aparat = rozdzielczosc_aparatu;
        }
        //---------metody--------- 
        public override void info_urzadzenia()//metoda przesłonięta
        {
            MessageBox.Show("Marka Smartfona: " + nazwa + Environment.NewLine + "System operacyjny: " + system_operacyjny + Environment.NewLine + "Wartość Smartfona: " + cena + " zł" + Environment.NewLine +
                  "Pobór mocy Smartfona: " + pobor_mocy + " W" + Environment.NewLine + "Waga Smartfona: " + waga + " kg" + Environment.NewLine
                  + "Taktowanie Procesora: " + czestotliwosc_procesora + " GHz" + Environment.NewLine + "Przekątna Ekranu: " + ekran + " cala" + Environment.NewLine
                  + "Rozdzielczość aparatu: " + aparat + " Mpx");
        }

    }

}
