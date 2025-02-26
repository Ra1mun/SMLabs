using System;
using System.Drawing;
using System.Windows.Forms;

namespace SimulationModelling.Lab3
{
    public partial class Form1 : Form
    {
        private const int Resolution = 10;
        
        private readonly bool[] _rules = new bool[8];
        private readonly Random _random = new Random();

        private bool _isStarted;
        private bool _isInit;
        private bool[,] _field;
        
        private int _rows;
        private int _cols;
        private int _currentRow;
        private int _rule;

        private Graphics _graphics;


        public Form1()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (!_isStarted)
            {
                StartGame();
                _isStarted = true;
            }
            else
            {
                StopGame();
                _isStarted = false;
            }
        }

        private void StartGame()
        {
            if (_rule != inputRule.Value && _isInit)
            {
                _graphics.Clear(Color.White);
                _currentRow = 1;
            }
            
            _rule = (int)inputRule.Value;
            _cols = pictureBox1.Width / Resolution;
            _rows = pictureBox1.Height / Resolution;
            _field = new bool[_cols, _rows];
            InitializeRules(_rule);

            for (int i = 0; i < _cols; i++)
            {
                _field[i, 0] = _random.Next(2) == 0;
            }

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(pictureBox1.Image);

            DrawGrid();
            DrawGeneration(0);
            
            _isInit = true;

            timer1.Start();
        }

        private void DrawGrid()
        {
            var borderPen = new Pen(Color.Black, 2);
            _graphics.DrawRectangle(borderPen, 0, 0, _cols * Resolution, _rows * Resolution);

            for (int i = 1; i < _rows; i++)
            {
                _graphics.DrawLine(Pens.Black, 0, i * Resolution, _cols * Resolution, i * Resolution);
            }

            for (int j = 1; j < _cols; j++)
            {
                _graphics.DrawLine(Pens.Black, j * Resolution, 0, j * Resolution, _rows * Resolution);
            }
        }

        private void DrawGeneration(int row)
        {
            for (int col = 0; col < _cols; col++)
            {
                if (_field[col, row])
                {
                    _graphics.FillRectangle(Brushes.Turquoise, col * Resolution + 1, row * Resolution + 1, Resolution - 1, Resolution - 1);
                }
            }
            pictureBox1.Invalidate();
        }

        private void InitializeRules(int rule)
        {
            for (int i = 0; i < 8; i++)
            {
                _rules[i] = (rule & (1 << i)) != 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_currentRow >= _rows)
            {
                timer1.Stop();
                return;
            }

            for (int col = 0; col < _cols; col++)
            {
                var left = _field[(col - 1 + _cols) % _cols, _currentRow - 1];
                var center = _field[col, _currentRow - 1];
                var right = _field[(col + 1) % _cols, _currentRow - 1];

                int pattern = GetPatternIndex(left, center, right);
                _field[col, _currentRow] = _rules[pattern];
            }

            DrawGeneration(_currentRow);

            _currentRow++;
        }

        private int GetPatternIndex(bool left, bool center, bool right)
        {
            return (left ? 4 : 0) | (center ? 2 : 0) | (right ? 1 : 0);
        }

        private void StopGame()
        {
            timer1.Stop();
        }
    }
}