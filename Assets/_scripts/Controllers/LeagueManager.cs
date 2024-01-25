using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LeagueManager : MonoBehaviour
{
    private List<LeagueTableEntry> _standings;

    public static LeagueManager Instance { get; private set; }

    public LeagueManager()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            throw new System.Exception("Only one instance of LeagueTableManager is allowed");
        }

        _standings = new List<LeagueTableEntry>();
    }

    // Initialize standings with teams
    public void InitializeStandings()
    {
        _standings.Clear();
        foreach (var team in TeamManager.Instance.GetAllTeams())
        {
            _standings.Add(new LeagueTableEntry(team));
        }
    }

    // Update standings based on a fixture
    public void UpdateStandings(Fixture fixture)
    {
        var homeTeamEntry = _standings.FirstOrDefault(entry => entry.Team == fixture.homeTeam);
        var awayTeamEntry = _standings.FirstOrDefault(entry => entry.Team == fixture.awayTeam);

        if (homeTeamEntry == null || awayTeamEntry == null)
        {
            Debug.LogError("Team not found in league standings.");
            return;
        }

        // Assuming Fixture has properties like HomeGoals, AwayGoals
        int homeGoals = fixture.homeScore;
        int awayGoals = fixture.awayScore;

        homeTeamEntry.GoalsFor += homeGoals;
        homeTeamEntry.GoalsAgainst += awayGoals;

        awayTeamEntry.GoalsFor += awayGoals;
        awayTeamEntry.GoalsAgainst += homeGoals;

        if (homeGoals > awayGoals) // Home win
        {
            homeTeamEntry.Points += 3;
        }
        else if (homeGoals < awayGoals) // Away win
        {
            awayTeamEntry.Points += 3;
        }
        else // Draw
        {
            homeTeamEntry.Points += 1;
            awayTeamEntry.Points += 1;
        }

        SortStandings();
    }

    // Sort standings based on points, then goal difference, then goals for
    private void SortStandings()
    {
        _standings = _standings.OrderByDescending(entry => entry.Points)
                             .ThenByDescending(entry => entry.GoalDifference)
                             .ThenByDescending(entry => entry.GoalsFor)
                             .ToList();
    }

    // Get current standings
    public List<LeagueTableEntry> GetStandings()
    {
        if(_standings.Count < 1)
        {
            InitializeStandings();
        }

        return _standings;
    }
}