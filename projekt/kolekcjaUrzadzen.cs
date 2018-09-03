using System;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;


namespace projekt
{
    //-------------------kolekcje--------------------

    class kolekcjaUrzadzen : ArrayList //gotowa klasa opisująca klasy
    {

        public bool WyswietlParametryUrzadzenia(int index, System.Windows.Forms.TextBox txtbox)
        {
            txtbox.Clear();
            if (this[index] is PC)
            {
                txtbox.AppendText("Marka: " + (this[index] as PC).marka.ToString()+ Environment.NewLine);
                txtbox.AppendText("System operacyjny: " + (this[index] as PC).system.ToString() + Environment.NewLine);
                txtbox.AppendText("Wartość: " + (this[index] as PC).cena_urzadzenia.ToString()+" zł" + Environment.NewLine);
                txtbox.AppendText("Pobór mocy: " + (this[index] as PC).moc.ToString() + " W" + Environment.NewLine);
                txtbox.AppendText("Waga: " + (this[index] as PC).ciezar.ToString() + " kg" + Environment.NewLine);
                txtbox.AppendText("Taktowanie Procesora: " + (this[index] as PC).czestotliwosc.ToString() + " GHz" + Environment.NewLine);
                
            }
            if (this[index] is Laptop)
            {
               
                txtbox.AppendText("Przekątna Ekranu: " + (this[index] as Laptop).przekatna_ekranu.ToString() + " cala" + Environment.NewLine);

            }


            if (this[index] is Smarfon)

            {
               
                txtbox.AppendText("Rozdzielczość aparatu: " + (this[index] as Smarfon).rozdzielczosc_aparatu.ToString() + " Mpx" + Environment.NewLine);

            }

            return true;

        }

        public void WyswietlListeUrzadzen(System.Windows.Forms.ListBox lstbox)
        {
            lstbox.Items.Clear();

            foreach(Elektronika x in this)
            {
                lstbox.Items.Add(x.marka);
            }

            
        }

        public void ZapiszDoExcela (int ilosc_urzadzen)

        {
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            Workbook wb = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet ws = (Worksheet)excel.ActiveSheet;

            excel.Visible = true;

            ws.Cells[1, 1] = "Cena";
            ws.Cells[1, 2] = "Pobór mocy";
            ws.Cells[1, 3] = "Nazwa";
            ws.Cells[1, 4] = "Waga";
            ws.Cells[1, 5] = "System operacyjny";
            ws.Cells[1, 6] = "Częstotliwość";
            ws.Cells[1, 7] = "Przekątna ekranu";
            ws.Cells[1, 8] = "Rozdzielczość aparatu";

            for (int i = 0; i <= ilosc_urzadzen; i++)
            {
                if (this[i] is PC)
                {
                    ws.Cells[(i + 2), 1] = (this[i] as PC).cena_urzadzenia;
                    ws.Cells[(i + 2), 2] = (this[i] as PC).moc;
                    ws.Cells[(i + 2), 3] = (this[i] as PC).marka;
                    ws.Cells[(i + 2), 4] = (this[i] as PC).ciezar;
                    ws.Cells[(i + 2), 5] = (this[i] as PC).system;
                    ws.Cells[(i + 2), 6] = (this[i] as PC).czestotliwosc;
                    //ws.Cells[(i + 2), 7] = "null";
                    //ws.Cells[(i + 2), 8] = "null";
                }
                if (this[i] is Laptop)
                {
                    ws.Cells[(i + 2), 1] = (this[i] as Laptop).cena_urzadzenia;
                    ws.Cells[(i + 2), 2] = (this[i] as Laptop).moc;
                    ws.Cells[(i + 2), 3] = (this[i] as Laptop).marka;
                    ws.Cells[(i + 2), 4] = (this[i] as Laptop).ciezar;
                    ws.Cells[(i + 2), 5] = (this[i] as Laptop).system;
                    ws.Cells[(i + 2), 6] = (this[i] as Laptop).czestotliwosc;
                    ws.Cells[(i + 2), 7] = (this[i] as Laptop).przekatna_ekranu;
                    //ws.Cells[(i + 2), 8] = "null";
                }

                if (this[i] is Smarfon)
                {
                    ws.Cells[(i + 2), 1] = (this[i] as Smarfon).cena_urzadzenia;
                    ws.Cells[(i + 2), 2] = (this[i] as Smarfon).moc;
                    ws.Cells[(i + 2), 3] = (this[i] as Smarfon).marka;
                    ws.Cells[(i + 2), 4] = (this[i] as Smarfon).ciezar;
                    ws.Cells[(i + 2), 5] = (this[i] as Smarfon).system;
                    ws.Cells[(i + 2), 6] = (this[i] as Smarfon).czestotliwosc;
                    ws.Cells[(i + 2), 7] = (this[i] as Smarfon).przekatna_ekranu;
                    ws.Cells[(i + 2), 8] = (this[i] as Smarfon).rozdzielczosc_aparatu;
                }
            }

            

        }


