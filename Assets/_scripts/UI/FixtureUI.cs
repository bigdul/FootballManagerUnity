using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FixtureUI : MonoBehaviour
{
    public TextMeshProUGUI HomeTeam, HomeScore, AwayTeam, AwayScore;

    public void SetFixtureText(Fixture fixture)
    {
        HomeTeam.text = fixture.homeTeam.teamName;
        AwayTeam.text = fixture.awayTeam.teamName;

        if (fixture.MatchWeek.hasBeenPlayed)
        {
            HomeScore.text = fixture.homeScore.ToString();
            AwayScore.text = fixture.awayScore.ToString();
        }
        else
        {
            HomeScore.text = string.Empty;
            AwayScore.text = string.Empty;
        }
    }
}
