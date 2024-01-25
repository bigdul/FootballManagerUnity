using System;
using System.Collections.Generic;
using System.Linq;

public static class FixtureGenerator
{
    // Generates a round-robin fixture list
    public static List<MatchWeek> GenerateFixtures(List<Team> teams)
    {
        int numberOfTeams = teams.Count;

        List<MatchWeek> matchWeeks = new List<MatchWeek>();
        int totalRounds = numberOfTeams - 1;
        int matchesPerRound = numberOfTeams / 2;

        for (int round = 0; round < totalRounds * 2; round++) // Double round-robin
        {
            MatchWeek matchWeek = new MatchWeek(round + 1);
            for (int match = 0; match < matchesPerRound; match++)
            {
                int homeIndex = (round + match) % (numberOfTeams - 1);
                int awayIndex = (numberOfTeams - 1 - match + round) % (numberOfTeams - 1);

                // Last team stays in the same place while the others rotate around it.
                if (match == 0)
                {
                    awayIndex = numberOfTeams - 1;
                }

                Team homeTeam = round >= totalRounds ? teams[awayIndex] : teams[homeIndex];
                Team awayTeam = round >= totalRounds ? teams[homeIndex] : teams[awayIndex];

                matchWeek.AddFixture(new Fixture(homeTeam, awayTeam, matchWeek));


            }
            matchWeeks.Add(matchWeek);
        }

        return matchWeeks;
    }
}

