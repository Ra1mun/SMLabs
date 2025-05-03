namespace Lab8;

public partial class Form1 : Form
{
    private readonly Random random = new Random();
    
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var form = new lab1(random);
        
        form.Show();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        var form = new lab2(random);
        
        form.Show();
    }
}