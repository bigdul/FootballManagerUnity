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

        SimMatch();
    }

    public void UpdateMatchUI()
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

    public void UpdateTimer(int time) 
    {
        _currentTime = time;  
        _timerText.text = time.ToString(); 
    }

    private void SimMatch()
    {
        StartCoroutine(_fixture.AdvancedSimulateFixture());

        UpdateMatchUI();
    }

    public void PrintEvent(int minute, string text)
    {
        Instantiate(_matchEventPrefab, _matchEventContainer).GetComponent<MatchEventUI>().SetText($"{minute}: {text}");
    }

    private void ClearEvents()
    {
        foreach(Transform child in _matchEventContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }
}