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
        int balance = 1000;     //balance  
        int bet = 1;            // how much money will u bet 
        int win = 0;
        
        //every color and number has it own number 
        int iblack = 0;     //intiger for black color 
        int ired = 0;       //initiger for red color 
        int igreen = 0;

        // intigers for every number 
        int num_one = 0;
        int num_two = 0;
        int num_three = 0;
        int num_four = 0;
        int num_five = 0;
        int num_six = 0;
        int num_seven = 0;
        int num_eight = 0;
        int num_nine = 0;
        int num_ten = 0;

        // zde máme klik a kurz 
        int click = 1;   //after click on chip this value´ll change 
        
        Random rnd = new Random(); //this is function that need to be defined for random number creation 


        //if some color will be choosen the bool will change to TRUE 
        bool Bcervena = false;  
        bool Bcerna = false;
        bool Bzelena = false;

        //vylosovane cislo 
        int choosen_number;
        // souradnice ukazatele 
        int X = 10;
        int Y;

        public Form1()          //inicializace 
        {
            InitializeComponent();
            X = this.pictureBox2.Location.X;
            Y = this.pictureBox2.Location.Y;
            textBox1.Text = (balance.ToString());
            textBox4.Text = (win.ToString());


        }
        private void Form1_Load(object sender, EventArgs e) //věci co chci at se dějou neustále s
        {
        }
        private void Button1_Click(object sender, EventArgs e)  //if the button start is clicked 
        {
            
            bet = iblack + ired + igreen + num_one + num_two + num_three + num_four + num_five + num_six + num_seven + num_eight + num_nine + num_ten;

            //vsadit = float.Parse(textBox2.Text);        //zjistime čislo vsadit z textboxu
            if (balance < bet)    //pokud vsadime vice nez je nas zustatek 
            {
                bet = 0;
            }
         
            balance = balance - bet;
            choosen_number = rnd.Next(0, 11);               //nahodně vygenerujeme číslo  

            textBox4.Text = ("0");   
            Debug.WriteLine(choosen_number);

            tam(12, 1100);        // pohyb prstu tam s rychlosti 12 
            zpet(8, 20);        // pohyb prstu zpět s rychlosti 8 

            switch (choosen_number)
            {
                case 1:
                    win = win + (num_one * 10);
                    tam(2, 50);
                    break;
                case 2:
                    win = win + (num_two * 10);
                    tam(2, 150);
                    break;
                case 3:
                    win = win + (num_three * 10);
                    tam(2, 250);
                    break;
                case 4:
                    win = win + (num_four * 10);
                    tam(2, 350);
                    break;
                case 5:
                    win = win + (num_five * 10);
                    tam(2, 450);
                    break;
                case 6:
                    win = win + (num_six * 10);
                    tam(2, 550);
                    break;
                case 7:
                    win = win + (num_seven * 10);
                    tam(2, 650);
                    break;
                case 8:
                    win = win + (num_eight * 10);
                    tam(2, 750);
                    break;
                case 9:
                    win = win + (num_nine * 10);
                    tam(2, 850);
                    break;
                case 10:
                    win = win + (num_ten * 10);
                    tam(2, 950);
                    break;
                case 11:
                    tam(2, 1050);
                    break;
                default:
                    break;
            } //how the pointer should move for given number 

            if ((choosen_number > 0) && (choosen_number % 2 == 1))  //cervena 
            {
                richTextBox1.Text = (choosen_number.ToString() + "\n") + richTextBox1.Text;
                win = win + (ired * 2);
            }
            else if ((choosen_number > 0) && (choosen_number % 2 == 0)) //pokud padne cerna 
            {
                richTextBox1.Text = (choosen_number.ToString() + "\n") + richTextBox1.Text;
                win = win + (iblack * 2);
            }
            else  // zelena 
            {
                richTextBox1.Text = (choosen_number.ToString() + "\n") + richTextBox1.Text;
                win = win + (igreen * 10);
            }
            balance = balance + win;
            textBox4.Text = (win.ToString());
            textBox1.Text = (balance.ToString());

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
        private void Cervena_Click(object sender, EventArgs e)  // cervena 
        {
            ired = ired + click;
            textBox1.Text = (balance.ToString());
            textBox17.Text = (ired.ToString());
        }
        private void Cerna_Click(object sender, EventArgs e)    //cerna 
        {
            iblack = iblack + click;
            textBox11.Text = (iblack.ToString());

        }
        private void Zelena_Click(object sender, EventArgs e)   //zelena 
        {
            igreen = igreen + click;
            textBox18.Text = (igreen.ToString());
        }
        //modrý žeton 
        private void PictureBox3_Click(object sender, EventArgs e)
        {
            click = 1;
            pictureBox3.Size = new System.Drawing.Size(25, 25);
            pictureBox4.Size = new System.Drawing.Size(40, 40);
            pictureBox5.Size = new System.Drawing.Size(40, 40);
            pictureBox6.Size = new System.Drawing.Size(40, 40);

        }
        //červený žeton 
        private void PictureBox4_Click(object sender, EventArgs e)
        {
            click = 2;
            pictureBox3.Size = new System.Drawing.Size(40, 40);
            pictureBox4.Size = new System.Drawing.Size(25, 25);
            pictureBox5.Size = new System.Drawing.Size(40, 40);
            pictureBox6.Size = new System.Drawing.Size(40, 40);
        }
        // zelený žeton 
        private void PictureBox5_Click(object sender, EventArgs e)
        {
            click = 5;
            pictureBox3.Size = new Size(40, 40);
            pictureBox4.Size = new Size(40, 40);
            pictureBox5.Size = new System.Drawing.Size(25, 25);
            pictureBox6.Size = new System.Drawing.Size(40, 40);
        }
        // černý žeton 
        private void PictureBox6_Click(object sender, EventArgs e)
        {
            click = 10;
            pictureBox3.Size = new System.Drawing.Size(40, 40);
            pictureBox4.Size = new System.Drawing.Size(40, 40);
            pictureBox5.Size = new System.Drawing.Size(40, 40);
            pictureBox6.Size = new System.Drawing.Size(25, 25);
        }

        private void TextBox11_TextChanged(object sender, EventArgs e) //cerny textbox
        {

        }
        private void TextBox17_TextChanged(object sender, EventArgs e)  //cerveny textbox
        {

        }
        private void TextBox18_TextChanged(object sender, EventArgs e) //zeleny textbox
        {

        }
        private void TextBox5_TextChanged_1(object sender, EventArgs e) //jedna  
        {

        }
        private void TextBox6_TextChanged(object sender, EventArgs e)  //dva  
        {

        }
        private void TextBox8_TextChanged(object sender, EventArgs e) //tri
        {

        }
        private void TextBox7_TextChanged(object sender, EventArgs e) // ctyri
        {

        }
        private void TextBox10_TextChanged(object sender, EventArgs e) //pet 
        {

        }
        private void TextBox9_TextChanged(object sender, EventArgs e) //sest 
        {

        }
        private void TextBox16_TextChanged(object sender, EventArgs e) //sedm
        {

        }
        private void TextBox15_TextChanged(object sender, EventArgs e) //osm 
        {

        }
        private void TextBox14_TextChanged(object sender, EventArgs e) //devet 
        {

        }
        private void TextBox13_TextChanged(object sender, EventArgs e) //deset 
        {

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
        private void Label4_Click(object sender, EventArgs e)
        {

        }
        private void Label2_Click_1(object sender, EventArgs e)
        {

        }
        private void Label11_Click(object sender, EventArgs e)
        {

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

        private void Button2_Click(object sender, EventArgs e)
        {
            num_one = num_one + click;
            textBox5.Text = (num_one.ToString());
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            num_two = num_two + click;
            textBox6.Text = (num_two.ToString());
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            num_three = num_three + click;
            textBox8.Text = (num_three.ToString());
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            num_four = num_four + click;
            textBox7.Text = (num_four.ToString());
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            num_five = num_five + click;
            textBox10.Text = (num_five.ToString());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            num_six = num_six + click;
            textBox9.Text = (num_six.ToString());
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            num_seven = num_seven + click;
            textBox16.Text = (num_seven.ToString());
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            num_eight = num_eight + click;
            textBox15.Text = (num_eight.ToString());
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            num_nine = num_nine + click;
            textBox14.Text = (num_nine.ToString());
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            num_ten = num_ten + click;
            textBox13.Text = (num_ten.ToString());
        }

        private void Label1_Click_1(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged_2(object sender, EventArgs e)
        {
            textBox1.Text = (balance.ToString());
        }
    }
}
