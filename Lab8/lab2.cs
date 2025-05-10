namespace Lab8;

public partial class lab2 : Form
{
    private readonly Random _rand;
    private readonly List<string> _answers =
    [
        "Бесспорно.",
        "Определённо да.",
        "Можешь быть уверен в этом.",

        "Мне кажется — «да».",
        "Вероятнее всего.",
        "Хорошие перспективы.",
        "Знаки говорят — «да».",
        "Да.",

        "Спроси позже.",

        "Даже не думай.",
        "Мой ответ — «нет».",
        "По моим данным — «нет».",
        "Перспективы не очень хорошие.",
        "Весьма сомнительно."
    ];

    public lab2(Random rand)
    {
        _rand = rand;
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var a = _rand.NextDouble();
        var p = 1 / (double) (_answers.Count - 1);
        var k = (int)(a/p);
        
        button1.Text = _answers[k];
    }
}

public abstract class Test;

public class ProgTest : Test;