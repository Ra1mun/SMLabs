using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab10
{
    public partial class Form1 : Form
    {
        private readonly PoissonDistribution _poissonDistribution = new PoissonDistribution();

        private readonly List<Team> _teams = new List<Team>
        {
            new Team("Manchester United", "ENG"),
            new Team("Real Madrid", "ESP"),
            new Team("Bayern Munich", "GER"),
            new Team("Liverpool", "ENG"),
            new Team("Barcelona", "ESP"),
            new Team("Juventus", "ITA"),
            new Team("Manchester City", "ENG"),
            new Team("AC Milan", "ITA"),
            new Team("Borussia Dortmund", "GER"),
            new Team("Arsenal", "ENG"),
            new Team("Atletico Madrid", "ESP"),
            new Team("Inter Milan", "ITA"),
            new Team("RB Leipzig", "GER"),
            new Team("Tottenham Hotspur", "ENG"),
            new Team("Sevilla", "ESP"),
            new Team("Napoli", "ITA"),
            new Team("Eintracht Frankfurt", "GER"),
            new Team("Newcastle United", "ENG"),
            new Team("Benfica", "POR"),
            new Team("Paris Saint-Germain", "FRA"),
            new Team("Porto", "POR")
        };
        
        public Form1()
        {
            InitializeComponent();
        }
        
        private void StartButton_Click(object sender, EventArgs e)
        {
            SimulateMatches();
            DisplayLeaderboard();
            
            _teams.ForEach(x => x.ClearResults());
        }

        private void SimulateMatches()
        {
            for (int i = 0; i < _teams.Count; i++)
            {
                for (int j = i + 1; j < _teams.Count; j++)
                {
                    var home = _teams[i];
                    var away = _teams[j];

                    var goalsHome = _poissonDistribution.Generate(1.5);
                    var goalsAway = _poissonDistribution.Generate(1.5);

                    home.PlayMatch(goalsHome, goalsAway);
                    away.PlayMatch(goalsAway, goalsHome);
                }
            }
        }

        private void DisplayLeaderboard()
        {
            resultListBox.Items.Clear();
            
            var orderTeams = _teams.OrderByDescending(x => x.Points).ThenByDescending(x => x.GoalDifference).ToList();

            resultListBox.Items.Add("Pos | Team          | Country | Pts | W | D | L | GF | GA | GD");
            for (int position = 0; position < orderTeams.Count; position++)
            {
                var team = orderTeams[position];
                var text = $"{position + 1,-3} | {team.Name,-13} | {team.Country, 3} | {team.Points,3} | {team.Wins,2} | {team.Draws,2} | {team.Losses,2} | {team.GoalsFor,2} | {team.GoalsAgainst,2} | {team.GoalDifference,3}";
                resultListBox.Items.Add(text);
            }
        }
    }
}