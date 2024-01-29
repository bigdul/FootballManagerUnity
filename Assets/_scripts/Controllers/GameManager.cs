using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

    private int _matchWeek = 0;
    public int MatchWeek => _matchWeek;

    private void Awake()
    {
        instance = this;
    }

    public void SimulateWeek()
    {
        MatchWeek matchWeek = FixturesManager.Instance.GetMatchWeek(_matchWeek);

        matchWeek.SimulateWeek();

        //Increment Matchweek
        _matchWeek++;

        //Rerender home page
        UIManager.Instance.ShowHomePage();
    }
}
