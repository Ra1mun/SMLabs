namespace SimulationModelling.Lab4;

public partial class Form1 : Form
{
    private const int None = 0;
    private const int Fire = 1;
    private const int Tree = 2;

    private const int Resolution = 5;
    
    private readonly Pen _gridColor = Pens.Black;
    
    private readonly Brush _treeCellColor = Brushes.GreenYellow;
    private readonly Brush _fireCellColor = Brushes.DarkRed;
    private readonly Brush _noneCellColor = Brushes.White;

    private readonly Random _random = new();


    private int _cols;
    private int _rows;

    private int[,] _field;
    private int[,] _nextField;

    private Graphics _graphics;

    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        StartGame();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
        GenerateNextGeneration();
    }

    private void StartGame()
    {
        _cols = pictureBox1.Width / Resolution;
        _rows = pictureBox1.Height / Resolution;
        _field = new int[_rows, _cols];
        _nextField = new int[_rows, _cols];

        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        _graphics = Graphics.FromImage(pictureBox1.Image);

        DrawGrid();

        GenerateFirstGeneration();

        timer.Start();
    }

    private void GenerateFirstGeneration()
    {
        for (var x = 0; x < _rows; x++)
        for (var y = 0; y < _cols; y++)
            _field[x, y] = _random.Next(100) < 50 ? 2 : 0;

        _field[_rows / 2, _cols / 2] = 1;

        DrawGeneration();
    }

    private void GenerateNextGeneration()
    {
        for (var x = 0; x < _rows; x++)
        for (var y = 0; y < _cols; y++)
            GenerateNextField(x, y);

        Array.Copy(_nextField, _field, _rows * _cols);

        DrawGeneration();
    }

    private void GenerateNextField(int x, int y)
    {
        _nextField[x, y] = _field[x, y];

        switch (_field[x, y])
        {
            case Fire:
                _nextField[x, y] = None;
                break;
            case Tree:
            {
                if (HasNeighbor(x, y, Fire)) _nextField[x, y] = Fire;

                break;
            }
            case None:
            {
                if (HasNeighbor(x, y, Tree) && _random.Next(100) < 50) _nextField[x, y] = Tree;

                break;
            }
        }
    }

    private bool HasNeighbor(int x, int y, int state)
    {
        for (var i = -1; i <= 1; i++)
        for (var j = -1; j <= 1; j++)
        {
            if (i == 0 && j == 0) continue;

            var neighborX = x + i;
            var neighborY = y + j;

            if (neighborX >= 0 && neighborX < _rows && neighborY >= 0 && neighborY < _cols)
                if (_field[neighborX, neighborY] == state)
                    return true;
        }

        return false;
    }

    private void DrawGeneration()
    {
        for (var col = 0; col < _cols; col++)
        for (var row = 0; row < _rows; row++)
        {
            var color = GetColor(_field[row, col]);
            _graphics.FillRectangle(color, col * Resolution + 1, row * Resolution + 1, Resolution - 1,
                Resolution - 1);
        }


        pictureBox1.Invalidate();
    }

    private void DrawGrid()
    {
        var borderPen = new Pen(Color.Black, 2);
        _graphics.DrawRectangle(borderPen, 0, 0, _cols * Resolution, _rows * Resolution);

        for (var i = 1; i < _rows; i++)
            _graphics.DrawLine(_gridColor, 0, i * Resolution, _cols * Resolution, i * Resolution);

        for (var j = 1; j < _cols; j++)
            _graphics.DrawLine(_gridColor, j * Resolution, 0, j * Resolution, _rows * Resolution);
    }

    private Brush GetColor(int state)
    {
        return state switch
        {
            None => _noneCellColor,
            Fire => _fireCellColor,
            Tree => _treeCellColor,
            _ => throw new InvalidOperationException()
        };
    }
}