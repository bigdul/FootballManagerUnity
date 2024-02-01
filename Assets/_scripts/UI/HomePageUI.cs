using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomePageUI : UIPage
{
    public static HomePageUI Instance { get; private set; }

    //For fixtures
    [SerializeField] private Transform _fixtureContainer;
    [SerializeField] private GameObject _resultPrefab;

    //For league standings
    [SerializeField] private Transform _leagueStandingContainer;
    [SerializeField] private GameObject _leagueStandingPrefab;

    public void Awake()
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

    protected override void OnShow()
    {
        ClearFixtures();
        ClearLeagueStandings();

        //Get the matchweek from the game manager to render the current results
        var matchWeek = GameManager.instance.MatchWeek;

        //Set up Results panel
        foreach (Fixture f in FixturesManager.Instance.GetMatchWeeks()[matchWeek].fixtures)
        {
            var obj = Instantiate(_resultPrefab, _fixtureContainer);
            obj.GetComponent<FixtureUI>().SetFixtureText(f);
        }

        //Set up league table panel
        int leagueStandingIndex = 1;

        var standings = LeagueManager.Instance.GetStandings();
        foreach(LeagueTableEntry l in standings)
        {
            var obj = Instantiate(_leagueStandingPrefab, _leagueStandingContainer);
            obj.GetComponent<LeagueStandingUI>().SetLeagueStandingText(l, leagueStandingIndex);
            leagueStandingIndex++;
        }
    }

    private void ClearFixtures()
    {
        foreach(Transform t in _fixtureContainer)
        {
            Destroy(t.gameObject);
        }
    }

    private void ClearLeagueStandings()
    {
        foreach(Transform t in _leagueStandingContainer)
        {
            Destroy(t.gameObject);
        }
    }
}
