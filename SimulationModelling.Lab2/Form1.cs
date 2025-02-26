using System;
using System.Windows.Forms;

namespace SimulationModelling.Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const double k = 0.02;
        double price1, price2;
        int i = 0;
        bool isStarted = false;
        bool isInit = false;
        Random rnd = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isInit)
            {
                chart1.Series[0].Points.Clear();
                price1 = (double)inputPrice.Value;
                price2 = (double)inputSecondPrice.Value;
                chart1.Series[0].Points.AddXY(0, price1);
                chart1.Series[1].Points.AddXY(0, price2);
                isInit = true;
            }

            if (isStarted)
            {
                timer1.Stop();
                isStarted = false;
            }
            else
            {
                timer1.Start();
                isStarted = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            price1 = price1 * (1 + k * (rnd.NextDouble() - 0.5));
            chart1.Series[0].Points.AddXY(i, price1);
            price2 = price2 * (1 + k * (rnd.NextDouble() - 0.5));
            chart1.Series[1].Points.AddXY(i, price2);
            i++;
        }
    }
}