        public void ZapiszDoAccessa(int ilosc_urzadzen, string sciezka_dostepu)
        {
            try
            {
                OleDbConnection polaczenie = new OleDbConnection();
                //polaczenie.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rafal\Documents\Visual Studio 2015\Projects\projekt\BazaDanychDoProjektuZPOB.accdb;
                                         // Persist Security Info=False;";
                    polaczenie.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + sciezka_dostepu + @"  Persist Security Info=False;";

                polaczenie.Open();

                OleDbCommand polecenie = new OleDbCommand();
                polecenie.Connection = polaczenie;
                for (int i = 0; i <= ilosc_urzadzen; i++)
                {                    
                    if (this[i] is PC)
                    {
                        polecenie.CommandText = "insert into Urzadzenia (Nazwa_urządzenia, Cena, Pobierana_moc, Waga, Taktowanie_procesora) values ('"
                            + (this[i] as PC).marka.ToString() + "','" + (this[i] as PC).cena_urzadzenia + "','"
                            + (this[i] as PC).moc.ToString() + "','" + (this[i] as PC).ciezar.ToString() + "','"
                            + (this[i] as PC).czestotliwosc.ToString() + "')";
                        
                    }
                    if (this[i] is Laptop)
                    {
                        polecenie.CommandText = "insert into Urzadzenia (Nazwa_urządzenia, Cena, Pobierana_moc, Waga, Taktowanie_procesora,Przekątna_ekranu) values ('"
                           + (this[i] as Laptop).marka.ToString() + "','" + (this[i] as Laptop).cena_urzadzenia + "','"
                           + (this[i] as Laptop).moc.ToString() + "','" + (this[i] as Laptop).ciezar.ToString() + "','"
                           + (this[i] as Laptop).czestotliwosc.ToString() + "','" + (this[i] as Laptop).przekatna_ekranu.ToString() + "')";

                    }
                    if (this[i] is Smarfon)
                    {
                        polecenie.CommandText = "insert into Urzadzenia (Nazwa_urządzenia, Cena, Pobierana_moc, Waga, Taktowanie_procesora,Przekątna_ekranu,Rozdzielczość_aparatu) values ('"
                          + (this[i] as Smarfon).marka.ToString() + "','" + (this[i] as Smarfon).cena_urzadzenia + "','"
                          + (this[i] as Smarfon).moc.ToString() + "','" + (this[i] as Smarfon).ciezar.ToString() + "','"
                          + (this[i] as Smarfon).czestotliwosc.ToString() + "','" + (this[i] as Smarfon).przekatna_ekranu.ToString() + "','" + (this[i] as Smarfon).rozdzielczosc_aparatu.ToString() + "')";
                    }
                    polecenie.ExecuteNonQuery();

                }

                polaczenie.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas połączenia z bazą danych" + Environment.NewLine + ex);
            }

        }

        public void DodawanieDanychDoAccessaDoOsobnychTabel (int ilosc_urzadzen, string sciezka_dostepu)
        {
            try
            {
                OleDbConnection polaczenie = new OleDbConnection();
                polaczenie.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + sciezka_dostepu + @"  Persist Security Info=False;";

                polaczenie.Open();

                OleDbCommand polecenie = new OleDbCommand();
                polecenie.Connection = polaczenie;
                for (int i = 0; i <= ilosc_urzadzen; i++)
                {
                    if (this[i] is PC)
                    {
                        polecenie.CommandText = "insert into PC (Nazwa_urządzenia, Cena, Pobierana_moc, Waga, Taktowanie_procesora) values ('"
                            + (this[i] as PC).marka.ToString() + "','" + (this[i] as PC).cena_urzadzenia + "','"
                            + (this[i] as PC).moc.ToString() + "','" + (this[i] as PC).ciezar.ToString() + "','"
                            + (this[i] as PC).czestotliwosc.ToString() + "')";

                    }
                    if (this[i] is Laptop)
                    {
                        polecenie.CommandText = "insert into Laptopy (Nazwa_urządzenia, Cena, Pobierana_moc, Waga, Taktowanie_procesora,Przekątna_ekranu) values ('"
                           + (this[i] as Laptop).marka.ToString() + "','" + (this[i] as Laptop).cena_urzadzenia + "','"
                           + (this[i] as Laptop).moc.ToString() + "','" + (this[i] as Laptop).ciezar.ToString() + "','"
                           + (this[i] as Laptop).czestotliwosc.ToString() + "','" + (this[i] as Laptop).przekatna_ekranu.ToString() + "')";

                    }
                    if (this[i] is Smarfon)
                    {
                        polecenie.CommandText = "insert into Smartfony (Nazwa_urządzenia, Cena, Pobierana_moc, Waga, Taktowanie_procesora,Przekątna_ekranu,Rozdzielczość_aparatu) values ('"
                          + (this[i] as Smarfon).marka.ToString() + "','" + (this[i] as Smarfon).cena_urzadzenia + "','"
                          + (this[i] as Smarfon).moc.ToString() + "','" + (this[i] as Smarfon).ciezar.ToString() + "','"
                          + (this[i] as Smarfon).czestotliwosc.ToString() + "','" + (this[i] as Smarfon).przekatna_ekranu.ToString() + "','" + (this[i] as Smarfon).rozdzielczosc_aparatu.ToString() + "')";
                    }
                    polecenie.ExecuteNonQuery();

                }

                polaczenie.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas połączenia z bazą danych" + Environment.NewLine + ex);
            }


        }




    }

}
