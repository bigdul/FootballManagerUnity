using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class FixtureUI : MonoBehaviour
{
    public TextMeshProUGUI HomeTeam, HomeScore, AwayTeam, AwayScore;

    public void SetFixtureText(Fixture fixture)
    {
        HomeTeam.text = LinkBuilder.BuildLink(fixture.homeTeam);
        AwayTeam.text = LinkBuilder.BuildLink(fixture.awayTeam);

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
