using System;
using TMPro;
using UnityEngine;

public class ClubDetailsUI : UIPage
{
    public static ClubDetailsUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _clubTitleText, _stadiumCapacityText, _yearFoundedText;
    [SerializeField] private Transform _teamContainer;
    [SerializeField] private GameObject _teamPlayerPrefab;


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

    protected override void OnShow(Team team)
    {
        base.OnShow(team);

        ClearTeam();

        _clubTitleText.text = team.teamName;
        _yearFoundedText.text = $"Year founded: {team.YearFounded}";
        _stadiumCapacityText.text = $"Stadium Capacity: {team.StadiumCapacity}";

        PopulateTeamUI(team);
    }

    private void PopulateTeamUI(Team team)
    {
        foreach(Player p in team.Players)
        {
            var newPlayerUI = Instantiate(_teamPlayerPrefab, _teamContainer);

            newPlayerUI.GetComponent<TeamPlayerUI>().SetPlayer(p);
        }
    }

    private void ClearTeam()
    {
        foreach(Transform child in _teamContainer)
        {
            Destroy(child.gameObject);
        }
    }
}