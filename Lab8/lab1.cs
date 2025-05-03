namespace Lab8;

public partial class lab1 : Form
{
    private const int ProbabilityOfOccurrence = 70;
    
    private readonly Random _random;
    
    public lab1(Random random)
    {
        InitializeComponent();
        _random = random;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var alpha = _random.Next(0, 100);

        label2.Text = alpha <= ProbabilityOfOccurrence ? "Да" : "Нет";
    }
}