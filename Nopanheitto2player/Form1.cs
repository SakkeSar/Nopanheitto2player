using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nopanheitto2player
{
    public partial class Form1 : Form
    {
        private bool noppa1heitetty = false;
        private bool noppa2heitetty = false;
        

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int noppa1;
            noppa1heitetty = true;
            button1.Enabled = false;
            

                noppa1 = rnd.Next(1, 7);

            label1.Text = noppa1.ToString();

            

            pictureBox1.Image = GetPictureResX(GetNoppaKey1(noppa1));

            if (noppa2heitetty == true)
            {
                checkWinner();

            }
        }

        // 1 , resetointi ja vain yksi napin painallus
        // 2 tasapeli
        // 3 noppa 1 voiton tarkistus


        private void button2_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int noppa2;
            button2.Enabled = false;

            noppa2heitetty = true;

            noppa2 = rnd.Next(1, 7);

            label2.Text = noppa2.ToString();

            pictureBox2.Image = GetPictureResX2(GetNoppaKey2(noppa2));

            



            if (noppa1heitetty == true)
            {
            checkWinner();

            }
        }

        private void checkWinner()
        {

            int arvo1 = Convert.ToInt32(label1.Text);
            int arvo2 = Convert.ToInt32(label2.Text);


            if (arvo1 > arvo2)
            {
                label3.Text = "Pelaaja 1 voitti";
            }

            if (arvo2 > arvo1)
            {
                label3.Text = "Pelaaja 2 voitti";
            }

            if (arvo1 == arvo2)
            {
                label3.Text = "Tasapeli";
            }

        }

        public string GetNoppaKey1(int noppa1) // "N1" - "N6"
        {
           string returnValue = "noppa"; // Noppa picture filenames begin with Text "N" in NoppaPictures.resx

            return returnValue + noppa1;
        }

        public static Image GetPictureResX(string key)
        {
           return Nopanheitto2player.Properties.noppakuvat.ResourceManager.GetObject(key) as Image;
            
            
        }

        public string GetNoppaKey2(int noppa2) // "N1" - "N6"
        {
            string returnValue = "noppa"; // Noppa picture filenames begin with Text "N" in NoppaPictures.resx

            return returnValue + noppa2;
        }

        public static Image GetPictureResX2(string key)
        {
            return Nopanheitto2player.Properties.noppakuvat.ResourceManager.GetObject(key) as Image;


        }

        public Form1()
        {
            InitializeComponent();
            label1.Hide();
            label2.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";

            button1.Enabled = true;
            button2.Enabled = true;

            noppa1heitetty = false;
            noppa2heitetty = false;

            pictureBox1.Image = null;
            pictureBox2.Image = null;
        }


    }
}
