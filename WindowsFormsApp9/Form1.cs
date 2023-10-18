using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp9
{
    public partial class Form_Graf : Form
    {

        Graphics gGraf;
        Pen pen;
        int xGraf = 0;
        int yGraf = 0;
        int wGraf = 400;
        int hGraf = 216;
        public Form_Graf()
        {
            InitializeComponent();
            gGraf = pictureBox_Graf.CreateGraphics();
        }

        ~Form_Graf()
        {
            if (gGraf != null)
            {
                gGraf.Dispose();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == ',' || e.KeyChar == (char)13 || e.KeyChar == (char)8)
            {
                return;
            }
            e.Handled = true;
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            ShowGraf();
            SowMarking();
            Result();
        }

        private void ShowGraf()
        {
            HatchBrush ht = new HatchBrush(HatchStyle.Cross, Color.Azure, Color.LightGray);
            gGraf.FillRectangle(ht, xGraf + 45, yGraf, wGraf, hGraf - 3);
            ht.Dispose();
        }

        private void SowMarking()
        {
            pen = new Pen(Color.Blue, 2);
            string name = "";
            Font f = new Font("Arial", 10);

            gGraf.DrawLine(pen, xGraf + 43, yGraf, xGraf + 43, hGraf);
            gGraf.DrawLine(pen, xGraf + 43, hGraf - 1, wGraf + 43, hGraf - 1);
            gGraf.DrawLine(pen, xGraf + 38, yGraf + 16, xGraf + 48, yGraf + 16);
            gGraf.DrawLine(pen, xGraf + 38, yGraf + 105, xGraf + 48, yGraf + 105);
            name = "100%";
            gGraf.DrawString(name, f, Brushes.Red, xGraf, yGraf + 1);
            name = "50%";
            gGraf.DrawString(name, f, Brushes.Orange, xGraf + 10, yGraf + 100);
            name = "0%";
            gGraf.DrawString(name, f, Brushes.Green, xGraf + 20, hGraf - 15);

            pen.Dispose();
            f.Dispose();
        }

        private void Result()
        {
            SolidBrush sb = new SolidBrush(Color.Green);
            int Text = 0;
            int input = 0;
            int max = 0;
            string[] strText = textBox1.Text.Split(new Char[] { (char)13 });

            Text = strText.Length;

            foreach (string s in strText)
            {
                input = Convert.ToInt32(s);

                if (input > max)
                {
                    max = input;
                }
            }
           
            for (int i = 0; i < Text; i++)
            {
                foreach (string s in strText)
                {
                    input = Convert.ToInt32(s);
                    xGraf += (wGraf - 45) / Text + 5;
                    gGraf.FillRectangle(sb, xGraf, hGraf - input - 2, 30, input); 
                }
            }
        }

    }
}