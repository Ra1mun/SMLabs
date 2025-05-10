using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab11
{
    public partial class Form1 : Form
    {
        private readonly Random _rand = new Random();

        private const int BinsCount = 15;
        
        // Табличные значения для уровня доверия 0.95
        private Dictionary<int, double> _criticalValues = new Dictionary<int, double>()
        {
            {1, 3.841}, {2, 5.991}, {3, 7.815}, {4, 9.488}, {5, 11.070},
            {6, 12.592}, {7, 14.067}, {8, 15.507}, {9, 16.919}, {10, 18.307}
        };
        
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.ChartAreas[0].AxisX.CustomLabels.Clear();

            var N = int.Parse(TrialsTextBox.Text);
            var mean = double.Parse(MeanTextBox.Text);
            var variance = double.Parse(VarianceTextBox.Text);
            
            var sample = GenerateNormalSample(N, mean, variance);

            var trueMean = ComputeTrueMean(sample);
            var trueVariance = ComputeTrueVariance(sample, trueMean);

            var relErrorMean = Math.Abs(mean - trueMean) / trueMean;
            var relErrorVar = Math.Abs(variance - trueVariance) / trueVariance;

            var sigma = Math.Sqrt(variance);

            var binEdges = ComputeBinEdges(sample);
            
            var freq = ComputeFrequencies(sample);
            
            var chi2 = ChiSquareTest(N, mean, sigma, binEdges, freq);
            
            PlotHistogram(sample, binEdges, freq);
            
            AverageLabel.Text = $"Выборочное среднее: {trueMean:F3}, ош.={relErrorMean:P2}";
            VarianceLabel.Text = $"Выборочная дисперсия: {trueVariance:F3}, ош.={relErrorVar:P2}";
            ChiSquareLabel.Text = $"Хи-квадрат: {chi2}" ;
        }

        private void PlotHistogram(List<double> data, double[] binEdges, int[] frequencies)
        {
            var min = data.Min();
            var max = data.Max();
            var binWidth = (max - min) / BinsCount;

            chart1.Series.Clear();
            var series = new Series();
            series.ChartType = SeriesChartType.Column;
            double maxFrequency = 0;
            for (int i = 0; i < BinsCount; i++)
            {
                var binEdge = binEdges[i] + binWidth / 2;
                
                series.Points.AddXY(binEdge, frequencies[i]);
                
                if (frequencies[i] > maxFrequency)
                    maxFrequency = frequencies[i];
            }
            
            chart1.Series.Add(series);
            
            chart1.ChartAreas[0].AxisY.Maximum = maxFrequency * 1.1;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
        }

        private List<double> GenerateNormalSample(int N, double mean, double variance)
        {
            var result = new List<double>();
            for (int i = 0; i < N; i++)
            {
                var mul = BoxMuller();
                result.Add(Math.Sqrt(variance) * mul + mean);
            }

            return result;
        }

        private double BoxMuller()
        {
            var alfa1 = _rand.NextDouble();
            var alfa2 = _rand.NextDouble();
            return Math.Sqrt(-2.0 * Math.Log(alfa1)) * Math.Cos(2.0 * Math.PI * alfa2);
        }
        
        private static double ComputeTrueMean(List<double> values)
        {
            return values.Average();
        }

        private static double ComputeTrueVariance(List<double> values, double mean)
        {
            return values.Select(x => Math.Pow(x - mean, 2)).Average();
        }
        
        private static double[] ComputeBinEdges(List<double> data)
        {
            var min = data.Min();
            var max = data.Max();
            var binWidth = (max - min) / BinsCount;
            var binEdges = new double[BinsCount + 1];
            for (int i = 0; i <= BinsCount; i++)
                binEdges[i] = min + i * binWidth;
            
            return binEdges;
        }

        private static int[] ComputeFrequencies(List<double> data)
        {
            var min = data.Min();
            var max = data.Max();
            var binWidth = (max - min) / BinsCount;
            var frequencies = new int[BinsCount];
            foreach (var x in data)
            {
                if (x >= min && x < max)
                {
                    var bin = (int)Math.Floor((x - min) / binWidth);
                    if (bin >= 0 && bin < BinsCount)
                        frequencies[bin]++;
                }
            }
            
            return frequencies;
        }
        
        private static double NormalCDF(double x, double mu, double sigma)
        {
            var t = (x - mu) / (sigma * Math.Sqrt(2));
            return 0.5 * (1 + Erf(t));
        }

        private static double Erf(double x)
        {
            // Аппроксимация по формуле Абрамовица и Стигуна
            var a1 = 0.254829592;
            var a2 = -0.284496736;
            var a3 = 1.421413741;
            var a4 = -1.453152027;
            var a5 = 1.061405429;
            var p = 0.3275911;

            int sign = x < 0 ? -1 : 1;
            x = Math.Abs(x);

            var t = 1.0 / (1.0 + p * x);
            var y = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);

            return sign * y;
        }
        
        private static double ChiSquareTest(int N, double mean, double sigma, double[] binEdges, int[] frequencies)
        {
            var expected = new double[BinsCount];
            for (int i = 0; i < BinsCount; i++)
            {
                var a = binEdges[i];
                var b = binEdges[i + 1];
                var p = NormalCDF(b, mean, sigma) - NormalCDF(a, mean, sigma);
                expected[i] = N * p;
            }
            
            double result = 0;
            for (int i = 0; i < BinsCount; i++)
            {
                if (expected[i] > 0)
                    result += Math.Pow(frequencies[i] - expected[i], 2) / expected[i];
            }

            return result;
        }
    }
}