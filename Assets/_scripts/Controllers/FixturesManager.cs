using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixturesManager : MonoBehaviour
{
    public static FixturesManager Instance;

    private List<MatchWeek> MatchWeeks = new List<MatchWeek>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    // Start is called before the first frame update
    public List<MatchWeek> GetMatchWeeks()
    {
        if (MatchWeeks.Count < 1)
        {
            MatchWeeks = FixtureGenerator.GenerateFixtures(TeamManager.Instance.GetAllTeams());
        }

        return MatchWeeks;
    }

    internal MatchWeek GetMatchWeek(int matchWeek)
    {
        if (MatchWeeks.Count < 1)
        {
            GetMatchWeeks();
        }

        return MatchWeeks[matchWeek];
    }
}
