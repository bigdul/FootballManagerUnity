using System;
using System.Collections;
using UnityEngine;

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
        System.Random random = new System.Random();
        float randomFactor = 0.1f * random.Next(1, 11); 

        //Calculate the goals score and return using offense
        int score = (int)(((teamOffense/2) + teamOffense * randomFactor) - opponentDefense);
        return Math.Max(score, 0);
    }

    //Match sim logic:
    internal IEnumerator AdvancedSimulateFixture()
    {
        // Initial setup for the match
        Team currentPossessor = homeTeam;
        Team opponent;

        homeTeam.CurrentScore = 0;
        awayTeam.CurrentScore = 0;

        for (int minute = 1; minute <= 90; minute++)
        {
            opponent = (currentPossessor == homeTeam) ? awayTeam : homeTeam;

            yield return new WaitForSeconds(2.5f);

            // Simulate phases of play here
            if (PossessionPhase(currentPossessor, opponent, minute))
            {
                minute++;
                MatchSimPageUI.Instance.UpdateTimer(minute);
                yield return new WaitForSeconds(1.5f);

                if (AdvancementPhase(currentPossessor, minute))
                {
                    minute++;
                    MatchSimPageUI.Instance.UpdateTimer(minute);
                    yield return new WaitForSeconds(1.8f);

                    if (ChanceCreationPhase(currentPossessor, opponent, minute))
                    {
                        minute++;
                        MatchSimPageUI.Instance.UpdateTimer(minute);
                        yield return new WaitForSeconds(1.6f);

                        // Clear Chance Phase - Higher probability of scoring
                        if (UnityEngine.Random.Range(0.1f, 1) < 0.3f)
                        {
                            minute++;
                            MatchSimPageUI.Instance.UpdateTimer(minute);
                            yield return new WaitForSeconds(2.5f);

                            if (ClearChancePhase(currentPossessor, opponent, minute))
                            {
                                MatchSimPageUI.Instance.PrintEvent(minute, $"{currentPossessor.teamName} scores on a clear chance!");
                                currentPossessor.CurrentScore++;
                            }
                            else
                            {
                                MatchSimPageUI.Instance.PrintEvent(minute, $"{currentPossessor.teamName} misses the clear chance.");
                            }
                        }
                        else if (ScoringAttemptPhase(currentPossessor, opponent, minute))
                        {
                            yield return new WaitForSeconds(2.2f);
                            MatchSimPageUI.Instance.PrintEvent(minute, $"{currentPossessor.teamName} scores!");
                            currentPossessor.CurrentScore++;
                        }
                    }
                }
            }

            // Switch possession if no clear chance or scoring attempt succeeds
            currentPossessor = opponent;

            homeScore = homeTeam.CurrentScore;
            awayScore = awayTeam.CurrentScore;

            MatchSimPageUI.Instance.UpdateMatchUI();
        }

        hasPlayed = true;
    }

    bool PossessionPhase(Team team, Team opponent, int minute)
    {
        float possessionChance = (7 + team.AvgTechnique + team.AvgPhysical) - (opponent.AvgTechnique + opponent.AvgPhysical);
        float randomRoll = UnityEngine.Random.Range(0f, 10f); // Random factor
        if (randomRoll <= possessionChance)
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"{team.teamName} with some nice build up play.");
            return true;
        }
        else {
            MatchSimPageUI.Instance.PrintEvent(minute,$"{team.teamName} loses possession.");
            return false;
        }
    }


    bool AdvancementPhase(Team team, int minute)
    {
        float advancementChance = team.AvgAttacking/2 + team.AvgTechnique;
        float randomRoll = UnityEngine.Random.Range(0f, 10f); // Random factor
        if (randomRoll <= advancementChance)
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"{team.teamName} are advancing into the opposition's half.");
            return true;
        }
        else
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"{team.teamName} with a poor pass. They've lost possession!");
            return false;
        }
    }


    bool ChanceCreationPhase(Team team, Team opponent, int minute)
    {
        float chanceCreationChance = (team.AvgAttacking/2 + team.AvgTechnique + 3) - opponent.AvgDefending;
        float randomRoll = UnityEngine.Random.Range(0f, 10f); // Random factor
        if (randomRoll <= chanceCreationChance)
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"This is a goal scoring chance for {team.teamName}");
            return true;
        }
        else
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"{team.teamName} lose the ball!");
            return false;
        }
    }


    bool ScoringAttemptPhase(Team team, Team opponent, int minute)
    {
        float scoringChance = team.AvgAttacking * 0.8f - opponent.AvgDefending * 0.2f;
        float randomRoll = UnityEngine.Random.Range(0f, 10f); // Random factor
        if (randomRoll <= scoringChance)
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"GOAL FOR {team.teamName}!");
            return true;
        }
        else
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"The shot by {team.teamName} is saved!");
            return false;
        }
    }


    bool ClearChancePhase(Team team, Team opponent, int minute)
    {
        float clearChanceProbability = 0.75f; // High probability for clear chances
        bool clearChanceResult = UnityEngine.Random.Range(0.1f, 1) < clearChanceProbability;

        if (clearChanceResult)
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"GOAL FOR {team.teamName}!!");
        }
        else
        {
            MatchSimPageUI.Instance.PrintEvent(minute, $"What a chance!! {team.teamName} waste a chance 1 on 1 with the keeper!");
        }

        return clearChanceResult;
    }
}
