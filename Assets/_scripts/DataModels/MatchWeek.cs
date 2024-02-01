using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class MatchWeek
{
    public List<Fixture> fixtures;
    public int weekNumber;
    public bool hasBeenPlayed;

    public MatchWeek(int number)
    {
        weekNumber = number;
        fixtures = new List<Fixture>();
    }

    public void AddFixture(Fixture fixture)
    {
        fixtures.Add(fixture);
    }

    public void SimulateWeek()
    {
        foreach (Fixture fixture in fixtures.Where(x => !x.hasPlayed))
        {
            fixture.SimulateFixture();

            LeagueManager.Instance.UpdateStandings(fixture);
        }


        hasBeenPlayed = true;
    }
}
