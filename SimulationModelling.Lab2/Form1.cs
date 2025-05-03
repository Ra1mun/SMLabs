using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SimulationModelling.Lab2
{
    public partial class Form1 : Form
    {
        private const double K = 0.02;
        private readonly Random _rnd = new Random();
        private int _i;
        private bool _isInit;
        private bool _isStarted;
        private double _price1, _price2;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_isInit)
            {
                chart1.Series[0].Points.Clear();
                _price1 = (double)inputPrice.Value;
                _price2 = (double)inputSecondPrice.Value;
                chart1.Series[0].ToolTip = "X = #VALX, Y = #VALY";
                PrintPoints(0, _price1, _price2);
                _isInit = true;
            }

            if (_isStarted)
            {
                timer1.Stop();
                _isStarted = false;
            }
            else
            {
                timer1.Start();
                _isStarted = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _price1 *= 1 + K * (_rnd.NextDouble() - 0.5);
            _price2 *= 1 + K * (_rnd.NextDouble() - 0.5);
            PrintPoints(_i, _price1, _price2);
            _i++;
        }

        private void PrintPoints(double x, double y1, double y2)
        {
            var point1 = new DataPoint(x, y1);
            var point2 = new DataPoint(x, y2);
            chart1.Series[0].Points.Add(point1);
            chart1.Series[1].Points.Add(point2);
        }
    }
}