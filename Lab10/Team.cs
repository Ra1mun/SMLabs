namespace Lab10
{
    public class Team
    {
        public string Name { get; private set; }
        public string Country { get; private set; }
        public int Points { get; private set; }
        public int Wins { get; private set; }
        public int Draws { get; private set; }
        public int Losses { get; private set; }
        public int GoalsFor { get; private set; }
        public int GoalsAgainst { get; private set; }
        
        public int GoalDifference => GoalsFor - GoalsAgainst;

        public Team(string name, string country)
        {
            Name = name;
            Country = country;
        }
        
        public void PlayMatch(int goalsScored, int goalsConceded)
        {
            GoalsFor += goalsScored;
            GoalsAgainst += goalsConceded;

            if (goalsScored > goalsConceded)
            {
                Wins++;
                Points += 3;
            }
            else if (goalsScored == goalsConceded)
            {
                Draws++;
                Points += 1;
            }
            else
            {
                Losses++;
            }
        }

        public void ClearResults()
        {
            Points = 0;
            Wins = 0;
            Draws = 0;
            Losses = 0;
            GoalsFor = 0;
            GoalsAgainst = 0;
        }
    }
}