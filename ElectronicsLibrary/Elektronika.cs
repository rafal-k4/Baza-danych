using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ElectronicsLibrary
{

    /*
     * 
     * Stworzona klasa pozwala na tworzenie obiektów elektronicznych, którymi są komputery osobiste, laptopy, smartfony. Dzięki zachowaniu podstawowych paradygmatów progrowamowania,
     * którymi są dziedzieczenie, hermetyzacja, polimorfizm projekt może zostać z łatwością rozbudowany o kolejne klasy dziedziczące, zawierające i zachowujące pola i konstruktory
     * klasy bazowej. 
     * 
     */



    public class Elektronika
    {
        protected double cena;
        protected double pobor_mocy;
        protected string nazwa;
        protected double waga;
        protected string system_operacyjny;



        //----------wlasciwosci------------


        public double cena_urzadzenia
        {
            set { cena = value; }
            get { return cena; }
        }
        public double moc
        {
            set { pobor_mocy = value; }
            get { return pobor_mocy; }
        }

        public string marka
        {
            get { return nazwa; }
        }
        public double ciezar
        {
            get { return waga; }
        }

        public string system
        {
            get { return system_operacyjny; }
        }



        //------------konstruktory----------
        public Elektronika()
        { }

        // kontruktor przeciazeniowy
        public Elektronika(string marka, double cena_urzadzenia, double pobierana_moc, double ciezar, string system)
        {
            nazwa = marka;
            cena = cena_urzadzenia;
            pobor_mocy = pobierana_moc;
            waga = ciezar;
            system_operacyjny = system;

        }
        //----------metody--------



        public void tryb_oszczedzania_energii()
        {
            pobor_mocy = 0.7 * pobor_mocy;
        }



        //-------metoda polimorficzna---------
        public virtual void info_urzadzenia()
        {
            MessageBox.Show("Marka urządzenia: " + nazwa + Environment.NewLine + "System operacyjny: " + system_operacyjny + Environment.NewLine + "Wartość urządzenia: " + cena + " zł" + Environment.NewLine + "Waga urządzenia: " + waga + " kg" + Environment.NewLine);
        }


    }

}
