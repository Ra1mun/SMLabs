using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Lab9
{
    public partial class Form1 : Form
    {
        private readonly Dictionary<int, double> _distribution = new Dictionary<int, double>
        {
            { 1, 0.1 },
            { 2, 0.25 },
            { 3, 0.3 },
            { 4, 0.15 },
            { 5, 0.2 }
        };
        
        private Dictionary<int, double> _criticalValues = new Dictionary<int, double>()
        {
            { 1, 3.841 },
            { 2, 5.991 },
            { 3, 7.815 },
            { 4, 9.488 },
            { 5, 11.070 }
        };

        private readonly List<TextBox> _evtTextBoxes;
        
        private readonly Random _rand = new Random();



        public Form1()
        {
            InitializeComponent();
            _evtTextBoxes = new List<TextBox>
            {
                textBox1, textBox2, textBox3, textBox4, textBox5
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            var N = int.Parse(trialsBox.Text);

            var observed = GenerateRandomValues(N);

            var empiricalProbs = ComputeEmpiricalProbabilities(observed, N);
            var theoreticalProbs = _distribution;

            var sampleMean = ComputeMean(observed);
            var sampleVariance = ComputeVariance(observed, sampleMean);

            var trueMean = ComputeTrueMean(_distribution);
            var trueVariance = ComputeTrueVariance(_distribution, trueMean);

            var relErrorMean = Math.Abs(sampleMean - trueMean) / trueMean;
            var relErrorVar = Math.Abs(sampleVariance - trueVariance) / trueVariance;

            var chiSquare = ComputeChiSquare(observed, theoreticalProbs, N);
            var check = ChiSquareTest(chiSquare, _distribution.Count - 1);

            foreach(var key in empiricalProbs.Keys)
            {
                _evtTextBoxes[key - 1].Text = empiricalProbs[key].ToString();

                chart1.Series[0].Points.AddXY(key, empiricalProbs[key]);
            }

            var compare = check
                ? $"{_criticalValues[_distribution.Count - 1]} > {chiSquare:F3}"
                : $"{_criticalValues[_distribution.Count - 1]} < {chiSquare:F3}";
            
            AverageLabel.Text = $"Выборочное среднее: {sampleMean:F3}, ош.={relErrorMean:P2}";
            VarianceLabel.Text = $"Выборочная дисперсия: {sampleVariance:F3}, ош.={relErrorVar:P2}";
            ChiSquareLabel.Text = $"Хи-квадрат: {compare} является {check}" ;
        }

        private List<int> GenerateRandomValues(int N)
        {
            var result = new List<int>();
            var cumulative = new List<(double, int)>();

            double sum = 0;
            foreach (var pair in _distribution)
            {
                sum += pair.Value;
                cumulative.Add((sum, pair.Key));
            }

            for (int i = 0; i < N; i++)
            {
                var u = _rand.NextDouble();
                foreach (var (prob, value) in cumulative)
                {
                    if (u <= prob)
                    {
                        result.Add(value);
                        break;
                    }
                }
            }

            return result;
        }
        
        private bool ChiSquareTest(double chi2, int df)
        {
            if (!_criticalValues.TryGetValue(df, out var value)) return false;

            return chi2 <= value;
        }

        private Dictionary<int, double> ComputeEmpiricalProbabilities(List<int> values, int N)
        {
            var freq = new Dictionary<int, int>();
            foreach (var v in values)
            {
                if (!freq.ContainsKey(v)) freq[v] = 0;
                freq[v]++;
            }

            return freq.ToDictionary(kv => kv.Key, kv => (double)kv.Value / N);
        }

        private static double ComputeMean(List<int> values)
        {
            return values.Average();
        }

        private static double ComputeVariance(List<int> values, double mean)
        {
            return values.Select(x => Math.Pow(x - mean, 2)).Average();
        }

        private static double ComputeTrueMean(Dictionary<int, double> distribution)
        {
            return distribution.Sum(kv => kv.Key * kv.Value);
        }

        private static double ComputeTrueVariance(Dictionary<int, double> distribution, double mean)
        {
            return distribution.Sum(kv => kv.Value * Math.Pow(kv.Key - mean, 2));
        }

        private static double ComputeChiSquare(List<int> observed, Dictionary<int, double> theoretical, int N)
        {
            var freq = observed.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

            double chi2 = 0;
            foreach (var key in theoretical.Keys)
            {
                int O;
                if(freq.TryGetValue(key, out var value))
                {
                    O = 0;
                }

                O = value;
                var E = theoretical[key] * N;
                chi2 += Math.Pow(O - E, 2) / E;
            }

            return chi2;
        }

        
    }
}
