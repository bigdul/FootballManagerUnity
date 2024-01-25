public class LeagueTableEntry
{
    public Team Team { get; private set; }
    public int Points { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference => GoalsFor - GoalsAgainst;

    public LeagueTableEntry(Team team)
    {
        Team = team;
        Points = 0;
        GoalsFor = 0;
        GoalsAgainst = 0;
    }
}