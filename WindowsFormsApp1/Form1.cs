using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int[] nahodnaCislaPole(out int[] pole, int intervalX, int intervalY, int pocet)
        {
            pole = new int[pocet];
            Random r = new Random();
            for (int i = 0; i < pocet; i++)
                pole[i] = r.Next(intervalX, intervalY + 1);
            return pole;
        }

        private void zobrazitPole(int[] pole)
        {
            listBox1.Items.Clear();
            listBox1.DataSource = pole;
        }

        private void sudaLichaSoucet(int[] pole, ref int soucetLich, ref int soucetSud)
        {
            for(int i = 0; i < pole.Length; i++)
            {
                if (pole[i] % 2 == 0)
                    soucetSud += pole[i];
                else soucetLich += pole[i];
            }
        }

        private bool rostouci(int[] pole)
        {
            int posledni = -1;
            for(int i = 0; i < pole.Length; i++)
            {
                if (pole[i] > posledni)
                    if (i == pole.Length - 1)
                        return true;
            }
            return false; //Nevím
        }

        private void vymenaPole(int[] pole)
        {
            int max = pole.Max();
            int iMax = Array.IndexOf(pole, max);
            int posledni = pole[pole.Length - 1];

            int x = posledni;

            pole[pole.Length - 1] = max;
            pole[iMax] = x;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(textBox1.Text);
            int x = Convert.ToInt32(textBox2.Text); 
            int y = Convert.ToInt32(textBox3.Text);
            int[] pole = new int[n];

            int a = 0;
            int b = 0;
            

            if (textBox2.Text.Length == 0 || textBox3.Text.Length == 0)
            {
                if(textBox2.Text.Length == 0)
                    x = 1;
                if(textBox3.Text.Length == 0)
                    y = 100;
               
            }
            pole = nahodnaCislaPole(out pole, x, y, n);
            zobrazitPole(pole);
            sudaLichaSoucet(pole, ref a, ref b);
            vymenaPole(pole);
        }
    }
}
