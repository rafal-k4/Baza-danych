using System;
using System.Windows.Forms;


namespace ElectronicsLibrary
{
    public class Laptop : PC
    {
        //--------pola---------
        protected double ekran;

        //-------właściwości-----------
        public double przekatna_ekranu
        {
            get { return ekran; }
        }



        public Laptop(string marka, double cena_urzadzenia, double pobierana_moc, double ciezar, string system, double taktowanie_procesora, double przekatna_ekranu) : base(marka, cena_urzadzenia, pobierana_moc, ciezar, system, taktowanie_procesora)
        {
            ekran = przekatna_ekranu;
        }

        //---------metody--------- 
        public override void info_urzadzenia() //metoda przesłonięta
        {
            MessageBox.Show("Marka Laptopa: " + nazwa + Environment.NewLine + "System operacyjny: " + system_operacyjny + Environment.NewLine + "Wartość Laptopa: " + cena + " zł" +
                Environment.NewLine + "Waga Laptopa: " + waga + " kg" + Environment.NewLine +
                "Pobór mocy Laptopa: " + pobor_mocy + " W" + Environment.NewLine + "Waga Laptopa: " + waga + " kg" + Environment.NewLine
                + "Taktowanie Procesora: " + czestotliwosc_procesora + " GHz" + Environment.NewLine + "Przekątna Ekranu: " + ekran + " cala" + Environment.NewLine);
        }
    }

}
