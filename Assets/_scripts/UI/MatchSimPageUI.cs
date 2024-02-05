using System.Collections;
using TMPro;
using UnityEngine;

public class MatchSimPageUI : UIPage
{
    public static MatchSimPageUI Instance { get; private set; }

    //For fixtures
    [SerializeField] private TextMeshProUGUI _homeClubName, _homeClubScore, _awayClubName, _awayClubScore, _timerText;

    //For league standings
    [SerializeField] private Transform _matchEventContainer;
    [SerializeField] private GameObject _matchEventPrefab;

    private Fixture _fixture;
    private int _currentTime;

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

    protected override void OnShow(Fixture fixture)
    {
        base.OnShow(fixture);
        ClearEvents();

        _fixture = fixture;

        StartCoroutine(SimMatch());
    }

    private void UpdateMatchUI()
    {
        //Club names
        _homeClubName.text = _fixture.homeTeam.teamName;
        _awayClubName.text = _fixture.awayTeam.teamName;

        //Club scores
        _homeClubScore.text = _fixture.homeScore.ToString();
        _awayClubScore.text = _fixture.awayScore.ToString();

        //Timer text
        _timerText.text = _fixture.hasPlayed ? "Full time" : _currentTime.ToString();
    }

    private IEnumerator SimMatch()
    {
        for(int i = 0; i < 91; i++)
        {
            _currentTime = i;

            //Show a placeholder event
            PrintEvent($"Match is at minute {i}");

            //Update the UI
            UpdateMatchUI();

            yield return new WaitForSeconds(0.2f);
        }

        //Just for now, the full match is simulated after the end of 90, we'll update this
        _fixture.SimulateFixture();

        UpdateMatchUI();
    }

    private void PrintEvent(string text)
    {
        Instantiate(_matchEventPrefab, _matchEventContainer).GetComponent<MatchEventUI>().SetText(text);
    }

    private void ClearEvents()
    {
        foreach(Transform child in _matchEventContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }
}