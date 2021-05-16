using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _9_лаба
{
    public partial class Form1 : Form
    {
        const double b = 4294967299;
        const double m = 9223372036854775808;
        double xNext = b;
        double xBefore, xNow;
        double[] stat = new double[5] { 0, 0, 0, 0, 0 };
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                xBefore = xNext;
                xNext = (b * xBefore) % m;
                xNow = xNext / m;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            if ((double)prob1.Value + (double)prob2.Value + (double)prob3.Value + (double)prob4.Value > 1)
                Error.Text = "Введённые данные некоректны";
            else
            {
                for (int i = 0; i < numericUpDown1.Value; i++)
                {
                    xBefore = xNext;
                    xNext = (b * xBefore) % m;
                    xNow = xNext / m;
                    if (xNow < (double)prob1.Value)
                        stat[0]++;
                    else if (xNow < (double)prob1.Value + (double)prob2.Value)
                        stat[1]++;
                    else if (xNow < (double)prob1.Value + (double)prob2.Value + (double)prob3.Value)
                        stat[2]++;
                    else if (xNow < (double)prob1.Value + (double)prob2.Value + (double)prob3.Value + (double)prob4.Value)
                        stat[3]++;
                    else if (xNow <= 1)
                        stat[4]++;
                }
                for (int i = 0; i < 5; i++)
                {
                    chart1.Series[0].Points.AddXY(i + 1, stat[i] / (double)numericUpDown1.Value);
                    stat[i] = 0;
                }
                Error.Text = "";
            }
        }
    }
}
