using System;
using System.Windows.Forms;

namespace SimulationModelling.Lab1
{
    public partial class Form1 : Form
    {
        private const double g = 9.81;
        private const double C = 0.15;
        private const double rho = 1.29;

        private double x, y, v0, cosa, sina, S, m, k, vx, vy, dt;
        private double ymax;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            var v = Math.Sqrt(vx * vx + vy * vy);
            vx -= k * vx * v * dt;
            vy -= (g + k * vy * v) * dt;
            x += vx * dt;
            y += vy * dt;

            if (ymax < y)
                ymax = y;

            chart1.Series[0].Points.AddXY(x, y);

            if (y <= 0)
                timer1.Stop();

            textBoxStep.Text = "" + dt;
            textBoxDistance.Text = "" + x;
            textBoxMaxHeight.Text = "" + ymax;
            textBoxSpeedEndPoint.Text = "" + v;
        }

        private void LaucnhButton_Click(object sender, EventArgs e)
        {
            InitializeValues(out var height, out var angle, out var speed);
            x = 0;
            y = height;
            v0 = speed;
            var radiant = angle * Math.PI / 180;
            cosa = Math.Cos(radiant);
            sina = Math.Sin(radiant);

            k = 0.5 * C * rho * S / m;
            vx = v0 * cosa;
            vy = v0 * sina;

            chart1.Series[0].Points.AddXY(x, y);
            timer1.Start();
        }


        private void InitializeValues(out double height, out double angle, out double speed)
        {
            height = (double)inputHeight.Value;
            angle = (double)inputAngle.Value;
            speed = (double)inputSpeed.Value;
            S = (double)inputSize.Value;
            m = (double)inputWeight.Value;
            dt = (double)inputStep.Value;
        }
    }
}