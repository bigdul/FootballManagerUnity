using System;
using System.Linq;
using TMPro;
using UnityEngine;

public class ClubDetailsUI : UIPage
{
    public static ClubDetailsUI Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI _clubTitleText, _stadiumCapacityText, _yearFoundedText;
    [SerializeField] private TextMeshProUGUI _statAttacking, _statDefending, _statTechnique, _statPhysical;
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
        ShowAverageStats(team);
    }

    private void ShowAverageStats(Team team)
    {
        _statAttacking.text = $"{team.AvgAttacking} Attacking";
        _statDefending.text = $"{team.AvgDefending} Defending";
        _statTechnique.text = $"{team.AvgTechnique} Technique";
        _statPhysical.text = $"{team.AvgPhysical} Physical";
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