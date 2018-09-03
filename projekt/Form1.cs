using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using ElectronicLibrary;







namespace projekt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        kolekcjaUrzadzen listaUrzadzen = new kolekcjaUrzadzen();

        //-----------------------------------------sciezka dostepu do bazy danych--------------------------------------------------
        string sciezka_dostepu = new PathForDataBase().Path;

        //string sciezka_dostepu = @"Data Source=C:\Users\Rafal\Documents\Visual Studio 2015\Projects\projekt\BazaDanychDoProjektuZPOB.accdb;";



        private void button1_Click(object sender, EventArgs e)
        {



            PC pecet = new PC(Convert.ToString(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text),
                Convert.ToDouble(textBox4.Text), comboBox2.SelectedItem.ToString(), Convert.ToDouble(textBox5.Text));

            if (comboBox1.Text == "Tak")
            {
                pecet.tryb_oszczedzania_energii();
            }
            listaUrzadzen.Add(pecet);
            listaUrzadzen.WyswietlListeUrzadzen(listBox1);
            listaUrzadzen.WyswietlParametryUrzadzenia(listaUrzadzen.Count - 1, textBox8);




        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Laptop lap = new Laptop(Convert.ToString(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text), Convert.ToDouble(textBox4.Text),
                comboBox2.SelectedItem.ToString(), Convert.ToDouble(textBox5.Text), Convert.ToDouble(textBox6.Text));

            if (comboBox1.Text == "Tak")
            {
                lap.tryb_oszczedzania_energii();
            }
            listaUrzadzen.Add(lap);
            listaUrzadzen.WyswietlListeUrzadzen(listBox1);
            listaUrzadzen.WyswietlParametryUrzadzenia(listaUrzadzen.Count - 1, textBox8);

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Smarfon telefon = new Smarfon(Convert.ToString(textBox1.Text), Convert.ToDouble(textBox2.Text), Convert.ToDouble(textBox3.Text),
                Convert.ToDouble(textBox4.Text), comboBox2.SelectedItem.ToString(), Convert.ToDouble(textBox5.Text),
                Convert.ToDouble(textBox6.Text), Convert.ToDouble(textBox7.Text));

            if (comboBox1.Text == "Tak")
            {
                telefon.tryb_oszczedzania_energii();
            }
            listaUrzadzen.Add(telefon);
            listaUrzadzen.WyswietlListeUrzadzen(listBox1);
            listaUrzadzen.WyswietlParametryUrzadzenia(listaUrzadzen.Count - 1, textBox8);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listaUrzadzen.WyswietlParametryUrzadzenia(listBox1.SelectedIndex, textBox9);
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void usuńToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            listaUrzadzen.ZapiszDoExcela(listaUrzadzen.Count - 1);

        }

        private void button5_Click(object sender, EventArgs e)
        {

            listaUrzadzen.ZapiszDoAccessa(listaUrzadzen.Count - 1, sciezka_dostepu);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listaUrzadzen.DodawanieDanychDoAccessaDoOsobnychTabel(listaUrzadzen.Count - 1, sciezka_dostepu);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            { }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            { }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            { }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            { }
            else
            {
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == ',')
            { }
            else
            {
                //e.Handled = true;
                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}