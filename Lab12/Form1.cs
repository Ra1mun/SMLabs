using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace Lab12
{
    public partial class Form1 : Form
    {
        private static double[,] Q =
        {
            { -0.4, 0.3, 0.1 },
            {  0.4, -0.8, 0.4 },
            {  0.1, 0.4, -0.5 }
        };
        private static string[] WeatherStates = { "Clear", "Cloudy", "Overcast" };
        private readonly Random _rand = new Random();
        private int _currentWeather;
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void SimulateWeather()
        {
            if (!TryCalculateExitRate(out var exitRate))
                return;
            
            var probs = ComputeTransition(exitRate);

            GenerateNextState(probs);
        }

        private double[] ComputeTransition(double exitRate)
        {
            var stateLength = WeatherStates.Length;
            var probs = new double[stateLength];
            for (int j = 0; j < probs.Length; j++)
                probs[j] = _currentWeather != j ? Q[_currentWeather, j] / exitRate : 0;
            
            return probs;
        }

        private void GenerateNextState(double[] probs)
        {
            var r = _rand.NextDouble();
            double cumulative = 0;
            var nextState = _currentWeather;
            for (int j = 0; j < 3; j++)
            {
                cumulative += probs[j];
                if (r <= cumulative)
                {
                    nextState = j;
                    break;
                }
            }

            _currentWeather = nextState;
        }

        private bool TryCalculateExitRate(out double exitRate)
        {
            var stateLength = WeatherStates.Length;
            
            exitRate = 0;
            for (int j = 0; j < stateLength; j++)
            {
                if (j != _currentWeather)
                    exitRate += Q[_currentWeather, j];
            }

            return exitRate != 0;
        }

        private void timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            SimulateWeather();
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            if(!timer1.Enabled)
                timer1.Start();

            timer1.Stop();
        }
    }
}