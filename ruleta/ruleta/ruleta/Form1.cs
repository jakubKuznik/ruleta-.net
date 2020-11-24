using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ruleta
{
    public partial class Form1 : Form
    {
        float zustatek = 1000;     //zustatek 
        string Szustatek;       

        float vsadit = 1;              // kolik chce hrač vsadit 

        int kurz = 1;
        Random rnd = new Random();

        bool Bcervena = false;   // pokud padne cervena bude bool cervena true 
        bool Bcerna = false;
        bool Bzelena = false;

        public int r = 0;
        public int bl = 0;
        public int g = 0;

        int vylosovane;
        int X = 10;
        int Y;

        public Form1()          //inicializace 
        {
            InitializeComponent();

            Szustatek = zustatek.ToString();

            textBox1.Text = (Szustatek);

            X = this.pictureBox2.Location.X;
            Y = this.pictureBox2.Location.Y;
        }
        private void Form1_Load(object sender, EventArgs e) //věci co chci at se dějou neustále s
        {
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            vsadit = float.Parse(textBox2.Text);        //zjistime čislo vsadit z textboxu
            if (zustatek < vsadit)    //pokud vsadime vice nez je nas zustatek 
            {
                vsadit = 0;
                textBox2.Text = (vsadit.ToString());
            }
            zustatek = zustatek - vsadit;
/*
            for (int i = 0; i < 1000000; i++)
            {
                
                vylosovane = rnd.Next(0, 11);
                if ((vylosovane > 0) && (vylosovane % 2 == 1))  //cervena 
                {
                    r = r + 1;
                }
                else if ((vylosovane > 0) && (vylosovane % 2 == 0)) //pokud padne cerna 
                {
                    bl = bl + 1;
                }
                else  // zelena 
                {
                    g = g + 1;
                }

            }

            Debug.WriteLine(r.ToString());
            Debug.WriteLine(g.ToString());
            Debug.WriteLine(bl.ToString());
*/
            vylosovane = rnd.Next(0, 11);               //nahodně vygenerujeme číslo  
            Szustatek = zustatek.ToString();
            textBox1.Text = (Szustatek);
            textBox4.Text = ("0");   
            Debug.WriteLine(vylosovane);

            tam(12, 1100);        // pohyb prstu tam s rychlosti 12 
            zpet(8, 20);        // pohyb prstu zpět s rychlosti 8 

            // pohyb sipky pri danem cislu 
            if (vylosovane == 1)
            {
                tam(2, 50);
            }
            else if (vylosovane == 3)
            {
                tam(2, 250);
            }
            else if (vylosovane == 5)
            {
                tam(2, 450);
            }
            else if (vylosovane == 7)
            {
                tam(2, 650);
            }
            else if (vylosovane == 9)
            {
                tam(2, 850);
            }
            else if (vylosovane == 2)
            {
                tam(2, 150);
            }
            else if (vylosovane == 4)
            {
                tam(2, 350);
            }
            else if (vylosovane == 6)
            {
                tam(2, 550);
            }
            else if (vylosovane == 8)
            {
                tam(2, 750);
            }
            else if (vylosovane == 10)
            {
                tam(2, 950);
            }
            else if (vylosovane == 0)
            {
                tam(2, 1050);
            }

            if ((vylosovane > 0) && (vylosovane % 2 == 1))  //cervena 
            {
                richTextBox1.Text = (vylosovane.ToString() + "\n") + richTextBox1.Text;

                if (Bcervena == true) //pokud padne cervena a je vybrana cervena 
                {
                    zustatek = zustatek + (vsadit * kurz);
                    Szustatek = zustatek.ToString();
                    textBox1.Text = (zustatek.ToString());
                    textBox4.Text = (vsadit * kurz).ToString();
                }
                else //pokud padne cervena a je vybrana cerna nebo zelena 
                {
                    Szustatek = zustatek.ToString();
                    textBox1.Text = (zustatek.ToString());
                    textBox4.Text = ("0");
                }
            }
            else if ((vylosovane > 0) && (vylosovane % 2 == 0)) //pokud padne cerna 
            {
                richTextBox1.Text = (vylosovane.ToString() + "\n") + richTextBox1.Text;
                if (Bcerna == true) //pokud padne cerna  a je vybrana cerna 
                {
                    zustatek = zustatek + (vsadit * kurz);
                    Szustatek = zustatek.ToString();
                    textBox1.Text = (zustatek.ToString());
                    textBox4.Text = (vsadit * kurz).ToString();
                }
                else //pokud padne cerna  a je vybrana cervena nebo zelena  
                {
                    Szustatek = zustatek.ToString();
                    textBox1.Text = (zustatek.ToString());
                    textBox4.Text = ("0");

                }
            }
            else  // zelena 
            {
                richTextBox1.Text = (vylosovane.ToString() + "\n") + richTextBox1.Text;
                if (Bzelena == true) //pokud padne zelena   a je vybrana zelena  
                {
                    zustatek = zustatek + (vsadit * kurz);
                    Szustatek = zustatek.ToString();
                    textBox1.Text = (zustatek.ToString());
                    textBox4.Text = (vsadit * kurz).ToString();
                }
                else //pokud padne zelena a je vybrana cervena nebo cerna   
                {
                    Szustatek = zustatek.ToString();
                    textBox1.Text = (zustatek.ToString());
                    textBox4.Text = ("0");

                }
            }

        }

        // FUNKCE NA POHYB SIPKY 
        public void zpet(int speed, int size)         // funkce s parametrem speed určuje pohyb prstu zpět 
        {
            while (true)
            {
                int z = 1;
                z = z + 1;
                X = X - speed;
                this.pictureBox2.Location = new Point(X, Y);
                this.Refresh();
                if (z % 10 == 0)
                {
                    speed = speed - 1;
                }
                if (X <= size)
                {
                    break;
                }            
            }
        }
        public void tam(int speed, int size)  // funkce s parametrem speed určuje pohyb prstu tam 
        {
            while (true)
            {
                int z = 1;
                z = z + 1;
                X = X + speed;
                this.pictureBox2.Location = new Point(X, Y);
                this.Refresh();
                if (X >= size)
                {
                    break;
                }
                if (z % 10 == 0)
                {
                    speed = speed - 1;
                }               
            }
        } 
       private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Label2_Click(object sender, EventArgs e)
        {

        }
        private void Label3_Click(object sender, EventArgs e)
        {

        }
        private void TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
        }
        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void Cervena_Click(object sender, EventArgs e)  // cervena 
        {
            kurz = 2;
            textBox3.Text = (kurz.ToString());
            Bcervena = true;   // pokud padne cervena bude bool cervena true 
            Bcerna = false;
            Bzelena = false;


        }
        private void Cerna_Click(object sender, EventArgs e)    //cerna 
        {
            kurz = 2;
            textBox3.Text = (kurz.ToString());
            Bcervena = false;   // pokud padne cervena bude bool cervena true 
            Bcerna = true;
            Bzelena = false;

        }
        private void Zelena_Click(object sender, EventArgs e)   //zelena 
        {
            kurz = 10;
            textBox3.Text = (kurz.ToString());
            Bcervena = false;   // pokud padne cervena bude bool cervena true 
            Bcerna = false;
            Bzelena = true;

        }
        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void Label5_Click(object sender, EventArgs e)
        {

        }
        private void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
