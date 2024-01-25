[System.Serializable]
public class Fixture
{
    public Team homeTeam;
    public Team awayTeam;
    public int homeScore;
    public int awayScore;

    public MatchWeek MatchWeek;

    // Constructor
    public Fixture(Team home, Team away, MatchWeek matchWeek)
    {
        homeTeam = home;
        awayTeam = away;
        homeScore = 0;
        awayScore = 0;
        MatchWeek = matchWeek;

    }
}
