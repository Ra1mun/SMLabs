using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab8._3
{
    public partial class Form1 : Form
    {
        private readonly Random _rand = new Random();

        private readonly List<string> _events = new List<string>()
        {
            "A1",
            "A2",
            "A3",
            "A4",
            "A5"
        };

        private readonly List<TextBox> _evtTextBoxes;


        public Form1()
        {
            InitializeComponent();
            _evtTextBoxes = new List<TextBox>()
            {
                textBox1, textBox2, textBox3, textBox4, textBox5
            };
        }


        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();

            var N = double.Parse(trialsBox.Text);

            var statistics = new Dictionary<string, int>();

            foreach (var evt in _events)
            {
                statistics[evt] = 0;
            }

            for (int k = 0; k < N; k++)
            {
                var keys = statistics.Keys.ToList();
                var index = _rand.Next(0, keys.Count);
                statistics[keys[index]]++;
            }

            for (int k = 0; k < _events.Count; k++)
            {
                string evt = _events[k];
                var frequencie = statistics[evt] / N;

                chart1.Series[0].Points.AddXY(evt, frequencie);

                _evtTextBoxes[k].Text = frequencie.ToString();
            }
        }
    }
}
