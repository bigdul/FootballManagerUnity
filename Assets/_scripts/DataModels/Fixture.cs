using System;

[System.Serializable]
public class Fixture
{
    public Team homeTeam;
    public Team awayTeam;
    public int homeScore;
    public int awayScore;

    public bool hasPlayed = false;

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

    //Less Shite!
    internal void SimulateFixture()
    {
        homeScore = CalculateScore(homeTeam, awayTeam);
        awayScore = CalculateScore(awayTeam, homeTeam);

        hasPlayed = true;
    }

    public int CalculateScore(Team attacker, Team defender)
    {
        //Static modifier values which can be adjusted
        float techniqueModifier = 0.3f; 
        float physicalModifier = 0.3f; 

        //Calculating offensive score of attacking team, using Attacking, Technique and technique modifier
        var teamOffense = attacker.AvgAttacking + (int)(attacker.AvgTechnique * techniqueModifier);
        //Calculating defending team defence, using defending, physical and physical modifier
        var opponentDefense = defender.AvgDefending + (int)(defender.AvgPhysical * physicalModifier);

        //Add randomness, between 0.1 and 1
        Random random = new Random();
        float randomFactor = 0.1f * random.Next(1, 11); 

        //Calculate the goals score and return using offense
        int score = (int)(((teamOffense/2) + teamOffense * randomFactor) - opponentDefense);
        return Math.Max(score, 0);
    }
}
