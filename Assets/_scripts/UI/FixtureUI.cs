using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class FixtureUI : MonoBehaviour
{
    public TextMeshProUGUI HomeTeam, HomeScore, AwayTeam, AwayScore;
    [SerializeField] private Button _simButton;
    public Fixture Fixture;

    public void SetFixtureText(Fixture fixture)
    {
        Fixture = fixture;

        ConfigureSimulateButton(fixture);

        HomeTeam.text = LinkBuilder.BuildLink(fixture.homeTeam);
        AwayTeam.text = LinkBuilder.BuildLink(fixture.awayTeam);

        if (fixture.hasPlayed)
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

    private void ConfigureSimulateButton(Fixture fixture)
    {
        var buttonActive = !fixture.hasPlayed && fixture.MatchWeek.weekNumber - 1 == GameManager.instance.MatchWeek;

        _simButton.gameObject.SetActive(buttonActive);
        if (buttonActive)
        {
            _simButton.onClick.RemoveAllListeners();
            _simButton.onClick.AddListener(() => OnSimulateClick());
        }
    }

    public void OnSimulateClick()
    {
        Fixture.SimulateFixture();

        LeagueManager.Instance.UpdateStandings(Fixture);

        UIManager.Instance.ShowHomePage();
    }
}
