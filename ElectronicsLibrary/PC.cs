using System;
using System.Windows.Forms;


namespace ElectronicsLibrary
{
    public class PC : Elektronika
    {
        //--------pola---------
        protected double czestotliwosc_procesora;

        //-------właściwości-----------
        public double czestotliwosc
        {
            get { return czestotliwosc_procesora; }
        }


        public PC()
        {
        }

        public PC(string marka, double cena_urzadzenia, double pobierana_moc, double ciezar, string system, double taktowanie_procesora) : base(marka, cena_urzadzenia, pobierana_moc, ciezar, system)
        {
            czestotliwosc_procesora = taktowanie_procesora;
        }
        //---------metody--------- 
        public override void info_urzadzenia()//metoda przesłonięta
        {
            MessageBox.Show("Marka Komputera Osobistego: " + nazwa + Environment.NewLine + "System operacyjny: " + system_operacyjny + Environment.NewLine + "Wartość Komputera Osobistego: " + cena + " zł" + Environment.NewLine +
                "Pobór mocy Komputera Osobistego: " + pobor_mocy + " W" + Environment.NewLine + "Waga Komputera Osobistego: " + waga + " kg" + Environment.NewLine
                + "Taktowanie Procesora: " + czestotliwosc_procesora + " GHz" + Environment.NewLine);


        }


    }

}
